﻿using System;

namespace _3mpacador4.Entidad
{
    public class Programa_proceso
    {
        public int idproceso { get; set; }
        public DateTime fecha_proceso { get; set; }
        public int idlote { get; set; }
        public string numlote { get; set; }
        public int idgrupo_turno { get; set; }
        public int iddestino { get; set; }
        public string destino { get; set; }
        public int idcategoria { get; set; }
        public string categoria { get; set; }
        public int idpresentacion { get; set; }
        public string presentacion { get; set; }
        public string nombre { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public int idterminal { get; set; }
        public int idusuario { get; set; }
        public string flag_estado { get; set; }

        public int cantidad_jabas { get; set; }
        public decimal kilos { get; set; }
    }
}