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
    public partial class frmUsuarios2 : Form
    {
        public frmUsuarios2()
        {
            InitializeComponent();
        }
               
        private void InsertarUsuarios()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                var comando = new MySqlCommand("INSERT INTO tblusuarios (nombres, apaterno, amaterno, dni, telefono, login, clave, nivel)" + '\r'
                        + "VALUES(@nombres, @apaterno, @amaterno, @dni, @telefono, @login, @clave, @nivel)", ConexionGral.conexion);

                {
                    //NOMBRES
                    if (!String.IsNullOrEmpty(txtNombres.Text))
                    {
                        comando.Parameters.AddWithValue("@nombres", MySqlType.Text).Value = this.txtNombres.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese los nombres correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //aPATERNO
                    if (!String.IsNullOrEmpty(txtaPaterno.Text))
                    {
                        comando.Parameters.AddWithValue("@apaterno", MySqlType.VarChar).Value = this.txtaPaterno.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese su apellido paterno", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //aMATERNO
                    if (!String.IsNullOrEmpty(txtaMaterno.Text))
                    {
                        comando.Parameters.AddWithValue("@amaterno", MySqlType.VarChar).Value = this.txtaMaterno.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese su apellido materno", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //DNI
                    if (!String.IsNullOrEmpty(txtDni.Text))
                    {
                        comando.Parameters.AddWithValue("@dni", MySqlType.VarChar).Value = this.txtDni.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese el número de su DNI", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //TELEFONO
                    if (!String.IsNullOrEmpty(txtTelefono.Text))
                    {
                        comando.Parameters.AddWithValue("@telefono", MySqlType.VarChar).Value = this.txtTelefono.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese su teléfono", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //LOGIN
                    if (!String.IsNullOrEmpty(txtLogin.Text))
                    {
                        comando.Parameters.AddWithValue("@login", MySqlType.VarChar).Value = this.txtLogin.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese su Login(Usuario)", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //CLAVE
                    if (!String.IsNullOrEmpty(txtClave.Text))
                    {
                        comando.Parameters.AddWithValue("@clave", MySqlType.VarChar).Value = this.txtClave.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, Ingrese su Contraseña", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // NIVEL
                    if (int.TryParse(txtNivel.Text, out int nivel))
                    {
                        comando.Parameters.AddWithValue("@nivel", MySqlType.Int).Value = nivel;
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@nivel", MySqlType.Int).Value = DBNull.Value;
                    }

                    comando.ExecuteNonQuery();
                    MessageBox.Show("USUARIO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarcampos();
                    ConexionGral.desconectar();
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("USUARIO NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
            }
        }

        private void limpiarcampos()
        {
            try
            {
                txtNombres.Text = String.Empty;
                txtaPaterno.Text = string.Empty;
                txtaMaterno.Text = "";
                txtDni.Text = "";
                txtTelefono.Text = "";
                txtLogin.Text = "";
                txtClave.Text = "";
                txtAcceso.Text = "";
                txtNivel.Text = "";
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
            InsertarUsuarios();
        }



    }
}
