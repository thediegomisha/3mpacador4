using _3mpacador4.Presentacion.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.R00t
{
    public partial class FrmMod : Form
    {
        public FrmMod()
        {
            InitializeComponent();
        }

        private void btnSubirDoc_Click(object sender, EventArgs e)
        {
          //  VarIngresoPeso = cboLote.Text;
            FrmAgregarDoc F = new FrmAgregarDoc();
            F.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
