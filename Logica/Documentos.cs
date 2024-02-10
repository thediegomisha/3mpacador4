using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Logica
{
    public class Documentos
    {
        private int idexpediente;
        private int idlote;
        private string nombre;
        private byte[] documento;
        private string extension;

        public int Id { get => idexpediente; set => idexpediente = value; }
        public int Idlote { get => idlote; set => idlote = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte[] Documento { get => documento; set => documento = value; }
        public string Extension { get => extension; set => extension = value; }
       

        public string AgregarDocumentos()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblexpediente_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_idlote", idlote);
                comando.Parameters.AddWithValue("p_nombre", nombre);
                comando.Parameters.AddWithValue("p_documento", documento);
                comando.Parameters.AddWithValue("p_extension", extension);

                comando.ExecuteNonQuery();

                ConexionGral.desconectar();
                return "Agregado con exito";

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
