using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

//using QuestPDF;
//using QuestPDF.Infrastructure;
//using Microsoft.Office.Interop.Excel;
//using objExcel  = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptBoletaPesadoDetalle : Form

    {
        //  String nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string nombreArchivo = "C:/archivo.xlsx";

        // Label[] labels = new Label[] { lblciente, label2, label3, label4, label5, label6 };


        public RptBoletaPesadoDetalle(string[] filaConDatos, DataTable data)
        {
            InitializeComponent();
            PrepGrid();
            //contar();
            //sumaneto();

         //   Settings.License = LicenseType.Community;

            if (filaConDatos.Length >= 5)
            {
                lblnumlote.Text = filaConDatos[0];
                lblguiaingreso.Text = filaConDatos[1];
                //   lblnumdoc.Text = filaConDatos[2];
                lblfechaingreso.Text = filaConDatos[3];
                lblhoraingreso.Text = filaConDatos[4];
                lblproducto.Text = filaConDatos[4];
                lblvariedad.Text = filaConDatos[5];
                lblcliente.Text = filaConDatos[6];
                lblproductor.Text = filaConDatos[7];
                lblclp.Text = filaConDatos[8];
                lblcantjabas.Text = filaConDatos[9];
                totalneto.Text = filaConDatos[10];
                // lblservicio  .Text = filaConDatos[4];
                //   lblmetodo.Text = filaConDatos[2];

                datalistado.DataSource = data;
                ocultar_columnas2();
            }
        }
        
        private void RptBoletaPesado_Load(object sender, EventArgs e)
        {
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //  mostrarconsulta();
        }

        private void PrepGrid()
        {
            {
                var withBlock = datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 11.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

                // 
                // establecer color de resaltado (opcional)
                // 
                withBlock.DefaultCellStyle.SelectionBackColor = Color.Red;
                withBlock.DefaultCellStyle.SelectionForeColor = Color.Yellow;

                // 
                // propiedades relacionadas con agregar / eliminar filas
                // 
                withBlock.AllowUserToAddRows = false;
                withBlock.AllowUserToDeleteRows = false;

                // 
                // propiedades relacionadas con cambiar el tamaño de columnas / filas en la celda tingkal
                // 
                withBlock.AllowUserToResizeColumns = false;
                withBlock.AllowUserToResizeRows = false;

                // 
                // propiedades que permiten al usuario ordenar columnas
                // 'haciendo clic en los encabezados de columna
                withBlock.AllowUserToOrderColumns = false;

                withBlock.BorderStyle = BorderStyle.None;

                // propiedades que regulan las líneas uniformes de "cosméticos"
                // 
                withBlock.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;

                // propiedades relacionadas con el formato del encabezado de columna / encabezado de columna
                // NB. para poder aplicar ForeColor y BackColor al encabezado, luego
                // La propiedad EnableHeadersVisualStyles debe establecerse en FALSE
                // 
                withBlock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                withBlock.ColumnHeadersHeight = 40;
                withBlock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                withBlock.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Tahoma", 11.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
                withBlock.EnableHeadersVisualStyles = false;
                withBlock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                withBlock.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                withBlock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // 
                // dado que DataGridView es solo para mostrar datos, no para medios de entrada de datos
                // luego ocultar RowHeader será mejor visto
                // 
                withBlock.RowHeadersVisible = false;
                withBlock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                // 

                // establecer columnas y filas de cambio de tamaño automático
                withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                withBlock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // 
                // determina la altura de todas las filas
                // 
                withBlock.RowTemplate.Height = 20;

                // establecer el modo de selección
                // 
                withBlock.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                // 'establecer selección múltiple (elija más de 1 fila)  '
                withBlock.MultiSelect = true;

                // el siguiente es el formato por columna
                // ajusta la posición del texto en la celda

                withBlock.ResumeLayout();
                withBlock.PerformLayout();
            }
        }

        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;

                //withBlock.Columns["LOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["LOTE"].Width = 0;

                // establecer modo de ajuste
                // .Columns("NOMBRE_PRODUCTO").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                withBlock.Columns["T. JABA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T. JABA"].Width = 50;

                withBlock.Columns["T.PARIH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T.PARIH"].Width = 110;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("PESAJE").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["CANT JABAS"].Width = 100;


                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 70;


                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO JABAS"].Width = 90;

                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 90;

                withBlock.Columns["PROMEDIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PROMEDIO"].Width = 90;
            }
            catch (Exception)
            {
                //  throw;
            }

            {
            }
        }

        private void ocultar_columnas()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[8].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            var contarfila = datalistado.RowCount - 1;
            var contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }

            LBLCONTAR.Text = Strings.FormatNumber(contador, 0);
        }

        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                }

                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //  ExportarExcel( nombreArchivo);
        }


        private void RptBoletaPesadoDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.ke == (Char)Keys.Escape)
            //    this.Close();
        }

        private void RptBoletaPesadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void ocultar_columnas2()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[8].Visible = false;
        }

        const string LogoPath = "logoagricola.png";
        private void GenerarPDF2()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(0, QuestPDF.Infrastructure.Unit.Centimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(14));

                    pagina.Header().Element(CrearCabecera);
                    pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf("Theathoq.pdf");
            Process.Start("Theathoq.pdf");
        }

        void CrearCabecera(IContainer container)
        {
            container.Column(col =>
            {
                //   col.Item().Image(LogoPath);


                col.Item().Row(row =>
                {
                    row.RelativeItem().AlignLeft()
                        .Row(rowitem =>
                        {
                            rowitem.AutoItem().Width(180).Height(80).Image(LogoPath);
                        });
                    //    col.Spacing(10);
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Cell().AlignRight().Text("          Boleta de Pesado - Lote N° ").SemiBold().FontSize(18)
                            .FontColor(Colors.Orange.Medium);
                        table.Cell().AlignLeft().Text("  " + lblnumlote.Text).SemiBold().FontSize(18)
                            .FontColor(Colors.Black);
                        col.Spacing(10);
                        //col.Item().AlignCenter().Text("Boleta de Pesado - Lote N° ")
                        //    .SemiBold().FontSize(18).FontColor(Colors.Orange.Medium);
                        //col.Spacing(10);
                    });
                });
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });
                    table.Cell().Text("        Cliente :");
                    table.Cell().Text(lblcliente.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Guia de Remision :");
                    table.Cell().Text(lblguiaingreso.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Productor :");
                    table.Cell().Text(lblproductor.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   RUC / DNI :");
                    table.Cell().Text(lblruc_dni.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Metodo :");
                    table.Cell().Text(lblmetodo.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   CLP :");
                    table.Cell().Text(lblclp.Text);

                    table.Cell().Text("        Producto :");
                    table.Cell().Text(lblproducto.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Variedad :");
                    table.Cell().Text(lblvariedad.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Tipo de Servicio :");
                    table.Cell().Text(lblservicio.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Fecha Ingreso :");
                    table.Cell().Text(lblfechaingreso.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Acopiador :");
                    table.Cell().Text(lblacopiador.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Hora Ingreso");
                    table.Cell().Text(lblhoraingreso.Text).FontSize(12).FontColor(Colors.Black).Bold();
                });
            });
        }


        void CrearContenido(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Table(table =>
                {
                    QuestPDF.Infrastructure.IContainer DefaultCellStyle(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                            .Border(0.5f)
                            .BorderColor(Colors.Grey.Lighten1)
                            .Background(backgroundColor)

                            .PaddingVertical(5)
                            .PaddingHorizontal(10)
                            .AlignCenter()
                            .AlignMiddle();
                    }

                    QuestPDF.Infrastructure.IContainer DefaultCellStyle2(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                              .Border(0.5f)
                              .BorderColor(Colors.Grey.Lighten1)
                              .Background(Colors.White)

                              .PaddingVertical(5)
                              .PaddingHorizontal(10);
                    }

                    QuestPDF.Infrastructure.IContainer DefaultCellStyleGroup(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                              .Border(0.5f)
                                .BorderColor(Colors.Grey.Lighten1)
                              .Background("#f0f0f0")

                              .PaddingVertical(5)
                              .PaddingHorizontal(10);
                    }

                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);

                    });



                    table.Header(header =>
                    {
                        //foreach (DataGridViewRow row in datalistado.Rows)
                        //{
                        header.Cell().Element(CellStyle).Text("T. JABA").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("T. PARIH").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("CANT JABAS").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO BRUTO").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO JABAS").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO NETO").FontSize(12).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PROM").FontSize(12).FontColor(Colors.White).Bold();

                        QuestPDF.Infrastructure.IContainer
                            CellStyle(QuestPDF.Infrastructure.IContainer containers) =>
                            DefaultCellStyle(containers, Colors.Blue.Medium);
                        //}

                    });

                    foreach (DataGridViewRow row in datalistado.Rows)
                    {

                        table.Cell().Element(CellStyle2).Text(row.Cells["T. JABA"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["T.PARIH"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["CANT JABAS"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO BRUTO"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO JABAS"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO NETO"].Value).FontSize(10);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PROMEDIO"].Value).FontSize(10);

                        //   i++;

                        QuestPDF.Infrastructure.IContainer CellStyle2(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyle2(containers, Colors.Blue.Medium);

                    }
                });
                //col.Item().Text(string.Empty);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();

                    });
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);

                    table.Cell().Text("Items");
                    table.Cell().Text($"{datalistado.RowCount}").FontSize(12).FontColor(Colors.Black).Bold();
                    //   $"{TableOfContents.Contents.Count}"
                    ;
                    table.Cell().Text("Cant Jabas");
                    table.Cell().Text(lblcantjabas.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("Total Neto");
                    table.Cell().Text(totalneto.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    ;
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                });
                col.Item().AlignCenter().Text(String.Empty);
                col.Item().AlignCenter().Text(String.Empty);
                col.Item().AlignCenter().Text(String.Empty);
                col.Item().AlignCenter().Text(String.Empty);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();

                    });
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);

                    table.Cell().Text("V.B");

                    //    col.Item().AlignCenter().Text("V.B");

                });
            });
        }

        private void CrearFooter(IContainer container)
        {
            container.Background("#8fce00").Padding(5).Row(row =>
            {
                row.RelativeItem().Padding(0).Column(col =>
                {
                    col.Item()
                        .Hyperlink("https://agricoladelsurpisco.com/")
                        .Text("www.agricoladelsurpisco.com");
                });
                row.RelativeItem().AlignRight().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }
    }
}