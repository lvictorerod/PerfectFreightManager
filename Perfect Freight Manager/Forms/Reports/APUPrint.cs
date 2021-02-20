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
using iTextSharp.text;
using Npgsql;
using Org.BouncyCastle.Utilities.IO.Pem;
using Perfect_Freight_Manager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Windows.Forms;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using Paragraph = iText.Layout.Element.Paragraph;
using Rectangle = iText.Kernel.Geom.Rectangle;
namespace Perfect_Freight_Manager.Forms.Reports
{
    public partial class APUPrint : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        int filtro = 0;
        private string raiz = "", route = "";
        private string ApuId, ApuHours, ApuDriver, NoOrder;
        private int Codigo, PrintOrder;

        public APUPrint(string apuid, string apuhours,string apudriver, int codigo, string nuorder, int printorder)
        {
            InitializeComponent();
            ApuId = apuid;
            ApuHours = apuhours;
            ApuDriver = apudriver;
            Codigo = codigo;
            NoOrder = nuorder;
            PrintOrder = printorder;
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
            crearPDF();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                Rectangle rootArea = new Rectangle(35, (page.GetPageSize().GetTop() - 95), (page.GetPageSize().GetWidth() - 70), 75);
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
                    .Add(new Paragraph("APU Maintenance"))
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
        private void crearPDF()
        {
            string pdfdoc = raiz + @"Documents\Reporte.pdf";
            string cadena = "select * from maintenanceapus where id=" + Codigo;
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                MemoryStream ms = new MemoryStream();
                /////////////////////
                /// Creando la Instancia PdfWriter
                /////////////////////
                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                /////////////////////
                /// Creando el Documento
                /// y poniendo propiedades del documento
                //////////////////////////////////
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize portrait = new PageSize(612, 792);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                ///////////////////////////////
                /// Adicionando contenido
                /// y poniendo propiedades
                ///////////////////////////////
                //Encabezado Principal
                Document document = new Document(pdfDocument, portrait); //PageSize.LETTER
                document.SetMargins(108, 20, 55, 20);
                float[] ancho = { 3, 3, 5, 5 };
                Table tabla1 = new Table(UnitValue.CreatePercentArray(ancho)); //(UnitValue.CreatePercentArray(anchos));
                tabla1.SetWidth(UnitValue.CreatePercentValue(100));
                Cell cell = new Cell().Add(new Paragraph("Apu Id: " + ApuId.ToString())).SetFontSize(10);
                tabla1.AddCell(cell);
                cell = new Cell().Add(new Paragraph("Hours: " + ApuHours.ToString())).SetFontSize(10);
                tabla1.AddCell(cell);
                cell = new Cell().Add(new Paragraph("Driver: " + ApuDriver.ToString())).SetFontSize(10);
                tabla1.AddCell(cell);
                cell = new Cell().Add(new Paragraph("Order No: " + NoOrder)).SetFontSize(10);
                tabla1.AddCell(cell);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X (if applicable) or not"))
                    .SetFont(fontContenido).SetFontSize(10)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER));

                //Encabezado de Tabla
                string[] columnas = { "Item", "Description" };
                float[] anchos = { 4, 5 };
                Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                documento2.SetMargins(148, 20, 55, 20);
                Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla2 = new Table(1).UseAllAvailableWidth();
                _tabla2.AddCell(new Cell().Add(new Paragraph("Write Incidense and Expense for APU"))
                    .SetFont(fontContenido).SetFontSize(10)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER));
                foreach (string columna in columnas)
                {
                    tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                //Encabezado Incidencias y Expense
                string[] columnas2 = { "Incidense", "Expense" };
                float[] anchos2 = { 5, 5 };
                Document documento3 = new Document(pdfDocument, portrait); //PageSize.LETTER
                documento3.SetMargins(280, 20, 55, 20);
                Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                //tabla3.SetRelativePosition(10, 300, 20, 55);
                tabla3.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead2 = new Style().SetFont(fontColumnas).SetFontSize(11).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                foreach (string columnax in columnas2)
                {
                    tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead)));
                }

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                List<string> names = new List<string> { "<name>", "Belt adjustment", "Oil Change", "Oil Filter", "Fuel FIlter", "Air Filter" };

                for (int i = 1; i < 6; i++)
                {
                    if (PrintOrder == 1)
                    {
                        if (Convert.ToInt32(dr["apu" + i.ToString()].ToString()) < 100)
                        {
                            tabla2.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                            tabla2.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                        }
                        else
                        {
                            tabla2.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                            tabla2.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                        }
                    }
                    else
                    {
                        tabla2.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                        tabla2.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    }
                }
                document.Add(tabla1);
                document.Add(_tabla);
                documento2.Add(tabla2);
                documento3.Add(tabla3);
                documento2.Add(_tabla2);
                document.Close();
                documento2.Close();
                documento3.Close();
            }
            conn.Close();

            axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
        }
    }
}
