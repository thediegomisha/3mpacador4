using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FRptPackigCalibre : Form
    {
        public FRptPackigCalibre()
        {
            InitializeComponent();
        }
        int li_idlote = 0;
        decimal ldc_kilos_descarte, ldc_kilos_muestra, ldc_porc_descarte, ldc_porc_muestra,
            ldc_porc_ingresado, ldc_porc_procesado, ldc_kilos_ingresados, ldc_kilos_procesados;

        private void btnbuscar_trab_Click(object sender, EventArgs e)
        {
            ldc_kilos_descarte = 0; ldc_kilos_muestra = 0; ldc_porc_descarte = 0; ldc_porc_muestra = 0;
            ldc_porc_ingresado = 0; ldc_porc_procesado = 0; ldc_kilos_ingresados = 0; ldc_kilos_procesados = 0;

            dgvpacking_calibre_cab.Rows.Clear();
            var Lista_cab = LPacking_calibre.Lista_packing_calibre_cab(dtpf_produccion.Value.ToString("yyyy-MM-dd"));
            foreach (var f in Lista_cab)
            {
                dgvpacking_calibre_cab.Rows.Add(f.nom_planta, f.idproducto, f.producto, f.idacopiador, f.nom_acopiador, f.ruc_a,
                                                f.fecha_produccion.ToShortDateString(), f.idclp, f.idlote, f.lote, f.num_guia, f.idvariedad, f.variedad,
                                                f.idcliente, f.nom_cliente, f.ruc_c, f.cantidad_jabas, f.peso_bruto, f.peso_jabas, 
                                                f.peso_neto, f.peso_promedio);
                ldc_kilos_ingresados += f.peso_neto;
            }

            tbxkilos_ingreso.Text = ldc_kilos_ingresados.ToString("###,##0.00");

            dgvpacking_calibre_det.Rows.Clear();
            var Lista_det = LPacking_calibre.Lista_packing_calibre_det(dtpf_produccion.Value.ToString("yyyy-MM-dd"));
            foreach (var f in Lista_det)
            {
                dgvpacking_calibre_det.Rows.Add(f.presentacion, f.categoria, f.C8, f.C10, f.C12, f.C14, f.C16, f.C18, f.C20, f.C22, f.C24, f.C26, f.C28, f.C30, f.C32, f.cantidad, f.sobrepeso, f.kilos);
                ldc_kilos_procesados += f.kilos;
            }

            tbxkilos_proceso.Text = ldc_kilos_procesados.ToString("###,##0.00");

            if (dgvpacking_calibre_det.RowCount > 0)
            {
                // PARA DESCARTE Y MUESTREO
                li_idlote = Convert.ToInt32(dgvpacking_calibre_cab.CurrentRow.Cells[8].Value);
                ldc_kilos_descarte = LConteo_manual.Kilos_Descarte(li_idlote);
                ldc_kilos_muestra = LConteo_manual.Kilos_Muestra();

                tbxkilos_descarte.Text = ldc_kilos_descarte.ToString("###,##0.00");
                tbxkilos_muestra.Text = ldc_kilos_muestra.ToString("###,##0.00");
                tbxtotal_kilos_muestra.Text = (ldc_kilos_descarte + ldc_kilos_muestra).ToString("###,##0.00");

                ldc_porc_descarte = ((ldc_kilos_descarte / ldc_kilos_ingresados) * 100);
                ldc_porc_muestra = ((ldc_kilos_muestra / ldc_kilos_ingresados) * 100);
                tbxporcentaje_descarte.Text = ldc_porc_descarte.ToString("###,##0.000");
                tbxporcentaje_muestra.Text = ldc_porc_muestra.ToString("###,##0.000");
                tbxtotal_porcentaje_muestra.Text = (ldc_porc_descarte + ldc_porc_muestra).ToString("###,##0.000"); ;

                // PARA EL RESUMEN
                ldc_porc_ingresado = ((ldc_kilos_ingresados / ldc_kilos_ingresados) * 100);
                ldc_porc_procesado = ((ldc_kilos_procesados / ldc_kilos_ingresados) * 100);
                tbxkilos_descarte_muestra.Text = tbxtotal_kilos_muestra.Text;
                tbxkilos_deshidratacion.Text = ((ldc_kilos_ingresados) - (ldc_kilos_procesados + ldc_kilos_descarte + ldc_kilos_muestra)).ToString("###,##0.00");

                tbxporcentaje_ingreso.Text = ldc_porc_ingresado.ToString();
                tbxporcentaje_proceso.Text = ldc_porc_procesado.ToString("###,##0.000");
                tbxporcentaje_desc_mues.Text = tbxtotal_porcentaje_muestra.Text;                
                tbxporcentaje_deshidratacion.Text = ((ldc_porc_ingresado) - (ldc_porc_procesado + ldc_porc_descarte + ldc_porc_muestra)).ToString("###,##0.000");


                decimal C08 = 0, C10 = 0, C12 = 0, C14 = 0, C16 = 0, C18 = 0, C20 = 0, C22 = 0, C24 = 0, C26 = 0, C28 = 0, C30 = 0, C32 = 0, Total_cant = 0, sobrepeso = 0, Total_kilos = 0;

                foreach (DataGridViewRow fila in dgvpacking_calibre_det.Rows)
                {
                    C08 += Convert.ToDecimal(fila.Cells[2].Value);
                    C10 += Convert.ToDecimal(fila.Cells[3].Value);
                    C12 += Convert.ToDecimal(fila.Cells[4].Value);
                    C14 += Convert.ToDecimal(fila.Cells[5].Value);
                    C16 += Convert.ToDecimal(fila.Cells[6].Value);
                    C18 += Convert.ToDecimal(fila.Cells[7].Value);
                    C20 += Convert.ToDecimal(fila.Cells[8].Value);
                    C22 += Convert.ToDecimal(fila.Cells[9].Value);
                    C24 += Convert.ToDecimal(fila.Cells[10].Value);
                    C26 += Convert.ToDecimal(fila.Cells[11].Value);
                    C28 += Convert.ToDecimal(fila.Cells[12].Value);
                    C30 += Convert.ToDecimal(fila.Cells[13].Value);
                    C32 += Convert.ToDecimal(fila.Cells[14].Value);
                    Total_cant += Convert.ToDecimal(fila.Cells[15].Value);
                    sobrepeso = Convert.ToDecimal(fila.Cells[16].Value);
                    Total_kilos += Convert.ToDecimal(fila.Cells[17].Value);
                }

                int fila_suma_cajas = dgvpacking_calibre_det.Rows.Add(null, "TOTAL CAJAS", C08, C10, C12, C14, C16, C18, C20, C22, C24, C26, C28, C30, C32, Total_cant, "0.00", Total_kilos);
                dgvpacking_calibre_det.Rows[fila_suma_cajas].DefaultCellStyle.Font = new System.Drawing.Font(dgvpacking_calibre_det.Font, System.Drawing.FontStyle.Bold);


                C08 = 0; C10 = 0; C12 = 0; C14 = 0; C16 = 0; C18 = 0; C20 = 0; C22 = 0; C24 = 0; C26 = 0; C28 = 0; C30 = 0; C32 = 0;

                foreach (DataGridViewRow fila in dgvpacking_calibre_det.Rows)
                {
                    C08 += Convert.ToDecimal(fila.Cells[2].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C10 += Convert.ToDecimal(fila.Cells[3].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C12 += Convert.ToDecimal(fila.Cells[4].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C14 += Convert.ToDecimal(fila.Cells[5].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C16 += Convert.ToDecimal(fila.Cells[6].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C18 += Convert.ToDecimal(fila.Cells[7].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C20 += Convert.ToDecimal(fila.Cells[8].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C22 += Convert.ToDecimal(fila.Cells[9].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C24 += Convert.ToDecimal(fila.Cells[10].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C26 += Convert.ToDecimal(fila.Cells[11].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C28 += Convert.ToDecimal(fila.Cells[12].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C30 += Convert.ToDecimal(fila.Cells[13].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                    C32 += Convert.ToDecimal(fila.Cells[14].Value) * Convert.ToDecimal(fila.Cells[16].Value);
                 
                }
                int fila_suma_kilos = dgvpacking_calibre_det.Rows.Add(null, "TOTAL KILOS", C08.ToString("#0.00"), C10.ToString("#0.00"), C12.ToString("#0.00"), C14.ToString("#0.00"), C16.ToString("#0.00"), C18.ToString("#0.00"), C20.ToString("#0.00"), C22.ToString("#0.00"), C24.ToString("###.00"), C26.ToString("#0.00"), C28.ToString("#0.00"), C30.ToString("#0.00"), C32.ToString("#0.00"), null, null, null);
                dgvpacking_calibre_det.Rows[fila_suma_kilos].DefaultCellStyle.Font = new System.Drawing.Font(dgvpacking_calibre_det.Font, System.Drawing.FontStyle.Bold);

                C08 = 0; C10 = 0; C12 = 0; C14 = 0; C16 = 0; C18 = 0; C20 = 0; C22 = 0; C24 = 0; C26 = 0; C28 = 0; C30 = 0; C32 = 0;

                foreach (DataGridViewRow fila in dgvpacking_calibre_det.Rows)
                {
                    C08 += (Convert.ToDecimal(fila.Cells[2].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C10 += (Convert.ToDecimal(fila.Cells[3].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C12 += (Convert.ToDecimal(fila.Cells[4].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C14 += (Convert.ToDecimal(fila.Cells[5].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C16 += (Convert.ToDecimal(fila.Cells[6].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C18 += (Convert.ToDecimal(fila.Cells[7].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C20 += (Convert.ToDecimal(fila.Cells[8].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C22 += (Convert.ToDecimal(fila.Cells[9].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C24 += (Convert.ToDecimal(fila.Cells[10].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C26 += (Convert.ToDecimal(fila.Cells[11].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C28 += (Convert.ToDecimal(fila.Cells[12].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C30 += (Convert.ToDecimal(fila.Cells[13].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;
                    C32 += (Convert.ToDecimal(fila.Cells[14].Value) * Convert.ToDecimal(fila.Cells[16].Value) / Total_kilos)*100;

                }
                int fila_suma_porcentaje = dgvpacking_calibre_det.Rows.Add(null, "% EXPORTABLE", C08.ToString("#0.000"), C10.ToString("#0.000"), C12.ToString("#0.000"), C14.ToString("#0.000"), C16.ToString("#0.000"), C18.ToString("#0.000"), C20.ToString("#0.000"), C22.ToString("#0.000"), C24.ToString("###.00"), C26.ToString("#0.000"), C28.ToString("#0.000"), C30.ToString("#0.00"), C32.ToString("#0.000"), null, null, null);
                dgvpacking_calibre_det.Rows[fila_suma_porcentaje].DefaultCellStyle.Font = new System.Drawing.Font(dgvpacking_calibre_det.Font, System.Drawing.FontStyle.Bold);
            }

        }

        void GeneraPDF(Packing_calibre_cab p)
        {
            try
            {

            
            var doc = new Document(PageSize.A4.Rotate(), 30, 20, 30, 20);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(AppDomain.CurrentDomain.BaseDirectory + "RESUMEN_BALANCE_MASA"+dtpf_produccion.Value.ToString("ddMMyyyy")+".pdf", FileMode.Create));

            // estas dos lineas es para el encavezado
            var tipo = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            var titulo_tabla = new iTextSharp.text.Font(tipo, 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var fuente1 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var fuente2 = new iTextSharp.text.Font(tipo, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            var fuente3 = new iTextSharp.text.Font(tipo, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var fuente4 = new iTextSharp.text.Font(tipo, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            var fuente_pp2 = new iTextSharp.text.Font(tipo, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            writer.PageEvent = new CustomPdfPageEvent();

            doc.Open();

            var logo = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory + "logoagricola.png");
            logo.SetAbsolutePosition(50, 500);
            logo.ScaleToFit(120f, 250f);
            logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;

            doc.Add(logo);

            var espacio = new Paragraph("\n");

            var TTabla01 = new PdfPTable(4);
            var columnas = new[] { 40, 80, 40, 80 };
            TTabla01.SetWidths(columnas);
            TTabla01.WidthPercentage = 70;
            TTabla01.HorizontalAlignment = Element.ALIGN_LEFT;

            var plan = new PdfPCell(new Paragraph("Planta : ", fuente1));
            plan.HorizontalAlignment = Element.ALIGN_RIGHT;
            plan.Border = 0;
            var planta = new PdfPCell(new Paragraph(p.nom_planta, fuente2));
            planta.HorizontalAlignment = Element.ALIGN_LEFT;
            planta.Border = 0;

            var produc = new PdfPCell(new Paragraph("Productor : ", fuente1));
            produc.HorizontalAlignment = Element.ALIGN_RIGHT;
            produc.Border = 0;
            var productor = new PdfPCell(new Paragraph(p.nom_acopiador, fuente2));
            productor.HorizontalAlignment = Element.ALIGN_LEFT;
            productor.Border = 0;

            var prod = new PdfPCell(new Paragraph("Producto : ", fuente1));
            prod.HorizontalAlignment = Element.ALIGN_RIGHT;
            prod.Border = 0;
            var producto = new PdfPCell(new Paragraph(p.variedad, fuente2));
            producto.HorizontalAlignment = Element.ALIGN_LEFT;
            producto.Border = 0;

            var fec_emp = new PdfPCell(new Paragraph("Fecha de Empaque : ", fuente1));
            fec_emp.HorizontalAlignment = Element.ALIGN_RIGHT;
            fec_emp.Border = 0;
            var fecha_empaque = new PdfPCell(new Paragraph(p.fecha_produccion.ToString("dd/MM/yyyy"), fuente2));
            fecha_empaque.HorizontalAlignment = Element.ALIGN_LEFT;
            fecha_empaque.Border = 0;

            TTabla01.AddCell(plan);
            TTabla01.AddCell(planta);
            TTabla01.AddCell(produc);
            TTabla01.AddCell(productor);
            TTabla01.AddCell(prod);
            TTabla01.AddCell(producto);
            TTabla01.AddCell(fec_emp);
            TTabla01.AddCell(fecha_empaque);

            // TITULO TABLA02
            var TTabla02 = new PdfPTable(1);
            TTabla02.WidthPercentage = 100;
            var tit = new PdfPCell(new Paragraph("INGRESO A PROCESO", fuente1));
            tit.HorizontalAlignment = Element.ALIGN_CENTER;
            tit.BackgroundColor = BaseColor.LIGHT_GRAY;
            tit.PaddingBottom = 5f;
            tit.Colspan = 4;
            TTabla02.AddCell(tit);

            // NOMBRES DE LAS COLIMNAS INGRESO PROCESO
            var TTituloLista1 = new PdfPTable(8);
            var ancho1 = new[] { 50, 50, 50, 50, 150, 35, 35, 35 };
            TTituloLista1.SetWidths(ancho1);
            TTituloLista1.WidthPercentage = 100;
            TTituloLista1.HorizontalAlignment = Element.ALIGN_CENTER;

            var fec = new PdfPCell(new Paragraph("FECHA", fuente1));
            fec.HorizontalAlignment = Element.ALIGN_CENTER;
            fec.BackgroundColor = BaseColor.LIGHT_GRAY;
            fec.PaddingBottom = 5f;

            var lot = new PdfPCell(new Paragraph("LOTE", fuente1));
            lot.HorizontalAlignment = Element.ALIGN_CENTER;
            lot.BackgroundColor = BaseColor.LIGHT_GRAY;
            lot.PaddingBottom = 5f;

            var clp = new PdfPCell(new Paragraph("CLP", fuente1));
            clp.HorizontalAlignment = Element.ALIGN_CENTER;
            clp.BackgroundColor = BaseColor.LIGHT_GRAY;
            clp.PaddingBottom = 5f;

            var n_guia = new PdfPCell(new Paragraph("N° GUIA", fuente1));
            n_guia.HorizontalAlignment = Element.ALIGN_CENTER;
            n_guia.BackgroundColor = BaseColor.LIGHT_GRAY;
            n_guia.PaddingBottom = 5f;

            var clien = new PdfPCell(new Paragraph("CLIENTE", fuente1));
            clien.HorizontalAlignment = Element.ALIGN_CENTER;
            clien.BackgroundColor = BaseColor.LIGHT_GRAY;
            clien.PaddingBottom = 5f;

            var cant = new PdfPCell(new Paragraph("CANTIDAD", fuente1));
            cant.HorizontalAlignment = Element.ALIGN_CENTER;
            cant.BackgroundColor = BaseColor.LIGHT_GRAY;
            cant.PaddingBottom = 5f;

            var kil = new PdfPCell(new Paragraph("KILOS", fuente1));
            kil.HorizontalAlignment = Element.ALIGN_CENTER;
            kil.BackgroundColor = BaseColor.LIGHT_GRAY;
            kil.PaddingBottom = 5f;

            var prm_jab = new PdfPCell(new Paragraph("PRM. JABAS", fuente1));
            prm_jab.HorizontalAlignment = Element.ALIGN_CENTER;
            prm_jab.BackgroundColor = BaseColor.LIGHT_GRAY;
            prm_jab.PaddingBottom = 5f;

            TTituloLista1.AddCell(new PdfPCell(fec));
            TTituloLista1.AddCell(new PdfPCell(lot));
            TTituloLista1.AddCell(new PdfPCell(clp));
            TTituloLista1.AddCell(new PdfPCell(n_guia));
            TTituloLista1.AddCell(new PdfPCell(clien));
            TTituloLista1.AddCell(new PdfPCell(cant));
            TTituloLista1.AddCell(new PdfPCell(kil));
            TTituloLista1.AddCell(new PdfPCell(prm_jab));

            // INFORMACION INGRESO PROCESO
            var TTablaLista1 = new PdfPTable(8);
            var ancho2 = new[] { 50, 50, 50, 50, 150, 35, 35, 35 };
            TTablaLista1.SetWidths(ancho2);
            TTablaLista1.WidthPercentage = 100;

            foreach (DataGridViewRow ele in dgvpacking_calibre_cab.Rows)
            {
                var fecha = new PdfPCell(new Paragraph(ele.Cells[6].Value.ToString(), fuente2));
                fecha.HorizontalAlignment = Element.ALIGN_CENTER;

                var lote = new PdfPCell(new Paragraph(ele.Cells[9].Value.ToString(), fuente2));
                lote.HorizontalAlignment = Element.ALIGN_CENTER;

                var clp1 = new PdfPCell(new Paragraph(ele.Cells[7].Value.ToString(), fuente2));
                clp1.HorizontalAlignment = Element.ALIGN_CENTER;

                var num_guia = new PdfPCell(new Paragraph(ele.Cells[10].Value.ToString(), fuente2));
                num_guia.HorizontalAlignment = Element.ALIGN_CENTER;

                var cliente = new PdfPCell(new Paragraph(ele.Cells[14].Value.ToString(), fuente2));

                var cantidad = new PdfPCell(new Paragraph(ele.Cells[16].Value.ToString(), fuente2));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;

                var kilos = new PdfPCell(new Paragraph(ele.Cells[19].Value.ToString(), fuente2));
                kilos.HorizontalAlignment = Element.ALIGN_RIGHT;

                var prm_jabas = new PdfPCell(new Paragraph(ele.Cells[20].Value.ToString(), fuente2));
                prm_jabas.HorizontalAlignment = Element.ALIGN_RIGHT;


                TTablaLista1.AddCell(new PdfPCell(fecha));
                TTablaLista1.AddCell(new PdfPCell(lote));
                TTablaLista1.AddCell(new PdfPCell(clp1));
                TTablaLista1.AddCell(new PdfPCell(num_guia));
                TTablaLista1.AddCell(new PdfPCell(cliente));
                TTablaLista1.AddCell(new PdfPCell(cantidad));
                TTablaLista1.AddCell(new PdfPCell(kilos));
                TTablaLista1.AddCell(new PdfPCell(prm_jabas));
            }           

            // TITULO TABLA03
            var TTabla03 = new PdfPTable(1);
            TTabla03.WidthPercentage = 100;
            var tit2 = new PdfPCell(new Paragraph("RESULTADO DEL PROCESO", fuente1));
            tit2.HorizontalAlignment = Element.ALIGN_CENTER;
            tit2.BackgroundColor = BaseColor.LIGHT_GRAY;
            tit2.PaddingBottom = 5f;
            tit2.Colspan = 4;
            TTabla03.AddCell(tit2);

            // NOMBRES DE LAS COLUMNAS RESULTADO DEL PROCESO
            var TTituloLista2 = new PdfPTable(18);
            var ancho3 = new[] { 50, 50, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 35, 35, 35 };
            TTituloLista2.SetWidths(ancho3);
            TTituloLista2.WidthPercentage = 100;
            TTituloLista2.HorizontalAlignment = Element.ALIGN_CENTER;

            var enva = new PdfPCell(new Paragraph("ENVASE", fuente3));
            enva.HorizontalAlignment = Element.ALIGN_CENTER;
            enva.BackgroundColor = BaseColor.LIGHT_GRAY;
            enva.PaddingBottom = 5f;

            var cat = new PdfPCell(new Paragraph("CATEGORIA", fuente3));
            cat.HorizontalAlignment = Element.ALIGN_CENTER;
            cat.BackgroundColor = BaseColor.LIGHT_GRAY;
            cat.PaddingBottom = 5f;

            var t8 = new PdfPCell(new Paragraph("8", fuente3));
            t8.HorizontalAlignment = Element.ALIGN_CENTER;
            t8.BackgroundColor = BaseColor.LIGHT_GRAY;
            t8.PaddingBottom = 5f;

            var t10 = new PdfPCell(new Paragraph("10", fuente3));
            t10.HorizontalAlignment = Element.ALIGN_CENTER;
            t10.BackgroundColor = BaseColor.LIGHT_GRAY;
            t10.PaddingBottom = 5f;

            var t12 = new PdfPCell(new Paragraph("12", fuente3));
            t12.HorizontalAlignment = Element.ALIGN_CENTER;
            t12.BackgroundColor = BaseColor.LIGHT_GRAY;
            t12.PaddingBottom = 5f;

            var t14 = new PdfPCell(new Paragraph("14", fuente3));
            t14.HorizontalAlignment = Element.ALIGN_CENTER;
            t14.BackgroundColor = BaseColor.LIGHT_GRAY;
            t14.PaddingBottom = 5f;

            var t16 = new PdfPCell(new Paragraph("16", fuente3));
            t16.HorizontalAlignment = Element.ALIGN_CENTER;
            t16.BackgroundColor = BaseColor.LIGHT_GRAY;
            t16.PaddingBottom = 5f;

            var t18 = new PdfPCell(new Paragraph("18", fuente3));
            t18.HorizontalAlignment = Element.ALIGN_CENTER;
            t18.BackgroundColor = BaseColor.LIGHT_GRAY;
            t18.PaddingBottom = 5f;

            var t20 = new PdfPCell(new Paragraph("20", fuente3));
            t20.HorizontalAlignment = Element.ALIGN_CENTER;
            t20.BackgroundColor = BaseColor.LIGHT_GRAY;
            fec.PaddingBottom = 5f;

            var t22 = new PdfPCell(new Paragraph("22", fuente3));
            t22.HorizontalAlignment = Element.ALIGN_CENTER;
            t22.BackgroundColor = BaseColor.LIGHT_GRAY;
            t22.PaddingBottom = 5f;

            var t24 = new PdfPCell(new Paragraph("24", fuente3));
            t24.HorizontalAlignment = Element.ALIGN_CENTER;
            t24.BackgroundColor = BaseColor.LIGHT_GRAY;
            t24.PaddingBottom = 5f;

            var t26 = new PdfPCell(new Paragraph("26", fuente3));
            t26.HorizontalAlignment = Element.ALIGN_CENTER;
            t26.BackgroundColor = BaseColor.LIGHT_GRAY;
            t26.PaddingBottom = 5f;

            var t28 = new PdfPCell(new Paragraph("28", fuente3));
            t28.HorizontalAlignment = Element.ALIGN_CENTER;
            t28.BackgroundColor = BaseColor.LIGHT_GRAY;
            t28.PaddingBottom = 5f;

            var t30 = new PdfPCell(new Paragraph("30", fuente3));
            t30.HorizontalAlignment = Element.ALIGN_CENTER;
            t30.BackgroundColor = BaseColor.LIGHT_GRAY;
            t30.PaddingBottom = 5f;

            var t32 = new PdfPCell(new Paragraph("32", fuente3));
            t32.HorizontalAlignment = Element.ALIGN_CENTER;
            t32.BackgroundColor = BaseColor.LIGHT_GRAY;
            t32.PaddingBottom = 5f;

            var cant2 = new PdfPCell(new Paragraph("CANTIDAD", fuente3));
            cant2.HorizontalAlignment = Element.ALIGN_CENTER;
            cant2.BackgroundColor = BaseColor.LIGHT_GRAY;
            cant2.PaddingBottom = 5f;

            var sobrep = new PdfPCell(new Paragraph("SOBREPESO", fuente3));
            sobrep.HorizontalAlignment = Element.ALIGN_CENTER;
            sobrep.BackgroundColor = BaseColor.LIGHT_GRAY;
            sobrep.PaddingBottom = 5f;

            var kil2 = new PdfPCell(new Paragraph("KILOS", fuente3));
            kil2.HorizontalAlignment = Element.ALIGN_CENTER;
            kil2.BackgroundColor = BaseColor.LIGHT_GRAY;
            kil2.PaddingBottom = 5f;

            TTituloLista2.AddCell(new PdfPCell(enva));
            TTituloLista2.AddCell(new PdfPCell(cat));
            TTituloLista2.AddCell(new PdfPCell(t8));
            TTituloLista2.AddCell(new PdfPCell(t10));
            TTituloLista2.AddCell(new PdfPCell(t12));
            TTituloLista2.AddCell(new PdfPCell(t14));
            TTituloLista2.AddCell(new PdfPCell(t16));
            TTituloLista2.AddCell(new PdfPCell(t18));
            TTituloLista2.AddCell(new PdfPCell(t20));
            TTituloLista2.AddCell(new PdfPCell(t22));
            TTituloLista2.AddCell(new PdfPCell(t24));
            TTituloLista2.AddCell(new PdfPCell(t26));
            TTituloLista2.AddCell(new PdfPCell(t28));
            TTituloLista2.AddCell(new PdfPCell(t30));
            TTituloLista2.AddCell(new PdfPCell(t32));
            TTituloLista2.AddCell(new PdfPCell(cant2));
            TTituloLista2.AddCell(new PdfPCell(sobrep));
            TTituloLista2.AddCell(new PdfPCell(kil2));

            // INFORMACION RESULTADO DE PROCESO
            var TTablaLista2 = new PdfPTable(18);
            var ancho4 = new[] { 50, 50, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 35, 35, 35 };
            TTablaLista2.SetWidths(ancho4);
            TTablaLista2.WidthPercentage = 100;

            foreach (DataGridViewRow ele in dgvpacking_calibre_det.Rows)
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

                var c16 = new PdfPCell(new Paragraph(ele.Cells[6].Value.ToString(), fuente4));
                c16.HorizontalAlignment = Element.ALIGN_CENTER;

                var c18 = new PdfPCell(new Paragraph(ele.Cells[7].Value.ToString(), fuente4));
                c18.HorizontalAlignment = Element.ALIGN_CENTER;

                var c20 = new PdfPCell(new Paragraph(ele.Cells[8].Value.ToString(), fuente4));
                c20.HorizontalAlignment = Element.ALIGN_CENTER;

                var c22 = new PdfPCell(new Paragraph(ele.Cells[9].Value.ToString(), fuente4));
                c22.HorizontalAlignment = Element.ALIGN_CENTER;

                var c24 = new PdfPCell(new Paragraph(ele.Cells[10].Value.ToString(), fuente4));
                c24.HorizontalAlignment = Element.ALIGN_CENTER;

                var c26 = new PdfPCell(new Paragraph(ele.Cells[11].Value.ToString(), fuente4));
                c26.HorizontalAlignment = Element.ALIGN_CENTER;

                var c28 = new PdfPCell(new Paragraph(ele.Cells[12].Value.ToString(), fuente4));
                c28.HorizontalAlignment = Element.ALIGN_CENTER;

                var c30 = new PdfPCell(new Paragraph(ele.Cells[12].Value.ToString(), fuente4));
                c30.HorizontalAlignment = Element.ALIGN_CENTER;

                var c32 = new PdfPCell(new Paragraph(ele.Cells[14].Value.ToString(), fuente4));
                c32.HorizontalAlignment = Element.ALIGN_CENTER;

                var cantidad = new PdfPCell(new Paragraph(ele.Cells[15].Value == null ? "" : ele.Cells[15].Value.ToString(), fuente4));
                cantidad.HorizontalAlignment = Element.ALIGN_CENTER;

                var sobrepeso = new PdfPCell(new Paragraph(ele.Cells[16].Value == null ? "" : ele.Cells[16].Value.ToString(), fuente4));
                sobrepeso.HorizontalAlignment = Element.ALIGN_RIGHT;

                var kilos = new PdfPCell(new Paragraph(ele.Cells[17].Value == null ? "" : ele.Cells[17].Value.ToString(), fuente4));
                kilos.HorizontalAlignment = Element.ALIGN_RIGHT;               


                TTablaLista2.AddCell(new PdfPCell(envase));
                TTablaLista2.AddCell(new PdfPCell(categoria));
                TTablaLista2.AddCell(new PdfPCell(c8));
                TTablaLista2.AddCell(new PdfPCell(c10));
                TTablaLista2.AddCell(new PdfPCell(c12));
                TTablaLista2.AddCell(new PdfPCell(c14));
                TTablaLista2.AddCell(new PdfPCell(c16));
                TTablaLista2.AddCell(new PdfPCell(c18));
                TTablaLista2.AddCell(new PdfPCell(c20));
                TTablaLista2.AddCell(new PdfPCell(c22));
                TTablaLista2.AddCell(new PdfPCell(c24));
                TTablaLista2.AddCell(new PdfPCell(c26));
                TTablaLista2.AddCell(new PdfPCell(c28));
                TTablaLista2.AddCell(new PdfPCell(c30));
                TTablaLista2.AddCell(new PdfPCell(c32));
                TTablaLista2.AddCell(new PdfPCell(cantidad));
                TTablaLista2.AddCell(new PdfPCell(sobrepeso));
                TTablaLista2.AddCell(new PdfPCell(kilos));                
            }

            // TITULO TABLA04
            var TTabla04 = new PdfPTable(1);
            TTabla04.WidthPercentage = 100;
            var tit3 = new PdfPCell(new Paragraph("DESCARTE / MUESTRA", fuente1));
            tit3.HorizontalAlignment = Element.ALIGN_CENTER;
            tit3.BackgroundColor = BaseColor.LIGHT_GRAY;
            tit3.PaddingBottom = 5f;
            tit3.Colspan = 4;
            TTabla04.AddCell(tit3);

            // TABLA DESCARTE - MUESTRA
            var TTabla05 = new PdfPTable(4);
            var columnas4 = new[] { 250, 70, 10, 70 };
            TTabla05.SetWidths(columnas4);
            TTabla05.WidthPercentage = 100;
            TTabla05.HorizontalAlignment = Element.ALIGN_LEFT;

            var tit01 = new PdfPCell(new Paragraph("", fuente1));
            tit01.HorizontalAlignment = Element.ALIGN_RIGHT;
            tit01.Border = 0;
            var titulo01 = new PdfPCell(new Paragraph("KILOS", fuente1));
            titulo01.HorizontalAlignment = Element.ALIGN_RIGHT;
            titulo01.Border = 0;

            var tit02 = new PdfPCell(new Paragraph("", fuente1));
            tit02.HorizontalAlignment = Element.ALIGN_RIGHT;
            tit02.Border = 0;
            var titulo02 = new PdfPCell(new Paragraph("PORCENTAJE", fuente1));
            titulo02.HorizontalAlignment = Element.ALIGN_RIGHT;
            titulo02.Border = 0;

            var descar_k = new PdfPCell(new Paragraph("DESCARTE", fuente1));
            descar_k.HorizontalAlignment = Element.ALIGN_LEFT;
            descar_k.Border = 0;
            var descarte_k = new PdfPCell(new Paragraph(tbxkilos_descarte.Text, fuente2));
            descarte_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            descarte_k.Border = 0;

            var descar_p = new PdfPCell(new Paragraph("", fuente1));
            descar_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            descar_p.Border = 0;
            var descarte_p = new PdfPCell(new Paragraph(tbxporcentaje_descarte.Text, fuente2));
            descarte_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            descarte_p.Border = 0;

            var mues_k = new PdfPCell(new Paragraph("MUESTRA", fuente1));
            mues_k.HorizontalAlignment = Element.ALIGN_LEFT;
            mues_k.Border = 0;
            var muestra_k = new PdfPCell(new Paragraph(tbxkilos_muestra.Text, fuente2));
            muestra_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            muestra_k.Border = 0;

            var mues_p = new PdfPCell(new Paragraph("", fuente1));
            mues_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            mues_p.Border = 0;
            var muestra_p = new PdfPCell(new Paragraph(tbxporcentaje_muestra.Text, fuente2));
            muestra_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            muestra_p.Border = 0;

            var tot_k = new PdfPCell(new Paragraph("TOTAL GENERAL", fuente1));
            tot_k.HorizontalAlignment = Element.ALIGN_LEFT;
            tot_k.Border = 0;
            var total_k = new PdfPCell(new Paragraph(tbxtotal_kilos_muestra.Text, fuente2));
            total_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            total_k.Border = 0;

            var tot_p = new PdfPCell(new Paragraph("", fuente1));
            tot_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            tot_p.Border = 0;
            var total_p = new PdfPCell(new Paragraph(tbxtotal_porcentaje_muestra.Text, fuente2));
            total_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            total_p.Border = 0;

            TTabla05.AddCell(tit01);
            TTabla05.AddCell(titulo01);
            TTabla05.AddCell(tit02);
            TTabla05.AddCell(titulo02);
            TTabla05.AddCell(descar_k);
            TTabla05.AddCell(descarte_k);
            TTabla05.AddCell(descar_p);
            TTabla05.AddCell(descarte_p);
            TTabla05.AddCell(mues_k);
            TTabla05.AddCell(muestra_k);
            TTabla05.AddCell(mues_p);
            TTabla05.AddCell(muestra_p);
            TTabla05.AddCell(tot_k);
            TTabla05.AddCell(total_k);
            TTabla05.AddCell(tot_p);
            TTabla05.AddCell(total_p);


            // TITULO TABLA05
            var TTabla06 = new PdfPTable(1);
            TTabla06.WidthPercentage = 100;
            var tit4 = new PdfPCell(new Paragraph("RESUMEN", fuente1));
            tit4.HorizontalAlignment = Element.ALIGN_CENTER;
            tit4.BackgroundColor = BaseColor.LIGHT_GRAY;
            tit4.PaddingBottom = 5f;
            tit4.Colspan = 4;
            TTabla06.AddCell(tit4);

            // TABLA DESCARTE - MUESTRA
            var TTabla07 = new PdfPTable(4);
            var columnas5 = new[] { 250, 70, 10, 70 };
            TTabla07.SetWidths(columnas5);
            TTabla07.WidthPercentage = 100;
            TTabla07.HorizontalAlignment = Element.ALIGN_LEFT;

            var tit1 = new PdfPCell(new Paragraph("", fuente1));
            tit1.HorizontalAlignment = Element.ALIGN_RIGHT;
            tit1.Border = 0;
            var titulo1 = new PdfPCell(new Paragraph("KILOS", fuente1));
            titulo1.HorizontalAlignment = Element.ALIGN_RIGHT;
            titulo1.Border = 0;

            var tit5 = new PdfPCell(new Paragraph("", fuente1));
            tit5.HorizontalAlignment = Element.ALIGN_RIGHT;
            tit5.Border = 0;
            var titulo5 = new PdfPCell(new Paragraph("PORCENTAJE", fuente1));
            titulo5.HorizontalAlignment = Element.ALIGN_RIGHT;
            titulo5.Border = 0;

            var ingreso_k = new PdfPCell(new Paragraph("INGRESO PROCESO", fuente1));
            ingreso_k.HorizontalAlignment = Element.ALIGN_LEFT;
            ingreso_k.Border = 0;
            var ingreso_proceso_k = new PdfPCell(new Paragraph(tbxkilos_ingreso.Text, fuente2));
            ingreso_proceso_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            ingreso_proceso_k.Border = 0;

            var ingreso_p = new PdfPCell(new Paragraph("", fuente1));
            ingreso_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            ingreso_p.Border = 0;
            var ingreso_proceso_p = new PdfPCell(new Paragraph(tbxporcentaje_ingreso.Text, fuente2));
            ingreso_proceso_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            ingreso_proceso_p.Border = 0;

            var resul_k = new PdfPCell(new Paragraph("RESULTADO PROCESO", fuente1));
            resul_k.HorizontalAlignment = Element.ALIGN_LEFT;
            resul_k.Border = 0;
            var resultado_proceso_k = new PdfPCell(new Paragraph(tbxkilos_proceso.Text, fuente2));
            resultado_proceso_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            resultado_proceso_k.Border = 0;

            var resul_p = new PdfPCell(new Paragraph("", fuente1));
            resul_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            resul_p.Border = 0;
            var resultado_proceso_p = new PdfPCell(new Paragraph(tbxporcentaje_proceso.Text, fuente2));
            resultado_proceso_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            resultado_proceso_p.Border = 0;

            var des_mue_k = new PdfPCell(new Paragraph("DESCARTE / MUESTRA", fuente1));
            des_mue_k.HorizontalAlignment = Element.ALIGN_LEFT;
            des_mue_k.Border = 0;
            var descarte_muetra_k = new PdfPCell(new Paragraph(tbxkilos_descarte_muestra.Text, fuente2));
            descarte_muetra_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            descarte_muetra_k.Border = 0;

            var des_mue_p = new PdfPCell(new Paragraph("", fuente1));
            des_mue_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            des_mue_p.Border = 0;
            var descarte_muetra_p = new PdfPCell(new Paragraph(tbxporcentaje_desc_mues.Text, fuente2));
            descarte_muetra_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            descarte_muetra_p.Border = 0;

            var deshidra_k = new PdfPCell(new Paragraph("DESHIDRATACIÓN", fuente1));
            deshidra_k.HorizontalAlignment = Element.ALIGN_LEFT;
            deshidra_k.Border = 0;
            var deshidratacion_k = new PdfPCell(new Paragraph(tbxkilos_deshidratacion.Text, fuente2));
            deshidratacion_k.HorizontalAlignment = Element.ALIGN_RIGHT;
            deshidratacion_k.Border = 0;

            var deshidra_p = new PdfPCell(new Paragraph("", fuente1));
            deshidra_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            deshidra_p.Border = 0;
            var deshidratacion_p = new PdfPCell(new Paragraph(tbxporcentaje_deshidratacion.Text, fuente2));
            deshidratacion_p.HorizontalAlignment = Element.ALIGN_RIGHT;
            deshidratacion_p.Border = 0;

            TTabla07.AddCell(tit1);
            TTabla07.AddCell(titulo1);
            TTabla07.AddCell(tit5);
            TTabla07.AddCell(titulo5);
            TTabla07.AddCell(ingreso_k);
            TTabla07.AddCell(ingreso_proceso_k);
            TTabla07.AddCell(ingreso_p);
            TTabla07.AddCell(ingreso_proceso_p);
            TTabla07.AddCell(resul_k);
            TTabla07.AddCell(resultado_proceso_k);
            TTabla07.AddCell(resul_p);
            TTabla07.AddCell(resultado_proceso_p);
            TTabla07.AddCell(des_mue_k);
            TTabla07.AddCell(descarte_muetra_k);
            TTabla07.AddCell(des_mue_p);
            TTabla07.AddCell(descarte_muetra_p);
            TTabla07.AddCell(deshidra_k);
            TTabla07.AddCell(deshidratacion_k);
            TTabla07.AddCell(deshidra_p);
            TTabla07.AddCell(deshidratacion_p);

            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(TTabla01);
            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(TTabla02);               
            doc.Add(TTituloLista1);
            doc.Add(TTablaLista1);
            doc.Add(espacio);
            doc.Add(TTabla03);
            doc.Add(TTituloLista2);
            doc.Add(TTablaLista2);
            doc.Add(espacio);
            doc.Add(TTabla04);
            doc.Add(TTabla05);
            doc.Add(espacio);
            doc.Add(TTabla06);
            doc.Add(TTabla07);

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

                string pageText = "RESUMEN BALANCE DE MASA DE PRODUCCION";

                // Crear una instancia de PdfContentByte para trabajar con el contenido de la página
                PdfContentByte cb = writer.DirectContent;

                // Configurar la fuente y el tamaño de la fuente
                cb.SetFontAndSize(baseFont, 12);

                // Escribir el número de página en el contenido del PDF
                PdfContentByte canvas = writer.DirectContent;

                // Position the header at the top of the page
                canvas.BeginText();
                canvas.SetTextMatrix(300, 520); // Adjust the position as needed
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
        

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvpacking_calibre_cab.RowCount; i++)
            {
                Packing_calibre_cab pcc = new Packing_calibre_cab();
                pcc.nom_acopiador = dgvpacking_calibre_cab.Rows[i].Cells[4].Value.ToString();
                pcc.nom_planta = dgvpacking_calibre_cab.Rows[i].Cells[0].Value.ToString();
                pcc.fecha_produccion = Convert.ToDateTime(dgvpacking_calibre_cab.Rows[i].Cells[6].Value.ToString());
                pcc.variedad = dgvpacking_calibre_cab.Rows[i].Cells[12].Value.ToString();

                GeneraPDF(pcc);
            }            
        }
    }
}
