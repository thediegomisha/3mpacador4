using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;


namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmProductorCLP : Form
    {
        public frmProductorCLP()
        {
            InitializeComponent();
            PrepGrid();          
            
        }       

        private void limpiarcampos()
        {
            try
            {
                txtCLP.Text = String.Empty;
             
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            txtCLP.Focus();
        }
      
        private void activarcamposjuridica()
        {
            txtCLP.Enabled = true;
          
        }
        private void desactivarcamposjuridica()
        {
            txtCLP.Enabled = false;
          
        }

        private void consulta()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblclp_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_clp", MySqlType.Int).Value = (txtCLP.Text.ToString()); ;


                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        tamanio();
                        ocultar_columnas();
                        contar();
                        lblclptotal.Text = datos.Rows[0]["total_registros"].ToString();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
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
                withBlock.Columns["CLP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CLP"].Width = 110;

                withBlock.Columns["REGION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["REGION"].Width = 130;

                withBlock.Columns["VARIEDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["VARIEDAD"].Width = 150;


                withBlock.Columns["RAZONSOCIAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["RAZONSOCIAL"].Width = 300;


                withBlock.Columns["NOMBRELUGAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["NOMBRELUGAR"].Width = 250;

                withBlock.Columns["FCERTIFICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FCERTIFICADO"].Width = 95;

                withBlock.Columns["FFINCERTIFICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FFINCERTIFICADO"].Width = 95;


            }
            catch (Exception)
            {

                //  throw;
            }
            {


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LBLCONTAR.Text = String.Empty;
            consulta();
            
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

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = this.datalistado.Rows[e.RowIndex];
                // Instanciamos el Formulario PADRE

                frmProductor2 frmProductor2 = Owner as frmProductor2;

                frmProductor2.txtRazonSocial.Text = fila.Cells[3].Value.ToString();
                frmProductor2.txtnombreLugar.Text = fila.Cells[4].Value.ToString();
                frmProductor2.txtregion.Text = fila.Cells[1].Value.ToString();
                frmProductor2.txtclp.Text = fila.Cells[0].Value.ToString(); 
                this.Close();
                // mostrarconsulta2();
            }
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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[1].Visible = false;
            //this.datalistado.Columns[2].Visible = false;
            //this.datalistado.Columns[3].Visible = false;
            //this.datalistado.Columns[4].Visible = false;
            //this.datalistado.Columns[5].Visible = false;
            //this.datalistado.Columns[6].Visible = false;
            this.datalistado.Columns[7].Visible = false;
            //this.datalistado.Columns[8].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }


        private void txtCLP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtCLP.Text))
                {
                    btnBuscar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Ingrese el Dato Correcto");
                }


            }
        }

        private void frmProductorCLP_Activated(object sender, EventArgs e)
        {
            txtCLP.Focus();
        }
    }
}
