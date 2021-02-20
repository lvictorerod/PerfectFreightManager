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

namespace Perfect_Freight_Manager.Forms.ExpensesInvoices
{
    public partial class frmPrintExpenses : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string raiz = "",route="";
        public frmPrintExpenses()
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
        }

        private void printExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPdf();
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
                //PdfFont Bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                
                cell = new Cell()
                    .Add(new Paragraph(""))
                    .Add(new Paragraph(""))
                    .Add(new Paragraph("Perfect Freight Inc."))
                    .Add(new Paragraph("( Expenses by Invoice )"))
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
        private void CrearPdf()
        {
            string pdfdoc = raiz + @"Documents\Reporte.pdf";

            string cadena = "select invoicenumber,vendor,city,state,address,date,payment,truck,trailer from expenses";

            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();

            PdfWriter pdfWriter = new PdfWriter(pdfdoc);
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
            Document documento = new Document(pdfDocument, PageSize.LETTER);
            documento.SetMargins(158, 20, 55, 20);
            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //Encabezado del Trip
            string[] columnas = { "Vendor", "City", "State", "Address", "Date", "Payment", "Tuck Id", "Trailer Id", };
            float[] anchos = { 5, 5, 4, 4, 4, 4, 5, 5 };
            Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            Style styleCabeza = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.CYAN);
            Style styleSub = new Style().SetFontSize(9).SetBackgroundColor(ColorConstants.YELLOW);
            Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
            Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
            foreach (string columna in columnas)
            {
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
            }

            while (dr.Read())
            {

                string Loadid = dr["invoicenumber"].ToString();

                tabla.AddCell(new Cell().Add(new Paragraph(dr["vendor"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["date"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["payment"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["truck"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));
                tabla.AddCell(new Cell().Add(new Paragraph(dr["trailer"].ToString()).SetFont(fontContenido).AddStyle(styleCabeza).SetTextAlignment(TextAlignment.CENTER)));


                string cadena2 = "select p.idexpense, p.tripid, p.expensecategory, p.description, p.price, c.invoicenumber from exresumens as p inner join expenses as c on p.idexpense = c.invoicenumber order by p.idexpense"; 
                conn2.Open();
                NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
                NpgsqlDataReader dr2 = comando2.ExecuteReader();

                while (dr2.Read()) //for (int j=0; j <= largo; j++)
                {
                    string idExpense = dr2["idexpense"].ToString();
                    if (idExpense == Loadid)
                    {
                        tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("").SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("Trip Id: " + dr2["tripid"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("Category: " + dr2["expensecategory"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("Description: " + dr2["description"].ToString()).SetFont(fontContenido).AddStyle(styleSub)));
                        tabla.AddCell(new Cell().Add(new Paragraph("Price:" + dr2["price"].ToString()).SetFont(fontContenido).AddStyle(styleSub).SetTextAlignment(TextAlignment.RIGHT)));
                    }
                }
                conn2.Close();
            }
            conn.Close();
            documento.Add(tabla);
            documento.Close();

            axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
        }

        private void quitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
