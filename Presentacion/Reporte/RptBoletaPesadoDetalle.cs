using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Devart.Common;
using Microsoft.VisualBasic;
//using Microsoft.Office.Interop.Excel;
//using objExcel  = Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
//using Microsoft.Office.Interop.Excel;
using Label = System.Windows.Forms.Label;
using IFont = NPOI.SS.UserModel.IFont;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;
using NPOI.SS.Util;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptBoletaPesadoDetalle : Form

    {
      //  String nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string nombreArchivo = "C:/archivo.xlsx";

       // Label[] labels = new Label[] { lblciente, label2, label3, label4, label5, label6 };


        public RptBoletaPesadoDetalle()
        {
            InitializeComponent();
            PrepGrid();
        }

        private void RptBoletaPesado_Load(object sender, EventArgs e)
        {

        }

        private void mostrarconsulta()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticketpesaje_RptBoletaPesado", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = txtnumlote.Text;
           
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new System.Data.DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos.Rows.Count != 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        tamanio();
                        ocultar_columnas();
                        actualizardatos();
                        sumaneto();
                        contar();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizardatos()
        {
            try
            {
                lblcliente.Text = this.datalistado.Rows[0].Cells[6].Value .ToString();
                lblproductor.Text = this.datalistado.Rows[0].Cells[7].Value.ToString();
                lblclp.Text  = this.datalistado.Rows[0].Cells[8].Value.ToString();
                lblproducto.Text = this.datalistado.Rows[0].Cells[4].Value.ToString();
                lblvariedad.Text = this.datalistado.Rows[0].Cells[5].Value.ToString();
                lblfechaingreso.Text = this.datalistado.Rows[0].Cells[1].Value.ToString();
                lblhoraingreso.Text = this.datalistado.Rows[0].Cells[2].Value.ToString();
                lblguiaingreso.Text = this.datalistado.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            mostrarconsulta();

        }

        private void PrepGrid()
        {
            {
                var withBlock = this.datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new System.Drawing.Font("Tahoma", 11.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

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

                withBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;

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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                withBlock.Columns["T. JABA"].Width = 90;

                withBlock.Columns["T.PARIH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T.PARIH"].Width = 130;

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
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[1].Visible = false;
            this.datalistado.Columns[2].Visible = false;
            this.datalistado.Columns[3].Visible = false;
            this.datalistado.Columns[4].Visible = false;
            this.datalistado.Columns[5].Visible = false;
            this.datalistado.Columns[6].Visible = false;
            this.datalistado.Columns[7].Visible = false;
            this.datalistado.Columns[8].Visible = false;
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            int contarfila = datalistado.RowCount - 1;
            int contador = 0;
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

                foreach(DataGridViewRow row in datalistado.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                    
                   
                }
                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);


            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Microsoft.VisualBasic.Constants.vbCritical);
            }
        }

        private void txtnumlote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtnumlote.Text))
                {
                    BtnBuscar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Ingrese el Peso Correcto");
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarExcel( nombreArchivo);
        }

        private void ExportarExcel(string nombreArchivo)
        {

            // Crear un nuevo libro de Excel
            IWorkbook libro = new XSSFWorkbook();

            // Crear una hoja de trabajo en el libro
            ISheet hoja = libro.CreateSheet("Datos");

            // Crear una fila para el encabezado principal
            IRow encabezadoPrincipalRow = hoja.CreateRow(0);

            // Establecer el estilo de celda para el encabezado principal
            ICellStyle estiloEncabezadoPrincipal = libro.CreateCellStyle();
            estiloEncabezadoPrincipal.FillForegroundColor = IndexedColors.LightYellow.Index;
            estiloEncabezadoPrincipal.FillPattern = FillPattern.SolidForeground;
            estiloEncabezadoPrincipal.Alignment = HorizontalAlignment.Center;
            estiloEncabezadoPrincipal.BorderTop = BorderStyle.Thin;
            estiloEncabezadoPrincipal.BorderBottom = BorderStyle.Thin;
            estiloEncabezadoPrincipal.BorderLeft = BorderStyle.Thin;
            estiloEncabezadoPrincipal.BorderRight = BorderStyle.Thin;

            // Crear celda y unir celdas para el encabezado principal
            ICell celdaTitulo = encabezadoPrincipalRow.CreateCell(3);
            celdaTitulo.SetCellValue("Datos del Formulario");
            celdaTitulo.CellStyle = estiloEncabezadoPrincipal;
            hoja.AddMergedRegion(new CellRangeAddress(0, 0, 3, 6));

            // Obtener los Label del formulario actual
            Label[] labelsFormulario = { lblcliente, lblproductor, lblproducto, lblvariedad }; // Reemplaza con tus Labels correspondientes

            // Crear una fila para los datos adicionales
            IRow datosAdicionalesRow = hoja.CreateRow(2);

            // Establecer el estilo de celda para los datos adicionales
            ICellStyle estiloDatosAdicionales = libro.CreateCellStyle();
            estiloDatosAdicionales.Alignment = HorizontalAlignment.Left;
            estiloDatosAdicionales.BorderTop = BorderStyle.Thin;
            estiloDatosAdicionales.BorderBottom = BorderStyle.Thin;
            estiloDatosAdicionales.BorderLeft = BorderStyle.Thin;
            estiloDatosAdicionales.BorderRight = BorderStyle.Thin;

            // Crear celdas y establecer los valores de los Labels como datos adicionales
            for (int i = 0; i < labelsFormulario.Length; i++)
            {
                ICell celdaLabel = datosAdicionalesRow.CreateCell(i + 1); // Iniciar desde la segunda columna
                celdaLabel.SetCellValue(labelsFormulario[i].Text);
                celdaLabel.CellStyle = estiloDatosAdicionales;
            }

            // Ajustar el ancho de las columnas automáticamente
            hoja.AutoSizeColumn(3);


            // Guardar el libro en un archivo
            using (FileStream archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write))
            {
                libro.Write(archivo);
            }

            // Abrir el archivo de Excel
            System.Diagnostics.Process.Start(nombreArchivo);

        }


        //private void BTNEXPORTAR_Click(object sender, EventArgs e)
        //{
        //    WINPESFARD.My.MyProject.Forms.F_MovBalanza_Pesfard.RELLENARGRILLAMOVBAL();
        //    WINPESFARD.My.MyProject.Forms.F_Romaneo_liquidacion_Pesfard.resultadoromaneo();
        //    try
        //    {

        //        // Me.Cursor = Cursors.WaitCursor

        //        // Creamos un objeto Excel.
        //        Microsoft.Office.Interop.Excel.Application Mi_Excel;
        //        // Creamos un objeto WorkBook. Para crear el documento Excel.
        //        Microsoft.Office.Interop.Excel.Workbook LibroExcel;
        //        // Creamos un objeto WorkSheet. Para crear la hoja del documento.
        //        Microsoft.Office.Interop.Excel.Worksheet HojaExcel = null;
        //        // Iniciamos una instancia a Excel, y Hacemos visibles para ver como se va creando el reporte,
        //        // podemos hacerlo visible al final si se desea.
        //        Mi_Excel = new Microsoft.Office.Interop.Excel.Application();


        //        // /* Ahora creamos un nuevo documento y seleccionamos la primera hoja del
        //        // * documento en la cual crearemos nuestro informe.
        //        // */

        //        // AÑADIR MAS HOJAS AL LIBRO EXCEL
        //        Mi_Excel.SheetsInNewWorkbook = 3;


        //        // Form_MovBalanz.grillamovbalanza.DataSource = dstables(0)

        //        // Creamos una instancia del Workbooks de excel.
        //        LibroExcel = Mi_Excel.Workbooks.Add();

        //        // Creamos una instancia de la primera hoja de trabajo de excel
        //        HojaExcel = (Microsoft.Office.Interop.Excel.Worksheet)LibroExcel.Worksheets[1];

        //        // Cambiamos el nombre de las hojas trabajo de excel
        //        LibroExcel.Worksheets["Hoja1"].Name = "LIQUIDACION";
        //        LibroExcel.Worksheets["Hoja2"].Name = "MOVIMIENTO";
        //        LibroExcel.Worksheets["Hoja3"].Name = "ROMANEO";



        //        // HojaExcel.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        //        // HojaExcel.Cells.Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        //        // HojaExcel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        //        HojaExcel.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible;



        //        // Hacemos esta hoja sea visible en pantalla
        //        // (como seleccionamos la primera esto no es necesario
        //        // si seleccionamos una diferente a la primera si lo
        //        // necesitariamos).

        //        HojaExcel.Activate();

        //        // Crear el encabezado de nuestro informe.
        //        // La primera línea une las celdas y las convierte en una sola.
        //        HojaExcel.get_Range("B1:G1").Merge();

        //        // La segunda línea Asigna el nombre del encabezado.
        //        // HojaExcel.Range("A1:E1").Value = "----------------------------------------------"
        //        // La tercera línea asigna negrita al titulo.
        //        HojaExcel.get_Range("B1:G1").Font.Bold = true;
        //        // La cuarta línea asigna un Size a titulo de 15.
        //        HojaExcel.get_Range("B1:G1").Font.Size = 15;

        //        // Crear el subencabezado de nuestro informe
        //        HojaExcel.get_Range("B2:G2").Merge();
        //        HojaExcel.get_Range("B2:G2").set_Value(value: "DESMOTADORA ALTO AMAZONAS");
        //        HojaExcel.get_Range("B2:G2").Font.Bold = true;
        //        HojaExcel.get_Range("B2:G2").Font.Size = 24;

        //        HojaExcel.get_Range("B3:G3").Merge();
        //        HojaExcel.get_Range("B3:G3").set_Value(value: "DE: JAIME VERA MEDINA");
        //        HojaExcel.get_Range("B3:G3").Font.Italic = true;
        //        HojaExcel.get_Range("B3:G3").Font.Size = 12;

        //        HojaExcel.get_Range("B4:D4").Merge();
        //        HojaExcel.get_Range("B4:D4").set_Value(value: "R.U.C. :  1097538811");
        //        HojaExcel.get_Range("B4:G4").Font.Bold = true;
        //        HojaExcel.get_Range("B4:G4").Font.Size = 13;

        //        HojaExcel.get_Range("B5:G5").Merge();
        //        HojaExcel.get_Range("B5:G5").set_Value(value: "Via Los Libertadores Km. 6 San Clemente - PISCO");
        //        HojaExcel.get_Range("B5:G5").Font.Italic = true;
        //        HojaExcel.get_Range("B5:G5").Font.Size = 13;

        //        HojaExcel.get_Range("C6:F6").Merge();
        //        HojaExcel.get_Range("C6").set_Value(value: "LIQUIDACION DE SERVICIO Nº");
        //        HojaExcel.get_Range("G6").set_Value(value: "00" + this.TextBox1.Text);
        //        HojaExcel.get_Range("C6:G6").Font.Bold = true;
        //        HojaExcel.get_Range("C6:G6").Font.Size = 16;


        //        // //ENCABEZADO DATOS DEL CLIENTE
        //        // // B8:G8  B12:G12

        //        // // DIBUJA UN BORDE ALREDEDOR DE TODO ESE PARAMETRO
        //        HojaExcel.get_Range("B8:G8", "B12:G12").BorderAround();

        //        HojaExcel.get_Range("B8").set_Value(value: "FECHA :");
        //        HojaExcel.get_Range("D8").set_Value(value: (object)this.DateTimePicker1.Value.Date);
        //        HojaExcel.get_Range("B8").Font.Bold = true;
        //        HojaExcel.get_Range("B8:D8").Font.Size = 12;

        //        HojaExcel.get_Range("B9").set_Value(value: "CLIENTE :");
        //        HojaExcel.get_Range("D9").set_Value(value: this.COMBOCLIENTE.Text);
        //        HojaExcel.get_Range("B9:D9").Font.Bold = true;
        //        HojaExcel.get_Range("B9:D9").Font.Size = 12;

        //        HojaExcel.get_Range("B10").set_Value(value: "VARIEDAD :");
        //        HojaExcel.get_Range("D10").set_Value(value: this.COMBOVARIEDAD.Text);
        //        HojaExcel.get_Range("B10:D10").Font.Bold = true;
        //        HojaExcel.get_Range("B10:D10").Font.Size = 12;

        //        HojaExcel.get_Range("B11").set_Value(value: "ESTADO :");
        //        HojaExcel.get_Range("D11").set_Value(value: this.COMBOESTADO.Text);
        //        HojaExcel.get_Range("B11:D11").Font.Bold = true;
        //        HojaExcel.get_Range("B11:D11").Font.Size = 12;

        //        HojaExcel.get_Range("F11").set_Value(value: "OP :");
        //        HojaExcel.get_Range("G11").set_Value(value: this.LBLOP.Text);
        //        HojaExcel.get_Range("F11:G11").Font.Bold = true;
        //        HojaExcel.get_Range("F11:G11").Font.Size = 12;

        //        HojaExcel.get_Range("B12").set_Value(value: "LOTE :");
        //        HojaExcel.get_Range("F12").set_Value(value: this.COMBOLOTE.Text);
        //        HojaExcel.get_Range("B12:F12").Font.Bold = true;
        //        HojaExcel.get_Range("B12:F12").Font.Size = 12;

        //        // //
        //        HojaExcel.get_Range("B14:F14", "B16:F16").BorderAround();

        //        HojaExcel.get_Range("B14").set_Value(value: "INGRESO ALGODON RAMA :");
        //        HojaExcel.get_Range("F14").set_Value(value: this.LBLING_RAMA_TOTAL.Text);
        //        HojaExcel.get_Range("E14").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("B14:F14").Font.Bold = true;
        //        HojaExcel.get_Range("B14").Font.Size = 12;

        //        HojaExcel.get_Range("B15").set_Value(value: "RAMA PROCESADA :");
        //        HojaExcel.get_Range("F15").set_Value(value: this.LBLINGRESORAMA.Text);
        //        HojaExcel.get_Range("E15").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("B15").Font.Bold = false;
        //        HojaExcel.get_Range("B15").Font.Size = 12;

        //        HojaExcel.get_Range("B16").set_Value(value: "RAMA SIN PROCESAR :");
        //        HojaExcel.get_Range("F16").set_Value(value: this.LBL_SIN_PROCESAR.Text);
        //        HojaExcel.get_Range("E16").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("B16").Font.Bold = false;
        //        HojaExcel.get_Range("B16").Font.Size = 12;


        //        // //
        //        HojaExcel.get_Range("B18:F18", "B21:F21").BorderAround();

        //        HojaExcel.get_Range("B18").set_Value(value: "TOTAL FARDOS:");
        //        HojaExcel.get_Range("E18").set_Value(value: "UNIDAD:");
        //        HojaExcel.get_Range("F18").set_Value(value: this.LBLTOTALFARDOS.Text);
        //        HojaExcel.get_Range("B18").Font.Bold = false;
        //        HojaExcel.get_Range("B18").Font.Size = 12;

        //        HojaExcel.get_Range("B19").set_Value(value: "PESO BRUTO:");
        //        HojaExcel.get_Range("E19").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("F19").set_Value(value: this.LBLPESOBRUTO.Text);
        //        HojaExcel.get_Range("B19").Font.Bold = false;
        //        HojaExcel.get_Range("B19").Font.Size = 12;

        //        HojaExcel.get_Range("B20").set_Value(value: "PESO TARA:");
        //        HojaExcel.get_Range("E20").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("F20").set_Value(value: this.LBLPESOTARA.Text);
        //        HojaExcel.get_Range("B20").Font.Bold = false;
        //        HojaExcel.get_Range("B20").Font.Size = 12;

        //        HojaExcel.get_Range("B21").set_Value(value: "PESO NETO ALGODON FIBRA:");
        //        HojaExcel.get_Range("E21").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("F21").set_Value(value: this.LBLNETOFIBRA.Text);
        //        HojaExcel.get_Range("B21").Font.Bold = false;

        //        // //
        //        HojaExcel.get_Range("B23:F23", "B25:F25").BorderAround();

        //        HojaExcel.get_Range("B23").set_Value(value: "ACUDE (Procesado) :");
        //        HojaExcel.get_Range("D23").set_Value(value: this.LBLACUDEPORCENTAJE.Text + this.Label16.Text);
        //        HojaExcel.get_Range("F23").set_Value(value: this.LBLACUDE.Text);
        //        HojaExcel.get_Range("B23:F23").Font.Bold = true;
        //        HojaExcel.get_Range("B23").Font.Size = 12;

        //        HojaExcel.get_Range("B25").set_Value(value: "PEPA:");
        //        HojaExcel.get_Range("D25").set_Value(value: "QQ :");
        //        HojaExcel.get_Range("D25").set_Value(value: this.TXTPEPA.Text + " " + this.Label16.Text);
        //        HojaExcel.get_Range("F25").set_Value(value: this.LBLPEPA.Text);
        //        HojaExcel.get_Range("B25:F25").Font.Bold = true;
        //        HojaExcel.get_Range("B25:F25").Font.Size = 12;

        //        // //
        //        HojaExcel.get_Range("B27:F27", "B32:F32").BorderAround();

        //        HojaExcel.get_Range("B27").set_Value(value: "COSTO SERVICIO QUINTAL POR FIBRA:");
        //        HojaExcel.get_Range("F27").set_Value(value: this.TXTCOSTOFIBRA.Text);
        //        HojaExcel.get_Range("B27").Font.Bold = false;
        //        HojaExcel.get_Range("B27").Font.Size = 12;

        //        HojaExcel.get_Range("B28").set_Value(value: "CANTIDAD:");
        //        HojaExcel.get_Range("F28").set_Value(value: this.LBLCANTIDAD.Text);
        //        HojaExcel.get_Range("B28").Font.Bold = false;
        //        HojaExcel.get_Range("B28").Font.Size = 12;

        //        HojaExcel.get_Range("B29").set_Value(value: "SUB-TOTAL:");
        //        HojaExcel.get_Range("F29").set_Value(value: this.LBLSUBTOTAL.Text);
        //        HojaExcel.get_Range("B29").Font.Bold = false;
        //        HojaExcel.get_Range("B29").Font.Size = 12;

        //        HojaExcel.get_Range("B30").set_Value(value: "I.G.V.:");
        //        HojaExcel.get_Range("F30").set_Value(value: this.lblIGV.Text);
        //        HojaExcel.get_Range("B30").Font.Bold = false;
        //        HojaExcel.get_Range("B30").Font.Size = 12;

        //        HojaExcel.get_Range("B31").set_Value(value: "TOTAL USD $:");
        //        HojaExcel.get_Range("F31").set_Value(value: this.LBLTOTAL.Text);
        //        HojaExcel.get_Range("B31").Font.Bold = false;
        //        HojaExcel.get_Range("B31").Font.Size = 12;

        //        HojaExcel.get_Range("B32").Merge();
        //        HojaExcel.get_Range("B32").set_Value(value: "T/C SUNAT VENTA:");
        //        HojaExcel.get_Range("D32").set_Value(value: this.TXTTIPOCAMBIO.Text);
        //        HojaExcel.get_Range("F32").set_Value(value: this.LBLTOTALGENERAL.Text);
        //        HojaExcel.get_Range("B32:F32").Font.Bold = true;
        //        HojaExcel.get_Range("F32").Font.Size = 12;

        //        // HOJA DE MOVIMIENTO DE BALANZA
        //        HojaExcel = (Microsoft.Office.Interop.Excel.Worksheet)LibroExcel.Worksheets[2];
        //        HojaExcel.get_Range("D2:E2").Merge();
        //        HojaExcel.get_Range("D2:E2").set_Value(value: "MOVIMIENTO DE BALANZA");
        //        HojaExcel.get_Range("D2:E2").Font.Bold = true;
        //        HojaExcel.get_Range("D2:E2").Font.Size = 18;



        //        // HojaExcel.Columns(9, 10).NumberFormat = "#,##0.00"

        //        // Dim chartRange As Excel.Range

        //        // chartRange = HojaExcel.Range("b1", "e1")
        //        // chartRange.Merge()
        //        // chartRange.FormulaR1C1 = "MARK LIST"
        //        // chartRange.HorizontalAlignment = 3
        //        // chartRange.VerticalAlignment = 3



        //        // //contamos las filas y columnas de la grilla
        //        int NCol = WINPESFARD.My.MyProject.Forms.F_MovBalanza_Pesfard.grillamovbalanza.ColumnCount;
        //        int NRow = WINPESFARD.My.MyProject.Forms.F_MovBalanza_Pesfard.grillamovbalanza.RowCount;

        //        for (int i = 1, loopTo = NCol; i <= loopTo; i++)
        //        {

        //            {
        //                ref var withBlock = ref HojaExcel;
        //                withBlock.get_Range(withBlock.Cells.get_Item(4, i), withBlock.Cells.get_Item(4, i)).BorderAround();
        //            }

        //            HojaExcel.Cells.set_Item((object)4, (object)i, WINPESFARD.My.MyProject.Forms.F_MovBalanza_Pesfard.grillamovbalanza.Columns[i - 1].Name.ToString());
        //        }
        //        for (int Fila = 0, loopTo1 = NRow - 1; Fila <= loopTo1; Fila++)
        //        {
        //            for (int Col = 0, loopTo2 = NCol - 1; Col <= loopTo2; Col++)
        //            {
        //                {
        //                    ref var withBlock1 = ref HojaExcel;
        //                    withBlock1.get_Range(withBlock1.Cells.get_Item(Fila + 5, Col + 1), withBlock1.Cells.get_Item(Fila + 5, Col + 1)).BorderAround();
        //                }
        //                HojaExcel.Cells.set_Item((object)(Fila + 5), (object)(Col + 1), WINPESFARD.My.MyProject.Forms.F_MovBalanza_Pesfard.grillamovbalanza[Col, Fila].Value);
        //            }
        //        }

        //        HojaExcel.Rows.get_Item(4).Font.Bold = (object)1;
        //        HojaExcel.Rows.get_Item(4).HorizontalAlignment = (object)3;
        //        HojaExcel.Columns.AutoFit();

        //        // HOJA DE ROMANEO
        //        HojaExcel = (Microsoft.Office.Interop.Excel.Worksheet)LibroExcel.Worksheets[3];

        //        HojaExcel.get_Range("B1:I1").Merge();
        //        HojaExcel.get_Range("B1:I1").set_Value(value: "DESMOTADORA ALTO AMAZONAS");
        //        HojaExcel.get_Range("B1:I1").Font.Bold = true;
        //        HojaExcel.get_Range("B1:I1").Font.Size = 24;

        //        HojaExcel.get_Range("B2:F2").Merge();
        //        HojaExcel.get_Range("B2:F2").set_Value(value: "DE: JAIME VERA MEDINA");
        //        HojaExcel.get_Range("B2:F2").Font.Italic = true;
        //        HojaExcel.get_Range("B2:F2").Font.Size = 12;

        //        HojaExcel.get_Range("B3:G3").Merge();
        //        HojaExcel.get_Range("B3:D3").set_Value(value: "R.U.C. :  1097538811");
        //        HojaExcel.get_Range("B3:F3").Font.Bold = true;
        //        HojaExcel.get_Range("B3:F3").Font.Size = 13;

        //        HojaExcel.get_Range("B4:G4").Merge();
        //        HojaExcel.get_Range("B4:F4").set_Value(value: "Via Los Libertadores Km. 6 San Clemente - PISCO");
        //        HojaExcel.get_Range("B4:F4").Font.Italic = true;
        //        HojaExcel.get_Range("B4:F4").Font.Size = 13;

        //        HojaExcel.get_Range("D5:i5").Merge();
        //        HojaExcel.get_Range("D5:i5").set_Value(value: "ROMANEO DE DESPACHO");
        //        HojaExcel.get_Range("D5:i5").Font.Bold = true;
        //        HojaExcel.get_Range("D5:i5").Font.Size = 20;

        //        // //CONTAMOS LAS COLUMNAS Y FILAS    
        //        int NColr = WINPESFARD.My.MyProject.Forms.F_Romaneo_liquidacion_Pesfard.grillaaromaneo.ColumnCount;
        //        int NRowr = WINPESFARD.My.MyProject.Forms.F_Romaneo_liquidacion_Pesfard.grillaaromaneo.RowCount;

        //        for (int ir = 1, loopTo3 = NColr; ir <= loopTo3; ir++)
        //        {
        //            {
        //                ref var withBlock2 = ref HojaExcel;
        //                // .Range(.Cells(5, 2), .Cells(5, 10)).BorderAround()
        //                withBlock2.get_Range(withBlock2.Cells.get_Item(7, ir + 1), withBlock2.Cells.get_Item(7, ir + 1)).BorderAround();
        //            }
        //            HojaExcel.Cells.set_Item((object)7, (object)(ir + 1), WINPESFARD.My.MyProject.Forms.F_Romaneo_liquidacion_Pesfard.grillaaromaneo.Columns[ir - 1].Name.ToString());
        //        }

        //        for (int Filar = 0, loopTo4 = NRowr - 1; Filar <= loopTo4; Filar++)
        //        {
        //            for (int Colr = 0, loopTo5 = NColr - 1; Colr <= loopTo5; Colr++)
        //            {
        //                {
        //                    ref var withBlock3 = ref HojaExcel;
        //                    // .Range(.Cells(5, 2), .Cells(5, 10)).BorderAround()
        //                    withBlock3.get_Range(withBlock3.Cells.get_Item(Filar + 8, Colr + 2), withBlock3.Cells.get_Item(Filar + 8, Colr + 2)).BorderAround();
        //                }
        //                HojaExcel.Cells.set_Item((object)(Filar + 8), (object)(Colr + 2), WINPESFARD.My.MyProject.Forms.F_Romaneo_liquidacion_Pesfard.grillaaromaneo[Colr, Filar].Value);

        //            }

        //        }

        //        HojaExcel.Rows.get_Item(7).Font.Bold = (object)1;
        //        HojaExcel.Rows.get_Item(7).HorizontalAlignment = (object)3;
        //        HojaExcel.Columns.AutoFit();

        //        Mi_Excel.Visible = true;

        //        Mi_Excel = null;
        //        LibroExcel = null;
        //        HojaExcel = null;
        //        FileSystem.FileClose(1);
        //        GC.Collect();
        //    }

        //    catch (Exception ex)
        //    {
        //    }

        //}
    }
}
