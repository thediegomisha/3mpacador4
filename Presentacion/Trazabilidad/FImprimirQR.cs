using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = System.Drawing.Font;
using Image = iTextSharp.text.Image;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FImprimirQR : Form
    {
        private bool lb_estado_impresion;

        private int li_idgrupo;
        private List<Numerador_trab> Lista_num_trab = new List<Numerador_trab>();
        private string ls_dni = "";

        public FImprimirQR()
        {
            InitializeComponent();
        }


        private void Lista_Num_trab(string ls_dni, int li_idgrupo_turno)
        {
            MySqlCommand comando;
            try
            {
                Lista_num_trab.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                comando = new MySqlCommand("usp_tblnumerador_trab_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_dni", ls_dni);
                comando.Parameters.AddWithValue("p_idgrupo_turno", li_idgrupo_turno);

                Lista_num_trab = new List<Numerador_trab>();

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Numerador_trab();
                        c.codigo = Convert.ToString(reader["codigo"]);
                        c.fecha_produccion = Convert.ToDateTime(reader["fecha_produccion"]);
                        c.numerador = Convert.ToString(reader["numerador"]);
                        c.dni = Convert.ToString(reader["dni"]);
                        c.item = Convert.ToInt32(reader["item"]);
                        c.idgrupo_turno = Convert.ToInt32(reader["idgrupo_turno"]);
                        Lista_num_trab.Add(c);
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

        private void ConstruirQR(string ls_dni)
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var qrCode = qrEncoder.Encode(ls_dni);

            var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black,
                Brushes.White);
            var ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imagen = new Bitmap(new Bitmap(ms), new Size(new Point(120, 90)));

            // Crear una nueva imagen combinando el QR y el texto
            var combinedImage = new Bitmap(imagen.Width, imagen.Height + 30); // Ajusta el espacio para el texto
            using (var graphics = Graphics.FromImage(combinedImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imagen, 0, 0);

                using (var font = new Font("Arial", 12, FontStyle.Bold))
                {
                    using (var brush = new SolidBrush(Color.Black))
                    {
                        // Posición para el texto debajo del QR
                        var textSize = graphics.MeasureString(ls_dni, font);
                        var point = new PointF((imagen.Width - textSize.Width) / 2, imagen.Height);

                        // PONER FONDO BLANCO
                        graphics.FillRectangle(Brushes.White,
                            new RectangleF(new PointF(0, imagen.Height), new SizeF(imagen.Width, textSize.Height)));

                        graphics.DrawString(ls_dni, font, brush, point);
                    }
                }
            }

            // Mostrar la imagen combinada en el PictureBox
            pbQR.Image = combinedImage;
        }

        private void GenerarQR_A4(int numeroDeVeces)
        {
            lb_estado_impresion = false;
            var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_dni + ".pdf");
            using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var doc = new Document();
                var writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                var table = new PdfPTable(5);
                table.DefaultCell.Padding = 5;

                // Reemplaza "pictureBoxImage" con tu imagen desde el PictureBox
                var pictureBoxImage = Image.GetInstance(pbQR.Image, ImageFormat.Png);

                for (var i = 0; i < numeroDeVeces; i++)
                {
                    var cell = new PdfPCell(pictureBoxImage, true);
                    cell.Border = 0;
                    table.AddCell(cell);
                }

                doc.Add(table);
                doc.Close();
                lb_estado_impresion = true;
            }
        }

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

        private void FImprimirQR_Load(object sender, EventArgs e)
        {
            li_idgrupo = FJornalTurno.li_idgrupo;
            ls_dni = FJornalTurno.ls_dni;
            lbltrabajador.Text = FJornalTurno.ls_trabajador;
            if (ls_dni.Length >= 8) ConstruirQR(ls_dni);
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            var nro_etiquetas = Convert.ToInt32(nudcantidad.Value.ToString());
            if (nro_etiquetas > 0)
            {
                //if (lb_estado_impresion)

                ActualizarEtiquetas(li_idgrupo, ls_dni, nro_etiquetas);
                Lista_Num_trab(ls_dni, li_idgrupo);

                var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_dni + ".pdf");
                using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    var doc = new Document();
                    var writer = PdfWriter.GetInstance(doc, fs);

                    doc.Open();

                    var table = new PdfPTable(5);
                    table.DefaultCell.Padding = 0;
                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9); // Fuente en negrita
                    foreach (var li in Lista_num_trab)
                    {
                        var qrCode = new BarcodeQRCode(li.codigo, 150, 150, null);
                        var img = qrCode.GetImage();

                        var qrCell = new PdfPCell();
                        qrCell.PaddingTop = 1;
                        qrCell.Border = 0;
                        qrCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        qrCell.AddElement(img);


                        var textChunk = new Chunk(li.codigo, boldFont);
                        var text = new Paragraph(textChunk);
                        text.Alignment = Element.ALIGN_CENTER;
                        text.IndentationLeft = 10;
                        text.IndentationRight = 10;
                        qrCell.AddElement(text);

                        table.AddCell(qrCell);
                    }

                    doc.Add(table);

                    doc.Close();
                    writer.Close();

                    MessageBox.Show(@"SE GENERARON LOS QR :)", @"CODIGOS QR");
                    Close();
                }
            }
        }
    }
}