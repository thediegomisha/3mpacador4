using System;
using System.Data;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4.Logica
{
    internal static class ConexionGral
    {
        public static MySqlConnection conexion = new MySqlConnection();

        public static void conectar()
        {
            try
            {
                conexion.Close();
                // conexion.ConnectionString = "server=localhost;user=theathoq; password='<N@n@y15>'; database=empacadora; Connect Timeout=60; Unicode=True;";


                conexion.ConnectionString = Settings.Default.ConecctionString;
                // conexion.ConnectionString = "server=192.0.0.69; Port=3309;user=root; password='nanayis'; database=alcides; Connect Timeout=60;"Unicode=True;""
                // conexion.ConnectionString = "server=192.0.0.69; Port=3301;user=root; password='nanayis'; database=alcides; Connect Timeout=60;"
                // conexion.ConnectionString = "server=181.224.247.108; Port=3309;user=root; password='nanayis'; database=alcides; Connect Timeout=60;"
                conexion.Open();
                // MessageBox.Show("Conectado al Server 3mpacadora Satisfactoriamente");
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        public static void desconectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }
    }
}