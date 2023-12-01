﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using iTextSharp.text;
using iTextSharp.text.pdf;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FImprimirQR : Form
    {
        public FImprimirQR()
        {
            InitializeComponent();
        }

        int li_idgrupo = 0;
        string ls_dni = "";
        bool lb_estado_impresion = false;

        void ConstruirQR(string ls_dni) 
        {
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            var qrCode = qrEncoder.Encode(ls_dni);

            var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
            var ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imagen = new Bitmap(new Bitmap(ms), new Size(new Point(120,90)));

            // Crear una nueva imagen combinando el QR y el texto
            Bitmap combinedImage = new Bitmap(imagen.Width, imagen.Height + 30); // Ajusta el espacio para el texto
            using (Graphics graphics = Graphics.FromImage(combinedImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imagen, 0, 0);

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold))
                {
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        // Posición para el texto debajo del QR
                        SizeF textSize = graphics.MeasureString(ls_dni, font);
                        PointF point = new PointF((imagen.Width - textSize.Width) / 2, imagen.Height);

                        // PONER FONDO BLANCO
                        graphics.FillRectangle(Brushes.White, new RectangleF(new PointF(0, imagen.Height), new SizeF(imagen.Width, textSize.Height)));
                        
                        graphics.DrawString(ls_dni, font, brush, point);                    
                    }
                }
            }

            // Mostrar la imagen combinada en el PictureBox
            pbQR.Image = combinedImage;
        }

        void GenerarQR_A4(int numeroDeVeces) 
        {
            lb_estado_impresion = false;
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ls_dni + ".pdf");
            using (FileStream fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                PdfPTable table = new PdfPTable(5);
                table.DefaultCell.Padding = 5;

                // Reemplaza "pictureBoxImage" con tu imagen desde el PictureBox
                iTextSharp.text.Image pictureBoxImage = iTextSharp.text.Image.GetInstance(pbQR.Image, System.Drawing.Imaging.ImageFormat.Png);

                for (int i = 0; i < numeroDeVeces; i++)
                {
                    PdfPCell cell = new PdfPCell(pictureBoxImage, true);
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
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblgrupo_turno_det_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_id", li_idgrupo);
                comando.Parameters.AddWithValue("p_dni", ls_dni);
                comando.Parameters.AddWithValue("p_cantidad", cantidad);
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

        private void FImprimirQR_Load(object sender, EventArgs e)
        {
            li_idgrupo = FJornalTurno.li_idgrupo;
            ls_dni = FJornalTurno.ls_dni;
            lbltrabajador.Text = FJornalTurno.ls_trabajador;
            if (ls_dni.Length >= 8)
            {
                ConstruirQR(ls_dni);
            }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            int nro_etiquetas = Convert.ToInt32(nudcantidad.Value.ToString());
            if (nro_etiquetas > 0)
            {
                GenerarQR_A4(nro_etiquetas);
                if (lb_estado_impresion)
                {
                    ActualizarEtiquetas(li_idgrupo, ls_dni, nro_etiquetas);
                }
            }            
        }
    }
}
