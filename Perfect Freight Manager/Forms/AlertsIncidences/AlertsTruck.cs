using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    public partial class AlertsTruck : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        string TblName = "trucksprofiles";
        int codigo;
        int sgtetr = 0;
        public AlertsTruck(string Truck)
        {
            InitializeComponent();
            dgvTrucks.DataSource = conectandose.ConsultarTrucks(TblName,Truck);

            codigo = Convert.ToInt32(dgvTrucks.Rows[sgtetr].Cells[0].Value);

            conn.Open();
            string query = "select photo from " + TblName + " where id = " + codigo;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "img");

            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["img"].Rows[0];
            datos = (byte[])dr["photo"];
            MemoryStream ms = new MemoryStream(datos);
            pbTruckPhoto.Image = System.Drawing.Bitmap.FromStream(ms);
            conn.Close();


            txtTruckCompany.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[1].Value);
            txtTruckOwner.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[2].Value);
            txtTruckNumber.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[3].Value);
            txtTruckVin.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[4].Value);
            txtTruckYear.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[5].Value);
            txtTruckMake.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[6].Value);
            txtTruckModel.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[7].Value);
            txtTruckTag.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[8].Value);
            txtTruckPmMileage.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[9].Value);
            txtTruckColor.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[10].Value);

            txtTruckTire.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[11].Value);
            txtTruckAxles.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[12].Value);
            txtTruckEngineMake.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[13].Value);
            txtTruckEnginePower.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[14].Value);
            txtTruckEngineSn.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[15].Value);
            txtTruckTranspType.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[16].Value);
            txtTruckEmptyWgt.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[17].Value);
            txtTruckFuelTank.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[18].Value);
            txtTruckNotes.Text = Convert.ToString(dgvTrucks.Rows[sgtetr].Cells[19].Value);
            dtLicenseTruck.Value = Convert.ToDateTime(dgvTrucks.Rows[sgtetr].Cells[21].Value);
            dtLicenseExpireTruck.Value = Convert.ToDateTime(dgvTrucks.Rows[sgtetr].Cells[22].Value);
        }

        private void btnUpdTruck_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update trucksprofiles set licensedate='" + dtLicenseTruck.Value + "', licensedateexpire='" + dtLicenseExpireTruck.Value + "'" + " where id=" + codigo, conn);
                
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
