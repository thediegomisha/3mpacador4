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
    public partial class frmEditProductor : Form
    {
        public int idProductoredit { get; set; }

        public frmEditProductor()
        {
            InitializeComponent();

        }


        public void CargarDatosProductor(int idProductor)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                MySqlCommand comando = new MySqlCommand("usp_tblproductor_Mostrar", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idProductor", idProductor);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRazonSocial.Text = reader["razonsocial"].ToString();
                        txtregion.Text = reader["region"].ToString();
                        txtnombreLugar.Text = reader["nombrelugar"].ToString();
                    }
                }


                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al cargar datos del productor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarcampos()
        {
            try
            {
                txtRazonSocial.Text = String.Empty;
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

                comando = new MySqlCommand("usp_tblproductor_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idProductor", idProductoredit);
                comando.Parameters.AddWithValue("p_razon_social", txtRazonSocial.Text);
                comando.Parameters.AddWithValue("p_region", txtregion.Text);
                comando.Parameters.AddWithValue("p_nombrelugar", txtnombreLugar.Text);


                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Productor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el productor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos del productor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
