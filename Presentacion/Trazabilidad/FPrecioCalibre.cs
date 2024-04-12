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
    public partial class FPrecioCalibre : Form
    {
        public FPrecioCalibre()
        {
            InitializeComponent();
        }

        public static bool b_estado = false;
        public static Lote l = null;

        void Mostrar_Precio_x_Calibre(int li_lote)
        {
            MySqlCommand comando = null;
            try
            {
                dgvlista.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_listar_precio_x_calibre", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", li_lote);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                        dgvlista.Rows.Add(reader["idlote"].ToString(), reader["lote"].ToString(),
                                              reader["idcliente"].ToString(), 
                                              reader["cliente"].ToString(),                                             
                                              reader["calibre"].ToString(), Convert.ToDecimal(reader["cajas"].ToString()),
                                              Convert.ToDecimal(reader["kg"].ToString()), 
                                              Convert.ToDecimal(reader["kilos_x_calibre"].ToString()),
                                              Convert.ToDecimal(reader["precio"].ToString()),
                                              
                                              Convert.ToDecimal(reader["kilos_x_calibre"]) * Convert.ToDecimal(reader["precio"])
                                              
                                              );
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_listar_precio_x_calibre :( ");
                throw;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void dgvlista_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            
        }

        private void btnbuscar_lote_Click(object sender, EventArgs e)
        {
            b_estado = true;
            l = new Lote();
            var F = new FBuscarLote();
            F.ShowDialog();
            if (l.idlote > 0)
            {
                lblidlote.Text = l.idlote.ToString();
                lbllote.Text = l.lote;
                Mostrar_Precio_x_Calibre(Convert.ToInt32(lblidlote.Text));
            }
            b_estado = false;
        }

        private void dgvlista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvlista.Rows[e.RowIndex];

                decimal kilos = Convert.ToDecimal(row.Cells[7].Value);
                decimal precio = Convert.ToDecimal(row.Cells[8].Value);
                decimal importe = kilos * precio;

                row.Cells[9].Value = importe;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            bool lb_rpta = false;
            var rpta = MessageBox.Show("¿ ESTA SEGURO QUE DESEA APLICAR LOS PRECIOS ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                for (int i = 0; i < dgvlista.RowCount; i++)
                {
                    int li_idlote, li_idcliente, li_calibre;
                    decimal ldc_precio;

                    li_idlote = Convert.ToInt32(dgvlista.Rows[i].Cells[0].Value);
                    li_idcliente = Convert.ToInt32(dgvlista.Rows[i].Cells[2].Value);
                    li_calibre = Convert.ToInt32(dgvlista.Rows[i].Cells[4].Value);
                    ldc_precio = Convert.ToDecimal(dgvlista.Rows[i].Cells[8].Value);

                    if (LMuestreo.Precio_x_calibre_insert_update(li_idlote, li_idcliente, li_calibre, ldc_precio))
                    {
                        lb_rpta = true;
                    }                    
                    
                }
                if (lb_rpta)
                {
                    MessageBox.Show("SE APLICARON LOS PRECIOS CORRCTAMENTE", "Aviso...!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
