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

namespace Perfect_Freight_Manager.Forms.Utilities
{
    public partial class frmPrintUtilities : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        int filtro = 0;
        private string raiz = "",route="";
        string pdfdoc = "";
        string pdfdoc2 = "";
    
        public frmPrintUtilities()
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

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 1;
            crearPDF(filtro);
        }

        private void driversProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 2;
            crearPDF(filtro);
        }

        private void officeEmployProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 3;
            crearPDF(filtro);
        }

        private void emailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 4;
            crearPDF(filtro);
        }

        private void faxSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtro = 5;
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
                //PdfFont Bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                
                cell = new Cell()
                    .Add(new Paragraph(""))
                    .Add(new Paragraph(""))
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
            /// COMPANY PROFILE
            ////////////////////////////////////////////////
            ///////
            if (filtro == 1)
            {
                string cadena = "select company,owner,address,address2,city,zip,email,phone,usddot,fid,mc from companyprofiles";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(612, 792); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(792, 612); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Company", "Owner", "Address", "City, St", "Code Zip", "Email", "Phone", "Usd Dot", "Fid", "Mc" };
                float[] anchos = { 4, 4, 4, 3, 3, 4, 4, 3, 3, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Company Profile )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["company"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["owner"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["zip"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["email"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["phone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["usddot"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["fid"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["mc"].ToString()).SetFont(fontContenido).SetFontSize(9)));

                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                
                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// DRIVERS PROFILES
            ////////////////////////////////////////////////
            ///////
            if (filtro == 2)
            {
                float centro = 792 / 2;
                string cadena = "select name,middlename,lastname,birthay,assignedtruck,hiredate,endservicedate,address,city,state,codezip,homephone,cellphone,email,statusdriver from driverprofiles";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(612, 792); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(792, 612); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Status", "Birthday", "Assig. Truck", "Hire Date", "End Service", "Address", "City, St", "Code Zip", "Home Phone", "Cell Phone", "Email" };
                float[] anchos = { 4, 3, 4, 4, 3, 3, 4, 4, 3, 3, 3, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Drivers Profiles )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    string statusdriver = dr["statusdriver"].ToString();
                    string newstatus = "";
                    if (statusdriver == "0")
                        newstatus = "Company Driver";
                    else newstatus = "Owner Operator";
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["name"].ToString() + " " + dr["middlename"].ToString() + " " + dr["lastname"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(newstatus).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["birthay"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["assignedtruck"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["hiredate"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["endservicedate"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString() + ", " + dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["codezip"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["homephone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["cellphone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["email"].ToString()).SetFont(fontContenido).SetFontSize(9)));

                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();
                
                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// OFFICE EMPLOYEE PROFILE
            ////////////////////////////////////////////////
            ///////
            if (filtro == 3)
            {
                float centro = 792 / 2;
                string cadena = "select firstname,middlename,lastname,birthay,hiredate,address,city,state,zip,homephone,cellphone,email  from employeeprofile";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(612, 792); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(792, 612); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Birthday", "Hire Date", "Address", "City", "State", "Code Zip", "Home Phone", "Cell Phone", "Email" };
                float[] anchos = { 4, 4, 4, 3, 3, 4, 4, 3, 3, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Employee Profile )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["firstname"].ToString() + " " + dr["middlename"].ToString() + " " + dr["lastname"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["birthay"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["hiredate"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["address"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["city"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["state"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["zip"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["homephone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["cellphone"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["email"].ToString()).SetFont(fontContenido).SetFontSize(9)));

                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// EMAIL SETTINGS
            ////////////////////////////////////////////////
            ///////
            if (filtro == 4)
            {
                float centro = 792 / 2;
                string cadena = "select nombre,clave,port,principal,smtp,ssl from emailsettings";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(612, 792); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(792, 612); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Password", "Port", "Default", "SMTP", "SSL" };
                float[] anchos = { 4, 4, 4, 4, 4, 4 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Email Setting )"))
                    .SetFont(fontContenido).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));
                foreach (string columna in columnas)
                {
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                }

                while (dr.Read())
                {
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["nombre"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["clave"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["port"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["principal"].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["smtp"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["ssl"].ToString()).SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));

                }
                conn.Close();
                documento.Add(_tabla);
                documento.Add(tabla);
                documento.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            ////////////////////////////////////////////////
            /// FAX SETTINGS
            ////////////////////////////////////////////////
            ///////
            if (filtro == 5)
            {
                float centro = 792 / 2;
                string cadena = "select name,servicecode from faxsetting";

                conn.Open();
                NpgsqlCommand comando = new NpgsqlCommand(cadena, conn);
                NpgsqlDataReader dr = comando.ExecuteReader();

                PdfWriter pdfWriter = new PdfWriter(pdfdoc);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                //1 pulg = 72 pt (8.5 x 11) ~ (612 x 792) PageSize pagina = new PageSize(612, 792); Portrait
                //1 pulg = 72 pt (11 x 8.5) ~ (792 x 612) PageSize pagina = new PageSize(792, 612); Lanscape
                PageSize landscape = new PageSize(792, 612);
                Document documento = new Document(pdfDocument, landscape); //PageSize.LETTER
                documento.SetMargins(158, 20, 55, 20);
                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                //Encabezado del Trip
                string[] columnas = { "Name", "Service Code" };
                float[] anchos = { 5, 5 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchos));
                tabla.SetWidth(UnitValue.CreatePercentValue(100));
                Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());
                Table _tabla = new Table(1).UseAllAvailableWidth();
                _tabla.AddCell(new Cell().Add(new Paragraph("( Catalog Fax Setting )"))
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
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["servicecode"].ToString()).SetFont(fontContenido).SetFontSize(9)));

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
