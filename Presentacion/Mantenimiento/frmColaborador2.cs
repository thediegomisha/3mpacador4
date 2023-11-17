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
using _3mpacador4.Entidad;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmColaborador2 : Form
    {
        public frmColaborador2()
        {
            InitializeComponent();
        }

        int id;

        string Estado() {
            string estado = "";

            if (cbxestado.Checked)
            {
                estado = "1";
            }
            else
            {
                estado = "0";
            }

        return estado;
        }
               
        private void InsertarColaborador()
        {
            try
            {
                if (txtdni.Text.Length < 8 )
                {
                    MessageBox.Show("Error, Ingrese DNI Valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdni.Focus();
                    return;
                }

                if (txtnombres.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Nombres del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombres.Focus();
                    return;
                }

                if (txtapel_paterno.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Apellido Paterno del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtapel_paterno.Focus();
                    return;
                }

                if (txtapel_materno.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Apellido Materno del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtapel_materno.Focus();
                    return;
                }

                var aux = new Colaborador();
                aux.dni = txtdni.Text.Trim();
                aux.nombres = txtnombres.Text.Trim();
                aux.apel_paterno = txtapel_paterno.Text.Trim();
                aux.apel_materno = txtapel_materno.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblcolaborador_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_dni", aux.dni);
                comando.Parameters.AddWithValue("p_nombres", aux.nombres);
                comando.Parameters.AddWithValue("p_apel_paterno", aux.apel_paterno);
                comando.Parameters.AddWithValue("p_apel_materno", aux.apel_materno);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show("COLABORADOR REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarcampos();
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
            }
        }
        private void ActualizarColaborador()
        {
            try
            {
                if (txtdni.Text.Length < 8)
                {
                    MessageBox.Show("Error, Ingrese DNI Valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtdni.Focus();
                    return;
                }

                if (txtnombres.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Nombres del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnombres.Focus();
                    return;
                }

                if (txtapel_paterno.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Apellido Paterno del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtapel_paterno.Focus();
                    return;
                }

                if (txtapel_materno.Text.Length <= 0)
                {
                    MessageBox.Show("Error, Ingrese Apellido Materno del Colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtapel_materno.Focus();
                    return;
                }

                var aux = new Colaborador();
                aux.idcolaborador = id;
                aux.dni = txtdni.Text.Trim();
                aux.nombres = txtnombres.Text.Trim();
                aux.apel_paterno = txtapel_paterno.Text.Trim();
                aux.apel_materno = txtapel_materno.Text.Trim();
                aux.flag_estado = Estado();


                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblcolaborador_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_id", aux.idcolaborador);
                comando.Parameters.AddWithValue("p_dni", aux.dni);
                comando.Parameters.AddWithValue("p_nombres", aux.nombres);
                comando.Parameters.AddWithValue("p_apel_paterno", aux.apel_paterno);
                comando.Parameters.AddWithValue("p_apel_materno", aux.apel_materno);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show("COLABORADOR ACTUALIZADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarcampos();
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void limpiarcampos()
        {
            try
            {
                txtdni.Text = string.Empty;
                txtnombres.Text = string.Empty;               
                txtapel_paterno.Text = string.Empty;
                txtapel_materno.Text = string.Empty;
                cbxestado.Checked = false;
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
            if (cbxestado.Checked)
            {
                cbxestado.Text = "ACTIVO";
            }
            else
            {
                cbxestado.Text = "INACTIVO";
            }

            if (frmColaborador.editar)
            {
                if (frmColaborador.cl.idcolaborador > 0)
                {
                    id = frmColaborador.cl.idcolaborador;
                    txtdni.Text = frmColaborador.cl.dni;
                    txtnombres.Text = frmColaborador.cl.nombres;
                    txtapel_paterno.Text = frmColaborador.cl.apel_paterno;
                    txtapel_materno.Text = frmColaborador.cl.apel_materno;
                    if (Convert.ToBoolean(frmColaborador.cl.flag_estado))
                    {
                        cbxestado.Checked = true;
                    }
                    else
                    {
                        cbxestado.Checked = false;
                    }
                }
            }
            
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarColaborador();
        }
    }
}
