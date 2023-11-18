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
using NPOI.SS.Formula.Functions;
using PdfSharp.Drawing;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptBoletaPesadoDetalle : Form

    {
      //  String nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string nombreArchivo = "C:/archivo.xlsx";

        // Label[] labels = new Label[] { lblciente, label2, label3, label4, label5, label6 };


        //public RptBoletaPesadoDetalle(string[] filaConDatos, DataTable data)
        //{
        //    InitializeComponent();
        //    PrepGrid();

        //    if (filaConDatos.Length >= 5)
        //    {
        //        lblguiaingreso.Text = filaConDatos[0];
        //        //   lblnumdoc.Text = filaConDatos[1];
        //        lblnumlote.Text = filaConDatos[2];
        //        lblfechaingreso.Text = filaConDatos[3];
        //        lblhoraingreso.Text = filaConDatos[4];
        //        lblproducto.Text = filaConDatos[5];
        //        lblvariedad.Text = filaConDatos[6];
        //        lblcliente.Text = filaConDatos[7];
        //        lblproductor.Text = filaConDatos[8];
        //        lblclp.Text = filaConDatos[9];
        //        //   lblservicio .Text = filaConDatos[4];
        //        //   lblmetodo.Text = filaConDatos[2];

        //        datalistado2_2.DataSource = data;
        //        ocultar_columnas2();
        //    }
        //}


        public RptBoletaPesadoDetalle(string[] filaConDatos, DataTable data2, DataTable data3)
        {
            InitializeComponent();
            PrepGrid();
            PrepGrid3();

            if (filaConDatos.Length >= 5)
            {
                lblguiaingreso.Text = filaConDatos[0];
                lblnumlote.Text = filaConDatos[2];
                lblfechaingreso.Text = filaConDatos[3];
                lblhoraingreso.Text = filaConDatos[4];
                lblproducto.Text = filaConDatos[5];
                lblvariedad.Text = filaConDatos[6];
                lblcliente.Text = filaConDatos[7];
                lblproductor.Text = filaConDatos[8];
                lblclp.Text = filaConDatos[9];

                datalistado2_2.DataSource = data2;
                ocultar_columnas2();

                datalistado3_2.DataSource = data3;
                ocultar_columnas3();
                lblinfo2.Visible = (datalistado3_2.Rows.Count == 0);
            }
        }

        private void ocultar_columnas3()
        {
            this.datalistado3_2.Columns[0].Visible = true;
            this.datalistado3_2.Columns[1].Visible = true;
            this.datalistado3_2.Columns[2].Visible = true;
        }




        //public RptBoletaPesadoDetalle(DataGridViewSelectedRowCollection filasseleccionadas)
        //{
        //    InitializeComponent();
        //    PrepGrid();
        //  //  MostrarDatosEnLabels(guiaRemision, numdoc, lote, fechapesaje, hllegada, producto, variedad, exportador, productor, codigoproduccion, cantjabas, pesobruto, pesojabas, pesoneto, prom);

        //}

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
                var withBlock = this.datalistado2_2;
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
                var withBlock = datalistado2_2;
              
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
            this.datalistado2_2.Columns[0].Visible = false;
            this.datalistado2_2.Columns[1].Visible = false;
            this.datalistado2_2.Columns[2].Visible = false;
            this.datalistado2_2.Columns[3].Visible = false;
            this.datalistado2_2.Columns[4].Visible = false;
            this.datalistado2_2.Columns[5].Visible = false;
            this.datalistado2_2.Columns[6].Visible = false;
            this.datalistado2_2.Columns[7].Visible = false;
            this.datalistado2_2.Columns[8].Visible = false;
            this.datalistado2_2.Columns[0].Visible = false;
            this.datalistado2_2.Columns[0].Visible = false;
            this.datalistado2_2.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            int contarfila = datalistado2_2.RowCount - 1;
            int contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }
            resultado.Text = Strings.FormatNumber(contador, 0);
        }
        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach(DataGridViewRow row in datalistado2_2.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                    
                   
                }
                totalneto2.Text = Strings.FormatNumber(total, 2);
                totaljabas2.Text = Strings.FormatNumber(cantjabas, 0);


            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Microsoft.VisualBasic.Constants.vbCritical);
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

        private void RptBoletaPesadoDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.ke == (Char)Keys.Escape)
            //    this.Close();
        }

        private void RptBoletaPesadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ocultar_columnas2()
        {
            this.datalistado2_2.Columns[0].Visible = false;
            this.datalistado2_2.Columns[1].Visible = false;
            this.datalistado2_2.Columns[2].Visible = false;
            this.datalistado2_2.Columns[3].Visible = false;
            this.datalistado2_2.Columns[4].Visible = false;
            this.datalistado2_2.Columns[5].Visible = false;
            this.datalistado2_2.Columns[6].Visible = false;
            this.datalistado2_2.Columns[7].Visible = false;
            this.datalistado2_2.Columns[8].Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void lblcantjabas_Click(object sender, EventArgs e)
        {

        }

        private void LBLCONTAR_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void totalneto_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }


        private void PrepGrid3()
        {
            {
                var withBlock = this.datalistado3_2;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 10.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

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

                //withBlock.BorderStyle = BorderStyle.None;

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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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

        //public void LimpiarDatalistado3_2()
        //{
        //    // Limpia todas las filas de datalistado2_2.
        //    datalistado3_2.Rows.Clear();

        //    lblinfo2.Visible = true;
        //}

        //public void AgregarFilaEnDatalistado3_2(string cantjabas3, string pesobruto3, string pesoneto3)
        //{
        //    if (datalistado3_2.Columns.Count == 0)
        //    {
        //        // Se Crean y agregan columnas a datalistado2_2.
        //        datalistado3_2.Columns.Add("cantjabas3", "CANT JABAS");
        //        datalistado3_2.Columns.Add("pesobruto3", "PESO BRUTO");
        //        datalistado3_2.Columns.Add("pesoneto3", "PESO NETO");
        //    }
        //    // Agrega una fila con los datos de datalistado2_2.
        //    DataGridViewRow row = new DataGridViewRow();
        //    row.Cells.Add(new DataGridViewTextBoxCell { Value = cantjabas3 });
        //    row.Cells.Add(new DataGridViewTextBoxCell { Value = pesobruto3 });
        //    row.Cells.Add(new DataGridViewTextBoxCell { Value = pesoneto3 });

        //    // Hace agregar filas a datalistado2_2.
        //    datalistado3_2.Rows.Add(row);

        //    // Hace que si hay filas en datalistado3_2 muestra o oculta el label.
        //    lblinfo2.Visible = (datalistado3_2.Rows.Count == 0);

        //    PrepGrid3();
        //}

        public string contardescarte2
        {
            get { return lblcontardescarte2.Text; }
            set { lblcontardescarte2.Text = value; }
        }

        public string jabasdescarte2
        {
            get { return lblcantjabasdescarte2.Text; }
            set { lblcantjabasdescarte2.Text = value; }
        }

        public string totalnetodescarte2
        {
            get { return lbltotalnetodescarte2.Text; }
            set { lbltotalnetodescarte2.Text = value; }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (datalistado2_2.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarPDF(datalistado2_2, datalistado3_2, lblnumlote, labcliente, lblcliente, labproductor, lblproductor, labmetodo, lblmetodo,
                labproducto, lblproducto, labservicio, lblservicio, labacopiador, lblacopiador, labguiaingreso, lblguiaingreso,
                labruc_dni, lblruc_dni, labclp, lblclp, labvariedad, lblvariedad, labfechaingreso, lblfechaingreso, labhoraingreso,
                lblhoraingreso, labresultado, resultado, labcantjabas, totaljabas2, labtotalneto, totalneto2);
        }


        private void ExportarPDF(DataGridView datalistado2_2, DataGridView datalistado3_2, Label lblnumlote, Label labcliente, Label lblcliente,
            Label labproductor, Label lblproductor, Label labmetodo, Label lblmetodo, Label labproducto, Label lblproducto, 
            Label labservicio, Label lblservicio, Label labacopiador, Label lblacopiador, Label labguiaingreso, Label lblguiaingreso, 
            Label labruc_dni, Label lblruc_dni, Label labclp, Label lblclp, Label labvariedad, Label lblvariedad, 
            Label labfechaingreso, Label lblfechaingreso, Label labhoraingreso, Label lblhoraingreso, Label labresultado, Label resultado,
            Label labcantjabas, Label totaljabas2, Label labtotalneto, Label totalneto2)
        {
            try
            {
                SaveFileDialog dialogoGuardar = new SaveFileDialog();
                dialogoGuardar.Filter = "Archivo PDF|*.pdf";
                dialogoGuardar.Title = "Guardar PDF";
                dialogoGuardar.ShowDialog();

                if (!string.IsNullOrEmpty(dialogoGuardar.FileName))
                {
                    using (PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument())
                    {
                        pdf.Info.Title = "Los datos fueron exportados.";

                        PdfSharp.Pdf.PdfPage pagina = pdf.AddPage();
                        pagina.Orientation = PdfSharp.PageOrientation.Portrait;
                        XGraphics gfx = XGraphics.FromPdfPage(pagina);
                        XFont fuente = new XFont("Arial", 7);
                        XFont fuentetitulo = new XFont("Arial", 12);
                        
                        int posX = 20;
                        int posY = 20;

                        //Título del PDF.
                        gfx.DrawString($"BOLETA DE PESAJE        Nº {lblnumlote.Text}", fuentetitulo, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posY += 35;

                        //Labels.
                        gfx.DrawString(labcliente.Text, fuente, XBrushes.Black, new XRect(posX, posY, 650, 40), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblcliente.Text, fuente, XBrushes.Black, new XRect(posX, posY, 650, 40), XStringFormats.TopLeft);
                        posX += -65;
                        posY += 20;

                        gfx.DrawString(labproductor.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblproductor.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += -65;
                        posY += 20;

                        gfx.DrawString(labmetodo.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblmetodo.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        posY += 20;

                        gfx.DrawString(labproducto.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblproducto.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        posY += 20;

                        gfx.DrawString(labservicio.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblservicio.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        posY += 20;

                        gfx.DrawString(labacopiador.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        gfx.DrawString(lblacopiador.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posY += -100;
                        posX += 400;

                        //Segunda columna de labels.
                        gfx.DrawString(lblguiaingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labguiaingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += 65;
                        posY += 20;

                        gfx.DrawString(lblruc_dni.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labruc_dni.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        posY += 20;

                        gfx.DrawString(lblclp.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labclp.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        posY += 20;

                        gfx.DrawString(lblvariedad.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labvariedad.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        posY += 20;

                        gfx.DrawString(lblfechaingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labfechaingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posX += 65;
                        posY += 20;

                        gfx.DrawString(lblhoraingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 500, 20), XStringFormats.TopLeft);
                        posX += -65;
                        gfx.DrawString(labhoraingreso.Text, fuente, XBrushes.Black, new XRect(posX, posY, 800, 500), XStringFormats.TopLeft);
                        posY += 25;

                        //Labels del datagrid datalistado2_2
                        //posY += 300;
                        //gfx.DrawString(labresultado.Text, fuente, XBrushes.Black, new XRect(posX, posY, 650, 40), XStringFormats.TopLeft);
                        //posY += 5;
                        //gfx.DrawString(resultado.Text, fuente, XBrushes.Black, new XRect(posX, posY, 650, 40), XStringFormats.TopLeft);
                        //posY += 20;
                        posX += -800;
                        /*posY += -250*/;

                        string[] columnasMostrar = { "T. JABA", "T.PARIH", "CANT JABAS", "PESO BRUTO", "PESO JABAS", "PESO NETO", "PROMEDIO" };

                        HashSet<string> columnasDeseadas = new HashSet<string>(columnasMostrar);

                        //Columnas del datagrid datalistado2_2
                        for (int c = 0; c < datalistado2_2.Columns.Count; c++)
                        {
                            if (columnasDeseadas.Contains(datalistado2_2.Columns[c].HeaderText))
                            {
                                gfx.DrawString(datalistado2_2.Columns[c].HeaderText, fuente, XBrushes.Black, new XRect(posX + c * 55, posY, 50, 20), XStringFormats.TopLeft);
                            }
                        }

                        posY += 25;

                        //Datos del datagrid datalistado2_2
                        for (int c = 0; c < datalistado2_2.Rows.Count; c++)
                        {
                            for (int f = 0; f < datalistado2_2.Columns.Count; f++)
                            {
                                if (columnasDeseadas.Contains(datalistado2_2.Columns[f].HeaderText))
                                {
                                    gfx.DrawString(datalistado2_2.Rows[c].Cells[f].Value.ToString(), fuente, XBrushes.Black, new XRect(posX + f * 55, posY, 50, 20), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    //Si las columnas no estan las deseadas, borra los datos.
                                    gfx.DrawString("", fuente, XBrushes.Black, new XRect(posX + f * 55, posY, 50, 20), XStringFormats.TopLeft);
                                }
                            }

                            posY += 20;
                        }

                        //Nueva posición de labels.
                        int posiX = 20;
                        int posiY = 389;

                        //Labels del datagrid datalistado2_2.
                        posiX += 120;
                        posiY += 50;
                        gfx.DrawString(labresultado.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);
                        posiY += 10;
                        gfx.DrawString(resultado.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);

                        posiX += 150;
                        posiY += -10;
                        gfx.DrawString(labcantjabas.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);
                        posiY += 10;
                        gfx.DrawString(totaljabas2.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);

                        posiX += 150;
                        posiY += -10;
                        gfx.DrawString(labtotalneto.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);
                        posiY += 10;
                        gfx.DrawString(totalneto2.Text, fuente, XBrushes.Black, new XRect(posiX, posiY, 650, 20), XStringFormats.TopLeft);
                        posiY += 45;

                        posiX -= 400;
                        gfx.DrawString("TABLA DE DESCARTE:", fuente, XBrushes.Black, new XRect(posiX, posiY, 500, 20), XStringFormats.TopLeft);
                        
                        posiY += 20;
                        posiX += 100;
                        // Columnas del datagrid datalistado3_2
                        for (int c = 0; c < datalistado3_2.Columns.Count; c++)
                        {
                            gfx.DrawString(datalistado3_2.Columns[c].HeaderText, fuente, XBrushes.Black, new XRect(posiX + c * 55, posiY, 50, 20), XStringFormats.TopLeft);
                        }

                        posiY += 25;

                        // Contenido del datagrid datalistado3_2
                        for (int c = 0; c < datalistado3_2.Rows.Count; c++)
                        {
                            for (int f = 0; f < datalistado3_2.Columns.Count; f++)
                            {
                                gfx.DrawString(datalistado3_2.Rows[c].Cells[f].Value.ToString(), fuente, XBrushes.Black, new XRect(posiX + f * 55, posiY, 50, 20), XStringFormats.TopLeft);
                            }

                            posiY += 20;  // Ajusta según sea necesario
                        }


                        //H!ace de nuevo el proceso para datalistado3_2 si se necesita.

                        pdf.Save(dialogoGuardar.FileName);

                        MessageBox.Show("Los datos se han exportado a PDF correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el PDF: {ex.Message}\nDetalles: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lblinfo2_Click(object sender, EventArgs e)
        {

        }
    }
}
