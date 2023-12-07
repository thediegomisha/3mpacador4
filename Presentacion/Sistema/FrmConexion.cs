using _3mpacador4.Logica;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Presentacion;
using _3mpacador4.Properties;


namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmConexion : Form
    {
        private ClConexion claseconnect = new ClConexion();

        public FrmConexion()
        {
            InitializeComponent();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            try
            {
                
            if (ConexionGral.conexion.State == ConnectionState.Closed)
            {
                ConexionGral.conectar();
            }

            string cadenaconexion = Settings.Default.ConecctionString;
            string[] nombress = cadenaconexion.Split(';');

            this.txtservidor.Text = nombress[0].Substring(7);
            this.txtPort.Text = nombress[1].Substring(5);
            this.txtusuario.Text = nombress[2].Substring(5);
            this.txtpass.Text = nombress[3].Substring(9);
            this.txtBd.Text = nombress[4].Substring(9);
            this.txttime.Text = nombress[5].Substring(16);
            this.txtunicode.Text = nombress[6].Substring(8);

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtservidor.Text) & !string.IsNullOrEmpty(this.txtBd.Text) & !string.IsNullOrEmpty(this.txtusuario.Text))
            {
                try
                {
                    // If conexion.State = ConnectionState.Closed Then
                    // conectar()
                    // 'conexion.Open()s
                    // End If

                    Settings.Default.ConecctionString = "server=" + this.txtservidor.Text + ";port=" + this.txtPort.Text + ";user=" + this.txtusuario.Text + ";password=" + this.txtpass.Text + ";database=" + this.txtBd.Text + " ;Connect Timeout=" + this.txttime.Text +   ";Unicode=True";
                    Settings.Default.Save();
                    MessageBox.Show("La Conexion se guardo correctamente. El sistema se Reiniciara ", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmPrincipal F = new FrmPrincipal();
                    F.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ConexionGral.desconectar();
                }
            }
            else
            {
                MessageBox.Show("Todos los datos son necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Settings.Default.Reload();
        }

        private void txtservidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtusuario.Focus();
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtBd.Focus();
            }
        }

        private void txtBd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txttime.Focus();
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtpass.Focus();
            }
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.txtPort.Focus();
            }
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnprobar.Focus();
            }
        }

        private void btnprobar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                this.btnGuardar.Focus();
            }
        }

        private void btnprobar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtservidor.Text) & !string.IsNullOrEmpty(this.txtPort.Text) & !string.IsNullOrEmpty(this.txtusuario.Text))
            {
                string nuevaconexion = "server=" + this.txtservidor.Text + ";port=" + this.txtPort.Text + ";user=" + this.txtusuario.Text + ";password=" + this.txtpass.Text + ";database=" + this.txtBd.Text + " ;Connect Timeout=" + this.txttime.Text + "";

                if (claseconnect.ProbarConexion(nuevaconexion))
                {
                    MessageBox.Show("Conexion exitosa", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Conexion erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los datos son necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmConexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
       
    }
    

