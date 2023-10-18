using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           // info();

          lblversion.Text = Application.ProductVersion + "   ";
        }
            
        private void cmd_Aceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal.FrmBienvenida bienvenida = new Principal.FrmBienvenida();
            bienvenida.ShowDialog();
            FrmPrincipal  form = new FrmPrincipal ();
            form.Show();
         // 
           
        }

        public void info()
        {
            System.Deployment.Application.ApplicationDeployment ver;
            ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
            lblversion.Text = ver.CurrentVersion.ToString() + "   ";
            //lblDatabase.Text = nombress[4].Substring(9) + "   ";
        }

        private void cmd_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void txtlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
