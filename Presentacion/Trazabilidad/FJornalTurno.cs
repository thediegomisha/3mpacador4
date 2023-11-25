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
        public static string ls_grupo_desc = "";

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

                comando = new MySqlCommand("usp_grupo_turno_select", ConexionGral.conexion);
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

        private void btnasigna_trab_Click(object sender, EventArgs e)
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
        }
    }
}
