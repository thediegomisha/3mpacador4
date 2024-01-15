using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3mpacador4.Entidad;
using Devart.Data.MySql;

namespace _3mpacador4.Logica
{
    public class LGrupo_turno
    {
        {
            var x = new Grupo_turno();
            x.idgrupo = Convert.ToInt32(lector[0]);
            x.descripcion = Convert.ToString(lector[1]);
            x.idusuario = Convert.ToInt32(lector[2]);
            x.nom_usuario = Convert.ToString(lector[3]);
            x.idturno = Convert.ToInt32(lector[4]);
            x.nom_turno = Convert.ToString(lector[5]);
            x.fecha_produccion = Convert.ToDateTime(lector[6]);
            x.fecha_inicio = Convert.ToDateTime(lector[7]);
            x.fecha_fin = Convert.ToDateTime(lector[8]);
            x.flag_tercero = Convert.ToString(lector[9]);
            x.flag_estado = Convert.ToString(lector[10]);

            return x;
        public static List<Grupo_turno> Lista_grupo_turno(string ls_fecha_produccion)
        {
            var lista = new List<Grupo_turno>();

            var comando = new MySqlCommand("usp_tblgrupo_turno_select", ConexionGral.conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_fecha_produccion", ls_fecha_produccion);

            {
                while (reader.Read())
                {
                    c.idgrupo = Convert.ToInt32(reader["idgrupo_turno"]);
                    c.descripcion = Convert.ToString(reader["descripcion"]);
                    c.idusuario = Convert.ToInt32(reader["idusuario"]);
                    c.nom_usuario = Convert.ToString(reader["usuario"]);
                    c.idturno = Convert.ToInt32(reader["idturno"]);
                    c.nom_turno = Convert.ToString(reader["nombre"]);
                    c.fecha_produccion = Convert.ToDateTime(reader["fecha_produccion"]);
                    c.fecha_inicio = Convert.ToDateTime(reader["fecha_inicio"]);
                    c.fecha_fin = Convert.ToDateTime(reader["fecha_fin"]);
                    c.flag_tercero = reader["flag_tercero"].ToString();
                    c.flag_estado = reader["flag_estado"].ToString();
                    lista.Add(c);
                }
            }

            ConexionGral.desconectar();
            return lista;
        }

        {
            var x = new Grupo_turno_detalle();
            x.idgrupo = Convert.ToInt32(lector[0]);
            x.dni = Convert.ToString(lector[1]);
            x.trabajador = Convert.ToString(lector[2]);
            x.ult_cantidad = Convert.ToInt32(lector[3]);

            return x;
        public static List<Grupo_turno_detalle> Lista_grupo_turno_detalle(int li_idgrupo)
        {
            var lista = new List<Grupo_turno_detalle>();

            var comando = new MySqlCommand("usp_tblgrupo_turno_det_select", ConexionGral.conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("p_idgrupo", li_idgrupo);

            {
                while (reader.Read())
                {
                    c.idgrupo = Convert.ToInt32(reader["idgrupo_turno"]);
                    c.dni = Convert.ToString(reader["dni"]);
                    c.trabajador = Convert.ToString(reader["trabajador"]);
                    c.ult_cantidad = Convert.ToInt32(reader["ult_cantidad"]);
                    lista.Add(c);
                }
            }

            ConexionGral.desconectar();
            return lista;
        }
    }
}
