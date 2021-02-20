using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truck_Fleet_Manager
{
    public partial class mnShipReceiver : Form
    {
        public mnShipReceiver()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
            //"http://www.mapquest.com/?q=,,++";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
            //https://www.bing.com/maps/?q=,+,+++
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
            //https://www.google.com/maps/place/,+,+++
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
            //https://www.weather.com/weather/today/l/
        }

        private void mnShipReceiver_Load(object sender, EventArgs e)
        {

        }
    }
}
