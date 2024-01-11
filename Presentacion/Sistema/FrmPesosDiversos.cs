using System;
using System.Windows.Forms;
using _3mpacador4.Properties;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmPesosDiversos : Form
    {
        public FrmPesosDiversos()
        {
            InitializeComponent();
            desabilitar();
        }

        private void FrmPesosDiversos_Load(object sender, EventArgs e)
        {
            cargarinicial();
        }

        public void desabilitar()
        {
            txtjavaverde.Enabled = false;
            txtjavaazul.Enabled = false;
            txtpaleta.Enabled = false;
            txtcajacarton.Enabled = false;
            txtcajaplasticablanca.Enabled = false;
        }

        private void cargarinicial()
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    if (bloque.chkjavaverde)
                    {
                        chkjavaverde.Checked = true;
                        txtjavaverde.Text = bloque.javaverde.ToString();
                    }
                    else
                    {
                        chkjavaverde.Checked = false;
                        txtjavaverde.Text = bloque.javaverde.ToString();
                    }

                    if (bloque.chkjavaazul)
                    {
                        chkjavaazul.Checked = true;
                        txtjavaazul.Text = bloque.javaazul.ToString();
                    }
                    else
                    {
                        chkjavaazul.Checked = false;
                        txtjavaazul.Text = bloque.javaazul.ToString();
                    }

                    if (bloque.chkpaleta)
                    {
                        chkpaleta.Checked = true;
                        txtpaleta.Text = bloque.paleta.ToString();
                    }
                    else
                    {
                        chkpaleta.Checked = false;
                        txtpaleta.Text = bloque.paleta.ToString();
                    }

                    if (bloque.chkcajacarton)
                    {
                        chkcajacarton.Checked = true;
                        txtcajacarton.Text = bloque.cajacarton.ToString();
                    }
                    else
                    {
                        chkcajacarton.Checked = false;
                        txtcajacarton.Text = bloque.cajacarton.ToString();
                    }

                    if (bloque.chkcajaplasticablanca)
                    {
                        chkcajaplasticablanca.Checked = true;
                        txtcajaplasticablanca.Text = bloque.cajaplasticablanca.ToString();
                    }
                    else
                    {
                        chkcajaplasticablanca.Checked = false;
                        txtcajaplasticablanca.Text = bloque.cajaplasticablanca.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void guardar()
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    if (chkjavaverde.Checked)
                        bloque.chkjavaverde = true;
                    else
                        bloque.chkjavaverde = false;
                    if (chkjavaazul.Checked)
                        bloque.chkjavaazul = true;
                    else
                        bloque.chkjavaazul = false;
                    if (chkpaleta.Checked)
                        bloque.chkpaleta = true;
                    else
                        bloque.chkpaleta = false;
                    if (chkcajacarton.Checked)
                        bloque.chkcajacarton = true;
                    else
                        bloque.chkcajacarton = false;
                    if (chkcajaplasticablanca.Checked)
                        bloque.chkcajaplasticablanca = true;
                    else
                        bloque.chkcajaplasticablanca = false;

                    if (txtjavaverde.Text != string.Empty) bloque.javaverde = double.Parse(txtjavaverde.Text);

                    if (txtjavaazul.Text != string.Empty) bloque.javaazul = double.Parse(txtjavaazul.Text);

                    if (txtpaleta.Text != string.Empty) bloque.paleta = double.Parse(txtpaleta.Text);

                    if (txtcajacarton.Text != string.Empty) bloque.cajacarton = double.Parse(txtcajacarton.Text);
                    if (txtcajaplasticablanca.Text != string.Empty)
                        bloque.cajaplasticablanca = double.Parse(txtcajaplasticablanca.Text);


                    bloque.Save();
                    MessageBox.Show("Datos Guardados Satisfactoriamente !!!");
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void chkjavaverde_CheckedChanged(object sender, EventArgs e)
        {
            if (chkjavaverde.Checked)
                txtjavaverde.Enabled = true;
            else
                txtjavaverde.Enabled = false;
        }

        private void chkjavaazul_CheckedChanged(object sender, EventArgs e)
        {
            if (chkjavaazul.Checked)
                txtjavaazul.Enabled = true;
            else
                txtjavaazul.Enabled = false;
        }

        private void chkpaleta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpaleta.Checked)
                txtpaleta.Enabled = true;
            else
                txtpaleta.Enabled = false;
        }

        private void chkcajacarton_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcajacarton.Checked)
                txtcajacarton.Enabled = true;
            else
                txtcajacarton.Enabled = false;
        }

        private void chkcajaplasticablanca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcajaplasticablanca.Checked)
                txtcajaplasticablanca.Enabled = true;
            else
                txtcajaplasticablanca.Enabled = false;
        }

        private void FrmPesosDiversos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}