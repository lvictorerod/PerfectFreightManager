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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = iText.Layout.Element.Image;
using Rectangle = iText.Kernel.Geom.Rectangle;

namespace Perfect_Freight_Manager.Forms.Reports
{
    public partial class frmPrintSettlement : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 12345; Database = PerfectFreight");
        private string raiz = "",route="";
        private int idDriver;
        private string FactoryPaid = "True";
        string pdfdoc = "";
        string pdfdoc2 = "";
        string Dfrom, Dto;

        public frmPrintSettlement(string Zfrom, string Zto)
        {
            InitializeComponent();
            Dfrom = Zfrom;
            Dto = Zto;
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
                    .Add(new Paragraph("( Driver Paid Settlement )"))
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

        private void fIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printSettlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cadena = "select * from revenues where factorypaid >='" + Dfrom + "' and factorypaid <='" + Dto + "' and chkfactorypaid like '" + FactoryPaid + "' order by id";

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
            string[] columnas = { "Driver Name", "Paid From", "Paid To", "Date Paid", "Pay Due" };
            float[] anchos = { 5, 4, 4, 4, 3 };
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
                idDriver = Convert.ToInt32(dr["iddriver"].ToString());
                string cadena3 = "select name, lastname from driverprofiles where id = " + idDriver;
                conn2.Open();
                NpgsqlCommand comando3 = new NpgsqlCommand(cadena3, conn2);
                NpgsqlDataReader dr3 = comando3.ExecuteReader();

                while (dr3.Read())
                {
                    string nombre = dr3["name"].ToString() + " " + dr3["lastname"].ToString();
                    tabla.AddCell(new Cell().Add(new Paragraph(nombre).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["datefrompaid"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["datetopaid"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["datepaid"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(dr["totalpaydue"].ToString()).SetFont(fontContenido).SetTextAlignment(TextAlignment.RIGHT)));
                }
                conn2.Close();
            }
            conn.Close();
            documento.Add(tabla);
            documento.Close();

            //var logo = new iText.Layout.Element.Image(ImageDataFactory.Create("C:/Users/Rene/VisualStudioProjects/Perfect Freight Manager/Perfect Freight Manager/bin/Debug/Iconos/logopf.png"));
            //var plogo = new Paragraph("").Add(logo);
            //var titulo = new Paragraph("Perfect Freight Inc.");
            //string LoadStatus3 = "( Driver Paid Settlement )";
            //var loadstatu2 = new Paragraph(LoadStatus3);
            //titulo.SetTextAlignment(TextAlignment.CENTER);
            //var dfecha = DateTime.Now.ToString("M/d/yyyy H:mm");
            //var fecha = new Paragraph("Date: " + dfecha);

            //PdfDocument pdfDoc = new PdfDocument(new PdfReader(pdfdoc), new PdfWriter(pdfdoc2));
            //Document doc = new Document(pdfDoc);

            //int numeros = pdfDoc.GetNumberOfPages();

            //for (int i = 1; i <= numeros; i++)
            //{
            //    PdfPage pagina = pdfDoc.GetPage(i);
            //    float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
            //    doc.ShowTextAligned(plogo, 20, y, i, TextAlignment.JUSTIFIED, VerticalAlignment.TOP, 0);
            //    doc.ShowTextAligned(titulo.SetFontSize(14), centro, y - 59, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //    doc.ShowTextAligned(loadstatu2.SetFontSize(14), centro, y - 74, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //    doc.ShowTextAligned(fecha.SetFontSize(11), 612, y - 89, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            //    //Pie de Pagina
            //    doc.ShowTextAligned(new Paragraph(String.Format("Pagina {0} de {1}", i, numeros)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            //}

            //doc.Close();

            axAcroPDF.src = raiz + @"Documents/Reporte.pdf";
        }
    }
}
