using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class FActualizaFechaProduccion : Form
    {
        public FActualizaFechaProduccion()
        {
            InitializeComponent();
        }

        void Mostrar_Lotes_x_Fecha(int li_anio, string ls_mes) 
        {
            MySqlCommand comando;
            try
            {
                dgvlista.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticketpesaje_lote_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", li_anio);
                comando.Parameters.AddWithValue("p_mes", ls_mes);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvlista.Rows.Add(reader["idlote"].ToString(), reader["lote"].ToString(), Convert.ToDateTime(reader["fecha_ticket"]).ToShortDateString(), Convert.ToDateTime(reader["fecha_produccion"]).ToShortDateString());
                    }
                    lbltotal_lotes.Text = dgvlista.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FActualizaFechaProduccion_Load(object sender, EventArgs e)
        {
            nudanio.Value = DateTime.Now.Year;
            cbxmes.SelectedIndex = 0;
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            int li_anio;
            string ls_mes;

            li_anio = Convert.ToInt32(nudanio.Value);

            if (cbxmes.SelectedIndex == 0)
            {
                ls_mes = "%";
            }
            else
            {
                ls_mes = cbxmes.Text.Substring(0, cbxmes.Text.Contains("-").ToString().Length - 2);
            }

            Mostrar_Lotes_x_Fecha(li_anio, ls_mes);
        }

        private void dgvlista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvlista.Columns[e.ColumnIndex].Index == 4)
            {

                /*if (dgvlista.CurrentRow.Cells[3].Value.ToString() != dgvlista.CurrentRow.Cells[2].Value.ToString())
                {*/
                    var rpta = MessageBox.Show("¿ ESTA SEGURO QUE DESEA ACTUALIZAR LA FECHA DE PRODUCCION A " + dgvlista.CurrentRow.Cells[3].Value.ToString() +" ?" , "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rpta == DialogResult.Yes)
                    {
                        string ls_fecha_ticket, ls_fecha_produccion;
                        int li_idlote;

                        li_idlote = Convert.ToInt32(dgvlista.CurrentRow.Cells[0].Value);
                        ls_fecha_ticket = Convert.ToDateTime(dgvlista.CurrentRow.Cells[2].Value).ToString("yyyy-MM-dd");
                        ls_fecha_produccion = Convert.ToDateTime(dgvlista.CurrentRow.Cells[3].Value).ToString("yyyy-MM-dd");

                        if (LConteo_manual.Actualiza_Fecha_produccion(li_idlote, ls_fecha_ticket, ls_fecha_produccion))
                        {
                            MessageBox.Show("SE ACTUALIZO LA FECHA DE PRODUCCION CORRCTAMENTE", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                //}              
            }
        }

        private void dgvlista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvlista.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    e.Value = "Aplicar";
                }
            }
        }
    }
}
