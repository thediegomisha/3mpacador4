using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmMatCosecha : Form
    {
        public frmMatCosecha()
        {
            InitializeComponent();
            mostrarMatCosecha();
        }

        private void InsertarMetodoCultivo()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmatcosecha_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                {
                    if (!string.IsNullOrEmpty(txtMatCosecha.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar).Value = txtMatCosecha.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Material de Cosecha", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                comando.ExecuteNonQuery();
                MessageBox.Show("MATERIAL DE COSECHA REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                mostrarMatCosecha();
                // ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MATERIAL DE COSECHA NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK,
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
            txtMatCosecha.Text = string.Empty;
        }

        public void mostrarMatCosecha()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmatcosecha_Select", ConexionGral.conexion);
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
                        datalistado.Columns["idmatcosecha"].Visible = false;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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