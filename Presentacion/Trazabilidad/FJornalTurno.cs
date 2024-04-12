using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FJornalTurno : Form
    {
        public FJornalTurno()
        {
            InitializeComponent();
        }

        public static int li_idgrupo = 0;
        public static string ls_grupo_desc = "", ls_dni = "", ls_trabajador = "";
        public static bool editar = false;

        string Flag_tercero()
        {
            string flag_tercero = "";
            if (cbflag_tercero.Checked)
            {
                flag_tercero = "1";
            }
            else
            {
                flag_tercero = "0";
            }
            return flag_tercero;
        }

        void Cargar_turno()
        {
            MySqlCommand comando = null;
            try
            {
                cbturno.Items.Clear();
                cbturno.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblturno_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbturno.Items.Add(reader["idturno"].ToString() + " - " + reader["nombre"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cbturno.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal :( ");
                throw;
            }
        }

        void Lista_Grupo_turno(string ls_fecha_produccion)
        {
            dgvgrupo_turno_cab.Rows.Clear();
            var Lista = LGrupo_turno.Lista_grupo_turno(ls_fecha_produccion);
            foreach (var f in Lista)
            {
                dgvgrupo_turno_cab.Rows.Add(null, null, f.idgrupo, f.descripcion, f.idusuario, f.nom_usuario, f.idturno, f.nom_turno,
                                            f.fecha_produccion.ToShortDateString(), f.fecha_inicio.ToString("dd/MM/yyyy HH:mm"), f.fecha_fin.ToString("dd/MM/yyyy HH:mm"), f.flag_tercero == "1" ? true : false,
                                            f.flag_estado == "1" ? true : false);
            }
        }

        void Lista_Grupo_turno_det(int li_idgrupo)
        {
            dgvlista_trab.Rows.Clear();
            var Lista = LGrupo_turno.Lista_grupo_turno_detalle(li_idgrupo);
            foreach (var f in Lista)
            {
                dgvlista_trab.Rows.Add(f.dni, f.trabajador, null, f.ult_cantidad, null);
            }
        }

        private void btncrearturno_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxdescripcion.Text.Length == 0)
                {
                    MessageBox.Show(@"Ingrese La Descripcion del Grupo", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbturno.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione un Turno", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var aux = new Grupo_turno();
                aux.descripcion = tbxdescripcion.Text.Trim();
                aux.idusuario = Login.usuarioId1;
                aux.idturno = Convert.ToInt32(cbturno.Text.Substring(0, cbturno.Text.Contains("-").ToString().Length - 2));
                aux.fecha_produccion = Convert.ToDateTime(dtpfec_produccion.Value.ToShortDateString());
                aux.fecha_inicio = Convert.ToDateTime(dtpdesde.Value);
                aux.fecha_fin = Convert.ToDateTime(dtphasta.Value);
                aux.flag_tercero = Flag_tercero();
                aux.flag_estado = "1";

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                var comando = new MySqlCommand("usp_tblgrupo_turno_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_descripcion", aux.descripcion);
                comando.Parameters.AddWithValue("p_idusuario", aux.idusuario);
                comando.Parameters.AddWithValue("p_idturno", aux.idturno);
                comando.Parameters.AddWithValue("p_fecha_produccion", aux.fecha_produccion);
                comando.Parameters.AddWithValue("p_fecha_inicio", aux.fecha_inicio);
                comando.Parameters.AddWithValue("p_fecha_fin", aux.fecha_fin);
                comando.Parameters.AddWithValue("p_flag_tercero", aux.flag_tercero);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"COLABORADOR REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lista_Grupo_turno(aux.fecha_produccion.ToString("yyyy-MM-dd"));
                ConexionGral.desconectar();
                return;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FJornalTurno_Load(object sender, EventArgs e)
        {
            Cargar_turno();
            lblusuario.Text = Login.usuarioId1.ToString() + " " + Login.nombre1 + " " + Login.apaterno1;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpfecha_produccion_fil_ValueChanged(object sender, EventArgs e)
        {
            Lista_Grupo_turno(dtpfecha_produccion_fil.Value.ToString("yyyy-MM-dd"));
        }

        public bool Existe_dni(String rol, DataGridView dgv)
        {
            bool existe = false;

            foreach (DataGridViewRow f in dgv.Rows)
            {
                string verifica = f.Cells[0].Value.ToString();
                if (rol == verifica)
                {
                    MessageBox.Show("EL DNI " + verifica + " YA ESISTE EN LA LISTA DE TRABAJADORES", "AVISO");
                    existe = true;
                    break;
                }
                else
                {
                    existe = false;
                }
            }
            return existe;
        }

        private void btnasigna_trab_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvlista_trab.RowCount <= 0)
                {
                    MessageBox.Show(@"No Hay Ningun Trabajador para Asignar al Grupo", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                foreach (DataGridViewRow f in dgvlista_trab.Rows)
                {
                    var aux = new Grupo_turno_detalle();
                    aux.idgrupo = Convert.ToInt32(lblidgrupo.Text);
                    aux.dni = f.Cells[0].Value.ToString();

                    var comando = new MySqlCommand("usp_tblgrupo_turno_det_insert", ConexionGral.conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("p_idgrupo", aux.idgrupo);
                    comando.Parameters.AddWithValue("p_dni", aux.dni);
                    comando.ExecuteNonQuery();
                }

                MessageBox.Show(@"TRABAJADORES ASIGNADOS AL GRUPO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lista_Grupo_turno_det(Convert.ToInt32(lblidgrupo.Text.ToString()));
                ConexionGral.desconectar();
                return;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("TRABAJADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dgvlista_trab_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var img = Properties.Resources.qr;
                e.Graphics.DrawImage(img, e.CellBounds.Left + 30, e.CellBounds.Top + 3, 18, 15); // centrar la imagen en el boton
                e.Handled = true;
            }
        }

        private void dgvgrupo_turno_cab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvgrupo_turno_cab.Columns[e.ColumnIndex].Index == 0) //EDITAR
            {
                editar = true;
                tbxdescripcion.Text = dgvgrupo_turno_cab.CurrentRow.Cells[3].Value.ToString();
                cbturno.Text = dgvgrupo_turno_cab.CurrentRow.Cells[6].Value.ToString() + " - " + dgvgrupo_turno_cab.CurrentRow.Cells[7].Value.ToString();
                dtpfec_produccion.Value = Convert.ToDateTime(dgvgrupo_turno_cab.CurrentRow.Cells[8].Value);
                dtpdesde.Value = Convert.ToDateTime(dgvgrupo_turno_cab.CurrentRow.Cells[9].Value);
                dtphasta.Value = Convert.ToDateTime(dgvgrupo_turno_cab.CurrentRow.Cells[10].Value);
                cbflag_tercero.Checked = dgvgrupo_turno_cab.CurrentRow.Cells[11].Value.ToString() == "True" ? true : false;
                lblestado.Text = dgvgrupo_turno_cab.CurrentRow.Cells[12].Value.ToString() == "True" ? "ACTIVO" : "ANULADO";
            }
            else if (dgvgrupo_turno_cab.Columns[e.ColumnIndex].Index == 1) // ELIMINAR
            {
                var rpta = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL GRUPO " + dgvgrupo_turno_cab.CurrentRow.Cells[3].Value.ToString() + " ?"
                    , @"Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    MySqlCommand comando = null;
                    try
                    {
                        if (ConexionGral.conexion.State == ConnectionState.Closed)
                        {
                            ConexionGral.conectar();
                        }
                        comando = new MySqlCommand("usp_tblcolaborador_delete", ConexionGral.conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("p_id", Convert.ToInt32(dgvgrupo_turno_cab.CurrentRow.Cells[2].Value));
                        comando.ExecuteNonQuery();
                        MessageBox.Show(@"GRUPO TURNO SE ELIMINO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConexionGral.desconectar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        private void btnactualizar_turno_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                try
                {

                    if (tbxdescripcion.Text.Length == 0)
                    {
                        MessageBox.Show(@"Ingrese La Descripcion del Grupo", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (cbturno.SelectedIndex == 0)
                    {
                        MessageBox.Show(@"Seleccione un Turno", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var aux = new Grupo_turno();
                    aux.idgrupo = Convert.ToInt32(dgvgrupo_turno_cab.CurrentRow.Cells[2].Value);
                    aux.descripcion = tbxdescripcion.Text.Trim();
                    aux.idusuario = Login.usuarioId1;
                    aux.idturno = Convert.ToInt32(cbturno.Text.Substring(0, cbturno.Text.Contains("-").ToString().Length - 2));
                    aux.fecha_produccion = Convert.ToDateTime(dtpfec_produccion.Value.ToShortDateString());
                    aux.fecha_inicio = Convert.ToDateTime(dtpdesde.Value);
                    aux.fecha_fin = Convert.ToDateTime(dtphasta.Value);
                    aux.flag_tercero = Flag_tercero();
                    aux.flag_estado = "1";


                    if (ConexionGral.conexion.State == ConnectionState.Closed)
                    {
                        ConexionGral.conectar();
                    }

                    var comando = new MySqlCommand("usp_tblgrupo_turno_update", ConexionGral.conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("p_descripcion", aux.descripcion);
                    comando.Parameters.AddWithValue("p_idusuario", aux.idusuario);
                    comando.Parameters.AddWithValue("p_idturno", aux.idturno);
                    comando.Parameters.AddWithValue("p_fecha_produccion", aux.fecha_produccion);
                    comando.Parameters.AddWithValue("p_fecha_inicio", aux.fecha_inicio);
                    comando.Parameters.AddWithValue("p_fecha_fin", aux.fecha_fin);
                    comando.Parameters.AddWithValue("p_flag_tercero", aux.flag_tercero);
                    comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                    comando.Parameters.AddWithValue("p_id", aux.idgrupo);
                    comando.ExecuteNonQuery();
                    MessageBox.Show(@"GRUPO TURNO ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Lista_Grupo_turno(aux.fecha_produccion.ToString("yyyy-MM-dd"));
                    ConexionGral.desconectar();
                    return;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
/*
                editar = false;
*/
            }
        }

        private void dgvgrupo_turno_cab_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvgrupo_turno_cab.SelectedRows.Count > 0)
            {
                li_idgrupo = Convert.ToInt32(dgvgrupo_turno_cab.CurrentRow.Cells[2].Value);
                ls_grupo_desc = dgvgrupo_turno_cab.CurrentRow.Cells[3].Value.ToString();

                lblidgrupo.Text = li_idgrupo.ToString();
                lbldesc_grupo.Text = ls_grupo_desc.ToString();
                lblnro_trab.Text = dgvlista_trab.RowCount.ToString();

                Lista_Grupo_turno_det(li_idgrupo);
            }
        }

        private void btnbuscar_trab_Click(object sender, EventArgs e)
        {
            if (dgvgrupo_turno_cab.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Debe Selecccionar un Grupo", @"Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            li_idgrupo = Convert.ToInt32(dgvgrupo_turno_cab.CurrentRow.Cells[2].Value);
            ls_grupo_desc = dgvgrupo_turno_cab.CurrentRow.Cells[3].Value.ToString();

            var f = new FTraslado_trabajador();
            f.ShowDialog();

            if (FTraslado_trabajador.estado_transferencia)
            {
                if (dgvlista_trab.RowCount > 0)
                {
                    foreach (var y in FTraslado_trabajador.lista_datos)
                    {
                        if (Existe_dni(y.dni.ToString(), dgvlista_trab) == false)
                        {
                            dgvlista_trab.Rows.Add(y.dni, y.trabajador);
                        }
                    }
                    lblnro_trab.Text = dgvlista_trab.RowCount.ToString();
                }
                else
                {
                    foreach (var y in FTraslado_trabajador.lista_datos)
                    {
                        dgvlista_trab.Rows.Add(y.dni, y.trabajador);
                    }
                    lblnro_trab.Text = dgvlista_trab.RowCount.ToString();
                }
            }
            else
            {
                return;
            }
        }

        private void dgvlista_trab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvlista_trab.Columns[e.ColumnIndex].Index == 2)
            {
                li_idgrupo = Convert.ToInt32(lblidgrupo.Text.Trim());
                ls_dni = dgvlista_trab.CurrentRow.Cells[0].Value.ToString();
                ls_trabajador = dgvlista_trab.CurrentRow.Cells[1].Value.ToString();
                var f = new FImprimirQR();
                f.ShowDialog();
            }
            else if (dgvlista_trab.Columns[e.ColumnIndex].Index == 4)
            {
                // ELIMINAR
            }
        }
    }
}