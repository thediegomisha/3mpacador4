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
    public partial class frmProductor2 : Form
    {
        public frmProductor2()
        {
            InitializeComponent();
            
        }
               
        private void InsertarProductor()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
               
                comando = new MySqlCommand("usp_tblproductor_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                {
                    if (!String.IsNullOrEmpty(txtRazonSocial.Text))
                    {
                        comando.Parameters.AddWithValue("p_razonsocial", MySqlType.VarChar).Value = this.txtRazonSocial.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Razon Social", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!String.IsNullOrEmpty(txtnombreLugar.Text))
                    {
                        comando.Parameters.AddWithValue("p_region", MySqlType.VarChar).Value = this.txtnombreLugar.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Region correcta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtregion.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombrelugar", MySqlType.VarChar).Value = this.txtregion.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Nombre del Lugar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                        if (!String.IsNullOrEmpty(txtclp .Text))
                        {
                            comando.Parameters.AddWithValue("p_clp", MySqlType.VarChar).Value = this.txtclp.Text;

                            comando.ExecuteNonQuery();
                            MessageBox.Show("CLIENTE REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiarcampos();
                            ConexionGral.desconectar();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Error, Ingrese el Numero de Codigo del Lugar de Produccion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void limpiarcampos()
        {
            try
            {
                txtRazonSocial.Text = String.Empty;
                txtnombreLugar.Text = string.Empty;
                txtregion.Text = string.Empty;
             
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
            InsertarProductor();
        }

        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            
        }
      
        private void activarcamposjuridica()
        {
            txtRazonSocial.Enabled = true;
            txtregion.Enabled = true;
            txtnombreLugar.Enabled = true;
        }
        private void desactivarcamposjuridica()
        {
            txtRazonSocial.Enabled = false;
            txtregion.Enabled = false;
            txtnombreLugar.Enabled = false;
        }

        private void btnBuscarCLP_Click(object sender, EventArgs e)
        {
            //Instancio el Formulario Hijo al Padre
            frmProductorCLP FH = new frmProductorCLP();
            //Indico al Formulario quien es el Propietario
            AddOwnedForm(FH);           
            FH.ShowDialog();
            //FH.txtCLP.Focus();
        }


    }
}
