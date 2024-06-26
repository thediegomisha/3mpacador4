﻿using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Mantenimiento.Produccion;
using _3mpacador4.Presentacion.R00t;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Presentacion.Sistema;
using _3mpacador4.Presentacion.Trazabilidad;
using _3mpacador4.Properties;

namespace _3mpacador4.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private Form FormularioActivo;
        private int intentosErroneos = 0;
        private const int MAX_INTENTOS_ERRONEOS = 3;
        public event EventHandler TextBoxClicked;
        //   private string nombreObjetoClicleado;
        private formR00t formRoot;

        //    public string nombreusuario { get; set; } = "";

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
            PanelGerencia.Visible = false;
            PanelProduccion.Visible = false;
            PanelCalidad.Visible = false;
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
            if (PanelGerencia.Visible)
                PanelGerencia.Visible = false;
            if (PanelProduccion.Visible)
                PanelProduccion.Visible = false;
            if (PanelCalidad.Visible)
                PanelCalidad.Visible = false;

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
                    TxtVersion.Text = deployment.CurrentVersion.ToString() + "   ";
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
            var form = new frmCliente();
            form.ShowDialog();

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
            var form = new frmColaborador();
            form.ShowDialog();
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
            var form = new frmTerminal();
            form.ShowDialog();
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
            ocultarSubMenu();
            var form = new frmUsuarios();
            form.ShowDialog();
        }
     
       private void btnImpresora_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new FrmPrinter();
            form.ShowDialog();
        }

        private void btnperiodo_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new frmCampania();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FRptPackigCalibre());
        }

        private void btnActualizaFProduccion_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FActualizaFechaProduccion());
        }

      
        private void Gerencia_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelGerencia);
        }
        private void rptDashBoard_Click(object sender, EventArgs e)
        {

        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelProduccion);
        }

        private void txtDatabase_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            TextBoxClicked?.Invoke(this, EventArgs.Empty);

            formRoot = new formR00t(FuncionDespuesValidacion, IncrementarIntentosErroneos);
            formRoot.Show();
        }

        private void IncrementarIntentosErroneos()
        {
            intentosErroneos++;
            if (intentosErroneos >= MAX_INTENTOS_ERRONEOS)
            {
                MessageBox.Show("Se ha alcanzado el número máximo de intentos erróneos. Se reportará al administrador.");
                // Aquí puedes agregar lógica adicional si lo deseas
            }
        }
        private void FuncionDespuesValidacion()
        {
            // Lógica a ejecutar después de que la contraseña sea válida
            formRoot.Hide();
            FrmMod root = new FrmMod();
            root.ShowDialog();
            root.Dispose(); // Liberar los recursos asociados al formulario FrmMod
                            // Si deseas cerrar formRoot después de abrir FrmMod, puedes hacerlo aquí
            intentosErroneos = 0;

            if (formRoot != null)
            {
                formRoot.Close();
                formRoot.Dispose();
            }
        }

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(PanelCalidad);
        }

        private void btnAutSalida_Click(object sender, EventArgs e)
        {
            FrmAutorizacion salida = new FrmAutorizacion();
            salida.ShowDialog();
        }

        private void btnPresen_cajas_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            var form = new frmpresen_cajas();
            form.ShowDialog();
        }

        private void btn_DescarteGral_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new RptDescarteGeneral());
        }
              

     
        private void btnMuestreo_Click(object sender, EventArgs e)
        {
            var form = new FMuestreo();
            AbrirFormularioHijo(new FMuestreo());
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FRptKardexLote());
        }

        private void btnPrecioCalire_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FPrecioCalibre());
        }

        private void btnAvancePersonal_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new FRptAvancePersonal());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new frmOp());
        }

     
    }
}