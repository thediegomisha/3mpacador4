using System;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmReniec : Form
    {
        private ClConexion claseconnect = new ClConexion();

        public FrmReniec()
        {
            InitializeComponent();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            cargarinicial();
        }
        //{
        //    try
        //    {

        //    if (ConexionGral.conexion.State == ConnectionState.Closed)
        //    {
        //        ConexionGral.conectar();
        //    }

        //    string cadenaconexion = Settings.Default.ConecctionString;
        //    string[] nombress = cadenaconexion.Split(';');

        //    this.txtservidor.Text = nombress[0].Substring(7);


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        ConexionGral.desconectar();
        //    }
        //}

        private void cargarinicial()
        {
            try
            {
                {
                    var bloque = Settings.Default;


                    txtservidor.Text = bloque.txtreniec;
                    txttoken.Text = bloque.token_reniec;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    bloque.txtreniec = txtservidor.Text;
                    bloque.token_reniec = txttoken.Text
                        ;
                    bloque.Save();
                    MessageBox.Show(@"Datos Guardados Satisfactoriamente !!!");
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Close();
            Settings.Default.Reload();
        }

        private void txtservidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) txttoken.Focus();
        }


        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) btnprobar.Focus();
        }

        private void btnprobar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13) btnGuardar.Focus();
        }

        //private void btnprobar_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.txtservidor.Text) & !string.IsNullOrEmpty(this.txttoken.Text))
        //    {
        //        string nuevaconexion = "server=" + this.txtservidor.Text + ";user=" + this.txttoken.Text + " ;Connect Timeout=";

        //        if (claseconnect.ProbarConexion(nuevaconexion))
        //        {
        //            MessageBox.Show("Conexion exitosa", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Conexion erronea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Todos los datos son necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void FrmConexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}