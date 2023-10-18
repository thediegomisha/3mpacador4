using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO.Ports;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Management;
using _3mpacador4;
using _3mpacador4.Properties;

namespace _3mpacador4.Presentacion.Sistema
{
    public partial class FrmPuertos : Form
    {
        public FrmPuertos()
        {
            InitializeComponent();
            cbDesactivado();
            GetSerialPortNames();
        }

        private void FrmPuertos_Load(object sender, EventArgs e)
        {
            // VARIABLES PARA LA BALANZA RECEPCION
            if (Settings.Default.checked_bal1 == true)
            {
                this.chk_recepcion.Checked = true;
                this.CBParidadRecp.Text = null;
            }
            else
            {
                this.chk_recepcion.Checked = false;
            }

            if (Settings.Default.ParidadRecp == "0")
            {
                this.CBParidadRecp.Text = "Ninguno";
            }
            else if (Settings.Default.ParidadRecp == "1")
            {
                this.CBParidadRecp.Text = "Impar";
            }
            else if (Settings.Default.ParidadRecp == "2")
            {
                this.CBParidadRecp.Text = "Par";
            }

            this.CBRECEPCION.Text = Settings.Default.select_bal1.ToString();
            this.CBBaudioRecp.Text = Settings.Default.BaudiosRecp.ToString();
            this.CBDatosRecp.Text = Settings.Default.bitDatosRecp.ToString();
            this.CBParidadRecp.Text = Settings.Default.ParidadRecp.ToString();
            this.CBParadaRecp.Text = Settings.Default.ParadaRecp.ToString();

            // VARIABLES PARA LA BALANZA DESPACHO
            if (Settings.Default.checked_bal2 == true)
            {
                this.chk_Despacho.Checked = true;
                this.CBParidadDesp.Text = null;
            }

            else if (Settings.Default.checked_bal2 == false)
            {
                this.chk_Despacho.Checked = false;

                if (Settings.Default.ParidadDesp == "0")
                {
                    this.CBParidadDesp.Text = "Ninguno";
                }
                else if (Settings.Default.ParidadDesp == "1")
                {
                    this.CBParidadDesp.Text = "Impar";
                }
                else if (Settings.Default.ParidadDesp == "2")
                {
                    this.CBParidadDesp.Text = "Par";
                }

                this.CBDESPACHO.Text = Settings.Default.select_bal2.ToString();
                this.CBBaudiosDesp.Text = Settings.Default.BaudiosDesp.ToString();
                this.CBDatosDesp.Text = Settings.Default.bitDatosDesp.ToString();
                this.CBParidadDesp.Text = Settings.Default.ParidadDesp.ToString();
                this.CBParadaDesp.Text = Settings.Default.ParadaDesp.ToString();

            }
        }

        private void FrmPuertos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.chk_recepcion.Checked == true)
                {
                    Settings.Default.checked_bal1 = true;
                }
                else if (this.chk_recepcion.Checked == false)
                {
                    Settings.Default.checked_bal1 = false;
                }

                int codigoParidadRecp = 0;

                if (this.CBParidadRecp.Text == "Ninguno")
                {
                    codigoParidadRecp = (int)Parity.None;
                }
                else if (this.CBParidadRecp.Text == "Impar")
                {
                    codigoParidadRecp = (int)Parity.Odd;
                }
                else if (this.CBParidadRecp.Text == "Par")
                {
                    codigoParidadRecp = (int)Parity.Even;
                }

                int codigoparadaG = 0;

                if (this.CBParadaRecp.Text == "1")
                {
                    codigoparadaG = (int)StopBits.One;
                }
                else if (this.CBParadaRecp.Text == "2")
                {
                    codigoparadaG = (int)StopBits.Two;
                }
                else if (this.CBParadaRecp.Text == "1.5")
                {
                    codigoparadaG = (int)StopBits.OnePointFive;
                }
                else if (this.CBParadaRecp.Text == "0")
                {
                    codigoparadaG = (int)StopBits.None;
                }

                Settings.Default.select_bal1 = this.CBRECEPCION.Text;
                Settings.Default.BaudiosRecp = this.CBBaudioRecp.Text;
                Settings.Default.bitDatosRecp = this.CBDatosRecp.Text;
                Settings.Default.ParidadRecp = codigoParidadRecp.ToString();
                Settings.Default.ParadaRecp = codigoparadaG.ToString();

