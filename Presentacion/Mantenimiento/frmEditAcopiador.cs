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
    public partial class frmEditAcopiador : Form
    {
        public int idAcopiadoredit { get; set; }
        public frmEditAcopiador()
        {
            InitializeComponent();
        }


        public void CargarDatosProductor(int idAcopiador)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                MySqlCommand comando = new MySqlCommand("usp_tblacopiador_Mostrar", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idacopiador", idAcopiador);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtRazonSocial.Text = reader["razonsocial"].ToString();
                        txtruc.Text = reader["ruc"].ToString();
                        txtdireccion.Text = reader["direccion"].ToString();
                    }
                }


                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al cargar datos del productor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void InsertarAcopiador()
        //{
        //    try
        //    {
        //        if (ConexionGral.conexion.State == ConnectionState.Closed)
        //        {
        //            ConexionGral.conectar();
        //        }
        //        var comando = new MySqlCommand("INSERT INTO tblacopiador (razonsocial, ruc, direccion)" + '\r'
        //                + "VALUES(@razonsocial, @ruc, @direccion)", ConexionGral.conexion);

        //        {
        //            if (!String.IsNullOrEmpty(txtRazonSocial.Text))
        //            {
        //                comando.Parameters.AddWithValue("@razonsocial", MySqlType.Text).Value = this.txtRazonSocial.Text;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error, Ingrese la Razon Social correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }


        //            if (!String.IsNullOrEmpty(txtruc.Text))
        //            {
        //                comando.Parameters.AddWithValue("@ruc", MySqlType.VarChar).Value = this.txtruc.Text;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            if (!String.IsNullOrEmpty(txtdireccion.Text))
        //            {
        //                comando.Parameters.AddWithValue("@direccion", MySqlType.Text).Value = this.txtdireccion.Text;

        //                comando.ExecuteNonQuery();
        //                MessageBox.Show("ACOPIADOR REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                limpiarcampos();                       
        //                ConexionGral.desconectar();
        //                return;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error, Ingrese el Numero de RUC", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("ACOPIADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            throw;
        //    }
        //}

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
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblacopiador_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idProductor", idAcopiadoredit);
                comando.Parameters.AddWithValue("p_razon_social", txtRazonSocial.Text);
                comando.Parameters.AddWithValue("p_ruc", txtruc.Text);
                comando.Parameters.AddWithValue("p_direccion", txtdireccion.Text);


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
