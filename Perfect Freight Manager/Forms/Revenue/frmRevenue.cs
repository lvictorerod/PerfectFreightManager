using Npgsql;
using Perfect_Freight_Manager.Forms;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Revenue;
using Perfect_Freight_Manager.Forms.Utilities;
using Perfect_Freight_Manager.Models;
using System;
using System.Globalization;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using HorizontalAlignment = System.Windows.Forms.HorizontalAlignment;
using Keys = System.Windows.Forms.Keys;
using Point = System.Drawing.Point;
using TextBox = System.Windows.Forms.TextBox;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

namespace Perfect_Freight_Manager.Forms.Catalogs
{
    public partial class frmRevenue : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string TblName = "revenues";
        private int codigoTrip,codigoPickup, codigoFuel, codigoExpenses, codigoRoute, codigoNotes, codigoDocuments, codigoPay;
        private string LoadStatus = "0";
        private string ruta, correo;
        private int index = -1, zmbtPayPickup = 0;
        private bool initdocument = false, alertaCD = false;
        //private bool initcategory = false;
        private double costototal = 0.0, zExpensesConCargo = 0.0;
        //Variables de Profit & Loss
        private string zmtbExpenses, zTotalTripPay, zmtbFuel, zTotalMiles;

        private int sgte = 0, cuenta = 0;
        private int contador = 1, recordCount = 1;
        private int sgtepd = 0, cuentapd = 0;
        private int sgteFuel = 0, cuentaFuel = 0;
        private int sgteExpense = 0, cuentaExpense = 0;
        private int sgteRoute = 0, cuentaRoute = 0;
        private int sgteNotes = 0, cuentaNotes = 0;

        private int y = 37, yCount = 37;
        private string[] positionPC = new string[8];
        private string[] valorPC = new string[8];
        private int idDriver = 0;
        private string nameBroker = "";
        private string pdfdoc;
        

        string flatrate = "", emptypaypermiles = "", loadpaypermiles = "", tonnagepay = "", paybyhours = "", pickupdroppay = "", percentagepay = "";
        string DriverEZPassPay = "", DriverInsurancePay = "", DriverVacationPay = "", DriverELDPay = "", DriverPrePassPay = "", DriverFuel = "", DriverExpense = "";

