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
    public partial class mnExpenses : Form
    {
        public mnExpenses()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mnVendor vendor = new mnVendor();
            vendor.ShowDialog();
        }
    }
}
