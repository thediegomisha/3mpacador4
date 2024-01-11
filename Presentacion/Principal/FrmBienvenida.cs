using System;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Principal
{
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();
        }

        public string NombreDesdeLogin { get; set; }

        public string ApaternoDesdeLogin { get; set; }
        //   int cont = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1) Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            Opacity -= 0.1;
            if (Opacity == 0)
            {
                timer2.Stop();
                Close();
            }
        }

        private void FrmBienvenida_Load(object sender, EventArgs e)
        {
            Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
            lblusername.Text = NombreDesdeLogin + " " + ApaternoDesdeLogin;
        }
    }
}