using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmTerminal2 : Form
    {
        private int id;

        public frmTerminal2()
        {
            InitializeComponent();
        }

        private string Estado()
        {
            var estado = "";

            if (cbxestado.Checked)
                estado = "1";
            else
                estado = "0";

            return estado;
        }

        private void LimpiarCampos()
        {
            try
            {
                txtDescripcion.Focus();
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Algo Salio Mal LimpiarCampos() :( ");
                throw;
            }
        }

        private void InsertarTerminal()
        {
            try
            {
                if (txtDescripcion.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Descripcion para el Terminal", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtDescripcion.Focus();
                    return;
                }

                var aux = new Terminal();
                aux.descripcion = txtDescripcion.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblterminal_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_descripcion", aux.descripcion);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"TERMINAL REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"TERMINAL NO REGISTRADO. " + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void ActualizarTerminal()
        {
            try
            {
                if (txtDescripcion.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Nombres del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtDescripcion.Focus();
                    return;
                }

                var aux = new Terminal();
                aux.idterminal = id;
                aux.descripcion = txtDescripcion.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblterminal_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_id", aux.idterminal);
                comando.Parameters.AddWithValue("p_descripcion", aux.descripcion);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"TERMINAL ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"COLABORADOR NO REGISTRADO. 
" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarTerminal();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTerminal();
        }

        private void frmTerminal2_Load(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
            if (cbxestado.Checked)
                cbxestado.Text = @"ACTIVO";
            else
                cbxestado.Text = @"INACTIVO";

            if (frmTerminal.editar)
                if (frmTerminal.t.idterminal > 0)
                {
                    id = frmTerminal.t.idterminal;
                    txtDescripcion.Text = frmTerminal.t.descripcion;
                    if (Convert.ToBoolean(frmTerminal.t.flag_estado))
                        cbxestado.Checked = true;
                    else
                        cbxestado.Checked = false;
                }
        }
    }
}