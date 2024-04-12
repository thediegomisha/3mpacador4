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
            if (FRptPackigCalibre.ls_ruta_pdf.Length > 0)
            {
                pvvisor.LoadFromFile(FRptPackigCalibre.ls_ruta_pdf);
            } 
            else if (FRptKardexLote.ls_ruta_pdf.Length > 0) 
            {
                pvvisor.LoadFromFile(FRptKardexLote.ls_ruta_pdf);
            }
            else if (FRptAvancePersonal.ls_ruta_pdf.Length > 0)
            {
                pvvisor.LoadFromFile(FRptAvancePersonal.ls_ruta_pdf);
            }
                              
        }

        private void FVisorPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(FRptPackigCalibre.ls_ruta_pdf))
            {
                File.Delete(FRptPackigCalibre.ls_ruta_pdf);
            }
            else if (File.Exists(FRptKardexLote.ls_ruta_pdf))
            {
                File.Delete(FRptKardexLote.ls_ruta_pdf);
            }
            else if (File.Exists(FRptAvancePersonal.ls_ruta_pdf))
            {
                File.Delete(FRptAvancePersonal.ls_ruta_pdf);
            }
        }
    }
}
