﻿using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Color = System.Drawing.Color;


namespace _3mpacador4.Presentacion.Reporte
{
   

    public partial class RptBoletaPesadoDetalle : Form 

    {
        private string nombreArchivo = "C:/archivo.xlsx";
        public string VarBolPesoDetalle { get; set; } = "";
        private string[] _camptxtcadenas;
        public DataTable datosdescarte;

        public RptBoletaPesadoDetalle(string[] filaConDatos, DataTable data, DataTable datadescarte)
        {
            InitializeComponent();
            PrepGrid();
            
            if (filaConDatos.Length >= 5)
            {
                lblnumlote.Text = filaConDatos[0];
                lblguiaingreso.Text = filaConDatos[1];
                //   lblnumdoc.Text = filaConDatos[2];
                lblfechaingreso.Text = filaConDatos[3];
                lblhoraingreso.Text = filaConDatos[4];
                lblproducto.Text = filaConDatos[4];
                lblvariedad.Text = filaConDatos[5];
                lblmetodo.Text = filaConDatos[6];
                lblservicio.Text = filaConDatos[7];
                lblcliente.Text = filaConDatos[8];
                lblproductor.Text = filaConDatos[9];
                lblclp.Text = filaConDatos[10];

                lblcantjabas.Text = filaConDatos[11];
                totalneto.Text = Convert.ToDecimal(filaConDatos[12]).ToString("N2");
                datalistado.DataSource = data;
                datosdescarte = datadescarte;
                LBLCONTAR.Text = datalistado.RowCount.ToString();
                ocultar_columnas2();
                tamanio();
            }
        }

        public RptBoletaPesadoDetalle()
        {
         //   VariablePesoDetalle = lblnumlote.Text;
        }

        public void RptBoletaPesado_Load(object sender, EventArgs e)
        {
          //
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

        private void RptBoletaPesadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void ocultar_columnas2()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = true;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[8].Visible = false;
        }

        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;

                withBlock.Columns["H PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["H PESAJE"].Width = 90;

                withBlock.Columns["T. JABA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T. JABA"].Width = 40;

                withBlock.Columns["T.PARIH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T.PARIH"].Width = 80;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["CANT JABAS"].Width = 60;

                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 90;

                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO JABAS"].Width = 60;


                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 80;

                withBlock.Columns["PROM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PROM"].Width = 90;
            }
            catch (Exception)
            {
                //  throw;
            }
        }
        private void GenerarPDF2()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Size(PageSizes.A4.Portrait());
                    pagina.Margin(2, QuestPDF.Infrastructure.Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(14));

