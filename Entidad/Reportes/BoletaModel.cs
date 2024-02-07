using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Entidad
{
    public class BoletaModel

    {
        // Cabecera
        public int Numlote { get; set; }
        public int IdCliente { get; set;}
        public int IdProductor { get; set;}
        public string MetCultivo { get; set;}
        public string Producto { get; set;}
        public string tServicio { get; set;}
        public string Acopiador { get; set;}
        public string NumCLP { get; set;}
        public string Numguia{ get; set;}
        public string Variedad{ get; set;}
        public DateTime fIngreso { get; set;}




        //Contenido




        //Pie de Pagina
        public int Items { get; set;}
        public int CantJabas { get; set;}
        public double Total { get; set;}
    }
}
