using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FTraslado_trabajador : Form
    {
        public static List<Lista_transferir_trab> lista_datos;
        public static bool estado_transferencia;

        private Lista_transferir_trab d;

        public FTraslado_trabajador()
        {
            InitializeComponent();
            ListaTrabajadores();
        }

        public void ListaTrabajadores()
        {
            MySqlCommand comando = null;
            try
            {
                dgvlista1.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcolaborador_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Colaborador();
                        c.dni = reader["dni"].ToString();
                        c.nombres = reader["nombres"].ToString();
                        c.apellidoPaterno = reader["apel_paterno"].ToString();
                        c.apellidoMaterno = reader["apel_materno"].ToString();
                        dgvlista1.Rows.Add(c.dni, c.nombres + " " + c.apellidoPaterno + " " + c.apellidoMaterno, false);
                    }

                    lblnrotrab1.Text = dgvlista1.RowCount.ToString();
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FTraslado_trabajador_Load(object sender, EventArgs e)
        {
            lblidgrupo.Text = FJornalTurno.li_idgrupo.ToString();
            lblgrupo.Text = FJornalTurno.ls_grupo_desc;
            estado_transferencia = false;
        }

        private void Buscar_dni(string ls_dni)
        {
            foreach (DataGridViewRow fila in dgvlista1.Rows)
            foreach (DataGridViewCell celda in fila.Cells)
                if (celda.Value != null && celda.Value.ToString() == ls_dni)
                {
                    fila.Cells[2].Value = true;
                    tbxfildni.Clear();
                    tbxfildni.Focus();
                    return;
                }
        }

        private void tbxfildni_TextChanged(object sender, EventArgs e)
        {
            if (tbxfildni.Text.Length >= 8 && tbxfildni.Text.Length <= 10) Buscar_dni(tbxfildni.Text.Trim());
        }

        private void btnpasar_Click(object sender, EventArgs e)
        {
            if (dgvlista1.RowCount > 0)
            {
                for (var i = 0; i < dgvlista1.RowCount; i++)
                    if (Convert.ToBoolean(dgvlista1.Rows[i].Cells[2].Value))
                        /*if (dgvlista2.RowCount > 0)
                        {
                            if (dgvlista1.CurrentRow.Cells[0].Value.ToString() == dgvlista2.CurrentRow.Cells[0].Value.ToString())
                            {
                                MessageBox.Show("EL DNI " + dgvlista2.CurrentRow.Cells[0].Value.ToString() + " YA EXISTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }  */
                        dgvlista2.Rows.Add(dgvlista1.Rows[i].Cells[0].Value.ToString(),
                            dgvlista1.Rows[i].Cells[1].Value.ToString());
                lblnrotrab2.Text = dgvlista2.RowCount.ToString();
            }
        }

        private void btntrasladar_Click(object sender, EventArgs e)
        {
            lista_datos = new List<Lista_transferir_trab>();
            foreach (DataGridViewRow f in dgvlista2.Rows)
            {
                d = new Lista_transferir_trab();
                d.dni = f.Cells[0].Value.ToString();
                d.trabajador = f.Cells[1].Value.ToString();
                lista_datos.Add(d);
            }

            estado_transferencia = true;
            Close();
        }
    }
}