                if (this.chk_Despacho.Checked == true)
                {
                    Settings.Default.checked_bal2 = true;
                }
                else if (this.chk_Despacho.Checked == false)
                {
                    Settings.Default.checked_bal2 = false;
                }

                int codigoparidad = 0;

                if (this.CBParidadDesp.Text == "Ninguno")
                {
                    codigoparidad = (int)Parity.None;
                }
                else if (this.CBParidadDesp.Text == "Impar")
                {
                    codigoparidad = (int)Parity.Odd;
                }
                else if (this.CBParidadDesp.Text == "Par")
                {
                    codigoparidad = (int)Parity.Even;
                }

                int codigoparada = 0;

                if (this.CBParadaDesp.Text == "1")
                {
                    codigoparada = (int)StopBits.One;
                }
                else if (this.CBParadaDesp.Text == "2")
                {
                    codigoparada = (int)StopBits.Two;
                }
                else if (this.CBParadaDesp.Text == "1.5")
                {
                    codigoparada = (int)StopBits.OnePointFive;
                }
                else if (this.CBParadaDesp.Text == "0")
                {
                    codigoparada = (int)StopBits.None;
                }

                Settings.Default.select_bal2 = this.CBDESPACHO.Text;
                Settings.Default.BaudiosDesp = this.CBBaudiosDesp.Text;
                Settings.Default.bitDatosDesp = this.CBDatosDesp.Text;
                Settings.Default.ParidadDesp = codigoparidad.ToString();
                Settings.Default.ParadaDesp = codigoparada.ToString();

                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);

            }

        }

        public void GetSerialPortNames()
        {
            // Get a list of serial port names.
            string[] ports = SerialPort.GetPortNames();

            //   Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.d
            foreach (string sp in ports)
            {
                this.CBRECEPCION.Items.Add(sp);
                this.CBDESPACHO.Items.Add(sp);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(this.CBRECEPCION.Text) | !string.IsNullOrEmpty(this.CBDESPACHO.Text))
                {
                    if (CBRECEPCION.SelectedItem != CBDESPACHO.SelectedItem)
                    {
                        Interaction.MsgBox("Sin Problemas");
                    }
                    else
                    {
                        Interaction.MsgBox("Error, no puede seleccionar el mismo puerto COM");
                    }
                }
                else
                {
                    Interaction.MsgBox("Tiene que Seleccionar Puertos Disponibles");
                }
            }
            catch (Exception)
            {

            }
        }
            private void btnSalir_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void cbDesactivado()
        {
            CBBaudioRecp.Enabled = false;
            CBBaudiosDesp.Enabled  = false;
            CBDatosDesp.Enabled = false;
            CBDatosRecp.Enabled = false;
            CBRECEPCION.Enabled = false;
            CBDESPACHO.Enabled = false; 
            CBParadaDesp.Enabled = false;
            CBParadaRecp.Enabled = false;  
            CBParidadDesp.Enabled = false;
            CBParidadRecp.Enabled = false;
            
        }

        private void chk_recepcion_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_recepcion.Checked == true)
            {
              CBBaudioRecp.Enabled = true;
              CBDatosRecp.Enabled = true;
              CBRECEPCION.Enabled = true;
              CBParadaRecp.Enabled = true;
              CBParidadRecp.Enabled = true;
            }
            else
            {
                CBBaudioRecp.Enabled = false;
                CBDatosRecp.Enabled = false;
                CBRECEPCION.Enabled = false;
                CBParadaRecp.Enabled = false;
                CBParidadRecp.Enabled = false;
            }
        }

        private void chk_Despacho_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Despacho.Checked == true)
            {
                CBBaudiosDesp.Enabled = true;
                CBDatosDesp.Enabled = true;               
                CBDESPACHO.Enabled = true;
                CBParadaDesp.Enabled = true;              
                CBParidadDesp.Enabled = true;
            }
            else
            {
                CBBaudiosDesp.Enabled = false;
                CBDatosDesp.Enabled = false;
                CBDESPACHO.Enabled = false;
                CBParadaDesp.Enabled = false;
                CBParidadDesp.Enabled = false;
            }
        }
    }
    } 

