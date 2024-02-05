using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3mpacador4.Entidad;
using System.Data;
using Devart.Data.MySql;
using System.Windows.Forms;

namespace _3mpacador4.Logica
{
    public class LPacking_calibre
    {
        public static List<Packing_calibre_cab> Lista_packing_calibre_cab(string ls_fecha_produccion)
        {
            var lista = new List<Packing_calibre_cab>();
            if (ConexionGral.conexion.State == ConnectionState.Closed)
            {
                ConexionGral.conectar();
            }

            var comando = new MySqlCommand("usp_rpt_packing_calibre_cab", ConexionGral.conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_produccion);

            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Packing_calibre_cab c = new Packing_calibre_cab();
                    c.nom_planta = Convert.ToString(reader["nom_planta"]);
                    c.idproducto = Convert.ToInt32(reader["idproducto"]);
                    c.producto = Convert.ToString(reader["producto"]);
                    c.idacopiador = Convert.ToInt32(reader["idacopiador"]);
                    c.nom_acopiador = Convert.ToString(reader["nom_acopiador"]);
                    c.ruc_a = Convert.ToString(reader["ruc_a"]);
                    c.fecha_produccion = Convert.ToDateTime(reader["fecha_produccion"]);
                    c.idclp = Convert.ToString(reader["idclp"]);
                    c.idlote = Convert.ToInt32(reader["idlote"]);
                    c.lote = reader["lote"].ToString();
                    c.num_guia = reader["num_guia"].ToString();
                    c.idvariedad = Convert.ToInt32(reader["idvariedad"].ToString());
                    c.variedad = reader["variedad"].ToString();
                    c.idcliente = reader["idcliente"].ToString();
                    c.nom_cliente = reader["nom_cliente"].ToString();
                    c.ruc_c = reader["ruc_c"].ToString();
                    c.cantidad_jabas = Convert.ToDecimal(reader["cantidad_jabas"].ToString());
                    c.peso_bruto = Convert.ToDecimal(reader["peso_bruto"].ToString());
                    c.peso_jabas = Convert.ToDecimal(reader["peso_jabas"].ToString());
                    c.peso_neto = Convert.ToDecimal(reader["peso_neto"].ToString());
                    c.peso_promedio = Convert.ToDecimal(reader["peso_promedio"].ToString());
                    lista.Add(c);
                }
            }
            ConexionGral.desconectar();
            return lista;
        }

        public static decimal Kilos_Proceso_x_fecha(string ls_fecha_produccion, int li_idlote)
        {
            decimal li_rpta = 0;
            if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

            string sql = @"select ifnull(sum(x.kilos),0) from(
                            select (count(cj.calibre) * (usf_soprepeso(pp.idlote,pp.fecha_produccion, pp.idcategoria, pp.idpresentacion)))  as kilos
                            from tblconteo_jabas cj 
                            inner join tblprograma_proceso pp on cj.idproceso = pp.idproceso 
                            inner join tblpresentacion s on pp.idpresentacion = s.idpresentacion
                            where cj.calibre = cj.calibre and pp.fecha_produccion = @fecha_produccion and pp.idlote = @idlote
                            group by s.nombre) x";
            var cmd = new MySqlCommand(sql, ConexionGral.conexion);
            cmd.Parameters.AddWithValue("@fecha_produccion", ls_fecha_produccion);
            cmd.Parameters.AddWithValue("@idlote", li_idlote);
            li_rpta = Convert.ToDecimal(cmd.ExecuteScalar());
            ConexionGral.desconectar();
            return li_rpta;
        }

        public static List<Packing_calibre_det> Lista_packing_calibre_det(string ls_fecha_produccion, string ls_id_cliente, int li_idlote)
        {
            var lista = new List<Packing_calibre_det>();
            if (ConexionGral.conexion.State == ConnectionState.Closed)
            {
                ConexionGral.conectar();
            }

            var comando = new MySqlCommand("usp_rpt_packing_calibre_det", ConexionGral.conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_produccion);
            comando.Parameters.AddWithValue("p_idcliente", ls_id_cliente);
            comando.Parameters.AddWithValue("p_idlote", li_idlote);

            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Packing_calibre_det c = new Packing_calibre_det();
                    c.presentacion = Convert.ToString(reader["presentacion"]);
                    c.categoria = Convert.ToString(reader["categoria"]);
                    c.C8  = Convert.ToInt32(reader["C8"]);
                    c.C10 = Convert.ToInt32(reader["C10"]);
                    c.C12 = Convert.ToInt32(reader["C12"]);
                    c.C14 = Convert.ToInt32(reader["C14"]);
                    c.C16 = Convert.ToInt32(reader["C16"]);
                    c.C18 = Convert.ToInt32(reader["C18"]);
                    c.C20 = Convert.ToInt32(reader["C20"]);
                    c.C22 = Convert.ToInt32(reader["C22"]);
                    c.C24 = Convert.ToInt32(reader["C24"]);
                    c.C26 = Convert.ToInt32(reader["C26"]);
                    c.C28 = Convert.ToInt32(reader["C28"]);
                    c.C30 = Convert.ToInt32(reader["C30"]);
                    c.C32 = Convert.ToInt32(reader["C32"]);
                    c.cantidad = Convert.ToInt32(reader["cantidad"]);
                    c.sobrepeso = Convert.ToDecimal(reader["sobrepeso"]);
                    c.kilos = Convert.ToDecimal(reader["kilos"]);
                    lista.Add(c);
                }
            }
            ConexionGral.desconectar();
            return lista;
        }

        public static bool Sobrepeso_Insert_update(int idlote, string fecha_produccion, int idcategoria, int idpresentacion, decimal sobrepeso)
        {
            try
            {
                bool rpta = false;

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                    ConexionGral.conectar();

                var comando = new MySqlCommand(@"usp_tblsobrepeso_insert_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_idlote", idlote);
                comando.Parameters.AddWithValue("p_fecha_produccion", fecha_produccion);
                comando.Parameters.AddWithValue("p_idcategoria", idcategoria);                
                comando.Parameters.AddWithValue("p_idpresentacion", idpresentacion);
                comando.Parameters.AddWithValue("p_ult_sobrepeso", sobrepeso);
                rpta = Convert.ToBoolean(comando.ExecuteNonQuery());

                ConexionGral.desconectar();
                return rpta;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"OCURRIO UN ERROR EN usp_tblsobrepeso_insert_update " + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

    }
}
