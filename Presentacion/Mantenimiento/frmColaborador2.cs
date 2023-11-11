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
    public partial class frmColaborador2 : Form
    {
        public frmColaborador2()
        {
            InitializeComponent();
            
        }
               
        private void InsertarColaborador()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblcolaborador_insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                //var comando = new MySqlCommand("INSERT INTO tblcliente (razon_social, ruc, direccion)" + '\r'
                //        + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

                {
                    if (!String.IsNullOrEmpty(txtdni.Text))
                    {
                       comando.Parameters.AddWithValue("p_dni", MySqlType.Text).Value = this.txtdni.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese la Razon Social", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!String.IsNullOrEmpty(txtnombres.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombres", MySqlType.VarChar).Value = this.txtnombres.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtapel_paterno.Text))
                    {
                        comando.Parameters.AddWithValue("p_apel_paterno", MySqlType.VarChar).Value = this.txtapel_paterno.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrEmpty(txtapel_materno.Text))
                    {
                        comando.Parameters.AddWithValue("p_apel_materno", MySqlType.VarChar).Value = this.txtapel_materno.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (!String.IsNullOrEmpty("1"))
                    {
                        comando.Parameters.AddWithValue("p_flag_estado", MySqlType.Text).Value = "1";
                      

                        comando.ExecuteNonQuery();
                        MessageBox.Show("COLABORADOR REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtnombres.Text = String.Empty;
                txtdni.Text = string.Empty;
                txtapel_paterno.Text = string.Empty;
             
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
            InsertarColaborador();
           

        }
     

        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            
        }

        private void cbxestado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxestado.Checked)
            {
                cbxestado.Text = "ACTIVO";
            }
            else
            {
                cbxestado.Text = "INACTIVO";
            }
        }
    }
}
