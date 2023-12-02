using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Entidad
{
    public class Colaborador
    {
        public int idcolaborador { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string flag_estado { get; set; }
    }
}
