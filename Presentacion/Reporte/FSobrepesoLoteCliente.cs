using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FSobrepesoLoteCliente : Form
    {
        public FSobrepesoLoteCliente()
        {
            InitializeComponent();
        }

        void Mostrar_sobrepeso(int li_idlote)
        {
            MySqlCommand comando = null;
            try
            {
                dgvsobrepeso.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblsobrepeso_lote", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_idlote", li_idlote);
                comando.Parameters.AddWithValue("p_fecha_produccion", Convert.ToDateTime(lblfechaproduccion.Text).ToString("yyyy-MM-dd"));

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        dgvsobrepeso.Rows.Add(reader["idlote"].ToString(), reader["lote"].ToString(), 
                                              reader["idcliente"].ToString(), reader["cliente"].ToString(),
                                              reader["idcategoria"].ToString(), reader["categoria"].ToString(),
                                              reader["idpresentacion"].ToString(), reader["presentacion"].ToString(),                                              
                                              reader["cantidad_cajas"].ToString(), reader["ult_sobrepeso"].ToString(),
                                              (Convert.ToInt32(reader["cantidad_cajas"].ToString()) * Convert.ToDecimal(reader["ult_sobrepeso"].ToString())));
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

        private void dgvsobrepeso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvsobrepeso.Columns[e.ColumnIndex].Index == 11)
            {
                var rpta = MessageBox.Show("¿ ESTA SEGURO QUE DESEA MODIFICAR EL SOBREPESO ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    int li_idlote, li_idcategoria, li_idpresentacion, li_idcliente;
                    string ls_fecha_produccion;
                    decimal ldc_sobrepeso;


                    li_idlote = Convert.ToInt32(dgvsobrepeso.CurrentRow.Cells[0].Value);
                    ls_fecha_produccion = Convert.ToDateTime(lblfechaproduccion.Text).ToString("yyyy-MM-dd");
                    li_idcategoria = Convert.ToInt32(dgvsobrepeso.CurrentRow.Cells[4].Value);
                    li_idpresentacion = Convert.ToInt32(dgvsobrepeso.CurrentRow.Cells[6].Value);
                    li_idcliente = Convert.ToInt32(dgvsobrepeso.CurrentRow.Cells[2].Value);
                    ldc_sobrepeso = Convert.ToDecimal(dgvsobrepeso.CurrentRow.Cells[9].Value);

                    if (LPacking_calibre.Sobrepeso_Insert_update(li_idlote, ls_fecha_produccion, li_idcategoria, li_idpresentacion, li_idcliente, ldc_sobrepeso))
                    {
                        MessageBox.Show("SE ACTUALIZO EL SOBREPESO", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvsobrepeso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvsobrepeso.Columns[9].Index)
            {
                int cantidad = Convert.ToInt32(dgvsobrepeso.Rows[e.RowIndex].Cells[8].Value);
                decimal precio = Convert.ToDecimal(dgvsobrepeso.Rows[e.RowIndex].Cells[9].Value);

                decimal total = cantidad * precio;
                dgvsobrepeso.Rows[e.RowIndex].Cells[10].Value = total;
            }
        }

        private void dgvsobrepeso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvsobrepeso.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 11)
                {
                    e.Value = "Aplicar";
                }
            }
        }

        private void FSobrepesoLoteCliente_Load(object sender, EventArgs e)
        {
            lblfechaproduccion.Text = FRptPackigCalibre.ls_fecha_produccion;
            lbldesc_lote.Text = FRptPackigCalibre.ls_desc_lote;
            Mostrar_sobrepeso(FRptPackigCalibre.li_idlote);
        }
    }
}
