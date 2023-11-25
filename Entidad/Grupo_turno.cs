using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Entidad
{
    public class Grupo_turno
    {
        public int idgrupo { get; set; }
        public string descripcion { get; set; }
        public int idusuario { get; set; }
        public string nom_usuario { get; set; }
        public int idturno { get; set; }
        public string nom_turno { get; set; }
        public DateTime fecha_produccion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string flag_tercero { get; set; }
        public string flag_estado { get; set; }
    }
}
