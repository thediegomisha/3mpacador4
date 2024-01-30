using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Devart.Data.MySql;
using System.Windows.Forms;
using _3mpacador4.Entidad;

namespace _3mpacador4.Logica
{
    public class LConteo_manual
    {

        public static int Existe_Conteo_manual_x_fecha(string ls_fecha_produccion, int li_idlote, int li_categoria, int li_idpresentacion, int li_idcliente)
        {
            int li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
            
            string sql = @"select count(*) from tblconteo_jabas cj 
                            inner join tblprograma_proceso pp on cj.idproceso = pp.idproceso
                            where cj.fecha_produccion = @fecha_produccion and 
                            pp.idlote = @idlote and
                            pp.idcategoria = @idcategoria and
                            pp.idpresentacion = @idpresentacion and 
                            cj.idcliente = @idcliente and
                            pp.flag_estado <> '0'";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@fecha_produccion", ls_fecha_produccion);
            cmd.Parameters.AddWithValue("@idlote", li_idlote);
            cmd.Parameters.AddWithValue("@idcategoria", li_categoria);
            cmd.Parameters.AddWithValue("@idpresentacion", li_idpresentacion);
            cmd.Parameters.AddWithValue("@idcliente", li_idcliente);
            li_rpta = Convert.ToInt32(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static decimal Kilos_Descarte(int li_idlote)
        {
            decimal li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

            string sql = @"select (sum(d.peso_bruto) - sum(d.tara_jaba * d.cant_jabas)) from tblticket_descarte d where  d.idlote = @idlote;";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@idlote", li_idlote);
            li_rpta = Convert.ToDecimal(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static decimal Kilos_Muestra(/*int li_idlote*/)
        {
            decimal li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

            string sql = @"select 8 from dual;";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            //cmd.Parameters.AddWithValue("@idlote", li_idlote);
            li_rpta = Convert.ToDecimal(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static int Conteo_Manual(int idproceso, int calibre, string fecha_produccion, int cantidad, int li_idcliente)
        {
            try
            {
                int rpta = 0;

                if (ConexionGral.conexion.State == ConnectionState.Closed) 
                    ConexionGral.conectar();

                var comando = new MySqlCommand("usp_conteo_cajas_manual", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idproceso", idproceso);
                comando.Parameters.AddWithValue("p_idterminal", 1);
                comando.Parameters.AddWithValue("p_calibre", calibre);
                comando.Parameters.AddWithValue("p_fecha_produccion", fecha_produccion);
                comando.Parameters.AddWithValue("p_idusuario", 1);
                comando.Parameters.AddWithValue("p_nro_pallet", 0);
                comando.Parameters.AddWithValue("p_cantidad_x_calibre", cantidad);
                comando.Parameters.AddWithValue("p_idcliente", li_idcliente);
                rpta = comando.ExecuteNonQuery();                

                ConexionGral.desconectar();
                return rpta;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"OCURRIO UN ERROR EN usp_conteo_cajas_manual " + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
