using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmEditUsuarios : Form
    {

        public int idUsuarioedit { get; set; }
        //  int idUsuario;
        public frmEditUsuarios()
        {
            InitializeComponent();
            
            //UpdateUsuario(idUsuario);

        }


        public void CargarDatosUsuario(int idUsuario)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                MySqlCommand comando = new MySqlCommand("us_lista_usuarioid", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idUsuario", idUsuario);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombres.Text = reader["nombres"].ToString();
                        txtaPaterno.Text = reader["apaterno"].ToString();
                        txtaMaterno.Text = reader["amaterno"].ToString();
                        txtDni.Text = reader["dni"].ToString();
                        txtTelefono.Text = reader["telefono"].ToString();
                        txtLogin.Text = reader["login"].ToString();
                        txtClave.Text = reader["clave"].ToString();
                        //txtAcceso.Text = reader["acceso"].ToString();
                        txtNivel.Text = reader.GetInt32("nivel").ToString();
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void limpiarcampos()
        {
            try
            {
                txtNombres.Text = string.Empty;
                txtaPaterno.Text = string.Empty;
                txtaMaterno.Text = string.Empty;
                txtDni.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtClave.Text = string.Empty;
                txtAcceso.Text = string.Empty;
                txtNivel.Text = string.Empty;
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



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbusuario_Update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idUsuario", idUsuarioedit);
                comando.Parameters.AddWithValue("p_nombres", txtNombres.Text);
                comando.Parameters.AddWithValue("p_apaterno", txtaPaterno.Text);
                comando.Parameters.AddWithValue("p_amaterno", txtaMaterno.Text);
                comando.Parameters.AddWithValue("p_dni", txtDni.Text);
                comando.Parameters.AddWithValue("p_telefono", txtTelefono.Text);
                comando.Parameters.AddWithValue("p_login", txtLogin.Text);
                comando.Parameters.AddWithValue("p_clave", txtClave.Text);
                comando.Parameters.AddWithValue("p_acceso", string.IsNullOrEmpty(txtAcceso.Text) ? (object)DBNull.Value : txtAcceso.Text);
                comando.Parameters.AddWithValue("p_nivel", Convert.ToInt32(txtNivel.Text));
                
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
