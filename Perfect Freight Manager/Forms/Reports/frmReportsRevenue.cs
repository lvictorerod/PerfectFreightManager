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
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmReportsRevenue : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");

        int filtro = 0;
        List<string> lista = new List<string>();
        private string raiz = "",route="";
        string pdfdoc = "";
        string pdfdoc2 ="";


        public frmReportsRevenue()
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
            pdfdoc = raiz + @"Documents\Reporte.pdf";
            pdfdoc2 = raiz + @"Documents\Reporte2.pdf";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tripPickupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 1;
            crearPDF(filtro);
        }

        private void tripFuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 2;
            crearPDF(filtro);
        }

        private void tripExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 3;
            crearPDF(filtro);
        }

        private void tripRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 4;
            crearPDF(filtro);
        }
        public class HeaderEventHandler1 : IEventHandler
        {
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
                Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 95, page.GetPageSize().GetWidth() - 70, 55);
                new Canvas(canvas, pdfDoc, rootArea).Add(getTable(docEvent));
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 20f, 80f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();
                Style styleCell = new Style().SetBorder(Border.NO_BORDER);
                Style styleText = new Style().SetTextAlignment(TextAlignment.CENTER).SetFontSize(14);
                Cell cell = new Cell().Add(Img.SetAutoScale(true));
                tableEvent.AddCell(cell.AddStyle(styleCell).SetTextAlignment(TextAlignment.LEFT));
                PdfFont Bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

                cell = new Cell()
                    .Add(new Paragraph("Perfect Freight Inc."))
                    .Add(new Paragraph("Date: " + DateTime.Now.ToLongDateString()))
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
        private void crearPDF(int filtro)
        {
            //////////////////////////////////////
            ///// TRIP -> PICKUP & DROP
            //////////////////////////////////////
            ///
            if (filtro == 1) //Trip -> Pickup and Drop
            {
                float centro = 792 / 2;
                string cadena = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Trip Pay" };
                float[] anchos = { 5, 5, 4, 4, 4, 4, 5, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                Style styleCabeza = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.CYAN);
                Style styleSub = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.YELLOW);
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Trip Info -> Pickup & Drop )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {

                    string Loadid = dr["loadid"].ToString();

                    tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.RIGHT)));


                    string cadena2 = "select p.idrevenue, p.pickdroptype, p.startdate, p.startcs, p.arrivadate, p.endcs, p.customerliveload, p.appoinmentdate, c.loadid from rvpickupdrops as p inner join revenues as c on p.idrevenue = c.loadid order by p.idrevenue"; // + " where loadpay like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();

                    while (dr2.Read()) //for (int j=0; j <= largo; j++)
                    {
                        string idRevenue = dr2["idrevenue"].ToString();
                        if (idRevenue == Loadid)
                        {
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("PD Type: " + dr2["pickdroptype"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Start Date: " + dr2["startdate"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Start St: " + dr2["startcs"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Arr.Date: " + dr2["arrivadate"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("End St: " + dr2["endcs"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Customer: " + dr2["customerliveload"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Appoim Date: " + dr2["appoinmentdate"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                        }
                    }
                    conn2.Close();
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            //////////////////////////////////////
            ///// TRIP -> FUEL
            //////////////////////////////////////
            ///
            else if (filtro == 2)
            {
                float centro = 792 / 2;
                string cadena = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Trip Pay" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                Style styleCabeza = new Style().SetFontSize(10).SetBackgroundColor(ColorConstants.CYAN);
                Style styleSub = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.YELLOW);
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Trip Info -> Fuel )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {

                    string Loadid = dr["loadid"].ToString();

                    tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.RIGHT)));


                    string cadena2 = "select p.idrevenue, p.date, p.state, p.payment, p.quantity, p.cost, p.invoicenumber, c.loadid from rvfuels as p inner join revenues as c on p.idrevenue = c.loadid order by p.idrevenue"; // + " where loadpay like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();

                    while (dr2.Read()) //for (int j=0; j <= largo; j++)
                    {
                        string idRevenue = dr2["idrevenue"].ToString();
                        if (idRevenue == Loadid)
                        {
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Date: " + dr2["date"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("State: " + dr2["state"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Payment: " + dr2["payment"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Quantity: " + dr2["quantity"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Cost: " + dr2["cost"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Invoice #: " + dr2["invoicenumber"].ToString()).SetFont(fontContenido).AddStyle(styleSub).SetTextAlignment(TextAlignment.RIGHT)));

                        }
                    }
                    conn2.Close();
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            //////////////////////////////////////
            ///// TRIP -> EXPENSES
            //////////////////////////////////////
            ///
            else if (filtro == 3)
            {
                float centro = 792 / 2;
                string cadena = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Trip Pay" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                Style styleCabeza = new Style().SetFontSize(10).SetBackgroundColor(ColorConstants.CYAN);
                Style styleSub = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.YELLOW);
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Trip Info -> Expenses )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {

                    string Loadid = dr["loadid"].ToString();

                    tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.RIGHT)));


                    string cadena2 = "select p.idrevenue, p.date, p.description, p.cost, c.loadid from rvexpenses as p inner join revenues as c on p.idrevenue = c.loadid order by p.idrevenue"; // + " where loadpay like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();

                    while (dr2.Read()) //for (int j=0; j <= largo; j++)
                    {
                        string idRevenue = dr2["idrevenue"].ToString();
                        if (idRevenue == Loadid)
                        {
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Date: " + dr2["date"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Description: " + dr2["description"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Cost: " + dr2["cost"].ToString()).SetFont(fontContenido).AddStyle(styleSub).SetTextAlignment(TextAlignment.RIGHT)));

                        }
                    }
                    conn2.Close();
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            else if (filtro == 4)
            {
                float centro = 792 / 2;
                string cadena = "select client,contact,loadid,driver,truckid,trailerid,loaddate,startcityst,enddate,endcityst,totaltrippay from revenues";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Trip Pay" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                Style styleCabeza = new Style().SetFontSize(10).SetBackgroundColor(ColorConstants.CYAN);
                Style styleSub = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.YELLOW);
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Trip Info -> Route )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {

                    string Loadid = dr["loadid"].ToString();

                    tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.RIGHT)));


                    string cadena2 = "select p.idrevenue, p.state, p.startodom, p.endodom, p.miles, p.tollmiles, p.gallons, c.loadid from rvroutes as p inner join revenues as c on p.idrevenue = c.loadid order by p.idrevenue"; // + " where loadpay like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                    conn2.Open();
                    NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                    NpgsqlDataReader dr2 = comando2.ExecuteReader();

                    while (dr2.Read()) //for (int j=0; j <= largo; j++)
                    {
                        string idRevenue = dr2["idrevenue"].ToString();
                        if (idRevenue == Loadid)
                        {
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("State: " + dr2["state"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Start Odom: " + dr2["startodom"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("End Odom: " + dr2["endodom"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Miles: " + dr2["miles"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Toll Miles: " + dr2["tollmiles"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                            tabla.AddCell(new Cell().Add(new Paragraph("Gallons: " + dr2["gallons"].ToString()).SetFont(fontContenido).AddStyle(styleSub).SetTextAlignment(TextAlignment.RIGHT)));
                        }
                    }
                    conn2.Close();
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
