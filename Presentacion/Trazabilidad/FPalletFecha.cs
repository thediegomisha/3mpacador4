using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Reporte;

namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FPalletFecha : Form
    {
        public FPalletFecha()
        {
            InitializeComponent();
        }

        private void Caja_pallet_x_fecha(string ls_fecha_proceso)
        {
            int li_total_cajas = 0;
            MySqlCommand comando;
            try
            {
                dgvlista.Rows.Clear();
                var lista = new List<string>();
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand(@"usp_cajas_pallet_x_fecha", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_proceso);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvlista.Rows.Add(reader["nro_pallet"].ToString(), reader["cajas"].ToString());
                        li_total_cajas += Convert.ToInt32(reader["cajas"].ToString());
                    }
                }

                lbltotal.Text = li_total_cajas.ToString();

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblprograma_proceso_x_fecha :( ");
                throw;
            }
        }

        private void FPalletFecha_Load(object sender, EventArgs e)
        {
            lblfechaproduccion.Text = Convert.ToDateTime(FProgramaProceso.ls_fecha_produccion).ToShortDateString();
            Caja_pallet_x_fecha(FProgramaProceso.ls_fecha_produccion);
        }
    }
}
