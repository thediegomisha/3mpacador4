using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmJabas : Form
    {
        public frmJabas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarJabas();
        }

        private void InsertarJabas()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tbljabas_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var cantjava = float.Parse(txtnumjaba.Text);

                if (cantjava > 0)
                {
                    comando.Parameters.AddWithValue("p_numjabas", MySqlType.Int).Value = cantjava;


                    comando.ExecuteNonQuery();
                    MessageBox.Show(@"JAVA REGISTRADA SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    // limpiarcampos()
                    //    this.chkcapturapeso.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error, La cantidad tiene que ser mayor que 0", @"CANTIDAD JABA");
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
    }
}