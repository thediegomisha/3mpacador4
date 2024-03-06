using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using iTextSharp.text;
using iTextSharp.text.pdf;
using _3mpacador4.Presentacion.Trazabilidad;
using System.IO;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FRptKardexLote : Form
    {
        public FRptKardexLote()
        {
            InitializeComponent();
        }

        public static string ls_ruta_pdf = "";

        private void FRptKardexLote_Load(object sender, EventArgs e)
        {
            nudanio.Value = DateTime.Now.Year;
            cbxmes.SelectedIndex = 0;
        }

        void Kardex_x_Lote(int li_anio, string ls_mes)
        {
            MySqlCommand comando;
            try
            {
                dgvkardex.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_kardex_x_fecha", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", li_anio);
                comando.Parameters.AddWithValue("p_mes", ls_mes);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvkardex.Rows.Add(Convert.ToDateTime(reader["fecha_produccion"]).ToShortDateString(), 
                            reader["lote"].ToString(), reader["tipo"].ToString(),
                            Convert.ToDecimal(reader["ingreso"]).ToString("###,##0.000"),
                            Convert.ToDecimal(reader["salida"]).ToString("###,##0.000"),
                            Convert.ToDecimal(reader["saldo"]).ToString("###,##0.000"));
                    }
                    //lbltotal_lotes.Text = dgvlista.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            int li_anio;
            string ls_mes;

            li_anio = Convert.ToInt32(nudanio.Value);

            if (cbxmes.SelectedIndex == 0)
            {
                ls_mes = "%";
            }
            else
            {
                ls_mes = cbxmes.Text.Substring(0, cbxmes.Text.Contains("-").ToString().Length - 2);
            }

            Kardex_x_Lote(li_anio, ls_mes);
        }

        private void btnverpdf_Click(object sender, EventArgs e)
        {
            GenerarPDF();
            var f = new FVisorPDF();
            f.ShowDialog();
        }

        void GenerarPDF() 
        {
            try
            {
                //const string LogoPath = "logoagricola.png";
                var doc = new Document(PageSize.A4, 30, 20, 30, 20);

                ls_ruta_pdf = AppDomain.CurrentDomain.BaseDirectory + "KARDEX_LOTE.pdf";
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ls_ruta_pdf, FileMode.Create));

                // estas dos lineas es para el encavezado
                var tipo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                var titulo_tabla = new iTextSharp.text.Font(tipo, 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                var fuente1 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                var fuente2 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                var fuente3 = new iTextSharp.text.Font(tipo, 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                var fuente4 = new iTextSharp.text.Font(tipo, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                writer.PageEvent = new CustomPdfPageEvent();

                doc.Open();

                var logo = iTextSharp.text.Image.GetInstance("logoagricola.png");
                logo.SetAbsolutePosition(50, 770);
                logo.ScaleToFit(120f, 250f);
                logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

                doc.Add(logo);

                var espacio = new Paragraph("\n");                

                // NOMBRES DE LAS COLUMNAS RESULTADO DEL PROCESO
                var TTituloLista2 = new PdfPTable(6);
                var ancho3 = new[] { 120, 120, 120, 120, 120, 120 };
                TTituloLista2.SetWidths(ancho3);
                TTituloLista2.WidthPercentage = 100;
                TTituloLista2.HorizontalAlignment = Element.ALIGN_CENTER;

                var enva = new PdfPCell(new Paragraph("F. PRODUCCION", fuente3));
                enva.HorizontalAlignment = Element.ALIGN_CENTER;
                enva.BackgroundColor = BaseColor.LIGHT_GRAY;
                enva.PaddingBottom = 5f;

                var cat = new PdfPCell(new Paragraph("LOTE", fuente3));
                cat.HorizontalAlignment = Element.ALIGN_CENTER;
                cat.BackgroundColor = BaseColor.LIGHT_GRAY;
                cat.PaddingBottom = 5f;

                var t8 = new PdfPCell(new Paragraph("TIPO", fuente3));
                t8.HorizontalAlignment = Element.ALIGN_CENTER;
                t8.BackgroundColor = BaseColor.LIGHT_GRAY;
                t8.PaddingBottom = 5f;

                var t10 = new PdfPCell(new Paragraph("INGRESO", fuente3));
                t10.HorizontalAlignment = Element.ALIGN_CENTER;
                t10.BackgroundColor = BaseColor.LIGHT_GRAY;
                t10.PaddingBottom = 5f;

                var t12 = new PdfPCell(new Paragraph("SALIDA", fuente3));
                t12.HorizontalAlignment = Element.ALIGN_CENTER;
                t12.BackgroundColor = BaseColor.LIGHT_GRAY;
                t12.PaddingBottom = 5f;

                var t14 = new PdfPCell(new Paragraph("SALDO", fuente3));
                t14.HorizontalAlignment = Element.ALIGN_CENTER;
                t14.BackgroundColor = BaseColor.LIGHT_GRAY;
                t14.PaddingBottom = 5f;

                TTituloLista2.AddCell(new PdfPCell(enva));
                TTituloLista2.AddCell(new PdfPCell(cat));
                TTituloLista2.AddCell(new PdfPCell(t8));
                TTituloLista2.AddCell(new PdfPCell(t10));
                TTituloLista2.AddCell(new PdfPCell(t12));
                TTituloLista2.AddCell(new PdfPCell(t14));

                // INFORMACION RESULTADO DE PROCESO
                var TTablaLista2 = new PdfPTable(6);
                var ancho4 = new[] { 120, 120, 120, 120, 120, 120};
                TTablaLista2.SetWidths(ancho4);
                TTablaLista2.WidthPercentage = 100;

                foreach (DataGridViewRow ele in dgvkardex.Rows)
                {
                    var envase = new PdfPCell(new Paragraph(ele.Cells[0].Value == null ? "" : ele.Cells[0].Value.ToString(), fuente4));
                    envase.HorizontalAlignment = Element.ALIGN_CENTER;

                    var categoria = new PdfPCell(new Paragraph(ele.Cells[1].Value.ToString(), fuente4));
                    categoria.HorizontalAlignment = Element.ALIGN_CENTER;

                    var c8 = new PdfPCell(new Paragraph(ele.Cells[2].Value.ToString(), fuente4));
                    c8.HorizontalAlignment = Element.ALIGN_CENTER;

                    var c10 = new PdfPCell(new Paragraph(ele.Cells[3].Value.ToString(), fuente4));
                    c10.HorizontalAlignment = Element.ALIGN_CENTER;

                    var c12 = new PdfPCell(new Paragraph(ele.Cells[4].Value.ToString(), fuente4));
                    c12.HorizontalAlignment = Element.ALIGN_CENTER;

                    var c14 = new PdfPCell(new Paragraph(ele.Cells[5].Value.ToString(), fuente4));
                    c14.HorizontalAlignment = Element.ALIGN_CENTER;

                    TTablaLista2.AddCell(new PdfPCell(envase));
                    TTablaLista2.AddCell(new PdfPCell(categoria));
                    TTablaLista2.AddCell(new PdfPCell(c8));
                    TTablaLista2.AddCell(new PdfPCell(c10));
                    TTablaLista2.AddCell(new PdfPCell(c12));
                    TTablaLista2.AddCell(new PdfPCell(c14));
                }

                doc.Add(espacio);
                doc.Add(espacio);
                doc.Add(espacio);
                doc.Add(espacio);
                doc.Add(TTituloLista2);
                doc.Add(TTablaLista2);
                doc.Add(espacio);
                doc.Add(espacio);

                doc.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public class CustomPdfPageEvent : PdfPageEventHelper
        {
            private readonly BaseFont baseFont;

            public CustomPdfPageEvent()
            {
                // Configurar la fuente y el tamaño de la fuente
                baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                string pageText = "KARDEX MOVIMIENTO POR LOTES";

                // Crear una instancia de PdfContentByte para trabajar con el contenido de la página
                PdfContentByte cb = writer.DirectContent;

                // Configurar la fuente y el tamaño de la fuente
                cb.SetFontAndSize(baseFont, 12);

                // Escribir el número de página en el contenido del PDF
                PdfContentByte canvas = writer.DirectContent;

                // Position the header at the top of the page
                canvas.BeginText();
                canvas.SetTextMatrix(240, 790); // Adjust the position as needed
                canvas.ShowText(pageText);
                canvas.EndText();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                // Obtener el número de página actual
                int pageNumber = writer.PageNumber;

                // Configurar la fuente y tamaño del número de página
                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                string pageText = "N° Pag. " + pageNumber;
                //Phrase pageNumberPhrase = new Phrase(pageText, new iTextSharp.text.Font(baseFont, 9f));

                // Posicionar el número de página en la esquina superior derecha
                float x = document.PageSize.Width - document.RightMargin - 55; // document.Right - document.RightMargin;
                float y = document.BottomMargin;

                // Escribir el número de página en el contenido del PDF
                PdfContentByte canvas = writer.DirectContent;
                canvas.BeginText();
                canvas.SetFontAndSize(baseFont, 9f);
                canvas.SetTextMatrix(x, y);
                canvas.ShowText(pageText);
                canvas.EndText();
            }

        }

    }
}
