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
    public partial class TrailerPrint : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        int filtro = 0; 
        private string raiz = "", route = "";
        private string TrailerId, TrailerHours, TrailerDriver, TrailerNoOrder;
        private int Codigo, PrintOrder;
        public TrailerPrint(string Id, string Hours, string Driver, int codigo, string NoOrder, int printorder)
        {
            InitializeComponent();
            TrailerId = Id;
            TrailerHours = Hours;
            TrailerDriver = Driver; 
            TrailerNoOrder=NoOrder;
            Codigo = codigo;
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
                    .Add(new Paragraph("TRAILER Maintenance"))
                    .AddStyle(styleCell).AddStyle(styleText);
                tableEvent.AddCell(cell);
                return tableEvent;
            }
        }

        public class HeaderEventHandler2 : IEventHandler
        {
            Image Img2;
            public HeaderEventHandler2(Image img2)
            {
                Img2 = img2;
            }

            [Obsolete]
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent2 = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc2 = docEvent2.GetDocument();
                PdfPage page2 = docEvent2.GetPage();

                PdfCanvas canvas2 = new PdfCanvas(page2.NewContentStreamAfter(), page2.GetResources(), pdfDoc2);
                Rectangle rootArea2 = new Rectangle(120, (page2.GetPageSize().GetBottom() + 165), page2.GetPageSize().GetWidth(), 105);
                new Canvas(canvas2, pdfDoc2, rootArea2).Add(getTable(docEvent2));
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 60f, 40f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();
                Style styleCell = new Style().SetBorder(new SolidBorder(ColorConstants.BLACK,1));//Border.NO_BORDER
                Cell cell = new Cell().Add(Img2.SetAutoScale(true));
                tableEvent.AddCell(cell.AddStyle(styleCell).SetTextAlignment(TextAlignment.CENTER));
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
            string cadena = "select * from maintenancetrailers where id=" + Codigo;
            conn.Open();
            NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
            NpgsqlDataReader dr = comando.ExecuteReader();
            
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
            //A4 document measures 210 mm x 297 mm, or 8.5 in. × 14 in
            PageSize portrait = new PageSize(612, 1008);
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
            Cell cell = new Cell().Add(new Paragraph("Trailer Id: " + TrailerId.ToString())).SetFontSize(10);
            tabla1.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Hours: " + TrailerHours.ToString())).SetFontSize(10);
            tabla1.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Driver: " + TrailerDriver.ToString())).SetFontSize(10);
            tabla1.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Order No: " + TrailerNoOrder)).SetFontSize(10);
            tabla1.AddCell(cell);
            Table _tabla = new Table(1).UseAllAvailableWidth();
            _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X as 'OK' or 'NR' (Need Repair)"))
                .SetFont(fontContenido).SetFontSize(10)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER));
            //Encabezado de Tabla
            string[] columnas2 = { "INBOUND", "OUTBOUND", " ", "INBOUND", "OUTBOUND", " " };
            float[] anchos = { 2, 2, 5, 2, 2, 5 };
            Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
            documento2.SetMargins(148, 20, 55, 20);
            Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
            tabla2.SetWidth(UnitValue.CreatePercentValue(100));
            Style styleHead2 = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);

            foreach (string columna in columnas2)
            {
                tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead2)));
            }
            string[] columnas3 = { "OK", "NR", "OK", "NR", "ITEM", "OK", "NR", "OK", "NR", "ITEM" };
            float[] anchos3 = { 1, 1, 1, 1, 5, 1, 1, 1, 1, 5 };
            Document documento3 = new Document(pdfDocument, portrait); //PageSize.LETTER
            documento3.SetMargins(170, 20, 55, 20);
            Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos3)); //(UnitValue.CreatePercentArray(anchos));
            tabla3.SetWidth(UnitValue.CreatePercentValue(100));
            Style styleHead3 = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
            foreach (string columnax in columnas3)
            {
                tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead3)));
            }
            List<string> names = new List<string> { "<name>", "FRONT", "RIGHT SIDE", "1. Electric & Air Connections", "25. Reflectors", "2. HeaderLoad", "26. Wheel & Lugs", "3. 5th Wheel Plate & Kingpin", "27. Brakes", "4. Lights", "28. Tires", "5. Others", "29. Lights", "LEFT SIDE", "30. Landing Gear", "6. Landing Gear", "31. Other", "7. Ligthts", "UNDERSIDE", "8. Tires", "32. Frame & Crossmembers", "9. Brakes", "33. Springs & U-Bolts", "10. Wheels & Lugs", "34. Electrical Wiring", "11. Reflectors", "35. Airlines & Hoses", "12. Other", "36. Spares Tire, Rack & Chains", "REAR", "37. Brakers", "13. Lights", "38. Other", "14. Stop, Tump & Tail Lighys", "TANK (IF APPLICABLE)", "15. Reflectors", "39. Cables", "16. Mud Flaps", "40. Dome & Gaskets", "17. Rear Bumper", "41. Valves External", "18. Doors & Latches", "42. Valves Internal", "19. Other", "43. Other", "INTERIOR (IF APPLICABLE", "REFRIG.UNIT (IF APPILC.)", "20. Floor", "44. Fuel Level", "21. Sides", "45. OIL Level", "22. Roof", "46. Belts", "23. Special Equipment", "47. Hosese & Cables", "24. Other", "48. Other" };

            Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));
            Image img2 = new Image(ImageDataFactory.Create(route + @"inoutbound.png"));
            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new HeaderEventHandler2(img2));
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

            for (int i = 1; i < 57; i++)
            {
                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                if (i == 1 || i == 2 || i == 13 || i == 18 || i == 29 || i == 34 || i == 45 || i == 46)
                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER).SetBackgroundColor(ColorConstants.LIGHT_GRAY)));
                else
                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                
            }
            if (PrintOrder == 1)
            {
                int j = 1;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["inok" + j.ToString()].ToString()) < 100)
                        tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));

                    if (Convert.ToInt32(dr["innr" + j.ToString()].ToString()) < 100)
                        tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));

                    if (Convert.ToInt32(dr["outok" + j.ToString()].ToString()) < 100)
                        tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));

                    if (Convert.ToInt32(dr["outnr" + j.ToString()].ToString()) < 100)
                        tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                    j++;
                }
            }
            document.Add(tabla1);
            document.Add(_tabla);
            documento2.Add(tabla2);
            documento3.Add(tabla3);
            document.Close();
            documento2.Close();
            documento3.Close();
            conn.Close();
            axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
        }
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