        Button[] boton = new Button[8];
        ComboBox[] combo = new ComboBox[8];
        TextBox[] texto = new TextBox[8];
        DateTimePicker[] fecha = new DateTimePicker[6];
        ComboBox[] combo2 = new ComboBox[6];
        TextBox[] texto2 = new TextBox[6];
        Button[] boton2 = new Button[6];
        private string route = "", raiz="";
        public frmRevenue()
        {
            InitializeComponent();
            string cadena2 = "select * from adminsystems";

            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            while (dr2.Read())
            {
                raiz = dr2["rphotodoc"].ToString();
                route = dr2["rprogram"].ToString();
            }
            conn2.Close();
            btnTripAdd.Enabled = true;
            btnTripUpd.Enabled = false;
            btnTripUpd.FlatStyle = FlatStyle.Standard;
            btnTripDel.Enabled = false;
            btnTripDel.FlatStyle = FlatStyle.Standard;

            btnPckupAdd.Enabled = false;
            btnPckupUpd.Enabled = false;
            btnPckupDel.Enabled = false;
            btnPckupAdd.FlatStyle = FlatStyle.Standard;
            btnPckupUpd.FlatStyle = FlatStyle.Standard;
            btnPckupDel.FlatStyle = FlatStyle.Standard;

            btnFuelAdd.Enabled = false;
            btnFuelUpd.Enabled = false;
            btnFuelDel.Enabled = false;
            btnFuelAdd.FlatStyle = FlatStyle.Standard;
            btnFuelUpd.FlatStyle = FlatStyle.Standard;
            btnFuelDel.FlatStyle = FlatStyle.Standard;

            btnExpensesAdd.Enabled = false;
            btnExpensesUpd.Enabled = false;
            btnExpensesDel.Enabled = false;
            btnExpensesAdd.FlatStyle = FlatStyle.Standard;
            btnExpensesUpd.FlatStyle = FlatStyle.Standard;
            btnExpensesDel.FlatStyle = FlatStyle.Standard;

            btnRouteAdd.Enabled = false;
            btnRouteUpd.Enabled = false;
            btnRouteDel.Enabled = false;
            btnRouteAdd.FlatStyle = FlatStyle.Standard;
            btnRouteUpd.FlatStyle = FlatStyle.Standard;
            btnRouteDel.FlatStyle = FlatStyle.Standard;

            btnNotesAdd.Enabled = false;
            btnNotesUpd.Enabled = false;
            btnNotesDel.Enabled = false;
            btnNotesAdd.FlatStyle = FlatStyle.Standard;
            btnNotesUpd.FlatStyle = FlatStyle.Standard;
            btnNotesDel.FlatStyle = FlatStyle.Standard;


            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = false;
            btnDelAttacment.Enabled = false;
            btnOpen.Enabled = true;
            FillCombo();
            
            dgvTripInfo.DataSource = conectandose.Consultar(TblName);
            cbLoadType.Items.Clear();
            string cadena = "select type from loadtypes order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbLoadType.Items.Add(dr["type"].ToString());
            }
            conn.Close();
            dgvPayCategories.DataSource = conectandose.ConsultarRevenue("paycategories", txtLoadId.Text);
            dgvSearch.DataSource = conectandose.Consultar("brokers");
            cuenta = dgvTripInfo.Rows.GetRowCount(0);
            lbRecord.Text = "Record " + sgte + " of " + cuenta;
        }
        private void FillCombo()
        {
            string cadena = "select category from categories order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbTripPayCategory.Items.Add(dr["category"].ToString());
            }
            conn.Close();
            //Brockers
            string brokers = "select name from brokers order by id";
            conn.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(brokers, conn);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();

            while (dr2.Read())
            {
                cbBrockers.Items.Add(dr2["name"].ToString());
            }
            conn.Close();
        }
        private void tabTrip_Click(object sender, EventArgs e)
        {
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabTrip")
            {
                TblName = "revenues";
                cuenta = dgvTripInfo.Rows.GetLastRow(0);
            }
            if (tabControl1.SelectedTab.Name == "tabPickup")
            {
                cbPDType.Items.Clear();
                string cadena = "select type from pickupdroptypes order by id";
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    cbPDType.Items.Add(dr["type"].ToString());
                }
                conn.Close();
                lbLoadIdPickup.Text = txtLoadId.Text;
                lbSRPickup.Text = cbBrockers.Text;
                dtPDReceiverAppoinment.Value = dtEndDate.Value;
                TblName = "rvpickupdrops";
                if (!(txtLoadId.Text == ""))
                    dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                cuentapd = dgvPickup.Rows.GetRowCount(0);
                if(txtPDDriver.Text=="")
                    txtPDDriver.Text = txtDriver.Text;
                lbRecordPD.Text = "Record " + (sgtepd + 1) + " of  " + cuentapd;
            }
            if (tabControl1.SelectedTab.Name == "tabFuel")
            {
                lbLoadIdFuel.Text = txtLoadId.Text;
                lbSRFuel.Text = cbBrockers.Text;
                TblName = "rvfuels";
                if (!(txtLoadId.Text == ""))
                    dgvFuel.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                cuentaFuel = dgvFuel.Rows.GetRowCount(0);
                lbRecordFuel.Text = "Record " + (sgteFuel + 1) + " of  " + cuentaFuel;
                zmtbFuel = "0";
            }
            if (tabControl1.SelectedTab.Name == "tabExpenses")
            {
                lbLoadIdExpenses.Text = txtLoadId.Text;
                lbSRExpenses.Text = cbBrockers.Text;
                TblName = "rvexpenses";
                if (!(txtLoadId.Text == ""))
                    dgvExpenses.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                cuentaExpense = dgvExpenses.Rows.GetRowCount(0);
                lbRecordExpense.Text = "Record " + sgteExpense + " of  " + cuentaExpense;
                zmtbExpenses = "0";
                zExpensesConCargo = 0;
            }
            if (tabControl1.SelectedTab.Name == "tabRoute")
            {
                lbLoadIdRoute.Text = txtLoadId.Text;
                lbSRRorute.Text = cbBrockers.Text;
                TblName = "rvroutes";
                if (!(txtLoadId.Text == ""))
                    dgvRoute.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                cuentaRoute = dgvRoute.Rows.GetRowCount(0);
                lbRecordRoute.Text = "Record " + (sgteRoute + 1) + " of  " + cuentaRoute;
            }
            if (tabControl1.SelectedTab.Name == "tabNotes")
            {
                lbLoadIdNotes.Text = txtLoadId.Text;
                lbSRNotes.Text = cbBrockers.Text;
                TblName = "rvnotes";
                if (!(txtLoadId.Text == ""))
                    dgvNotes.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                cuentaNotes = dgvNotes.Rows.GetRowCount(0);
                lbRecordNotes.Text = "Record " + (sgteNotes + 1) + " of  " + cuentaNotes;
            }
            if (tabControl1.SelectedTab.Name == "tabProfit")
            {
                if (!rbLSAvailable.Checked)
                {
                    if (txtLoadId.Text != "")
                    {
                        double a1, a4, a6;
                        double r1=0, rtotal=0, rdeductions=0;
                        double b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0;
                        double d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0, d7 = 0;

                        string cadena2 = "select * from driverprofiles where id=" + idDriver;

                        conn2.Open();
                        NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                        NpgsqlDataReader dr2 = comando2.ExecuteReader();
                        while (dr2.Read())
                        {
                            idDriver = Convert.ToInt32(dr2["id"].ToString());
                            int paymethod = Convert.ToInt32(dr2["paymethod"].ToString());
                            switch (paymethod)
                            {
                                case 0: //Flat Rate
                                    b1 = Convert.ToDouble(dr2["flatratepay"].ToString());
                                    b2 = Convert.ToDouble(dr2["vacation"].ToString()) * Convert.ToDouble(dr2["flatratepay"].ToString());
                                    mtbDriverPay.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 1: //Mileage
                                    b1 = Convert.ToDouble(dr2["emptypaypermile"].ToString()) * Convert.ToDouble(txtDeadHeadMiles.Text);
                                    mtbPayPerEmptyMiles.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Pay per Empty Miles
                                    b3 = Convert.ToDouble(dr2["loadedparpermile"].ToString()) * Convert.ToDouble(txtLoadMiles.Text);
                                    mtbPayPerLoadMiles.Text = (b3.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Pay per Loaded Miles
                                    b2 = Convert.ToDouble(dr2["vacation"].ToString()) * (b1 + b3);
                                    mtbDriverPay.Text = (b1 + b3).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                                    break;
                                case 2: //PercentagePay
                                    b1 = Convert.ToDouble(dr2["percentagepay"].ToString())/100 * Convert.ToDouble(txtTotalTripBasic.Text);
                                    mtbPayPerPercentage.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                    b2 = Convert.ToDouble(dr2["vacation"].ToString()) * b1;
                                    mtbDriverPay.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 3: //Tonnage
                                    b1 = Convert.ToDouble(dr2["tonnagepay"].ToString()) * Convert.ToDouble(txtWeight.Text)/ 907.18474;
                                    mtbPayPerTonnage.Text = b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                                    b2 = Convert.ToDouble(dr2["vacation"].ToString()) * b1;
                                    mtbDriverPay.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                                case 4: //Hourly
                                    string year1 = Convert.ToDateTime(dtEndDate.Value).Year.ToString();
                                    int intyear1 = Convert.ToInt32(year1);
                                    string mes1 = Convert.ToDateTime(dtEndDate.Value).Month.ToString();
                                    int intmes1= Convert.ToInt32(mes1);
                                    string dia1 = Convert.ToDateTime(dtEndDate.Value).Day.ToString();
                                    int intdia1= Convert.ToInt32(dia1);
                                    string hora1 = Convert.ToDateTime(dtEndDate.Value).Hour.ToString();
                                    int inthora1= Convert.ToInt32(hora1);

                                    string year2 = Convert.ToDateTime(dtLastDate.Value).Year.ToString();
                                    int intyear2 = Convert.ToInt32(year2);
                                    string mes2 = Convert.ToDateTime(dtLastDate.Value).Month.ToString();
                                    int intmes2 = Convert.ToInt32(mes2);
                                    string dia2 = Convert.ToDateTime(dtLastDate.Value).Day.ToString();
                                    int intdia2 = Convert.ToInt32(dia2);
                                    string hora2 = Convert.ToDateTime(dtLastDate.Value).Hour.ToString();
                                    int inthora2 = Convert.ToInt32(hora2);

                                    int horas = (intyear1 - intyear2) * 8760 + (intmes1 - intmes2) * 720 + (intdia1 - intdia2) * 24 + (inthora1 - inthora2);
                                    

                                    b1 = Convert.ToDouble(dr2["paybyhours"].ToString()) * horas;
                                    mtbPayPerHours.Text = b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                                    b2 = Convert.ToDouble(dr2["vacation"].ToString()) * b1;
                                    mtbDriverPay.Text = (b1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                    break;
                            }
                            b4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                            mbtPayPickup.Text = (b4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Pickup and Drop
                            //Deductions
                            d1 = Convert.ToDouble(dr2["driverezpass"].ToString());
                            mtbEZPass.Text = (d1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            d2 = Convert.ToDouble(dr2["driverinsurace"].ToString());
                            mtbInsurance.Text = (d2.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            d3 = Convert.ToDouble(dr2["driverfactoryfee"].ToString());
                            mtbFactoryFee.Text = (d3.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            d4 = Convert.ToDouble(dr2["driverpaymentfee"].ToString());
                            mtbPaymentFee.Text = (d4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            if (dr2["statusdriver"].ToString() == "1") //Es Owner property
                            {
                                d5 = Convert.ToDouble(dr2["drivereld"].ToString());
                                mtbELD.Text = (d5.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                                d6 = Convert.ToDouble(dr2["driverprepass"].ToString());
                                mtbPrePass.Text = (d6.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            }
                            if(dr2["driverfuel"].ToString() == "True") 
                                d7 = Convert.ToDouble(zmtbFuel);
                            mtbFuel.Text = (d7.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            rdeductions = d1 + d2 + d3 + d4 + d5 + d6 + d7;
                            mtbTotalDeductions.Text = (rdeductions.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                            //Gastos Fuel y Expenses (zmtbFuel y zmtbExpenses)
                            b5 = Convert.ToDouble(zmtbExpenses);
                            //DriverExpense = (b5 - zExpensesConCargo).ToString();
                        }
                        conn2.Close();
                        lbLoadIdProfit.Text = txtLoadId.Text;
                        lbSRProfit.Text = cbBrockers.Text;
                        lblDriverName.Text = txtDriver.Text;
                        if (LoadStatus == "0") lblLoadStatus.Text = "Available";
                        else if (LoadStatus == "1") lblLoadStatus.Text = "In Transit";
                        else if (LoadStatus == "2") lblLoadStatus.Text = "Delivered";
                        else lblLoadStatus.Text = "";
                        a1 = Convert.ToDouble(zmtbExpenses);
                        mtbExpenses.Text = (a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Expense
                        mtbExpensesCompany.Text = ((a1 - zExpensesConCargo).ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        r1 = a1 + d7;
                        mtbTExpenses.Text = (r1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Total Expense
                        a4 = Convert.ToDouble(txtTotalMiles.Text);

                        mtbTotalToPay.Text = (b1 + b3 + b4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));  //to Pay Total
                        mbtDeductions.Text = "( " + (rdeductions+zExpensesConCargo).ToString("C", CultureInfo.CreateSpecificCulture("en-US")) + " )";
                        mtbTotalPay.Text = (b1 + b3 + b4 - zExpensesConCargo-rdeductions).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        mtbVacations.Text = (b2.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        a6 = Convert.ToDouble(txtTotalTrip.Text);
                        rtotal = a6 - (b1 + b2 + b3 + b4 + (a1 - zExpensesConCargo-rdeductions));
                        mtbTotalProfit.Text = (rtotal.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); //Profit
                        mtbCostPerMiles.Text = (r1 / a4).ToString(); //Costo por Miles
                        mtbProfPerMiles.Text = ((rtotal + (a1 - zExpensesConCargo)) / a4).ToString(); //Profit por Miles
                        string driverPay = (b1 + b2 + b3 + b4).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Trip Available have not Data yet\n" + "You should change to In-Transit and enter Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (tabControl1.SelectedTab.Name == "tabDocuments")
            {
                lbLoadIdDocuments.Text = txtLoadId.Text;
                lbDocuments.Text = cbBrockers.Text;
                TblName = "documents";
                if (!(txtLoadId.Text == ""))
                    dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                if (!initdocument)
                {
                    string pdfDoc = raiz + @"Documents\Contact_us.pdf";
                    if (pdfDoc == raiz + @"Documents\Contact_us.pdf")
                    {
                        axAcroPDF1.src = pdfDoc;
                    }
                    initdocument = true;
                }
            }
            if (tabControl1.SelectedTab.Name == "tabInvoice")
            {

            }

        }

        /// <summary> ////////////////////////////////////////////////////
        /// TRIP INFORMATION
        /// </summary> ///////////////////////////////////////////////////
        /// 
        private void gbLoadStatus_Enter(object sender, EventArgs e)
        {
            if (rbAvailable.Checked == true)
            {
                LoadStatus = "0";
                dgvTripInfo.DataSource = conectandose.ConsultarStatus(TblName, LoadStatus);
                dgvPayCategories.DataSource = conectandose.ConsultarStatus("paycategories", LoadStatus);
                btnClearTrip_Click(sender, e);
            }
            else if (rbInTransit.Checked == true)
            { 
                LoadStatus = "1";
                dgvTripInfo.DataSource = conectandose.ConsultarStatus(TblName, LoadStatus);
                dgvPayCategories.DataSource = conectandose.ConsultarStatus("paycategories", LoadStatus);
                btnClearTrip_Click(sender, e);
            }
            else if (rbDelivered.Checked == true)
            { 
                LoadStatus = "2";
                dgvTripInfo.DataSource = conectandose.ConsultarStatus(TblName, LoadStatus);
                dgvPayCategories.DataSource = conectandose.ConsultarStatus("paycategories", LoadStatus);
                btnClearTrip_Click(sender, e);
            }
            else if (rbCancelled.Checked == true)
            {  
                LoadStatus = "3";
                dgvTripInfo.DataSource = conectandose.ConsultarStatus(TblName, LoadStatus);
                dgvPayCategories.DataSource = conectandose.ConsultarStatus("paycategories", LoadStatus);
                btnClearTrip_Click(sender, e);
            }
            else
            {
                dgvTripInfo.DataSource = conectandose.Consultar(TblName);
                dgvPayCategories.DataSource = conectandose.Consultar("paycategories");
                btnClearTrip_Click(sender, e);
            }
            LimpiaCategory();
            if (alertaCD)
            {
                int valor = contador - 1;
                for (int i = 0; i < valor; i++)
                {
                    boton_Click(sender, e);
                }
                alertaCD = false;
            }
        }
        private void btnTripFirst_Click(object sender, EventArgs e)
        {
            cuenta = dgvTripInfo.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvTripInfo.Rows.GetFirstRow(0);
                //sgte += 1;
                LimpiaCategory();
                dgvTripInfo_RowEnter(sender, e);
                rellena();
                if (alertaCD)
                {
                    int valor = contador - 1;
                    for (int i = 0; i < valor; i++)
                    {
                        boton_Click(sender, e);
                    }
                    alertaCD = false;
                }
            }
        }

        private void btnTripPrevios_Click(object sender, EventArgs e)
        {
            cuenta = dgvTripInfo.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvTripInfo.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    LimpiaCategory();
                    dgvTripInfo_RowEnter(sender, e);
                    rellena();
                }
                if (alertaCD)
                {
                    int valor = contador - 1;
                    for (int i = 0; i < valor; i++)
                    {
                        boton_Click(sender, e);
                    }
                    alertaCD = false;
                }
            }
        }

        private void btnTripNext_Click(object sender, EventArgs e)
        {
            cuenta = dgvTripInfo.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvTripInfo.Rows.GetNextRow(sgte, 0);
                if (sgte == -1) sgte = 0;
                if (sgte <= cuenta && sgte >= 0)
                {
                    LimpiaCategory();
                    dgvTripInfo_RowEnter(sender, e);
                    rellena();
                }
                if (alertaCD)
                {
                    int valor = contador - 1;
                    for (int i = 0; i < valor; i++)
                    {
                        boton_Click(sender, e);
                    }
                    alertaCD = false;
                }
            }
        }
        
        private void btnTripEnd_Click(object sender, EventArgs e)
        {
            cuenta = dgvTripInfo.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvTripInfo.Rows.GetLastRow(0);
                LimpiaCategory();
                dgvTripInfo_RowEnter(sender, e);
                rellena();
                if (alertaCD)
                {
                    int valor = contador - 1;
                    for (int i = 0; i < valor; i++)
                    {
                        boton_Click(sender, e);
                    }
                    alertaCD = false;
                }
            }
        }

        private void dgvTripInfo_RowEnter(object sender, EventArgs e)
        {
            dgvTripInfo.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvTripInfo.Rows[sgte].Selected = true;
            dgvTripInfo.FirstDisplayedScrollingRowIndex = dgvTripInfo.Rows.GetNextRow(sgte - 1, 0);
        }

        private void LimpiaCategory()
        {
            if (recordCount > 1)
            {
                int j = 0;
                for (int i = 1; i < recordCount; i++)
                {
                    yCount -= 27;
                    y -= 27;
                    groupBox8.Controls.Remove(boton2[i - 1]);
                    groupBox8.Controls.Remove(combo2[i - 1]);
                    groupBox8.Controls.Remove(texto2[i - 1]);
                    j++;
                }
                recordCount = recordCount - j;
            }
        }
        private void rellena()
        {
            btnTripAdd.Enabled = false;
            btnTripAdd.FlatStyle = FlatStyle.Standard;
            btnTripUpd.Enabled = true;
            btnTripUpd.FlatStyle = FlatStyle.Flat;
            btnTripDel.Enabled = true;
            btnTripDel.FlatStyle = FlatStyle.Flat;

            codigoTrip = Convert.ToInt32(dgvTripInfo.Rows[sgte].Cells[0].Value);

            cbBrockers.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[1].Value);
            cbContactName.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[2].Value);
            txtLoadId.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[3].Value);
            switch (Convert.ToInt32(dgvTripInfo.Rows[sgte].Cells[4].Value)) //Loadstatus
            {
                case 0:
                    rbLSAvailable.Checked = true;
                    LoadStatus = "0";
                    break;
                case 1:
                    rbLSInTransit.Checked = true;
                    LoadStatus = "1";
                    break;
                case 2:
                    rbLSDelivered.Checked = true;
                    LoadStatus = "2";
                    break;
                case 3:
                    rbLSCancelled.Checked = true;
                    LoadStatus = "3";
                    break;
            }

            txtDriver.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[5].Value);
            txtTruck.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[6].Value);
            txtTrailer.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[7].Value);
            txtChassis.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[8].Value);
            txtWeight.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[10].Value);
            txtPiece.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[11].Value);
            txtLoadTemp.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[12].Value);
            cbLoadType.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[13].Value);
            dtLastDate.Value = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[28].Value);
            txtDeadHead.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[14].Value);
            txtLastEmptyOdom.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[29].Value);
            dtLoadDate.Value = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[15].Value);
            txtStartCS.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[16].Value);
            txtLoadOdom.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[17].Value);

            dtEndDate.Value = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[18].Value);
            txtEndCS.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[19].Value);
            txtEndOdom.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[20].Value);

            txtPersonalMiles.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[21].Value);
            txtDeadHeadMiles.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[22].Value);
            txtLoadMiles.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[23].Value);
            txtTotalMiles.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[24].Value);
            txtFlatRate.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[25].Value);
            txtTotalOther.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[26].Value);
            txtTripPayAmmount.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[27].Value);
            txtTotalTrip.Text = txtTripPayAmmount.Text;
            txtTotalTripBasic.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[30].Value);
            dtFactoryDate.Value = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[31].Value);
            txtTripPayAmmount.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[32].Value);
            cbTripPayCategory.Text = Convert.ToString(dgvTripInfo.Rows[sgte].Cells[33].Value);
            idDriver = Convert.ToInt32(dgvTripInfo.Rows[sgte].Cells[34].Value);
            dtFactoryPaid.Value = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[43].Value);
            if (Convert.ToString(dgvTripInfo.Rows[sgte].Cells[36].Value) == "True")
                dtFactoryDate.Checked = true;
            else dtFactoryDate.Checked = false;
            if (Convert.ToString(dgvTripInfo.Rows[sgte].Cells[37].Value) == "True")
                dtFactoryPaid.Checked = true;
            else dtFactoryPaid.Checked = false;

            dgvPayCategories.DataSource = conectandose.ConsultarRevenue("paycategories", txtLoadId.Text);

            if (dgvPayCategories.Rows.GetRowCount(0) - 1 > 0)
                ControlesDinamicos();

            lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;

            if (rbLSDelivered.Checked == true)
                if (dtFactoryDate.Value >= dtEndDate.Value && dtFactoryDate.Checked == true)
                {
                    dtFactoryDate.Checked = true;
                    dtFactoryDate.Enabled = false;
                }
                else
                {
                    dtFactoryDate.Checked = false;
                    dtFactoryDate.Enabled = true;
                    //MessageBox.Show("Please checking your Factory Date and/or End Date");
                }
            zTotalTripPay = txtTotalTripBasic.Text;
            initdocument = false;

            
            btnPckupAdd.Enabled = true;
            btnFuelAdd.Enabled = true;
            btnExpensesAdd.Enabled = true;
            btnRouteAdd.Enabled = true;
            btnNotesAdd.Enabled = true;
            btnPckupAdd.FlatStyle = FlatStyle.Flat;
            btnFuelAdd.FlatStyle = FlatStyle.Flat;
            btnExpensesAdd.FlatStyle = FlatStyle.Flat;
            btnRouteAdd.FlatStyle = FlatStyle.Flat;
            btnNotesAdd.FlatStyle = FlatStyle.Flat;


            btnPckupUpd.Enabled = false;
            btnPckupDel.Enabled = false;
            btnPckupUpd.FlatStyle = FlatStyle.Standard;
            btnPckupDel.FlatStyle = FlatStyle.Standard;


            btnFuelUpd.Enabled = false;
            btnFuelDel.Enabled = false;
            btnFuelUpd.FlatStyle = FlatStyle.Standard;
            btnFuelDel.FlatStyle = FlatStyle.Standard;


            btnExpensesUpd.Enabled = false;
            btnExpensesDel.Enabled = false;
            btnExpensesUpd.FlatStyle = FlatStyle.Standard;
            btnExpensesDel.FlatStyle = FlatStyle.Standard;


            btnRouteUpd.Enabled = false;
            btnRouteDel.Enabled = false;
            btnRouteUpd.FlatStyle = FlatStyle.Standard;
            btnRouteDel.FlatStyle = FlatStyle.Standard;


            btnNotesUpd.Enabled = false;
            btnNotesDel.Enabled = false;
            btnNotesUpd.FlatStyle = FlatStyle.Standard;
            btnNotesDel.FlatStyle = FlatStyle.Standard;

            btnUpdAttachment.Enabled = false;
            btnDelAttacment.Enabled = false;
           
            //Limpiando Pickup&Drop
            dtArrivaDate.Text = "";
            txtPDTotalTime.Text = "0";
            txtNotes.Text = "";
            dtStartDate.Text = "";
            txtPDStarCS.Text = "";
            txtPDEndCS.Text = "";
            txtPDDriver.Text = "";
            txtPDSealReceiver.Text = "";
            txtPDSealShipper.Text = "";
            txtPDShipper.Text = "";
            txtPDPickupTime.Text = "";
            txtPDPickupNumber.Text = "";
            dtPDPickupAppoinment.Text = "";
            txtPDTotalTime.Text = "";
            txtPDDeliveryNumber.Text = "";

            //Limpiando Fuel
            dtFuelDate.Text = "";
            txtStation.Text = "0";
            txtMileage.Text = "0";
            txtTruckStop.Text = "0";
            txtFuelCS.Text = "";
            cbPayment.Text = "";
            txtQuantity.Text = "0";
            txtCost.Text = "0";
            txtTotal.Text = "0";
            txtAdvance.Text = "0";
            txtInvoiveNumber.Text = "0";

            //Limpiando Expenses
            dtExpensesDate.Text = "";
            txtDescription2.Text = "";
            txtExpensesCost.Text = "0";
            lbTotalExpenss.Text = "";

            //Limpiando Route
            txtState2.Text = "";
            txtStartOdom.Text = "0";
            txtEnOdom2.Text = "0";
            txtMiles.Text = "0";
            txtTollMiles.Text = "0";
            txtGallons.Text = "0";
            txtHighways.Text = "0";
            lbTotalMiles.Text = "";
            lbTollMiiles.Text = "";
            lbTotalGallons2.Text = "";

            //Limpiando Notes
            txtNotes2.Text = "";
            txtCRequi.Text = "";

            //Limpiando Documents
            txtName.Text = "";
            dtAnnotation.Text = "";
            txtDescription.Text = "";
            //groupBox1.Visible = true;
            string pdfDoc = raiz + @"Documents\Contact_us.pdf";
            if (pdfDoc == raiz + @"Documents\Contact_us.pdf")
            {
                axAcroPDF1.src = pdfDoc;
            }

            //Limpiando Profit
            mtbExpenses.Text = "0";
            mtbExpensesCompany.Text = "0";
            mtbDriverPay.Text = "0";
            mtbTExpenses.Text = "0";
            mtbCostPerMiles.Text = "0";
            mtbProfPerMiles.Text = "0";
            mtbPayPerLoadMiles.Text = "0";
            mtbPayPerEmptyMiles.Text = "0";
            mtbPayPerTonnage.Text = "0";
            mtbPayPerHours.Text = "0";
            mbtPayPickup.Text = "0";
            mtbTotalToPay.Text = "0";
            mbtDeductions.Text = "0";
            mtbPayPerPercentage.Text = "0";
            mtbPayPerHours.Text = "0";
            mtbTotalPay.Text = "0";
            mtbVacations.Text = "0";
            mtbTotalProfit.Text = "0";
            mtbELD.Text = "0";
            mtbPrePass.Text = "0";
            mtbEZPass.Text = "0";
            mtbInsurance.Text = "0";
            mtbFactoryFee.Text = "0";
            mtbPaymentFee.Text = "0";
            mtbFuel.Text = "0";
            mtbTotalDeductions.Text = "0";
        }


        private void btnClearTrip_Click(object sender, EventArgs e)
        {
            cbBrockers.Text = "";
            cbContactName.Text = "";
            txtLoadId.Text = "";
            rbLSAvailable.Checked = true;
            txtDriver.Text = "";
            txtTruck.Text = "";
            txtTrailer.Text = "";
            txtChassis.Text = "";
            txtWeight.Text = "";
            txtPiece.Text = "";
            txtLoadTemp.Text = "";
            cbLoadType.Text = "";
            dtLastDate.Text = DateTime.Now.ToString();
            dtLastDate.Text = DateTime.Now.ToString();
            txtDeadHead.Text = "";
            txtLastEmptyOdom.Text = "0";
            dtLoadDate.Text = DateTime.Now.ToString();
            txtStartCS.Text = "";
            txtLoadOdom.Text = "0";
            dtEndDate.Text = DateTime.Now.ToString();
            txtEndCS.Text = "";
            txtEndOdom.Text = "0";
            txtDeadHeadMiles.Text = "0";
            txtLoadMiles.Text = "0";
            txtPersonalMiles.Text = "0";
            txtTotalMiles.Text = "0";
            txtFlatRate.Text = "0";
            txtTotalOther.Text = "0";
            txtTotalTrip.Text = "0";
            txtTotalTripBasic.Text = "0";
            dtFactoryDate.Text = DateTime.Now.ToString();
            dtFactoryPaid.Text = DateTime.Now.ToString();
            txtTripPayAmmount.Text = "0";
            cbTripPayCategory.Text = "";
            
            dtFactoryDate.Checked = false;
            dtFactoryPaid.Checked = false;
            txtSearchLoad.Text = "";
            LimpiaCategory();
            

            //Limpiando Pickup&Drop
            dtArrivaDate.Text = "";
            txtPDTotalTime.Text = "";
            txtNotes.Text = "";
            dtStartDate.Text = "";
            txtPDStarCS.Text = "";
            txtPDEndCS.Text = "";
            txtPDSealReceiver.Text = "";
            txtPDSealShipper.Text = "";
            txtPDShipper.Text = "";
            txtPDPickupTime.Text = "";
            txtPDPickupNumber.Text = "";
            dtPDPickupAppoinment.Text = "";
            txtPDTotalTime.Text = "";
            txtPDDeliveryNumber.Text = "";

            //Limpiando Fuel
            dtFuelDate.Text = "";
            txtStation.Text = "";
            txtMileage.Text = "";
            txtTruckStop.Text = "";
            txtFuelCS.Text = "";
            cbPayment.Text = "";
            txtQuantity.Text = "";
            txtCost.Text = "";
            txtTotal.Text = "";
            txtAdvance.Text = "";
            txtInvoiveNumber.Text = "";

            //Limpiando Expenses
            dtExpensesDate.Text = "";
            txtDescription2.Text = "";
            txtExpensesCost.Text = "";

            lbTotalExpenss.Text = "";

            //Limpiando Route
            txtState2.Text = "";
            txtStartOdom.Text = "";
            txtEnOdom2.Text = "";
            txtMiles.Text = "";
            txtTollMiles.Text = "";
            txtGallons.Text = "";
            txtHighways.Text = "";

            lbTotalMiles.Text = "";
            lbTollMiiles.Text = "";
            lbTotalGallons2.Text = "";

            //Limpiando Notes
            txtNotes2.Text = "";
            txtCRequi.Text = "";

            //Limpiando Documents
            txtName.Text = "";
            dtAnnotation.Text = "";
            txtDescription.Text = "";

            //Limpiando Profit
            mtbExpenses.Text = "0";
            mtbExpensesCompany.Text = "0";
            mtbDriverPay.Text = "0";
            mtbTExpenses.Text = "0";
            mtbCostPerMiles.Text = "0";
            mtbProfPerMiles.Text = "0";
            mtbPayPerLoadMiles.Text = "0";
            mtbPayPerEmptyMiles.Text = "0";
            mtbPayPerTonnage.Text = "0";
            mtbPayPerHours.Text = "0";
            mbtPayPickup.Text = "0";
            mtbTotalToPay.Text = "0";
            mbtDeductions.Text = "0";
            mtbPayPerPercentage.Text = "0";
            mtbPayPerHours.Text = "0";
            mtbTotalPay.Text = "0";
            mtbVacations.Text = "0";
            mtbTotalProfit.Text = "0";
            mtbELD.Text = "0";
            mtbPrePass.Text = "0";
            mtbEZPass.Text = "0";
            mtbInsurance.Text = "0";
            mtbFactoryFee.Text = "0";
            mtbPaymentFee.Text = "0";
            mtbFuel.Text = "0";
            mtbTotalDeductions.Text = "0";

            LoadStatus = "";

            btnTripAdd.Enabled = true;
            btnTripAdd.FlatStyle = FlatStyle.Flat;
            btnTripUpd.Enabled = false;
            btnTripUpd.FlatStyle = FlatStyle.Standard;
            btnTripDel.Enabled = false;
            btnTripDel.FlatStyle = FlatStyle.Standard;
            btnPckupAdd.Enabled = false;
            btnPckupAdd.FlatStyle = FlatStyle.Standard;
            btnFuelAdd.Enabled = false;
            btnFuelAdd.FlatStyle = FlatStyle.Standard;
            btnExpensesAdd.Enabled = false;
            btnExpensesAdd.FlatStyle = FlatStyle.Standard;
            btnRouteAdd.Enabled = false;
            btnRouteAdd.FlatStyle = FlatStyle.Standard;
            btnNotesAdd.Enabled = false;
            btnNotesAdd.FlatStyle = FlatStyle.Standard;
        }

        private void dtFactoryDate_Leave(object sender, EventArgs e)
        {
            if(dtFactoryDate.Value >= dtEndDate.Value && dtFactoryDate.Checked==true && rbLSDelivered.Checked == true)
            {
                double milestruck = 0;
                double milestrailer = 0;
                double hoursapu = 0;
                double rate = 0;

                dgvAdmin.DataSource = conectandose.Consultar("adminmaintenances");
                rate =  Convert.ToDouble(dgvAdmin.Rows[0].Cells[15].Value);

                dgvTrucks.DataSource = conectandose.ConsultarTrucks("trucksprofiles", txtTruck.Text);
                milestruck =  Convert.ToDouble(txtTotalMiles.Text);
                milestruck += Convert.ToDouble(dgvTrucks.Rows[0].Cells[23].Value);
                NpgsqlCommand cmd = new NpgsqlCommand("update trucksprofiles set totalmiles='" + milestruck.ToString() + "'" + " where trucknumber like '" + txtTruck.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                dgvTrailers.DataSource = conectandose.ConsultarTrailers("trailersprofiles", txtTrailer.Text);
                milestrailer = Convert.ToDouble(txtTotalMiles.Text);
                milestrailer += Convert.ToDouble(dgvTrailers.Rows[0].Cells[16].Value);
                NpgsqlCommand cmd2 = new NpgsqlCommand("update trailersprofiles set totalmiles='" + milestrailer.ToString() + "'" + " where trailernumber like '" + txtTrailer.Text + "'", conn);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                dgvApu.DataSource = conectandose.ConsultarApus("apuprofiles", txtTruck.Text);
                //End Date
                string year1 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[18].Value).Year.ToString();
                int intyear1 = Convert.ToInt32(year1);
                string mes1 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[18].Value).Month.ToString();
                int intmes1 = Convert.ToInt32(mes1);
                string dia1 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[18].Value).Day.ToString();
                int intdia1 = Convert.ToInt32(dia1);
                string hora1 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[18].Value).Hour.ToString();
                int inthora1 = Convert.ToInt32(hora1);
                //LastDate
                string year2 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[28].Value).Year.ToString();
                int intyear2 = Convert.ToInt32(year2);
                string mes2 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[28].Value).Month.ToString();
                int intmes2 = Convert.ToInt32(mes2);
                string dia2 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[28].Value).Day.ToString();
                int intdia2 = Convert.ToInt32(dia2);
                string hora2 = Convert.ToDateTime(dgvTripInfo.Rows[sgte].Cells[28].Value).Hour.ToString();
                int inthora2 = Convert.ToInt32(hora2);

                hoursapu = ((intyear1 - intyear2) * 8760 + (intmes1 - intmes2) * 720 + (intdia1 - intdia2) * 24 + (inthora1 - inthora2)) * (rate / 100);
                
                hoursapu += Convert.ToDouble(dgvApu.Rows[0].Cells[10].Value);
                NpgsqlCommand cmd3 = new NpgsqlCommand("update apuprofiles set totalhours='" + hoursapu.ToString() + "'" + " where trucknumber like '" + txtTruck.Text + "'", conn);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();

                dtFactoryDate.Checked = true;
                dtFactoryDate.Enabled = false;
            }
                
        }

        private void btnTripUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbLSAvailable.Checked == true)
                    LoadStatus = "0";
                if (rbLSInTransit.Checked == true)
                    LoadStatus = "1";
                if (rbLSDelivered.Checked == true)
                    LoadStatus = "2";
                if (rbLSCancelled.Checked == true)
                    LoadStatus = "3";
                NpgsqlCommand cmd = new NpgsqlCommand("update revenues set client='" + cbBrockers.Text + "',contact='" + cbContactName.Text + "',loadid='" + txtLoadId.Text + "',loadstatus=@loadStatus,driver='" + txtDriver.Text + "',truckid='" + txtTruck.Text + "',trailerid='" + txtTrailer.Text + "',chassisid='" + txtChassis.Text + "',weight='" + txtWeight.Text + "',piececount='" + txtPiece.Text + "',loadtemp='" + txtLoadTemp.Text + "',loadtype='" + cbLoadType.Text + "',lastemptydate='" + dtLastDate.Value + "',deadheadfrom='" + txtDeadHead.Text + "',lastemptyodometer='" + txtLastEmptyOdom.Text + "',loaddate='" + dtLoadDate.Value + "',startcityst='" + txtStartCS.Text + "',loadodometer='" + txtLoadOdom.Text + "',enddate='" + dtEndDate.Value + "',endcityst='" + txtEndCS.Text + "',endodometer='" + txtEndOdom.Text + "',personalmiles='" + txtPersonalMiles.Text + "',deadheadmiles='" + txtDeadHeadMiles.Text + "',loadmiles='" + txtLoadMiles.Text + "',totalmiles='" + txtTotalMiles.Text + "',flatrate='" + txtFlatRate.Text + "',totalotherpay='" + txtTotalOther.Text + "',totaltrippay='" + txtTotalTrip.Text + "',totaltripbasic='" + txtTotalTripBasic.Text + "',factorydate='" + dtFactoryDate.Value + "',ammount='" + txtTripPayAmmount.Text + "',category='" + cbTripPayCategory.Text + "',iddriver='" + idDriver.ToString() + "',factorypaid='" + dtFactoryPaid.Value + "',chkfactorydate='" + dtFactoryDate.Checked + "',chkfactorypaid='" + dtFactoryPaid.Checked + "'" + " where id=" + codigoTrip, conn);
                cmd.Parameters.AddWithValue("loadstatus", LoadStatus);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            //gbLoadStatus_Enter(sender, e);
            dgvTripInfo.DataSource = conectandose.Consultar(TblName);
            
        }
        private void CategoryPayUpd(string zcategory, string zammount)
        {
            try
            {
                NpgsqlCommand cmd3 = new NpgsqlCommand("update paycategories set idrevenue='" + txtLoadId.Text + "',category='" + zcategory + "',ammount='" + zammount + "',loadstatus=@loadStatus3" + " where id=" + codigoPay, conn);
                cmd3.Parameters.AddWithValue("loadstatus3", LoadStatus);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvPayCategories.DataSource = conectandose.ConsultarStatus("paycategories",txtLoadId.Text);
            
        }
        private void btnTripDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoTrip);
                    btnClearTrip_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvTripInfo.DataSource = conectandose.Consultar(TblName);
            }
        }
        private void btnTripAdd_Click(object sender, EventArgs e)
        {
            if (rbLSAvailable.Checked == true)
                LoadStatus = "0";
            if (rbLSInTransit.Checked == true)
                LoadStatus = "1";
            if (rbLSDelivered.Checked == true)
                LoadStatus = "2";
            if (rbLSCancelled.Checked == true)
                LoadStatus = "3";
            if (cbBrockers.Text != "" && txtLoadId.Text !="")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into revenues (client,contact,loadid,loadstatus,driver,truckid,trailerid,chassisid,weight,piececount,loadtemp, loadtype,lastemptydate,deadheadfrom,lastemptyodometer,loaddate,startcityst,loadodometer,enddate,endcityst,endodometer,personalmiles,deadheadmiles,loadmiles,totalmiles,flatrate,totalotherpay,totaltrippay,totaltripbasic,factorydate,ammount,category,iddriver,factorypaid,chkfactorydate,chkfactorypaid) values ('" + cbBrockers.Text + "','" + cbContactName.Text + "','" + txtLoadId.Text + "',@LoadStatus,'" + txtDriver.Text + "','" + txtTruck.Text + "','" + txtTrailer.Text + "','" + txtChassis.Text + "','" + txtWeight.Text + "','" + txtPiece.Text + "','" + txtLoadTemp.Text + "','" + cbLoadType.Text + "','" + dtLastDate.Value + "','" + txtDeadHead.Text + "','" + txtLastEmptyOdom.Text + "','" + dtLoadDate.Value + "','" + txtStartCS.Text + "','" + txtLoadOdom.Text + "', '" + dtEndDate.Value + "','" + txtEndCS.Text + "','" + txtEndOdom.Text + "','" + txtPersonalMiles.Text + "','" + txtDeadHeadMiles.Text + "','" + txtLoadMiles.Text + "','" + txtTotalMiles.Text + "','" + txtFlatRate.Text + "','" + txtTotalOther.Text + "','" + txtTotalTrip.Text + "','" + txtTotalTripBasic.Text + "','" + dtFactoryDate.Value + "','" + txtTripPayAmmount.Text + "','" + cbTripPayCategory.Text + "','" + idDriver.ToString() + "','" + dtFactoryDate.Value + "','" + dtFactoryDate.Checked + "','" + dtFactoryPaid.Checked + "')", conn);
                    cmd.Parameters.AddWithValue("loadstatus", LoadStatus);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nBroker, LoadId, Driver, #Truck, Weight and PayAmmount", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvTripInfo.DataSource = conectandose.Consultar(TblName);

            btnTripAdd.Enabled = false;
            btnTripAdd.FlatStyle = FlatStyle.Standard;
            btnTripUpd.Enabled = true;
            btnTripDel.Enabled = true;
            btnTripUpd.FlatStyle = FlatStyle.Flat;
            btnTripDel.FlatStyle = FlatStyle.Flat;

            btnPckupAdd.Enabled = true;
            btnNotesAdd.Enabled = true;
            btnFuelAdd.Enabled = true;
            btnExpensesAdd.Enabled = true;
            btnRouteAdd.Enabled = true;
            btnOpen.Enabled = true;

        }
        private void btnSearchDriver_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("driverprofiles","");
            search.ShowDialog();
            txtDriver.Text = search.Nombre;
            idDriver = search.Driver;
        }
        private void btnSearchTruck_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("trucksprofiles","");
            search.ShowDialog();
            txtTruck.Text = search.Nombre;
        }
        private void btnSearchTrailer_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("trailersprofiles","");
            search.ShowDialog();
            txtTrailer.Text = search.Nombre;
        }
        private void btnSearchDead_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtDeadHead.Text = search.Nombre;
        }
        private void btnSearchStartCS_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtStartCS.Text = search.Nombre;
        }
        private void btnSearchEndCS_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtEndCS.Text = search.Nombre;
        }
        private void btnTripNext_MouseHover_1(object sender, EventArgs e)
        {
            lbPosition.Location = new Point(351, 41);
            lbPosition.Text = "Next Record";
            lbPosition.Visible = true;
        }
        private void btnTripNext_MouseLeave(object sender, EventArgs e)
        {
            lbPosition.Visible = false;
        }
        /// <summary> ////////////////////////////////////////////////////
        /// PICKUP & DROPS
        /// </summary> ///////////////////////////////////////////////////

        private void btnPDFirst_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetFirstRow(0);
                dgvPickup_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaPD();
            }
        }

        private void btnPDPrevious_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetPreviousRow(sgtepd, 0);
                if (sgtepd == -1) sgtepd = cuentapd - 1;
                if (sgtepd <= cuentapd && sgtepd >= 0)
                {
                    dgvPickup_RowEnter(sender, e);
                    rellenaPD();
                }
            }
        }

        private void btnPDNext_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetNextRow(sgtepd, 0);
                if (sgtepd == -1) sgtepd = 0;
                if (sgtepd <= cuentapd && sgtepd >= 0)
                {
                    dgvPickup_RowEnter(sender, e);
                    rellenaPD();
                }
            }
        }

        private void btnPDEnd_Click(object sender, EventArgs e)
        {
            cuentapd = dgvPickup.Rows.GetLastRow(0) + 1;
            if (cuentapd != 0)
            {
                sgtepd = dgvPickup.Rows.GetLastRow(0);
                dgvPickup_RowEnter(sender, e);
                rellenaPD();
            }
        }

        private void dgvPickup_RowEnter(object sender, EventArgs e)
        {
            dgvPickup.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvPickup.Rows[sgtepd].Selected = true;
            dgvPickup.FirstDisplayedScrollingRowIndex = dgvPickup.Rows.GetNextRow(sgtepd - 1, 0);
        }
        private void rellenaPD()
        {
            if (txtLoadId.Text != "" && cuentapd > 0)
            {
                btnPckupAdd.Enabled = false;
                btnPckupAdd.FlatStyle = FlatStyle.Standard;
                btnPckupUpd.Enabled = true;
                btnPckupDel.Enabled = true;
                btnPckupUpd.FlatStyle = FlatStyle.Flat;
                btnPckupDel.FlatStyle = FlatStyle.Flat;

                codigoPickup = Convert.ToInt32(dgvPickup.Rows[sgtepd].Cells[0].Value);

                cbPDType.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[2].Value);
                dtStartDate.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[3].Value);
                txtPDStarCS.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[4].Value);
                dtArrivaDate.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[5].Value);
                txtPDEndCS.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[6].Value);
                txtPDReceiver.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[7].Value);
                dtPDReceiverAppoinment.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[8].Value);
                txtPDTotalTime.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[9].Value);
                txtNotes.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[10].Value);
                txtPDSealReceiver.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[12].Value);
                txtPDSealShipper.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[13].Value);
                txtPDShipper.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[14].Value);
                dtPDPickupAppoinment.Value = Convert.ToDateTime(dgvPickup.Rows[sgtepd].Cells[15].Value);
                txtPDPickupNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[16].Value);
                txtPDPickupTime.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[17].Value);
                txtPDDeliveryNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[18].Value);
                txtAPDeliveryNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[19].Value);
                txtAPPickupNumber.Text = Convert.ToString(dgvPickup.Rows[sgtepd].Cells[20].Value);

                lbRecordPD.Text = "Record " + (sgtepd + 1) + " of  " + cuentapd;
                lbRuta.Text = "From: " + txtPDStarCS.Text + " < to > " + txtPDEndCS.Text;
            }
        }

        private void btnClearPickup_Click(object sender, EventArgs e)
        {
            btnPckupAdd.Enabled = true;
            btnPckupAdd.FlatStyle = FlatStyle.Flat;
            btnPckupUpd.Enabled = false;
            btnPckupDel.Enabled = false;
            btnPckupUpd.FlatStyle = FlatStyle.Standard;
            btnPckupDel.FlatStyle = FlatStyle.Standard;


            cbPDType.Text = "";
            txtPDShipper.Text = "";
            dtStartDate.Text = "";
            txtPDStarCS.Text = "";
            txtPDSealShipper.Text = "";

            dtArrivaDate.Text = "";
            txtPDEndCS.Text = "";
            txtPDReceiver.Text = "";
            dtPDReceiverAppoinment.Text = "";
            txtPDTotalTime.Text = "0";
            txtPDSealReceiver.Text = "";
            txtNotes.Text = "";

            txtPDPickupTime.Text = "";
            txtPDPickupNumber.Text = "";
            dtPDPickupAppoinment.Text = "";
            txtPDTotalTime.Text = "";
            txtPDDeliveryNumber.Text = "";
            txtAPPickupNumber.Text = "";
            txtAPDeliveryNumber.Text = "";
        }

        private void dtAppoinmentDate_Leave(object sender, EventArgs e)
        {

        }

        private void btnPckupAdd_Click(object sender, EventArgs e)
        { 
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into rvpickupdrops (idrevenue,pickdroptype,startdate,startcs,arrivadate,endcs,customerliveload,appoinmentdate,totaltime,notes,sealreceiver,sealshipper,shipper,pickupappoinment,pickupnumber,pickuptime,deliverynumber,apptdeliverynumber,apptpickupnumber) values ('" + lbLoadIdPickup.Text + "','" + cbPDType.Text + "','" + dtStartDate.Value + "','" + txtPDStarCS.Text + "','" + dtArrivaDate.Value + "','" + txtPDEndCS.Text + "','" + txtPDReceiver.Text + "','" + dtPDReceiverAppoinment.Value + "','" + txtPDTotalTime.Text + "',@notes,'" + txtPDSealReceiver.Text + "','" + txtPDSealShipper.Text + "','" + txtPDShipper.Text + "','" + dtPDPickupAppoinment.Value + "','" + txtPDPickupNumber.Text + "','" + txtPDPickupTime.Text + "','" + txtPDDeliveryNumber.Text + "','" + txtAPDeliveryNumber.Text + "','" + txtAPPickupNumber.Text + "')", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Insert successfully");
                MessageBox.Show("Remember to add Customer Requiments in Notes", "Customer Requiments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            
            dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdPickup.Text);
            cuentapd = dgvPickup.Rows.GetRowCount(0);
            lbRecordPD.Text = "Record " + (sgtepd + 1) + " of  " + cuentapd;
            btnPckupAdd.Enabled = false;
            btnPckupAdd.FlatStyle = FlatStyle.Standard;
            btnPckupUpd.Enabled = true;
            btnPckupDel.Enabled = true;
            btnPckupUpd.FlatStyle = FlatStyle.Flat;
            btnPckupDel.FlatStyle = FlatStyle.Flat;
        }

        private void btnPckupDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoPickup);
                    btnClearPickup_Click(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdPickup.Text);
            }

        }

        private void btnPckupUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvpickupdrops set idrevenue='" + lbLoadIdPickup.Text + "',pickdroptype='" + cbPDType.Text + "',startdate='" + dtStartDate.Value + "',startcs='" + txtPDStarCS.Text + "',arrivadate='" + dtArrivaDate.Value + "',endcs='" + txtPDEndCS.Text + "',customerliveload= '" + txtPDReceiver.Text + "',appoinmentdate='" + dtPDReceiverAppoinment.Value + "',totaltime='" + txtPDTotalTime.Text + "',notes=@notes,sealreceiver='" + txtPDSealReceiver.Text + "',sealshipper='" + txtPDSealShipper.Text + "',shipper='" + txtPDShipper.Text + "',pickupappoinment='" + dtPDPickupAppoinment.Value + "',pickupnumber='" + txtPDPickupNumber.Text + "',pickuptime='" + txtPDPickupTime.Text + "',deliverynumber='" + txtPDDeliveryNumber.Text + "',apptdeliverynumber='" + txtAPDeliveryNumber.Text + "',apptpickupnumber='" + txtAPPickupNumber.Text + "'" + " where id=" + codigoPickup, conn);
                cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();

            }
            dgvPickup.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdPickup.Text);
        }

        /// <summary> ////////////////////////////////////////////////////
        /// FUEL
        /// </summary> ///////////////////////////////////////////////////

        private void btnFuelFirst_Click(object sender, EventArgs e)
        {
            cuentaFuel = dgvFuel.Rows.GetRowCount(0);
            if (cuentaFuel != 0)
            {
                sgteFuel = dgvFuel.Rows.GetFirstRow(0);
                dgvFuel_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaFuel();
            }
        }

        private void btnFuelPrevious_Click(object sender, EventArgs e)
        {
            cuentaFuel = dgvFuel.Rows.GetRowCount(0);
            if (cuentaFuel != 0)
            {
                sgteFuel = dgvFuel.Rows.GetPreviousRow(sgteFuel, 0);
                if (sgteFuel == -1) sgteFuel = cuentaFuel - 1;
                if (sgteFuel <= cuentaFuel && sgteFuel >= 0)
                {
                    dgvFuel_RowEnter(sender, e);
                    rellenaFuel();
                }
            }
        }

        private void btnFuelNext_Click(object sender, EventArgs e)
        {
            cuentaFuel = dgvFuel.Rows.GetRowCount(0);
            if (cuentaFuel != 0)
            {
                sgteFuel = dgvFuel.Rows.GetNextRow(sgteFuel, 0);
                if (sgteFuel == -1) sgteFuel = 0;
                if (sgteFuel <= cuentaFuel && sgteFuel >= 0)
                {
                    dgvFuel_RowEnter(sender, e);
                    rellenaFuel();
                }
            }
        }

        private void btnFuelEnd_Click(object sender, EventArgs e)
        {
            cuentaFuel = dgvFuel.Rows.GetRowCount(0);
            if (cuentaFuel != 0)
            {
                sgteFuel = dgvFuel.Rows.GetLastRow(0);
                dgvFuel_RowEnter(sender, e);
                rellenaFuel();
            }
        }

        private void dgvFuel_RowEnter(object sender, EventArgs e)
        {
            dgvFuel.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvFuel.Rows[sgteFuel].Selected = true;
            dgvFuel.FirstDisplayedScrollingRowIndex = dgvFuel.Rows.GetNextRow(sgteFuel - 1, 0);
        }

        private void rellenaFuel()
        {
            if (txtLoadId.Text != "" && cuentaFuel > 0)
            {
                btnFuelAdd.Enabled = false;
                btnFuelAdd.FlatStyle = FlatStyle.Standard;
                btnFuelUpd.Enabled = true;
                btnFuelDel.Enabled = true;
                btnFuelUpd.FlatStyle = FlatStyle.Flat;
                btnFuelDel.FlatStyle = FlatStyle.Flat;

                costototal = 0.0;
                zmtbFuel = "0";
                double costoquantity = 0.0, costoadvance = 0.0;

                codigoFuel = Convert.ToInt32(dgvFuel.Rows[sgteFuel].Cells[0].Value);

                dtFuelDate.Value = Convert.ToDateTime(dgvFuel.Rows[sgteFuel].Cells[2].Value);
                txtMileage.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[3].Value);
                txtTruckStop.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[4].Value);
                txtFuelCS.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[5].Value);
                cbPayment.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[6].Value);
                txtQuantity.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[7].Value);
                txtCost.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[8].Value);
                txtTotal.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[9].Value);
                txtAdvance.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[10].Value);
                txtInvoiveNumber.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[11].Value);
                txtDEFCost.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[12].Value);
                txtDEF.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[13].Value);
                txtStation.Text = Convert.ToString(dgvFuel.Rows[sgteFuel].Cells[14].Value);

                string cadena = "select idrevenue, quantity, cost, advance, costdef, quantitydef  from rvfuels where idrevenue = '" + lbLoadIdFuel.Text + "'";

                conn2.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    costoquantity += Convert.ToDouble(dr["quantity"]) + Convert.ToDouble(dr["costdef"]);
                    costototal += Convert.ToDouble(dr["cost"]);
                    costoadvance += Convert.ToDouble(dr["advance"]);
                }
                conn2.Close();
                zmtbFuel = costototal.ToString();

                lbRecordFuel.Text = "Record " + (sgteFuel + 1) + " of  " + cuentaFuel;
            }

        }
       
        private void btnClearFuel_Click(object sender, EventArgs e)
        {
            dtFuelDate.Text = "";
            txtDEF.Text = "0";
            txtDEFCost.Text = "0";
            txtStation.Text = "0";
            txtMileage.Text = "0";
            txtTruckStop.Text = "0";
            txtFuelCS.Text = "";
            cbPayment.Text = "";
            txtQuantity.Text = "0";
            txtCost.Text = "0";
            txtTotal.Text = "0";
            txtAdvance.Text = "0";
            txtInvoiveNumber.Text = "0";
            btnFuelAdd.Enabled = true;
            btnFuelAdd.FlatStyle = FlatStyle.Flat;
            
            btnFuelUpd.Enabled = false;
            btnFuelDel.Enabled = false;
            btnFuelUpd.FlatStyle = FlatStyle.Standard;
            btnFuelDel.FlatStyle = FlatStyle.Standard;

        }

        private void btnFuelAdd_Click(object sender, EventArgs e)
        {
            if (dtFuelDate.Value != null && cbPayment.Text != "" && txtQuantity.Text != "" && txtCost.Text != "" && txtInvoiveNumber.Text != "")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into rvfuels (idrevenue,date,quantitydef,costdef,station,mileage,truckstop,state,payment,quantity,cost,total,advance,invoicenumber) values ('" + lbLoadIdFuel.Text + "','" + dtFuelDate.Value + "','" + txtDEF.Text + "','" + txtDEFCost.Text + "','" + txtStation.Text + "','" + txtMileage.Text + "','" + txtTruckStop.Text + "','" + txtFuelCS.Text + "','" + cbPayment.Text + "','" + txtQuantity.Text + "','" + txtCost.Text + "','" + txtTotal.Text + "','" + txtAdvance.Text + "','" + txtInvoiveNumber.Text + "')", conn);
                    conn.Open();
                    //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nDate, Payment, Quantity, Cost, #Invoice", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvFuel.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdFuel.Text);
            cuentaFuel = dgvFuel.Rows.GetRowCount(0);
            lbRecordFuel.Text = "Record " + (sgteFuel + 1) + " of  " + cuentaFuel;
            btnFuelAdd.Enabled = false;
            btnFuelAdd.FlatStyle = FlatStyle.Standard;
            btnFuelUpd.Enabled = true;
            btnFuelDel.Enabled = true;
            btnFuelUpd.FlatStyle = FlatStyle.Flat;
            btnFuelDel.FlatStyle = FlatStyle.Flat;
        }

        private void btnFuelDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoFuel);
                    btnClearPickup_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvFuel.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdFuel.Text);
            }
        }

        private void btnFuelUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvfuels set idrevenue='" + lbLoadIdFuel.Text + "',date='" + dtFuelDate.Value + "',quantitydef='" + txtDEF.Text + "',costdef='" + txtDEFCost.Text + "',station='" + txtStation.Text + "',mileage='" + txtMileage.Text + "',truckstop='" + txtTruckStop.Text + "',state='" + txtFuelCS.Text + "',payment='" + cbPayment.Text + "',quantity='" + txtQuantity.Text + "',cost='" + txtCost.Text + "',total='" + txtTotal.Text + "',advance='" + txtAdvance.Text + "',invoicenumber='" + txtInvoiveNumber.Text + "'" + " where id=" + codigoFuel, conn);
                //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvFuel.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdFuel.Text);
            rellenaFuel();
        }

        private void btnFuelCS_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtFuelCS.Text = search.Nombre;
        }

        /// <summary> ////////////////////////////////////////////////////
        /// EXPENSES
        /// </summary> ///////////////////////////////////////////////////
        ////
        ///
        private void btnExpensFirst_Click(object sender, EventArgs e)
        {
            cuentaExpense = dgvExpenses.Rows.GetLastRow(0) + 1;
            if (cuentaExpense != 0)
            {
                sgteExpense = dgvExpenses.Rows.GetFirstRow(0);
                dgvExpenses_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaExpense();
            }
        }

        private void btnExpensPrevious_Click(object sender, EventArgs e)
        {
            cuentaExpense = dgvExpenses.Rows.GetLastRow(0) + 1;
            if (cuentaExpense != 0)
            {
                sgteExpense = dgvExpenses.Rows.GetPreviousRow(sgteExpense, 0);
                if (sgteExpense == -1) sgteExpense = cuentaExpense - 1;
                if (sgteExpense <= cuentaExpense && sgteExpense >= 0)
                {
                    dgvExpenses_RowEnter(sender, e);
                    rellenaExpense();
                }
            }
        }

        private void btnExpensNext_Click(object sender, EventArgs e)
        {
            cuentaExpense = dgvExpenses.Rows.GetLastRow(0) + 1;
            if (cuentaExpense != 0)
            {
                sgteExpense = dgvExpenses.Rows.GetNextRow(sgteExpense, 0);
                if (sgteExpense == -1) sgteExpense = 0;
                if (sgteExpense <= cuentaExpense && sgteExpense >= 0)
                {
                    dgvExpenses_RowEnter(sender, e);
                    rellenaExpense();
                }
            }
        }

        private void btnExpensEnd_Click(object sender, EventArgs e)
        {
            cuentaExpense = dgvExpenses.Rows.GetLastRow(0) + 1;
            if (cuentaExpense != 0)
            {
                sgteExpense = dgvExpenses.Rows.GetLastRow(0);
                dgvExpenses_RowEnter(sender, e);
                rellenaExpense();
            }
        }

        private void dgvExpenses_RowEnter(object sender, EventArgs e)
        {
            dgvExpenses.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvExpenses.Rows[sgteExpense].Selected = true;
            dgvExpenses.FirstDisplayedScrollingRowIndex = dgvExpenses.Rows.GetNextRow(sgteExpense - 1, 0);
        }

        private void rellenaExpense()
        {
            if (txtLoadId.Text != "" && cuentaExpense > 0)
            {
                btnExpensesAdd.Enabled = false;
                btnExpensesAdd.FlatStyle = FlatStyle.Standard;
                btnExpensesUpd.Enabled = true;
                btnExpensesDel.Enabled = true;
                btnExpensesUpd.FlatStyle = FlatStyle.Flat;
                btnExpensesDel.FlatStyle = FlatStyle.Flat;

                costototal = 0.0;
                zExpensesConCargo = 0.0;
                zmtbExpenses = "";
                codigoExpenses = Convert.ToInt32(dgvExpenses.Rows[sgteExpense].Cells[0].Value);

                dtExpensesDate.Value = Convert.ToDateTime(dgvExpenses.Rows[sgteExpense].Cells[2].Value);
                txtDescription2.Text = Convert.ToString(dgvExpenses.Rows[sgteExpense].Cells[3].Value);
                txtExpensesCost.Text = Convert.ToString(dgvExpenses.Rows[sgteExpense].Cells[4].Value);
                if (Convert.ToString(dgvExpenses.Rows[sgteExpense].Cells[5].Value) == "True")
                    chkCargoDriver.Checked = true;
                else chkCargoDriver.Checked = false;

                string cadena = "select idrevenue, cost, cargostatus from rvexpenses where idrevenue = '" + lbLoadIdExpenses.Text + "'";
                conn2.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    costototal += Convert.ToDouble(dr["cost"]);
                    if (dr["cargostatus"].ToString() == "True") 
                        zExpensesConCargo += Convert.ToDouble(dr["cost"]);
                }
                lbTotalExpenss.Text = costototal.ToString();
                zmtbExpenses = costototal.ToString();
                conn2.Close();

                lbRecordExpense.Text = "Record " + (sgteExpense + 1) + " of " + cuentaExpense;
            }
        }
        
        private void btnClearExpenses_Click_1(object sender, EventArgs e)
        {
            dtExpensesDate.Text = "";
            txtDescription2.Text = "";
            txtExpensesCost.Text = "0";
            lbTotalExpenss.Text = "";
            chkCargoDriver.Checked = true;

            btnExpensesAdd.Enabled = true;
            btnExpensesUpd.FlatStyle = FlatStyle.Flat;
            btnExpensesUpd.Enabled = false;
            btnExpensesDel.Enabled = false;
            btnExpensesUpd.FlatStyle = FlatStyle.Standard;
            btnExpensesDel.FlatStyle = FlatStyle.Standard;
        }

        private void btnExpensesAdd_Click(object sender, EventArgs e)
        {
            if (dtExpensesDate.Value != null && txtExpensesCost.Text != "0")
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into rvexpenses (idrevenue,date,description,cost,cargostatus) values ('" + lbLoadIdExpenses.Text + "','" + dtExpensesDate.Value + "',@description,'" + txtExpensesCost.Text + "','" + chkCargoDriver.Checked + "')", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("description", txtDescription2.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nDate, Cost", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvExpenses.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdExpenses.Text);
            cuentaExpense = dgvExpenses.Rows.GetRowCount(0);
            lbRecordExpense.Text = "Record " + (sgteExpense + 1) + " of  " + cuentaExpense;
            btnExpensesAdd.Enabled = false;
            btnExpensesAdd.FlatStyle = FlatStyle.Standard;
            btnExpensesUpd.Enabled = true;
            btnExpensesDel.Enabled = true;
            btnExpensesUpd.FlatStyle = FlatStyle.Flat;
            btnExpensesDel.FlatStyle = FlatStyle.Flat;
        }

        private void btnExpensesDel_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoExpenses);
                    btnClearPickup_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvExpenses.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdExpenses.Text);
            }
        }

        private void btnExpensesUpd_Click_1(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvexpenses set idrevenue='" + lbLoadIdExpenses.Text + "',date='" + dtExpensesDate.Value + "',description=@description,cost='" + txtExpensesCost.Text + "',cargostatus='" + chkCargoDriver.Checked + "'" + " where id=" + codigoExpenses, conn);
                cmd.Parameters.AddWithValue("description", txtDescription2.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvExpenses.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdExpenses.Text);
            rellenaExpense();
        }

