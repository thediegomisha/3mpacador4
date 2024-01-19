﻿using RawDataPrint;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class ImprimirPesos : Form
    {
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
            // Instanciamos el Formulario PADRE

            var IngresoPesos = Owner as IngresoPesos;

            //  lblproductor2.Text = (IngresoPesos.cbProductor.Text);
            //IngresoPesos.cbcliente.Text = 
            //IngresoPesos.cbProductor.Text = 
            //IngresoPesos.lblCLP.Text = 


            // mostrarconsulta2();
        }

        private void ImprimirPesos_Load(object sender, EventArgs e)
        {
            cargadatos();
        }


        private void cargadatos()
        {
            // Instanciamos el Formulario PADRE

            var IngresoPesos = Owner as IngresoPesos;

            var iniciocadena = IngresoPesos.cbcliente.Text.IndexOf('-');

            lblcliente2.Text = IngresoPesos.cbcliente.Text.Substring(iniciocadena + 1);

            DateTime fechaRecepcion = IngresoPesos.DateTimePicker1.Value;

            lblfecharecepcion.Text = fechaRecepcion.ToString("dd-MM-yyyy");
            lblguiaremision.Text = IngresoPesos.txtGuiaRemision.Text;
            lblclp2.Text = IngresoPesos.lblCLP.Text;
            lblproductor2.Text = IngresoPesos.cbProductor.Text.ToString();
            lblvariedad.Text = IngresoPesos.cbvariedad.Text.ToString();
            lbljabas .Text = IngresoPesos .cbjabas .Text.ToString();
            lblpesoneto.Text = IngresoPesos.lblpeso.Text;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            impresora_termico();
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
                        
                        cadena.AppendLine("^FO870,1 ^BY4,2.0,65 ^BQN,2,10 ^FDJLDJuan Luis Diaz Aylands^FS");

                    //    ^FX Informacion que se necesita.
                        cadena.AppendLine("^CF0,40");
                        cadena.AppendLine("^FO420,380 ^FD" + lblfecharecepcion.Text + " ^FS");
                        cadena.AppendLine("^FO420,310 ^FD" + lblguiaremision.Text + " ^FS");
                        cadena.AppendLine("^FO420,240 ^FD" + lblclp2.Text + " ^FS");

                    //    int contartexto = lblproductor2.ToString().Length;

                     //   int longitudLimite = 16;


                    //if (lblproductor2.Text .Length > longitudLimite)
                    //    {
                    //     int indiceEspacio = lblproductor2.Text.IndexOf(' ', longitudLimite);

                    //     if (indiceEspacio != -1)
                    //     {
                    //         lblproductor2.Text = lblproductor2.Text.Substring(0, indiceEspacio);
                    //     }
                    //    }

                        cadena.AppendLine("^FO420,450 ^FD" + (lblproductor2.Text) + " ^FS"); // 16 espacios

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
    }
}