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
    public partial class frmCliente2 : Form
    {
        public frmCliente2()
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
            InsertarCliente();
           

        }
     

        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            
        }
      
       

        

    }
}
