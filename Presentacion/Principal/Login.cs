using _3mpacador4.Logica;
using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Sistema;
using Devart.Data.MySql;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           // info();

          lblversion.Text = Application.ProductVersion + "   ";
        }
            
        private void cmd_Aceptar_Click(object sender, EventArgs e)
       {
            string login = txtlogin.Text; // Obtén el nombre de usuario del TextBox
            string clave = txtpassword.Text; // Obtén la contraseña del TextBox
            int usuarioId;
            string nombre;
            string apaterno;

            bool autenticado = Validarusuario(login, clave, out usuarioId, out nombre, out apaterno);

            if (autenticado)
            {
                // El usuario se autenticó con éxito. Puedes realizar acciones adicionales aquí.
                MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                // La autenticación falló.
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }

        }

        private bool Validarusuario(string login, string clave, out int usuarioId, out string nombre, out string apaterno)
        {
            MySqlCommand comando = null;
            usuarioId = 1;
            nombre = "";
            apaterno = "";

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_validarusuarios", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_login", MySqlType.VarChar).Value = txtlogin.Text;
                comando.Parameters.AddWithValue("p_clave", MySqlType.VarChar).Value = txtpassword.Text;

                comando.Parameters.AddWithValue("p_valido", MySqlType.Bit);
                comando.Parameters["p_valido"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_usuario_id", MySqlType.Int);
                comando.Parameters["p_usuario_id"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar);
                comando.Parameters["p_nombre"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_apaterno", MySqlType.VarChar);
                comando.Parameters["p_apaterno"].Direction = ParameterDirection.Output;


                comando.ExecuteNonQuery();

                bool usuarioValido = Convert.ToBoolean(comando.Parameters["p_valido"].Value);

                if (usuarioValido)
                {
                    usuarioId = Convert.ToInt32(comando.Parameters["p_usuario_id"].Value);
                    nombre = Convert.ToString(comando.Parameters["p_nombre"].Value);
                    apaterno = Convert.ToString(comando.Parameters["p_apaterno"].Value);
                    MessageBox.Show("Inicio de sesión exitoso");
                    cargavalidada();
                    return usuarioValido;
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                    txtlogin.Text = "";
                    txtpassword.Text = "";
                    return usuarioValido;
                }
                        }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Devuelve false en caso de excepción.
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

        private void cargavalidada()
        {
            this.Hide();
            Principal.FrmBienvenida bienvenida = new Principal.FrmBienvenida();
            bienvenida.ShowDialog();
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
        }

        public void info()
        {
            System.Deployment.Application.ApplicationDeployment ver;
            ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
            lblversion.Text = ver.CurrentVersion.ToString() + "   ";
            //lblDatabase.Text = nombress[4].Substring(9) + "   ";
        }

        private void cmd_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

       

        private void txtlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
