using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using RawDataPrint;
//using Gma.QrCodeNet.Encoding;
//using Gma.QrCodeNet.Encoding.Windows.Render;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Font = System.Drawing.Font;
//using Image = iTextSharp.text.Image;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FImprimirQR : Form
    {
        //private bool lb_estado_impresion;

        private int li_idgrupo;
        public Numerador_trab n_trab = null;
        private List<string> Lista_num_trab = new List<string>();
        private string ls_dni = "";

        public FImprimirQR()
        {
            InitializeComponent();
        }


        private void Lista_Num_trab(string ls_dni, int li_idgrupo_turno)
        {
            MySqlCommand comando = null;
            try
            {
                Lista_num_trab.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                comando = new MySqlCommand("usp_tblnumerador_trab_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_dni", ls_dni);
                comando.Parameters.AddWithValue("p_idgrupo_turno", li_idgrupo_turno);

                Lista_num_trab = new List<string>();//Lista_num_trab = new List<Numerador_trab>();

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lista_num_trab.Add(Convert.ToString(reader["codigo"]));
                        /*
                        n_trab = new Numerador_trab();
                        n_trab.codigo = Convert.ToString(reader["codigo"]);
                        n_trab.fecha_produccion = Convert.ToDateTime(reader["fecha_produccion"]);
                        n_trab.numerador = Convert.ToString(reader["numerador"]);
                        n_trab.dni = Convert.ToString(reader["dni"]);
                        n_trab.item = Convert.ToInt32(reader["item"]);
                        n_trab.idgrupo_turno = Convert.ToInt32(reader["idgrupo_turno"]);
                        Lista_num_trab.Add(n_trab);
                        */
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

        //private void ConstruirQR(string ls_dni)
        //{
        //    var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
        //    var qrCode = qrEncoder.Encode(ls_dni);

        //    var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black,
        //        Brushes.White);
        //    var ms = new MemoryStream();
        //    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
        //    var imagen = new Bitmap(new Bitmap(ms), new Size(new Point(120, 90)));

        //    // Crear una nueva imagen combinando el QR y el texto
        //    var combinedImage = new Bitmap(imagen.Width, imagen.Height + 30); // Ajusta el espacio para el texto
        //    using (var graphics = Graphics.FromImage(combinedImage))
        //    {
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.DrawImage(imagen, 0, 0);

        //        using (var font = new Font("Arial", 12, FontStyle.Bold))
        //        {
        //            using (var brush = new SolidBrush(Color.Black))
        //            {
        //                // Posición para el texto debajo del QR
        //                var textSize = graphics.MeasureString(ls_dni, font);
        //                var point = new PointF((imagen.Width - textSize.Width) / 2, imagen.Height);

        //                // PONER FONDO BLANCO
        //                graphics.FillRectangle(Brushes.White,
        //                    new RectangleF(new PointF(0, imagen.Height), new SizeF(imagen.Width, textSize.Height)));

        //                graphics.DrawString(ls_dni, font, brush, point);
        //            }
        //        }
        //    }

        //    // Mostrar la imagen combinada en el PictureBox
        //    pbQR.Image = combinedImage;
        //}

        //private void GenerarQR_A4(int numeroDeVeces)
        //{
        //    lb_estado_impresion = false;
        //    var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_dni + ".pdf");
        //    using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        var doc = new Document();
        //        var writer = PdfWriter.GetInstance(doc, fs);

        //        doc.Open();

        //        var table = new PdfPTable(5);
        //        table.DefaultCell.Padding = 5;

        //        // Reemplaza "pictureBoxImage" con tu imagen desde el PictureBox
        //        var pictureBoxImage = Image.GetInstance(pbQR.Image, ImageFormat.Png);

        //        for (var i = 0; i < numeroDeVeces; i++)
        //        {
        //            var cell = new PdfPCell(pictureBoxImage, true);
        //            cell.Border = 0;
        //            table.AddCell(cell);
        //        }

        //        doc.Add(table);
        //        doc.Close();
        //        lb_estado_impresion = true;
        //    }
        //}

        private void ActualizarEtiquetas(int li_idgrupo, string ls_dni, int cantidad)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblgrupo_turno_det_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_id", li_idgrupo);
                comando.Parameters.AddWithValue("p_dni", ls_dni);
                comando.Parameters.AddWithValue("p_cantidad", cantidad);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"CANTIDAD DE ETIQUETAS ACTUALIZADA SATISFACTORIAMENTE.", @"Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private bool Generar_Numeradores(int li_idgrupo, string ls_dni, int cantidad)
        {
            try
            {
                bool rpta = false;
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblnumerador_trab_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idgrupo", li_idgrupo);
                comando.Parameters.AddWithValue("p_dni", ls_dni);
                comando.Parameters.AddWithValue("p_cantidad", cantidad);
                rpta = Convert.ToBoolean(comando.ExecuteNonQuery());
                //MessageBox.Show(@"CANTIDAD DE ETIQUETAS GENERADAS SATISFACTORIAMENTE.", @"Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LimpiarCampos();
                ConexionGral.desconectar();
                return rpta;
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            var nro_etiquetas = Convert.ToInt32(lblcantidad_tikects.Text.ToString());
            if (nro_etiquetas > 0)
            {
                
                if (Generar_Numeradores(li_idgrupo, ls_dni, nro_etiquetas))
                {
                    Lista_Num_trab(ls_dni, li_idgrupo);

                    List<List<string>> filasSeparadas = SepararEnFilas(Lista_num_trab, 4);
                    
                    string cadena;

                    for (var i = 0; i <= filasSeparadas.Count - 1; i++)
                    {
                        cadena = "^XA" + Environment.NewLine;

                        cadena = cadena + "^FO20^BQN,2,6^FDMA," + filasSeparadas[i][0].ToString() + "^FS" + Environment.NewLine;
                        cadena = cadena + "^CF0,25^FO30,128^FD" + filasSeparadas[i][0].ToString().Substring(10) + "^FS" + Environment.NewLine;

                        cadena = cadena + "^FO235^BQN,2,6^FDMA," + filasSeparadas[i][1].ToString() + "^FS" + Environment.NewLine;
                        cadena = cadena + "^CF0,25^FO245,128^FD" + filasSeparadas[i][1].ToString().Substring(10) + "^FS" + Environment.NewLine;

                        cadena = cadena + "^FO450^BQN,2,6^FDMA," + filasSeparadas[i][2].ToString() + "^FS" + Environment.NewLine;
                        cadena = cadena + "^CF0,25^FO460,128^FD" + filasSeparadas[i][2].ToString().Substring(10) + "^FS" + Environment.NewLine;

                        cadena = cadena + "^FO665^BQN,2,6^FDMA," + filasSeparadas[i][3].ToString() + "^FS" + Environment.NewLine;
                        cadena = cadena + "^CF0,25^FO675,128^FD" + filasSeparadas[i][3].ToString().Substring(10) + "^FS" + Environment.NewLine;

                        // FIN
                        cadena = cadena + "^XZ" + Environment.NewLine;
                        RawPrinterHelper.EnviarCadenaToImpresora(cbximpresora.Text.Trim(), cadena);
                        cadena = "";
                    }

                    MessageBox.Show("IMPRESION DE TICKETS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Impresion_ZPL(/*Convert.ToInt32(nudacantidad_filas.Value)*/);
                }   
            }
        }

        public void Impresion_ZPL(/*Numerador_trab n, int li_cantidad_filas*/)
        {
            try
            {
                string cadena;

                //int imp = 0;

                // CONVERTIRNO LA LISTA DE ENTIDADES A UN ARREGLO BIDIMENCIONAL
                int filas = Lista_num_trab.Count;
                object[,] Arreglo = new object[filas, 1];

                // AGREGO LOS VALORES AL ARREGLO
                for (int i = 0; i < filas; i++)
                {
                    //Arreglo[i, 0] = Lista_num_trab[i].codigo;
                    /*Arreglo[i, 1] = Lista_num_trab[i].codigo;
                    Arreglo[i, 2] = Lista_num_trab[i].codigo;
                    Arreglo[i, 3] = Lista_num_trab[i].codigo;*/
                }

                

                //int fila = 0;
                // RECORRO LAS FILAS
                for (int i = 0; i < nudacantidad_filas.Value; i++)
                {
                    //fila = fila + 1;
                    // INICIO
                    cadena = "^XA" + Environment.NewLine;

                    cadena = cadena + "^FO20^BQN,2,6^FDMA," + Arreglo[i, 0].ToString() + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,25^FO30,128^FD" + Arreglo[i, 0].ToString().Trim().Substring(12) + "^FS" + Environment.NewLine;

                    cadena = cadena + "^FO235^BQN,2,6^FDMA," + Arreglo[i, 1].ToString().Trim() + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,25^FO245,128^FD" + Arreglo[i, 1].ToString().Trim().Substring(12) + "^FS" + Environment.NewLine;
                                                                       
                    cadena = cadena + "^FO450^BQN,2,6^FDMA," + Arreglo[i, 2].ToString().Trim() + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,25^FO460,128^FD" + Arreglo[i, 3].ToString().Trim().Substring(12) + "^FS" + Environment.NewLine;
                                                                       
                    cadena = cadena + "^FO665^BQN,2,6^FDMA," + Arreglo[i, 4].ToString().Trim() + "^FS" + Environment.NewLine;
                    cadena = cadena + "^CF0,25^FO675,128^FD" + Arreglo[i, 4].ToString().Trim().Substring(12) + "^FS" + Environment.NewLine;

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

        private void cbximpresora_SelectedValueChanged(object sender, EventArgs e)
        {
            SetImpresoraPredeterminada(cbximpresora.Text.ToString());
        }

        private void FImprimirQR_Load(object sender, EventArgs e)
        {
            li_idgrupo = FJornalTurno.li_idgrupo;
            ls_dni = FJornalTurno.ls_dni;
            lbltrabajador.Text = FJornalTurno.ls_trabajador;
            LlenarComboBoxImpresoras();
            lblcantidad_tikects.Text = Convert.ToString(Convert.ToInt32(nudacantidad_filas.Value) * Convert.ToInt32(lblcolumnas.Text.Trim()));
        }

        private void nudacantidad_filas_ValueChanged(object sender, EventArgs e)
        {
            lblcantidad_tikects.Text = Convert.ToString(Convert.ToInt32(nudacantidad_filas.Value) * Convert.ToInt32(lblcolumnas.Text.Trim()));
        }

        //private void FImprimirQR_Load(object sender, EventArgs e)
        //{
        //    li_idgrupo = FJornalTurno.li_idgrupo;
        //    ls_dni = FJornalTurno.ls_dni;
        //    lbltrabajador.Text = FJornalTurno.ls_trabajador;
        //    if (ls_dni.Length >= 8) ConstruirQR(ls_dni);
        //}

        //private void btngenerar_Click(object sender, EventArgs e)
        //{
        //    var nro_etiquetas = Convert.ToInt32(nudcantidad.Value.ToString());
        //    if (nro_etiquetas > 0)
        //    {
        //        //if (lb_estado_impresion)

        //        ActualizarEtiquetas(li_idgrupo, ls_dni, nro_etiquetas);
        //        Lista_Num_trab(ls_dni, li_idgrupo);

        //        var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_dni + ".pdf");
        //        using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            var doc = new Document();
        //            var writer = PdfWriter.GetInstance(doc, fs);

        //            doc.Open();

        //            var table = new PdfPTable(5);
        //            table.DefaultCell.Padding = 0;
        //            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9); // Fuente en negrita
        //            foreach (var li in Lista_num_trab)
        //            {
        //                BarcodeQRCode qrCode = new BarcodeQRCode(li.codigo, 150, 150, null);
        //                iTextSharp.text.Image img = qrCode.GetImage();

        //                var qrCell = new PdfPCell();
        //                qrCell.PaddingTop = 1;
        //                qrCell.Border = 0;
        //                qrCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //                qrCell.AddElement(img);


        //                var textChunk = new Chunk(li.codigo, boldFont);
        //                var text = new Paragraph(textChunk);
        //                text.Alignment = Element.ALIGN_CENTER;
        //                text.IndentationLeft = 10;
        //                text.IndentationRight = 10;
        //                qrCell.AddElement(text);

        //                table.AddCell(qrCell);
        //            }

        //            doc.Add(table);

        //            doc.Close();
        //            writer.Close();

        //            MessageBox.Show(@"SE GENERARON LOS QR :)", @"CODIGOS QR");
        //            Close();
        //        }
        //    }
        //}
    }
}