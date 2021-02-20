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
using System.Windows.Forms;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmPrintPdf : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");

        string LoadStatus = "";
        private string raiz = "",route="";

        int indice = 0;
        string pdfdoc = "";
        string pdfdoc2 = "";

        public frmPrintPdf()
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

        private void oustandingInvoice60DaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indice = 0;
            crearPDF(indice);
        }

        private void dueInvoiceNotLate6090DaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indice = 1;
            crearPDF(indice);
        }

        private void pastDueInvoice90DaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indice = 2;
            crearPDF(indice);
        }

        private void paidInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indice = 3;
            crearPDF(indice);
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
                    .Add(new Paragraph("Date: " + DateTime.Now.ToLongTimeString()))
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
            if (filtro == 0) //Oustanding Invoice <=60 days
            {
                string cliente;
                DateTime arrivdate;
                DateTime fecha = DateTime.Now;
                string pay = "False";
                LoadStatus = "Outstanding Invoice <= 60 days - Today = " + fecha.ToString("M/d/yyyy H:mm");

                string cadena = "select p.client,p.contact,p.loadid,p.driver,p.truckid,p.trailerid,p.loaddate,p.startcityst,p.enddate,p.endcityst,p.totaltrippay,c.idrevenue,c.arrivadate from revenues as p inner join rvpickupdrops as c on p.loadid = c.idrevenue" + " where chkfactorydate like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
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

                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Revenue" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("(" + LoadStatus + ")"))
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
                    cliente = dr["idrevenue"].ToString();

                    arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                    int dias = fecha.Subtract(arrivdate).Days;

                    if (dias <= 60)
                    {  
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.RIGHT)));
                    }
                    
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }

            else if (filtro == 1)
            {
                string cliente;

                DateTime arrivdate;
                //DateTime fecha = new DateTime(2020, 8, 25);
                DateTime fecha = DateTime.Now;
                string pay = "False";
                LoadStatus = "Due Invoice > 60 & <=90 days - Today = " + fecha.ToString("M/d/yyyy H:mm");

                string cadena = "select p.client,p.contact,p.loadid,p.driver,p.truckid,p.trailerid,p.loaddate,p.startcityst,p.enddate,p.endcityst,p.totaltrippay,c.idrevenue,c.arrivadate from revenues as p inner join rvpickupdrops as c on p.loadid = c.idrevenue" + " where chkfactorydate like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //Document documento = new Document(pdf, PageSize.LETTER);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Revenue" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("(" + LoadStatus + ")"))
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
                    cliente = dr["idrevenue"].ToString();

                    arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                    int dias = fecha.Subtract(arrivdate).Days;

                    //dgvInvoice.DataSource = conectandose.ConsultarInvoice("rvpickupdrops", fecha);

                    if (dias > 60 && dias <= 90) //&& arrivdate90 <= fecha
                    {
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.RIGHT)));
                    }
                }

                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                
                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }

            else if (filtro == 2)
            {
                string cliente;
                float centro = 792 / 2;

                DateTime arrivdate;
                //DateTime fecha = new DateTime(2020, 10, 25);
                DateTime fecha = DateTime.Now;
                //string fecha2 = DateTime.Now.ToString("M/d/yyyy H:mm");
                string pay = "False";
                LoadStatus = "Past Due Invoice > 90 days - Today = " + fecha.ToString("M/d/yyyy H:mm");

                string cadena = "select p.client,p.contact,p.loadid,p.driver,p.truckid,p.trailerid,p.loaddate,p.startcityst,p.enddate,p.endcityst,p.totaltrippay,c.idrevenue,c.arrivadate from revenues as p inner join rvpickupdrops as c on p.loadid = c.idrevenue" + " where chkfactorydate like '" + pay + "'"; //loadid = '" + cliente + "'" + " and 
                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //Document documento = new Document(pdf, PageSize.LETTER);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                string[] columnas = { "Customer", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Revenue" };
                float[] anchos = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("(" + LoadStatus + ")"))
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
                    cliente = dr["idrevenue"].ToString();

                    arrivdate = Convert.ToDateTime(dr["arrivadate"]);
                    int dias = fecha.Subtract(arrivdate).Days;

                    if (dias > 90) //&& arrivdate90 <= fecha
                    {
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["client"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["contact"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["loadid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["driver"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["truckid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["trailerid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["enddate"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                        tabla.AddCell(new Cell().Add(new Paragraph(dr["totaltrippay"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.RIGHT)));
                    }
                }

                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }

            else
            {

                string pay3 = "True";
                float centro = 792 / 2;

                DateTime fecha = DateTime.Now;
                LoadStatus = "Paid Invoice to - Today = " + fecha.ToString("M/d/yyyy H:mm");

                string cadena3 = "select p.client,p.contact,p.loadid,p.driver,p.truckid,p.trailerid,p.loaddate,p.startcityst,p.enddate,p.endcityst,p.totaltrippay,c.name from revenues as p inner join brokers as c on p.client = c.name" + " where chkfactorydate like  '" + pay3 + "'";

                conn.Open();
                NpgsqlCommand comando3 = new NpgsqlCommand(cadena3, conn);
                NpgsqlDataReader dr3 = comando3.ExecuteReader();

                PdfWriter pdfWriter3 = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter3);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //Document documento3 = new Document(pdf3, PageSize.LETTER);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape);
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                string[] columnas3 = { "Broker", "Contact", "Load Id", "Driver", "Tuck Id", "Trailer Id", "End Date", "Total Revenue" };
                float[] anchos3 = { 5, 5, 3, 4, 3, 3, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos3));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("(" + LoadStatus + ")"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                foreach (string columna in columnas3)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr3.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["name"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["contact"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["loadid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["driver"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["truckid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["trailerid"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["enddate"].ToString()).SetFont(fontContenido).SetFontSize(11)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr3["totaltrippay"].ToString()).SetFont(fontContenido).SetFontSize(11).SetTextAlignment(TextAlignment.RIGHT)));

                }
                documento.Add(_tabla);
                documento.Add(tabla);
                conn.Close();
                documento.Close();
                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
