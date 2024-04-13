using _3mpacador4.Presentacion.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento.Produccion
{
    public partial class frmOp : Form
    {
        public frmOp()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmdetallelote lote = new frmdetallelote();

            AddOwnedForm(lote);
            lote.ShowDialog();
        }
    }
}
