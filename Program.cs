using System;
using System.Windows.Forms;
using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Sistema;
using _3mpacador4.Presentacion.Principal;

namespace _3mpacador4
{
    internal static class Program
    {
        /// <summary>
        ///     Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }
    }
}