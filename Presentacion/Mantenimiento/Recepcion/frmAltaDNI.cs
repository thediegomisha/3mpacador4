using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
using _3mpacador4.Presentacion.Trazabilidad;
using Devart.Data.MySql;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmAltaDNI : Form
    {
        private int id;
        public event EventHandler<Dictionary<string, string>> DatosEnviados;

        public frmAltaDNI()
        {
            InitializeComponent();
        }

        private string Estado()
        {
            var estado = "";

            if (cbxestado.Checked)
                estado = "1";
            else
                estado = "0";

            return estado;
        }

        private void InsertarColaborador()
        {
            try
            {
                if (txtdni.Text.Length < 8)
                {
                    MessageBox.Show(@"Error, Ingrese DNI Valido", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdni.Focus();
                    return;
                }

                if (txtnombres.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Nombres del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtnombres.Focus();
                    return;
                }

                if (txtapel_paterno.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Apellido Paterno del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtapel_paterno.Focus();
                    return;
                }

                if (txtapel_materno.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Apellido Materno del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtapel_materno.Focus();
                    return;
                }

                var aux = new Colaborador();
                aux.dni = txtdni.Text.Trim();
                aux.nombres = txtnombres.Text.Trim();
                aux.apellidoPaterno = txtapel_paterno.Text.Trim();
                aux.apellidoMaterno = txtapel_materno.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblcolaborador_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_dni", aux.dni);
                comando.Parameters.AddWithValue("p_nombres", aux.nombres);
                comando.Parameters.AddWithValue("p_apel_paterno", aux.apellidoPaterno);
                comando.Parameters.AddWithValue("p_apel_materno", aux.apellidoMaterno);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"COLABORADOR REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                if (MessageBox.Show(@"Desea ingresar otro Colaborador?", @"Mensaje", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) Close();
                LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

     

        private void ActualizarColaborador()
        {
            try
            {
                if (txtdni.Text.Length < 8)
                {
                    MessageBox.Show(@"Error, Ingrese DNI Valido", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdni.Focus();
                    return;
                }

                if (txtnombres.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Nombres del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtnombres.Focus();
                    return;
                }

                if (txtapel_paterno.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Apellido Paterno del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtapel_paterno.Focus();
                    return;
                }

                if (txtapel_materno.Text.Length <= 0)
                {
                    MessageBox.Show(@"Error, Ingrese Apellido Materno del Colaborador", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtapel_materno.Focus();
                    return;
                }

                var aux = new Colaborador();
                aux.idcolaborador = id;
                aux.dni = txtdni.Text.Trim();
                aux.nombres = txtnombres.Text.Trim();
                aux.apellidoPaterno = txtapel_paterno.Text.Trim();
                aux.apellidoMaterno = txtapel_materno.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblcolaborador_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_id", aux.idcolaborador);
                comando.Parameters.AddWithValue("p_dni", aux.dni);
                comando.Parameters.AddWithValue("p_nombres", aux.nombres);
                comando.Parameters.AddWithValue("p_apel_paterno", aux.apellidoPaterno);
                comando.Parameters.AddWithValue("p_apel_materno", aux.apellidoMaterno);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"COLABORADOR ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void LimpiarCampos()
        {
            try
            {
                txtdni.Focus();
                txtdni.Text = string.Empty;
                txtnombres.Text = string.Empty;
                txtapel_paterno.Text = string.Empty;
                txtapel_materno.Text = string.Empty;
                //cbxestado.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Algo Salio Mal LimpiarCampos() :( ");
                throw;
            }
        }

        public void CambiarTextoLabel(string nuevoTexto, string nuevotexto2)
        {
            lbltitulo.Text = nuevoTexto;
            btnGuardar.Text = nuevotexto2;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lbltitulo.Text == "Ingreso de Usuarios")
            {
                //         InsertarUsuario();
                enviardatos();
            }
            else if (lbltitulo.Text == "Ingreso de Colaborador")
            {
                InsertarColaborador();
            }           
        }
     
        public void enviardatos()
        {
            try
            {

                // Crear un diccionario para almacenar los datos de los TextBox
                Dictionary<string, string> datos = new Dictionary<string, string>();
                datos.Add("txtdni", txtdni.Text);
                datos.Add("txtnombres", txtnombres.Text);
                datos.Add("txtapellidop", txtapel_paterno.Text);
                datos.Add("txtapellidom", txtapel_materno.Text);

                // Verificar si hay suscriptores al evento antes de activarlo
                DatosEnviados?.Invoke(this, datos);

                // Cerrar el formulario actual después de enviar los datos
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void frmPersonaJuridica_Load(object sender, EventArgs e)
        {
            txtdni.Focus();
            if (cbxestado.Checked)
                cbxestado.Text = "ACTIVO";
            else
                cbxestado.Text = "INACTIVO";

            if (frmColaborador.editar)
            {
                if (frmColaborador.cl.idcolaborador > 0)
                {
                    id = frmColaborador.cl.idcolaborador;
                    txtdni.Text = frmColaborador.cl.dni;
                    txtnombres.Text = frmColaborador.cl.nombres;
                    txtapel_paterno.Text = frmColaborador.cl.apellidoPaterno;
                    txtapel_materno.Text = frmColaborador.cl.apellidoMaterno;
                    if (Convert.ToBoolean(frmColaborador.cl.flag_estado))
                        cbxestado.Checked = true;
                    else
                        cbxestado.Checked = false;
                }
            }
            else if (FTraslado_trabajador.buscar_dni)
            {
                txtdni.Text = FTraslado_trabajador.ls_nro_dni;
            }

        }

        private void cbxestado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxestado.Checked)
                cbxestado.Text = "ACTIVO";
            else
                cbxestado.Text = "INACTIVO";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarColaborador();
            Close();
        }

        private void cbxreniec_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxreniec.Checked)
            {
                pbreniec.Image = Resources.reniec;
                LimpiarCampos();
            }
            else
            {
                pbreniec.Image = Resources.cargando;
                LimpiarCampos();
            }
        }

        private async void txtdni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxreniec.Checked)
                    if (txtdni.Text.Trim().Length == 8)
                    {
                        var respuesta = await ConsultaDNI(txtdni.Text.Trim());

                        var obj = JsonConvert.DeserializeObject<Colaborador>(respuesta);

                        txtdni.Text = obj.dni;
                        txtnombres.Text = obj.nombres;
                        txtapel_paterno.Text = obj.apellidoPaterno;
                        txtapel_materno.Text = obj.apellidoMaterno;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Algo Salio Mal ConsultaDNI() :( ");
                throw;
            }
        }

        public async Task<string> ConsultaDNI(string ls_dni)
        {
            var url = "https://dniruc.apisperu.com/api/v1/dni/" + ls_dni +
                      "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InBhYmxvamMzMDA1QGdtYWlsLmNvbSJ9.ZuknLPwsDIINQaL0YfoOdXvtUouYB4dnhm4469HsMnM";
            var oRequest = WebRequest.Create(url);
            var oResponse = oRequest.GetResponse();
            var sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}