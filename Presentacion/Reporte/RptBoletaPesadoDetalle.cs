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
using static _3mpacador4.Presentacion.Reporte.RptGeneral;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptBoletaPesadoDetalle : Form

    {
        //  String nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string nombreArchivo = "C:/archivo.xlsx";

        // Label[] labels = new Label[] { lblciente, label2, label3, label4, label5, label6 };


        public RptBoletaPesadoDetalle(string guiaRemision, string numdoc, string lote, string fechapesaje, string hllegada, string producto, string variedad, string exportador, string productor, string codigoproduccion, string cantjabas, string pesobruto, string pesojabas, string pesoneto, string prom)
        {
            InitializeComponent();
            PrepGrid();
            PrepGrid2();
            MostrarDatosEnLabels(guiaRemision, numdoc, lote, fechapesaje, hllegada, producto, variedad, exportador, productor, codigoproduccion, cantjabas, pesobruto, pesojabas, pesoneto, prom);

        }



        public RptBoletaPesadoDetalle()
        {
            InitializeComponent();
            //Labels datalistado2_2
            string resultado = this.lblresultado.Text;
            string totaljabas2 = this.lblcantjabas.Text;
            string totalneto2 = this.lbltotalneto2.Text;

            //Labels datalistado3_2
            string contardescarte2 = this.lblcontardescarte2.Text;
            string jabasdescarte2 = this.lblcantjabasdescarte2.Text;
            string netodescarte2 = this.lbltotalnetodescarte2.Text;
        }


        //public RptBoletaPesadoDetalle(string tjaba2, string tparih2, string cantjabas2, string pesobruto2, string pesojabas2, string pesoneto2, string prom2) : this()
        //{
        //    CargarDatosEnDatalistado2_2(tjaba2, tparih2, cantjabas2, pesobruto2, pesojabas2, pesoneto2, prom2);
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

        private void PrepGrid2()
        {
            {
                var withBlock = this.datalistado3_2;
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
            lblresultado.Text = Strings.FormatNumber(contador, 0);
        }
        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado2_2.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);


                }
                lbltotalneto2.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);


            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Microsoft.VisualBasic.Constants.vbCritical);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarExcel(nombreArchivo);
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
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
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

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado2_2;

                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }











        private void MostrarDatosEnLabels(string guiaRemision, string numdoc, string lote, string fechapesaje, string hllegada, string producto, string variedad, string exportador, string productor, string codigoproduccion, string cantjabas, string pesobruto, string pesojabas, string pesoneto, string prom)
        {
            //Aqui se igualan tanto label como las variables para pasar los datos del Formulario RptGeneral al Formulario RptBoletaPesadoDetalle 
            lblguiaingreso.Text = guiaRemision;
            //lbl.Text = numdoc;
            lblnumlote.Text = lote;
            lblfechaingreso.Text = fechapesaje;
            lblhoraingreso.Text = hllegada;
            lblproducto.Text = producto;
            lblvariedad.Text = variedad;
            lblcliente.Text = exportador;
            lblproductor.Text = productor;
            lblclp.Text = codigoproduccion;
            //lblcantjabas.Text = cantjabas;
            //lblpesobruto.Text = pesobruto;
            //lblpesojabas.Text = pesojabas;
            //lblpesoneto.Text = pesoneto;
            //lblprom.Text = prom;

            mostrarconsulta();

        }





        private void mostrarconsulta2()
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

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado2_2;
                    if (datos.Rows.Count != 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        //tamanio();
                        ocultar_columnas2();
                        //actualizardatos();
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












        public void LimpiarDatalistado2_2()
        {
            // Limpia todas las filas de datalistado2_2.
            datalistado2_2.Rows.Clear();
        }

        public void LimpiarDatalistado3_2()
        {
            // Limpia todas las filas de datalistado2_2.
            datalistado3_2.Rows.Clear();
            
            lblinfo2.Visible = true;
        }

        public void AgregarFilaEnDatalistado2_2(string tjaba2, string tparih2, string cantjabas2, string pesobruto2, string pesojabas2, string pesoneto2, string promedio2)
        {
            if (datalistado2_2.Columns.Count == 0)
            {
                // Se Crean y agregan columnas a datalistado2_2.
                datalistado2_2.Columns.Add("tjaba2", "T. JABA");
                datalistado2_2.Columns.Add("tparih2", "T.PARIH");
                datalistado2_2.Columns.Add("cantjabas2", "CANT JABAS");
                datalistado2_2.Columns.Add("pesobruto2", "PESO BRUTO");
                datalistado2_2.Columns.Add("pesojabas2", "PESO JABAS");
                datalistado2_2.Columns.Add("pesoneto2", "PESO NETO");
                datalistado2_2.Columns.Add("promedio2", "PROMEDIO");
            }

            // Agrega una fila con los datos de datalistado2_2.
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell { Value = tjaba2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = tparih2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = cantjabas2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = pesobruto2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = pesojabas2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = pesoneto2 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = promedio2 });

            // Hace agregar filas a datalistado2_2.
            datalistado2_2.Rows.Add(row);
        }


        public void AgregarFilaEnDatalistado3_2(string cantjabas3, string pesobruto3, string pesoneto3)
        {
            if (datalistado3_2.Columns.Count == 0)
            {
                // Se Crean y agregan columnas a datalistado2_2.
                datalistado3_2.Columns.Add("cantjabas3", "CANT JABAS");
                datalistado3_2.Columns.Add("pesobruto3", "PESO BRUTO");
                datalistado3_2.Columns.Add("pesoneto3", "PESO NETO");
            }
            // Agrega una fila con los datos de datalistado2_2.
            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell { Value = cantjabas3 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = pesobruto3 });
            row.Cells.Add(new DataGridViewTextBoxCell { Value = pesoneto3 });

            // Hace agregar filas a datalistado2_2.
            datalistado3_2.Rows.Add(row);

            // Hace que si hay filas en datalistado3_2 muestra o oculta el label.
            lblinfo2.Visible = (datalistado3_2.Rows.Count == 0);
        }

        //Labels de datalistado2_2
        public string resultado
        {
            get { return lblresultado.Text; }  // Obtiene el dato del label en RptGeneral.
            set { lblresultado.Text = value; }  // Establece el valor del label en RptGeneral.
        }

        public string totaljabas2
        {
            get { return lblcantjabas.Text; }
            set { lblcantjabas.Text = value; }
        }

        public string totalneto2
        {
            get { return lbltotalneto2.Text; }
            set { lbltotalneto2.Text = value; }
        }

        //Label de datalistado3_2

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
    }
}