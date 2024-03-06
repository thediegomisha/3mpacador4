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

        public static int Existe_Conteo_manual_x_fecha(int li_idproceso)
        {
            int li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
            
            string sql = @"select count(*) from tblconteo_jabas cj 
                            inner join tblprograma_proceso pp on cj.idproceso = pp.idproceso
                            where cj.idproceso = @idproceso and
                            pp.flag_estado <> '0'";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@idproceso", li_idproceso);
            li_rpta = Convert.ToInt32(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static decimal Kilos_Descarte(int li_idlote)
        {
            decimal li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

            string sql = @"select ifnull((sum(d.peso_bruto) - sum(d.tara_jaba * tj.numjabas + d.tara_pallet)),0) from tblticket_descarte d 
                            inner join tbljabas tj on  tj.idjabas = d.cant_jabas
                            where  d.idlote = @idlote";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@idlote", li_idlote);
            li_rpta = Convert.ToDecimal(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static decimal Kilos_Muestra(int li_idlote)
        {
            decimal li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

            string sql = @"select ifnull(m.cantidad,0) from tblmuestreo m where m.idlote = @idlote";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@idlote", li_idlote);
            li_rpta = Convert.ToDecimal(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static int Conteo_Manual(int idproceso, int calibre, string fecha_produccion, int idusuario, int li_nro_pallet, int cantidad, int li_idcliente)
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
                comando.Parameters.AddWithValue("p_idusuario", idusuario);
                comando.Parameters.AddWithValue("p_nro_pallet", li_nro_pallet);
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

        public static bool Actualiza_Fecha_produccion(int idlote, string fecha_ticket, string fecha_produccion)
        {
            try
            {
                bool rpta = false;

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                    ConexionGral.conectar();

                var comando = new MySqlCommand(@"update tblticketpesaje t set t.fecha_produccion = @fecha_produccion
                                                where t.idlote = @idlote and t.fecha_ticket = @fecha_ticket ", ConexionGral.conexion);
                //comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@idlote", idlote);
                comando.Parameters.AddWithValue("@fecha_ticket", fecha_ticket);
                comando.Parameters.AddWithValue("@fecha_produccion", fecha_produccion);
                rpta = Convert.ToBoolean(comando.ExecuteNonQuery());

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