/// <summary> ////////////////////////////////////////////////////
/// ROUTE
/// </summary> ///////////////////////////////////////////////////
////////
        private void btnRouteFirst_Click(object sender, EventArgs e)
        {
            cuentaRoute = dgvRoute.Rows.GetLastRow(0) + 1;
            if (cuentaRoute != 0)
            {
                sgteRoute = dgvRoute.Rows.GetFirstRow(0);
                dgvRoute_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaRoute();
            }
        }

        private void btnRoutePrevious_Click(object sender, EventArgs e)
        {
            cuentaRoute = dgvRoute.Rows.GetLastRow(0) + 1;
            if (cuentaRoute != 0)
            {
                sgteRoute = dgvRoute.Rows.GetPreviousRow(sgteRoute, 0);
                if (sgteRoute == -1) sgteRoute = cuentaRoute - 1;
                if (sgteRoute <= cuentaRoute && sgteRoute >= 0)
                {
                    dgvRoute_RowEnter(sender, e);
                    rellenaRoute();
                }
            }
        }

        private void btnRouteNext_Click(object sender, EventArgs e)
        {
            cuentaRoute = dgvRoute.Rows.GetLastRow(0) + 1;
            if (cuentaRoute != 0)
            {
                sgteRoute = dgvRoute.Rows.GetNextRow(sgteRoute, 0);
                if (sgteRoute == -1) sgteRoute = 0;
                if (sgteRoute <= cuentaRoute && sgteRoute >= 0)
                {
                    dgvRoute_RowEnter(sender, e);
                    rellenaRoute();
                }
            }
        }

        private void btnRouteEnd_Click(object sender, EventArgs e)
        {
            cuentaRoute = dgvRoute.Rows.GetLastRow(0) + 1;
            if (cuentaRoute != 0)
            {
                sgteRoute = dgvRoute.Rows.GetLastRow(0);
                dgvRoute_RowEnter(sender, e);
                rellenaRoute();
            }
        }

        private void dgvRoute_RowEnter(object sender, EventArgs e)
        {
            dgvRoute.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvRoute.Rows[sgteRoute].Selected = true;
            dgvRoute.FirstDisplayedScrollingRowIndex = dgvRoute.Rows.GetNextRow(sgteRoute - 1, 0);
        }

        private void rellenaRoute()
        {
            if (txtLoadId.Text != "" && cuentaRoute > 0)
            {
                btnRouteAdd.Enabled = false;
                btnRouteAdd.FlatStyle = FlatStyle.Standard;
                btnRouteUpd.Enabled = true;
                btnRouteDel.Enabled = true;
                btnRouteUpd.FlatStyle = FlatStyle.Flat;
                btnRouteDel.FlatStyle = FlatStyle.Flat;

                double totalMiles = 0.0, totalToll = 0.0, totalGallons = 0.0;

                codigoRoute = Convert.ToInt32(dgvRoute.Rows[sgteRoute].Cells[0].Value);

                txtState2.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[2].Value);
                txtStartOdom.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[3].Value);
                txtEnOdom2.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[4].Value);
                txtMiles.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[5].Value);
                txtTollMiles.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[6].Value);
                txtGallons.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[7].Value);
                txtHighways.Text = Convert.ToString(dgvRoute.Rows[sgteRoute].Cells[8].Value);

                string cadena = "select idrevenue, miles, tollmiles, gallons from rvroutes where idrevenue = '" + lbLoadIdRoute.Text + "'";

                conn2.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    totalMiles += Convert.ToDouble(dr["miles"]);
                    totalToll += Convert.ToDouble(dr["tollmiles"]);
                    totalGallons += Convert.ToDouble(dr["gallons"]);
                }
                lbTotalMiles.Text = totalMiles.ToString();
                lbTollMiiles.Text = totalToll.ToString();
                lbTotalGallons2.Text = totalGallons.ToString();
                conn2.Close();

                lbRecordRoute.Text = "Record " + (sgteRoute + 1) + " of " + cuentaRoute;
            }
        }
        private void btnClearRoute_Click(object sender, EventArgs e)
        {
            txtState2.Text = "";
            txtStartOdom.Text = "";
            txtEnOdom2.Text = "";
            txtMiles.Text = "";
            txtTollMiles.Text = "";
            txtGallons.Text = "";
            txtHighways.Text = "";

            btnRouteAdd.Enabled = true;
            btnRouteAdd.FlatStyle = FlatStyle.Flat;
            btnRouteUpd.Enabled = false;
            btnRouteDel.Enabled = false;
            btnRouteUpd.FlatStyle = FlatStyle.Standard;
            btnRouteDel.FlatStyle = FlatStyle.Standard;
        }

        private void btnRouteAdd_Click(object sender, EventArgs e)
        {
            if (!(txtState2.Text == ""))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into rvroutes (idrevenue,state,startodom,endodom,miles,tollmiles,gallons,highways) values ('" + lbLoadIdRoute.Text + "','" + txtState2.Text + "','" + txtStartOdom.Text + "','" + txtEnOdom2.Text + "','" + txtMiles.Text + "','" + txtTollMiles.Text + "','" + txtGallons.Text + "','" + txtHighways.Text + "')", conn);
                    conn.Open();
                    //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nCity Sate", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvRoute.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdRoute.Text);
            cuentaRoute = dgvRoute.Rows.GetRowCount(0);
            lbRecordRoute.Text = "Record " + (sgteRoute + 1) + " of  " + cuentaRoute;
            btnRouteAdd.Enabled = false;
            btnRouteAdd.FlatStyle = FlatStyle.Standard;
            btnRouteUpd.Enabled = true;
            btnRouteDel.Enabled = true;
            btnRouteUpd.FlatStyle = FlatStyle.Flat;
            btnRouteDel.FlatStyle = FlatStyle.Flat;
        }

        private void btnRouteDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoRoute);
                    btnClearRoute_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvRoute.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdRoute.Text);
            }
        }

        private void btnRouteUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvroutes set idrevenue='" + lbLoadIdRoute.Text + "',state='" + txtState2.Text + "',startodom='" + txtStartOdom.Text + "',endodom='" + txtEnOdom2.Text + "',miles='" + txtMiles.Text + "',tollmiles='" + txtTollMiles.Text + "',gallons='" + txtGallons.Text + "',highways='" + txtHighways.Text + "'" + " where id=" + codigoRoute, conn);
                //cmd.Parameters.AddWithValue("notes", txtNotes.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvRoute.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdRoute.Text);
        }

        private void btnRouteState_MouseHover(object sender, EventArgs e)
        {
            lbRouteState.Visible = true;
        }

        private void btnRouteState_MouseLeave(object sender, EventArgs e)
        {
            lbRouteState.Visible = false;
        }

        private void btnRouteState_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtState2.Text = search.Nombre;
        }
