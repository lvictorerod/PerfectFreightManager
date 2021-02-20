using Perfect_Freight_Manager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Truck_Fleet_Manager;

namespace Perfect_Freight_Manager.Forms
{  
    public partial class Dashboard : Form
    {
        frmLogin login = new frmLogin();
        string usuario = "";
        private bool EsColapsado;
        public Dashboard()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToLongDateString();
            timer.Start();
            Sidepanel.Height = btnDashboard.Height;
            Sidepanel.Top = btnDashboard.Top;
            userControlDashboard1.BringToFront();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            Colapsar.Stop();
            timer1.Stop();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnDashboard.Height;
            Sidepanel.Top = btnDashboard.Top;
            userControlDashboard1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnLoad.Height;
            Sidepanel.Top = btnLoad.Top;
            userControlRevenue1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }
        private void btnTruck_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnTruck.Height;
            Sidepanel.Top = btnTruck.Top;
            userControlTruck1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnExpense.Height;
            Sidepanel.Top = btnExpense.Top;
            userControlExpense1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnTrip.Height;
            Sidepanel.Top = btnTrip.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmTripPlanner tripplanner = new frmTripPlanner();
            tripplanner.ShowDialog();
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnCatalogs.Height;
            Sidepanel.Top = btnCatalogs.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnProfile.Height;
            Sidepanel.Top = btnProfile.Top;
            userControlUtilities1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }

        private void btnAdministration_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnAdministration.Height;
            Sidepanel.Top = btnAdministration.Top;
            userControlAdministration1.BringToFront();
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Colapsar.Start();
            Sidepanel.Height = 50;
            Sidepanel.Top = pnUsuario.Top;
        }
        public void ColapsaStop()
        {
            btnUsuario.Image = Resources.forward_16px_white;
            pnUsuario.Height -= 10;
            if (pnUsuario.Size == pnUsuario.MinimumSize)
            {
                Colapsar.Stop();
                EsColapsado = true;
            }
        }
        private void Colapsar_Tick_1(object sender, EventArgs e)
        {
            btnUsuario.Image = Resources.back_16px_white;
            if (EsColapsado)
            {
                pnUsuario.Height += 10;
                if (pnUsuario.Size == pnUsuario.MaximumSize)
                {
                    Colapsar.Stop();
                    EsColapsado = false;
                }
            }
            else
            {
                ColapsaStop();
            }
        }

        
    }
}
