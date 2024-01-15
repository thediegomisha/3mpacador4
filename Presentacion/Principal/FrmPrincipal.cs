using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Presentacion.Sistema;
using _3mpacador4.Presentacion.Trazabilidad;
using _3mpacador4.Properties;

namespace _3mpacador4.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private Form FormularioActivo;

        public FrmPrincipal()
        {
            InitializeComponent();
            personalizado();
        }

        public string NombreDesdeLogin { get; set; }
        public string ApaternoDesdeLogin { get; set; }

        private void Principal_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private void AbrirFormularioHijo(Form FormularioHijo)
        {
            if (FormularioActivo != null)
                FormularioActivo.Close();
            FormularioActivo = FormularioHijo;
            FormularioHijo.TopLevel = false;
            FormularioHijo.FormBorderStyle = FormBorderStyle.None;
            FormularioHijo.Dock = DockStyle.Fill;
            PanelFormularioHijo.Controls.Add(FormularioHijo);
            PanelFormularioHijo.Tag = FormularioHijo;
            FormularioHijo.BringToFront();
            FormularioHijo.Show();
        }

        private void personalizado()
        {
            panelPesos.Visible = false;
            panelReportes.Visible = false;
            panelSistema.Visible = false;
            panelMantenimiento.Visible = false;
            panelTrazabilidad.Visible = false;
            PanelBuscar.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (panelPesos.Visible)
                panelPesos.Visible = false;
            if (panelReportes.Visible)
                panelReportes.Visible = false;
            if (panelSistema.Visible)
                panelSistema.Visible = false;
            if (panelMantenimiento.Visible)
                panelMantenimiento.Visible = false;
            if (PanelBuscar.Visible)
                PanelBuscar.Visible = false;
            if (panelTrazabilidad.Visible)
                panelTrazabilidad.Visible = false;
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        public void informacion()
        {
            try
            {
                var FileVer = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
                var currentversion = Application.ProductVersion;


                var cadenaconexion = Settings.Default.ConecctionString;
                var nombress = cadenaconexion.Split(';');

                // Obtener dirección IP local
                IPHostEntry host;
                var LocalIp = "?";
                host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        LocalIp = ip.ToString();
                        TxtIp.Text = LocalIp + " ";
                    }

                LBLUSUARIO.Text = NombreDesdeLogin + " " + ApaternoDesdeLogin + "  ";

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    var deployment = ApplicationDeployment.CurrentDeployment;
                    TxtVersion.Text = deployment.CurrentVersion + "   ";
                    lblDatabase.Text = nombress[4].Substring(9) + "   ";
                }
                else

                {
                    TxtVersion.Text = currentversion + "   ";
                }

                lblDatabase.Text = nombress[4].Substring(9) + "   ";

                txtServer.Text = nombress[0].Substring(7) + "  ";
                txtNombreEquipo.Text = Environment.MachineName + "  ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmenu1_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelPesos);
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSistema);
        }

        private void btnPuertoSerie_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new FrmPuertos();
            form.ShowDialog();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new FrmConexion();
            form.ShowDialog();
        }

        private void BtnPesosDiversos_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var from = new FrmPesosDiversos();
            from.ShowDialog();
        }

        private void btnRecepcionPesos_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new IngresoPesos());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new RptGeneral());
        }

        private void btnSubmenu2_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelReportes);
        }


        private void button12_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new RptBoletaPesado());
        }

       private void button10_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new TicketCajas());
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDescarte_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new IngresoDescarte());
        }

        private void btnMantenimiento_Click_1(object sender, EventArgs e)
        {
            MostrarSubMenu(panelMantenimiento);
        }

     private void btnClientes_Click_1(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmCliente());
        }

        private void btnAcopiador_Click_1(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmAcopiador());
        }

        private void btnProductores_Click_1(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmProductor());
        }

        private void btnTrazabilidadP_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelTrazabilidad);
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new frmProducto();
            form.ShowDialog();
        }

        private void btnColaborador_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmAltaDNI());
        }

        private void btnProductores_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmProductor());
        }

        private void btnAcopiador_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmAcopiador());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelBuscar);
        }

        private void btnCLP_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new frmProductorCLP();
            form.ShowDialog();
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmTerminal());
        }

        private void btnProceso_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FProgramaProceso());
        }

        private void btnReniec_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new FrmReniec();
            form.ShowDialog();
        }

        private void btnJornal_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FJornalTurno());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

        }

        //private void btnTerminal_Click(object sender, EventArgs e)
        //{
        //    ocultarSubMenu();
        //    AbrirFormularioHijo(new frmTerminal());

        //}

        private void btnImprimeCalibre_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FrmImprimeCalibre());
        }
    }
}