/// <summary>////////////////////////////////
/// NOTES
/// </summary>///////////////////////////////
/////
        private void btNotesFirst_Click(object sender, EventArgs e)
        {
            cuentaNotes = dgvNotes.Rows.GetLastRow(0) + 1;
            if (cuentaNotes != 0)
            {
                sgteNotes = dgvNotes.Rows.GetFirstRow(0);
                dgvNotes_RowEnter(sender, e);
                //sgtepd += 1;
                rellenaNotes();
            }
        }

        private void btNotesPrevious_Click(object sender, EventArgs e)
        {
            cuentaNotes = dgvNotes.Rows.GetLastRow(0) + 1;
            if (cuentaNotes != 0)
            {
                sgteNotes = dgvNotes.Rows.GetPreviousRow(sgteNotes, 0);
                if (sgteNotes == -1) sgteNotes = cuentaNotes - 1;
                if (sgteNotes <= cuentaNotes && sgteNotes >= 0)
                {
                    dgvNotes_RowEnter(sender, e);
                    rellenaNotes();
                }
            }
        }

        private void btNotesNext_Click(object sender, EventArgs e)
        {
            cuentaNotes = dgvNotes.Rows.GetLastRow(0) + 1;
            if (cuentaNotes != 0)
            {
                sgteNotes = dgvNotes.Rows.GetNextRow(sgteNotes, 0);
                if (sgteNotes == -1) sgteNotes = 0;
                if (sgteNotes <= cuentaNotes && sgteNotes >= 0)
                {
                    dgvNotes_RowEnter(sender, e);
                    rellenaNotes();
                }
            }
        }

        private void btNotesEnd_Click(object sender, EventArgs e)
        {
            cuentaNotes = dgvNotes.Rows.GetLastRow(0) + 1;
            if (cuentaNotes != 0)
            {
                sgteNotes = dgvNotes.Rows.GetLastRow(0);
                dgvNotes_RowEnter(sender, e);
                rellenaNotes();
            }
        }

        private void dgvNotes_RowEnter(object sender, EventArgs e)
        {
            dgvNotes.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvNotes.Rows[sgteNotes].Selected = true;
            dgvNotes.FirstDisplayedScrollingRowIndex = dgvNotes.Rows.GetNextRow(sgteNotes - 1, 0);
        }
        private void rellenaNotes()
        {
            if (txtLoadId.Text != "" && cuentaNotes > 0)
            {
                btnNotesAdd.Enabled = false;
                btnNotesAdd.FlatStyle = FlatStyle.Standard;
                btnNotesUpd.Enabled = true;
                btnNotesDel.Enabled = true;
                btnNotesUpd.FlatStyle = FlatStyle.Flat;
                btnNotesDel.FlatStyle = FlatStyle.Flat;

                codigoNotes = Convert.ToInt32(dgvNotes.Rows[sgteNotes].Cells[0].Value);

                txtNotes2.Text = Convert.ToString(dgvNotes.Rows[sgteNotes].Cells[2].Value);
                txtCRequi.Text = Convert.ToString(dgvNotes.Rows[sgteNotes].Cells[3].Value);

                lbRecordRoute.Text = "Record " + (sgteNotes + 1) + " of " + cuentaNotes;
            }
        }

        private void btnClearNotes_Click(object sender, EventArgs e)
        {
            txtNotes2.Text = "";
            txtCRequi.Text = "";

            btnNotesAdd.Enabled = true; 
            btnNotesAdd.FlatStyle = FlatStyle.Flat;
            btnNotesUpd.Enabled = false;
            btnNotesDel.Enabled = false;
            btnNotesUpd.FlatStyle = FlatStyle.Standard;
            btnNotesDel.FlatStyle = FlatStyle.Standard;
        }

        private void btnNotesAdd_Click(object sender, EventArgs e)
        {
            if (!(txtNotes2.Text == "" && txtCRequi.Text == ""))
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into rvnotes (idrevenue, notes, requirements) values ('" + lbLoadIdNotes.Text + "', @note, @requirement)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("note", txtNotes2.Text);
                    cmd.Parameters.AddWithValue("requirement", txtCRequi.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");

                    dgvNotes.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }

                cuentaNotes = dgvNotes.Rows.GetRowCount(0);
                lbRecordNotes.Text = "Record " + (sgteNotes + 1) + " of  " + cuentaNotes;

                btnNotesAdd.Enabled = false;
                btnNotesAdd.FlatStyle = FlatStyle.Standard;
                btnNotesUpd.Enabled = true;
                btnNotesDel.Enabled = true;
                btnNotesUpd.FlatStyle = FlatStyle.Flat;
                btnNotesDel.FlatStyle = FlatStyle.Flat;
            }
        }

        private void btnNotesDel_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoNotes);
                    btnClearNotes_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvNotes.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdNotes.Text);
            }
        }

        private void btnNotesUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update rvnotes set idrevenue='" + lbLoadIdNotes.Text + "', notes=@note, requirements=@requirement " + " where id=" + codigoNotes, conn);
                cmd.Parameters.AddWithValue("note", txtNotes2.Text);
                cmd.Parameters.AddWithValue("requirement", txtCRequi.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");

                dgvNotes.DataSource = conectandose.ConsultarRevenue(TblName, txtLoadId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

        }
        /// <summary>////////////////////////////////
        /// DOCUMENTS
        /// </summary>///////////////////////////////
        /// 


        private void dgvDocuments_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (txtLoadId.Text != "")
            {
                btnAddAttachment.Enabled = false;
                btnUpdAttachment.Enabled = true;
                btnDelAttacment.Enabled = true;
                btnOpen.Enabled = true;

                codigoDocuments = Convert.ToInt32(dgvDocuments.Rows[e.RowIndex].Cells[0].Value);

                txtName.Text = Convert.ToString(dgvDocuments.Rows[e.RowIndex].Cells[5].Value);
                dtAnnotation.Value = Convert.ToDateTime(dgvDocuments.Rows[e.RowIndex].Cells[2].Value);
                txtDescription.Text = Convert.ToString(dgvDocuments.Rows[e.RowIndex].Cells[3].Value);
                axAcroPDF1.src = Convert.ToString(dgvDocuments.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void btnCleanDocuments_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            dtAnnotation.Text = "";
            txtDescription.Text = "";

            string pdfDoc = raiz + @"Documents\Contact_us.pdf";
            if (pdfDoc == raiz + @"Documents\Contact_us.pdf")
            {
                axAcroPDF1.src = pdfDoc;
            }
            initdocument = true;


            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = false;
            btnDelAttacment.Enabled = false;
            btnOpen.Enabled = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "Documents PDF |*.pdf; ";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fd.Title = "Seleccionar Document";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ruta = fd.FileName;
                    axAcroPDF1.src = fd.FileName;
                    btnAddAttachment.Enabled = true;
                    btnUpdAttachment.Enabled = false;
                    btnDelAttacment.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "PerfectFreight PdfViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && dtAnnotation.Value != null)
            {
                //Convirtiendo PDF a binario
                FileStream path = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                byte[] binario = new byte[path.Length];
                path.Read(binario, 0, (int)path.Length);
                path.Close();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into documents (idrevenue,date,description,document,name) values ('" + lbLoadIdDocuments.Text + "','" + dtAnnotation.Value + "','" + txtDescription.Text + "','" + axAcroPDF1.src + "','" + txtName.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Insert successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else MessageBox.Show("Lack data, check that have:\nName, Date", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdDocuments.Text);
            btnAddAttachment.Enabled = false;
            btnUpdAttachment.Enabled = true;
            btnDelAttacment.Enabled = true;
            btnOpen.Enabled = true;
        }

        private void btnDelAttacment_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you Sure want Delete this Record ?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                try
                {
                    conectandose.DeleteRecord(TblName, codigoDocuments);
                    btnCleanDocuments_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdDocuments.Text);
            }
        }

        private void btnUpdAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update documents set idrevenue='" + lbLoadIdDocuments.Text + "',date='" + dtAnnotation.Value + "', description='" + txtDescription.Text + "',name='" + txtName.Text + "',document='" + axAcroPDF1.src + "'" + " where id=" + codigoDocuments, conn);
                //cmd.Parameters.AddWithValue("document", axAcroPDF1.src);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            dgvDocuments.DataSource = conectandose.ConsultarRevenue(TblName, lbLoadIdDocuments.Text);
        }

        //////////////////////////////////////////////////////
        /// INVOICE STATUS
        //////////////////////////////////////////////////////
        ////////
        private void btnOustInvoice_Click(object sender, EventArgs e) //<=60 dias
        {
            string cliente;
            DateTime arrivdate;
            DateTime fecha = DateTime.Now;
            lblStatus.Text = "";
            lblBroker.Visible = false;
            txtMail.Text = "";
            string pay = "False";
            string cadena = "select idrevenue, arrivadate from rvpickupdrops";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            dgvInvoice.Rows.Clear();
            while (dr.Read())
            {
                cliente = dr["idrevenue"].ToString();

                arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                int dias = fecha.Subtract(arrivdate).Days;

                if (dias <= 60)
                {
                    string cadena2 = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues" + " where loadid = '" + cliente + "'" + " and chkfactorydate like '" + pay + "'";
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();
                    if (dr2.Read())
                    {
                        int n = dgvInvoice.Rows.Add();

                        dgvInvoice.Rows[n].Cells[0].Value = dr2["client"].ToString();
                        dgvInvoice.Rows[n].Cells[1].Value = dr2["contact"].ToString();
                        dgvInvoice.Rows[n].Cells[2].Value = dr2["loadid"].ToString();
                        dgvInvoice.Rows[n].Cells[3].Value = dr2["driver"].ToString();
                        dgvInvoice.Rows[n].Cells[4].Value = dr2["truckid"].ToString();
                        dgvInvoice.Rows[n].Cells[5].Value = dr2["trailerid"].ToString();
                        dgvInvoice.Rows[n].Cells[6].Value = dr2["loaddate"].ToString();
                        dgvInvoice.Rows[n].Cells[7].Value = dr2["startcityst"].ToString();
                        dgvInvoice.Rows[n].Cells[8].Value = dr2["enddate"].ToString();
                        dgvInvoice.Rows[n].Cells[9].Value = dr2["endcityst"].ToString();
                        lblStatus.Visible = true;
                        lblStatus.Text = "Outstanding Invoice <= 60 days - Today = " + fecha.ToString("M/d/yyyy H:mm");
                        LoadStatus = lblStatus.Text;
                        conn2.Close();
                    }
                    else conn2.Close();
                }
            }
            if (lblStatus.Text == "")
            {
                MessageBox.Show("Do not exist Customer Oustanding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //conn.Close();
            }
            conn.Close();
        }

        private void btnDueInvoice_Click(object sender, EventArgs e) // >60 y <=90 dias
        {
            string cliente;
            DateTime arrivdate;
            //DateTime fecha = new DateTime(2020, 8, 6);
            DateTime fecha = DateTime.Now;
            lblStatus.Text = "";
            lblBroker.Visible = false;
            txtMail.Text = "";
            string pay = "False";

            string cadena = "select idrevenue, arrivadate from rvpickupdrops"; // where arrivadate >= '" + fecha.ToString() + "'";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            dgvInvoice.Rows.Clear();
            while (dr.Read())
            {
                cliente = dr["idrevenue"].ToString();

                arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                int dias = fecha.Subtract(arrivdate).Days;

                //dgvInvoice.DataSource = conectandose.ConsultarInvoice("rvpickupdrops", fecha);

                if (dias > 60 && dias <= 90) //&& arrivdate90 <= fecha
                {
                    string cadena2 = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues" + " where loadid = '" + cliente + "'" + " and chkfactorydate like '" + pay + "'";
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();
                    if (dr2.Read())
                    {
                        int n = dgvInvoice.Rows.Add();

                        dgvInvoice.Rows[n].Cells[0].Value = dr2["client"].ToString();
                        dgvInvoice.Rows[n].Cells[1].Value = dr2["contact"].ToString();
                        dgvInvoice.Rows[n].Cells[2].Value = dr2["loadid"].ToString();
                        dgvInvoice.Rows[n].Cells[3].Value = dr2["driver"].ToString();
                        dgvInvoice.Rows[n].Cells[4].Value = dr2["truckid"].ToString();
                        dgvInvoice.Rows[n].Cells[5].Value = dr2["trailerid"].ToString();
                        dgvInvoice.Rows[n].Cells[6].Value = dr2["loaddate"].ToString();
                        dgvInvoice.Rows[n].Cells[7].Value = dr2["startcityst"].ToString();
                        dgvInvoice.Rows[n].Cells[8].Value = dr2["enddate"].ToString();
                        dgvInvoice.Rows[n].Cells[9].Value = dr2["endcityst"].ToString();
                        lblStatus.Visible = true;
                        lblStatus.Text = "Due Invoice > 60 & <=90 days - Today = " + fecha.ToString("M/d/yyyy H:mm");
                        LoadStatus = lblStatus.Text;
                        conn2.Close();
                    }
                    else conn2.Close();
                }
            }
            if (lblStatus.Text == "")
            {
                MessageBox.Show("Do not exist Customer Due Invoice", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //conn.Close();
            }
            conn.Close();
        }

        private void btnPastInvoice_Click(object sender, EventArgs e) // >90 dias
        {
            string cliente;
            DateTime arrivdate;
            //DateTime fecha = new DateTime(2020, 12, 26);
            DateTime fecha = DateTime.Now;
            lblStatus.Text = "";
            lblBroker.Visible = false;
            txtMail.Text = "";
            string pay = "False";

            string cadena = "select idrevenue, arrivadate from rvpickupdrops"; // where arrivadate >= '" + fecha.ToString() + "'";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            dgvInvoice.Rows.Clear();
            while (dr.Read())
            {
                cliente = dr["idrevenue"].ToString();

                arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                int dias = fecha.Subtract(arrivdate).Days;

                //dgvInvoice.DataSource = conectandose.ConsultarInvoice("rvpickupdrops", fecha);

                if (dias > 90) //&& arrivdate90 <= fecha
                {
                    string cadena2 = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues" + " where loadid = '" + cliente + "'" + " and chkfactorydate like '" + pay + "'";
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();
                    if (dr2.Read())
                    {
                        int n = dgvInvoice.Rows.Add();

                        dgvInvoice.Rows[n].Cells[0].Value = dr2["client"].ToString();
                        dgvInvoice.Rows[n].Cells[1].Value = dr2["contact"].ToString();
                        dgvInvoice.Rows[n].Cells[2].Value = dr2["loadid"].ToString();
                        dgvInvoice.Rows[n].Cells[3].Value = dr2["driver"].ToString();
                        dgvInvoice.Rows[n].Cells[4].Value = dr2["truckid"].ToString();
                        dgvInvoice.Rows[n].Cells[5].Value = dr2["trailerid"].ToString();
                        dgvInvoice.Rows[n].Cells[6].Value = dr2["loaddate"].ToString();
                        dgvInvoice.Rows[n].Cells[7].Value = dr2["startcityst"].ToString();
                        dgvInvoice.Rows[n].Cells[8].Value = dr2["enddate"].ToString();
                        dgvInvoice.Rows[n].Cells[9].Value = dr2["endcityst"].ToString();
                        lblStatus.Visible = true;
                        lblStatus.Text = "Past Due Invoice > 90 days - Today = " + fecha.ToString("M/d/yyyy H:mm");
                        LoadStatus = lblStatus.Text;
                        conn2.Close();
                    }
                    else conn2.Close();
                }
            }
            if (lblStatus.Text == "")
            {
                MessageBox.Show("Do not exist Customer Due Invoice","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                //conn.Close();
            }
            conn.Close();
        }

        private void btnPaidInvoices_Click(object sender, EventArgs e)
        {
            String pay = "True";
            DateTime fecha = DateTime.Now;
            lblStatus.Text = "";
            lblBroker.Visible = false;
            txtMail.Text = "";

            string cadena2 = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues" + " where chkfactorydate like  '" + pay + "'";
            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            dgvInvoice.Rows.Clear();
            while (dr2.Read())
            {
                int n = dgvInvoice.Rows.Add();

                dgvInvoice.Rows[n].Cells[0].Value = dr2["client"].ToString();
                dgvInvoice.Rows[n].Cells[1].Value = dr2["contact"].ToString();
                dgvInvoice.Rows[n].Cells[2].Value = dr2["loadid"].ToString();
                dgvInvoice.Rows[n].Cells[3].Value = dr2["driver"].ToString();
                dgvInvoice.Rows[n].Cells[4].Value = dr2["truckid"].ToString();
                dgvInvoice.Rows[n].Cells[5].Value = dr2["trailerid"].ToString();
                dgvInvoice.Rows[n].Cells[6].Value = dr2["loaddate"].ToString();
                dgvInvoice.Rows[n].Cells[7].Value = dr2["startcityst"].ToString();
                dgvInvoice.Rows[n].Cells[8].Value = dr2["enddate"].ToString();
                dgvInvoice.Rows[n].Cells[9].Value = dr2["endcityst"].ToString();
                dgvInvoice.Rows[n].Cells[10].Value = dr2["totaltrippay"].ToString();
                lblStatus.Visible = true;
                lblStatus.Text = "Paid Invoice since --------- Today = " + fecha.ToString("M/d/yyyy H:mm");
                LoadStatus = lblStatus.Text;

            }
            if (lblStatus.Text == "")
            {
                MessageBox.Show("Do not exist Paid Invoice", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //conn.Close();
            }
            conn2.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                //int cantidad = 0;

                PrintDocument doc = new PrintDocument();
                //doc.DefaultPageSettings.Landscape = true;
                //doc.PrinterSettings.PrinterName = "Adobe PDF";

                PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
                ((Form)ppd).WindowState = FormWindowState.Maximized;

                int y = 20;
                string img = route + @"logopf.png";


                doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
                {
                    ep.HasMorePages = false;

                    int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top + 50, right = ep.MarginBounds.Right;
                    int currentHeight = 0;
                    Font font = new Font("Segoe UI", 13);
                    Image image = Image.FromFile(img);
                    ep.Graphics.DrawImage(image, new System.Drawing.Rectangle(left, y += 20, 128, 128));
                    int centro = (right - left) / 2;
                    ep.Graphics.DrawString("Perfectr Freight Inc.", new Font("Segoe UI", 18, FontStyle.Bold), Brushes.DarkBlue, centro, top - 50);
                    //left = ep.MarginBounds.Left;
                    ep.Graphics.DrawString("( " + lblStatus.Text + " )", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.DarkBlue, centro - LoadStatus.Length, top - 20);
                    const int dgv_alto = 35;
                    left = ep.MarginBounds.Left;
                    ep.Graphics.DrawString("Broker: " + dgvInvoice.Rows[0].Cells[0].Value.ToString(), new Font("Segoe UI", 16, FontStyle.Bold), Brushes.DarkBlue, left, top += 20);
                    ep.Graphics.DrawString("eMail: " + correo, font, Brushes.DarkBlue, left, top += 25);
                    left = ep.MarginBounds.Left;// restituyendo el margen izquierdo
                    ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);// poniendo una linea de 3 mm de grueso
                    top += 43;//actualizando al top los 3 mm de grueso de la linea anterior


                    ep.Graphics.DrawString("Contact: " + dgvInvoice.Rows[index].Cells[1].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Load Id: " + dgvInvoice.Rows[index].Cells[2].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Driver: " + dgvInvoice.Rows[index].Cells[3].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Truck Id: " + dgvInvoice.Rows[index].Cells[4].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Trailer ID: " + dgvInvoice.Rows[index].Cells[5].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Load Date: " + dgvInvoice.Rows[index].Cells[6].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("Start City, St: " + dgvInvoice.Rows[index].Cells[7].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("End Date: " + dgvInvoice.Rows[index].Cells[8].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;
                    ep.Graphics.DrawString("End City, St: " + dgvInvoice.Rows[index].Cells[9].Value.ToString(), font, Brushes.Black, left, top + 4);
                    top += dgv_alto;


                    ep.Graphics.FillRectangle(Brushes.Black, right - 160, top + 40, 210, 3);// poniendo una linea de 3 mm de grueso
                    top += dgv_alto;
                    //ep.Graphics.DrawString("Total Revenue: " + dgvInvoice.Rows[index].Cells[10].Value.ToString(), font, Brushes.DarkBlue, right - 150, top + 8);
                    //top += dgv_alto;
                    ep.Graphics.FillRectangle(Brushes.Black, right - 160, top + 8, 210, 3);// poniendo una linea de 3 mm de grueso
                    currentHeight += font.Height + top + 3;
                    //if (currentHeight >= ep.PageBounds.Height - 250)
                    //{
                    //    ep.HasMorePages = true;
                    //}
                    //doc = new PrintDocument();
                    index = -1;
                };
                ppd.ShowDialog();
            }
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cliente;

            cliente = Convert.ToString(dgvInvoice.Rows[e.RowIndex].Cells[0].Value);
            index = e.RowIndex;

            string query = "select name,email from brokers" + " where name like  '" + cliente + "'";
            conn2.Open();
            NpgsqlCommand comando2 = new NpgsqlCommand(query, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();

            if (dr2.Read())
            {
                lblBroker.Visible = true;
                lblBroker.Text = dr2["name"].ToString();
                lblAgent.Visible = true;
                lblAgent.Text = Convert.ToString(dgvInvoice.Rows[e.RowIndex].Cells[1].Value).ToString();
                if (dr2["email"].ToString() == "")
                    txtMail.Text = "This Broker don't have eMail";
                else txtMail.Text = dr2["email"].ToString();
            }
            conn2.Close();
        }

        private void btnClearInvoice_Click(object sender, EventArgs e)
        {
            dgvInvoice.Rows.Clear();
            lblBroker.Text = "";
            txtMail.Text = "";
            lblStatus.Visible = false;
            lblStatus.Text = "";
        }

        private void btnPDF_Click_1(object sender, EventArgs e)
        {
            frmPrintPdf imprimir = new frmPrintPdf();
            imprimir.Show();
        }

        private void btnReportsRevenue_Click(object sender, EventArgs e)
        { 
            frmReportsRevenue reportsRevenue = new frmReportsRevenue();
            reportsRevenue.Show();
        }

        /// <summary>////////////////////////////////
        /// GENERALES
        /// </summary>///////////////////////////////
        /////
        private void btnSearchShipper_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("rvpickupdrops","");
            search.ShowDialog();
            //txtShipperReceive.Text = search.Shipper;
        }
        private void btnSearchDriver_MouseHover(object sender, EventArgs e)
        {
            lblDriver.Visible = true;
        }

        private void btnSearchDriver_MouseLeave(object sender, EventArgs e)
        {
            lblDriver.Visible = false;
        }

        private void btnSearchTruck_MouseHover(object sender, EventArgs e)
        {
            lblTruck.Visible = true;
        }

        private void btnSearchTruck_MouseLeave(object sender, EventArgs e)
        {
            lblTruck.Visible = false;
        }

        private void btnSearchTrailer_MouseHover(object sender, EventArgs e)
        {
            lblTrailer.Visible = true;
        }

        private void btnSearchTrailer_MouseLeave(object sender, EventArgs e)
        {
            lblTrailer.Visible = false;
        }

        private void btnSearchDead_MouseHover(object sender, EventArgs e)
        {
            lblDeadHead.Visible = true;
        }

        private void btnSearchDead_MouseLeave(object sender, EventArgs e)
        {
            lblDeadHead.Visible = false;
        }

        private void btnSearchStartCS_MouseHover(object sender, EventArgs e)
        {
            lblStartCity.Visible = true;
        }

        private void btnSearchStartCS_MouseLeave(object sender, EventArgs e)
        {
            lblStartCity.Visible = false;
        }

        private void btnSearchEndCS_MouseHover(object sender, EventArgs e)
        {
            lblEndCity.Visible = true;
        }

        private void btnSearchEndCS_MouseLeave(object sender, EventArgs e)
        {
            lblEndCity.Visible = false;
        }

        private void btnSearchShipper_MouseHover(object sender, EventArgs e)
        {
            //lblShipper.Visible = true;
        }

        private void btnSearchShipper_MouseLeave(object sender, EventArgs e)
        {
            //lblShipper.Visible = false;
        }

        private void btnFuelCS_MouseHover(object sender, EventArgs e)
        {
            lbFuelState.Visible = true;
        }

        private void btnFuelCS_MouseLeave(object sender, EventArgs e)
        {
            lbFuelState.Visible = false;
        }

        private void txtDeadHeadMiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtDeadHeadMiles.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLoadMiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtLoadMiles.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPersonalMiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPersonalMiles.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFlatRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtFlatRate.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTotalOther_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtTotalOther.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSeal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtWeight.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTruck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtTruck.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPiece_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPiece.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTrailer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtTrailer.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtChassis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtChassis.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLastEmptyOdom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtLastEmptyOdom.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtLoadOdom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtLoadOdom.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEndOdom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtEndOdom.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPDProNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //else if ((e.KeyChar == '.') && (!txtPDProNumber.Text.Contains(".")))
            //{
            //    e.Handled = false;
            //}
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPDOdometer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //else if ((e.KeyChar == '.') && (!txtPDOdometer.Text.Contains(".")))
            //{
            //    e.Handled = false;
            //}
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPDTotalTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPDTotalTime.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only number, please", "Information!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPersonalMiles_Leave(object sender, EventArgs e)
        {
            double a1, a2, a3, r1;
            a1 = Double.Parse(txtDeadHeadMiles.Text);
            a2 = Double.Parse(txtLoadMiles.Text);
            a3 = Double.Parse(txtPersonalMiles.Text);
            r1 = a1 + a2 + a3;
            txtTotalMiles.Text = r1.ToString();
        }

        private void mtbDriverPay_Leave(object sender, EventArgs e)
        {

        }

        private void txtDeadHeadMiles_Leave(object sender, EventArgs e)
        {
            double a1, a2, a3, r1;
            a1 = Convert.ToDouble(txtDeadHeadMiles.Text);
            a2 = Convert.ToDouble(txtLoadMiles.Text);
            a3 = Convert.ToDouble(txtPersonalMiles.Text);
            r1 = a1 + a2 + a3;
            txtTotalMiles.Text = r1.ToString();
        }

        private void txtTripPayAmmount_Leave(object sender, EventArgs e)
        {
            float a1, a2, a3, a4, r1;
            if (txtTripPayAmmount.Text != "") a3 = (float)Convert.ToDouble(txtTripPayAmmount.Text);
            else a3 = 0;
            //txtTotalOther.Text = (a3.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
            if (txtTotalMiles.Text != "") a2 = (float)Convert.ToDouble(txtTotalMiles.Text);
            else a2 = 0;
            //if (txtTotalOther.Text != "") a4 = Convert.ToDouble(txtTotalOther.Text);
            //else a4 = 0;
            txtTotalTrip.Text = a3.ToString();
            //txtTotalTripBasic.Text = (a3 + a4).ToString();
            //a1 = a3 + a4;
            if (a2 != 0.0) r1 = a3 / a2;
            else r1 = 0.0f;
            txtFlatRate.Text = r1.ToString();
        }

        private void txtLoadMiles_Leave(object sender, EventArgs e)
        {
            double a1, a2, a3, r1;
            a1 = Convert.ToDouble(txtDeadHeadMiles.Text);
            a2 = Convert.ToDouble(txtLoadMiles.Text);
            a3 = Convert.ToDouble(txtPersonalMiles.Text);
            r1 = a1 + a2 + a3;
            txtTotalMiles.Text = r1.ToString();
        }

        private void txtBrocker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtDepartDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dtFuelDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtExpensesDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtState2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void mtbExpenses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnOustInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }



        private void btnDriverPay_Click(object sender, EventArgs e)
        { 
            frmDriverPay driverPay = new frmDriverPay();
            driverPay.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategorys frmCategorys = new frmCategorys();
            frmCategorys.ShowDialog();
            if (frmCategorys.Mensaje)
                RefreshCategorys();
        }
        private void RefreshCategorys()
        {
            string cadena = "select category from categories order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbTripPayCategory.Items.Add(dr["category"].ToString());
            }
            conn.Close();
        }

        private void btnAddCD_Click(object sender, EventArgs e)
        {
            if (recordCount + contador <= 8) //contador
            {
                string cadena = "select category from categories order by id";

                boton[contador] = new Button();
                boton[contador].Name = "btnnuevo" + contador.ToString();
                //boton[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton[contador].Size = new Size(25, 25);
                boton[contador].Text = "X";
                y += 27;
                boton[contador].Location = new Point(260, y);
                boton[contador].Click += boton_Click;
                //EnsureSchemaOperation
                groupBox8.Controls.Add(boton[contador]);

                combo[contador] = new ComboBox();
                combo[contador].Name = "cbnuevo" + contador.ToString();
                combo[contador].Text = "Select Category";
                //combo[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                combo[contador].Size = new Size(235, 23);
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    combo[contador].Items.Add(dr["category"].ToString());
                }
                conn.Close();
                combo[contador].Location = new Point(288, y);
                groupBox8.Controls.Add(combo[contador]);

                texto[contador] = new TextBox();
                texto[contador].Name = "txtnuevo" + contador.ToString();
                texto[contador].Text = "0";
                //texto[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                texto[contador].Size = new Size(126, 23);
                texto[contador].Location = new Point(556, y);
                texto[contador].TextAlign = HorizontalAlignment.Right;
                texto[contador].KeyPress += texto_keyPress;
                texto[contador].Leave += texto_Leave;
                groupBox8.Controls.Add(texto[contador]);
                alertaCD = true;
                contador += 1;

            }
        }

        private void texto_Leave(object sender, EventArgs e)
        {
            double a1, a2, a3, a4, r1;
            //if (txtTripPayAmmount.Text != "") a3 = Convert.ToDouble(txtTripPayAmmount.Text);
            //else a3 = 0.0;
            //if (txtTotalTrip.Text != "") a1 = Convert.ToDouble(txtTotalTrip.Text);
            //else a1 = 0.0;
            //if (txtTotalMiles.Text != "") a2 = Convert.ToDouble(txtTotalMiles.Text);
            //else a2 = 0.0;
            a4 = Convert.ToDouble(txtTotalOther.Text);
            //if (a2 != 0.0) r1 = a1 / a2;
            //else r1 = 0.0;
            //txtFlatRate.Text = r1.ToString();
            a4 = a4 + Convert.ToDouble(texto[1].Text);
            txtTotalOther.Text = a4.ToString();
            //txtTotalTrip.Text = (a3 + a4).ToString();
            CategoryPayAdd(combo[1].Text, texto[1].Text);
            btnTripUpd_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("driverprofiles", "");
            search.ShowDialog();
            txtPDDriver.Text = search.Nombre;
        }

        private void txtSearchLoad_TextChanged(object sender, EventArgs e)
        {
            btnTripAdd.Enabled = false;
            btnTripUpd.Enabled = true;
            btnTripDel.Enabled = true;
            string search = (txtSearchLoad.Text).ToUpper();
            if (txtSearchLoad.Text != "")
            {
                LimpiaCategory();
                dgvTripInfo.DataSource = conectandose.ConsultarInvoice(TblName, search);
                sgte = 0;
                cuenta = dgvTripInfo.Rows.GetRowCount(0);
                if (cuenta != 0)
                    rellena();
            }
            else
            {
                dgvTripInfo.DataSource = conectandose.Consultar(TblName);
                cuenta = dgvTripInfo.Rows.GetLastRow(0);
            }
        }

        private void cbBrockers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbBrockers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = conectandose.ConsultarWith("brokers", cbBrockers.Text);
            nameBroker = Convert.ToString(dgvSearch.Rows[0].Cells[1].Value);
            dgvAgents.DataSource = conectandose.ConsultarAgents("agents", nameBroker);
            int cuantos= dgvAgents.Rows.GetRowCount(0);
            int sgteagent = 0;
            //Lleno el COmboBox
            cbContactName.Items.Clear();
            while (cuantos > 0)
            {
                cbContactName.Items.Add(Convert.ToString(dgvAgents.Rows[sgteagent].Cells[1].Value).ToString());
                cuantos--;
                sgteagent++;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoadId_Leave(object sender, EventArgs e)
        {
            txtLoadId.Text = (txtLoadId.Text).ToUpper();
        }
        
        private void btnDispacht_Click(object sender, EventArgs e)
        {
            dgvNotes.DataSource = conectandose.ConsultarRevenue("rvnotes", txtLoadId.Text);
            int cto= dgvNotes.Rows.GetRowCount(0);
            if (cto <= 0)
            {
                MessageBox.Show("Lack data, check that have:\r\nCustomer Requirements in Notes", "Lack Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmDispatch dispatch = new frmDispatch(txtDriver.Text, idDriver, txtLoadId.Text, cbLoadType.Text);
                dispatch.Show();
            }
        }

        private void btnPDSearchShipper_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("clients", "");
            search.ShowDialog();
            txtPDShipper.Text = search.Nombre;
        }

        private void dtPDPickupAppoinment_Leave(object sender, EventArgs e)
        {

        }

        private void txtPDSealShipper_Leave(object sender, EventArgs e)
        {
            txtPDSealShipper.Text = (txtPDSealShipper.Text).ToUpper();
        }

        private void txtPDPickupNumber_Leave(object sender, EventArgs e)
        {
            txtPDPickupNumber.Text = (txtPDPickupNumber.Text).ToUpper();
        }

        private void txtPDSealReceiver_Leave(object sender, EventArgs e)
        {
            txtPDSealReceiver.Text = (txtPDSealReceiver.Text).ToUpper();
        }

        private void txtPDDeliveryNumber_Leave(object sender, EventArgs e)
        {
            txtPDDeliveryNumber.Text = (txtPDDeliveryNumber.Text).ToUpper();
        }

        private void txtPDDriver_Leave(object sender, EventArgs e)
        {
            txtPDDriver.Text = (txtPDDriver.Text).ToUpper();
        }

        private void btnRVType_Click(object sender, EventArgs e)
        {
            frmRVType loadtype = new frmRVType();
            loadtype.ShowDialog();
            RefreshRVType();


        }
        private void RefreshRVType()
        {
            cbLoadType.Items.Clear();
            string cadena = "select type from loadtypes order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbLoadType.Items.Add(dr["type"].ToString());
            }
            conn.Close();
        }
        private void btnRVType_MouseHover(object sender, EventArgs e)
        {
            lblLoad.Visible = true;
        }

        private void btnRVType_MouseLeave(object sender, EventArgs e)
        {
            lblLoad.Visible = false;
        }

        private void btnPDSearchShipper_MouseHover(object sender, EventArgs e)
        {
            lblPDShipper.Visible = true;
        }

        private void btnPDSearchShipper_MouseLeave(object sender, EventArgs e)
        {
            lblPDShipper.Visible = false;
        }

        private void btnPDType_MouseHover(object sender, EventArgs e)
        {
            lblPDType.Visible = true;
        }

        private void btnPDType_MouseLeave(object sender, EventArgs e)
        {
            lblPDType.Visible = false;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            lblPDDriver.Visible = true;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            lblPDDriver.Visible = false;
        }

        private void btnCategory_MouseHover(object sender, EventArgs e)
        {
            lblCategory.Visible = true;
        }

        private void btnCategory_MouseLeave(object sender, EventArgs e)
        {
            lblCategory.Visible = false;
        }

        private void btnAddCD_MouseHover(object sender, EventArgs e)
        {
            lblAddCategory.Visible = true;
        }

        private void btnAddCD_MouseLeave(object sender, EventArgs e)
        {
            lblAddCategory.Visible = false;
        }

        private void cbPDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbPDType.Text == "Drop")
            {
                txtPDReceiver.Enabled = true;
                dtArrivaDate.Enabled = true;
                txtPDEndCS.Enabled = true;
                txtPDSealReceiver.Enabled = true;
                txtPDTotalTime.Enabled = true;
                txtPDDeliveryNumber.Enabled = true;
                txtAPDeliveryNumber.Enabled = true;
                dtPDReceiverAppoinment.Enabled = true;

                txtPDShipper.Enabled = false;
                dtStartDate.Enabled = false;
                txtPDStarCS.Enabled = false;
                txtPDSealShipper.Enabled = false;
                txtPDPickupTime.Enabled = false;
                txtPDPickupNumber.Enabled = false;
                txtAPPickupNumber.Enabled = false;
                dtPDPickupAppoinment.Enabled = false;

                txtPDReceiver.Focus();
            }
            else
            {
                txtPDReceiver.Enabled = false;
                dtArrivaDate.Enabled = false;
                txtPDEndCS.Enabled = false;
                txtPDSealReceiver.Enabled = false;
                txtPDTotalTime.Enabled = false;
                txtPDDeliveryNumber.Enabled = false;
                txtAPDeliveryNumber.Enabled = false;
                dtPDReceiverAppoinment.Enabled = false;

                txtPDShipper.Enabled = true;
                dtStartDate.Enabled = true;
                txtPDStarCS.Enabled = true;
                txtPDSealShipper.Enabled = true;
                txtPDPickupTime.Enabled = true;
                txtPDPickupNumber.Enabled = true;
                txtAPPickupNumber.Enabled = true;
                dtPDPickupAppoinment.Enabled = true;

                txtPDShipper.Focus();
            }
        }

        private void txtAPPickupNumber_Leave(object sender, EventArgs e)
        {
            txtAPPickupNumber.Text = (txtAPPickupNumber.Text).ToUpper();
        }

        private void txtAPDeliveryNumber_Leave(object sender, EventArgs e)
        {
            txtAPDeliveryNumber.Text = (txtAPDeliveryNumber.Text).ToUpper();
        }

        private void btnAgents_Click(object sender, EventArgs e)
        {
            frmCatalogClient frmclient = new frmCatalogClient();
            frmclient.ShowDialog();
            if (frmclient.Mensaje)
                RefreshAgents();
            
        }
        private void RefreshAgents()
        {
            dgvAgents.DataSource = conectandose.ConsultarAgents("agents", nameBroker);
            int cuantos = dgvAgents.Rows.GetRowCount(0);
            int sgteagent = 0;
            //Lleno el COmboBox
            cbContactName.Items.Clear();
            while (cuantos > 0)
            {
                cbContactName.Items.Add(Convert.ToString(dgvAgents.Rows[sgteagent].Cells[1].Value).ToString());
                cuantos--;
                sgteagent++;
            }
        }

        private void btnAgents_MouseHover(object sender, EventArgs e)
        {
            lblContact.Visible = true;
        }

        private void btnAgents_MouseLeave(object sender, EventArgs e)
        {
            lblContact.Visible = true;
        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void txtCost_Leave(object sender, EventArgs e)
        {
            float cantidad = 0.0f, costo = 0.0f;
            cantidad = (float)Convert.ToDouble(txtQuantity.Text);
            costo = (float)Convert.ToDouble(txtCost.Text);
            txtTotal.Text = (cantidad * costo).ToString();
        }

        private void txtDEFCost_Leave(object sender, EventArgs e)
        {
            float cantidad = 0.0f, costo = 0.0f, defCant = 0.0f, defCost = 0.0f;
            cantidad = (float)Convert.ToDouble(txtQuantity.Text);
            costo = (float)Convert.ToDouble(txtCost.Text);
            defCant = (float)Convert.ToDouble(txtDEF.Text);
            defCost = (float)Convert.ToDouble(txtDEFCost.Text);
            txtTotal.Text = ((cantidad * costo) + (defCant * defCost)).ToString();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("vendors", "");
            search.ShowDialog();
            txtVendor.Text = search.Nombre;
        }

        private void CategoryPayAdd(string zcategory, string zammount)
        {
            try
            {
                NpgsqlCommand cmd3 = new NpgsqlCommand("insert into paycategories (idrevenue,category,ammount,loadstatus) values ('" + txtLoadId.Text + "','" + zcategory + "','" + zammount + "',@loadstatus)", conn);
                cmd3.Parameters.AddWithValue("loadstatus", LoadStatus);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Guarded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void texto_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void ControlesDinamicos()
        {
            int position = 0;
            string query = "select * from paycategories where idrevenue like '%" + txtLoadId.Text + "%' order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                string cadena = "select category from categories order by id";

                //codigoPay = Convert.ToInt32(dgvPayCategories.Rows[recordCount - 1].Cells[0].Value);

                combo2[position] = new ComboBox();
                combo2[position].Name = "cbnuevo" + recordCount.ToString();
                combo2[position].Text = dr["category"].ToString();
                yCount += 27;
                y += 27;
                //combo[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                combo2[position].Size = new Size(235, 23);
                conn2.Open();
                NpgsqlCommand comando2 = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr2 = comando2.ExecuteReader();

                while (dr2.Read())
                {
                    combo2[position].Items.Add(dr2["category"].ToString());
                }
                conn2.Close();
                combo2[position].Location = new Point(288, yCount);
                groupBox8.Controls.Add(combo2[position]);

                texto2[position] = new TextBox();
                texto2[position].Name = "txtnuevo" + position.ToString();
                texto2[position].Text = dr["ammount"].ToString();
                //texto[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                texto2[position].Size = new Size(126, 23);
                texto2[position].Location = new Point(556, yCount);
                texto2[position].TextAlign = HorizontalAlignment.Right;
                texto2[position].KeyPress += texto2_keyPress;
                texto2[position].Leave += texto2_Leave;
                groupBox8.Controls.Add(texto2[position]);

                boton2[position] = new Button();
                boton2[position].Name = "btnnuevo" + position.ToString();
                //boton[ctdad].Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton2[position].Size = new Size(25, 25);
                //string img = @"C:\Users\Rene\VisualStudioProjects\PerfectFreightManager\PerfectFreightManager\bin\Debug\Iconos\icons8_delete_database_16.png";
                boton2[position].Text = "D";
                boton2[position].Location = new Point(684, yCount);
                boton2[position].Click += boton2_Click;
                //EnsureSchemaOperation
                groupBox8.Controls.Add(boton2[position]);
                positionPC[position] = Convert.ToString(yCount);
                valorPC[position] = dr["ammount"].ToString();
                position += 1;
                recordCount += 1;
            }
            conn.Close();
        }

        private void cbPDType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPDCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPDSearchReceiver_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("clients","");
            search.ShowDialog();
            txtPDReceiver.Text = search.Nombre;
        }

        private void btnPDSearchCustomer_MouseHover(object sender, EventArgs e)
        {
            lbPDReceiver.Visible = true;
        }

        private void btnPDSearchCustomer_MouseLeave(object sender, EventArgs e)
        {
            lbPDReceiver.Visible = false;
        }

        private void btnPDType_Click(object sender, EventArgs e)
        { 
            frmPDType frmType = new frmPDType();
            frmType.ShowDialog();
            if (frmType.Mensaje)
                Refresh();
        }
        private void Refresh()
        {
            cbPDType.Items.Clear();
            string cadena = "select type from pickupdroptypes order by id";
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                cbPDType.Items.Add(dr["type"].ToString());
            }
            conn.Close();
        }
        
        private void btnTripFirst_MouseHover(object sender, EventArgs e)
        {
            lbPosition.Location = new Point(294, 41);
            lbPosition.Text = "First Record";
            lbPosition.Visible = true;
        }

        private void btnTripFirst_MouseLeave(object sender, EventArgs e)
        {
            lbPosition.Visible = false;
        }

        private void btnTripPrevios_MouseHover(object sender, EventArgs e)
        {
            lbPosition.Location = new Point(328, 41);
            lbPosition.Text = "Previous Record";
            lbPosition.Visible = true;
        }

        private void btnTripNext_MouseHover(object sender, EventArgs e)
        {
            lbPosition.Location = new Point(362, 41);
            lbPosition.Text = "Right Record";
            lbPosition.Visible = true;
        }

        private void btnTripEnd_MouseHover(object sender, EventArgs e)
        {
            lbPosition.Location = new Point(396, 41);
            lbPosition.Text = "Last Record";
            lbPosition.Visible = true;
        }

        private void boton2_Click(object sender, EventArgs e) //Delete de PayCategory
        {
            float a4, a5;
            int pos = 64;
            for (int i = 0; i < recordCount - 1; i++)
            {
                if (positionPC[i] == Convert.ToString(pos) && valorPC[i] == texto2[i].Text)
                {
                    DialogResult dialog = MessageBox.Show("Categoria = " + combo2[i].Text + "\nImporte = " + texto2[i].Text, "Selection Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        DialogResult dialog2 = MessageBox.Show("Are you Sure want Delete this Record?", "Warning Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog2 == DialogResult.Yes)
                        {
                            try
                            {
                                string cadena = "select id, idrevenue, category, ammount from paycategories where ammount like '" + texto2[i].Text + "' and  category like '" + combo2[i].Text + "' and idrevenue like '" + txtLoadId.Text + "'";

                                conn2.Open();
                                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn2);
                                NpgsqlDataReader dr = comando.ExecuteReader();

                                while (dr.Read())
                                {
                                    codigoPay = Convert.ToInt32(dr["id"]);
                                    MessageBox.Show("This is Record to Delete = " + codigoPay);
                                    a4 = (float)Convert.ToDouble(texto2[i].Text);
                                    conectandose.DeleteRecord("paycategories", codigoPay);
                                    //Actualizando los valores del Trip
                                    //a3 = Convert.ToDouble(txtTotalTrip.Text);
                                    a5 = (float)Convert.ToDouble(txtTotalOther.Text);
                                    a5 = a5 - a4;
                                    txtTotalOther.Text = a5.ToString();
                                    //txtTotalTrip.Text = (a3 - a4).ToString();
                                    //a1 = Convert.ToDouble(txtTotalTrip.Text);
                                    //a2 = Convert.ToDouble(txtTotalMiles.Text);
                                    //if (a2 != 0.0) r1 = a1 / a2;
                                    //else r1 = 0.0;
                                    //txtFlatRate.Text = r1.ToString();
                                    groupBox8.Controls.Remove(boton2[i]);
                                    groupBox8.Controls.Remove(combo2[i]);
                                    groupBox8.Controls.Remove(texto2[i]);
                                    btnTripUpd_Click(sender, e);
                                    break;
                                }
                                conn2.Close();
                                break;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                conn2.Close();
                            }
                            //dgvTripInfo.DataSource = conectandose.Consultar(TblName);
                            //dgvPayCategories.DataSource = conectandose.Consultar("paycategories");
                        }
                    }

                    if (dialog == DialogResult.No)
                        pos += 27;
                }
            }
        }

        private void texto2_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                    SendKeys.Send("{TAB}");
            }
        }

        private void texto2_Leave(object sender, EventArgs e)
        {
            float a4=0.0f;
            int j = 0;
            
            try
            {
                string cadena = "select id, idrevenue, category, ammount from paycategories where idrevenue like '" + txtLoadId.Text + "' order by id";
                conn2.Open();
                NpgsqlCommand comando2 = new NpgsqlCommand(cadena, conn2);
                NpgsqlDataReader dr = comando2.ExecuteReader();
                
                while (dr.Read())
                {
                    codigoPay = Convert.ToInt32(dr["id"].ToString());
                    a4 = a4 + (float)Convert.ToDouble(texto2[j].Text); //Valor de los Paycategory
                    CategoryPayUpd(combo2[j].Text, texto2[j].Text);
                    j++;
                }
                txtTotalOther.Text = a4.ToString();
                //a3 = Convert.ToDouble(txtTripPayAmmount.Text);
                //txtTotalTrip.Text = (a3 + a4).ToString();
                //if(txtTotalTrip.Text!="") a1 = Convert.ToDouble(txtTotalTrip.Text);
                //else a1 = 0.0;
                //if (txtTotalMiles.Text != "") a2 = Convert.ToDouble(txtTotalMiles.Text);
                //else a2 = 0.0;
                //if (a2 != 0.0) r1 = a1 / a2;
                //else r1 = 0.0;
                //txtFlatRate.Text = r1.ToString();
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Modify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn2.Close();
            }
            btnTripUpd_Click(sender, e);
        }

        private void boton_Click(object sender, EventArgs e)
        {
            //if (!initcategory) RemoveControlDinamico(contador);
            contador -= 1;
            y -= 27;
            groupBox8.Controls.Remove(boton[contador]);
            groupBox8.Controls.Remove(combo[contador]);
            groupBox8.Controls.Remove(texto[contador]);
        }

        private void RemoveControlDinamico(int valor)
        {
            valor = 1;
            y -= 27;
            groupBox8.Controls.Remove(boton[valor]);
            groupBox8.Controls.Remove(combo[valor]);
            groupBox8.Controls.Remove(texto[valor]);
        }

        private void txtLoadOdom_Leave(object sender, EventArgs e)
        {
            double a1, a2, r1;
            if (txtLastEmptyOdom.Text == "") txtLastEmptyOdom.Text = "0";
            a1 = Convert.ToInt32(txtLastEmptyOdom.Text);
            if (txtLoadOdom.Text == "") txtLoadOdom.Text = "0";
            a2 = Convert.ToInt32(txtLoadOdom.Text);
            r1 = a2 - a1;
            if (a1 == 0.0) txtDeadHeadMiles.Text = "0";
            else txtDeadHeadMiles.Text = r1.ToString();


        }

        private void txtEndOdom_Leave(object sender, EventArgs e)
        {
            double a1, a2, r1;
            if (txtLoadOdom.Text == "") txtLoadOdom.Text = "0";
            a1 = Convert.ToInt32(txtLoadOdom.Text);
            if (txtEndOdom.Text == "" || txtEndOdom.Text == "0")
            {
                txtEndOdom.Text = "0";
                a2 = Convert.ToInt32(txtEndOdom.Text);
                r1 = a1 - a2;
                txtLoadMiles.Text = "0";
            }
            else
            {
                a2 = Convert.ToInt32(txtEndOdom.Text);
                r1 = a2 - a1;
                txtLoadMiles.Text = r1.ToString();
            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddDinamic_Click(object sender, EventArgs e)
        {
            frmNotes notes = new frmNotes(txtLoadId.Text);
            notes.ShowDialog();
        }

        private void btnAddDinamic_MouseHover(object sender, EventArgs e)
        {
            //lblAddControls.Visible = true;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpRevenue helpRevenue = new frmHelpRevenue();
            helpRevenue.Show();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            frmMail nuevomail = new frmMail(txtMail.Text, "");
            nuevomail.ShowDialog();
        }

        private void btnAddDinamic_MouseLeave(object sender, EventArgs e)
        {
            //lblAddControls.Visible = false;
        }

        private void btnPDSearchStartCS_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtPDStarCS.Text = search.Nombre;
        }

        private void btnPDSearchEndtCS_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch("citystates","");
            search.ShowDialog();
            txtPDEndCS.Text = search.Nombre;
        }

        private void btnPDSearchStartCS_MouseHover(object sender, EventArgs e)
        {
            lbPDStartCS.Visible = true;
        }

        private void btnPDSearchStartCS_MouseLeave(object sender, EventArgs e)
        {
            lbPDStartCS.Visible = false;
        }

        private void btnPDSearchEndCS_MouseHover(object sender, EventArgs e)
        {
            lbPDEndCS.Visible = true;
        }

        private void btnPDSearchEndCS_MouseLeave(object sender, EventArgs e)
        {
            lbPDEndCS.Visible = false;
        }


    }
}
