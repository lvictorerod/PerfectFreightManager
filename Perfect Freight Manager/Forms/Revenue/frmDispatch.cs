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
using Npgsql;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = iText.Layout.Element.Image;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using PdfFont = iText.Kernel.Font.PdfFont;
using PdfReader = iText.Kernel.Pdf.PdfReader;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using Rectangle = iText.Kernel.Geom.Rectangle;
using Style = iText.Layout.Style;
using Table = iText.Layout.Element.Table;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmDispatch : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string raiz = "", route = "";
        private string pdfdoc;
        private string pdfdoc2;
        private string Address, Phone, Shipper, Receiver, Email;
        private int idDriver = 0;
        private int sgte = 0, cuenta = 0, sgtepickup = 0, cuantos=0, howreceiver = 0, howshipper = 0, sgteclient = 0;
        private float total;
        private string TruckNumber;
        private string TrailerNumber;
        public frmDispatch(string drivername, int iddriver, string loadid, string equipment)
        {
            InitializeComponent();
            string cadena = "select * from adminsystems";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                raiz = dr["rphotodoc"].ToString();
                route = dr["rprogram"].ToString();
            }
            conn.Close();

            Shipper = "";
            Receiver = "";

            txtDSDriver.Text = drivername;
            txtDSLoadId.Text = loadid;
            idDriver = iddriver;
            txtRDLoadId.Text = loadid;
            txtDSType.Text = equipment;

            dgvDSPickup.DataSource = conectandose.ConsultarPickupDrop("rvpickupdrops", txtDSLoadId.Text);
            cuantos = dgvDSPickup.Rows.GetRowCount(0) - 1;
            int compara = cuantos;
            while (compara > 0)
            {
                if (Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Pickup" ||
                    Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Hook")
                    howshipper++;
                if (Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Drop")
                    howreceiver++;
                compara--;
                sgtepickup++;
            }
            sgtepickup = 0;
            txtDSHShipper.Text = howshipper.ToString();
            txtDSHReceiver.Text = howreceiver.ToString();

            dgvDSRevenue.DataSource = conectandose.ConsultarInvoice("revenues", txtDSLoadId.Text);
            compara = dgvDSPickup.Rows.GetRowCount(0) - 1;
            txtDSAmmount.Text = "1";
            if (Convert.ToString(dgvDSRevenue.Rows[0].Cells[33].Value) == "Line Haul")
            {
                txtDSRate.Text = Convert.ToString(dgvDSRevenue.Rows[0].Cells[30].Value);
                txtDSEXtended.Text = Convert.ToString(dgvDSRevenue.Rows[0].Cells[30].Value);
                txtDSTotal.Text = Convert.ToString(dgvDSRevenue.Rows[0].Cells[30].Value);
                total = Convert.ToInt16(dgvDSRevenue.Rows[0].Cells[30].Value);
            }
            TruckNumber = Convert.ToString(dgvDSRevenue.Rows[0].Cells[6].Value);

            TrailerNumber = Convert.ToString(dgvDSRevenue.Rows[0].Cells[7].Value);

            dgvTrailerProfile.DataSource = conectandose.ConsultarTrailers("trailersprofiles", TrailerNumber);
            txtDSTrailer.Text = Convert.ToString(dgvTrailerProfile.Rows[0].Cells[18].Value) + " #" + TrailerNumber;

            dgvTruckProfile.DataSource = conectandose.ConsultarTrucks("trucksprofiles", TruckNumber);
            txtDSTruck.Text = Convert.ToString(dgvTruckProfile.Rows[0].Cells[25].Value) + " #" + TruckNumber;

            dgvNotes.DataSource = conectandose.ConsultarRevenue("rvnotes", txtDSLoadId.Text);
            lblRequirementes.Text = Convert.ToString(dgvNotes.Rows[0].Cells[3].Value);
            
        }

        private void returrnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    .Add(new Paragraph(" DISPATCH SHEET ").SetBold())
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
        private void btnDSReport_Click(object sender, EventArgs e)
        {
            string cadena = "select * from driverprofiles where id=" + idDriver;

            int numeroshipper = 1, numeroreceiver = 1;

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                if (dr["email"].ToString() != "") //Tiene eMail ???
                {
                    Email = dr["email"].ToString();
                    //Envia eMail con Driver Settlement Sheet y lo marco para la Nomina
                    float centro = 612 / 2;
                    //pdfdoc = raiz + @"Documents\Reporte.pdf";
                    pdfdoc = raiz + @"Documents\Dispatch.pdf";// + cuantos + ".pdf"; //" + cuantos +"

                    PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                    PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                    //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                    //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                    PageSize portrait = new PageSize(612, 792);
                    Document documento = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento.SetMargins(15, 20, 55, 20);
                    PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    //Encabezado del Pay Method
                    string[] columnas = { "Customer-Specified Equipment Requirements" };
                    float[] anchos = { 5 };

                    Table tabla = new Table(UnitValue.CreatePercentArray(anchos)); //UnitValue.CreatePercentArray(anchos)
                    tabla.SetWidth(UnitValue.CreatePercentValue(100)); //UnitValue.CreatePercentValue(100)
                    tabla.SetRelativePosition(20, 80, 20, 20);
                    Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                    pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                    foreach (string columna in columnas)
                    {
                        tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                    }
                    var load = txtDSLoadId.Text;
                    var drivername = txtDSDriver.Text;
                    var truck = txtDSTruck.Text;
                    var trailer = txtDSTrailer.Text;
                    var type = txtDSType.Text;

                    var loadConfirmation = new Paragraph("Load Confirmation #: " + load).SetFontSize(9);
                    var driverName = new Paragraph("Driver Name: " + drivername).SetFontSize(9);
                    var Equipment = new Paragraph("Equipment: " + truck).SetFontSize(9);
                    var Trailer = new Paragraph(trailer).SetFontSize(9);
                    var Type = new Paragraph(type).SetFontSize(9);
                    float y = 675;

                    documento.ShowTextAligned(loadConfirmation, 50, y, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento.ShowTextAligned(driverName, 50, y - 10, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento.ShowTextAligned(Equipment, 50, y - 20, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento.ShowTextAligned(Trailer, 98, y - 30, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento.ShowTextAligned(Type, 98, y - 40, TextAlignment.LEFT, VerticalAlignment.TOP);


                    //Tabla2
                    Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento2.SetMargins(90, 20, 55, 20);
                    string[] columnas2 = { "Customer Requirements" };
                    float[] anchos2 = { 5 };
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos2)); //UnitValue.CreatePercentArray(anchos)
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100)); //UnitValue.CreatePercentValue(100)
                    tabla2.SetRelativePosition(20, 80, 20, 20);
                    foreach (string columnay in columnas2)
                    {
                        tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columnay).AddStyle(styleHead)));
                    }
                    //var ytexto = label5.Text;
                    var ztexto = new Paragraph(lblRequirementes.Text).SetFontSize(9);
                    var ztexto1 = new Paragraph("____________________________________________________________________________________________________________________________________________").SetFontSize(9).SetBold();
                    documento2.ShowTextAligned(ztexto, 50, y - 75, TextAlignment.LEFT, VerticalAlignment.TOP);
                    
                    int incremento = 15;
                    y = 570;
                    documento2.ShowTextAligned(ztexto1, 50, y - (8 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                    string formato = "M/dd/yyyy";
                    DateTime fecha;
                    //Analisis del SHIPPER/////////////////////////////////
                    ///////////////////////////////////////////////////////
                    ////// PickupDrop
                    //////////////////////////
                    while (cuantos > 0)
                    {
                        if (Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Pickup" ||
                            Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Hook")
                        {
                            string categoria = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value);
                            string ycategoria;
                            Shipper = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[14].Value);
                            dgvDSCliente.DataSource = conectandose.ConsultarWith("clients", Shipper);
                            var yname = Convert.ToString(dgvDSCliente.Rows[0].Cells[1].Value);
                            var yaddress = Convert.ToString(dgvDSCliente.Rows[0].Cells[3].Value);
                            var ycitystate = Convert.ToString(dgvDSCliente.Rows[0].Cells[5].Value) + ", " + Convert.ToString(dgvDSCliente.Rows[0].Cells[6].Value);
                            var ycodezip = Convert.ToString(dgvDSCliente.Rows[0].Cells[7].Value);
                            var yphone = Convert.ToString(dgvDSCliente.Rows[0].Cells[8].Value);
                            

                            fecha = Convert.ToDateTime(dgvDSPickup.Rows[sgtepickup].Cells[15].Value);
                            var ypickupdate = fecha.ToString(formato);
                            var ypickuptime = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[17].Value);
                            var ypickupnumber = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[16].Value);
                            var ypickupapp = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[20].Value);
                            switch (categoria)
                            {
                                case "Hook":
                                    ycategoria = "SHIPPER #";
                                    break;
                                default:
                                    ycategoria = "SHIPPER #";
                                    break;
                            }
                            var ztexto2 = new Paragraph(ycategoria + numeroshipper + " " + yname).SetFontSize(9).SetBold();
                            var ztexto3 = new Paragraph("Addres: " + yaddress).SetFontSize(9);
                            var ztexto4 = new Paragraph("City, St: " + ycitystate).SetFontSize(9);
                            var ztexto5 = new Paragraph("Code Zip: " + ycodezip).SetFontSize(9);
                            var ztexto6 = new Paragraph("Phone: " + yphone).SetFontSize(9);

                            var ztexto7 = new Paragraph("Pick Up Date: " + ypickupdate).SetFontSize(9);
                            var ztexto8 = new Paragraph("*Scheduled to Pick*").SetFontSize(9).SetBold(); ;
                            var ztexto9 = new Paragraph("Pick Up Time: " + ypickuptime).SetFontSize(9);
                            var ztexto10 = new Paragraph("Pickup#: " + ypickupnumber).SetFontSize(9);
                            var ztexto11 = new Paragraph("Appointment#: " + ypickupapp).SetFontSize(9);

                            documento2.ShowTextAligned(ztexto2, 50, y - (30 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto3, 50, y - (40 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto4, 50, y - (50 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto5, 50, y - (60 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto6, 50, y - (70 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);

                            documento2.ShowTextAligned(ztexto7, 350, y - (30 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto8, 350, y - (40 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto9, 350, y - (50 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto10, 350, y - (60 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto11, 350, y - (70 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);

                            y = y - 55;
                            numeroshipper++;
                            incremento = incremento + 15;
                        }
                        documento2.ShowTextAligned(ztexto1, 50, y - (8 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                        if (Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[2].Value) == "Drop")
                        {   
                            Receiver = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[7].Value);
                            dgvDSCliente.DataSource = conectandose.ConsultarWith("clients", Receiver);
                            var yname = Convert.ToString(dgvDSCliente.Rows[0].Cells[1].Value);
                            var ycitystate = Convert.ToString(dgvDSCliente.Rows[0].Cells[5].Value) + ", " + Convert.ToString(dgvDSCliente.Rows[0].Cells[6].Value);
                            var ycodezip = Convert.ToString(dgvDSCliente.Rows[0].Cells[7].Value);
                            var yaddress = Convert.ToString(dgvDSCliente.Rows[0].Cells[3].Value);

                            var yphone = Convert.ToString(dgvDSCliente.Rows[0].Cells[8].Value);
                            fecha= Convert.ToDateTime(dgvDSPickup.Rows[sgtepickup].Cells[5].Value);
                            var ydeliverypdate = fecha.ToString(formato);
                            var ydeliverytime = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[9].Value);
                            var deliverynumber = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[18].Value);
                            var ydeliverypapp = Convert.ToString(dgvDSPickup.Rows[sgtepickup].Cells[19].Value);

                            var ztexto21 = new Paragraph("RECEIVER #" + numeroreceiver + " " + yname).SetFontSize(9).SetBold();
                            var ztexto31 = new Paragraph("Addres: " + yaddress).SetFontSize(9);
                            var ztexto41 = new Paragraph("City, St: " + ycitystate).SetFontSize(9);
                            var ztexto421 = new Paragraph("Code Zip: " + ycodezip).SetFontSize(9);
                            var ztexto43 = new Paragraph("Phone: " + yphone).SetFontSize(9);

                            var ztexto51 = new Paragraph("Delivery Up Date: " + ydeliverypdate).SetFontSize(9);
                            var ztexto61 = new Paragraph("*Open Delivery*").SetFontSize(9).SetBold(); ;
                            var ztexto71 = new Paragraph("Delivery Up Time: " + ydeliverytime).SetFontSize(9);
                            var ztexto81 = new Paragraph("Delivery#: " + deliverynumber).SetFontSize(9);
                            var ztexto91 = new Paragraph("Appointment#: " + ydeliverypapp).SetFontSize(9);

                            documento2.ShowTextAligned(ztexto21, 50, y - (30 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto31, 50, y - (40 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto41, 50, y - (50 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto421, 50, y - (60 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto43, 50, y - (70 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);

                            documento2.ShowTextAligned(ztexto51, 350, y - (30 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto61, 350, y - (40 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto71, 350, y - (50 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto81, 350, y - (60 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);
                            documento2.ShowTextAligned(ztexto91, 350, y - (70 + incremento), TextAlignment.LEFT, VerticalAlignment.TOP);

                            y = y - 55;
                            numeroreceiver++;
                            incremento = incremento + 15;
                        }
                        cuantos--;
                        sgtepickup++;
                        sgteclient++;
                    }
                    y = y - 100;
                    
                    var retails = new Paragraph("Retails Details").SetFont(fontContenido).SetFontSize(10)
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER);
                    
                    documento2.ShowTextAligned(retails, centro, y, TextAlignment.CENTER, VerticalAlignment.TOP);
                    //documento2.ShowTextAligned(ztexto1, 50, y-10, TextAlignment.LEFT, VerticalAlignment.TOP);
                    var ztexto22 = new Paragraph("Service for Load #" + txtDSLoadId.Text).SetFontSize(9).SetBold();
                    var ztexto32 = new Paragraph("Amount").SetFontSize(9).SetBold(); ;
                    var ztexto42 = new Paragraph("Rate").SetFontSize(9).SetBold(); ;
                    var ztexto52 = new Paragraph("Extended").SetFontSize(9).SetBold(); ;
                    
                    var linehaul= new Paragraph("Line Haul - FLAT RATE").SetFontSize(9);
                    var rate = new Paragraph(txtDSRate.Text).SetFontSize(9); 
                    var extended = new Paragraph(txtDSEXtended.Text).SetFontSize(9);
                    var amount = new Paragraph("1").SetFontSize(9);
                    
                    documento2.ShowTextAligned(ztexto22, 50, y - 20, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(ztexto32, 300, y - 20, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(ztexto42, 400, y - 20, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(ztexto52, 500, y - 20, TextAlignment.RIGHT, VerticalAlignment.TOP);

                    documento2.ShowTextAligned(linehaul, 50, y - 40, TextAlignment.LEFT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(amount, 300, y - 40, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(rate, 400, y - 40, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(extended, 500, y - 40, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    
                    y = y - 45;
                    var ztotal = new Paragraph("_______________").SetFontSize(9); ;
                    var totalgeneral = new Paragraph("Total........." + total.ToString()).SetFontSize(9).SetBold();

                    documento2.ShowTextAligned(ztotal, 500, y, TextAlignment.RIGHT, VerticalAlignment.TOP);
                    documento2.ShowTextAligned(totalgeneral, 500, y - 10, TextAlignment.RIGHT, VerticalAlignment.TOP);

                    documento.Add(tabla);
                    documento2.Add(tabla2);
                    documento.Close();
                    documento2.Close();

                    frmMail nuevomail = new frmMail(Email, pdfdoc2);
                    nuevomail.ShowDialog();

                    MessageBox.Show("Dispatch Sheet send to: " + txtDSDriver.Text);

                    //Guardando el Dispatch Sheet en el Directorio del Driver con:
                    //Directorio: Dispatch-Driver
                    //Nombre: DIspatch-Driver-LoadID.pdf

                    if(!Directory.Exists(raiz + @"Documents\Dispatch"))
                        Directory.CreateDirectory(raiz + @"Documents\Dispatch");

                    string Driver = txtDSDriver.Text.Trim();
                    if (!Directory.Exists(raiz + @"Documents\Dispatch\Dispatch" + Driver))
                        Directory.CreateDirectory(raiz + @"Documents\Dispatch\Dispatch" + Driver);

                    string Load = txtDSLoadId.Text;
                    //Copiando el Fichero
                    FileInfo fi = new FileInfo(raiz + @"Documents\Dispatch\Dispatch" + Driver + "/Dispatch" + Driver + "-" + Load +".pdf");
                    if (fi.Exists)
                        fi.Delete();
                        //fi.Replace(raiz + @"Documents\Dispatch\Dispatch" + Driver + "/Dispatch.pdf", raiz + @"Documents/Dispatch.pdf");
                    string source = raiz + @"Documents/Dispatch.pdf";
                    string destination = raiz + @"Documents\Dispatch\Dispatch" + Driver + "/Dispatch" + Driver + "-" + Load + ".pdf";
                    File.Copy(source, destination);
                }
                else
                {
                    //No tiene eMail y lo marco para la nomina
                    MessageBox.Show("Dispatch Sheet Not send to: " + txtDSDriver.Text);// + DriverName
                }
            }
            conn.Close();
        }
    }
}
