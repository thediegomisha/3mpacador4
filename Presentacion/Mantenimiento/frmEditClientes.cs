using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmEditClientes : Form
    {
        public int idClienteedit { get; set; }

        public frmEditClientes()
        {
            InitializeComponent();
            
        }
           
        
        public void CargarDatosCliente(int idCliente)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                MySqlCommand comando = new MySqlCommand("usp_tblcliente_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idCliente", idCliente);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRazonSocial.Text = reader["razon_social"].ToString();
                        txtruc.Text = reader["ruc"].ToString();
                        txtdireccion.Text = reader["direccion"].ToString();
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcliente_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idCliente", idClienteedit);
                comando.Parameters.AddWithValue("p_razon_social", txtRazonSocial.Text);
                comando.Parameters.AddWithValue("p_ruc", txtruc.Text);
                comando.Parameters.AddWithValue("p_direccion", txtdireccion.Text);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            
        }
      
       

        

    }
}
