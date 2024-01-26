using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Entidad
{
    public class Packing_calibre_cab
    {
        public string nom_planta { get; set; }
        public int idproducto { get; set; }
        public string producto { get; set; }
        public int idacopiador { get; set; }
        public string nom_acopiador { get; set; }
        public string ruc_a { get; set; }
        public DateTime fecha_produccion { get; set; }
        public string idclp { get; set; }
        public int idlote { get; set; }
        public string lote { get; set; }
        public string num_guia { get; set; }
        public int idvariedad { get; set; }
        public string variedad { get; set; }
        public string idcliente { get; set; }
        public string nom_cliente { get; set; }
        public string ruc_c { get; set; }
        public decimal cantidad_jabas { get; set; }
        public decimal peso_bruto { get; set; }
        public decimal peso_jabas { get; set; }
        public decimal peso_neto { get; set; }
        public decimal peso_promedio { get; set; }


    }
}
