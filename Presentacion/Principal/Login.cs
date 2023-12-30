using _3mpacador4.Logica;
using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Sistema;
using _3mpacador4.Presentacion.Principal;
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

namespace _3mpacador4.Presentacion
{
    public partial class Login : Form
    {
        public static string nombre1 { get; private set; }
        public static string apaterno1 { get; private set; }
        public static int usuarioId1 { get; private set; }

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

               bool autenticado = Validarusuario(login, clave, out usuarioId, out nombre, out apaterno); // COMENTAR PARA UTILIZAR CON CONTRASEÑA

          //  cargavalidada(); // DESCOMENTAR PARA UTILIZAR SIN CONTRASEÑA 


        }

        private bool Validarusuario(string login, string clave, out int usuarioId, out string nombre, out string apaterno)
        {
            MySqlCommand comando = null;
            usuarioId = 0;
            nombre = string.Empty;
            apaterno = string.Empty;

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_validarusuarios", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_login", MySqlType.VarChar).Value = login;
                comando.Parameters.AddWithValue("p_clave", MySqlType.VarChar).Value = clave;

                comando.Parameters.AddWithValue("p_valido", MySqlType.Bit);
                comando.Parameters["p_valido"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_usuario_id", MySqlType.Int);
                comando.Parameters["p_usuario_id"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar.ToString()) ;
                comando.Parameters["p_nombre"].Direction = ParameterDirection.Output;

                comando.Parameters.AddWithValue("p_apaterno", MySqlType.VarChar.ToString());
                comando.Parameters["p_apaterno"].Direction = ParameterDirection.Output;

                comando.ExecuteNonQuery();

                bool usuarioValido = Convert.ToBoolean(comando.Parameters["p_valido"].Value);

                if (usuarioValido)
                {
                    usuarioId1 = Convert.ToInt32(comando.Parameters["p_usuario_id"].Value);
                    nombre1 = (comando.Parameters["p_nombre"].Value.ToString());
                    apaterno1 = (comando.Parameters["p_apaterno"].Value.ToString());
               //     MessageBox.Show("Inicio de sesión exitoso");
                    cargavalidada();                 
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                    txtlogin.Text = string.Empty ;
                    txtpassword.Text = string.Empty;
                }
                return usuarioValido;
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

            bienvenida.NombreDesdeLogin = nombre1;
            bienvenida.ApaternoDesdeLogin = apaterno1;

            bienvenida.ShowDialog();
            FrmPrincipal form = new FrmPrincipal();
            

            form.NombreDesdeLogin = nombre1;
            form.ApaternoDesdeLogin = apaterno1;

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

        private void label1_Click(object sender, EventArgs e)
        {
            FrmConexion conexion = new FrmConexion();

            conexion.Show();
        }
    }
}
