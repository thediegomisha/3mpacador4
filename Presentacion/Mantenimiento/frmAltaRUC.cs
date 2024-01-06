using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblcliente_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                //var comando = new MySqlCommand("INSERT INTO tblcliente (razon_social, ruc, direccion)" + '\r'
                //        + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

                {
                    if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                       comando.Parameters.AddWithValue("p_razon_social", MySqlType.Text).Value = this.txtRazonSocial.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Razon Social", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!String.IsNullOrEmpty(txtruc.Text))
                    {
                        comando.Parameters.AddWithValue("p_ruc", MySqlType.VarChar).Value = this.txtruc.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtdireccion.Text))
                    {
                        comando.Parameters.AddWithValue("p_direccion", MySqlType.Text).Value = this.txtdireccion.Text;
                      

                        comando.ExecuteNonQuery();
                        MessageBox.Show("CLIENTE REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show(@"Desea ingresar otro Cliente?", @"Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            this.Close();
                        }
                        limpiarcampos();
                       
                        ConexionGral.desconectar();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                        
                            

                    }

                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("CLIENTE NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
            }
        }

        private void InsertarAcopiador()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                var comando = new MySqlCommand("INSERT INTO tblacopiador (razonsocial, ruc, direccion)" + '\r'
                        + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

                {
                    if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                        comando.Parameters.AddWithValue("@razonsocial", MySqlType.Text).Value = this.txtRazonSocial.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Razon Social correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!String.IsNullOrEmpty(txtruc.Text))
                    {
                        comando.Parameters.AddWithValue("@ruc", MySqlType.VarChar).Value = this.txtruc.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtdireccion.Text))
                    {
                        comando.Parameters.AddWithValue("@direccion", MySqlType.Text).Value = this.txtdireccion.Text;

                        comando.ExecuteNonQuery();
                        MessageBox.Show("ACOPIADOR REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarcampos();
                        ConexionGral.desconectar();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ACOPIADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void limpiarcampos()
        {
            try
            {
                txtRazonSocial.Text = String.Empty;
                txtruc.Text = string.Empty;
                txtdireccion.Text = string.Empty;
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbltitulo.Text == "Ingreso de Clientes")
                {
                    InsertarCliente();
                }
                else if (lbltitulo.Text == "Ingreso de Acopiadores")
                {
                    InsertarAcopiador();
                }
                
            }
            catch (Exception)
            {

                throw;
            }
           

        }
     

        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            
        }

        public void CambiarTextoLabel(string nuevoTexto)
        {
            lbltitulo .Text = nuevoTexto;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            // Llama al método para cambiar el título cuando sea necesario
        //    FormUtils.CambiarTextoLabel(lbltitulo, "Nuevo Texto");
        }

        private async void txtruc_TextChanged(object sender, EventArgs e)
        {
           
                if ( txtruc.Text.Trim().Length != 11) return;

                try
                {
                    string respuesta = await ConsultaDNI(txtruc.Text.Trim());
                    var sunat = JsonConvert.DeserializeObject<Sunat>(respuesta);

                    txtruc.Text = sunat.ruc;
                    txtRazonSocial.Text = sunat.razonSocial;
                    txtdireccion.Text = sunat.direccion;                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Algo salió mal en la consulta(): {ex.Message}", "Error");
                }
            }

        public async Task<string> ConsultaDNI(string ls_ruc)
        {
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InBhYmxvamMzMDA1QGdtYWlsLmNvbSJ9.ZuknLPwsDIINQaL0YfoOdXvtUouYB4dnhm4469HsMnM";
            string url = $"https://dniruc.apisperu.com/api/v1/ruc/{ls_ruc}?token={token}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }



    }
}