                    pagina.Header().Element(CrearCabecera);
                    pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf("RptBoletaPesadoDetalle_TheAthoq.pdf");
            Process.Start("RptBoletaPesadoDetalle_TheAthoq.pdf");
        }
        void CrearCabecera(IContainer container)
        {      
        const string LogoPath = (@"Resources\logoagricola.png");

            container.Column(col =>
            {

                col.Item().Row(
                    row =>
                    {
                        row.RelativeItem().AlignLeft()

                            .Row(rowitem =>
                            {

                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Padding(0).Column(column =>
                                {
                                    column.Item().Container().Height(2);

                                    if (File.Exists(LogoPath))
                                    {
                                        rowitem.AutoItem().Width(160).Height(80).Image(LogoPath);
                                    }
                                    
                                });
                            });

                        row.RelativeItem().AlignCenter()

                            .Row(rowitem =>
                            {
                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Padding(2).Column(column =>
                                {
                                    column.Item().Container().Height(3);
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(8);
                                        row2.AutoItem().Text($"RECEPCION DE MATERIA PRIMA").SemiBold().FontSize(12)
                                            .FontColor(Colors.Orange.Medium);
                                    });
                                   
                                });
                            });
                       


                        row.RelativeItem().AlignRight().Width(150).Height(45)

                            .Row(rowitem =>
                            {
                                //   rowitem.AutoItem().Width(65).Height(65).Image(QRCodeGenerator.GenerateQRCodeBytes("https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---Csharp----Huong-dan-tao-ung-dung-dock-windows-giong-Taskbar/2f0a9a79ff1bafd4.html", 170, 170));
                             //   rowitem.AutoItem().Width(65).Height(65).Image(GenerarCodigoQr.ReadImageFileToBytes(LogoPath));
                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Border(0.5f).Padding(1).Column(column =>
                                {
                                    column.Item().Container().Height(2);
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().Text($"CODIGO : AGS-PRO-R-01").FontSize(9).Italic();

                                    });
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().Text($"FECHA: 27/10/2023").FontSize(9).Italic();

                                    });
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().AlignCenter().Text($"VERSION : 02").FontSize(9).Italic();

                                    });


                                });
                            });
                    });


                col.Item().Row(row =>
                {
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            //columns.RelativeColumn();
                            //columns.RelativeColumn();
                        });
                        //table.Cell().AlignCenter().Text(String.Empty).SemiBold().FontSize(18)
                        //    .FontColor(Colors.Black);
                        table.Cell().AlignCenter().Text("LOTE N° " + lblnumlote.Text).SemiBold().FontSize(18)
                            .FontColor(Colors.Black);
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
                    table.Cell().Text(lblcliente.Text).FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Guia de Remision :");
                    table.Cell().Text(lblguiaingreso.Text).FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Productor :");
                    table.Cell().Text(lblproductor.Text).FontSize(9).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   RUC / DNI :");
                    table.Cell().Text(lblruc_dni.Text).FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Metodo :");
                    table.Cell().Text(lblmetodo.Text).FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   CLP :");
                    table.Cell().Text(lblclp.Text);

                    table.Cell().Text("        Producto :");
                    table.Cell().Text(lblproducto.Text).FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Variedad :");
                    table.Cell().Text(lblvariedad.Text).FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Tipo de Servicio :");
                    table.Cell().Text(lblservicio.Text).FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Fecha Ingreso :");
                    table.Cell().Text(lblfechaingreso.Text).FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Acopiador :");
                    table.Cell().Text(lblacopiador.Text).FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Hora Ingreso");
                    table.Cell().Text(lblhoraingreso.Text).FontSize(10).FontColor(Colors.Black).Bold();
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
                        columns.RelativeColumn(1);

                    });

                    table.Header(header =>
                    {
                        //foreach (DataGridViewRow row in datalistado.Rows)
                        //{
                        header.Cell().Element(CellStyle).Text("H PESAJE").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("T. JABA").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("T. PARIH").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("CANT JABAS").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO BRUTO").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO JABAS").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO NETO").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PROM").FontSize(10).FontColor(Colors.White).Bold();

                        QuestPDF.Infrastructure.IContainer
                            CellStyle(QuestPDF.Infrastructure.IContainer containers) =>
                            DefaultCellStyle(containers, Colors.Blue.Medium);
                        //}

                    });

                    foreach (DataGridViewRow row in datalistado.Rows)
                    {
                        table.Cell().Element(CellStyle2).Text(row.Cells["H PESAJE"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["T. JABA"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["T.PARIH"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["CANT JABAS"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO BRUTO"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO JABAS"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO NETO"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PROM"].Value).FontSize(9);


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

                //row.RelativeItem().AlignRight()
                //        .Row(rowitem =>
                //        {
                //            rowitem.AutoItem().AlignRight().Text("USER : " + Login.nombre1 + " " + Login.apaterno1).SemiBold().FontSize(10)
                //                .FontColor(Colors.Red.Medium);

                //        });
             //   row.RelativeItem().AlignLeft().Text("Copyright © 2024 - Todos los derechos reservados");                
            });
           
        }


        private void BtnExportar_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }
        private void btnAdjuntos_Click(object sender, EventArgs e)
        {            
            VarBolPesoDetalle = lblnumlote.Text;

            FrmDocAdjuntos frmDocAdjuntos = new FrmDocAdjuntos();

            AddOwnedForm(frmDocAdjuntos);
            frmDocAdjuntos.ShowDialog();
        }

        private void btnDescarte_Click(object sender, EventArgs e)

        {
            try
            {
                _camptxtcadenas = new string[9];
                _camptxtcadenas[0] = lblcliente.Text;
                _camptxtcadenas[1] = lblproductor.Text;
                _camptxtcadenas[2] = lblclp.Text;
                _camptxtcadenas[3] = LBLCONTAR.Text;
                _camptxtcadenas[4] = lblcantjabas.Text;
                _camptxtcadenas[5] = totalneto.Text;
                _camptxtcadenas[6] = lblnumlote.Text;
                _camptxtcadenas[7] = lblvariedad.Text;
                _camptxtcadenas[8] = lblguiaingreso.Text;

                var datosdescartados = datosdescarte;



                RptBolPesDetalDesc descarte = new RptBolPesDetalDesc(_camptxtcadenas, datosdescarte);

                AddOwnedForm(descarte);
                descarte.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}