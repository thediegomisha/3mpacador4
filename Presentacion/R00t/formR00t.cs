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
        public formR00t()
        {
            InitializeComponent();
        }

        private void cmd_Aceptar_Click(object sender, EventArgs e)
        {
            Acceso_root();
        }

        private int Acceso_root()
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
                    //if ( == "Ingreso de Usuarios")
                    //{
                        frmroot();
                    //}
                  
                }
                else
                {
                    MessageBox.Show(@"Contraseña incorrecta, se reportará al Administrador !!!");
                    // Borrar los campos de entrada debería manejarse en el nivel de interfaz de usuario
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

        private void frmroot()
        {
            FrmMod root = new FrmMod();
            root.ShowDialog();
            this.Close();
        }

    }
}

