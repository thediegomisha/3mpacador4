using _3mpacador4.Properties;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.txtjavaverde.Enabled = false;
            this.txtjavaazul.Enabled = false;
            this.txtpaleta.Enabled = false;
            this.txtcajacarton .Enabled = false;
            this.txtcajaplasticablanca .Enabled = false;

          
        }
        private void cargarinicial()
        {
            try
            {                          
              {
                var bloque = Settings.Default;

                if (bloque.chkjavaverde == true)
                {
                    this.chkjavaverde.Checked = true;
                    this.txtjavaverde.Text = bloque.javaverde.ToString();
                }else
                    {
                        this.chkjavaverde.Checked = false;
                        this.txtjavaverde.Text = bloque.javaverde.ToString();
                    }            
                if (bloque.chkjavaazul == true)
                {
                    this.chkjavaazul.Checked = true;
                    this.txtjavaazul.Text = bloque.javaazul.ToString();
                    }
                    else
                    {
                        this.chkjavaazul.Checked = false;
                        this.txtjavaazul.Text = bloque.javaazul.ToString();
                    }
                if (bloque.chkpaleta == true)
                {
                    this.chkpaleta.Checked = true;
                    this.txtpaleta.Text = bloque.paleta.ToString();
                }
                    else
                    {
                        this.chkpaleta.Checked = false;
                        this.txtpaleta.Text = bloque.paleta.ToString();
                    }
                if (bloque.chkcajacarton == true)
                {
                    this.chkcajacarton.Checked = true;
                    this.txtcajacarton.Text = bloque.cajacarton.ToString();
                }
                    else
                    {
                        this.chkcajacarton.Checked = false;
                        this.txtcajacarton.Text = bloque.cajacarton.ToString();
                    }
                if (bloque.chkcajaplasticablanca == true)
                {
                    this.chkcajaplasticablanca.Checked = true;
                    this.txtcajaplasticablanca.Text = bloque.cajaplasticablanca.ToString();
                }
                    else
                    {
                        this.chkcajaplasticablanca.Checked = false;
                        this.txtcajaplasticablanca.Text = bloque.cajaplasticablanca.ToString();
                    }

            }
             }
            catch (Exception ex)
            {

                Interaction.MsgBox(ex.Message, Constants.vbCritical);


            }

        }
        private void guardar( )
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    if (this.chkjavaverde.Checked == true)
                    {
                        bloque.chkjavaverde = true;                                    
                    }
                    else
                    {
                        bloque.chkjavaverde = false;                        
                    }
                    if (this.chkjavaazul.Checked == true)
                    {
                        bloque.chkjavaazul = true;                      
                    }
                    else
                    {
                        bloque.chkjavaazul = false;                     
                    }
                    if (this.chkpaleta.Checked == true)
                    {
                        bloque.chkpaleta = true;
                    }
                    else
                    {
                        bloque.chkpaleta = false;
                    }
                    if (this.chkcajacarton.Checked == true)
                    {
                        bloque.chkcajacarton = true;
                    }
                    else
                    {
                        bloque.chkcajacarton = false;
                    }
                    if (this.chkcajaplasticablanca.Checked == true)
                    {
                            bloque.chkcajaplasticablanca = true;
                    }
                    else
                    {
                        bloque.chkcajaplasticablanca = false;
                    }

                    if(txtjavaverde.Text != String.Empty)
                    {
                        bloque.javaverde = Double.Parse(this.txtjavaverde.Text.ToString());
                    }

                    if(txtjavaazul .Text != String.Empty)
                    {
                        bloque.javaazul = Double.Parse(this.txtjavaazul.Text.ToString());
                    }
                  
                    if(txtpaleta .Text != String.Empty)
                    {
                        bloque.paleta = Double.Parse(this.txtpaleta.Text.ToString());
                    }
                   
                    if(txtcajacarton.Text != String.Empty)
                    {
                        bloque.cajacarton = Double.Parse(this.txtcajacarton.Text.ToString());
                    }
                   if(txtcajaplasticablanca.Text!= String.Empty)
                    {
                        bloque.cajaplasticablanca = Double.Parse(this.txtcajaplasticablanca.Text.ToString());
                    }
                   

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
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void chkjavaverde_CheckedChanged(object sender, EventArgs e)
        {
            if (chkjavaverde.Checked == true)
            {
                txtjavaverde.Enabled = true;
            }
            else
            {
                txtjavaverde.Enabled = false;
            }
        }

        private void chkjavaazul_CheckedChanged(object sender, EventArgs e)
        {
            if(chkjavaazul.Checked == true)
            {
                txtjavaazul.Enabled = true;
            }
            else
            {
                txtjavaazul.Enabled = false;
            }
        }

        private void chkpaleta_CheckedChanged(object sender, EventArgs e)
        {
            if(chkpaleta.Checked == true)
            {
                txtpaleta.Enabled = true;
            }
            else
            {
                txtpaleta.Enabled = false;
            }
        }

        private void chkcajacarton_CheckedChanged(object sender, EventArgs e)
        {
            if(chkcajacarton.Checked == true)
            {
                txtcajacarton.Enabled = true;
            }
            else
            {
                txtcajacarton.Enabled = false;
            }
        }

        private void chkcajaplasticablanca_CheckedChanged(object sender, EventArgs e)
        {
            if(chkcajaplasticablanca.Checked == true)
            {
                txtcajaplasticablanca.Enabled= true;
            }
            else
            {
                txtcajaplasticablanca.Enabled = false;
            }
        }

        private void FrmPesosDiversos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
