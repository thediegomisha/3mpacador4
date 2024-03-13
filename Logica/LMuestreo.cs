using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Devart.Data.MySql;
using System.Windows.Forms;

namespace _3mpacador4.Logica
{
    public class LMuestreo
    {
        public static bool Muestreo_insert_update(int idlote, string fecha_produccion, decimal cantidad)
        {
            try
            {
                bool rpta = false;

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                    ConexionGral.conectar();

                var comando = new MySqlCommand("usp_tblmuestreo_insert_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idlote", idlote);
                comando.Parameters.AddWithValue("p_fecha_produccion", fecha_produccion);
                comando.Parameters.AddWithValue("p_cantidad", cantidad);
                rpta = Convert.ToBoolean(comando.ExecuteNonQuery());

                ConexionGral.desconectar();
                return rpta;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"OCURRIO UN ERROR EN usp_tblmuestreo_insert_update " + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
