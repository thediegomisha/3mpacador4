using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmProductorCLP : Form
    {
        public frmProductorCLP()
        {
            InitializeComponent();
            PrepGrid();
            txtCLP.Enabled = false;
            txtRazonSocial.Enabled = false;
        }

        private void limpiarcampos()
        {
            txtCLP.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
               
                if (chkclp.Checked == true)
                {
                    comando = new MySqlCommand("usp_tblclp_Select", ConexionGral.conexion);
                    comando.CommandType = (CommandType)4;
                    comando.Parameters.AddWithValue("p_clp", MySqlType.Text ).Value = txtCLP.Text;
                }
                else if (chkrazonsocial .Checked == true)
                {
                    comando = new MySqlCommand("usp_tblclp_SelectbyName", ConexionGral.conexion);
                    comando.CommandType = (CommandType)4;
                    comando.Parameters.AddWithValue("p_razonsocial", MySqlType.Text).Value = txtRazonSocial.Text;
                }

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        tamanio();
                        ocultar_columnas();
                        contar();
                        lblclptotal.Text = datos.Rows[0]["total_registros"].ToString();
                        MarcarVencidas();
                        if (chkrazonsocial.Checked != true)
                        {
                            poblarPais();
                        }
                       
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }
                ConexionGral.desconectar();
            }
        }

        private void MarcarVencidas()
        {
            DateTime fechaActual = DateTime.Today;

            foreach (DataGridViewRow row in datalistado.Rows)
            {
                if (!row.IsNewRow) // Evita la fila de nueva entrada, si está presente
                {
                    DataGridViewCell celdaFecha = row.Cells[6]; // Suponiendo que la columna de fecha es la segunda (índice 1)
                    DateTime fechaCelda;

                    if (celdaFecha.Value != null && DateTime.TryParse(celdaFecha.Value.ToString(), out fechaCelda))
                    {
                        if (fechaCelda < fechaActual)
                        {
                           // celdaFecha.Style.BackColor = System.Drawing.Color.LightCoral; // Color de fondo para celdas retrasadas
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Red; // Color de fondo para filas con fechas vencidas
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.White; // Color de la letra para filas con fechas vencidas

                        }
                    }
                }
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
                withBlock.Columns["CLP"].Width = 90;

                withBlock.Columns["REGION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["REGION"].Width = 100;

                withBlock.Columns["VARIEDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["VARIEDAD"].Width = 90;


                withBlock.Columns["RAZONSOCIAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["RAZONSOCIAL"].Width = 200;


                withBlock.Columns["NOMBRELUGAR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["NOMBRELUGAR"].Width = 250;

                withBlock.Columns["FCERTIFICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FCERTIFICADO"].Width = 95;

                withBlock.Columns["FFINCERTIFICADO"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FFINCERTIFICADO"].Width = 95;
            }
            catch (Exception)
            {
                //  throw;
            }

            {
            }
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

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = datalistado.Rows[e.RowIndex];
                // Instanciamos el Formulario PADRE

                var frmProductor2 = Owner as frmProductor2;

                frmProductor2.txtRazonSocial.Text = fila.Cells[3].Value.ToString();
                frmProductor2.txtnombreLugar.Text = fila.Cells[4].Value.ToString();
                frmProductor2.txtregion.Text = fila.Cells[1].Value.ToString();
                frmProductor2.txtclp.Text = fila.Cells[0].Value.ToString();
                Close();
                // mostrarconsulta2();
            }
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
                    new Font("Tahoma", 9.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            datalistado.Columns[7].Visible = false;
            //this.datalistado.Columns[8].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }


        private void txtCLP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCLP.Text))
                    btnBuscar.PerformClick();
                else
                    MessageBox.Show(@"Ingrese el Dato Correcto");
            }
        }

        private void frmProductorCLP_Activated(object sender, EventArgs e)
        {
            txtCLP.Focus();
        }

        private void chkclp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkclp.Checked == true)
                {
                    txtCLP.Enabled = true;
                    txtRazonSocial.Enabled = false;
                    chkrazonsocial.Checked = false;
                }
               
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void chkrazonsocial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkrazonsocial.Checked == true)
                {
                    txtRazonSocial.Enabled = true;
                    chkclp.Checked = false;
                    txtCLP.Enabled = false;
                }
               
            }
            catch (Exception exception)
            {
               
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtRazonSocial.Text))
                    btnBuscar.PerformClick();
                else
                    MessageBox.Show(@"Ingrese un apellido");
            }
        }

        private void poblarPais()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblhabilitadodestino_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_clp", MySqlType.Int).Value = txtCLP.Text;
                ;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    //var withBlock = this.cboLote;
                    if (datos != null && datos.Rows.Count > 0)
                        lblpais1.Text = datos.Rows[0]["ORIGEN"].ToString();

                    else
                        lblpais1.Text = @"EUROPA";
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LBLCONTAR.Text = string.Empty;
            consulta();
        }

        private void frmProductorCLP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}