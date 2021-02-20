using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Models;

namespace Truck_Fleet_Manager
{
    public partial class frmShipReceiver : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        public frmShipReceiver()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
            //"http://www.mapquest.com/?q=,,++";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
            //https://www.bing.com/maps/?q=,+,+++
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
            //https://www.google.com/maps/place/,+,+++
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmWebServicio servicio = new frmWebServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
            //https://www.weather.com/weather/today/l/
        }

        private void mnShipReceiver_Load(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
