using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Presentacion.Sistema;
using _3mpacador4.Properties;
using Microsoft.VisualBasic;

using System.Net;

namespace _3mpacador4.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            personalizado();
           
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            informacion();
        }

        private Form FormularioActivo = null;
        private void AbrirFormularioHijo(Form FormularioHijo)
        {
            if (FormularioActivo != null)
                FormularioActivo.Close();
            FormularioActivo = FormularioHijo;
            FormularioHijo.TopLevel = false;
            FormularioHijo.FormBorderStyle= FormBorderStyle.None;   
            FormularioHijo.Dock= DockStyle.Fill;
            PanelFormularioHijo.Controls.Add(FormularioHijo);
            PanelFormularioHijo.Tag = FormularioHijo;
            FormularioHijo.BringToFront();
            FormularioHijo.Show();

        }
              
        private void personalizado()
        {
            panelPesos.Visible = false;
            panelReportes.Visible  = false;
            panelSistema.Visible = false;
            panelMantenimiento.Visible = false;
        }

        private void ocultarSubMenu()
        {
               if(panelPesos.Visible == true)
                    panelPesos.Visible = false;
               if(panelReportes.Visible == true)
                panelReportes.Visible = false;
               if(panelSistema.Visible == true)
                panelSistema.Visible = false;
               if (panelMantenimiento.Visible == true)
                panelMantenimiento.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible= true;
            }
            else
            {
                subMenu.Visible= false; 
            }
        }
        public void informacion()
        {
            try
            {

                string FileVer = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;


                // Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://sites.google.com/site/stprmareadeti/gestor-de-descarga-de-sintesis-gds/GDS.txt?attredirects=0&d=1")
                // Dim response As System.Net.HttpWebResponse = request.GetResponse()
                // Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                // Dim newestversion As String = sr.ReadToEnd()
                // PARA SABER LA VERSION DEL PROGRAMA 
                string currentversion = Application.ProductVersion;

                // If newestversion.Contains(currentversion) Then
                // MsgBox("su versión es la mas actual")
                // Else
                // MsgBox("Existe una Versión mas actual")
                // '  System.Diagnostics.Process.Start("https://sites.google.com/site/stprmareadeti/gestor-de-descarga-de-sintesis-gds")
                // End If


                string cadenaconexion = Settings.Default.ConecctionString;
                string[] nombress = cadenaconexion.Split(';');

                IPHostEntry host;
                string LocalIp = "?";
                host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host.AddressList)
                    if(ip.AddressFamily.ToString() == "InterNetwork")
                {
                        LocalIp= ip.ToString();
                        TxtIp.Text = LocalIp.ToString() +" ";
                }
              //  LBLUSUARIO.Text = UCase(Login.datalistado.SelectedCells.Item(2).Value) + "  ";

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Deployment.Application.ApplicationDeployment ver;
                    ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                    TxtVersion.Text = ver.CurrentVersion.ToString() + "   ";
                    lblDatabase.Text = nombress[4].Substring(9) + "   ";

                }
                else
                    TxtVersion.Text = Application.ProductVersion + "   ";
                lblDatabase.Text = nombress[4].Substring(9) + "   ";

                // TxtVersion.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString & "  "
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
            FrmPuertos form = new FrmPuertos();
            form.ShowDialog();
           
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            FrmConexion form = new FrmConexion();
            form.ShowDialog();
           
        }

        private void BtnPesosDiversos_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            FrmPesosDiversos from = new FrmPesosDiversos();
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new RptBoletaPesado());
        }

       private void button11_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new RptTrazabilidad());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
            AbrirFormularioHijo(new TicketCajas());
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application .Exit ();
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

        private void PanelFormularioHijo_Paint(object sender, PaintEventArgs e)
        {

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
    }
    }



