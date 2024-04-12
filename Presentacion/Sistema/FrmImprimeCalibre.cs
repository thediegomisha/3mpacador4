using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using RawDataPrint;
using System.Data;
using _3mpacador4.Presentacion.Reporte;
using System.Collections.Generic;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmImprimeCalibre : Form
    {
        public FrmImprimeCalibre()
        {
            InitializeComponent();
        }

        private List<string> Lista_cod = new List<string>();

        /*public void MostrarCalibres()
        {
            MySqlCommand comando = null;
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }*/

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

        private void Lista_codigos(int li_calibre, string ls_fecha_produccion)
        {
            MySqlCommand comando = null;
            try
            {
                Lista_cod.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                comando = new MySqlCommand(@"select c.codigo from tblnumerador_calibre c
                                            where c.calibre = @calibre and 
                                            c.fecha_produccion = @fecha_produccion and 
                                            item = (select max(x.item) from tblnumerador_calibre x
                                                    where x.calibre = c.calibre and x.fecha_produccion = c.fecha_produccion);", ConexionGral.conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@calibre", li_calibre);
                comando.Parameters.AddWithValue("@fecha_produccion", ls_fecha_produccion);

                Lista_cod = new List<string>();

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lista_cod.Add(reader["codigo"].ToString());
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FrmImprimeCalibre_Load(object sender, EventArgs e)
        {
            LlenarComboBoxImpresoras();

            lblfproduccion.Text = FProgramaProceso.ls_fecha_produccion;
            lbllote.Text = FProgramaProceso.ls_desc_programacion.ToString();
            lblidprogramacion.Text = FProgramaProceso.li_idprogramacion.ToString();
            //lblcalibre.Text = FProgramaProceso.li_calibre.ToString();

            lblcantidad_tikects.Text = Convert.ToString(Convert.ToInt32(nudacantidad_filas.Value) * 4);
        }

        void Numeror_x_Calibre(int li_calibre, int li_cantidad, int li_idprogramacion, string ls_fecha_produccion) {

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblnumerador_calibre_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_calibre", li_calibre);
                comando.Parameters.AddWithValue("p_cantidad", li_cantidad);
                comando.Parameters.AddWithValue("p_idprogramacion", li_idprogramacion);
                comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_produccion);
                comando.ExecuteNonQuery();
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        { 
            int li_calibre = Convert.ToInt32(nudcalibre.Value.ToString());
            int nro_etiquetas = Convert.ToInt32(nudacantidad_filas.Value.ToString());

            if (dgvlista.Rows.Count == 0)
            {
                MessageBox.Show("NO HAY INFORMACION PARA IMPRIMIR TICKETS", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpta = MessageBox.Show("¿ ESTA SEGUR@ DE IMPRIMIR "+lblcantidad_tikects.Text.Trim() + " TICKETS DEL CALIBRE " + nudcalibre.Value.ToString()+" ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
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
                for (imp = 0; imp <= dgvlista.Rows.Count - 1; imp++)
                {
                    string ls_codigo1 = "", ls_codigo2 = "", ls_codigo3 = "", ls_codigo4 = "";
                    string ls_print1 = "", ls_print2 = "", ls_print3 = "", ls_print4 = "";

                    ls_codigo1 = dgvlista.Rows[imp].Cells[0].Value != null ? dgvlista.Rows[imp].Cells[0].Value.ToString() : "";
                    ls_print1 = ls_codigo1 != "" ? ls_codigo1.Substring(12,2) : "";
                    
                    ls_codigo2 = dgvlista.Rows[imp].Cells[1].Value != null ? dgvlista.Rows[imp].Cells[1].Value.ToString() : "";
                    ls_print2 = ls_codigo2 != "" ? ls_codigo2.Substring(12,2) : "";
                    
                    ls_codigo3 = dgvlista.Rows[imp].Cells[2].Value != null ? dgvlista.Rows[imp].Cells[2].Value.ToString() : "";
                    ls_print3 = ls_codigo3 != "" ? ls_codigo3.Substring(12,2) : "";
                    
                    ls_codigo4 = dgvlista.Rows[imp].Cells[3].Value != null ? dgvlista.Rows[imp].Cells[3].Value.ToString() : "";
                    ls_print4 = ls_codigo4 != "" ? ls_codigo4.Substring(12,2) : "";

                    // INICIO
                    cadena = "^XA" + Environment.NewLine;

                    // COLUMNA 01
                    cadena = cadena + "^FO15,15^BQN,2,6^FDMA," + ls_codigo1 + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,40^FO140,70^FD" + ls_print1 + "^FS" + Environment.NewLine;

                    // COLUMNA 02
                    cadena = cadena + "^FO230,15^BQN,2,6^FDMA," + ls_codigo2 + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,40^FO355,70^FD" + ls_print2 + "^FS" + Environment.NewLine;
                    
                    // COLUMNA 03
                    cadena = cadena + "^FO445,15^BQN,2,6^FDMA," + ls_codigo3 + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,40^FO570,70^FD" + ls_print3 + "^FS" + Environment.NewLine;
                    
                    //COLUMNA 04
                    cadena = cadena + "^FO652,15^BQN,2,6^FDMA," + ls_codigo4 + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,40^FO777,70^FD" + ls_print4 + "^FS" + Environment.NewLine;

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

        private void btngenerar_Click(object sender, EventArgs e)
        {

            int li_calibre = 0, li_cantidad = 0, li_idprogramacion = 0;
            string ls_fecha_produccion = "";

            li_calibre = Convert.ToInt32(nudcalibre.Value.ToString());
            li_cantidad = Convert.ToInt32(lblcantidad_tikects.Text.Trim());
            li_idprogramacion = Convert.ToInt32(lblidprogramacion.Text.Trim());
            ls_fecha_produccion = Convert.ToDateTime(lblfproduccion.Text).ToString("yyyy-MM-dd");

            var rpta = MessageBox.Show("¿ ESTA SEGURO DE GENERAR " + li_cantidad.ToString() + " TICKETS DEL CALIBRE "+ li_calibre.ToString() + " DE FECHA : " + lblfproduccion.Text.Trim() + " ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                dgvlista.Rows.Clear();

                Numeror_x_Calibre(li_calibre, li_cantidad, li_idprogramacion, ls_fecha_produccion);

                Lista_codigos(li_calibre, ls_fecha_produccion);

                List<List<string>> filasSeparadas = SepararEnFilas(Lista_cod, 4);

                foreach (var fila in filasSeparadas)
                {
                    dgvlista.Rows.Add(fila.ToArray());
                }
            }              
        }

        static List<List<string>> SepararEnFilas(List<string> listaOriginal, int columnasPorFila)
        {
            List<List<string>> filasSeparadas = new List<List<string>>();

            for (int i = 0; i < listaOriginal.Count; i += columnasPorFila)
            {
                // Obtiene una porción de la lista con el número de columnas especificado
                List<string> fila = listaOriginal.GetRange(i, Math.Min(columnasPorFila, listaOriginal.Count - i));

                // Agrega la fila a la lista de filas separadas
                filasSeparadas.Add(fila);
            }

            return filasSeparadas;
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
