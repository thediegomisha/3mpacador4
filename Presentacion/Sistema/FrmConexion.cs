using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmConexion : Form
    {
        private readonly ClConexion claseconnect = new ClConexion();

        public FrmConexion()
        {
            InitializeComponent();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var cadenaconexion = Settings.Default.ConecctionString;
                var nombress = cadenaconexion.Split(';');

                txtservidor.Text = nombress[0].Substring(7);
                txtPort.Text = nombress[1].Substring(5);
                txtusuario.Text = nombress[2].Substring(5);
                txtpass.Text = nombress[3].Substring(9);
                txtBd.Text = nombress[4].Substring(9);
                txttime.Text = nombress[5].Substring(16);
                txtunicode.Text = nombress[6].Substring(8);
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
            if (!string.IsNullOrEmpty(txtservidor.Text) & !string.IsNullOrEmpty(txtBd.Text) &
                !string.IsNullOrEmpty(txtusuario.Text))
                try
                {
                    // If conexion.State = ConnectionState.Closed Then
                    // conectar()
                    // 'conexion.Open()s
                    // End If
                    Settings.Default.ConecctionString = "server=" + txtservidor.Text + ";port=" + txtPort.Text +
                                                        ";user=" + txtusuario.Text + ";password=" + txtpass.Text +
                                                        ";database=" + txtBd.Text + " ;Connect Timeout=" +
                                                        txttime.Text + ";Unicode=True";
                    Settings.Default.Save();
                    MessageBox.Show("La Conexion se guardo correctamente. El sistema se Reiniciara ", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var F = new FrmPrincipal();
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
            else
                MessageBox.Show("Todos los datos son necesarios", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
            Settings.Default.Reload();
        }

        private void txtservidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txtusuario.Focus();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txtBd.Focus();
        }

        private void txtBd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txttime.Focus();
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txtpass.Focus();
        }

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txtPort.Focus();
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) btnprobar.Focus();
        }

        private void btnprobar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) btnGuardar.Focus();
        }

        private void btnprobar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtservidor.Text) & !string.IsNullOrEmpty(txtPort.Text) &
                !string.IsNullOrEmpty(txtusuario.Text))
            {
                var nuevaconexion = "server=" + txtservidor.Text + ";port=" + txtPort.Text + ";user=" +
                                    txtusuario.Text + ";password=" + txtpass.Text + ";database=" + txtBd.Text +
                                    " ;Connect Timeout=" + txttime.Text + "";

                if (claseconnect.ProbarConexion(nuevaconexion))
                    MessageBox.Show("Conexion exitosa", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Conexion erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Todos los datos son necesarios", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void FrmConexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}