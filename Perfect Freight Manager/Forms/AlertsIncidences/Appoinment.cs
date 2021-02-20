using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    public partial class Appoinment : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        int cuantos = 0, sgte=0;
        int totalgood = 0, totalmedium = 0, totalbad = 0;
        public Appoinment()
        {
            InitializeComponent();
            dgvAppoinment.DataSource = conectandose.Consultar("revenues");
            cuantos = dgvAppoinment.Rows.GetRowCount(0) - 1;
            lvAppoinment.Items.Clear();
            while (cuantos > 0)
            {
                dgvAppoinment.DataSource = conectandose.Consultar("revenues");
                string loadid = Convert.ToString(dgvAppoinment.Rows[sgte].Cells[3].Value);
                string driver = Convert.ToString(dgvAppoinment.Rows[sgte].Cells[5].Value);
                string load = Convert.ToString(dgvAppoinment.Rows[sgte].Cells[3].Value);
                string broker = Convert.ToString(dgvAppoinment.Rows[sgte].Cells[1].Value);
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(Convert.ToString(dgvAppoinment.Rows[sgte].Cells[5].Value));
                item.SubItems.Add(Convert.ToString(dgvAppoinment.Rows[sgte].Cells[3].Value));
                int sgte2 = 0;
                int good = 0, medium = 0, bad = 0;
                dgvAppoinment.DataSource = conectandose.ConsultarPickup("rvpickupdrops",loadid);
                int cuantos2 = dgvAppoinment.Rows.GetRowCount(0) - 1;
                
                while (cuantos2 > 0)
                {
                    DateTime FechaArrivaDate = Convert.ToDateTime(dgvAppoinment.Rows[sgte2].Cells[5].Value);
                    DateTime FechaAppoinmentDate = Convert.ToDateTime(dgvAppoinment.Rows[sgte2].Cells[8].Value);
                    TimeSpan tspan = FechaAppoinmentDate - FechaArrivaDate;
                    int horas = tspan.Hours;
                    if (horas <= 1)
                    {
                        good = good + 1;
                    }
                    else if (horas > 1 && horas <= 5)
                    {
                        medium = medium + 1;
                    }
                    else
                    {
                        bad = bad + 1;
                    }
                    cuantos2--;
                    sgte2++;
                }
                item.SubItems.Add(good.ToString());
                item.SubItems.Add(medium.ToString());
                item.SubItems.Add(bad.ToString());
                item.SubItems.Add(broker);
                lvAppoinment.Items.Add(item);
                totalbad = totalbad + bad;
                totalgood = totalgood + good;
                totalmedium = totalmedium + medium;
                cuantos--;
                sgte++;
            }
            lblGood.Text = totalgood.ToString();
            lblMedium.Text = totalmedium.ToString();
            lblBad.Text = totalbad.ToString();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
