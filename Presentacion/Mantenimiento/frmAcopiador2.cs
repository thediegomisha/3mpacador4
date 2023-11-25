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
    public partial class frmAcopiador2 : Form
    {
        public frmAcopiador2()
        {
            InitializeComponent();
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
            InsertarAcopiador();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
