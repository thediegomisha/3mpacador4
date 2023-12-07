using System;
using Devart.Data.MySql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using _3mpacador4.Logica;
using System.IO.Ports;
using _3mpacador4.Properties;
using Devart.Common;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Sistema;
using System.Globalization;
using _3mpacador4.Presentacion.Reporte;

namespace _3mpacador4
{
    public partial class IngresoPesos : Form
    {
        CultureInfo en = new CultureInfo("es-MX");
        private int contador = 0;
        private int correlativo = 0;
        private int aux = 0;

        private int a1, b1, c1, d1, e2, f1, g1, h1;

        private int a, b, c, d;

        private string POSICION_INICIAL;
        private string stringinicio;
        private string mostrarcaracter;
        private string salidacontrol;

        private string w = Convert.ToString('w');  // HEXADECIMAL
        private string n = Convert.ToString('n');  // HEXADECIMAL
        private string cero = Convert.ToString('0');  // HEXADECIMAL
        private string menos = Convert.ToString('-');
        private string CR = Convert.ToString('\r');
        private string LF = Convert.ToString('\n');
        private string PUNTO = Convert.ToString('.');

        private void sppuerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string DatoInterrupcion;
            try
            {
                DatoInterrupcion = this.sppuerto.ReadExisting();
                PuertaAccesoInterrupcion(DatoInterrupcion);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("ERROR DATOS INTERRUPCION " + ex.Message, Constants.vbCritical);
            }
        }
        
