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

        string Flag_tercero() {
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
            MySqlCommand comando;
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
                MessageBox.Show(ex.Message,"Algo salio Mal :( ");
                throw;
            }
        }

        void Lista_Grupo_turno(string ls_fecha_produccion) 
        {
            MySqlCommand comando;
            try
            {
                dgvgrupo_turno_cab.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblgrupo_turno_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_produccion);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Grupo_turno c = new Grupo_turno();
                        c.idgrupo = Convert.ToInt32(reader["idgrupo_turno"]);
                        c.descripcion = Convert.ToString(reader["descripcion"]);
                        c.idusuario = Convert.ToInt32(reader["idusuario"]);
                        c.nom_usuario = Convert.ToString(reader["usuario"]);
                        c.idturno = Convert.ToInt32(reader["idturno"]);
                        c.nom_turno = Convert.ToString(reader["nombre"]);
                        c.fecha_produccion = Convert.ToDateTime(reader["fecha_produccion"]);
                        c.fecha_inicio = Convert.ToDateTime(reader["fecha_inicio"]);
                        c.fecha_fin = Convert.ToDateTime(reader["fecha_fin"]);
                        c.flag_tercero = reader["flag_tercero"].ToString();
                        c.flag_estado = reader["flag_estado"].ToString();
                        dgvgrupo_turno_cab.Rows.Add(null, null, c.idgrupo, c.descripcion, c.idusuario, c.nom_usuario, c.idturno, c.nom_turno, c.fecha_produccion.ToShortDateString(), c.fecha_inicio, 
                                                    c.fecha_fin, c.flag_tercero == "1" ? true : false, c.flag_estado == "1" ? true : false);
                    }
                    //lblnro_reg.Text = dgvgrupo_turno_cab.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void Lista_Grupo_turno_det(int li_idgrupo)
        {
            MySqlCommand comando;
            try
            {
                dgvlista_trab.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                comando = new MySqlCommand("usp_tblgrupo_turno_det_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idgrupo", li_idgrupo);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Grupo_turno_detalle c = new Grupo_turno_detalle();
                        c.idgrupo = Convert.ToInt32(reader["idgrupo_turno"]);
                        c.dni = Convert.ToString(reader["dni"]);
                        c.trabajador = Convert.ToString(reader["trabajador"]);
                        c.ult_cantidad = Convert.ToInt32(reader["ult_cantidad"]);
                        dgvlista_trab.Rows.Add(c.dni, c.trabajador, null, c.ult_cantidad, null);
                    }
                    lblnro_trab.Text = dgvlista_trab.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btncrearturno_Click(object sender, EventArgs e)
        {
            try 
            {

                if (tbxdescripcion.Text.Length == 0)
                {
                    MessageBox.Show("Ingrese La Descripcion del Grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbturno.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un Turno","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("COLABORADOR REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lista_Grupo_turno(aux.fecha_produccion.ToString("yyyy-MM-dd"));
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("COLABORADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void FJornalTurno_Load(object sender, EventArgs e)
        {
            Cargar_turno();
            lblusuario.Text = Login.usuarioId1.ToString() +" "+ Login.nombre1 + " " + Login.apaterno1;
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
                    MessageBox.Show("No Hay Ningun Trabajador para Asignar al Grupo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                MessageBox.Show("TRABAJADORES ASIGNADOS AL GRUPO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lista_Grupo_turno_det(Convert.ToInt32(lblidgrupo.Text.ToString()));
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("TRABAJADOR NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dgvgrupo_turno_cab_DoubleClick(object sender, EventArgs e)
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

        private void dgvlista_trab_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var img = Properties.Resources.qr;
                e.Graphics.DrawImage(img, e.CellBounds.Left + 30, e.CellBounds.Top + 3, 18, 15); // centrar la imagen en el boton
                e.Handled = true;
            }
            else if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var img = Properties.Resources.eliminar;
                e.Graphics.DrawImage(img, e.CellBounds.Left + 15, e.CellBounds.Top + 3, 18, 15); // centrar la imagen en el boton
                e.Handled = true;
            }
        }

        private void dgvgrupo_turno_cab_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var img = Properties.Resources.edit;
                e.Graphics.DrawImage(img, e.CellBounds.Left + 5, e.CellBounds.Top + 3, 18, 15); // centrar la imagen en el boton
                e.Handled = true;
            }
            else if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var img = Properties.Resources.eliminar;
                e.Graphics.DrawImage(img, e.CellBounds.Left + 5, e.CellBounds.Top + 3, 18, 15); // centrar la imagen en el boton
                e.Handled = true;
            }
        }

        private void btnbuscar_trab_Click(object sender, EventArgs e)
        {
            if (dgvgrupo_turno_cab.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe Selecccionar un Grupo", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
