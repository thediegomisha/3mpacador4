using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
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

                    String fechaaño =  Settings.Default.periodo.ToString();
                    String[] partes = fechaaño.Split(' ')[0].Split('/');
                    String año = partes[2];
                    comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Text).Value = año;


                    comando.ExecuteNonQuery();

                    MessageBox.Show(@"LOTE REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    mostrarUltimoRegistro();
                    // limpiarcampos()
                    //    this.chkcapturapeso.Checked = false;
                }
                else
                {
                    MessageBox.Show(@"Error, La cantidad tiene que ser mayor que 0", @"CANTIDAD LOTE");
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
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_last_reg", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.VarChar).Value = año;


                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        //  var dr = datos.NewRow();
                        txtnumlote.Text = datos.Rows[0]["siguienteRegistro"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Construye un mensaje detallado incluyendo el tipo de excepción y la pila de llamadas.
                string errorMessage = $"Se ha producido un error: {ex.GetType().Name}\n\n";
                errorMessage += $"Mensaje de error: {ex.Message}\n\n";
                errorMessage += $"Detalles del error:\n{ex.StackTrace}";

                // Muestra el mensaje detallado en el cuadro de diálogo.
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}