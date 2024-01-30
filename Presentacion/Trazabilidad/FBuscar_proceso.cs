using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using _3mpacador4.Presentacion.Reporte;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FBuscar_proceso : Form
    {
        public FBuscar_proceso()
        {
            InitializeComponent();
        }

        private void Cargar_proceso_x_fecha(string ls_fecha_proceso)
        {
            MySqlCommand comando;
            try
            {
                dgvlista.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblprograma_proceso_x_fecha", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_fecha_proceso", ls_fecha_proceso);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        dgvlista.Rows.Add(reader["idproceso"], reader["idlote"], reader["numlote"], reader["iddestino"], reader["destino"], reader["idcategoria"], reader["categoria"], reader["idpresentacion"], reader["presentacion"]);
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblprograma_proceso_x_fecha :( ");
                throw;
            }
        }

        private void FBuscar_proceso_Load(object sender, EventArgs e)
        {
            this.Text = "BUSCAR PROCESOS DE LA FECHA - " + Convert.ToDateTime(FProgramaProceso.ls_fecha_produccion).ToShortDateString();
            Cargar_proceso_x_fecha(FProgramaProceso.ls_fecha_produccion);
        }

        private void dgvlista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvlista.SelectedRows.Count > 0)
            {
                FProgramaProceso.pp.idproceso = Convert.ToInt32(dgvlista.CurrentRow.Cells[0].Value);
                FProgramaProceso.pp.idlote = Convert.ToInt32(dgvlista.CurrentRow.Cells[1].Value);
                FProgramaProceso.pp.numlote = Convert.ToString(dgvlista.CurrentRow.Cells[2].Value);
                FProgramaProceso.pp.iddestino = Convert.ToInt32(dgvlista.CurrentRow.Cells[3].Value);
                FProgramaProceso.pp.destino = Convert.ToString(dgvlista.CurrentRow.Cells[4].Value);
                FProgramaProceso.pp.idcategoria = Convert.ToInt32(dgvlista.CurrentRow.Cells[5].Value);
                FProgramaProceso.pp.categoria = Convert.ToString(dgvlista.CurrentRow.Cells[6].Value);
                FProgramaProceso.pp.idpresentacion = Convert.ToInt32(dgvlista.CurrentRow.Cells[7].Value);
                FProgramaProceso.pp.presentacion = Convert.ToString(dgvlista.CurrentRow.Cells[8].Value);
                Close();
            }
        }
    }
}
