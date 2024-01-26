using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using RawDataPrint;
using System.Data;

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
                //MessageBox.Show("CANTIDAD DE ETIQUETAS ACTUALIZADA SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnimprimir_Click(object sender, EventArgs e)
        { 
            int li_calibre = Convert.ToInt32(nudcalibre.Value.ToString());
            int nro_etiquetas = Convert.ToInt32(nudacantidad_filas.Value.ToString());

            var rpta = MessageBox.Show(
                    "¿ ESTA SEGUR@ DE IMPRIMIR "+lblcantidad_tikects.Text.Trim() + " TICKETS DEL CALIBRE " + nudcalibre.Value.ToString()+" ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                ActualizarCalibreQR(li_calibre, nro_etiquetas);
                Impresion_ZPL(li_calibre.ToString(), nro_etiquetas);
                MessageBox.Show("IMPRESION DE TICKETS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

                
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Impresion_ZPL(string ls_calibre, int li_cantidad)  
        {
            try
            {
                if (ls_calibre.Equals("8"))
                {
                    ls_calibre = "08";
                }

                string cadena;

                int imp = 0;
                for (imp = 1; imp <= li_cantidad; imp++)
                {
                    // INICIO
                    cadena = "^XA" + Environment.NewLine;

                    // COLUMNA 01
                    cadena = cadena + "^FO55,10^BQN,2,9^FDMA," + ls_calibre + "^FS" + Environment.NewLine;
                    cadena = cadena + "^FO160,135^GB70,65,65,W^FS" + Environment.NewLine;
                    /*cadena = cadena + "^FO160,135^GB70,65,3,B^FS" + Environment.NewLine;*/
                    cadena = cadena + "^CF0,65^FO165,142^FD" + ls_calibre + "^FS" + Environment.NewLine;

                    // COLUMNA 02
                    cadena = cadena + "^FO315,10^BQN,2,9^FDMA," + ls_calibre + "^FS" + Environment.NewLine;
                    cadena = cadena + "^FO420,135^GB70,65,65,W^FS" + Environment.NewLine;
                    /*cadena = cadena + "^FO420,135^GB70,65,3,B^FS" + Environment.NewLine;*/
                    cadena = cadena + "^CF0,65^FO425,142^FD" + ls_calibre + "^FS" + Environment.NewLine;

                    // COLUMNA 03
                    cadena = cadena + "^FO580,10^BQN,2,9^FDMA," + ls_calibre + "^FS" + Environment.NewLine;
                    cadena = cadena + "^FO685,135^GB70,65,65,W^FS" + Environment.NewLine;
                    /*cadena = cadena + "^FO685,135^GB70,65,3,B^FS" + Environment.NewLine;*/
                    cadena = cadena + "^CF0,65^FO690,142^FD" + ls_calibre + "^FS" + Environment.NewLine;

                    // FIN
                    cadena = cadena + "^XZ" + Environment.NewLine;
                    RawPrinterHelper.EnviarCadenaToImpresora(cbximpresora.Text.Trim(), cadena);
                    cadena = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR...");
            }
        }

        private void cbximpresora_SelectedValueChanged(object sender, EventArgs e)
        {
            SetImpresoraPredeterminada(cbximpresora.Text.ToString());
        }
        private void SetImpresoraPredeterminada(string nombreImpresora)
        {            
            // Obtener la colección de impresoras instaladas.
            PrinterSettings.InstalledPrinters.Cast<string>().ToList();

            // Obtener el valor de registro actual para la impresora predeterminada.
            string keyName = @"Software\Microsoft\Windows NT\CurrentVersion\Windows";
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true);

            // Establecer la impresora seleccionada como predeterminada.
            key.SetValue("Device", nombreImpresora + "," + "winspool", Microsoft.Win32.RegistryValueKind.String);
            
        }

        private void nudacantidad_filas_ValueChanged(object sender, EventArgs e)
        {
            lblcantidad_tikects.Text = Convert.ToString(Convert.ToInt32(nudacantidad_filas.Value) * Convert.ToInt32(lblcolumnas.Text.Trim()));
        }


        //static void PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    // Aquí puedes definir el contenido que deseas imprimir
        //    /*string contenido = "PRUEBA QR";

        //    // Utiliza la clase Graphics para dibujar el contenido en la página
        //    using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12))
        //    {
        //        e.Graphics.DrawString(contenido, font, Brushes.Black, new PointF(10, 10));
        //    }*/

        //    // Configura las dimensiones de las columnas en milímetros
        //    float columnaWidth = 30; // 3 cm en milímetros
        //    float columnaHeight = 30; // 3 cm en milímetros

        //    // Configura las coordenadas de las columnas
        //    float columna1X = e.MarginBounds.Left; // Izquierda de la página
        //    float columna2X = columna1X + columnaWidth;
        //    float columna3X = columna2X + columnaWidth;
        //    float y = e.MarginBounds.Top; // Parte superior de la página

        //    // Configura la fuente
        //    System.Drawing.Font font = new System.Drawing.Font("Arial", 12);

        //    // Contenido para cada columna
        //    string contenidoColumna1 = "Contenido 1";
        //    string contenidoColumna2 = "Contenido 2";
        //    string contenidoColumna3 = "Contenido 3";

        //    // Dibuja en cada columna
        //    e.Graphics.DrawString(contenidoColumna1, font, Brushes.Black, 40, y);
        //    e.Graphics.DrawString(contenidoColumna2, font, Brushes.Black, 50, y);
        //    e.Graphics.DrawString(contenidoColumna3, font, Brushes.Black, 60, y);

        //    // Puedes ajustar la altura (y) para el siguiente conjunto de contenido
        //    y += columnaHeight; // Ajusta según sea necesario

        //    // Indica que hay más páginas si es necesario
        //    e.HasMorePages = false;

        //}

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
    }
}
