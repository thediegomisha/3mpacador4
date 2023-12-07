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
    public partial class frmMatCosecha: Form
    {
        public frmMatCosecha()
        {
            InitializeComponent();
            mostrarMatCosecha();
        }
               
        private void InsertarMetodoCultivo()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
               
                comando = new MySqlCommand("usp_tblmatcosecha_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                {
                    if (!String.IsNullOrEmpty(txtMatCosecha.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar).Value = this.txtMatCosecha.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Material de Cosecha", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                   
                 }
                comando.ExecuteNonQuery();
                MessageBox.Show("MATERIAL DE COSECHA REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                mostrarMatCosecha();
               // ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MATERIAL DE COSECHA NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void limpiarcampos()
        {
            try
            {
                txtMatCosecha.Text = String.Empty;             
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void mostrarMatCosecha()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblmatcosecha_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        datalistado.Columns["idmatcosecha"].Visible = false;
                        datalistado.Columns["descripcion"].Visible = false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarMetodoCultivo();
        }
    }
}
