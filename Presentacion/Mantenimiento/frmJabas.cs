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
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarJabas();
        }

        private void InsertarJabas()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tbljabas_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                float cantjava = float.Parse(txtnumjaba .Text);

                if (cantjava > 0)
                {
                    comando.Parameters.AddWithValue("p_numjabas", MySqlType.Int).Value = cantjava;
               

                comando.ExecuteNonQuery();
                MessageBox.Show("JAVA REGISTRADA SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    // limpiarcampos()
                    //    this.chkcapturapeso.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error, La cantidad tiene que ser mayor que 0", "CANTIDAD JABA");
                    return;
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
    }
}
