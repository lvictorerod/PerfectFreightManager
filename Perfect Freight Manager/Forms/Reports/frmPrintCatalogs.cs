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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Windows.Forms;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using Paragraph = iText.Layout.Element.Paragraph;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace Perfect_Freight_Manager.Forms.Revenue
{
    public partial class frmPrintCatalogs : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        int filtro = 0;
        private string raiz = "", route = "";
        public frmPrintCatalogs()
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void brokersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filtro = 1;
            crearPDF(filtro);
        }
        private void agentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filtro = 2;
            crearPDF(filtro);
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 3;
            crearPDF(filtro);
        }

        private void agencyInsuranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 4;
            crearPDF(filtro);
        }

        private void phoneBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 5;
            crearPDF(filtro);
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 6;
            crearPDF(filtro);
        }

        private void trucksTrailersProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 7;
            crearPDF(filtro);
        }

        private void trailersProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 8;
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
            ////////////////////////////////////////////////
            /// BROKERS
            ////////////////////////////////////////////////
            ///////
            if (filtro == 1)
            {
                string pdfdoc = raiz + @"Documents\Reporte.pdf";
                string catalogo;
                string cadena = "select name,address,city,state,codezip,phonelocal,emergencynumber,email from brokers";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                MemoryStream ms = new MemoryStream();
                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document document = new Document(pdfDocument, landscape); //PageSize.LETTER
                document.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                
                int i = 1;
                //Encabezado del Trip
                string[] columnas = { "Name", "Address", "City", "State", "Code Zip", "Phone Number", "Emergency Number", "eMail"  };
                float[] anchos = { 5, 5, 3, 3, 3, 3, 3, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Brokers )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["phonelocal"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["emergencynumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["email"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                }
                conn.Close();
                document.Add(_tabla);
                document.Add(tabla);
                document.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            if (filtro == 2)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,idclient,department,phonenumber,expirationdate from agents";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Broker", "Deparment", "Phone Number", "Expiration Date" };
                float[] anchos = { 5, 5, 5, 5, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Agents )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["idclient"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["department"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["phonenumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["expirationdate"].ToString()).SetFont(fontContenido).SetFontSize(9)));

                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }
            if (filtro == 3)
            {
                string catalogo = "( Catalog Customer )";
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,ownername,address,address2,city,state,codezip,mainphonenumber from clients";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Owner", "Address", "Address2", "City", "State", "Code Zip", "Phone Number" };
                float[] anchos = { 5, 5, 5, 5, 3, 3, 3, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Customer )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["ownername"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address2"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["mainphonenumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));

                }
                conn.Close(); 
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// INSURANCE AGENCY
            ////////////////////////////////////////////////
            ///////
            if (filtro == 4)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,address,address2,contactname,phonenumber,city,state,codezip from insurances";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //Document documento = new Document(pdf, PageSize.LETTER);
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Address", "Address2", "Contact", "Phone Number", "City", "State", "Code Zip" };
                float[] anchos = { 5, 5, 4, 4, 3, 3, 3, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Insurance Agency )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address2"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["contactname"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["phonenumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9)));


                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// PHONE BOOK
            ////////////////////////////////////////////////
            ///////
            if (filtro == 5)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,lastname,address,city,state,codezip,email,homephone,mobilephone from phonebooks";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Address", "City", "State", "Code Zip", "Email", "Home Phone", "Mobile Phone" };
                float[] anchos = { 5, 5, 3, 3, 3, 4, 3, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Phone Book )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString() + " " + dr["lastname"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["email"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["homephone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["mobilephone"].ToString()).SetFont(fontContenido).SetFontSize(9)));


                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// VENDOR
            ////////////////////////////////////////////////
            ///////
            if (filtro == 6)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,category,addres,city,state,codezip,phonenumber from vendors";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612);
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                //Encabezado del Trip
                string[] columnas = { "Name", "Category", "Address", "City", "State", "Code Zip", "Phone Number" };
                float[] anchos = { 5, 5, 4, 4, 3, 3, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Vendors )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["category"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["addres"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["phonenumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));


                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// TRUCK PROFILE
            ////////////////////////////////////////////////
            ///////
            if (filtro == 7)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,ownername,trucknumber,year,make,tiresize,axles,emptywgt,fueltank,notes from trucksprofiles";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                //Encabezado del Trip
                string[] columnas = { "Name", "Owner", "Truck Number", "Year", "Make", "Tire Size", "Axles", "Empty Wgt", "Fuel Tank", "Notes" };
                float[] anchos = { 5, 5, 3, 3, 4, 4, 3, 3, 4, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Truck Profile )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["ownername"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trucknumber"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["year"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["make"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["tiresize"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["axles"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["emptywgt"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["fueltank"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["notes"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            ///TRAILER PROFILE
            ////////////////////////////////////////////////
            ///////
            if (filtro == 8)
            {
                float centro = 792 / 2;
                string pdfdoc = raiz + @"Documents\Reporte.pdf";

                string cadena = "select name,trailernumber,vinnumber,tag,year,make,tiresize,notes from trailersprofiles";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(792, 612); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(612, 792); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Tailer Number", "Vin Number", "Tag", "Year", "Make", "Tire Size", "Notes" };
                float[] anchos = { 5, 3, 4, 3, 3, 3, 4, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Trailer Profile )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["trailernumber"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["vinnumber"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["tag"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["year"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["make"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["tiresize"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["notes"].ToString()).SetFont(fontContenido).SetFontSize(9)));
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
