using System;
using System.IO;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Reporte;


namespace _3mpacador4.Presentacion.Trazabilidad
{
    public partial class FVisorPDF : Form
    {
        public FVisorPDF()
        {
            InitializeComponent();
        }

        private void FVisorPDF_Load(object sender, EventArgs e)
        {
            pvvisor.LoadFromFile(FRptPackigCalibre.ls_ruta_pdf);                      
        }

        private void FVisorPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(FRptPackigCalibre.ls_ruta_pdf))
            {
                File.Delete(FRptPackigCalibre.ls_ruta_pdf);
            }
        }
    }
}
