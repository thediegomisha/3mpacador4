using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmColaborador : Form
    {
        public static bool editar;
        public static Colaborador cl;

        public frmColaborador()
        {
            InitializeComponent();
            MostrarColaborador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var aux = new Colaborador();

            var F = new frmAltaDNI();
            F.CambiarTextoLabel("Ingreso de Colaborador");
            // F.Panel.BackColor = Color.Green;
            F.ShowDialog();
            MostrarColaborador();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarColaborador()
        {
            MySqlCommand comando;
            try
            {
                datalistado.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcolaborador_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Colaborador();
                        c.idcolaborador = Convert.ToInt32(reader["idcolaborador"]);
                        c.dni = reader["dni"].ToString();
                        c.nombres = reader["nombres"].ToString();
                        c.apellidoPaterno = reader["apel_paterno"].ToString();
                        c.apellidoMaterno = reader["apel_materno"].ToString();
                        c.flag_estado = reader["flag_estado"].ToString();
                        datalistado.Rows.Add(null, null, c.idcolaborador, c.dni, c.nombres, c.apellidoPaterno,
                            c.apellidoMaterno, c.flag_estado == "1" ? true : false);
                    }

                    lblnro_reg.Text = datalistado.RowCount.ToString();
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistado.Columns[e.ColumnIndex].Index == 0) //EDITAR
            {
                editar = true;

                cl = new Colaborador();
                cl.idcolaborador = Convert.ToInt32(datalistado.CurrentRow.Cells[2].Value);
                cl.dni = datalistado.CurrentRow.Cells[3].Value.ToString();
                cl.nombres = datalistado.CurrentRow.Cells[4].Value.ToString();
                cl.apellidoPaterno = datalistado.CurrentRow.Cells[5].Value.ToString();
                cl.apellidoMaterno = datalistado.CurrentRow.Cells[6].Value.ToString();
                cl.flag_estado = datalistado.CurrentRow.Cells[7].Value.ToString();

                var f = new frmAltaDNI();
                f.ShowDialog();
                MostrarColaborador();

                editar = false;
            }
            else if (datalistado.Columns[e.ColumnIndex].Index == 1) // ELIMINAR
            {
                var rpta = MessageBox.Show(
                    "¿ ESTA SEGURO DE ELIMINAR AL TRABAJADOR CON DNI " + datalistado.CurrentRow.Cells[3].Value + " ?"
                    , @"Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    MySqlCommand comando;
                    try
                    {
                        if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                        comando = new MySqlCommand("usp_tblcolaborador_delete", ConexionGral.conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("p_id", Convert.ToInt32(datalistado.CurrentRow.Cells[2].Value));
                        comando.ExecuteNonQuery();
                        MessageBox.Show(@"COLABORADOR SE ELIMINO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        ConexionGral.desconectar();
                        MostrarColaborador();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}