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

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmEditUsuarios : Form
    {
        public int IdUsuario { get; set; }

        private int idUsuario;

        public frmEditUsuarios()
        {
            InitializeComponent();
            this.idUsuario = IdUsuario;
            MostrarDatosUsuario();

        }


        private void MostrarDatosUsuario()
        {
            int idUsuario = IdUsuario;
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("SELECT nombres, apaterno, amaterno, dni, telefono, login, clave, nivel FROM tblusuarios WHERE idusuarios = @idUsuario", ConexionGral.conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

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
                        txtNivel.Text = reader["nivel"].ToString();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //MostrarDatosUsuario();
            
            this.Close();
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
