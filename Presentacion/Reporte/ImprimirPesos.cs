using RawDataPrint;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using ZXing;
using System.IO;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class ImprimirPesos : Form
    {
        const string LogoPath = (@"Resources\logoagricola.png");
        public ImprimirPesos()
        {
            InitializeComponent();
            //  PrepGrid();
            ticket();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ticket()
        {
            var IngresoPesos = Owner as IngresoPesos;
        }

        private void ImprimirPesos_Load(object sender, EventArgs e)
        {
            cargadatos();
        }


        private void cargadatos()
        {
            try
            {
            // Instanciamos el Formulario PADRE
            FrmPrincipal frmPrincipal = new FrmPrincipal();

            var IngresoPesos = Owner as IngresoPesos;

            var iniciocadena = IngresoPesos.cbcliente.Text.IndexOf('-');

            lblcliente2.Text = IngresoPesos.cbcliente.Text.Substring(iniciocadena + 1);

            DateTime fechaRecepcion = IngresoPesos.DateTimePicker1.Value;

            lblfecharecepcion.Text = fechaRecepcion.ToString("dd-MM-yyyy");
            lblguiaremision.Text = IngresoPesos.txtGuiaRemision.Text;
            lblclp2.Text = IngresoPesos.lblCLP.Text;
            lblproductor2.Text = IngresoPesos.cbProductor.Text.ToString();
            lblvariedad.Text = IngresoPesos.cbvariedad.Text.ToString();
           // lbljabas.Text = IngresoPesos.cbjabas.Text.ToString();
            //  lblpesoneto.Text = IngresoPesos.lblpeso.Text;
            lblnumlote.Text = IngresoPesos.cboLote.Text;
            lblusuario.Text = frmPrincipal.LBLUSUARIO.Text;

            // Si hay filas
            if (IngresoPesos.datalistado.Rows.Count > 0)
            {
                if (IngresoPesos.doubleclick == true)
                {
                    lbljabas.Text = IngresoPesos.Varcantjabas;
                    lblpesoneto.Text = IngresoPesos.Varpesoneto;
                    IngresoPesos.doubleclick = false;
                }
                else
                {
                    // Seleccionar el primer elemento de la lista
                        IngresoPesos.datalistado.Rows[0].Selected = true;
                    // Leer el valor de una celda específica
                //for (int i = 0; i < IngresoPesos.datalistado.ColumnCount; i++)
                //{
                    lblpesoneto.Text = IngresoPesos.datalistado.SelectedRows[0].Cells["PESO NETO"].Value.ToString();
                    lbljabas.Text = IngresoPesos.datalistado.SelectedRows[0].Cells["CANT JABAS"].Value.ToString();
                //}
                }
            }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }

        private void impresora_termico()
        {
            try
            {            
                Regex regex = new Regex(" ");
                using (PrintDialog pd = new PrintDialog())
                {
                    StringBuilder cadena = new StringBuilder();

                        cadena.AppendLine("^XA");

                    // ^FX Logo Agricola del Sur Pisco EIRL.
                    // ^FX Desing by Juan Luis Diaz Aylas.
                        cadena.AppendLine(
                       "^FO20,10^GFA,1521,1521,13,,K08,J01C,J07C,J0FE,J0FEM07FF,I01FFL0KFC,I03FFK07LF8,I07FF8I03NF,I07FF8I0OFE,I07FF8001PF," +
                       "I0IF8007PF,I0IFC01QF,I0IFC03PFE,001IFC07PFE,001IFC0QFC,001IFC1QF8,001FEF83IF8MF8,001FEF87FF07MF,001FEF8FF83MFE," +
                       "301FEF1FC1NFC,7C1FCF1E07NF8,7E1FDE381OF,7F0FDE607NFE,7F8F9C01OFC,7F8F9C03OF8,7FCFB88PF004,7FC7311OFC002,7FC7067OFI018," +
                       "7EE20COFCJ04,3F60187NFK06,3F60700MFCK03,1F60EI07JFCL018,0FA1CJ01FFO0C,07A38V06,0787W03,0187W01,008EW018,001CX0C,003CX06," +
                       "0038X06,007Y03,00FY018,00EO078M0398,01EN03FF8L0FCC,01CN0IFEK03FCC,03CM01JFK0FFC6,03CM07JF8I01FE06,078M0KFCI03E007," +
                       "078M0KFEI0F80F3,0782K01LF001C0FF3,0F00CJ03LF00707FF38,0F007J03LF80C3IF98,0F023CI03LF801JF98,0F199FI03LF80KF9C,1F1CC7C007KFE07FFC001C," +
                       "1E1EE3E607KF83FL0C,1E1F71F9C3JFC04001IF8C,1E3F3CFE703FFC001LFCE,1E3F9E7FBCJ01NFCE,1E3FDF3FDF2J03MFCE,3E3FEF9FE7CE0FF00LFCE," +
                       "3E3FEFCFFBF7E1IFC3JFC6,3E3FF7E7FDFDFC3JF0IFC6,3E3FF3F3FE7F7F8KF83FC7,3E3FFBFBFF3F9FE1KF80C7,3E3FF9F9FF9FEFFC3KF807,3E3FFDFCFFCFF3FF8LF07," +
                       "3E3FFDFEFFE7FDFFE3KFC6,3E1FFCFE7FF3FE7FF8KF86,3E1FFEFF3FFBFF3FFE1JF86,1F1FFEFFBFFDFFCIF87IF8E,1F1FFE7F9FFEFFE7FFC1IF8E," +
                       "1F0FFE7FDIF7FF3IF07FF8E,1F0IF7FCIF3FF8IFC3FF0E,1F0IF7FEIFBFFC7IF0FF0E,1F8IF3FEIFDFFE3IFC3F0E,0F87FF3FE7FFCIF1IFE1E1E," +
                       "0F87FF3FF7FFEIF8JF861C,0FC3FF3FF3IF7FFC7IFC01C,07C3FF3FF3IF7FFE3JF01C,07E3FF3FFBIF3FFE1JF83C,07E1FF3FF9IFBIF0JF838,03F0FF3FF9IF9IF83IF038," +
                       "03F0FF3FF9IFDIFC3IF078,01F87F3FFDIFCIFC1FFE07,01F87F3FFDIFCIFE0FFE0F,00FC3F3FFCIFE7IF07FC0E,00FE1F3FFCIFE7IF83F81E,007E0E3FFCIFE3IF81F01C," +
                       "003F063FFCIFE3IFC0E03C,003F823FFCIFE3IFC04038,001FC07FFCJF1IFEI078,I0FE07FFCJF1JFI0F,I0FF07FFCJF1JF020E,I07F83FFCJF1JF841E,I03FC0FFCJF0JF8C3C," +
                       "I01FE07FCJF0IFE1878,J0FF81FCJF0IFC70F8,J07FC07CJF0IF0C1F,J01FF01CJF07FC383E,K0FFC00JF07E0F07C,K07FF00JF0703E0F8,J041FFC007FFI0F81F," +
                       "J020IF8L07F07E,J0183IFK03FC1F8,K060JF8007FF03F,K0303NFC0FC,L0C07LFE03F8,L07007KF01FE,L01E007IF007F8,M07CL03FE,N0FCJ07FF,N03FF0JFC," +
                       "O07KFC,P03IF8,,^FS");

                    //    ^FX Top section with logo, name and address.
                        cadena.AppendLine("^CF0,120");
                        cadena.AppendLine("^FO220,20^FDRECEPCION^FS");

                    //   ^FX Titulo con Informacion requerida.
                        cadena.AppendLine("^CF0,70");
                        cadena.AppendLine("^FO20,240 ^FDCLP :^FS");

                        cadena.AppendLine("^FO20,310 ^FDGUIA REMISION :^FS");
                        cadena.AppendLine("^FO20,380 ^FDFECHA RECEPCION :^FS");
                        cadena.AppendLine("^FO20,450 ^FDPRODUCTOR :^FS");
                        cadena.AppendLine("^FO20,590 ^FDVARIEDAD :^FS");
                        cadena.AppendLine("^FO20,660 ^FDNo JABAS: ^FS");
                        cadena.AppendLine("^FO20,740 ^FDPESO NETO: ^FS");
                        
                        cadena.AppendLine("^FO870,1 ^BY4,2.0,65 ^BQN,2,10 ^FDJLDJuan Luis Diaz Aylas^FS");

                    //    ^FX Informacion que se necesita.
                        cadena.AppendLine("^CF0,70");
                        cadena.AppendLine("^FO220,240 ^FD" + lblclp2.Text + " ^FS");
                        cadena.AppendLine("^FO520,310 ^FD" + lblguiaremision.Text + " ^FS");
                        cadena.AppendLine("^FO620,380 ^FD" + lblfecharecepcion.Text + " ^FS");

                        cadena.AppendLine("^FO430,450 ^FD" + (lblproductor2.Text) + " ^FS"); // 16 espacios

                        cadena.AppendLine("^FO420,590 ^FD" + lblvariedad.Text + " ^FS");
                        cadena.AppendLine("^FO420,660 ^FD" + lbljabas.Text + " ^FS");
                        cadena.AppendLine("^FO420,740 ^FD" + lblpesoneto.Text + " ^FS");

                    //    ^ FX Contorno
                        cadena.AppendLine("^FO5,5^GB1165,820,3^FS");

                        cadena.AppendLine("^XZ");


                        RawPrinterHelper.EnviarCadenaToImpresora(Properties.Settings.Default.Impresora_valor.ToString(), cadena.ToString());
                        cadena.Clear();
                    //}
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show($@"Error: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarPDF2()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A6);
                    pagina.Size(PageSizes.A6.Landscape());
                    pagina.Margin(5, QuestPDF.Infrastructure.Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(14));

                    pagina.Header().Element(CrearCabecera);
              //      pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf(lblnumlote.Text +".pdf");
            Process.Start(lblnumlote.Text + ".pdf");
        }

        void CrearCabecera(IContainer container)
        {
            const string LogoPath = (@"Resources\logoagricola.png");

            container.Column(col =>
            {
                //   col.Item().Image(LogoPath);

                col.Item().Row(row =>
                {
                    row.RelativeItem().AlignLeft()
                        .Row(rowitem =>
                        {
                            if (File.Exists(LogoPath))
                            {
                                rowitem.AutoItem().Width(120).Height(50).Image(LogoPath);
                            }
                            rowitem.AutoItem().AlignLeft().Text("RECEPCION").SemiBold().FontSize(28)
                                .FontColor(Colors.Blue.Medium);
                            rowitem.AutoItem().AlignRight().Text("  LT N° " + lblnumlote.Text).SemiBold().FontSize(18)
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

                    //table.Cell().Text("PALLET N° :").FontSize(14).FontColor(Colors.Black).Bold();
                    //table.Cell().Text("000").FontSize(16).FontColor(Colors.Black).Bold();

                    table.Cell().Text("EXPORTADOR :").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblcliente2.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("CLP :").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblclp2.Text).FontSize(16).FontColor(Colors.Black).Bold();

                    table.Cell().Text("GUIA DE REMISION:").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblguiaremision.Text).FontSize(14).FontColor(Colors.Black).Bold();

                    table.Cell().Text("FECHA DE RECEPCION:").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblfecharecepcion.Text).FontSize(14).FontColor(Colors.Black).Bold();

                    int cortecadena = lblproductor2.Text.IndexOf("||");
                 
                    if (cortecadena != -1)
                    {
                        string parteCortada = lblproductor2.Text.Substring(0, cortecadena).Trim(); // Agregamos 3 para omitir el delimitador y los espacios que lo siguen
                   
                    table.Cell().Text("PRODUCTOR :").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(parteCortada).FontSize(12).FontColor(Colors.Black).Bold();
                    }
                    table.Cell().Text("VARIEDAD :").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblvariedad.Text).FontSize(16).FontColor(Colors.Black).Bold();

                    table.Cell().Text("N° DE JABAS :").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lbljabas.Text).FontSize(16).FontColor(Colors.Black).Bold();                   

                    table.Cell().Text("PESO NETO:").FontSize(14).FontColor(Colors.Black).Bold();
                    table.Cell().Text(lblpesoneto.Text).FontSize(16).FontColor(Colors.Black).Bold();
                   
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

                    //foreach (DataGridViewRow row in datalistado.Rows)
                    //{

                    //    table.Cell().Element(CellStyle2).Text(row.Cells["T. JABA"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["T.PARIH"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["CANT JABAS"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["PESO BRUTO"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["PESO JABAS"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["PESO NETO"].Value).FontSize(10);
                    //    table.Cell().Element(CellStyle2).Text(row.Cells["PROMEDIO"].Value).FontSize(10);

                    //    //   i++;

                    //    QuestPDF.Infrastructure.IContainer CellStyle2(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyle2(containers, Colors.Blue.Medium);

                    //}
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
                //    table.Cell().Text($"{datalistado.RowCount}").FontSize(12).FontColor(Colors.Black).Bold();
                    //   $"{TableOfContents.Contents.Count}"
                    //;
                    //table.Cell().Text("Cant Jabas");
                    //table.Cell().Text(lblcantjabas.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    //table.Cell().Text("Total Neto");
                    //table.Cell().Text(totalneto.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    //;
                    //table.Cell().Text(String.Empty);
                    //table.Cell().Text(String.Empty);
                });
                //col.Item().AlignCenter().Text(String.Empty);
                //col.Item().AlignCenter().Text(String.Empty);
                //col.Item().AlignCenter().Text(String.Empty);
                //col.Item().AlignCenter().Text(String.Empty);

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


        private void ImprimirPesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private void CrearFooter(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().AlignRight()
                        .Row(rowitem =>
                        {
                            rowitem.AutoItem().AlignRight().Text("USER : " + Login.nombre1 + " " + Login.apaterno1).SemiBold().FontSize(10)
                                .FontColor(Colors.Red.Medium);

                        });
                });

            });
        }
    }
}