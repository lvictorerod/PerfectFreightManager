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
    public partial class mnClients : Form
    {
        public mnClients()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mnInsurance insurenca = new mnInsurance();
            insurenca.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("http://www.mapquest.com/?q=,,++");
            servicio.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.bing.com/maps/?q=,+,+++");
            servicio.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.google.com/maps/place/,+,+++");
            servicio.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webServicio servicio = new webServicio("https://www.weather.com/weather/today/l/");
            servicio.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            mnRevenue revenue = new mnRevenue();
            revenue.ShowDialog();
        }
    }
}
