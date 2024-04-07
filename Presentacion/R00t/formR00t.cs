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
    public partial class formR00t : Form
    {
        public formR00t()
        {
            InitializeComponent();
        }

        private void cmd_Aceptar_Click(object sender, EventArgs e)
        {
            FrmMod root = new FrmMod();
            root.ShowDialog();
            this.Close();

        }
    }
}
