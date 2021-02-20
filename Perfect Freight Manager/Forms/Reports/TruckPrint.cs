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

    public partial class TruckPrint : Form
    {
        AplicationContext conectandose = new AplicationContext();
        NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        NpgsqlConnection conn2 = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 123456; Database = PerfectFreight");
        private string raiz = "", route = "";
        private string TruckId, TruckMiles, TruckDriver, TruckNoOrder,nombre;
        private int filtro = 0;
        private int Codigo, PrintOrder;

        public TruckPrint(string id, string miles, string driver, int codigo, string nuorder, int origen, int printorder )
        {
            InitializeComponent();
            TruckId = id;
            TruckMiles = miles;
            TruckDriver = driver;
            Codigo = codigo;
            TruckNoOrder = nuorder;
            filtro = origen;
            PrintOrder = printorder;

            conn2.Open();
            string cadena2 = "select * from adminsystems";
            NpgsqlCommand comando2 = new NpgsqlCommand(cadena2, conn2);
            NpgsqlDataReader dr2 = comando2.ExecuteReader();
            while (dr2.Read())
            {
                raiz = dr2["rphotodoc"].ToString();
                route = dr2["rprogram"].ToString();
            }
            conn2.Close();
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
                    .Add(new Paragraph("Order Maintenance"))
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
                Rectangle rootArea2 = new Rectangle(20, (page2.GetPageSize().GetBottom() + 45), page2.GetPageSize().GetWidth(), 105);
                new Canvas(canvas2, pdfDoc2, rootArea2).Add(getTable(docEvent2));
            }

            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 60f, 40f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();
                Style styleCell = new Style().SetBorder(new SolidBorder(ColorConstants.BLACK, 1));//Border.NO_BORDER
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
        private void crearPDF(int filtro)
        {
            string pdfdoc = raiz + @"Documents\Reporte.pdf";
            if (filtro == 1)//PM
            {
                string cadena = "select * from maintenancetruckpms where id=" + Codigo;
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
                    Cell cell = new Cell().Add(new Paragraph("Truck Id: " + TruckId.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Miles: " + TruckMiles.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Driver: " + TruckDriver.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Order No: " + TruckNoOrder)).SetFontSize(10);
                    tabla1.AddCell(cell);
                    Table _tabla = new Table(1).UseAllAvailableWidth();
                    _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X (if applicable) or not"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    Table _tabla1 = new Table(1).UseAllAvailableWidth();
                    _tabla1.AddCell(new Cell().Add(new Paragraph("PREVENT Maintenance (PM)"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER));

                    //Encabezado de Tabla
                    string[] columnas = { "Item", "Description" };
                    float[] anchos = { 2, 5 };
                    Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento2.SetMargins(168, 20, 55, 20);
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Table _tabla2 = new Table(1).UseAllAvailableWidth();
                    _tabla2.AddCell(new Cell().Add(new Paragraph("Write Incidense and Expense for PM"))
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
                    documento3.SetMargins(605, 20, 55, 20);
                    Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos2));
                    tabla3.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead2 = new Style().SetFont(fontColumnas).SetFontSize(11).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    foreach (string columnax in columnas2)
                    {
                        tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead)));
                    }

                    Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                    pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                    List<string> names = new List<string> { "<name>", "Engine oil and filter changes", "Transmission fluid", "Fuel system", "Cooling system", "Engine and transmission mounts", "Drive shafts or CV joints", "Belts and hoses", "Tune-ups", "Electrical system components", "Braking system", "Steering and suspension system", "Tires", "Wheels & rims", "Exhaust system", "Undercarriage and frame", "Exterior and interior lights", "Body, glass and mirrors", "Windshield wiper system", "Horn", "Seat belts and seat structure", "Fluid leaks", "Auxiliary systems" };

                    for (int i = 1; i < 23; i++)
                    {
                        if (PrintOrder == 1)
                        {
                            if (Convert.ToInt32(dr["pm" + i.ToString()].ToString()) < 100)
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
                    document.Add(_tabla1);
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
            else if (filtro == 2)//T2
            {
                string cadena = "select * from maintenancetrucktipo2s where id=" + Codigo;
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
                    //A4 document measures 210 mm x 297 mm, or 8.5 in. × 14 in
                    PageSize lanscape = new PageSize(1008, 612);
                    PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    ///////////////////////////////
                    /// Adicionando contenido
                    /// y poniendo propiedades
                    ///////////////////////////////
                    //Encabezado Principal
                    Document document = new Document(pdfDocument, lanscape);
                    document.SetMargins(108, 20, 55, 20);
                    float[] ancho = { 3, 3, 5, 5 };
                    Table tabla1 = new Table(UnitValue.CreatePercentArray(ancho)); //(UnitValue.CreatePercentArray(anchos));
                    tabla1.SetWidth(UnitValue.CreatePercentValue(100));
                    Cell cell = new Cell().Add(new Paragraph("Truck Id: " + TruckId.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Miles: " + TruckMiles.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Driver: " + TruckDriver.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Order No: " + TruckNoOrder)).SetFontSize(10);
                    tabla1.AddCell(cell);
                    Table _tabla = new Table(1).UseAllAvailableWidth();
                    _tabla.AddCell(new Cell().Add(new Paragraph("15-20 Mmiles Maintenance (T2)                             Prt=Pre-Trip, Pot=Post-Trip, RR=Require Reparation"))
                        .SetFont(fontContenido).SetFontSize(12)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER));
                    //Encabezado de Tabla
                    string[] columnas2 = { "TRUCK/TRACTOR", "TRAILER" };
                    float[] anchos = { 5, 3 };
                    Document documento2 = new Document(pdfDocument, lanscape); //PageSize.LETTER
                    documento2.SetMargins(148, 20, 55, 20);
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead2 = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);

                    foreach (string columna in columnas2)
                    {
                        tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead2)));
                    }
                    string[] columnas3 = { "Prt", "Pot", "RR", "ITEM", "Prt", "Pot", "RR", "ITEM", "Prt", "Pot", "RR", "ITEM", "Prt", "Pot", "RR", "ITEM" };
                    float[] anchos3 = { 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 1, 5 };
                    Document documento3 = new Document(pdfDocument, lanscape); //PageSize.LETTER
                    documento3.SetMargins(170, 20, 55, 20);
                    Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos3)); //(UnitValue.CreatePercentArray(anchos));
                    tabla3.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead3 = new Style().SetFont(fontColumnas).SetFontSize(9).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    foreach (string columnax in columnas3)
                    {
                        tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead3)));
                    }
                    //Encabezado Notes
                    string[] columnas4 = { "Notes" };
                    float[] anchos4 = { 5 };
                    Document documento4 = new Document(pdfDocument, lanscape); //PageSize.LETTER
                    documento4.SetMargins(490, 20, 55, 20);
                    Table tabla4 = new Table(UnitValue.CreatePercentArray(anchos4)); //(UnitValue.CreatePercentArray(anchos));
                                                                                     //tabla3.SetRelativePosition(10, 300, 20, 55);
                    tabla4.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead4 = new Style().SetFont(fontColumnas).SetFontSize(11).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    foreach (string columnay in columnas4)
                    {
                        tabla4.AddHeaderCell(new Cell().Add(new Paragraph(columnay).AddStyle(styleHead4)));
                    }

                    Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));
                    //Image img2 = new Image(ImageDataFactory.Create(route + @"inoutbound.png"));
                    pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                    //pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new HeaderEventHandler2(img2));
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                    List<string> names = new List<string> { "<name>", "1.Air Compressor", "18.Front Axle", "32.Safely Equipment", "49.Brake Connection", "2.Air Lines", "19.Fuel Tank", "33.Fire Extinguisher", "50.Brakers", "3.Battery", "20.Generator", "34.Flags-Flares-Fusses", "51.Coupling Devices", "4.Belts & Hoses", "21.Horn", "35.Reflective Triangles", "52.Coupling(King) Pin", "5.Body", "22.Lights", "36.Spare Bulbs &Fuses", "53.Door", "6.Brake Accessories", "23.Head-Stop", "37.Spare Seal Beam", "54.Hitch", "7.Brakers, Patking", "24.Tail-Dash", "38.Starter", "55.Landing Gear", "8.Brakers, Service", "25.Tum Indicators", "39.Steering", "56.Lights-All", "9.Clutch", "26.Mirros", "40.Suspension System", "57.Reflectros/Reflective Tape", "10.Coupling Devices", "27.Mufflers", "41.Tire Chains", "58.Roof", "11.Defroster/Heater", "28.Oil Level", "42.Tires", "59.Starp", "12.Drive Line", "29.Radiador Level", "43.Transmission", "60.Suspension System", "13.Engine", "30.Rear End", "44.Trip Recorder", "61.Tarpaulin", "14.Exhaust", "31.Reflectors", "45.Wheels & Rims", "62.Tires", "15.Fith Wheel", " ", "46.Windows", "63.Wheels & Rims", "16.Fluid Level", " ", "47.Windshield", "64.Other", "17.Frame & Assembly", " ", "48.Other", " " };

                    List<string> names2 = new List<string> { "<name>", "1.Air Compressor", "2.Air Lines", "3.Battery", "4.Belts & Hoses", "5.Body", "6.Brake Accessories", "7.Brakers, Patking", "8.Brakers, Service", "9.Clutch", "10.Coupling Devices", "11.Defroster/Heater", "12.Drive Line", "13.Engine", "14.Exhaust", "15.Fith Wheel", "16.Fluid Level", "17.Frame & Assembly", "18.Front Axle", "19.Fuel Tank", "20.Generator", "21.Horn", "22.Lights", "23.Head-Stop", "24.Tail-Dash", "25.Tum Indicators", "26.Mirros", "27.Mufflers", "28.Oil Level", "29.Radiador Level", "30.Rear End", "31.Reflectors", "32.Safely Equipment", "33.Fire Extinguisher", "34.Flags-Flares-Fusses", "35.Reflective Triangles", "36.Spare Bulbs &Fuses", "37.Spare Seal Beam", "38.Starter", "39.Steering", "40.Suspension System", "41.Tire Chains", "42.Tires", "43.Transmission", "44.Trip Recorder", "45.Wheels & Rims", "46.Windows", "47.Windshield", "48.Other", "49.Brake Connection", "50.Brakers", "51.Coupling Devices", "52.Coupling(King) Pin", "53.Door", "54.Hitch", "55.Landing Gear", "56.Lights-All", "57.Reflectros/Reflective Tape", "58.Roof", "59.Starp", "60.Suspension System", "61.Tarpaulin", "62.Tires", "63.Wheels & Rims", "64.Other" };

                    if (PrintOrder == 1)
                    {
                        for (int i = 1; i < 69; i++)
                        {
                            if (i == 33 || i == 34 || i == 35 || i > 64)
                            {
                                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                            }
                            else
                            {
                                //0,0,0
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) == 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) == 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) == 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //0,0,1
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) == 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) == 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) < 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //0,1,1
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) == 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) < 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) < 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //0,1,0
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) == 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) < 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) == 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //1,1,1
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) < 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) < 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) < 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //1,1,0
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) < 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) < 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) == 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //1,0,0
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) < 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) == 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) == 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                                //1,0,1
                                if (Convert.ToInt32(dr["prt" + i.ToString()].ToString()) < 100 && Convert.ToInt32(dr["pot" + (i).ToString()].ToString()) == 100 && Convert.ToInt32(dr["rr" + (i).ToString()].ToString()) < 100)
                                {
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9)));
                                    tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 69; i++)
                        {
                            tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                            tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                            tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                            tabla3.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                        }
                    }
                    document.Add(tabla1);
                    document.Add(_tabla);
                    documento2.Add(tabla2);
                    documento3.Add(tabla3);
                    documento4.Add(tabla4);
                    document.Close();
                    documento2.Close();
                    documento3.Close();
                    documento4.Close();
                }
                conn.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
                
            }
            else if (filtro == 3)//T3
            {
                string cadena = "select * from maintenancetrucktipo3s where id=" + Codigo;
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
                    Cell cell = new Cell().Add(new Paragraph("Truck Id: " + TruckId.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Miles: " + TruckMiles.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Driver: " + TruckDriver.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Order No: " + TruckNoOrder)).SetFontSize(10);
                    tabla1.AddCell(cell);
                    Table _tabla = new Table(1).UseAllAvailableWidth();
                    _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X (if applicable) or not"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    Table _tabla1 = new Table(1).UseAllAvailableWidth();
                    _tabla1.AddCell(new Cell().Add(new Paragraph("30-60 Mmiles Maintenance (T3)"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER));

                    //Encabezado de Tabla
                    string[] columnas = { "Item", "Description" };
                    float[] anchos = { 2, 5 };
                    Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento2.SetMargins(168, 20, 55, 20);
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Table _tabla2 = new Table(1).UseAllAvailableWidth();
                    _tabla2.AddCell(new Cell().Add(new Paragraph("Write Incidense and Expense for T3"))
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
                    documento3.SetMargins(335, 20, 55, 20);
                    Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos2)); //(UnitValue.CreatePercentArray(anchos));
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

                    List<string> names = new List<string> { "<name>", "Inspect engine air filter", "Restriction gauge and replace filter", "Replace Cabin air filter", "Replace front and rear differential fluid", "Replace transfer case fluid", "Transmission service", "Coolant replacement" };

                    for (int i = 1; i < 8; i++)
                    {
                        if (PrintOrder == 1)
                        {
                            if (Convert.ToInt32(dr["t3p" + i.ToString()].ToString()) < 100)
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
                    document.Add(_tabla1);
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
            else if (filtro == 4)//SM
            { 
                string cadena = "select * from maintenancesummers where id=" + Codigo;
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
                    float[] ancho = { 3, 5, 5 };
                    Table tabla1 = new Table(UnitValue.CreatePercentArray(ancho)); //(UnitValue.CreatePercentArray(anchos));
                    tabla1.SetWidth(UnitValue.CreatePercentValue(100));
                    Cell cell = new Cell().Add(new Paragraph("Truck Id: " + TruckId.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Driver: " + TruckDriver.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Order No: " + TruckNoOrder)).SetFontSize(10);
                    tabla1.AddCell(cell);
                    Table _tabla = new Table(1).UseAllAvailableWidth();
                    _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X (if applicable) or not"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    Table _tabla1 = new Table(1).UseAllAvailableWidth();
                    _tabla1.AddCell(new Cell().Add(new Paragraph("SUMMER Maintenance"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER));

                    //Encabezado de Tabla 2
                    string[] columnas2 = { "Item", "Description" };
                    float[] anchos2 = { 2, 5 };
                    Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento2.SetMargins(168, 20, 55, 20);
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos2)); //(UnitValue.CreatePercentArray(anchos));
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Table _tabla3 = new Table(1).UseAllAvailableWidth();
                    _tabla3.AddCell(new Cell().Add(new Paragraph("In addition, inspect the vehicle’s electrical system including:"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetBorder(Border.NO_BORDER));
                    foreach (string columna in columnas2)
                    {
                        tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                    }
                    //Encabezado Tabla 3
                    string[] columnas3 = { "Item", "Description" };
                    float[] anchos3 = { 2, 5 };
                    Document documento3 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento3.SetMargins(405, 20, 55, 20);
                    Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos3)); //(UnitValue.CreatePercentArray(anchos));
                    tabla3.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead3 = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Table _tabla2 = new Table(1).UseAllAvailableWidth();
                    _tabla2.AddCell(new Cell().Add(new Paragraph("Write Notes for SUMMER"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    foreach (string columnax in columnas3)
                    {
                        tabla3.AddHeaderCell(new Cell().Add(new Paragraph(columnax).AddStyle(styleHead3)));
                    }

                    //Encabezado Notes
                    string[] columnas4 = { "Notes" };
                    float[] anchos4 = { 5 };
                    Document documento4 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento4.SetMargins(540, 20, 55, 20);
                    Table tabla4 = new Table(UnitValue.CreatePercentArray(anchos4)); //(UnitValue.CreatePercentArray(anchos));
                                                                                     //tabla3.SetRelativePosition(10, 300, 20, 55);
                    tabla4.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead4 = new Style().SetFont(fontColumnas).SetFontSize(11).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    foreach (string columnay in columnas4)
                    {
                        tabla4.AddHeaderCell(new Cell().Add(new Paragraph(columnay).AddStyle(styleHead4)));
                    }

                    Image img = new Image(ImageDataFactory.Create(route + @"logopf.png"));

                    pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler1(img));
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FootEventHandler1());

                    List<string> names = new List<string> { "<name>", "Inspect the radiator for corrosion and determine that the coolant is clean. Coolant should be drained and flushed a minimum of once a year", "Inspect the radiator cap for damage and replace it whenever the coolant is drained and flushed", "Do a coolant system pressure test.Such an exam should be done a minimum of once a year", "Inspect air conditioner cooling coils for damage and debris buildup.Clean when necessary", "Inspect radiator and heater core hoses and lines for damage, leaks, mushiness and hardness.Make certain that connections are tight.Replace hoses every two years", "Exam belts for wear and tear as well as tension and test the tensioner arm to assure it works properly.Replace belts every one to two years", "Exam the water pump for leaks and check to assure that the engine preserves a temperature within manufacturer’s recommendations", "Run the heater to assure that it functions properly" };

                    //for (int i = 1; i < 9; i++)
                    //{
                    //    tabla2.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                    //    tabla2.AddCell(new Cell().Add(new Paragraph(names[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                    //}
                    List<string> names2 = new List<string> { "<name>", "Alternator wiring to see if they are loose and contacting fuel lines or any rough parts", "The battery to be certain it is properly and securely mounted", "The battery cables to see if they are connected properly and fastened securely", "Look for corrosion at the battery terminals and clean if necessary", "The condition of wires" };

                    for (int i = 1; i < 9; i++)
                    {
                        if (PrintOrder == 1)
                        {
                            if (Convert.ToInt32(dr["sm" + i.ToString()].ToString()) < 100)
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
                    for (int i = 1; i < 6; i++)
                    {
                        if (PrintOrder == 1)
                        {
                            if (Convert.ToInt32(dr["sm" + (i + 8).ToString()].ToString()) < 100)
                            {
                                tabla3.AddCell(new Cell().Add(new Paragraph("X").SetFont(fontContenido).SetFontSize(9).SetTextAlignment(TextAlignment.CENTER)));
                                tabla3.AddCell(new Cell().Add(new Paragraph(names2[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                            }
                            else
                            {
                                tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                                tabla3.AddCell(new Cell().Add(new Paragraph(names2[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                            }
                        }
                        else
                        {
                            tabla3.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontContenido).SetFontSize(9)));
                            tabla3.AddCell(new Cell().Add(new Paragraph(names2[i].ToString()).SetFont(fontContenido).SetFontSize(9)));
                        }
                    }

                    document.Add(tabla1);
                    document.Add(_tabla);
                    document.Add(_tabla1);
                    documento2.Add(tabla2);
                    documento2.Add(_tabla3);
                    documento3.Add(tabla3);
                    documento3.Add(_tabla2);
                    documento4.Add(tabla4);
                    document.Close();
                    documento2.Close();
                    documento3.Close();
                    documento4.Close();
                }
                conn.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            else if (filtro == 5)//WT
            {
                string cadena = "select * from maintenancewinters where id=" + Codigo;
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
                    float[] ancho = { 3, 5, 5 };
                    Table tabla1 = new Table(UnitValue.CreatePercentArray(ancho)); //(UnitValue.CreatePercentArray(anchos));
                    tabla1.SetWidth(UnitValue.CreatePercentValue(100));
                    Cell cell = new Cell().Add(new Paragraph("Truck Id: " + TruckId.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Driver: " + TruckDriver.ToString())).SetFontSize(10);
                    tabla1.AddCell(cell);
                    cell = new Cell().Add(new Paragraph("Order No: " + TruckNoOrder)).SetFontSize(10);
                    tabla1.AddCell(cell);
                    Table _tabla = new Table(1).UseAllAvailableWidth();
                    _tabla.AddCell(new Cell().Add(new Paragraph("Mark each item with X (if applicable) or not"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    Table _tabla1 = new Table(1).UseAllAvailableWidth();
                    _tabla1.AddCell(new Cell().Add(new Paragraph("WINTER Maintenance"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(Border.NO_BORDER));
                    //Encabezado de Tabla
                    string[] columnas = { "Item", "Description" };
                    float[] anchos = { 2, 5 };
                    Document documento2 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento2.SetMargins(168, 20, 55, 20);
                    Table tabla2 = new Table(UnitValue.CreatePercentArray(anchos)); //(UnitValue.CreatePercentArray(anchos));
                    tabla2.SetWidth(UnitValue.CreatePercentValue(100));
                    Style styleHead = new Style().SetFont(fontColumnas).SetFontSize(12).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(TextAlignment.CENTER);
                    Table _tabla2 = new Table(1).UseAllAvailableWidth();
                    _tabla2.AddCell(new Cell().Add(new Paragraph("Write Notes for WINTER"))
                        .SetFont(fontContenido).SetFontSize(10)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetBorder(Border.NO_BORDER));
                    foreach (string columna in columnas)
                    {
                        tabla2.AddHeaderCell(new Cell().Add(new Paragraph(columna).AddStyle(styleHead)));
                    }

                    //Encabezado Notes
                    string[] columnas2 = { "Notes" };
                    float[] anchos2 = { 5 };
                    Document documento3 = new Document(pdfDocument, portrait); //PageSize.LETTER
                    documento3.SetMargins(685, 20, 55, 20);
                    Table tabla3 = new Table(UnitValue.CreatePercentArray(anchos2)); //(UnitValue.CreatePercentArray(anchos));
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

                    List<string> names = new List<string> { "<name>", "Diesel engines that use urea-based diesel exhaust fluid (DEF) in the emission control system. The fluid freezes at temperatures of 12° F (-11° C), but thaws under normal operation within 45 minutes", "Engine heaters. Although it is true that most medium-duty trucks feature block heaters to keep engine oil warm, some newer commercial trucks use oil-pan heaters", "The coolant to assure proper level. Coolant older than 24 months should be flushed out and replaced", "Fuel for diesel engine. In areas where temperatures can drop below 10° F(-12° C) it is important that the diesel fuel is ASTM D - 975 Grade 1, which can withstand the cold", "Glow plug operation", "Servicing the fuel filter and draining the water separator to prevent freezing", "The battery.The battery should be tested and connections cleaned", "Windshield.The windshield should be checked for chips and pitting because as temperatures get colder, sheet metal contracts causing windshields to break due to stress.Small chips should be fixed to avoid extension of cracks", "Windshield wiper blades.They should be replaced if damaged", "Windshield washer reservoirs.Regularly check to see that there are proper winter dilution levels", "Heater and defroster operation.Check the function and position of the directional vanes of the heater/ defroster to assure effective defrosting", "Tires.Inspect the condition of the tires to assure that the tread is thicker than 5 / 32 - inch for winter driving and that tires are correctly inflated.Use tire chains when driving in icy conditions", "The exhaust system for leaks", "Anti - braking system.Check ABS operation at the start of winter and monitor stroke adjustment of drum brakes, fluid levels and parking brake performance", "The cab, body and undercarriage.Clean the truck weekly to remove road salt", "Radiator.Make certain that the front surface of the radiator is clean", "Heated mirrors. Assure that the mirrors operate properly", "Belts and hoses.Check all belts and hoses and replace when necessary", "Emergency kit.Make sure that the kit includes road flares, fire extinguisher, reflective triangles, first aid kit, water, solar blanket, jumper cables and anything else you may need to survive through extreme weather overnight" };

                    for (int i = 1; i < 20; i++)
                    {
                        if (PrintOrder == 1)
                        {
                            if (Convert.ToInt32(dr["wt" + i.ToString()].ToString()) < 100)
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
                    document.Add(_tabla1);
                    documento2.Add(tabla2);
                    documento2.Add(_tabla2);
                    documento3.Add(tabla3);
                    document.Close();
                    documento2.Close();
                    documento3.Close();
                }
                conn.Close();

                axAcroPDF.src = raiz + @"Documents\Reporte.pdf";
            }
            else return;
        }

            private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
