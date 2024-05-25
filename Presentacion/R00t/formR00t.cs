using _3mpacador4.Logica;
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

namespace _3mpacador4.Presentacion.R00t
{
    public partial class formR00t : Form
    {
            
        private Action onSuccess;
        //   private Action incrementarIntentosErroneos;
        private Action onIncorrectPassword;
        public formR00t(Action onSuccess, Action onIncorrectPassword)
        {
            InitializeComponent();
            this.onSuccess = onSuccess;
            this.onIncorrectPassword = onIncorrectPassword;
        }

        private void cmd_Aceptar_Click(object sender, EventArgs e)
        {
            Acceso_root();
        }

        public int Acceso_root()
        {
            MySqlCommand comando = null;

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                    ConexionGral.conectar();

                comando = new MySqlCommand("usp_acceso_root", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_clave", MySqlType.VarChar).Value = txtclave.Text;

                comando.Parameters.Add("p_resultado", MySqlType.Bit);
                comando.Parameters["p_resultado"].Direction = ParameterDirection.Output;

                comando.ExecuteNonQuery();

                // Ejecutar el comando antes de acceder al parámetro de salida
                // Obtener el valor del parámetro de salida y convertirlo a entero
                int resultado = Convert.ToBoolean(comando.Parameters["p_resultado"].Value) ? 1 : 0;

                if (resultado == 1)
                {
                    onSuccess?.Invoke();
                }
                else
                {
                    MessageBox.Show(@"Contraseña incorrecta, verifique sus credenciales !!!");
                    onIncorrectPassword?.Invoke(); // Incrementar el contador de intentos erróneos
                }
                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Devolver false en caso de una excepción.
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();

                ConexionGral.desconectar();
            }
        }

        private void txtclave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void formR00t_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}

