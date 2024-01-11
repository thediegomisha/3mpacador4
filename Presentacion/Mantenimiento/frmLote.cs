using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmLote : Form
    {
        public frmLote()
        {
            InitializeComponent();
            mostrarUltimoRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarLote();
        }

        private void InsertarLote()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tbllote_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var cantlote = float.Parse(txtnumlote.Text);
                if (cantlote > 0)
                {
                    comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cantlote;

                    comando.ExecuteNonQuery();

                    MessageBox.Show(@"LOTE REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    mostrarUltimoRegistro();
                    // limpiarcampos()
                    //    this.chkcapturapeso.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error, La cantidad tiene que ser mayor que 0", @"CANTIDAD LOTE");
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

        private void mostrarUltimoRegistro()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_last_reg", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        txtnumlote.Text = datos.Rows[0]["siguienteregistro"].ToString();
                    }
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