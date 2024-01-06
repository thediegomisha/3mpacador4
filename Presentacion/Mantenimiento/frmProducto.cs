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
    public partial class frmProducto: Form
    {
        public frmProducto()
        {
            InitializeComponent();
            mostrarTipoProducto();
            txtTipoCultivo.Focus();
        }
               
        private void InsertartipoProducto()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
               
                comando = new MySqlCommand("usp_tblproducto_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                {
                    if (!String.IsNullOrEmpty(txtTipoCultivo.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar).Value = this.txtTipoCultivo.Text.ToUpper(); ;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Tipo de Producto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                   
                 }
                comando.ExecuteNonQuery();
                MessageBox.Show("TIPO DE PRODUCTO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                mostrarTipoProducto();
                txtTipoCultivo.Text = string.Empty;
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("TIPO DE PRODUCTO NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtTipoCultivo.Text = String.Empty;             
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void mostrarTipoProducto()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblproducto_Select", ConexionGral.conexion);
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
                        datalistado.Columns["idproducto"].Visible = false;
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
            InsertartipoProducto();
        }
    }
}
