using Microsoft.Edge.SeleniumTools;
using Npgsql;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Models;
using System;
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmTripPlanner : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string DriverBrowser = "";
        private IWebDriver driver;
        public frmTripPlanner()
        {
            InitializeComponent();

            string cadena2 = "select * from adminsystems";
            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            while (dr2.Read())
            {
                DriverBrowser = dr2["browsepref"].ToString();
            }
            conn2.Close();
            txtLocation1.Text = "";
            txtLocation2.Text = "";
            txtLocation3.Text = "";
            txtLocation4.Text = "";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchLocation1_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtLocation1.Text = search.Nombre; //+ "," + search.Estado ;
        }

        private void btnSearchLocation2_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtLocation2.Text = search.Nombre; //+ "," + search.Estado;
        }

        private void btnSearchLocation3_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtLocation3.Text = search.Nombre; //+ "," + search.Estado;
        }

        private void btnSearchLocation4_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtLocation4.Text = search.Nombre; //+ "," + search.Estado;
        }

        private void btnSearchLocation1_MouseHover(object sender, EventArgs e)
        {
            lblStartCityL1.Visible = true;
        }

        private void btnSearchLocation1_MouseLeave(object sender, EventArgs e)
        {
            lblStartCityL1.Visible = false;
        }

        private void btnSearchLocation2_MouseHover(object sender, EventArgs e)
        {
            lblStartCityL2.Visible = true;
        }

        private void btnSearchLocation2_MouseLeave(object sender, EventArgs e)
        {
            lblStartCityL2.Visible = false;
        }

        private void btnSearchLocation3_MouseHover(object sender, EventArgs e)
        {
            lblStartCityL3.Visible = true;
        }

        private void btnSearchLocation3_MouseLeave(object sender, EventArgs e)
        {
            lblStartCityL3.Visible = false;
        }

        private void btnSearchLocation4_MouseHover(object sender, EventArgs e)
        {
            lblStartCityL4.Visible = true;
        }

        private void btnSearchLocation4_MouseLeave(object sender, EventArgs e)
        {
            lblStartCityL4.Visible = false;
        }

        private void btnRouteTrip_Click(object sender, EventArgs e)
        {
            if (!(txtLocation1.Text == "" || txtLocation2.Text == ""))
            {
                if (DriverBrowser == "FireFox")
                    driver = new FirefoxDriver();
                else if (DriverBrowser == "Chrome")
                    driver = new ChromeDriver();
                else
                    driver = new InternetExplorerDriver();
                string route = txtLocation1.Text + ",EE. UU./" + txtLocation2.Text + ",EE. UU./";
                if (txtLocation3.Text != "")
                    route = route + txtLocation3.Text + ",EE. UU./";
                if(txtLocation4.Text != "")
                 route = route + txtLocation4.Text + ",EE. UU./";
                driver.Navigate().GoToUrl("https://www.google.com/maps/dir/" + route);
                driver.Manage().Window.Maximize();
            }

            //frmWebServicio servicio = new frmWebServicio("https://www.google.com/maps/dir/" + txtLocation1.Text +  txtLocation2.Text);
            //servicio.ShowDialog();
        }

        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            txtLocation1.Text = "";
            txtLocation2.Text = "";
            txtLocation3.Text = "";
            txtLocation4.Text = "";
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpTripPlanner helpTripPlanner = new frmHelpTripPlanner();
            helpTripPlanner.Show();
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
