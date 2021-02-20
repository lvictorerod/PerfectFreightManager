using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Perfect_Freight_Manager.Forms
{
    public partial class UserControlDashboard : UserControl
    {
        public UserControlDashboard()
        {
            InitializeComponent();
            timer1.Enabled = true;
            textBox1.Text = "0";

            double y = 20;
            for (int x = 20; x < 120; x+=20)
            { 
                if (x == 40)
                {
                    y = y + 35;
                }
                else if(x == 60)
                {
                    y = y + 20;
                }else if (x == 80)
                {
                    y = y - 20;
                }
                chart1.Series["Series1"].Points.Add(x, y);
            }
        }
        GraficosDinamicos obj_graficar = new GraficosDinamicos();
        private void timer1_Tick(object sender, EventArgs e)
        {
            obj_graficar.p_x_set(int.Parse(textBox1.Text));
            obj_graficar.grafico(chart2);
        }
    }
}
