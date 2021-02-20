using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Perfect_Freight_Manager.Forms
{
    class GraficosDinamicos
    {
        int x;
        public void p_x_set(int valor)
        {
            x = valor;
        }
        public void grafico(Chart ejemplo)
        {
            ejemplo.ChartAreas[0].Area3DStyle.Enable3D = true;
            if (ejemplo.Series[0].Points.Count > 10)
            {
                ejemplo.Series[0].Points.RemoveAt(0);
                ejemplo.Update();
            }
            ejemplo.Series[0].Points.AddXY(x, new Random().NextDouble());
            
        }
    }
}
