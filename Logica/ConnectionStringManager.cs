using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace _3mpacador4.Logica
{
    public class ConnectionStringManager
    {

        public static string GetConnectionString(string connectionStringName)
        {

            var appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];
            return connStringSettings.ConnectionString;

        }
        public static void SaveConnectionString(string connectionStringName, string connectionString)
        {

            var appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;
            appconfig.Save();

        }

        public static List<string> GetConnectionStringNames()
        {

            var cns = new List<string>();
            var appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings)


                cns.Add(cn.Name);

            return cns;

        }


        public static string GetFirstConnectionStringName()
        {

            return GetConnectionStringNames().FirstOrDefault();

        }

        public static string GetFirstConnectionString()
        {

            return GetConnectionString(GetFirstConnectionStringName());

        }



    }
}
