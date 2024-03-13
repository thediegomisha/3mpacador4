using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FMuestreo : Form
    {
        public FMuestreo()
        {
            InitializeComponent();
        }

        void Mostrar_Muestreo_x_lote(int li_anio, string ls_mes)
        {
            MySqlCommand comando = null;
            try
            {
                dgvlista.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_muestreo_x_lote", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", li_anio);
                comando.Parameters.AddWithValue("p_mes", ls_mes);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        dgvlista.Rows.Add(Convert.ToDateTime(reader["fecha_produccion"]).ToShortDateString(),
                                              reader["idlote"].ToString(), reader["lote"].ToString(),
                                              reader["num_guia"].ToString(), reader["idcliente"].ToString(), 
                                              reader["nom_cliente"].ToString(),                                             
                                              reader["cantidad_jabas"].ToString(), Convert.ToDecimal(reader["peso_bruto"].ToString()),
                                              Convert.ToDecimal(reader["peso_neto"].ToString()), Convert.ToDecimal(reader["muestreo"].ToString()));
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblsobrepeso_lote :( ");
                throw;
            }
        }

        private void FMuestreo_Load(object sender, EventArgs e)
        {
            nudanio.Value = DateTime.Now.Year;
            cbxmes.SelectedIndex = 0;
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            int li_anio = 0;
            string ls_mes = "";

            li_anio = Convert.ToInt32(nudanio.Value);
            if (cbxmes.SelectedIndex == 0)
            {
                ls_mes = "%";
            }
            else
            {
                ls_mes = cbxmes.Text.Substring(0, cbxmes.Text.Contains("-").ToString().Length - 2);
            }

            Mostrar_Muestreo_x_lote(li_anio, ls_mes);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvlista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvlista.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 10)
                {
                    e.Value = "Aplicar";
                }
            }
        }

        private void dgvlista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvlista.Columns[e.ColumnIndex].Index == 10)
            {
                var rpta = MessageBox.Show("¿ ESTA SEGURO QUE DESEA INGRESAR EL MUESTREO PARA EL LOTE" + dgvlista.CurrentRow.Cells[2].Value.ToString() + " ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    string ls_fecha_produccion;
                    int li_idlote; 
                    decimal ldc_cantidad;

                    li_idlote = Convert.ToInt32(dgvlista.CurrentRow.Cells[1].Value);
                    ldc_cantidad = Convert.ToDecimal(dgvlista.CurrentRow.Cells[9].Value);
                    ls_fecha_produccion = Convert.ToDateTime(dgvlista.CurrentRow.Cells[0].Value).ToString("yyyy-MM-dd");

                    if (LMuestreo.Muestreo_insert_update(li_idlote, ls_fecha_produccion, ldc_cantidad))
                    {
                        MessageBox.Show("MUESTREO GENERADO CORRCTAMENTE", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
