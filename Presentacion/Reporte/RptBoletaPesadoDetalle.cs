using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
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

        private void BtnExportar_Click(object sender, EventArgs e)
        {
        }
    }
}