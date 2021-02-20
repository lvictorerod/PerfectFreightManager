using iText.Kernel.Geom;
using iText.StyledXmlParser.Css.Resolve.Shorthand.Impl;
using iText.StyledXmlParser.Jsoup.Safety;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Accident;
using Perfect_Freight_Manager.Forms.AlertsIncidences;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Mantenimiento;
using Perfect_Freight_Manager.Models;
using Perfect_Freight_Manager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ListBox = System.Windows.Forms.ListBox;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmPerfectFreightManager : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        frmLogin login = new frmLogin();
        string usuario = "", broker = "", driverid = "";
        private bool EsColapsado;
        private double good, medium, bad;
        int cuantos = 0;
        double indice = 0;
        int sgte = 0;
        List<string> Titulos = new List<string>();
        List<int> Incidencias = new List<int>();
        List<double> profit = new List<double>();
        List<string> mes = new List<string>();
        List<string> Clientes = new List<string>();
        List<int> ctdadClientes = new List<int>();
        List<string> Brokers = new List<string>();
        List<int> ctdadBrokers = new List<int>();
        
        public frmPerfectFreightManager()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblCopy.Text = "\u00A9 Perfect Fright Inc.";
            timer.Start();
            Colapsar.Start();
            Sidepanel.Height = btnDashboard.Height;
            Sidepanel.Top = btnDashboard.Top;
            Estadistica();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PerfectFreightManager_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
            lblUser.Text = " ( " + login.Mensaje + " )";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnLoad.Height;
            Sidepanel.Top = btnLoad.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmRevenue revenue = new frmRevenue();
            revenue.Show();
        }

        private void btnTruck_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnTruck.Height;
            Sidepanel.Top = btnTruck.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmTruckFleet truckfleet = new frmTruckFleet();
            truckfleet.Show();
        }
        private void btnAccident_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnAccident.Height;
            Sidepanel.Top = btnAccident.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            DamageAccident accident = new DamageAccident();
            accident.Show();
        }
        private void btnExpense_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnExpense.Height;
            Sidepanel.Top = btnExpense.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmExpenses expenses = new frmExpenses();
            expenses.Show();
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnTrip.Height;
            Sidepanel.Top = btnTrip.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmTripPlanner tripplanner = new frmTripPlanner();
            tripplanner.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnProfile.Height;
            Sidepanel.Top = btnProfile.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            frmUtilites utilities = new frmUtilites();
            utilities.Show();
        }

        private void btnAdministration_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnAdministration.Height;
            Sidepanel.Top = btnAdministration.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            //if (usuario == "Yassel")
            //{
            frmAdministration administration = new frmAdministration(usuario);
            administration.Show();
            //}
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmPerfectFreightManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            Colapsar.Stop();
            timer1.Stop();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = true;
            panelCatalogs.Visible = false;
            Sidepanel.Height = btnDashboard.Height;
            Sidepanel.Top = btnDashboard.Top;
            EsColapsado = false;
            for (int i = 0; i < 210; i += 10)
            {
                ColapsaStop();
            }
            lstAlerts.Items.Clear();
            lstMissing.Items.Clear();
            lstIncidents.Items.Clear();
            lstPickupDrop.Items.Clear();
            Titulos.Clear();
            Incidencias.Clear();
            mes.Clear();
            profit.Clear();
            Clientes.Clear();
            ctdadClientes.Clear();
            Brokers.Clear();
            ctdadBrokers.Clear();
            
            cuantos = 0;
            indice = 0;
            sgte = 0;
            List<string> LoadId = new List<string>();
            Estadistica();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelpManager helpManager = new frmHelpManager();
            helpManager.Show();
        }
        private void btnBokers_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = false;
            panelCatalogs.Height = btnBokers.Height;
            panelCatalogs.Top = btnBokers.Top;
            panelCatalogs.Visible = true;
            EsColapsado = false;
            frmCatalogClient frmCatalogClient = new frmCatalogClient();
            frmCatalogClient.Show();
        }

        private void btnInsurance_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = false;
            panelCatalogs.Height = btnInsurance.Height;
            panelCatalogs.Top = btnInsurance.Top;
            panelCatalogs.Visible = true;
            EsColapsado = false;
            frmCatalogInsurance insurance = new frmCatalogInsurance();
            insurance.Show();
        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = false;
            panelCatalogs.Height = btnVendors.Height;
            panelCatalogs.Top = btnVendors.Top;
            panelCatalogs.Visible = true;
            EsColapsado = false;
            frmCatalogVendor vendor = new frmCatalogVendor("");
            vendor.Show();
        }

        private void btnPhoneBook_Click(object sender, EventArgs e)
        {
            Sidepanel.Visible = false;
            panelCatalogs.Height = btnPhoneBook.Height;
            panelCatalogs.Top = btnPhoneBook.Top;
            panelCatalogs.Visible = true;
            EsColapsado = false;
            frmCatalogPhoneBook phonebook = new frmCatalogPhoneBook();
            phonebook.Show();
        }

        private void btnCatalogs_Click(object sender, EventArgs e)
        {
            Colapsar.Start();
            panelCatalogs.Visible = false;
            Sidepanel.Visible = true;
            Sidepanel.Height = 50;
            Sidepanel.Top = pnUsuario.Top;
        }
        
        public void ColapsaStop()
        {
            btnCatalogs.Image = Resources.forward_16px_white;
            pnUsuario.Height -= 10;
            if (pnUsuario.Size == pnUsuario.MinimumSize)
            {
                Colapsar.Stop();
                EsColapsado = true;
            }
        }
        private void Colapsar_Tick(object sender, EventArgs e)
        {
            btnCatalogs.Image = Resources.back_16px_white;
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
                btnCatalogs.Image = Resources.forward_16px_white;
                pnUsuario.Height -= 10;
                if (pnUsuario.Size == pnUsuario.MinimumSize)
                {
                    Colapsar.Stop();
                    EsColapsado = true;
                }
                //ColapsaStop();
            }
        }
        private void lstAlerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((string)lstAlerts.Items[lstAlerts.SelectedIndex]);
            string alerta = (string)lstAlerts.Items[lstAlerts.SelectedIndex];
            if(alerta == " " || alerta.Contains("Expire"))
            {
                MessageBox.Show("Esta es una eleccion incorrecta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int largo = alerta.Length;
            int indice = 0;
            string nombre = "";
            bool contieneTruck = alerta.Contains("Truck#");
            if (contieneTruck)
            {
                int indiceTrunck = alerta.LastIndexOf(" ");
                indice = largo - indiceTrunck - 1;
                nombre = alerta.Substring(indiceTrunck + 1, indice);
                AlertsTruck alertsTruck = new AlertsTruck(nombre);
                alertsTruck.Show();
            }
            bool contieneTrailer = alerta.Contains("Trailer#");
            if (contieneTrailer)
            {
                int indiceTrailer = alerta.LastIndexOf(" ");
                indice = largo - indiceTrailer - 1;
                nombre = alerta.Substring(indiceTrailer + 1, indice);
                AlertsTrailer alertsTrailer = new AlertsTrailer(nombre);
                alertsTrailer.Show();
            }
            bool contieneTruckNo = alerta.Contains("TruckNo");
            if (contieneTruckNo)
            {
                MessageBox.Show("You will upgrade the Maintenance of:\n" + (string)lstAlerts.Items[lstAlerts.SelectedIndex], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indiceTruckNo = alerta.LastIndexOf(" ");
                indice = largo - indiceTruckNo - 1;
                nombre = alerta.Substring(indiceTruckNo + 1, indice);
                frmTruckFleet truckfleet = new frmTruckFleet();
                truckfleet.Show();
            }
            bool contieneTrailerNo = alerta.Contains("TrailerNo");
            if (contieneTrailerNo)
            {
                MessageBox.Show("You will upgrade the Maintenance of:\n" + (string)lstAlerts.Items[lstAlerts.SelectedIndex], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indiceTrailerNo = alerta.LastIndexOf(" ");
                indice = largo - indiceTrailerNo - 1;
                nombre = alerta.Substring(indiceTrailerNo + 1, indice);
                frmTruckFleet truckfleet = new frmTruckFleet();
                truckfleet.Show();
            }
            bool contieneApuNo = alerta.Contains("Apu#");
            if (contieneApuNo)
            {
                MessageBox.Show("You will upgrade the Maintenance of:\n" + (string)lstAlerts.Items[lstAlerts.SelectedIndex], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int indiceApuNo = alerta.LastIndexOf(" ");
                indice = largo - indiceApuNo - 1;
                nombre = alerta.Substring(indiceApuNo + 1, indice);
                frmTruckFleet truckfleet = new frmTruckFleet();
                truckfleet.Show();
            }
            //else
            //{
            //    int indicefecha = alerta.IndexOf(" ") + 1;
            //    nombre = alerta.Substring(indicefecha, largo - indicefecha);
            //    indice = nombre.IndexOf(" ");
            //    string first = nombre.Substring(0, indice);
            //    int indice2 = nombre.Length - first.Length - 1;
            //    string last = nombre.Substring(indice + 1, indice2);
            //    Incidencias incidencias = new Incidencias(first, last);
            //    incidencias.Show();
            //}
            
        }

        private void lstIncidents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((string)lstIncidents.Items[lstIncidents.SelectedIndex]);
            string nombre = (string)lstIncidents.Items[lstIncidents.SelectedIndex];
            if (nombre == " " || nombre.Contains("Missing"))
            {
                MessageBox.Show("Esta es una eleccion incorrecta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int largo = nombre.Length;
            int indice = nombre.IndexOf(" ");
            string first = nombre.Substring(0, indice);
            int indice2 = nombre.Length - first.Length - 1;
            string last = nombre.Substring(indice+1, indice2);
            Incidencias incidencias = new Incidencias(first,last);
            incidencias.Show();
        }

        private void lstMissing_SelectedIndexChanged(object sender, EventArgs e)
        {
            string alerta = (string)lstMissing.Items[lstMissing.SelectedIndex];
            if (alerta == " " || alerta.Contains("Documents"))
            {
                MessageBox.Show("Esta es una eleccion incorrecta","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show((string)lstMissing.Items[lstMissing.SelectedIndex] +
                "\nyou should go to the subsystem Load and in Documents to upgrade these");
            
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Appoinment appoinment = new Appoinment();
            appoinment.Show();
        }

        private void lstPickupDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pd = (string)lstPickupDrop.Items[lstPickupDrop.SelectedIndex];
            if (pd == " " || pd.Contains("PICKUP") || pd.Contains("RECEIVER"))
            {
                MessageBox.Show("Esta es una eleccion incorrecta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int largo = pd.Length;
            int indice = 0;
            string idrevenue = "";
            bool contieneShipper = pd.Contains("Shipper:");
            bool contieneReceiver = pd.Contains("Receiver:");
            if (contieneShipper || contieneReceiver)
            {
                int indiceShipper = pd.IndexOf(" ");
                //indice = largo - indiceShipper - 1;
                idrevenue = pd.Substring(0, indiceShipper);
                string cadena5 = "select loadid, client from revenues where loadid = '" + idrevenue + "'";
                conn2.Open();
                NpgsqlCommand comando5 = new NpgsqlCommand(cadena5, conn2);
                NpgsqlDataReader dr5 = comando5.ExecuteReader();

                while (dr5.Read()) //for (int j=0; j <= largo; j++)
                {
                    broker = dr5["client"].ToString();
                }
                conn2.Close();

                PickupDrop pdShipper = new PickupDrop(idrevenue, broker);
                pdShipper.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to exit the application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            Application.Exit();
        }

        
        /// <summary> /////////////////////
        /// Estadisticas
        /// </summary>/////////////////////
        private void Estadistica()
        {
            List<string> LoadId = new List<string>();
            //Estadistica de Brokers
            dataGridView.DataSource = conectandose.ConsultarBrokers("revenues");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            string broker0 = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value);
            Brokers.Add(broker0);
            int numBrokers = 0;
            sgte = 0;
            while (cuantos > 0)
            {
                string broker1 = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value);
                if (broker1 != broker0)
                {
                    broker0 = broker1;
                    ctdadBrokers.Add(numBrokers);
                    Brokers.Add(broker0);
                    numBrokers = 1;
                }
                else numBrokers++;
                cuantos--;
                sgte++;
            }
            if (numBrokers >= 1)
            {
                Brokers.Add(broker0);
                ctdadBrokers.Add(numBrokers);
            }
            ////Estadisticas de Clients
            //dataGridView.DataSource = conectandose.ConsultarClients("rvpickupdrops");
            //cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            //sgte = 0;
            //string cliente0 = Convert.ToString(dataGridView.Rows[sgte].Cells[14].Value);//7
            //Clientes.Add(cliente0);
            //int numClientes = 0;
            //while (cuantos > 0)
            //{  
            //    string cliente1 = Convert.ToString(dataGridView.Rows[sgte].Cells[14].Value);//7
            //    if (cliente1 != cliente0)
            //    {
            //        cliente0 = cliente1;
            //        ctdadClientes.Add(numClientes);
            //        Clientes.Add(cliente0);
            //        numClientes = 1;
            //    }
            //    else numClientes++;
            //    cuantos--;
            //    sgte++;
            //}
            //if (numClientes >= 1)
            //{
            //    Clientes.Add(cliente0);
            //    ctdadClientes.Add(numClientes);
            //}
            //Estadísticas Appoinment
            dataGridView.DataSource = conectandose.Consultar("rvpickupdrops");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            good = 0;medium = 0;bad = 0;
            indice = cuantos;
            sgte = 0;
            while (cuantos > 0)
            {
                string type = Convert.ToString(dataGridView.Rows[sgte].Cells[2].Value);
                string code= Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value);
                if (type == "Pickup" || type == "Hook")
                {
                    string hora3 = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[5].Value).Hour.ToString();
                    int arrivatedate = Convert.ToInt32(hora3);
                    string shipper1 = Convert.ToString(dataGridView.Rows[sgte].Cells[17].Value);
                    int indice1 = shipper1.IndexOf(":");
                    string shipper2 = shipper1.Substring(0, indice1);
                    int pickuptime = Convert.ToInt32(shipper2);
                    int horasPickup = arrivatedate - pickuptime;
                    if (horasPickup <= 1)
                    {
                        good = good + 1;
                    }else if (horasPickup > 1 && horasPickup <= 2)
                    {
                        medium = medium + 1;
                    }
                    else
                    {
                        bad = bad + 1;
                    }
                }
                else
                {
                    string hora2 = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[8].Value).Hour.ToString();
                    int appoinmentdate = Convert.ToInt32(hora2);
                    string receiver1 = Convert.ToString(dataGridView.Rows[sgte].Cells[9].Value);
                    int indice2 = receiver1.IndexOf(":");
                    string receiver2 = receiver1.Substring(0, indice2);
                    int deliverytime = Convert.ToInt32(receiver2);
                    int horasDelivery = appoinmentdate - deliverytime;
                    if (horasDelivery <= 1)
                    {
                        good = good + 1;
                    }
                    else if (horasDelivery > 1 && horasDelivery <= 2)
                    {
                        medium = medium + 1;
                    }
                    else
                    {
                        bad = bad + 1;
                    }
                }
                cuantos--;
                sgte++;
            }
            double total = good + medium + bad;
            good = (good / total);
            medium = medium / total;
            bad = bad / total;
            lbGood.Text = good.ToString("P", CultureInfo.CreateSpecificCulture("en-US"));
            lbMedium.Text = medium.ToString("P", CultureInfo.CreateSpecificCulture("en-US"));
            lbBad.Text = bad.ToString("P", CultureInfo.CreateSpecificCulture("en-US"));

            //Estadisticas Invoice
            dataGridView.DataSource = conectandose.Consultar("revenues");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            indice = cuantos;
            sgte = 0;
            int pay = 0, paydue = 0, payover = 0;
            int Available = 0, InTransit = 0, Delivered = 0, Cancelled = 0;
            double TotalTripPay = 0, TotalPay = 0, TotalPayDue = 0, TotalPayOver = 0;
            while (cuantos > 0)
            {
                DateTime FechaFactoryDate = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[31].Value);
                DateTime FechaFactoryPaid = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[43].Value);
                TimeSpan tspan = FechaFactoryPaid - FechaFactoryDate;
                LoadId.Add(Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value));
                int dias = tspan.Days;
                TotalTripPay = TotalTripPay + Convert.ToDouble(dataGridView.Rows[sgte].Cells[27].Value);
                if (Convert.ToString(dataGridView.Rows[sgte].Cells[37].Value) == "True")
                {
                    TotalPay = TotalPay + Convert.ToDouble(dataGridView.Rows[sgte].Cells[27].Value);
                    pay++;
                }
                if (dias == 0)
                {
                    TotalPayDue = TotalPayDue + Convert.ToDouble(dataGridView.Rows[sgte].Cells[27].Value);
                    paydue++;
                }
                if (dias > 1)
                {
                    TotalPayOver = TotalPayOver + Convert.ToDouble(dataGridView.Rows[sgte].Cells[27].Value);
                    payover++;
                }
                switch (Convert.ToInt32(dataGridView.Rows[sgte].Cells[4].Value)) //Loadstatus
                {
                    case 0:
                        Available++;
                        break;
                    case 1:
                        InTransit++;
                        break;
                    case 2:
                        Delivered++;
                        break;
                    case 3:
                        Cancelled++;
                        break;
                }
                cuantos--;
                sgte++;
            }
            lbInvoicC.Text = indice.ToString();
            txtInv.Text = TotalTripPay.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            lbPaidC.Text = pay.ToString();
            txtPaid.Text = TotalPay.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            lbDueC.Text = paydue.ToString();
            txtDue.Text = TotalPayDue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            lbOverC.Text = payover.ToString();
            txtOver.Text = TotalPayOver.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            lbAvailable.Text = Available.ToString();
            lbInTransit.Text = InTransit.ToString();
            lbDelivered.Text = Delivered.ToString();
            lbCancelled.Text = Cancelled.ToString();
            lbJobs.Text = (Available + InTransit + Delivered + Cancelled).ToString();

            //Compliance Alerts Profiles Drivers
            dataGridView.DataSource = conectandose.Consultar("driverprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            int Active = 0, LicExpire = 0, MCExpire = 0;
            int LicExpireNull = 0, McCdlNull = 0, SsNull = 0, eMailNull = 0;
            sgte = 0;
            List<string> LicExpireData = new List<string>();
            List<string> LicExpireDataNull = new List<string>();
            List<string> McExpireData = new List<string>();
            List<string> McCdlDataNull = new List<string>();
            List<string> ssDataNull = new List<string>();
            List<string> eMailDataNull = new List<string>();
            string nombreLic, nombreMc, nombreLicNull, nombreMcNull, cdlnumber, nombreSsNull, nombreeMailNull;
            while (cuantos > 0)
            {
                DateTime ahora = DateTime.Today;
                DateTime lic = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[36].Value);
                TimeSpan tsLic = lic - ahora;
                int diasLic = tsLic.Days;
                if (Convert.ToInt32(dataGridView.Rows[sgte].Cells[44].Value) == 0)
                    Active++;
                //License Expire
                if (lic != null && diasLic <= 30)
                {
                    nombreLic = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicExpireData.Add(lic.ToShortDateString().ToString() + " " + nombreLic);
                    LicExpire++;

                }
                else if (lic == null)
                {
                    nombreLicNull = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicExpireDataNull.Add(nombreLicNull);
                    LicExpireNull++;
                }

                //MedCard Expire
                DateTime medcard = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[38].Value);
                cdlnumber = Convert.ToString(dataGridView.Rows[sgte].Cells[32].Value);
                TimeSpan tsMc = medcard - ahora;
                int diasmc = tsMc.Days;
                if (medcard != null && diasmc < 30)
                {
                    nombreMc = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    McExpireData.Add(medcard.ToShortDateString().ToString() + " " + nombreMc);
                    MCExpire++;
                }
                if (cdlnumber == null || cdlnumber == "")
                {
                    nombreMcNull = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    McCdlDataNull.Add(nombreMcNull);
                    McCdlNull++;
                }

                //SS Null
                string ss = Convert.ToString(dataGridView.Rows[sgte].Cells[39].Value);
                if (ss == null || ss == "")
                {
                    nombreSsNull = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    ssDataNull.Add(nombreSsNull);
                    SsNull++;
                }
                //eMail Null
                string eMail = Convert.ToString(dataGridView.Rows[sgte].Cells[15].Value);
                if (eMail == null || eMail == "")
                {
                    nombreeMailNull = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value) + " " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    eMailDataNull.Add(nombreeMailNull);
                    eMailNull++;
                }
                cuantos--;
                sgte++;
            }
            lstAlerts.BeginUpdate();
            if (LicExpire != 0)
            {
                lstAlerts.Items.Add("DRIVERS License Expire" + "(" + LicExpire.ToString() + ")");
                Titulos.Add("DRIVERS Lic. Exp.");
                Incidencias.Add(LicExpire);
                for (int i = 0; i < LicExpireData.Count; i++)
                {
                    lstAlerts.Items.Add(LicExpireData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            if (MCExpire != 0)
            {
                lstAlerts.Items.Add("MedCard Expire" + "(" + MCExpire.ToString() + ")");
                Titulos.Add("MedCard Expire");
                Incidencias.Add(MCExpire);
                for (int i = 0; i < McExpireData.Count; i++)
                {
                    lstAlerts.Items.Add(McExpireData[i]);
                }
            }
            lstAlerts.EndUpdate();

            //Data Q Incidense
            lstIncidents.BeginUpdate();
            if (McCdlNull != 0)
            {
                lstIncidents.Items.Add("Missing #CDL MedCard" + "(" + McCdlNull.ToString() + ")");
                Titulos.Add("Missing #CDL");
                Incidencias.Add(McCdlNull);
                for (int i = 0; i < McCdlDataNull.Count; i++)
                {
                    lstIncidents.Items.Add(McCdlDataNull[i]);
                }
                lstIncidents.Items.Add(" ");
            }
            if (SsNull != 0)
            {
                lstIncidents.Items.Add("Missing #SS Security Social" + "(" + SsNull.ToString() + ")");
                Titulos.Add("Missing #SS");
                Incidencias.Add(SsNull);
                for (int i = 0; i < ssDataNull.Count; i++)
                {
                    lstIncidents.Items.Add(ssDataNull[i]);
                }
                lstIncidents.Items.Add(" ");
            }
            if (eMailNull != 0)
            {
                lstIncidents.Items.Add("Missing eMail" + "(" + eMailNull.ToString() + ")");
                Titulos.Add("Missing eMail");
                Incidencias.Add(eMailNull);
                for (int i = 0; i < eMailDataNull.Count; i++)
                {
                    lstIncidents.Items.Add(eMailDataNull[i]);
                }
            }
            lstIncidents.EndUpdate();
            lbDrivers.Text = Active.ToString();

            //Estadistica Profiles Truck & Trailers
            //Compliance Alerts Trucks - License Expire & Inspection
            List<string> LicExpireTruckData = new List<string>();
            List<string> LicExpireTrailerData = new List<string>();
            List<string> LicTruckInspectionData = new List<string>();
            List<string> LicTrailerInspectionData = new List<string>();
            

            string nombreLicTruck, nombreLicTrailer, nombreLicTruckNull, nombreLicTrailerNull;
            int LicExpireTruck = 0, LicExpireTrailer = 0, LicExpireTruckNull = 0, LicExpireTrailerNull = 0, LicTruckInspection = 0, LicTruckInspectionNull = 0, LicTrailerInspection = 0, LicTrailerInspectionNull = 0;
            dataGridView.DataSource = conectandose.Consultar("trucksprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            lbTrucks.Text = cuantos.ToString();
            sgte = 0;
            while (cuantos > 0)
            {
                DateTime ahora = DateTime.Today;
                DateTime lic = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[22].Value);
                DateTime inspection = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[21].Value);
                TimeSpan tsLic = lic - ahora;
                TimeSpan tsInspection = inspection - ahora;
                int diasLic = tsLic.Days;
                int diasInspection = tsInspection.Days;
                //License Expire Truck
                if (lic != null && diasLic <= 30)
                {
                    nombreLicTruck = "Truck# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicExpireTruckData.Add(lic.ToShortDateString().ToString() + " " + nombreLicTruck);
                    LicExpireTruck++;

                }
                else if (lic == null)
                {
                    nombreLicTruckNull = "Truck# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicExpireTruckNull++;
                }
                //License Inspection Truck
                if (inspection != null && diasInspection <= 30)
                {
                    nombreLicTruck = "Truck# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicTruckInspectionData.Add(inspection.ToShortDateString().ToString() + " " + nombreLicTruck);
                    LicTruckInspection++;

                }
                else if (lic == null)
                {
                    nombreLicTruckNull = "Truck# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicTruckInspectionNull++;
                }
                cuantos--;
                sgte++;
            }
            //Compliance Alerts Trailers - License Expire
            dataGridView.DataSource = conectandose.Consultar("trailersprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            lbTrailers.Text = cuantos.ToString();
            sgte = 0;
            while (cuantos > 0)
            {
                DateTime ahora = DateTime.Today;
                DateTime lic = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[15].Value);
                DateTime inspection = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[14].Value);
                TimeSpan tsLic = lic - ahora;
                TimeSpan tsInspection = inspection - ahora;
                int diasLic = tsLic.Days;
                int diasInspection = tsInspection.Days;
                //License Expire Trailer
                if (lic != null && diasLic <= 30)
                {
                    nombreLicTrailer = "Trailer# " + Convert.ToString(dataGridView.Rows[sgte].Cells[2].Value);
                    LicExpireTrailerData.Add(lic.ToShortDateString().ToString() + " " + nombreLicTrailer);
                    LicExpireTrailer++;
                }
                else if (lic == null)
                {
                    nombreLicTrailerNull = "Trailer# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicExpireTrailerNull++;
                }
                //License Inspection Trailer
                if (inspection != null && diasInspection <= 30)
                {
                    nombreLicTrailer = "Trailer# " + Convert.ToString(dataGridView.Rows[sgte].Cells[2].Value);
                    LicTrailerInspectionData.Add(inspection.ToShortDateString().ToString() + " " + nombreLicTrailer);
                    LicTrailerInspection++;

                }
                else if (inspection == null)
                {
                    nombreLicTrailerNull = "Trailer# " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    LicTrailerInspectionNull++;
                }
                cuantos--;
                sgte++;
            }
            //Compliance Alerts Mantenimiento Trucks, Trailers y APU
            List<string> MtoTruckData = new List<string>();
            List<string> MtoTrailerData = new List<string>();
            List<string> MtoApuData = new List<string>();

            //Matenimiento Trucks
            sgte = 0;
            dataGridView.DataSource = conectandose.Consultar("adminmaintenances");
            double trpmini = Convert.ToDouble(dataGridView.Rows[sgte].Cells[1].Value);
            double trpmstop = Convert.ToDouble(dataGridView.Rows[sgte].Cells[2].Value);
            double trt2ini = Convert.ToDouble(dataGridView.Rows[sgte].Cells[3].Value);
            double trt2stop = Convert.ToDouble(dataGridView.Rows[sgte].Cells[4].Value);
            double trt3ini = Convert.ToDouble(dataGridView.Rows[sgte].Cells[5].Value);
            double trt3stop = Convert.ToDouble(dataGridView.Rows[sgte].Cells[6].Value);
            double tlpmini = Convert.ToDouble(dataGridView.Rows[sgte].Cells[7].Value);
            double tlpmstop = Convert.ToDouble(dataGridView.Rows[sgte].Cells[8].Value);
            double apuini = Convert.ToDouble(dataGridView.Rows[sgte].Cells[13].Value);
            double apustop = Convert.ToDouble(dataGridView.Rows[sgte].Cells[14].Value);
            //Esta parte es para el Mantenimiento de Verano e Invierno
            //DateTime summerfrom = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[16].Value);
            //DateTime summerto = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[17].Value);
            //DateTime winterfrom = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[18].Value);
            //DateTime winterto = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[19].Value);

            dataGridView.DataSource = conectandose.Consultar("trucksprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            sgte = 0;
            double totalmiles = 0, totalhours = 0;
            int ctdadTrucksMto = 0, ctdadTrailersMto = 0, ctdadApusMto = 0;
            string nombreTruck, nombreTrailer, nombreApu;
            while (cuantos > 0)
            {
                totalmiles = Convert.ToDouble(dataGridView.Rows[sgte].Cells[23].Value);
                //PM
                if (totalmiles >= trpmini && totalmiles < trt2ini)
                {
                    nombreTruck = totalmiles.ToString() + " miles PM TruckNo " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    MtoTruckData.Add(nombreTruck);
                    ctdadTrucksMto++;
                }
                //T2
                if (totalmiles >= trt2ini && totalmiles < trt3ini)
                {
                    nombreTruck = totalmiles.ToString() + " miles T2 TruckNo " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    MtoTruckData.Add(nombreTruck);
                    ctdadTrucksMto++;
                }
                //T3
                if (totalmiles >= trt3ini)
                {
                    nombreTruck = totalmiles.ToString() + " miles T3 TruckNo " + Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                    MtoTruckData.Add(nombreTruck);
                    ctdadTrucksMto++;
                }
                //Summer

                //Winter
                cuantos--;
                sgte++;
            }
            //Mantenimiento Trailers
            dataGridView.DataSource = conectandose.Consultar("trailersprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            sgte = 0;
            totalmiles = 0;
            while (cuantos > 0)
            {
                totalmiles = Convert.ToDouble(dataGridView.Rows[sgte].Cells[16].Value);
                if (totalmiles >= tlpmini)
                {
                    nombreTrailer = totalmiles.ToString() + " miles TrailerNo " + Convert.ToString(dataGridView.Rows[sgte].Cells[2].Value);
                    MtoTrailerData.Add(nombreTrailer);
                    ctdadTrailersMto++;
                }
                cuantos--;
                sgte++;
            }
            //Mantenimiento APU
            dataGridView.DataSource = conectandose.Consultar("apuprofiles");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            sgte = 0;
            totalhours = 0;
            while (cuantos > 0)
            {
                totalhours = Convert.ToDouble(dataGridView.Rows[sgte].Cells[10].Value);
                //PM
                if (totalhours >= apuini)
                {
                    nombreApu = totalhours.ToString() + " hours APU# " + Convert.ToString(dataGridView.Rows[sgte].Cells[2].Value) + "/TruckNo " + Convert.ToString(dataGridView.Rows[sgte].Cells[13].Value);
                    MtoApuData.Add(nombreApu);
                    ctdadApusMto++;
                }
                cuantos--;
                sgte++;
            }

            //Licenses Expire Trucks & Trailers
            lstAlerts.BeginUpdate();
            if (LicExpireTruck != 0)
            {
                lstAlerts.Items.Add(" ");
                lstAlerts.Items.Add("TRUCKS License Expire" + "(" + LicExpireTruck.ToString() + ")");
                Titulos.Add("TRUCKS Lic. Exp.");
                Incidencias.Add(LicExpireTruck);
                for (int i = 0; i < LicExpireTruckData.Count; i++)
                {
                    lstAlerts.Items.Add(LicExpireTruckData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            if (LicExpireTrailer != 0)
            {
                lstAlerts.Items.Add("TRAILERS License Expire" + "(" + LicExpireTrailer.ToString() + ")");
                Titulos.Add("TRAILERS Lic. Exp.");
                Incidencias.Add(LicExpireTrailer);
                for (int i = 0; i < LicExpireTrailerData.Count; i++)
                {
                    lstAlerts.Items.Add(LicExpireTrailerData[i]);
                }
                //Licenses Inspection Trucks & Trailers
                lstAlerts.Items.Add(" ");
            }
            if (LicTruckInspection != 0)
            {
                lstAlerts.Items.Add("TRUCKS Inspection" + "(" + LicTruckInspection.ToString() + ")");
                Titulos.Add("TRUCKS Inspection");
                Incidencias.Add(LicTruckInspection);
                for (int i = 0; i < LicTruckInspectionData.Count; i++)
                {
                    lstAlerts.Items.Add(LicTruckInspectionData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            if (LicTrailerInspection != 0)
            {
                lstAlerts.Items.Add("TRAILERS Inspection" + "(" + LicTrailerInspection.ToString() + ")");
                Titulos.Add("TRAILERS Inspection");
                Incidencias.Add(LicTrailerInspection);
                for (int i = 0; i < LicTrailerInspectionData.Count; i++)
                {
                    lstAlerts.Items.Add(LicTrailerInspectionData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            //Mantenimiento
            if(ctdadTrucksMto != 0)
            {
                lstAlerts.Items.Add("MAINTENANCE TRUCKS" + "(" + ctdadTrucksMto.ToString() + ")");
                Titulos.Add("MAINTENANCE Trucks");
                Incidencias.Add(ctdadTrucksMto);
                for (int i = 0; i < MtoTruckData.Count; i++)
                {
                    lstAlerts.Items.Add(MtoTruckData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            if (ctdadTrailersMto != 0)
            {
                lstAlerts.Items.Add("MAINTENANCE TRAILERS" + "(" + ctdadTrailersMto.ToString() + ")");
                Titulos.Add("MAINTENANCE Trailers");
                Incidencias.Add(ctdadTrailersMto);
                for (int i = 0; i < MtoTrailerData.Count; i++)
                {
                    lstAlerts.Items.Add(MtoTrailerData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            if (ctdadApusMto != 0)
            {
                lstAlerts.Items.Add("MAINTENANCE APU" + "(" + ctdadApusMto.ToString() + ")");
                Titulos.Add("MAINTENANCE Apus");
                Incidencias.Add(ctdadApusMto);
                for (int i = 0; i < MtoApuData.Count; i++)
                {
                    lstAlerts.Items.Add(MtoApuData[i]);
                }
                lstAlerts.Items.Add(" ");
            }
            lstAlerts.EndUpdate();

            //Missing Data Alerts Documents Missing
            dataGridView.DataSource = conectandose.Consultar("documents");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            string document, nombreDoc, idRevenue;
            List<string> DocDataNull = new List<string>();
            int docNull = 0;
            bool bol = false, rc = false;
            sgte = 0;
            int loadid = 0;
            loadid = LoadId.Count;
            int j = 0;
            while (loadid > 0)
            {
                if (cuantos > 0)
                {
                    document = Convert.ToString(dataGridView.Rows[sgte].Cells[5].Value);
                    idRevenue = Convert.ToString(dataGridView.Rows[sgte].Cells[1].Value);

                    if (idRevenue == LoadId[j])
                    {
                        if (document.Substring(0, 3) != "BOL" || document.Substring(0, 2) != "RC")
                        {
                            if (document.Substring(0, 3) == "BOL")
                                bol = true;
                            else rc = true;
                        }
                        if (!bol)
                        {
                            nombreDoc = LoadId[j] + " missing RC";
                            DocDataNull.Add(nombreDoc);
                            docNull++;
                            bol = false;

                        }
                        else if (!rc && !bol)
                        {
                            nombreDoc = LoadId[j] + " missing BOL";
                            DocDataNull.Add(nombreDoc);
                            docNull++;
                            rc = false;
                        }
                    }
                    else
                    {
                        nombreDoc = LoadId[j] + " missing BOL & RC";
                        DocDataNull.Add(nombreDoc);
                        docNull++;
                    }
                    cuantos--;
                    sgte++;
                }
                else
                {
                    nombreDoc = LoadId[j] + " missing BOL & RC";
                    DocDataNull.Add(nombreDoc);
                    docNull++;
                }
                j++;
                loadid--;
            }
            lstMissing.BeginUpdate();
            if (docNull != 0)
            {
                lstMissing.Items.Add("Missing Documents" + "(" + docNull.ToString() + ")");
                Titulos.Add("Missing Documents");
                Incidencias.Add(docNull);
                for (int i = 0; i < DocDataNull.Count; i++)
                {
                    lstMissing.Items.Add(DocDataNull[i]);
                }
            }
            lstMissing.EndUpdate();

            //Pickup & Drop
            List<string> listaShipper = new List<string>();
            List<string> listaReceiver = new List<string>();
            string idrevenue, pdType, shhiper, receiver ;
            int ctdShipper = 0, ctdReceiver = 0;


            string cadena5 = "select p.idrevenue, p.pickdroptype, p.shipper, p.customerliveload, c.loadid, c.chkfactorydate, c.client from rvpickupdrops as p inner join revenues as c on p.idrevenue = c.loadid and c.chkfactorydate = 'False' order by p.idrevenue";
            conn2.Open();
            NpgsqlCommand comando5 = new NpgsqlCommand(cadena5, conn2);
            NpgsqlDataReader dr5 = comando5.ExecuteReader();

            while (dr5.Read()) //for (int j=0; j <= largo; j++)
            {   
                if (dr5["pickdroptype"].ToString() == "Pickup" || dr5["pickdroptype"].ToString() == "Hook") // || dr5["pickdroptype"] == "Hook"
                {
                    listaShipper.Add(dr5["idrevenue"].ToString() + " Shipper: " + dr5["shipper"].ToString());
                    ctdShipper++;
                }
                else if(dr5["pickdroptype"].ToString() == "Drop")
                {
                    listaReceiver.Add(dr5["idrevenue"] + " Receiver: " + dr5["customerliveload"]);
                    ctdReceiver++;
                }
            }
            conn2.Close();
            lstPickupDrop.BeginUpdate();
            if (ctdShipper != 0)
            {
                lstPickupDrop.Items.Add("SHIPPER PICKUP" + "(" + ctdShipper.ToString() + ")");
                for (int i = 0; i < listaShipper.Count; i++)
                {
                    lstPickupDrop.Items.Add(listaShipper[i]);
                }
                lstPickupDrop.Items.Add(" ");
                lstPickupDrop.Items.Add("RECEIVER DROP" + "(" + ctdReceiver.ToString() + ")");
                for (int i = 0; i < listaReceiver.Count; i++)
                {
                    lstPickupDrop.Items.Add(listaReceiver[i]);
                }
            }
            lstPickupDrop.EndUpdate();

            /////////////////////////////////////
            ///// Graficos Estadisticos
            ////////////////////////////////////

            //Profit & Loss
            dataGridView.DataSource = conectandose.ConsultarFactoryDate("revenues");
            cuantos = dataGridView.Rows.GetRowCount(0) - 1;
            indice = cuantos;
            sgte = 0;
            string IdRevenue;
            int idDriver;
            string chkFactoryDate;
            double deductions = 0;
            double EZPass = 0, Insurance = 0, FactoryFee = 0, PaymentFee = 0, ELD = 0, PrePass = 0, Fuel = 0, totalPay = 0, Profit = 0, ExpenseCompany = 0, FuelCargo = 0, driverPay = 0;
            double b1 = 0, b2 = 0, b3 = 0, b4 = 0;
            int cuentapd = 0;
            double deductionsSum = 0;
            double ProfitSum = 0;
            DateTime factoryDate0 = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[31].Value);
            string mesFactoryDate0 = factoryDate0.Month.ToString();

            while (cuantos > 0)
            {
                b1 = 0; b2 = 0; b3 = 0; b4 = 0; cuentapd = 0;
                EZPass = 0; Insurance = 0; FactoryFee = 0; PaymentFee = 0; ELD = 0; PrePass = 0; Fuel = 0; totalPay = 0; Profit = 0; ExpenseCompany = 0; FuelCargo = 0; driverPay = 0;
                deductions = 0;
                IdRevenue = Convert.ToString(dataGridView.Rows[sgte].Cells[3].Value);
                idDriver = Convert.ToInt32(dataGridView.Rows[sgte].Cells[34].Value);
                totalPay = Convert.ToDouble(dataGridView.Rows[sgte].Cells[27].Value);
                chkFactoryDate = Convert.ToString(dataGridView.Rows[sgte].Cells[36].Value);
                string DeadHeadMiles, LoadMiles, TotalTripBasic, Weight;
                DeadHeadMiles = Convert.ToString(dataGridView.Rows[sgte].Cells[22].Value);
                LoadMiles = Convert.ToString(dataGridView.Rows[sgte].Cells[23].Value);
                TotalTripBasic = Convert.ToString(dataGridView.Rows[sgte].Cells[30].Value);
                Weight = Convert.ToString(dataGridView.Rows[sgte].Cells[10].Value);
                DateTime dtEndDate = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[18].Value);
                DateTime dtLastDate = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[28].Value);
                DateTime factoryDate1 = Convert.ToDateTime(dataGridView.Rows[sgte].Cells[31].Value);
                string mesFactoryDate1 = factoryDate1.Month.ToString();
                //Aqui comienza la Logica del Profit & Loss

                if (chkFactoryDate == "True")
                {
                    //Deduction Fuel del Driver & Driver Pay
                    string cadena = "select idrevenue, cost from rvfuels where idrevenue = '" + IdRevenue + "'";
                    conn2.Open();
                    NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                    NpgsqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        Fuel = Convert.ToDouble(dr["cost"]);
                    }
                    conn2.Close();
                    //Pickup & Drop
                    string cadena4 = "select idrevenue from rvpickupdrops where idrevenue = '" + IdRevenue + "'";
                    conn2.Open();
                    NpgsqlCommand comando4 = new NpgsqlCommand(cadena4, conn2);
                    NpgsqlDataReader dr4 = comando4.ExecuteReader();
                    while (dr4.Read())
                    {
                        cuentapd++;
                    }
                    conn2.Close();
                    //Deducciones del Driver
                    string cadena2 = "select * from driverprofiles where id=" + idDriver;
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();
                    EZPass = 0; Insurance = 0; FactoryFee = 0; PaymentFee = 0; ELD = 0; PrePass = 0; FuelCargo = 0;
                    while (dr2.Read())
                    {
                        int paymethod = Convert.ToInt32(dr2["paymethod"].ToString());
                        switch (paymethod)
                        {
                            case 0: //Flat Rate
                                b1 = Convert.ToDouble(dr2["flatratepay"].ToString());
                                driverPay = b1;
                                break;
                            case 1: //Mileage
                                b1 = Convert.ToDouble(dr2["emptypaypermile"].ToString()) * Convert.ToDouble(DeadHeadMiles);
                                b3 = Convert.ToDouble(dr2["loadedparpermile"].ToString()) * Convert.ToDouble(LoadMiles);
                                driverPay = b1 + b3;
                                break;
                            case 2: //PercentagePay
                                b1 = Convert.ToDouble(dr2["percentagepay"].ToString()) / 100 * Convert.ToDouble(TotalTripBasic);
                                driverPay = b1;
                                break;
                            case 3: //Tonnage
                                b1 = Convert.ToDouble(dr2["tonnagepay"].ToString()) * Convert.ToDouble(Weight) / 1000;
                                driverPay = b1;
                                break;
                            case 4: //Hourly
                                string year1 = dtEndDate.Year.ToString();
                                int intyear1 = Convert.ToInt32(year1);
                                string mes1 = dtEndDate.Month.ToString();
                                int intmes1 = Convert.ToInt32(mes1);
                                string dia1 = dtEndDate.Day.ToString();
                                int intdia1 = Convert.ToInt32(dia1);
                                string hora1 = dtEndDate.Hour.ToString();
                                int inthora1 = Convert.ToInt32(hora1);

                                string year2 = dtLastDate.Year.ToString();
                                int intyear2 = Convert.ToInt32(year2);
                                string mes2 = dtLastDate.Month.ToString();
                                int intmes2 = Convert.ToInt32(mes2);
                                string dia2 = dtLastDate.Day.ToString();
                                int intdia2 = Convert.ToInt32(dia2);
                                string hora2 = dtLastDate.Hour.ToString();
                                int inthora2 = Convert.ToInt32(hora2);

                                int horas = (intyear1 - intyear2) * 8760 + (intmes1 - intmes2) * 720 + (intdia1 - intdia2) * 24 + (inthora1 - inthora2);
                                b1 = Convert.ToDouble(dr2["paybyhours"].ToString()) * horas;
                                driverPay = b1;
                                break;
                        }
                        b4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        driverPay += b4;
                        /////////////////////////////////////////////
                        //Deductions
                        EZPass = Convert.ToDouble(dr2["driverezpass"].ToString());
                        Insurance = Convert.ToDouble(dr2["driverinsurace"].ToString());
                        FactoryFee = Convert.ToDouble(dr2["driverfactoryfee"].ToString());
                        PaymentFee = Convert.ToDouble(dr2["driverpaymentfee"].ToString());
                        if (dr2["statusdriver"].ToString() == "1") //Es Owner property
                        {
                            ELD = Convert.ToDouble(dr2["drivereld"].ToString());
                            PrePass = Convert.ToDouble(dr2["driverprepass"].ToString());
                        }
                        if (dr2["driverfuel"].ToString() == "True")
                            FuelCargo = Convert.ToDouble(Fuel);
                    }
                    conn2.Close();
                    //Expenses Fuel con Cargo COmpany
                    string cadena3 = "select idrevenue, cost, cargostatus from rvexpenses where idrevenue = '" + IdRevenue + "'";
                    conn2.Open();
                    NpgsqlCommand comando3 = new NpgsqlCommand(cadena3, conn2);
                    NpgsqlDataReader dr3 = comando3.ExecuteReader();
                    while (dr3.Read())
                    {
                        if (dr3["cargostatus"].ToString() == "False")
                            ExpenseCompany = Convert.ToDouble(dr3["cost"]);
                    }
                    conn2.Close();
                    deductions = EZPass + Insurance + FactoryFee + PaymentFee + ELD + PrePass;
                    Profit = totalPay - ExpenseCompany + deductions - FuelCargo - driverPay;
                }
                cuantos--;
                sgte++;
                
                if (mesFactoryDate0 != mesFactoryDate1)
                {
                    factoryDate0 = factoryDate1;
                    mesFactoryDate0 = mesFactoryDate1;
                    profit.Add(ProfitSum);
                    ProfitSum = 0;
                }else ProfitSum = ProfitSum + Profit;
            }
            if (Profit != 0)
                profit.Add(Profit);

            //////////////////////////////////
            ///GRAFICOS
            //////////////////////////////////

            //Grafico de Clientes
            //if (chart1.Series.Count > 0)
            //    chart1.Series.Clear();
            //chart1.Series.Add("Clientes");
            //chart1.Series["Clientes"].IsValueShownAsLabel = true;
            //chart1.Series["Clientes"].ShadowOffset = 3;
            //chart1.Series["Clientes"].LabelForeColor = Color.White;
            ////chart1.Legends.Clear();
            //chart1.Series["Clientes"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "Pie");
            //for (int i = 0; i < ctdadClientes.Count; i++)
            //{
            //    chart1.Series["Clientes"].Points.AddXY(Clientes[i], ctdadClientes[i]);
            //}

            //Grafico de Brokers
            if (chart4.Series.Count > 0)
                chart4.Series.Clear();
            chart4.Series.Add("Brokers");
            chart4.Series["Brokers"].IsValueShownAsLabel = true;
            chart4.Series["Brokers"].ShadowOffset = 3;
            chart4.Series["Brokers"].LabelForeColor = Color.White;
            //chart4.Legends.Clear();
            chart4.Series["Brokers"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "Doughnut");
            for (int i = 0; i < ctdadBrokers.Count; i++)
            {
                chart4.Series["Brokers"].Points.AddXY(Brokers[i], ctdadBrokers[i]);
            }
            mes.Add("Ene");
            mes.Add("Feb");
            mes.Add("Mar");
            mes.Add("Apr");
            mes.Add("May");
            mes.Add("Jun");
            mes.Add("Jly");
            mes.Add("Aug");
            mes.Add("Sep");
            mes.Add("Oct");
            mes.Add("Nov");
            mes.Add("Dec");

            //Grafico Profits & Loss
            if (chart2.Series.Count > 0)
                chart2.Series.Clear();
            chart2.Series.Add("Profit");
            chart2.Legends.Clear();
            chart2.Series["Profit"].ShadowOffset = 4;
            chart2.Series["Profit"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "SplineArea");
            for (int i = 0; i < profit.Count; i++)
            {
                chart2.Series["Profit"].Points.AddXY(mes[i], profit[i]);
            }
            //Grafico Incidencias
            if (chart3.Series.Count > 0)
                chart3.Series.Clear();
            chart3.Series.Add("Incidencias");
            chart3.Legends.Clear();
            //chart3.Series["Incidencias"].IsVisibleInLegend = false; //Otra manera de no ver la Leyenda
            //chart3.Palette=ChartColorPalette.SeaGreen; //Poniendo la Paleta desde afuera de la Series
            chart3.Series["Incidencias"].Palette = ChartColorPalette.SeaGreen;
            chart3.Series["Incidencias"].ShadowOffset = 3;
            chart3.Series["Incidencias"].IsValueShownAsLabel = true;
            chart3.Series["Incidencias"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), "Bar");
            for (int i = 0; i < Incidencias.Count; i++)
            {
                chart3.Series["Incidencias"].Points.AddXY(Titulos[i], Incidencias[i]);
            }
            
        }
    }
}
