﻿using System;
using System.Windows.Forms;
using _3mpacador4.Properties;
using Devart.Data.MySql;

namespace _3mpacador4.Logica
{
    public class ClConexion
    {
        private readonly MySqlConnection ConexionBD = new MySqlConnection(Settings.Default.ConecctionString);

        public bool ProbarConexion(string nuevaconexion)
        {
            bool ProbarConexionRet = default;
            ConexionBD.ConnectionString = nuevaconexion;
            if (AbrirConexion())
            {
                ProbarConexionRet = true;
                CerrarConexion();
            }
            else
            {
                ProbarConexionRet = false;
            }

            return ProbarConexionRet;
        }

        private bool AbrirConexion()
        {
            bool AbrirConexionRet = default;
            try
            {
                ConexionBD.Open();
                AbrirConexionRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                AbrirConexionRet = false;
            }

            return AbrirConexionRet;
        }

        private bool CerrarConexion()
        {
            bool CerrarConexionRet = default;
            try
            {
                ConexionBD.Close();
                CerrarConexionRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CerrarConexionRet = false;
            }

            return CerrarConexionRet;
        }
    }
}