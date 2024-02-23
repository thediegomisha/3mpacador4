using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Newtonsoft.Json;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmAltaRUC : Form
    {
        public frmAltaRUC()
        {
            InitializeComponent();
        }

        private void InsertarCliente()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblcliente_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                //var comando = new MySqlCommand("INSERT INTO tblcliente (razon_social, ruc, direccion)" + '\r'
                //        + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

                {
                    if (!string.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                        comando.Parameters.AddWithValue("p_razon_social", MySqlType.Text).Value = txtRazonSocial.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese la Razon Social", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }


                    if (!string.IsNullOrEmpty(txtruc.Text))
                    {
                        comando.Parameters.AddWithValue("p_ruc", MySqlType.VarChar).Value = txtruc.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Numero de RUC", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtdireccion.Text))
                    {
                        comando.Parameters.AddWithValue("p_direccion", MySqlType.Text).Value = txtdireccion.Text;


                        comando.ExecuteNonQuery();
                        MessageBox.Show(@"CLIENTE REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        if (MessageBox.Show(@"Desea ingresar otro Cliente?", @"Atención", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No) Close();
                        limpiarcampos();

                        ConexionGral.desconectar();
                        return;
                    }

                    MessageBox.Show(@"Error, Ingrese el Numero de RUC", @"Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("CLIENTE NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void InsertarAcopiador()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                var comando = new MySqlCommand("INSERT INTO tblacopiador (razonsocial, ruc, direccion)" + '\r'
                    + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

                {
                    if (!string.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                        comando.Parameters.AddWithValue("@razonsocial", MySqlType.Text).Value = txtRazonSocial.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese la Razon Social correctamente", @"Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!string.IsNullOrEmpty(txtruc.Text))
                    {
                        comando.Parameters.AddWithValue("@ruc", MySqlType.VarChar).Value = txtruc.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Numero de RUC", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtdireccion.Text))
                    {
                        comando.Parameters.AddWithValue("@direccion", MySqlType.Text).Value = txtdireccion.Text;

                        comando.ExecuteNonQuery();
                        MessageBox.Show(@"ACOPIADOR REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        limpiarcampos();
                        ConexionGral.desconectar();
                        return;
                    }

                    MessageBox.Show(@"Error, Ingrese el Numero de RUC", @"Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ACOPIADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void limpiarcampos()
        {
            txtRazonSocial.Text = string.Empty;
            txtruc.Text = string.Empty;
            txtdireccion.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lbltitulo.Text == "Ingreso de Usuarios")
                InsertarCliente();
            else if (lbltitulo.Text == "Ingreso de Acopiadores") InsertarAcopiador();
        }


        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
        }

        public void CambiarTextoLabel(string nuevoTexto)
        {
            lbltitulo.Text = nuevoTexto;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Llama al método para cambiar el título cuando sea necesario
            //    FormUtils.CambiarTextoLabel(lbltitulo, "Nuevo Texto");
        }

        private async void txtruc_TextChanged(object sender, EventArgs e)
        {
            if (txtruc.Text.Trim().Length != 11) return;

            try
            {
                var respuesta = await ConsultaDNI(txtruc.Text.Trim());
                var sunat = JsonConvert.DeserializeObject<Sunat>(respuesta);

                txtruc.Text = sunat.ruc;
                txtRazonSocial.Text = sunat.razonSocial;
                txtdireccion.Text = sunat.direccion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Algo salió mal en la consulta(): {ex.Message}", @"Error");
            }
        }

        public async Task<string> ConsultaDNI(string ls_ruc)
        {
            var token =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InBhYmxvamMzMDA1QGdtYWlsLmNvbSJ9.ZuknLPwsDIINQaL0YfoOdXvtUouYB4dnhm4469HsMnM";
            var url = $"https://dniruc.apisperu.com/api/v1/ruc/{ls_ruc}?token={token}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}