using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmAcopiador : Form
    {
        public frmAcopiador()
        {
            InitializeComponent();
            mostraracopiador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var F = new frmAltaRUC();
            F.CambiarTextoLabel("Ingreso de Acopiadores");
            F.Panel1.BackColor = Color.Green;
            F.ShowDialog();
            mostraracopiador();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void mostraracopiador()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbacopiador_Select", ConexionGral.conexion);
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
    }
}