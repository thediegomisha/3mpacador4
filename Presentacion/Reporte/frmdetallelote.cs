using _3mpacador4.Logica;
using _3mpacador4.Properties;
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

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class frmdetallelote : Form
    {
        public frmdetallelote()
        {
            InitializeComponent();
            PrepGrid();
         
            mostrarconsulta();
        }

        private void frmdetallelote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
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
                withBlock.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

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
                    new Font("Tahoma", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                withBlock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // 
                // determina la altura de todas las filas
                // 
                withBlock.RowTemplate.Height = 17;
                // withBlock.SelectionMode.


                // establecer el modo de selección
                // 
                withBlock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
            datalistado.Columns[0].Visible = true;
            datalistado.Columns[1].Visible = true;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = true;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = true;
            datalistado.Columns[7].Visible = true;
            datalistado.Columns[8].Visible = true;
            datalistado.Columns[9].Visible = false;
            datalistado.Columns[10].Visible = false;
            datalistado.Columns[11].Visible = false;

            // datalistado.Columns(3).Visible = False
        }
        private void mostrarconsulta()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

               var dtInicio = "null";
                var dtFin = "null";

                var fechaaño = Settings.Default.periodo;
                var partes = fechaaño.Split(' ')[0].Split('/');
                var año = partes[2];

                var iniciocadena = 0;

                var comando = new MySqlCommand("usp_tblticketpesaje_RptGral", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        ocultar_columnas();
                        LBLCONTAR.Text = datalistado.RowCount.ToString();
                        //tamanio();
                        //contarGeneral();
                        //contarjabaGeneral();
                        //lblinfo1.Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                  //      lblinfo1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
