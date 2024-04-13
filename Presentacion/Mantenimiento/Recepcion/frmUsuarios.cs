using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmUsuarios : Form
    {
        private byte[] imagenByte;

        public frmUsuarios()
        {
            InitializeComponent();
          //  mostrarUsuarios();
            mostrarTipoUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            var aux = new Colaborador();

            var F = new frmAltaDNI();
            F.CambiarTextoLabel("Ingreso de Usuarios", "VALIDAR DATOS");

            // Suscribirte al evento DatosEnviados de frmAltaDNI
            F.DatosEnviados += (s, datos) =>
            {
                // Manejar los datos recibidos

                if (datos.ContainsKey("txtdni"))
                {
                    string contenidoForm2 = datos["txtdni"];
                    txtdni.Text = contenidoForm2;
                }
                if (datos.ContainsKey("txtnombres"))
                {
                    string contenidoForm2 = datos["txtnombres"];
                    txtnombres.Text = contenidoForm2.ToLower();
                    txtnombres.Text = CapitalizarPrimeraLetra(txtnombres.Text);
                   
                }
                if (datos.ContainsKey("txtapellidop"))
                {
                    string contenidoForm2 = datos["txtapellidop"];
                    txtAPaterno.Text = contenidoForm2.ToLower();
                    txtAPaterno.Text = CapitalizarPrimeraLetra(txtAPaterno.Text);
                }

                if (datos.ContainsKey("txtapellidom"))
                {
                    string contenidoForm2 = datos["txtapellidom"];
                    txtAMaterno.Text = contenidoForm2.ToLower();
                    txtAMaterno.Text = CapitalizarPrimeraLetra(txtAMaterno.Text);
                }
                // Puedes agregar más comprobaciones para otros TextBox
            };

            F.ShowDialog();
            // MostrarColaborador();
        }

        static string CapitalizarPrimeraLetra(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Convertir la primera letra a mayúscula
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        //public void mostrarUsuarios()
        //{
        //    MySqlCommand comando = null;
        //    try
        //    {
        //        if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

        //        comando = new MySqlCommand("usp_tblusuarios_Select1", ConexionGral.conexion);
        //        comando.CommandType = (CommandType)4;

        //        var adaptador = new MySqlDataAdapter(comando);
        //        var datos = new DataTable();
        //        adaptador.Fill(datos);

        //        {
        //            var withBlock = datalistado;
        //            if (datos != null && datos.Rows.Count > 0)
        //            {
        //                var dr = datos.NewRow();
        //                withBlock.DataSource = datos;
        //            }
        //            else
        //            {
        //                withBlock.DataSource = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        ConexionGral.desconectar();
        //    }
        //}
        private void mostrarTipoUsuario()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbltipoUsuario_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbusuario;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idtipousuario"] = 0;
                        dr["nombretipo"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombretipo";
                        withBlock.ValueMember = "idtipousuario";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectorImagen = new OpenFileDialog();
            SelectorImagen.Title = "Seleccionar Imagen";

            if (SelectorImagen.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromStream(SelectorImagen.OpenFile());
                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);
                imagenByte = memoria.ToArray();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InsertarUsuario();
        }

        private void InsertarUsuario()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblusuario_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                {
                    if (!string.IsNullOrEmpty(txtdni.Text))
                    {
                        comando.Parameters.AddWithValue("p_dni", MySqlType.Text).Value = txtdni.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese Numero de DNI", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtnombres.Text))
                    {
                        comando.Parameters.AddWithValue("p_nombres", MySqlType.VarChar).Value = txtnombres.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Nombre", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtAPaterno.Text))
                    {
                        comando.Parameters.AddWithValue("p_apaterno", MySqlType.Text).Value = txtAPaterno.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Apellido Paterno", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    if (!string.IsNullOrEmpty(txtAMaterno.Text))
                    {
                        comando.Parameters.AddWithValue("p_amaterno", MySqlType.Text).Value = txtAMaterno.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Apellido Materno", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(txtLogin.Text))
                    {
                        comando.Parameters.AddWithValue("p_login", MySqlType.Text).Value = txtLogin.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Login de Usuario", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(cbusuario.Text))
                    {
                        if (cbusuario.SelectedValue != null)
                        {
                            string cbuser = cbusuario.SelectedValue.ToString();

                            comando.Parameters.AddWithValue("p_tipousuario",cbuser);
                        }
                        else
                        {
                            MessageBox.Show(@"Error, Seleccione un Tipo de Usuario válido", @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Ingrese el Tipo de Usuario", @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(txtclave1.Text))
                    {
                        comando.Parameters.AddWithValue("p_clave", MySqlType.Text).Value = txtclave1.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, Error en comprobacion de Contraseña", @"Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }


                    comando.ExecuteNonQuery();
                    MessageBox.Show(@"USUARIO REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                //    mostrarUsuarios();

                    if (MessageBox.Show(@"Desea ingresar otro Usuario?", @"Atención", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) Close();
                    // limpiarcampos();

                    ConexionGral.desconectar();
                    return;
                }

                MessageBox.Show(@"Error, Ingrese el Numero de DNI", @"Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("USUARIO NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void cbusuario_DropDownClosed(object sender, EventArgs e)
        {
         //   label8.Text = 
        }
    }
}
