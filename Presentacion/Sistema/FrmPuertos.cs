using System;
using System.IO.Ports;
using System.Windows.Forms;
using _3mpacador4.Properties;
using Microsoft.VisualBasic;

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
            if (Settings.Default.checked_bal1)
            {
                chk_recepcion.Checked = true;
                CBParidadRecp.Text = null;
            }
            else
            {
                chk_recepcion.Checked = false;
            }

            if (Settings.Default.ParidadRecp == "0")
                CBParidadRecp.Text = "Ninguno";
            else if (Settings.Default.ParidadRecp == "1")
                CBParidadRecp.Text = "Impar";
            else if (Settings.Default.ParidadRecp == "2") CBParidadRecp.Text = "Par";

            CBRECEPCION.Text = Settings.Default.select_bal1;
            CBBaudioRecp.Text = Settings.Default.BaudiosRecp;
            CBDatosRecp.Text = Settings.Default.bitDatosRecp;
            CBParidadRecp.Text = Settings.Default.ParidadRecp;
            CBParadaRecp.Text = Settings.Default.ParadaRecp;

            // VARIABLES PARA LA BALANZA DESPACHO
            if (Settings.Default.checked_bal2)
            {
                chk_Despacho.Checked = true;
                CBParidadDesp.Text = null;
            }
            else
            {
                chk_Despacho.Checked = false;
            }

         //   else if (Settings.Default.checked_bal2 == false)
          //  {
                if (Settings.Default.ParidadDesp == "0")
                    CBParidadDesp.Text = "Ninguno";
                else if (Settings.Default.ParidadDesp == "1")
                    CBParidadDesp.Text = "Impar";
                else if (Settings.Default.ParidadDesp == "2") CBParidadDesp.Text = "Par";

                CBDESPACHO.Text = Settings.Default.select_bal2;
                CBBaudiosDesp.Text = Settings.Default.BaudiosDesp;
                CBDatosDesp.Text = Settings.Default.bitDatosDesp;
                CBParidadDesp.Text = Settings.Default.ParidadDesp;
                CBParadaDesp.Text = Settings.Default.ParadaDesp;
           // }
        }

        private void GuardarValores()
        {
            try
            {
                if (chk_recepcion.Checked)
                    Settings.Default.checked_bal1 = true;
                else if (chk_recepcion.Checked == false) Settings.Default.checked_bal1 = false;

                var codigoParidadRecp = 0;

                if (CBParidadRecp.Text == "Ninguno")
                    codigoParidadRecp = (int)Parity.None;
                else if (CBParidadRecp.Text == "Impar")
                    codigoParidadRecp = (int)Parity.Odd;
                else if (CBParidadRecp.Text == "Par") codigoParidadRecp = (int)Parity.Even;

                var codigoparadaG = 0;

                if (CBParadaRecp.Text == "1")
                    codigoparadaG = (int)StopBits.One;
                else if (CBParadaRecp.Text == "2")
                    codigoparadaG = (int)StopBits.Two;
                else if (CBParadaRecp.Text == "1.5")
                    codigoparadaG = (int)StopBits.OnePointFive;
                else if (CBParadaRecp.Text == "0") codigoparadaG = (int)StopBits.None;

                Settings.Default.select_bal1 = CBRECEPCION.Text;
                Settings.Default.BaudiosRecp = CBBaudioRecp.Text;
                Settings.Default.bitDatosRecp = CBDatosRecp.Text;
                Settings.Default.ParidadRecp = codigoParidadRecp.ToString();
                Settings.Default.ParadaRecp = codigoparadaG.ToString();

                if (chk_Despacho.Checked)
                    Settings.Default.checked_bal2 = true;
                else if (chk_Despacho.Checked == false) Settings.Default.checked_bal2 = false;

                var codigoparidad = 0;

                if (CBParidadDesp.Text == "Ninguno")
                    codigoparidad = (int)Parity.None;
                else if (CBParidadDesp.Text == "Impar")
                    codigoparidad = (int)Parity.Odd;
                else if (CBParidadDesp.Text == "Par")
                    codigoparidad = (int)Parity.Even;

                var codigoparada = 0;

                if (CBParadaDesp.Text == "1")
                    codigoparada = (int)StopBits.One;
                else if (CBParadaDesp.Text == "2")
                    codigoparada = (int)StopBits.Two;
                else if (CBParadaDesp.Text == "1.5")
                    codigoparada = (int)StopBits.OnePointFive;
                else if (CBParadaDesp.Text == "0")
                    codigoparada = (int)StopBits.None;

                Settings.Default.select_bal2 = CBDESPACHO.Text;
                Settings.Default.BaudiosDesp = CBBaudiosDesp.Text;
                Settings.Default.bitDatosDesp = CBDatosDesp.Text;
                Settings.Default.ParidadDesp = codigoparidad.ToString();
                Settings.Default.ParadaDesp = codigoparada.ToString();

                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void FrmPuertos_FormClosing(object sender, FormClosingEventArgs e)
        {
           GuardarValores();
        }

        public void GetSerialPortNames()
        {
            // Get a list of serial port names.
            var ports = SerialPort.GetPortNames();

            //   Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.d
            foreach (var sp in ports)
            {
                CBRECEPCION.Items.Add(sp);
                CBDESPACHO.Items.Add(sp);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(CBRECEPCION.Text) | !string.IsNullOrEmpty(CBDESPACHO.Text))
                {
                    if (CBRECEPCION.SelectedItem != CBDESPACHO.SelectedItem)
                        MessageBox.Show("Sin Problemas");
                    else if(CBRECEPCION.SelectedItem == CBDESPACHO.SelectedItem)
                        MessageBox.Show( "Atento, esta utilizando el mismo Puerto COM");
                    //else
                    //    Interaction.MsgBox("Error, no puede seleccionar el mismo puerto COM");
                }
                else
                {
                    Interaction.MsgBox("Tiene que Seleccionar Puertos Disponibles");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Revisar Puertos:  {ex.GetType().Name} - {ex.Message}\\n{ex.StackTrace}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbDesactivado()
        {
            CBBaudioRecp.Enabled = false;
            CBBaudiosDesp.Enabled = false;
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
            if (chk_recepcion.Checked)
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
                CBRECEPCION.Text = null;
            }
        }

        private void chk_Despacho_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Despacho.Checked)
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
                CBDESPACHO.Text = null;
            }
        }

        private void FrmPuertos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}