        private string MAS = Convert.ToString('+');

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void cbProducto_DropDownClosed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbProducto.Text))
            {
                mostrarlistadovariedad();
            }
        }

        private delegate void DelegadoAcceso(string Adicionartexto);

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                borrarmensajeerror();
                if (validarcampos())
                {
                    InsertarRegistro();
                    mostrarconsulta();
                    txtPesoManual.Focus();
                    txtPesoManual.Text = string.Empty;                  
                }                
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void titulosjavasvisible()
        {
           // lblpeso.Visible = false;
            lblcantjavas.Visible = false;
            lbltarajaba .Visible = false;
            lbltaraparh .Visible = false;
            lblpjaba .Visible = false;
            lblpesojabas.Visible = false;
            txttarajaba.Visible = false;
            txttaraParihuela.Visible = false;
            cbjabas.Visible = false;           
        }

        public void titulosjavasinvisible()
        {
            // lblpeso.Visible = false;
            lblcantjavas.Visible = true;
            lbltarajaba.Visible = true;
            lbltaraparh.Visible = true;
            lblpjaba.Visible = true;
            lblpesojabas.Visible = true;
            txttarajaba.Visible = true;
            txttaraParihuela.Visible = true;
            cbjabas.Visible = true;
        }
            public IngresoPesos()
        {
            InitializeComponent();
            conectarserial();
            cargarinicial();
        }

        private void IngresoPesos_Load(object sender, EventArgs e)
        {
   //         pictureBoxEspera.Visible = true;
            this.timer1.Interval = 100;  // Un segundo
            this.timer1.Start();
            // temporizador();
            txtPesoManual.Visible = false;
            titulosjavasvisible();
            mostrarLote();
        //    pictureBoxEspera.Visible = false;
        }

        private void cbMetodoCultivo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbMetodoCultivo.Text))
                {
                    int Id = Convert.ToInt32(cbMetodoCultivo.SelectedValue.ToString());
                }

                if (cbMetodoCultivo.Text == "Nuevo ...")
                {
                  frmCultivo form = new frmCultivo();
                  form.ShowDialog();
                  mostrarMetCultivo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTipoServicio_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbTipoServicio.Text))
                {
                    int Id = Convert.ToInt32(cbTipoServicio.SelectedValue.ToString());                  
                }
                if (cbTipoServicio.Text == "Nuevo ...")
                {
                    frmServicio form = new frmServicio();
                    form.ShowDialog();
                    mostrarservicio();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error "  + ex.Message, Constants.vbCritical);
            }           
        }

        private void AccesoFromPrincipal(string TextoForm)
        {
            //// --------------------------------
            ////--------------------------------
            //////' ''CADENA A ANALIZAR POR CORREGIR SECUENCIA
            ///         w n  0 0 0 0 0 . 0 k g
            ///         AGRICOLA DE SUR PISCO - PALTA 
            ///         
            /// 
            /// ///         w n 0 0 0 0 0 0 . 0 k g
            /// 
            /// 
            ///          CARACTERES A ANALIZAR
            ////// ' '' ASCII     :    US,GS    84.4,kg
            ////// ' '' ASCII     :    U   S  ,  G  S               8  4  .  4    k  g CR LF
            ////// ' '' HEX       :    55 53 2C 47 53 20 20 20 31 30 37 2E 32 2C 6B 67 0D 0A
            ////// ' '' CANTIDAD  :    01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18
            try
            {
                if (!string.IsNullOrEmpty(TextoForm))
                {
                    POSICION_INICIAL = Strings.InStr(TextoForm, PUNTO).ToString();
                    stringinicio = Strings.Mid(TextoForm, (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 6d), 12);


                    if (stringinicio.StartsWith(w))
                    {
                        string textoini = null;
                        textoini = Strings.Left(stringinicio, 3);

                        if ((textoini == (w + n + cero)   ))
                        {
                            mostrarcaracter = Strings.Mid(TextoForm, (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 12d), 8);
                            this.lblpeso.Text = Strings.FormatNumber(Conversion.Val(mostrarcaracter.Replace("+", " ")), 2); // funcion REPLACE, REEMPLAZA EL SIGNO + POR UN ESPACIO EN BLANCO 05/12/19

                        }
                        else
                        {
                            mostrarcaracter = Strings.Mid(TextoForm, (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 8d), 12);
                            this.lblpeso.Text = Strings.FormatNumber(Conversion.Val(mostrarcaracter.Replace(" ", " ")), 2); // funcion REPLACE, REEMPLAZA EL SIGNO + POR UN ESPACIO EN BLANCO 05/12/19
                        }
                    }
                                       
                    //////ENVIA LA SALIDA A LBLTODO SI ES DIFERENTE DE VACIO
        else
                    {
                        this.sppuerto.DiscardInBuffer();
                    }
                }
                else
                {
                    this.lblpeso.Text = "REVISE CONEXION";
                }
            }

catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void cbjabas_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
               if (!String.IsNullOrEmpty(cbjabas.Text))
                {
                    int Id = Convert.ToInt32(cbjabas.SelectedValue.ToString());
                    if (cbjabas.Text == "Nuevo ...")
                    {
                        frmJabas form = new frmJabas();
                        form.ShowDialog();
                      mostrarjabas();
                    }
                  //  label35.Text = (cbjabas.GetItemText(cbjabas.SelectedValue));
                    //label22.Text = Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show ("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PuertaAccesoInterrupcion(string BufferIn)
        {
            object[] TextoInterrupcion = new object[] { BufferIn };
            DelegadoAcceso DelegadoInterrupcion;
            DelegadoInterrupcion = new DelegadoAcceso(AccesoFromPrincipal);
            base.BeginInvoke(DelegadoInterrupcion, TextoInterrupcion);
        }
       public void conectarserial()
        {
            try
            {
                string nompuerto = Settings.Default.select_bal1;
                string baudios = Settings.Default.BaudiosRecp;
                string bit_datos = Settings.Default.bitDatosRecp;
                string paridad = Settings.Default.ParidadRecp;
                string bit_parada = Settings.Default.ParadaRecp;

                {
                    var bloque = this.sppuerto;
                    bloque.PortName = nompuerto;
                    bloque.BaudRate = Convert.ToInt32(baudios);
                    bloque.DataBits = Convert.ToInt32(bit_datos);
                    bloque.Parity = (Parity)Convert.ToInt32(paridad);
                    bloque.StopBits = (StopBits)Convert.ToInt32(bit_parada);
                    bloque.DiscardNull = true;
                    bloque.ReceivedBytesThreshold = 36;
                    bloque.ReadBufferSize = 36;
                    // .ReadTimeout = 500
                    bloque.Open();
                    if (bloque.IsOpen)
                    {
                        this.lblestado.Text = "CONECTADO A LA BALANZA SATISFACTORIAMENTE !!!";
                    }
                    else
                    {
                        Interaction.MsgBox("CONEXION FALLIDA!", MsgBoxStyle.Critical);
                        bloque.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("AUN NO SE HA CONFIGURADO EL PUERTO SERIE !!! " + ex.Message, MsgBoxStyle.Critical);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            multiplicajabas();
        }

        private void mostrarlistadoproducto()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblproducto_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbProducto;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idproducto"] = 0;
                        dr["nombre"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idproducto";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }

        }

        private void mostrarproductor()
        {
            MySqlCommand comando;
          //  MostrarAnimacionEspera();
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblproductor_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

               {
                    var withBlock = this.cbProductor;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["clp"] = 0;
                        dr["RAZON SOCIAL"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "RAZON SOCIAL";
                        withBlock.ValueMember = "clp";
                        withBlock.SelectedIndex = -1;
                     //   poblarPais();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

      
        private void mostrarclientes()
        {
            MySqlCommand comando;
        //    MostrarAnimacionEspera();
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcliente_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbcliente;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["ruc"] = 0;
                        dr["razon_social"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "razon_social";
                        withBlock.ValueMember = "ruc";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarLote()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbllote_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cboLote;
                    //if (datos.Rows.Count != 0)
                    //{
                        var dr = datos.NewRow();
                        dr["idlote"] = 0;
                        dr["numlote"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "numlote";
                        withBlock.ValueMember = "idlote";
                        withBlock.SelectedIndex = -1;
            //        OcultarAnimacionEspera();
                    //}
                    //else
                    //{
                    //    withBlock.DataSource = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void cbProductor_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbProductor.Text))
                {
                    lblCLP.Text = Convert.ToString(cbProductor.SelectedValue.ToString());

                    //int iniciocadena1 = cbProductor.Text.IndexOf('|');


                    //label35.Text = cbProductor.Text.Substring(0, iniciocadena1);

                    poblarPais();
                    if (cbProductor.Text == "Nuevo ...")
                    {
                        frmProductor2 form = new frmProductor2();
                        form.ShowDialog();
                        mostrarproductor();                       
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        //private void MostrarAnimacionEspera()
        //{
        //    pictureBoxEspera.Visible = true;
        //    //  buttonConsultar.Enabled = false;
        //    // Otros controles que desees deshabilitar durante la espera
        //}

        //private void OcultarAnimacionEspera()
        //{
        //    pictureBoxEspera.Visible = false;
        //    //   buttonConsultar.Enabled = true;
        //    // Otros controles que desees habilitar después de la espera
        //}
        private void cbcliente_DropDownClosed(object sender, EventArgs e)
        {           
            try
            {
                if (!String.IsNullOrEmpty(cbcliente.Text))
                {
                    lblRUC.Text = cbcliente.GetItemText(cbcliente.SelectedValue.ToString());

                   int iniciocadena = cbcliente.Text.IndexOf('-');

                    if (cbcliente.Text == "Nuevo ...")
                    {
                       
                        frmCliente2 form = new frmCliente2();
                        form.ShowDialog();
                        mostrarclientes();
                    }else
                    {
                        label12.Text = cbcliente.Text.Substring(0, iniciocadena);
                    }
                   
                    mostrarproductor();
                    mostrarMetCultivo();
                    mostrarlistadoproducto();
                    mostrarAcopiador();
                    cbvariedad.SelectedIndex = -1;
                
                    mostrarturno();
                    mostrarservicio();

                    mostrarjabas();
                    multiplicajabas();

                 //   OcultarAnimacionEspera();

                   
                }

            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void cboLote_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cboLote.Text))
                {
                   label21 .Text = cboLote.GetItemText(cboLote.SelectedValue.ToString());
                    label4.Text = (cboLote.Text.ToString());
                    mostrarclientes();
                    //int combo = Convert.ToInt32(label21.ToString());
                    //combo += - 1;
                    //label4 .Text = combo.ToString();


                    if (cboLote.Text == "Nuevo ...")
                    {
                        frmLote  form = new frmLote();
                        form.ShowDialog();
                        mostrarLote();
                    }
                    else
                    {
                        mostrarproductor();
                        mostrarMetCultivo();
                        mostrarlistadoproducto();
                        mostrarAcopiador();
                        //   mostrarlistadovariedad();
                        cbvariedad.SelectedIndex = -1;
                        lblRUC.Text = string.Empty;
                        lblCLP.Text = string.Empty;
                        mostrarturno();
                        mostrarservicio();
                        mostrarMaterialCosecha();
                        mostrarjabas();
                        multiplicajabas();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void chkf_ing_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void chkPesoManual_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void chkPesoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPesoManual.Checked == true)
            {
                txtPesoManual.Visible = true;
            }
            else
            {
                txtPesoManual.Visible = false;
            }
        }

        private void mostrarlistadovariedad()
        {
           MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                   ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblvariedad_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value = cbProducto.GetItemText(cbProducto.SelectedValue);
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbvariedad;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["ID"] = 0;
                        dr["variedad"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "variedad";
                        withBlock.ValueMember = "ID";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (MySqlException  ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }
        private void mostrarturno()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblturno_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
               // label3.Text = cbMetodoCultivo.GetItemText(cbMetodoCultivo.SelectedValue);
                //   comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value = cbProducto.GetItemText(cbProducto.SelectedValue);
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cboturno;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                          withBlock.ValueMember = "idturno";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }
        private void mostrarMetCultivo()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
                
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbMetodoCultivo;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idmetodocultivo"] = 0;
                        dr["nombre"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                          withBlock.ValueMember = "idmetodocultivo";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }

        }

        private void txtPesoManual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!String.IsNullOrEmpty( txtPesoManual.Text ))
                {
                    btnguardar.PerformClick();
                }
                else
                {
                    MessageBox.Show("Ingrese el Peso Correcto");
                }              
            }           
        }

        private void mostrarservicio()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbltiposervicio_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
        
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbTipoServicio;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idtiposervicio"] = 0;
                        dr["nombre"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idtiposervicio";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Instancio el Formulario Hijo al Padre
            ImprimirPesos FH = new ImprimirPesos();
            //Indico al Formulario quien es el Propietario
            AddOwnedForm(FH);
            FH.ShowDialog();
         
        }

        private void mostrarjabas()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbljabas_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbjabas;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idjabas"] = 0;
                        dr["numjabas"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "numjabas";
                        withBlock.ValueMember = "idjabas";
                        withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void InsertarRegistro()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                //var comando = new MySqlCommand("INSERT INTO tblticketpesaje (numdoc, horallegada, horapesaje, fecha_ticket, idmetodocultivo, idtiposervicio, idproducto, idlote, idvariedad, idcliente, num_guia, tara_jaba, tara_pallet, cant_jabas, peso_bruto, peso_jabas, idturno, idclp)" + '\r'
                //    + "VALUES(p_numdoc, p_horallegada, p_horapesaje, p_fecha_ticket, p_idmetodocultivo, p_idtiposervicio, p_idproducto, p_idlote, p_idvariedad, p_idcliente, p_num_guia, p_tara_java, p_tara_pallet, p_cant_jabas, p_peso_bruto, p_peso_jabas, p_turno, p_idclp)", ConexionGral.conexion);
              
                var comando = new MySqlCommand("usp_tblticketpesaje_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                float tarajaba = float.Parse(txttarajaba.Text);
                float taraparihuela = float.Parse(txttaraParihuela.Text);
                float pesobruto = float.Parse(lblpeso.Text);
                float pesobrutoManual = float.Parse(txtPesoManual.Text);


                comando.Parameters.AddWithValue("p_numdoc", this.lblcorrelativo.Text);
                comando.Parameters.AddWithValue("p_horallegada", DateTime.Now);
                comando.Parameters.AddWithValue("p_horapesaje", DateTime.Now);
                comando.Parameters.AddWithValue("p_fecha_ticket", Convert.ToDateTime(this.fpesaje.Text));               
                comando.Parameters.AddWithValue("p_idmetodocultivo", MySqlType.Int).Value = cbMetodoCultivo.GetItemText(cbMetodoCultivo.SelectedValue);
                comando.Parameters.AddWithValue("p_idtiposervicio", MySqlType.Int).Value = cbTipoServicio.GetItemText(cbTipoServicio.SelectedValue);
                comando.Parameters.AddWithValue("p_idproducto", MySqlType.Int).Value = cbProducto.GetItemText(cbProducto.SelectedValue);
                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = cboLote.GetItemText(cboLote.SelectedValue.ToString());
                comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value = cbvariedad.GetItemText(cbvariedad.SelectedValue);
                comando.Parameters.AddWithValue("p_idcliente", MySqlType.Int).Value = label12.Text;
                comando.Parameters.AddWithValue("p_idacopiador", MySqlType.Int).Value = label35.Text;

                if (txtGuiaRemision.Text == String.Empty)
                {
                    MessageBox.Show("Error, Tiene que Ingresar el Numero de Guia", "GUIA REMISION");
                    return;                    
                }
                else
                    comando.Parameters.AddWithValue("p_num_guia", MySqlType.Text).Value =this.txtGuiaRemision.Text;

                if (tarajaba > 0 ) 
                {
                    comando.Parameters.AddWithValue("p_tara_java", MySqlType.Double).Value = txttarajaba.Text;
                }
                else
                {                 
                    MessageBox.Show("Error, el Peso tiene que ser mayor que 0", "TARA JABA");
                    return;
                }

                if (taraparihuela > 0)
                {
                    comando.Parameters.AddWithValue("p_tara_pallet", MySqlType.Double).Value = txttaraParihuela.Text;
                }
                else
                {
                    MessageBox.Show("Error, el Peso tiene que ser mayor que 0", "TARA PARIHUELA");
                    return;
                }

                comando.Parameters.AddWithValue("p_cant_jabas", MySqlType.Double).Value = (cbjabas.GetItemText(cbjabas.SelectedValue));

                if (chkPesoManual.Checked ==false)
                {
                    if (pesobruto > 0)
                    {
                        comando.Parameters.AddWithValue("p_peso_bruto", MySqlType.Double).Value = lblpeso.Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, el Peso tiene que ser mayor que 0", "PESO BALANZA");
                        return;
                    }
                }
                else
                {
                    if (pesobrutoManual > 0)
                    {
                        comando.Parameters.AddWithValue("p_peso_bruto", MySqlType.Double).Value = txtPesoManual .Text;
                    }
                    else
                    {
                        MessageBox.Show("Error, el Peso tiene que ser mayor que 0", "PESO BALANZA");
                        return;
                    }
                }
                
                if (!String.IsNullOrEmpty(cboturno.Text))
                {
                    comando.Parameters.AddWithValue("p_turno", MySqlType.Int).Value = cboturno.GetItemText(cboturno.SelectedValue);
                }else
                {
                    MessageBox.Show("Error, El Turno debe ser Ingresado", "TURNO");
                    return;
                }

                if (!String.IsNullOrEmpty(lblCLP.Text))
                {
                    comando.Parameters.AddWithValue("p_idclp", MySqlType.Int).Value =(lblCLP.Text);
                }
                else
                {
                    MessageBox.Show("Error, El Turno debe ser Ingresado", "TURNO");
                    return;
                }

                comando.ExecuteNonQuery();
                MessageBox.Show("PESO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                // limpiarcampos()
            //    this.chkcapturapeso.Checked = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
            // cuentacorrelativo_BG()
        }

        private void btnCerrarLote_Click(object sender, EventArgs e)
        {
            cerrarlote();
            mostrarLote();
            this.datalistado.DataSource = null;
            totalneto.Text = "0";
            lblcantjabas.Text = "0";
        }

        private void cbAcopiador_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbAcopiador.Text))
                {
                   // lblRUC.Text = cbcliente.GetItemText(cbcliente.SelectedValue.ToString());

                    int iniciocadena = cbAcopiador.Text.IndexOf('-');

                    if (cbAcopiador.Text == "Nuevo ...")
                    {
                        frmAcopiador2 form = new frmAcopiador2();
                        form.ShowDialog();
                        mostrarAcopiador();
                    }
                    else
                    {
                        label35.Text = cbAcopiador.Text.Substring(0, iniciocadena);
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void multiplicajabas()
        {
            try
            {
                if (!String.IsNullOrEmpty(cbjabas.Text) && (!String.IsNullOrEmpty(txttarajaba.Text)))
                {
                    Double resultado = Double.Parse(cbjabas.GetItemText(cbjabas.SelectedItem)) * Double.Parse(txttarajaba.Text);
                    (lblpesojabas.Text) = resultado.ToString();
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

       
        private void cbMatCosecha_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbMatCosecha.Text))
                {
                    if (cbMatCosecha.Text == "Nuevo ...")
                    {
                        frmMatCosecha form = new frmMatCosecha();
                        form.ShowDialog();
                       mostrarMaterialCosecha();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private bool validarcampos()
        {
            try
            {
                bool ok = true;
                if(txttarajaba.Text == "")
                {
                    ok = false;
                    errorProvider1.SetError(txttarajaba, "Ingrese un numero valido");
                }
                return ok;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbMatCosecha_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataRowView filaSeleccionada = cbMatCosecha.SelectedItem as DataRowView;

                if (filaSeleccionada != null)
                {
                    // Obtener el texto seleccionado del ComboBox
                    string resultado = filaSeleccionada.Row["nombre"].ToString();

                    if (!string.IsNullOrEmpty(resultado))
                    {
                    // Verificar si el texto seleccionado es igual a algo
                    if (resultado == "JABAS")
                    {
                        titulosjavasinvisible();
                    }
                    }
                }
            }
            catch (Exception)
                {
                    throw;
                }           
        }

        private void borrarmensajeerror()
        {
            try
            {
                errorProvider1.SetError(txttarajaba, "");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mostrarconsulta()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticketpesaje_Selectlote", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = (cboLote.Text.ToString()); ;


                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        //tamanio();
                        //ocultar_columnas();
                        //actualizardatos();
                        sumaneto();
                        contar();

                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }

        }

        public void contar()
        {
            int contarfila = datalistado.RowCount - 1;
            int contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }
            LBLCONTAR.Text = Strings.FormatNumber(contador, 0);
        }
        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);

                }
                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void poblarPais()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblhabilitadodestino_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_clp", MySqlType.Int).Value = (lblCLP.Text.ToString()); ;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    //var withBlock = this.cboLote;
                    if (datos != null && datos.Rows.Count > 0)
                    {

                    lblpais1.Text = datos.Rows[0]["ORIGEN"].ToString();

                        //    ////  lblmetodo.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //    //lblproducto.Text = datos.Rows[0]["PRODUCTO"].ToString();
                        //    ////  lblservicio.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //    ////  lblacopiador.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //    //// lblguiaingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //    ////  lblruc_dni.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //    //lblclp.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();
                        //    //lblvariedad.Text = datos.Rows[0]["VARIEDAD"].ToString();
                        //    //lblfechaingreso.Text = datos.Rows[0]["FECHA PESAJE"].ToString();
                        //    ////    lblhoraingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();

                        //    //lblpesoneto.Text = (datos.Rows[0]["PESO NETO"].ToString());
                        //    //lblcantjabas.Text = (datos.Rows[0]["CANT JABAS"].ToString());




                    }
                    else
                    {
                        lblpais1.Text =  "No Existe en la Lista !!!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void cargarinicial()
        {
            try
            {
                {
                    var bloque = Settings.Default;
                                       
                       this.txttarajaba.Text = bloque.javaverde.ToString();
                       this.txttaraParihuela.Text = bloque.paleta.ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void mostrarAcopiador()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbacopiador_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

               {
                    var withBlock = this.cbAcopiador;
                    //if (datos.Rows.Count != 0)
                    //{
                        var dr = datos.NewRow();
                        dr["ruc"] = 0;
                        dr["razon_social"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "razon_social";
                        withBlock.ValueMember = "ruc";
                        withBlock.SelectedIndex = -1;
                    //}
                    //else
                    //{
                    //    withBlock.DataSource = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarMaterialCosecha()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblmatcosecha_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cbMatCosecha;
                    //if (datos.Rows.Count != 0)
                    //{
                    var dr = datos.NewRow();
                    dr["idmatcosecha"] = 0;
                    dr["nombre"] = "Nuevo ...";
                    datos.Rows.InsertAt(dr, 0);

                    withBlock.DataSource = datos;
                    withBlock.DisplayMember = "nombre";
                    withBlock.ValueMember = "idmatcosecha";
                    withBlock.SelectedIndex = -1;                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }
        private void cerrarlote()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbllote_Update", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = cboLote.GetItemText(cboLote.SelectedValue.ToString());


                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cboLote;
                    //if (datos.Rows.Count != 0)
                    //{
                   
                    withBlock.DataSource = datos;
                    withBlock.DisplayMember = "numlote";
                    withBlock.ValueMember = "idlote";
                    withBlock.SelectedIndex = -1;
                    MessageBox.Show("El Lote se cerro Satisfactoriamente !!!");
                    //}
                    //else
                    //{
                    //    withBlock.DataSource = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }


    }
}
