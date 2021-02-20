using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;
using Perfect_Freight_Manager.Forms.Help;
using Perfect_Freight_Manager.Forms.Reports;
using Perfect_Freight_Manager.Models;
using System;
using System.Globalization;
using System.Windows.Forms;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using PdfFont = iText.Kernel.Font.PdfFont;
using PdfReader = iText.Kernel.Pdf.PdfReader;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using Style = iText.Layout.Style;
using Table = iText.Layout.Element.Table;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmDriverPay : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string TblName = "revenues";
        private int sgte = 0, cuenta = 0;
        private int idDriver = 0;
        private string LoadStatus = "2"; //Delivered
        private string FactoryPaid = "True";
        private string LoadId, DriverName, Truck, Fecha;

        private double a1 = 0, a2 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0, a9 = 0, a10 = 0;
        private double costofuel = 0.0, costoexpense = 0.0, costoconcargo = 0.0, tonnage = 0.0;
        private int cuentapd = 0;
        private string pdfdoc;
        private string pdfdoc2;
        private string raiz = "",route="";

        private void txtBonus_Leave(object sender, EventArgs e)
        {  
            a10 = Convert.ToDouble(txtBonus.Text);
            txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            txtTotalPayDue.Text = ((a1 + a2 + a4 + a10) - (costofuel + costoconcargo + a5 + a6 + a7 + a9)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelpDriverPay driverpay = new frmHelpDriverPay();
            driverpay.Show();
        }
        public frmDriverPay()
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
            lbRecord.Text = "Record " + sgte + " of  " + cuenta;
            btnDriverPayUpd.Enabled = false;
            btnPaySettlement.Enabled = false;
            btnAppoint.Enabled = false;
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtDateTo_Leave(object sender, EventArgs e)
        {
            string value1 = Convert.ToDateTime(dtDateFrom.Value).ToShortDateString().ToString();
            string value2 = Convert.ToDateTime(dtDateTo.Value).ToShortDateString().ToString();
            dgvDriver.DataSource = conectandose.ConsultarDriverPay(TblName, LoadStatus, value1, value2, FactoryPaid);
            cuenta = dgvDriver.Rows.GetRowCount(0);
            lbRecord.Text = "Record " + sgte + " of  " + cuenta;
            btnDriverPayUpd.Enabled = false;
            btnPaySettlement.Enabled = false;
            btnAppoint.Enabled = false;
            if (cuenta != 0)
            {
                btnDriverPayUpd.Enabled = true;
                btnPaySettlement.Enabled = true;
                lbAdvertency.Visible = false;
            }
                
            else MessageBox.Show("Not there are data to show\n" + "Select the correct range of dates\n" + "or review that Fatory Paid this checked in the your Load", "Incomplete data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void txtBonus_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDriverPayUpd_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update revenues set bonus='" + txtBonus.Text + "'" + " where loadid like '" + LoadId + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            string value1 = Convert.ToDateTime(dtDateFrom.Value).ToShortDateString().ToString();
            string value2 = Convert.ToDateTime(dtDateTo.Value).ToShortDateString().ToString();
            dgvDriver.DataSource = conectandose.ConsultarDriverPay(TblName, LoadStatus, value1, value2, FactoryPaid);
        }
        private void btnTripFirst_Click(object sender, EventArgs e)
        {
            double a2 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0;
            cuenta = dgvDriver.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvDriver.Rows.GetFirstRow(0);
                //sgte += 1;
                dgvDriver_RowEnter(sender, e);
                rellena();
            }
        }

        private void btnTripPrevios_Click(object sender, EventArgs e)
        {
            double a1 = 0; a2 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0;
            cuenta = dgvDriver.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvDriver.Rows.GetPreviousRow(sgte, 0);
                if (sgte == -1) sgte = cuenta - 1;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvDriver_RowEnter(sender, e);
                    rellena();
                }
            }
        }
        private void btnTripNext_Click(object sender, EventArgs e)
        {
            double a1 = 0; a2 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0;
            cuenta = dgvDriver.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvDriver.Rows.GetNextRow(sgte, 0);
                if (sgte == -1) sgte = 0;
                if (sgte <= cuenta && sgte >= 0)
                {
                    dgvDriver_RowEnter(sender, e);
                    rellena();
                }
            }
        }
        private void btnTripEnd_Click(object sender, EventArgs e)
        {
            double a1 = 0; a2 = 0; a4 = 0; a5 = 0; a6 = 0; a7 = 0; a8 = 0; a9 = 0; a10 = 0;
            cuenta = dgvDriver.Rows.GetRowCount(0);
            if (cuenta != 0)
            {
                sgte = dgvDriver.Rows.GetLastRow(0);
                dgvDriver_RowEnter(sender, e);
                rellena();
            }
        }
        private void dgvDriver_RowEnter(object sender, EventArgs e)
        {
            dgvDriver.ClearSelection(); //Rows[RowIndex].Selected = false;
            dgvDriver.Rows[sgte].Selected = true;
            dgvDriver.FirstDisplayedScrollingRowIndex = dgvDriver.Rows.GetNextRow(sgte - 1, 0);
        }
        private void btnClearPay_Click(object sender, EventArgs e)
        {
            dgvPay.Rows.Clear();
            dgvDeductions.Rows.Clear();
            lbDriverName.Text = "";
            lbDriverPayMethod.Text = "";
            txtPay.Text = "0.00";
            txtTotalRevenue.Text = "0.00";
            txtDeductions.Text = "0.00";
            txtTotalDeduction.Text = "0.00";
            txtTotalPayDue.Text = "0.00";
            dtDriverSettlement.Text = "";
            txtVacations.Text = "0.00";
            txtBonus.Text = "0";
            lbRecord.Text = "Record 0" + " of  " + cuenta;

            btnDriverPayUpd.Enabled = false;
            btnPaySettlement.Enabled = false;
            btnAppoint.Enabled = false;
        }
        private void rellena()
        {
            dgvPay.Rows.Clear();
            dgvDeductions.Rows.Clear();
            lbDriverName.Text = "";
            lbDriverPayMethod.Text = "";
            txtPay.Text = "0.00";
            txtTotalRevenue.Text = "0.00";
            txtDeductions.Text = "0.00";
            txtTotalDeduction.Text = "0.00";
            txtTotalPayDue.Text = "0.00";
            //dtDriverSettlement.Text = "";
            txtVacations.Text = "0.00";
            tonnage = 0;
            idDriver = Convert.ToInt32(dgvDriver.Rows[sgte].Cells[34].Value);
            LoadId = Convert.ToString(dgvDriver.Rows[sgte].Cells[3].Value);
            tonnage = Convert.ToDouble(dgvDriver.Rows[sgte].Cells[10].Value);
            Truck = Convert.ToString(dgvDriver.Rows[sgte].Cells[6].Value);
            txtBonus.Text = Convert.ToString(dgvDriver.Rows[sgte].Cells[42].Value);

            btnDriverPayUpd.Enabled = true;
            btnPaySettlement.Enabled = true;

            ///// FUEL //////////////////
            ///
            string cadenafuel = "select idrevenue, cost from rvfuels where idrevenue = '" + LoadId + "'";
            costofuel = 0;
            conn2.Open();
            NpgsqlCommand comandofuel = new NpgsqlCommand(cadenafuel, conn2);
            NpgsqlDataReader drfuel = comandofuel.ExecuteReader();

            while (drfuel.Read())
            {
                costofuel = costofuel + Convert.ToDouble(drfuel["cost"]);
            }
            conn2.Close();

            //// EXPENSE //////////////
            ///
            string cadenaexpense = "select idrevenue, cost, cargostatus from rvexpenses where idrevenue = '" + LoadId + "'";
            costoconcargo = 0;
            costoexpense = 0;
            conn2.Open();
            NpgsqlCommand comandoexpense = new NpgsqlCommand(cadenaexpense, conn2);
            NpgsqlDataReader drexpense = comandoexpense.ExecuteReader();

            while (drexpense.Read())
            {
                costoexpense = costoexpense + Convert.ToDouble(drexpense["cost"]);
                if (drexpense["cargostatus"].ToString() == "True")
                    costoconcargo = costoconcargo + Convert.ToDouble(drexpense["cost"]);
            }
            conn2.Close();

            //// PICKUP & DROP ///////////////
            ///
            string cadenapd = "select idrevenue, startcs from rvpickupdrops where idrevenue = '" + LoadId + "'";
            cuentapd = 0;
            conn2.Open();
            NpgsqlCommand comandopd = new NpgsqlCommand(cadenapd, conn2);
            NpgsqlDataReader drpd = comandopd.ExecuteReader();

            while (drpd.Read())
            {
                cuentapd++;
            }
            conn2.Close();


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
                        a1 = Convert.ToDouble(dr2["flatratepay"].ToString());
                        a8 = Convert.ToDouble(dr2["vacation"].ToString()) * Convert.ToDouble(dr2["flatratepay"].ToString());
                        a4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        //DriverVacationPay = a8.ToString();
                        dgvPay.Rows.Add("Pay per Flat Rate", a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a4 != 0)
                            dgvPay.Rows.Add("Pay per Pickup & Drop", a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a8 != 0)
                            txtVacations.Text = a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        a10 = Convert.ToDouble(txtBonus.Text);
                        txtPay.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalRevenue.Text = (a1 + a4).ToString();
                        lbDriverName.Text = dr2["name"].ToString() + " " + dr2["lastname"].ToString();
                        DriverName = lbDriverName.Text;
                        lbDriverPayMethod.Text = "Flat Rate";
                        break;
                    case 1: //Mileage
                        a1 = Convert.ToDouble(dr2["emptypaypermile"].ToString()) * Convert.ToDouble(Convert.ToString(dgvDriver.Rows[sgte].Cells[22].Value));
                        //emptypaypermiles = a1.ToString();
                        a2 = Convert.ToDouble(dr2["loadedparpermile"].ToString()) * Convert.ToDouble(Convert.ToString(dgvDriver.Rows[sgte].Cells[23].Value));
                        //loadpaypermiles = a2.ToString();
                        a4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        a8 = Convert.ToDouble(dr2["vacation"].ToString()) * (a1 + a2);
                        //DriverVacationPay = a8.ToString();
                        dgvPay.Rows.Add("Pay per Empty Miles", a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        dgvPay.Rows.Add("Pay per Load Miles", a2.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a4 != 0)
                            dgvPay.Rows.Add("Pay per Pickup & Drop", a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a8 != 0)
                            txtVacations.Text = a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        a10 = Convert.ToDouble(txtBonus.Text);
                        txtPay.Text = (a1 + a2 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalRevenue.Text = (a1 + a2 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        lbDriverName.Text = dr2["name"].ToString() + " " + dr2["lastname"].ToString();
                        DriverName = lbDriverName.Text;
                        lbDriverPayMethod.Text = "Mileage";
                        break;
                    case 2: //PercentagePay
                        a1 = Convert.ToDouble(dr2["percentagepay"].ToString()) / 100 * Convert.ToDouble(Convert.ToString(dgvDriver.Rows[sgte].Cells[32].Value));
                        //percentagepay = a4.ToString();
                        a4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        a8 = Convert.ToDouble(dr2["vacation"].ToString()) * a4;
                        //DriverVacationPay = a8.ToString();
                        dgvPay.Rows.Add("Pay per Percentage", a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a4 != 0)
                            dgvPay.Rows.Add("Pay per Pickup & Drop", a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a8 != 0)
                            txtVacations.Text = a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        a10 = Convert.ToDouble(txtBonus.Text);
                        txtPay.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalRevenue.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        lbDriverName.Text = dr2["name"].ToString() + " " + dr2["lastname"].ToString();
                        DriverName = lbDriverName.Text;
                        lbDriverPayMethod.Text = "Percentage";
                        break;
                    case 3: //Tonnage
                        a1 = Convert.ToDouble(dr2["tonnagepay"].ToString()) * tonnage / 907.18474;
                        a4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        a8 = Convert.ToDouble(dr2["vacation"].ToString()) * Convert.ToDouble(dr2["tonnagepay"].ToString());
                        //DriverVacationPay = a8.ToString();
                        dgvPay.Rows.Add("Pay per Tonnage", a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a4 != 0)
                            dgvPay.Rows.Add("Pay per Pickup & Drop", a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a8 != 0)
                            txtVacations.Text = a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        a10 = Convert.ToDouble(txtBonus.Text);
                        txtPay.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalRevenue.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        lbDriverName.Text = dr2["name"].ToString() + " " + dr2["lastname"].ToString();
                        DriverName = lbDriverName.Text;
                        lbDriverPayMethod.Text = "Tonnage";
                        break;
                    case 4: //Hourly
                        string year1 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[18].Value).Year.ToString();
                        int intyear1 = Convert.ToInt32(year1);
                        string mes1 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[18].Value).Month.ToString();
                        int intmes1 = Convert.ToInt32(mes1);
                        string dia1 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[18].Value).Day.ToString();
                        int intdia1 = Convert.ToInt32(dia1);
                        string hora1 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[18].Value).Hour.ToString();
                        int inthora1 = Convert.ToInt32(hora1);

                        string year2 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[28].Value).Year.ToString();
                        int intyear2 = Convert.ToInt32(year2);
                        string mes2 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[28].Value).Month.ToString();
                        int intmes2 = Convert.ToInt32(mes2);
                        string dia2 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[28].Value).Day.ToString();
                        int intdia2 = Convert.ToInt32(dia2);
                        string hora2 = Convert.ToDateTime(dgvDriver.Rows[sgte].Cells[28].Value).Hour.ToString();
                        int inthora2 = Convert.ToInt32(hora2);

                        int horas = (intyear1 - intyear2) * 8760 + (intmes1 - intmes2) * 720 + (intdia1 - intdia2) * 24 + (inthora1 - inthora2);

                        a1 = Convert.ToDouble(dr2["paybyhours"].ToString()) * horas;
                        //paybyhours = a3.ToString();
                        a4 = Convert.ToDouble(dr2["pickupdroppay"].ToString()) * cuentapd;
                        a8 = Convert.ToDouble(dr2["vacation"].ToString()) * a1;
                        //DriverVacationPay = a8.ToString();
                        dgvPay.Rows.Add("Pay per Hours", a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a4 != 0)
                            dgvPay.Rows.Add("Pay per Pickup & Drop", a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                        if (a8 != 0)
                            txtVacations.Text = a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        a10 = Convert.ToDouble(txtBonus.Text);
                        txtPay.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalBonus.Text = a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txtTotalRevenue.Text = (a1 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        lbDriverName.Text = dr2["name"].ToString() + " " + dr2["lastname"].ToString();
                        DriverName = lbDriverName.Text;
                        lbDriverPayMethod.Text = "Hourly";
                        break;
                }

                //Gastos Fuel y Expenses
                if (dr2["driverfuel"].ToString() == "True" && costofuel != 0)
                    dgvDeductions.Rows.Add("Deductions Fuel", costofuel.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                else costofuel = 0.0;
                if (dr2["driverexpense"].ToString() == "False" && costoconcargo != 0)
                    dgvDeductions.Rows.Add("Deductions Expenses", costoconcargo.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

                //Deducciones
                a5 = Convert.ToDouble(dr2["driverezpass"].ToString());
                if (a5 != 0)
                    dgvDeductions.Rows.Add("Deductions EZPass", a5.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                a6 = Convert.ToDouble(dr2["driverinsurace"].ToString());
                if (a6 != 0)
                    dgvDeductions.Rows.Add("Deductions Insurance", a6.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                if (dr2["statusdriver"].ToString() == "1") //Es Owner property
                {
                    a7 = Convert.ToDouble(dr2["drivereld"].ToString());
                    if (a7 != 0)
                        dgvDeductions.Rows.Add("Deductions ELD", a7.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                    a9 = Convert.ToDouble(dr2["driverprepass"].ToString());
                    if (a9 != 0)
                        dgvDeductions.Rows.Add("Deductions PrePass", a9.ToString("C", CultureInfo.CreateSpecificCulture("en-US")));
                }
                txtDeductions.Text = (costofuel + costoconcargo + a5 + a6 + a7 + a9).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                txtTotalDeduction.Text = (costofuel + costoconcargo + a5 + a6 + a7 + a9).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                txtTotalPayDue.Text = ((a1 + a2 + a4 + a10) - (costofuel + costoconcargo + a5 + a6 + a7 + a9)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                lbRecord.Text = "Record " + (sgte + 1) + " of  " + cuenta;
            }
            conn2.Close();
        }
        public class HeaderEventHandler1 : IEventHandler
        {
            string catalogo = "";
            Image Img;
            public HeaderEventHandler1(Image img)
            {
                Img = img;
            }

            [Obsolete]
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 95, page.GetPageSize().GetWidth() - 70, 85);
                new Canvas(canvas, pdfDoc, rootArea).Add(getTable(docEvent));
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 20f, 80f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();
                Style styleCell = new Style().SetBorder(Border.NO_BORDER);
                Style styleText = new Style().SetTextAlignment(TextAlignment.CENTER).SetFontSize(10);
                Cell cell = new Cell().Add(Img.SetAutoScale(true));
                tableEvent.AddCell(cell.AddStyle(styleCell).SetTextAlignment(TextAlignment.LEFT));
                cell = new Cell()
                    .Add(new Paragraph("Perfect Freight Inc."))
                    .Add(new Paragraph("4401 E INDEPENDENCE BLVD SIUT 208-H"))
                    .Add(new Paragraph("CHARLOTTE, NC NC.28205"))
                    .Add(new Paragraph("(786) 320 1590"))
                    .Add(new Paragraph(" Driver Settlement Sheet "))
                    .AddStyle(styleCell).AddStyle(styleText);
                tableEvent.AddCell(cell);
                return tableEvent;
            }
        }

        public class FootEventHandler1 : IEventHandler
        {
            [Obsolete]
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);
                Rectangle rootArea = new Rectangle(36, page.GetPageSize().GetBottom() - 15, page.GetPageSize().GetWidth() - 70, 50);
                new Canvas(canvas, pdfDoc, rootArea).Add(getTable(docEvent));
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 92f, 8f };
                PdfPage page = docEvent.GetPage();
                int pagenum = docEvent.GetDocument().GetPageNumber(docEvent.GetPage());

                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();

                Style styleCell = new Style().SetPadding(5).SetBorder(Border.NO_BORDER).SetBorderTop(new SolidBorder(ColorConstants.BLACK, 2));
                //Style styleText = new Style().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14);
                Cell cell = new Cell().Add(new Paragraph(DateTime.Now.ToLongDateString()));

                tableEvent.AddCell(cell.AddStyle(styleCell).SetTextAlignment(TextAlignment.RIGHT).SetFontColor(ColorConstants.LIGHT_GRAY));
                cell = new Cell().Add(new Paragraph(pagenum.ToString()));
                cell.AddStyle(styleCell).SetBackgroundColor(ColorConstants.BLACK).SetFontColor(ColorConstants.WHITE).SetTextAlignment(TextAlignment.CENTER);
                tableEvent.AddCell(cell);
                return tableEvent;
            }
        }
        private void btnPaySettlement_Click(object sender, EventArgs e)
        {
            int cuantos = dgvDriver.Rows.GetRowCount(0);


            if (dtDriverSettlement.Checked && dtDateFrom.Checked && dtDateTo.Checked)
            {
                Fecha = dtDriverSettlement.Text;
                while (cuantos != 0)
                {
                    if (cuantos == dgvDriver.Rows.GetRowCount(0))
                        btnTripFirst_Click(sender, e);
                    else btnTripNext_Click(sender, e);
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand("update revenues set datefrompaid='" + dtDateFrom.Value + "',datetopaid='" + dtDateTo.Value + "',datepaid='" + dtDriverSettlement.Value + "',totalpaydue='" + txtTotalPayDue.Text + "'" + " where loadid like '" + LoadId + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }

                    string cadena2 = "select * from driverprofiles where id=" + idDriver;

                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();
                    while (dr2.Read())
                    {
                        if (dr2["email"].ToString() != "") //Tiene eMail ???
                        {
                            //Envia eMail con Driver Settlement Sheet y lo marco para la Nomina
                            float centro = 612 / 2;
                            //pdfdoc = raiz + @"Documents\Reporte.pdf";
                            pdfdoc = raiz + @"Documents\DSS.pdf";// + cuantos + ".pdf"; //" + cuantos +"

                            PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                            //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                            //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                            PageSize portrait = new PageSize(612, 792);
                            Document documento = new Document(pdfDocument, portrait); //PageSize.LETTER
                            documento.SetMargins(158, 20, 55, 20);
                            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                            //Encabezado del Pay Method
                            string[] columnas = { "Pay Type", "Ammount" };
                            float[] anchos = { 5, 3 };

                            Table tabla = new Table(UnitValue.CreatePercentArray(anchos)); //UnitValue.CreatePercentArray(anchos)
                            tabla.SetWidth(225); //UnitValue.CreatePercentValue(100)
                            tabla.SetRelativePosition(15, 70, 55, 20);
                            Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                            Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                            foreach (string columna in columnas)
                            {
                                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                            }
                            //Encabezado de Deduccciones
                            Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                            documento2.SetMargins(158, 20, 55, 20);
                            string[] columnas2 = { "Deductions", "Ammount" };
                            float[] anchos2 = { 5, 3 };
                            Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos2));
                            tabla2.SetWidth(225); //UnitValue.CreatePercentValue(100)
                            tabla2.SetRelativePosition(280, 70, 55, 20);

                            foreach (string columnax in columnas2)
                            {
                                tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead)));
                            }
                            //Resumen
                            Document documento3 = new Document(pdfDocument, portrait); //PageSize.LETTER
                            documento3.SetMargins(158, 20, 55, 20);
                            string[] columnas3 = { "Resumen" };
                            float[] anchos3 = { 5 };
                            Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos3)); //UnitValue.CreatePercentArray(anchos)
                            tabla3.SetWidth(225); //UnitValue.CreatePercentValue(100)
                            tabla3.SetRelativePosition(140, 200, 55, 20);

                            Document documento4 = new Document(pdfDocument, portrait); //PageSize.LETTER
                            documento4.SetMargins(15, 20, 55, 20);
                            float[] ancho4 = { 4, 6, 3, 5 };
                            Table tabla4 = new Table(UnitValue.CreatePercentArray(ancho4));
                            tabla4.SetRelativePosition(50, 120, 55, 20);
                            tabla4.AddCell(new Cell().Add(new Paragraph("Load Id: " + LoadId).SetFont(fontContenido).SetFontSize(9)));
                            tabla4.AddCell(new Cell().Add(new Paragraph("Driver: " + DriverName).SetFont(fontContenido).SetFontSize(9)));
                            tabla4.AddCell(new Cell().Add(new Paragraph("Truck: " + Truck).SetFont(fontContenido).SetFontSize(9)));
                            tabla4.AddCell(new Cell().Add(new Paragraph("Date: " + Fecha).SetFont(fontContenido).SetFontSize(9)));
                            var dfechafrom = dtDateFrom.Value;
                            var fechaFrom = new Paragraph("Date From: " + dfechafrom).SetFontSize(9);
                            var dfechato = dtDateTo.Value;
                            var fechaTo = new Paragraph("Date To: " + dfechato).SetFontSize(9);
                            float y = 637;
                            
                            documento.ShowTextAligned(fechaFrom, 140, y, TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento.ShowTextAligned(fechaTo, 446, y, TextAlignment.RIGHT, VerticalAlignment.TOP);

                            foreach (string columnay in columnas3)
                            {
                                tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnay).AddStyle(styleHead)));
                            }

                            int paymethod = Convert.ToInt32(dr2["paymethod"].ToString());
                            switch (paymethod)
                            {
                                case 0: //Flat Rate
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Flat Rate").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT));
                                    if (a4 != 0)
                                    {
                                        tabla.AddCell(new Cell().Add(new Paragraph("Pay per Pickup & Drop").SetFont(fontContenido).SetFontSize(9)));
                                        tabla.AddCell(new Cell().Add(new Paragraph(a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    }

                                    break;
                                case 1: //Mileage
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Empty Miles").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Load Miles").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a2.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    if (a4 != 0)
                                    {
                                        tabla.AddCell(new Cell().Add(new Paragraph("Pay per Pickup & Drop").SetFont(fontContenido).SetFontSize(9)));
                                        tabla.AddCell(new Cell().Add(new Paragraph(a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    }

                                    break;
                                case 2: //Percentage
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Percentage").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US")))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT));
                                    if (a4 != 0)
                                    {
                                        tabla.AddCell(new Cell().Add(new Paragraph("Pay per Pickup & Drop").SetFont(fontContenido).SetFontSize(9)));
                                        tabla.AddCell(new Cell().Add(new Paragraph(a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    }

                                    break;
                                case 3: //Tonnage
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Tonnage").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    if (a4 != 0)
                                    {
                                        tabla.AddCell(new Cell().Add(new Paragraph("Pay per Pickup & Drop").SetFont(fontContenido).SetFontSize(9)));
                                        tabla.AddCell(new Cell().Add(new Paragraph(a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    }

                                    break;
                                case 4: //Hourly
                                    tabla.AddCell(new Cell().Add(new Paragraph("Pay per Hours").SetFont(fontContenido).SetFontSize(9)));
                                    tabla.AddCell(new Cell().Add(new Paragraph(a1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    if (a4 != 0)
                                    {
                                        tabla.AddCell(new Cell().Add(new Paragraph("Pay per Pickup & Drop").SetFont(fontContenido).SetFontSize(9)));
                                        tabla.AddCell(new Cell().Add(new Paragraph(a4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                    }
                                    break;
                            }
                            tabla.AddCell(new Cell().Add(new Paragraph("Total Revenue").SetFont(fontContenido).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                            tabla.AddCell(new Cell().Add(new Paragraph((a1 + a2 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));

                            //Gastos Fuel y Expenses
                            if (dr2["driverfuel"].ToString() == "True" && costofuel != 0)
                            {
                                tabla2.AddCell(new Cell().Add(new Paragraph("Deductions Fuel").SetFont(fontContenido).SetFontSize(9)));
                                tabla2.AddCell(new Cell().Add(new Paragraph(costofuel.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            }
                            if (dr2["driverexpense"].ToString() == "True" && costoconcargo != 0)
                            {
                                tabla2.AddCell(new Cell().Add(new Paragraph("Deductions Expenses").SetFont(fontContenido).SetFontSize(9)));
                                tabla2.AddCell(new Cell().Add(new Paragraph(costoconcargo.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            }
                            //Deducciones
                            if (a5 != 0)
                            {
                                tabla2.AddCell(new Cell().Add(new Paragraph("Deductions EZPass").SetFont(fontContenido).SetFontSize(9)));
                                tabla2.AddCell(new Cell().Add(new Paragraph(a5.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            }

                            if (a6 != 0)
                            {
                                tabla2.AddCell(new Cell().Add(new Paragraph("Deductions Insurance").SetFont(fontContenido).SetFontSize(9)));
                                tabla2.AddCell(new Cell().Add(new Paragraph(a6.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            }
                            if (dr2["statusdriver"].ToString() == "1") //Es Owner property
                            {
                                if (a7 != 0)
                                {
                                    tabla2.AddCell(new Cell().Add(new Paragraph("Deductions ELD").SetFont(fontContenido).SetFontSize(9)));
                                    tabla2.AddCell(new Cell().Add(new Paragraph(a7.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                }
                                if (a9 != 0)
                                {
                                    tabla2.AddCell(new Cell().Add(new Paragraph("Deductions PrePass").SetFont(fontContenido).SetFontSize(9)));
                                    tabla2.AddCell(new Cell().Add(new Paragraph(a9.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                                }
                            }
                            tabla2.AddCell(new Cell().Add(new Paragraph("Total Deduction").SetFont(fontContenido).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                            tabla2.AddCell(new Cell().Add(new Paragraph((costofuel + costoconcargo + a5 + a6 + a7 + a9).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));


                            //Resumen 
                            tabla3.AddCell(new Cell().Add(new Paragraph("Total Revenue " + (a1 + a2 + a4).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            tabla3.AddCell(new Cell().Add(new Paragraph("Total Deduction " + (costofuel + costoconcargo + a5 + a6 + a7 + a9).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));

                            tabla3.AddCell(new Cell().Add(new Paragraph("Total Bonus " + a10.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));

                            tabla3.AddCell(new Cell().Add(new Paragraph("Total Driver Pay Due " + ((a1 + a2 + a4 + a10) - (costofuel + costoconcargo + a5 + a6 + a7 + a9)).ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                            if (a8 != 0)
                            {
                                tabla3.AddCell(new Cell().Add(new Paragraph("Vacations " + a8.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)).SetFont(fontContenido).SetFontSize(9));
                            }
                            documento4.Add(tabla4);
                            documento.Add(tabla);
                            documento2.Add(tabla2);
                            documento3.Add(tabla3);
                            documento.Close();
                            documento2.Close();
                            documento3.Close();
                            documento4.Close();

                            frmMail nuevomail = new frmMail(dr2["email"].ToString(), pdfdoc2);
                            nuevomail.ShowDialog();

                            MessageBox.Show("Driver Settlement Sheet send to: " + DriverName);


                        }
                        else
                        {
                            //No tiene eMail y lo marco para la nomina
                            MessageBox.Show("Driver Settlement Sheet Not send to: " + DriverName);
                        }

                    }
                    conn2.Close();
                    // Print Nomina
                    cuantos--;
                    txtBonus.Text = "0";
                }
                btnAppoint.Enabled = true;
            }
            else
                MessageBox.Show("Date to Pay no selected", "Warning Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void btnAppoint_Click(object sender, EventArgs e)
        {
            string value1 = Convert.ToDateTime(dtDateFrom.Value).ToShortDateString().ToString();
            string value2 = Convert.ToDateTime(dtDateTo.Value).ToShortDateString().ToString();
            frmPrintSettlement frmPrintSettlement = new frmPrintSettlement(value1, value2);
            frmPrintSettlement.Show();
        }

    }
}
