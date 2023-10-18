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
    public partial class frmCultivo : Form
    {
        public frmCultivo()
        {
            InitializeComponent();
            mostrarMetodoCultivo();
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
               
                comando = new MySqlCommand("usp_tblmetodocultivo_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                {
                    if (!String.IsNullOrEmpty(txtTipoCultivo.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombre", MySqlType.VarChar).Value = this.txtTipoCultivo.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Tipo de Cultivo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                   
                 }
                comando.ExecuteNonQuery();
                MessageBox.Show("TIPO DE CULTIVO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                mostrarMetodoCultivo();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("TIPO DE CULTIVO NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
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

        public void mostrarMetodoCultivo()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos.Rows.Count != 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        datalistado.Columns["idmetodocultivo"].Visible = false;
                        datalistado.Columns["descripcion"].Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
