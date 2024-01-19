using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
//using Gma.QrCodeNet.Encoding;
//using Gma.QrCodeNet.Encoding.Windows.Render;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Font = iTextSharp.text.Font;
//using Image = iTextSharp.text.Image;
//using Rectangle = iTextSharp.text.Rectangle;
//using SharpZebra.Printing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
//using LibUsbDotNet.Main;
//using LibUsbDotNet;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmImprimeCalibre : Form
    {
        public FrmImprimeCalibre()
        {
            InitializeComponent();
        }

        public void MostrarCalibres()
        {
            MySqlCommand comando;
            try
            {
                datalistado.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcalibre_ultimo_nro", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Calibre c = new Calibre();
                        c.calibre = Convert.ToInt32(reader["calibre"]);
                        c.ultimo_nro_print = Convert.ToInt32(reader["ultimo_nro_print"]);
                        datalistado.Rows.Add(c.calibre, c.ultimo_nro_print);
                    }
                    //lblnro_reg.Text = datalistado.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        private void LlenarComboBoxImpresoras()
        {
            // Obtener la colección de impresoras instaladas
            System.Drawing.Printing.PrinterSettings.StringCollection impresoras = System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            // Limpiar el ComboBox antes de agregar las impresoras
            cbximpresora.Items.Clear();

            // Agregar cada impresora al ComboBox
            foreach (string impresora in impresoras)
            {
                cbximpresora.Items.Add(impresora);
            }

            // Seleccionar la primera impresora en la lista (si hay al menos una)
            if (cbximpresora.Items.Count > 0)
            {
                cbximpresora.SelectedIndex = 0;
            }
        }

        private void FrmImprimeCalibre_Load(object sender, EventArgs e)
        {
            MostrarCalibres();
            LlenarComboBoxImpresoras();
        }

        void ActualizarCalibreQR(int li_calibre, int li_cantidad) {

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblcalibre_update_ultimo_nro", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_calibre", li_calibre);
                comando.Parameters.AddWithValue("p_cantidad", li_cantidad);
                comando.ExecuteNonQuery();
                MessageBox.Show("CANTIDAD DE ETIQUETAS ACTUALIZADA SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LimpiarCampos();
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        //private void btnimprimir_Click(object sender, EventArgs e)
        //{           

        //    int li_calibre = Convert.ToInt32(nudcalibre.Value.ToString());
        //    int nro_etiquetas = Convert.ToInt32(nudacantidad.Value.ToString());

        //    ActualizarCalibreQR(li_calibre, nro_etiquetas);
        //    GenerarCalibreQR(li_calibre.ToString(), nro_etiquetas);
        //}

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //void GenerarCalibreQR(string ls_calibre, int li_cantidad) 
        //{
        //    // Configurar el codificador QR
        //    QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
        //    QrCode qrCode;
        //    qrEncoder.TryEncode(ls_calibre, out qrCode);

        //    // Configurar el renderizador QR
        //    GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

        //    // Crear un bitmap para el código QR
        //    DrawingSize dSize = renderer.SizeCalculator.GetSize(qrCode.Matrix.Width);
        //    Bitmap imagenQR = new Bitmap(dSize.CodeWidth, dSize.CodeWidth);

        //    // Renderizar el código QR en el bitmap
        //    using (Graphics g = Graphics.FromImage(imagenQR))
        //    {
        //        // Rellenar el fondo blanco
        //        g.FillRectangle(Brushes.White, 0, 0, imagenQR.Width, imagenQR.Height);

        //        // Renderizar el código QR con borde negro
        //        renderer.Draw(g, qrCode.Matrix);

        //        // Añadir el texto en el centro con borde negro y fondo blanco
        //        using (System.Drawing.Font font = new System.Drawing.Font("Arial", 18, FontStyle.Bold))
        //        {
        //            SizeF textSize = g.MeasureString(ls_calibre, font);
        //            float x = (imagenQR.Width - textSize.Width) / 2;
        //            float y = (imagenQR.Height - textSize.Height) / 2;

        //            // Dibujar el texto con borde negro y fondo blanco
        //            using (Pen pen = new Pen(Brushes.Black, 2))
        //            {
        //                g.DrawRectangle(pen, x, y, textSize.Width, textSize.Height);
        //                g.FillRectangle(Brushes.White, x, y, textSize.Width, textSize.Height);
        //                g.DrawString(ls_calibre, font, Brushes.Black, x, y);
        //            }
        //        }
        //    }

        //    imagenQR.Save("codigoQR.png");

        //    string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_calibre + ".pdf");
        //    using (FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        Document doc = new Document();
        //        PdfWriter writer = PdfWriter.GetInstance(doc, fs);

        //        doc.Open();

        //        PdfPTable table = new PdfPTable(5);
        //        table.DefaultCell.Padding = 0;
        //        iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9); // Fuente en negrita
        //        for (int i = 0; i < li_cantidad; i++)
        //        {
        //            string fileName = "codigoQR.png";

        //            // Obtener la ruta de la carpeta bin de la aplicación
        //            string binFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //            // Combinar la ruta de la carpeta bin con el nombre del archivo
        //            string filePath = Path.Combine(binFolderPath, fileName);

        //            // Crear un objeto Image con la imagen
        //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(filePath);

        //            PdfPCell qrCell = new PdfPCell();
        //            qrCell.PaddingTop = 1;
        //            qrCell.Border = 0;
        //            qrCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            qrCell.AddElement(image);

        //            table.AddCell(qrCell);
        //        }

        //        doc.Add(table);

        //        doc.Close();
        //        writer.Close();

        //        MessageBox.Show("SE GENERARON LOS QR :)", "CODIGOS QR");
        //        Close();
                
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //Impresion_ZPL();
            impresora_termico();
            /*PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintDialog pdialog = new PrintDialog();
            pdialog.Document = pd;

            if (pdialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }*/
        }

        static void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Aquí puedes definir el contenido que deseas imprimir
            /*string contenido = "PRUEBA QR";

            // Utiliza la clase Graphics para dibujar el contenido en la página
            using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12))
            {
                e.Graphics.DrawString(contenido, font, Brushes.Black, new PointF(10, 10));
            }*/

            // Configura las dimensiones de las columnas en milímetros
            float columnaWidth = 30; // 3 cm en milímetros
            float columnaHeight = 30; // 3 cm en milímetros

            // Configura las coordenadas de las columnas
            float columna1X = e.MarginBounds.Left; // Izquierda de la página
            float columna2X = columna1X + columnaWidth;
            float columna3X = columna2X + columnaWidth;
            float y = e.MarginBounds.Top; // Parte superior de la página

            // Configura la fuente
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);

            // Contenido para cada columna
            string contenidoColumna1 = "Contenido 1";
            string contenidoColumna2 = "Contenido 2";
            string contenidoColumna3 = "Contenido 3";

            // Dibuja en cada columna
            e.Graphics.DrawString(contenidoColumna1, font, Brushes.Black, 40, y);
            e.Graphics.DrawString(contenidoColumna2, font, Brushes.Black, 50, y);
            e.Graphics.DrawString(contenidoColumna3, font, Brushes.Black, 60, y);

            // Puedes ajustar la altura (y) para el siguiente conjunto de contenido
            y += columnaHeight; // Ajusta según sea necesario

            // Indica que hay más páginas si es necesario
            e.HasMorePages = false;

        }

        public void Impresion_ZPL()  // //09/09/2020
        {
            try
            {
                string cadena = "PREUBA IMPRESION ZPL EMPACADORA"; //cboproducto.Text;
                // Split con expresión regular
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(" ");
                string[] vectoraux;
                vectoraux = regex.Split(cadena);

                string s;
                PrintDialog pd = new PrintDialog();

                int imp = 0;
                for (imp = 1; imp <= 1/*txtcantidad.Text*/; imp++)
                {
                    s = "^XA" + Environment.NewLine;
                    // ' PARTE 01
                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CFI,20" + Environment.NewLine;
                    s = s + "^FO60,10^FDCORP DAMARIS^FS" + Environment.NewLine;

                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CF0,22" + Environment.NewLine;

                    s = s + "^FO60,30^FDLOTE:" + "LOTE PRUEBA"/*cbolote.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO60,55^FDTITULO:" + vectoraux[1] + "^FS" + Environment.NewLine;
                    s = s + "^FO60,80^FD" + vectoraux[2] + "  " + (vectoraux[3]) + "^FS" + Environment.NewLine;
                    s = s + "^FO60,105^FDCONERA:" + "PRUEBA CONERA"/*cboconera.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO60,130^FDFP:" + "PRUEBA PRODUCTO"/*fproduccion.Text*/ + "^FS" + Environment.NewLine;

                    // ' PARTE 02
                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CFI,20" + Environment.NewLine;
                    s = s + "^FO310,10^FDCORP DAMARIS^FS" + Environment.NewLine;

                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CF0,22" + Environment.NewLine;

                    s = s + "^FO310,30^FDLOTE:" + "LOTE PRUEBA"/*cbolote.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO310,55^FDTITULO:" + vectoraux[1] + "^FS" + Environment.NewLine;
                    s = s + "^FO310,80^FD" + vectoraux[2] + "  " + (vectoraux[3]) + "^FS" + Environment.NewLine;
                    s = s + "^FO310,105^FDCONERA:" + "PRUEBA CONERA"/*cboconera.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO310,130^FDFP:" + "PRUEBA PRODUCTO"/*fproduccion.Text*/ + "^FS" + Environment.NewLine;

                    // ' PARTE 03
                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CFI,20" + Environment.NewLine;
                    s = s + "^FO570,10^FDCORP DAMARIS^FS" + Environment.NewLine;

                    s = s + "^CF0,60" + Environment.NewLine;
                    s = s + "^CF0,22" + Environment.NewLine;

                    s = s + "^FO570,30^FDLOTE:" + "LOTE PRUEBA"/*cbolote.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO570,55^FDTITULO:" + vectoraux[1] + "^FS" + Environment.NewLine;
                    s = s + "^FO570,80^FD" + vectoraux[2] + "  " + (vectoraux[3]) + "^FS" + Environment.NewLine;
                    s = s + "^FO570,105^FDCONERA:" + "PRUEBA CONERA" /*cboconera.Text*/ + "^FS" + Environment.NewLine;
                    s = s + "^FO570,130^FDFP:" + "PRUEBA PRODUCTO"/*fproduccion.Text*/ + "^FS" + Environment.NewLine;

                    // ' FIN
                    s = s + "^XZ" + Environment.NewLine;

                    // pd.PrinterSettings = New Printing.PrinterSettings()
                    // If (pd.ShowDialog() = DialogResult.OK) Then
                    // RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s)
                    //RawPrinterHelper.SendStringToPrinter(My.Settings.Impresora_valor.ToString, s);
                    RawPrinterHelper.SendStringToPrinter(/*Properties.Settings.Default.Impresora_valor.ToString()*/"ZplPrinter", s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR...");
            }
        }

        private void impresora_termico()
        {
            try
            {
                Regex regex = new Regex(" ");
                using (PrintDialog pd = new PrintDialog())
                {
                    StringBuilder cadena = new StringBuilder();

                    cadena.AppendLine("^XA");

                    // ^FX Logo Agricola del Sur Pisco EIRL.
                    // ^FX Desing by Juan Luis Diaz Aylas.
                    cadena.AppendLine(
                   "^FO20,10^GFA,1521,1521,13,,K08,J01C,J07C,J0FE,J0FEM07FF,I01FFL0KFC,I03FFK07LF8,I07FF8I03NF,I07FF8I0OFE,I07FF8001PF," +
                   "I0IF8007PF,I0IFC01QF,I0IFC03PFE,001IFC07PFE,001IFC0QFC,001IFC1QF8,001FEF83IF8MF8,001FEF87FF07MF,001FEF8FF83MFE," +
                   "301FEF1FC1NFC,7C1FCF1E07NF8,7E1FDE381OF,7F0FDE607NFE,7F8F9C01OFC,7F8F9C03OF8,7FCFB88PF004,7FC7311OFC002,7FC7067OFI018," +
                   "7EE20COFCJ04,3F60187NFK06,3F60700MFCK03,1F60EI07JFCL018,0FA1CJ01FFO0C,07A38V06,0787W03,0187W01,008EW018,001CX0C,003CX06," +
                   "0038X06,007Y03,00FY018,00EO078M0398,01EN03FF8L0FCC,01CN0IFEK03FCC,03CM01JFK0FFC6,03CM07JF8I01FE06,078M0KFCI03E007," +
                   "078M0KFEI0F80F3,0782K01LF001C0FF3,0F00CJ03LF00707FF38,0F007J03LF80C3IF98,0F023CI03LF801JF98,0F199FI03LF80KF9C,1F1CC7C007KFE07FFC001C," +
                   "1E1EE3E607KF83FL0C,1E1F71F9C3JFC04001IF8C,1E3F3CFE703FFC001LFCE,1E3F9E7FBCJ01NFCE,1E3FDF3FDF2J03MFCE,3E3FEF9FE7CE0FF00LFCE," +
                   "3E3FEFCFFBF7E1IFC3JFC6,3E3FF7E7FDFDFC3JF0IFC6,3E3FF3F3FE7F7F8KF83FC7,3E3FFBFBFF3F9FE1KF80C7,3E3FF9F9FF9FEFFC3KF807,3E3FFDFCFFCFF3FF8LF07," +
                   "3E3FFDFEFFE7FDFFE3KFC6,3E1FFCFE7FF3FE7FF8KF86,3E1FFEFF3FFBFF3FFE1JF86,1F1FFEFFBFFDFFCIF87IF8E,1F1FFE7F9FFEFFE7FFC1IF8E," +
                   "1F0FFE7FDIF7FF3IF07FF8E,1F0IF7FCIF3FF8IFC3FF0E,1F0IF7FEIFBFFC7IF0FF0E,1F8IF3FEIFDFFE3IFC3F0E,0F87FF3FE7FFCIF1IFE1E1E," +
                   "0F87FF3FF7FFEIF8JF861C,0FC3FF3FF3IF7FFC7IFC01C,07C3FF3FF3IF7FFE3JF01C,07E3FF3FFBIF3FFE1JF83C,07E1FF3FF9IFBIF0JF838,03F0FF3FF9IF9IF83IF038," +
                   "03F0FF3FF9IFDIFC3IF078,01F87F3FFDIFCIFC1FFE07,01F87F3FFDIFCIFE0FFE0F,00FC3F3FFCIFE7IF07FC0E,00FE1F3FFCIFE7IF83F81E,007E0E3FFCIFE3IF81F01C," +
                   "003F063FFCIFE3IFC0E03C,003F823FFCIFE3IFC04038,001FC07FFCJF1IFEI078,I0FE07FFCJF1JFI0F,I0FF07FFCJF1JF020E,I07F83FFCJF1JF841E,I03FC0FFCJF0JF8C3C," +
                   "I01FE07FCJF0IFE1878,J0FF81FCJF0IFC70F8,J07FC07CJF0IF0C1F,J01FF01CJF07FC383E,K0FFC00JF07E0F07C,K07FF00JF0703E0F8,J041FFC007FFI0F81F," +
                   "J020IF8L07F07E,J0183IFK03FC1F8,K060JF8007FF03F,K0303NFC0FC,L0C07LFE03F8,L07007KF01FE,L01E007IF007F8,M07CL03FE,N0FCJ07FF,N03FF0JFC," +
                   "O07KFC,P03IF8,,^FS");

                    //    ^FX Top section with logo, name and address.
                    cadena.AppendLine("^CF0,90");
                    cadena.AppendLine("^FO220,20^FDRECEPCION^FS");

                    //   ^FX Titulo con Informacion requerida.
                    cadena.AppendLine("^CF0,40");
                    cadena.AppendLine("^FO20,200 ^FDFECHA DE RECEPCION :^FS");

                    cadena.AppendLine("^FO20,250 ^FDGUIA DE REMISION :^FS");
                    cadena.AppendLine("^FO20,300 ^FDCLP :^FS");
                    cadena.AppendLine("^FO20,350 ^FDPRODUCTOR :^FS");
                    cadena.AppendLine("^FO20,440 ^FDVARIEDAD :^FS");
                    cadena.AppendLine("^FO20,490 ^FDNo JABAS: ^FS");
                    cadena.AppendLine("^FO20,540 ^FDPESO NETO: ^FS");

                    //    ^FX Informacion que se necesita.
                    cadena.AppendLine("^CF0,40");
                    cadena.AppendLine("^FO420,200 ^FD" + "01/01/2024"/*lblfecharecepcion.Text*/ + " ^FS");
                    cadena.AppendLine("^FO420,250 ^FD" + "T202-00001"/*lblguiaremision.Text*/ + " ^FS");
                    cadena.AppendLine("^FO420,300 ^FD" + "0123456789"/*lblclp2.Text*/ + " ^FS");

                    //    int contartexto = lblproductor2.ToString().Length;

                    //   int longitudLimite = 16;


                    //if (lblproductor2.Text .Length > longitudLimite)
                    //    {
                    //     int indiceEspacio = lblproductor2.Text.IndexOf(' ', longitudLimite);

                    //     if (indiceEspacio != -1)
                    //     {
                    //         lblproductor2.Text = lblproductor2.Text.Substring(0, indiceEspacio);
                    //     }
                    //    }

                    cadena.AppendLine("^FO420,350 ^FD" + "PABLO CORZO"/*(lblproductor2.Text)*/ + " ^FS"); // 16 espacios

                    cadena.AppendLine("^FO420,440 ^FD" + "HASS"/*lblvariedad.Text*/ + " ^FS");
                    cadena.AppendLine("^FO420,490 ^FD" + "30"/*lbljabas.Text*/ + " ^FS");
                    cadena.AppendLine("^FO420,540 ^FD" + "2500"/*lblpesoneto.Text*/ + " ^FS");

                    //    ^ FX Contorno
                    cadena.AppendLine("^FO5,5 ^GB830,580,3 ^FS");

                    cadena.AppendLine("^XZ");

                    RawPrinterHelper.SendStringToPrinter(/*Properties.Settings.Default.Impresora_valor.ToString()*/"ZplPrinter", cadena.ToString());
                    cadena.Clear();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
