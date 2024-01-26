using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmCultivo : Form
    {
        public frmCultivo()
        {
            InitializeComponent();
            mostrarMetodoCultivo();
        }

        private void InsertarMetodoCultivo()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmetodocultivo_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                {
                    if (!string.IsNullOrEmpty(txtTipoCultivo.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar).Value = txtTipoCultivo.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Tipo de Cultivo", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                comando.ExecuteNonQuery();
                MessageBox.Show(@"TIPO DE CULTIVO REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                mostrarMetodoCultivo();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("TIPO DE CULTIVO NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void limpiarcampos()
        {
            txtTipoCultivo.Text = string.Empty;
        }

        public void mostrarMetodoCultivo()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        datalistado.Columns["idmetodocultivo"].Visible = false;
                        datalistado.Columns["descripcion"].Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarMetodoCultivo();
        }
    }
}