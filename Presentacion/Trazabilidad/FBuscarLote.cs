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
using _3mpacador4.Presentacion.Reporte;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FBuscarLote : Form
    {
        public FBuscarLote()
        {
            InitializeComponent();
        }


        private void Cargar_lote()
        {
            MySqlCommand comando = null;
            try
            {
                dgvlista.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_Select2", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", Convert.ToInt32(nudanio.Value));

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) dgvlista.Rows.Add(reader["idlote"].ToString(), reader["lote"].ToString());
                }

                ConexionGral.desconectar();                
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal :( ");
                throw;
            }
        }

        private void FBuscarLote_Load(object sender, EventArgs e)
        {
            nudanio.Value = DateTime.Now.Year;
            Cargar_lote();
        }

        private void nudanio_ValueChanged(object sender, EventArgs e)
        {
            Cargar_lote();
        }

        private void dgvlista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvlista.SelectedRows.Count > 0)
            {
                if (FPrecioCalibre.b_estado)
                {
                    FPrecioCalibre.l.idlote = Convert.ToInt32(dgvlista.CurrentRow.Cells[0].Value.ToString());
                    FPrecioCalibre.l.lote = dgvlista.CurrentRow.Cells[1].Value.ToString();
                }
                else 
                {
                    FProgramaProceso.l.idlote = Convert.ToInt32(dgvlista.CurrentRow.Cells[0].Value.ToString());
                    FProgramaProceso.l.lote = dgvlista.CurrentRow.Cells[1].Value.ToString();
                }
                
                Close();
            }
        }
    }
}
