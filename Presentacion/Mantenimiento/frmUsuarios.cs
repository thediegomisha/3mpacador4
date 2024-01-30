using _3mpacador4.Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            var aux = new Colaborador();

            frmAltaDNI F = new frmAltaDNI();
            F.ShowDialog();
           // MostrarColaborador();
        }
    }
}
