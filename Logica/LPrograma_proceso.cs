using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _3mpacador4.Entidad;
using Devart.Data.MySql;
using System.Windows.Forms;

namespace _3mpacador4.Logica
{
    public class LPrograma_proceso
    {
        public static List<Programa_proceso> Lista_lotes_x_fecha(string ls_fecha_proceso)
        {
            MySqlCommand comando;
            try
            {
                //dgvlote_x_fec.Rows.Clear();
                var lista = new List<Programa_proceso>();
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand(@"select distinct x.idlote, concat(l.numlote,'-',l.periodo) as lote, 
                                            sum(j.numjabas) as cantidad_jabas,
                                            sum(t.peso_bruto)  - sum((t.tara_jaba * j.numjabas) + t.tara_pallet) as kilos from tblprograma_proceso x 
                                            inner join tbllote l on x.idlote = l.idlote
                                            inner join tblticketpesaje t on l.idlote = t.idlote
                                            inner join tbljabas j on t.cant_jabas = j.idjabas
                                            where x.fecha_produccion = @fecha_produccion
                                            group by x.idlote", ConexionGral.conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fecha_produccion", ls_fecha_proceso);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        Programa_proceso p = new Programa_proceso();
                        p.idlote = Convert.ToInt32(reader["idlote"]);
                        p.numlote = Convert.ToString(reader["lote"]);
                        p.cantidad_jabas = Convert.ToInt32(reader["cantidad_jabas"]);
                        p.kilos = Convert.ToDecimal(reader["kilos"]);
                        lista.Add(p);
                    }                        
                }

                ConexionGral.desconectar();
                return lista;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblprograma_proceso_x_fecha :( ");
                throw;
            }
        }

        public static List<Programa_proceso> Lista_programacion_x_lote(int li_idlote)
        {
            MySqlCommand comando;
            try
            {
                //dgvprog_x_lote.Rows.Clear();
                var lista = new List<Programa_proceso>();
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand(@"select pp.idproceso, pp.fecha_produccion, concat(l.numlote,'-',l.periodo) as lote, 
                                            cl.razon_social, d.nombre as destino, 
                                            c.nombre as categoria, concat(p.nombre,' ',p.unidad,' ',p.material) as presentacion    
                                            from tblprograma_proceso pp 
                                            inner join tbllote l on pp.idlote = l.idlote
                                            inner join tblcliente cl on cl.idcliente = pp.idcliente
                                            inner join tbldestino d on pp.iddestino = d.iddestino
                                            inner join tblcategoria c on pp.idcategoria = c.idcategoria
                                            inner join tblpresentacion p on pp.idpresentacion = p.idpresentacion
                                            where pp.idlote = @idlote", ConexionGral.conexion);
                //comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idlote", li_idlote);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Programa_proceso p = new Programa_proceso();
                        p.idproceso = Convert.ToInt32(reader["idproceso"]);
                        p.fecha_proceso = Convert.ToDateTime(reader["fecha_produccion"]);
                        p.numlote = Convert.ToString(reader["lote"]);                        
                        p.cliente = Convert.ToString(reader["razon_social"]);
                        p.destino = Convert.ToString(reader["destino"]);
                        p.categoria = Convert.ToString(reader["categoria"]);
                        p.presentacion = Convert.ToString(reader["presentacion"]);                       
                        lista.Add(p);
                        //dgvprog_x_lote.Rows.Add(reader["idproceso"], reader["lote"], reader["razon_social"], reader["destino"], reader["categoria"], reader["presentacion"]);
                    }
                }

                ConexionGral.desconectar();
                return lista;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblprograma_proceso_x_fecha :( ");
                throw;
            }
        }
    }
}
