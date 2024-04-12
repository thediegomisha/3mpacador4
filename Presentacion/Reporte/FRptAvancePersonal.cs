using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Trazabilidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FRptAvancePersonal : Form
    {
        public FRptAvancePersonal()
        {
            InitializeComponent();
        }

        public static string ls_ruta_pdf = "";

        void Lista_Grupo_turno(string ls_fecha_produccion)
        {
            dgvgrupo_turno.Rows.Clear();
            var Lista = LGrupo_turno.Lista_grupo_turno(ls_fecha_produccion);
            foreach (var f in Lista)
            {
                dgvgrupo_turno.Rows.Add(f.idgrupo, f.descripcion, f.idusuario, f.nom_usuario, f.idturno, f.nom_turno,
                                            f.fecha_produccion.ToShortDateString(), f.fecha_inicio.ToString("dd/MM/yyyy HH:mm"), f.fecha_fin.ToString("dd/MM/yyyy HH:mm"), f.flag_tercero == "1" ? true : false,
                                            f.flag_estado == "1" ? true : false);
            }
        }

        void Lista_Grupo_turno_det(int li_idgrupo)
        {
            dgvavance.Rows.Clear();
            var Lista = LGrupo_turno.Lista_Avance_x_grupo(li_idgrupo);
            foreach (var f in Lista)
            {
                dgvavance.Rows.Add(f.dni, f.trabajador, f.ult_cantidad);
            }
        }

        private void dtpfecha_produccion_fil_ValueChanged(object sender, EventArgs e)
        {
            Lista_Grupo_turno(dtpfecha_produccion_fil.Value.ToString("yyyy-MM-dd"));
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvgrupo_turno_SelectionChanged(object sender, EventArgs e)
        {
            int li_idgrupo = Convert.ToInt32(dgvgrupo_turno.CurrentRow.Cells[0].Value);
            Lista_Grupo_turno_det(li_idgrupo);
        }

        private void dgvgrupo_turno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvgrupo_turno.Columns[e.ColumnIndex].Index == 11)
            {
                GeneraPDF();
                var f = new FVisorPDF();
                f.ShowDialog();
            }
        }

        void GeneraPDF()
        {
            var doc = new Document(PageSize.A4, 30, 20, 30, 20);
            
            ls_ruta_pdf = AppDomain.CurrentDomain.BaseDirectory + "AVANCE_TRABAJADOR_" + dtpfecha_produccion_fil.Value.ToString("ddMMyyyy") + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ls_ruta_pdf, FileMode.Create));

            // estas dos lineas es para el encavezado
            var tipo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            var titulo_tabla = new iTextSharp.text.Font(tipo, 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var fuente1 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var fuente2 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Open();

            Paragraph titulo = new Paragraph("AVANCE DE TRABAJADORES - " + dtpfecha_produccion_fil.Value.ToShortDateString(), titulo_tabla);
            titulo.Alignment = Element.ALIGN_CENTER;

            var espacio = new Paragraph("\n");

            doc.Add(titulo);
            doc.Add(espacio);
            doc.Add(espacio);


            var logo = iTextSharp.text.Image.GetInstance("logoagricola.png");
            logo.SetAbsolutePosition(30, 775); // 25, 752 125, 752
            logo.ScaleToFit(120f, 250f);
            logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

            doc.Add(logo);            
            

            //DATOS DE LA EMPRESA
            var Tabla_grupo = new PdfPTable(6);
            var columnas = new[] { 80, 60, 60, 80, 60, 80 };
            Tabla_grupo.SetWidths(columnas);
            Tabla_grupo.WidthPercentage = 85;

            var desc = new PdfPCell(new Paragraph("Decripcion : ", fuente1));
            desc.HorizontalAlignment = Element.ALIGN_RIGHT;
            desc.Border = 0;
            var Descripcion = new PdfPCell(new Paragraph(dgvgrupo_turno.CurrentRow.Cells[1].Value.ToString(), fuente2));
            Descripcion.HorizontalAlignment = Element.ALIGN_LEFT;
            Descripcion.Border = 0;
            Descripcion.Colspan = 3;

            var turn = new PdfPCell(new Paragraph("Turno : ", fuente1));
            turn.HorizontalAlignment = Element.ALIGN_RIGHT;
            turn.Border = 0;
            var turno = new PdfPCell(new Paragraph(dgvgrupo_turno.CurrentRow.Cells[5].Value.ToString(), fuente2));
            turno.HorizontalAlignment = Element.ALIGN_LEFT;
            turno.Border = 0;

            var fprod = new PdfPCell(new Paragraph("Fecha Produción : ", fuente1));
            fprod.HorizontalAlignment = Element.ALIGN_RIGHT;
            fprod.Border = 0;
            var fproduccion = new PdfPCell(new Paragraph(dgvgrupo_turno.CurrentRow.Cells[6].Value.ToString(), fuente2));
            fproduccion.HorizontalAlignment = Element.ALIGN_LEFT;
            fproduccion.Border = 0;

            var des = new PdfPCell(new Paragraph("Desde : ", fuente1));
            des.HorizontalAlignment = Element.ALIGN_RIGHT;
            des.Border = 0;
            var desde = new PdfPCell(new Paragraph(dgvgrupo_turno.CurrentRow.Cells[7].Value.ToString(), fuente2));
            desde.HorizontalAlignment = Element.ALIGN_LEFT;
            desde.Border = 0;

            var has = new PdfPCell(new Paragraph("Hasta : ", fuente1));
            has.HorizontalAlignment = Element.ALIGN_RIGHT;
            has.Border = 0;
            var hasta = new PdfPCell(new Paragraph(dgvgrupo_turno.CurrentRow.Cells[8].Value.ToString(), fuente2));
            hasta.HorizontalAlignment = Element.ALIGN_LEFT;
            hasta.Border = 0;

            Tabla_grupo.AddCell(desc);
            Tabla_grupo.AddCell(Descripcion);
            Tabla_grupo.AddCell(turn);
            Tabla_grupo.AddCell(turno);
            Tabla_grupo.AddCell(fprod);
            Tabla_grupo.AddCell(fproduccion);
            Tabla_grupo.AddCell(des);
            Tabla_grupo.AddCell(desde);
            Tabla_grupo.AddCell(has);
            Tabla_grupo.AddCell(hasta);

            doc.Add(Tabla_grupo);
            doc.Add(espacio);
            doc.Add(espacio);

            // BIEN
            var TAvance_cab = new PdfPTable(4);
            var tab3 = new[] { 30, 50, 250, 50};
            TAvance_cab.SetWidths(tab3);
            TAvance_cab.WidthPercentage = 100;

            var c_nro = new PdfPCell(new Paragraph("N°", fuente1));
            c_nro.HorizontalAlignment = Element.ALIGN_CENTER;
            c_nro.BackgroundColor = BaseColor.LIGHT_GRAY;
            //c_nro.BorderWidthRight = 0;
            c_nro.PaddingTop = 5f;
            c_nro.PaddingBottom = 5f;
            TAvance_cab.AddCell(c_nro);

            var c_dni = new PdfPCell(new Paragraph("DNI", fuente1));
            c_dni.HorizontalAlignment = Element.ALIGN_CENTER;
            c_dni.BackgroundColor = BaseColor.LIGHT_GRAY;
            //c_dni.BorderWidthRight = 0;
            c_dni.PaddingTop = 5f;
            c_dni.PaddingBottom = 5f;
            TAvance_cab.AddCell(c_dni);

            var c_trabjador = new PdfPCell(new Paragraph("NOMBRES Y APELLIDOS", fuente1));
            c_trabjador.HorizontalAlignment = Element.ALIGN_CENTER;
            c_trabjador.BackgroundColor = BaseColor.LIGHT_GRAY;
            //c_trabjador.BorderWidthRight = 0;
            //c_trabjador.BorderWidthRight = 0;
            c_trabjador.PaddingTop = 5f;
            c_trabjador.PaddingBottom = 5f;
            TAvance_cab.AddCell(c_trabjador);

            var c_cantidad = new PdfPCell(new Paragraph("CANTIDAD", fuente1));
            c_cantidad.HorizontalAlignment = Element.ALIGN_CENTER;
            c_cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
           // c_cantidad.BorderWidthLeft = 0;
            //c_cantidad.BorderWidthRight = 0;
            c_cantidad.PaddingTop = 5f;
            c_cantidad.PaddingBottom = 5f;
            TAvance_cab.AddCell(c_cantidad);
           

            for (int i = 0; i < dgvavance.Rows.Count; i++)
            {
                var c_item = new PdfPCell(new Paragraph((i+1).ToString(), fuente2));
                c_item.HorizontalAlignment = Element.ALIGN_CENTER;
                c_item.VerticalAlignment = Element.ALIGN_MIDDLE;
                //c_item.BorderWidthRight = 0;
                c_item.PaddingBottom = 5f;
                TAvance_cab.AddCell(c_item);

                var c_cod = new PdfPCell(new Paragraph(dgvavance.Rows[i].Cells[0].Value.ToString(), fuente2));
                c_cod.HorizontalAlignment = Element.ALIGN_CENTER;
                c_cod.VerticalAlignment = Element.ALIGN_MIDDLE;
                //c_cod.BorderWidthRight = 0;
                c_cod.PaddingBottom = 5f;
                TAvance_cab.AddCell(c_cod);

                var c_descrip = new PdfPCell(new Paragraph(dgvavance.Rows[i].Cells[1].Value.ToString(), fuente2));
                c_descrip.HorizontalAlignment = Element.ALIGN_LEFT;
                c_descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                //c_descrip.BorderWidthLeft = 0;
                //c_descrip.BorderWidthRight = 0;
                c_descrip.PaddingBottom = 5f;
                TAvance_cab.AddCell(c_descrip);

                var c_cant = new PdfPCell(new Paragraph(Convert.ToDecimal(dgvavance.Rows[i].Cells[2].Value).ToString("###,###.00"), fuente2));
                c_cant.HorizontalAlignment = Element.ALIGN_RIGHT;
                c_cant.VerticalAlignment = Element.ALIGN_MIDDLE;
                //c_cant.BorderWidthLeft = 0;
                //c_cant.BorderWidthRight = 0;
                c_cant.PaddingBottom = 5f;
                TAvance_cab.AddCell(c_cant);
            }

            // Calcular y agregar sumatoria
            PdfPCell sumatoriaCell = new PdfPCell(new Phrase("TOTAL DE CAJAS ", fuente1));
            sumatoriaCell.HorizontalAlignment = Element.ALIGN_CENTER;
            sumatoriaCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            sumatoriaCell.Colspan = 3;
            TAvance_cab.AddCell(sumatoriaCell);

            float sumatoria = 0;
            // Sumar los valores de la columna de precios
            for (int i = 0; i < dgvavance.RowCount; i++)
            {
                sumatoria += float.Parse(dgvavance.Rows[i].Cells[2].Value.ToString());
            }
            // Agregar la sumatoria al final
            PdfPCell valor_suma = new PdfPCell(new Phrase(sumatoria.ToString("###,###.00"), fuente1));
            valor_suma.HorizontalAlignment = Element.ALIGN_RIGHT;
            valor_suma.VerticalAlignment = Element.ALIGN_MIDDLE;
            TAvance_cab.AddCell(valor_suma);


            doc.Add(TAvance_cab);
            

            // Asignar el evento de pie de página al escritor PDF
            writer.PageEvent = new CustomPdfPageEvent();

            doc.Close();
        }

        public class CustomPdfPageEvent : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                // Obtener el número de página actual
                int pageNumber = writer.PageNumber;

                // Configurar la fuente y tamaño del número de página
                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                string pageText = "N° Pag. " + pageNumber;
                Phrase pageNumberPhrase = new Phrase(pageText, new iTextSharp.text.Font(baseFont, 9f));

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
