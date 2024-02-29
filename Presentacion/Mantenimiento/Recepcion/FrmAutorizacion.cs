using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class FrmAutorizacion : Form
    {
        public FrmAutorizacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }

        private void GenerarPDF2()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A5);
                    pagina.Size(PageSizes.A5.Landscape());
                    pagina.Margin(2, QuestPDF.Infrastructure.Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(14));

                    pagina.Header().Element(CrearCabecera);
                    pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf("Theathoq.pdf");
            Process.Start("Theathoq.pdf");
        }

        void CrearCabecera(QuestPDF.Infrastructure.IContainer container)
        {

            //     string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //     string LogoPath = Path.Combine(UserPath, "logoagricola.png");
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
                                        row2.AutoItem().Text(lbltitulo.Text).SemiBold().FontSize(14)
                                            .FontColor(Colors.Orange.Medium);
                                    });

                                });
                            });



                        row.RelativeItem().AlignRight().Width(110).Height(45)

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
                        table.Cell().AlignRight().Text("N° "+"      " + lblcorrelativo.Text + "   " ).SemiBold().FontSize(16)
                            .FontColor(Colors.Red.Medium);
                    });
                });


                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                       
                    });
                    table.Cell().Text("   Nombre :");
                    table.Cell().Text(txtnombre.Text).FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("   Fecha Salida :");
                    table.Cell().Text(dtpfecha.Value).FontSize(10).FontColor(Colors.Black).Bold();                  
                   
                });
            });
        }

        void CrearContenido(QuestPDF.Infrastructure.IContainer container)
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
                       

                    });

                    table.Header(header =>
                    {
                        //foreach (DataGridViewRow row in datalistado.Rows)
                        //{
                        header.Cell().Element(CellStyle).Text("T. JABA").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("MOTIVO DE SALIDA").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        

                        QuestPDF.Infrastructure.IContainer
                            CellStyle(QuestPDF.Infrastructure.IContainer containers) =>
                            DefaultCellStyle(containers, Colors.Blue.Medium);
                        //}

                    });

                    foreach (DataGridViewRow row in datalistado.Rows)
                    {
                        table.Cell().Element(CellStyle2).Text(row.Cells["T. JABA"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["T.PARIH"].Value).FontSize(9);
                      


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

        private void CrearFooter(QuestPDF.Infrastructure.IContainer container)
        {
            container.Background("#8fce00").Padding(3).Row(row =>
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

    }
}
