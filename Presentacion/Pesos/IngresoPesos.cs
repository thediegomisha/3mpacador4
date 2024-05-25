using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Presentacion;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.R00t;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using Microsoft.VisualBasic;
using static QuestPDF.Helpers.Colors;

namespace _3mpacador4
{
   public partial class IngresoPesos : Form
    {
        private formR00t formRoot;
        private int intentosErroneos = 0;
        private const int MAX_INTENTOS_ERRONEOS = 3;
        public event EventHandler CheckBoxClicked;

        private readonly string cero = Convert.ToString('0'); // HEXADECIMAL
        private readonly string n = Convert.ToString('n'); // HEXADECIMAL
        private readonly string PUNTO = Convert.ToString('.');

        private readonly string w = Convert.ToString('w'); // HEXADECIMAL
        private int a, b, c, d;

        private int a1, b1, c1, d1, e2, f1, g1, h1;
        private int aux = 0;
        private int contador = 0;
        private int correlativo;
        private string CR = Convert.ToString('\r');
        private CultureInfo en = new CultureInfo("es-MX");
        private string LF = Convert.ToString('\n');

        private string MAS = Convert.ToString('+');
        private string menos = Convert.ToString('-');
        private string mostrarcaracter;

        private string POSICION_INICIAL;
        private string salidacontrol;
        private string stringinicio;

      //  private FrmPrincipal form1;  ///

        public IngresoPesos()
        {
            InitializeComponent();

            this.Load += IngresoPesos_Load;

            conectarserial();
            cargarinicial();

        }

        // Método público que devuelve el texto del Label
        public string VarIngresoPeso { get; set; } = "";
        public string VarNumlote { get; set; } = "";

        public bool doubleclick { get; set; } = false;

        public string Varcantjabas{ get; set; } = "";
        public string Varpesoneto { get; set; } = "";


        private void sppuerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Es más eficiente leer los datos en un búfer
                var bytesToRead = sppuerto.BytesToRead;
                var buffer = new byte[bytesToRead];
                sppuerto.Read(buffer, 0, bytesToRead);

                // Convierte los bytes a una cadena utilizando la codificación adecuada
                var datosRecibidos = Encoding.UTF8.GetString(buffer);

                // Llama a la función de manejo de datos
                PuertaAccesoInterrupcion(datosRecibidos);
            }
            catch (Exception ex)
            {
                //  Console.WriteLine($"ERROR DATOS INTERRUPCION: {ex.GetType().Name} - {ex.Message}\n{ex.StackTrace}");

                MessageBox.Show($"ERROR DATOS INTERRUPCION:  {ex.GetType().Name} - {ex.Message}\\n{ex.StackTrace}",
                    @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void cbProducto_DropDownClosed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbProducto.Text)) mostrarlistadovariedad();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                borrarmensajeerror();
                if (validarcampos())
                {
                    if (chkPesoManual.Checked == false || (chkPesoManual.Checked == true && txtPesoManual.Text != null))
                    {
                        InsertarRegistro();
                        mostrarconsulta();
                        txtPesoManual.Focus();
                        txtPesoManual.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Error en btnguardar_Click - ", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void titulosjavasvisible()
        {
            // lblpeso.Visible = false;
            lblcantjavas.Visible = false;
            lbltarajaba.Visible = false;
            lbltaraparh.Visible = false;
            lblpjaba.Visible = false;
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

        private void IngresoPesos_Load(object sender, EventArgs e)
        {
            //         pictureBoxEspera.Visible = true;
            timer1.Interval = 100; // Un segundo
            timer1.Start();
            // temporizador();
            txtPesoManual.Visible = false;
            RecuperaCorrelativo();
            titulosjavasvisible();
            PrepGrid();
            // mostrarLote();
        }

        private void cbMetodoCultivo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbMetodoCultivo.Text))
                {
                    var Id = Convert.ToInt32(cbMetodoCultivo.SelectedValue.ToString());
                }

                if (cbMetodoCultivo.Text == "Nuevo ...")
                {
                    var form = new frmCultivo();
                    form.ShowDialog();
                    mostrarMetCultivo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoServicio_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbTipoServicio.Text))
                {
                    var Id = Convert.ToInt32(cbTipoServicio.SelectedValue.ToString());
                }

                if (cbTipoServicio.Text == "Nuevo ...")
                {
                    var form = new frmServicio();
                    form.ShowDialog();
                    mostrarservicio();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
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
                    stringinicio = Strings.Mid(TextoForm, (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 7d), 14);


                    if (stringinicio.StartsWith(w))
                    {
                        string textoini = null;
                        textoini = Strings.Left(stringinicio, 3);

                        if (textoini == w + n + cero)
                        {
                            mostrarcaracter = Strings.Mid(TextoForm,
                                (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 10d), 7);
                            lblpeso.Text =
                                Strings.FormatNumber(Conversion.Val(mostrarcaracter.Replace("+", " ")),
                                    2); // funcion REPLACE, REEMPLAZA EL SIGNO + POR UN ESPACIO EN BLANCO 05/12/19
                        }
                        else
                        {
                            mostrarcaracter = Strings.Mid(TextoForm,
                                (int)Math.Round(Convert.ToDouble(POSICION_INICIAL) + 8d), 12);
                            lblpeso.Text =
                                Strings.FormatNumber(Conversion.Val(mostrarcaracter.Replace(" ", " ")),
                                    2); // funcion REPLACE, REEMPLAZA EL SIGNO + POR UN ESPACIO EN BLANCO 05/12/19
                        }
                    }

                    //////ENVIA LA SALIDA A LBLTODO SI ES DIFERENTE DE VACIO
                    else
                    {
                        sppuerto.DiscardInBuffer();
                    }
                }
                else
                {
                    lblpeso.Text = "REVISE CONEXION";
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
                if (!string.IsNullOrEmpty(cbjabas.Text))
                {
                    var Id = Convert.ToInt32(cbjabas.SelectedValue.ToString());
                    if (cbjabas.Text == "Nuevo ...")
                    {
                        var form = new frmJabas();
                        form.ShowDialog();
                        mostrarjabas();
                    }
                    //  label35.Text = (cbjabas.GetItemText(cbjabas.SelectedValue));
                    //label22.Text = Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PuertaAccesoInterrupcion(string BufferIn)
        {
            object[] TextoInterrupcion = { BufferIn };
            DelegadoAcceso DelegadoInterrupcion;
            DelegadoInterrupcion = AccesoFromPrincipal;
            BeginInvoke(DelegadoInterrupcion, TextoInterrupcion);
        }

        public void conectarserial()
        {
            try
            {
                var nompuerto = Settings.Default.select_bal1;
                var baudios = Settings.Default.BaudiosRecp;
                var bit_datos = Settings.Default.bitDatosRecp;
                var paridad = Settings.Default.ParidadRecp;
                var bit_parada = Settings.Default.ParadaRecp;

                {
                    var bloque = sppuerto;
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
                        lblestado.Text = "CONECTADO A LA BALANZA SATISFACTORIAMENTE !!!";
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
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblproducto_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbProducto;
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }


        private void mostrarproductor()
        {
            MySqlCommand comando = null;

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                    ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblproductor_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                var withBlock = cbProductor;
                withBlock.ForeColor = SystemColors.ControlText;
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
                }
                else
                {
                    withBlock.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarclientes()
        {
            MySqlCommand comando = null;
        
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcliente_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbcliente;
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarLote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!string.IsNullOrEmpty(cbProductor.Text))
                {
                    //    DateTime fechaActual = DateTime.Today;

                    lblCLP.Text = Convert.ToString(cbProductor.SelectedValue.ToString());

                    //int iniciocadena1 = cbProductor.Text.IndexOf('|');


                    //label35.Text = cbProductor.Text.Substring(0, iniciocadena1);

                    poblarPais();
                    if (cbProductor.Text == "Nuevo ...")
                    {
                        var form = new frmProductor2();
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

        private void cbcliente_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbcliente.Text))
                {
                    lblRUC.Text = cbcliente.GetItemText(cbcliente.SelectedValue.ToString());

                    var iniciocadena = cbcliente.Text.IndexOf('-');

                    if (cbcliente.Text == "Nuevo ...")
                    {
                        var F = new frmAltaRUC();
                        F.CambiarTextoLabel("Ingreso de Clientes");
                        F.ShowDialog();
                        mostrarclientes();
                    }
                    else
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

        private void Cuentacorrelativo()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                if (lblcorrelativo.Text != null)
                {
                    if (int.TryParse(lblcorrelativo.Text, out var currentCorrelativo))
                    {
                        correlativo = currentCorrelativo + 1;
                        lblcorrelativo.Text = correlativo.ToString("0000");
                    }
                    else
                    {
                        lblcorrelativo.Text = "3";
                    }
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"ERROR CONTANDO CORRELATIVO: " + ex.Message, @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RecuperaCorrelativo()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                if (lblcorrelativo.Text != null || Convert.ToInt32(lblcorrelativo.Text) > 0)
                    comando = new MySqlCommand("usp_cuentaCorrelativoTicketPesaje", ConexionGral.conexion);
                else
                    comando = new MySqlCommand("usp_cuentaCorrelativoTicketPesaje", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                {
                    correlativo = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                    lblcorrelativo.Text = correlativo.ToString("0000");
                    comando.ExecuteNonQuery();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error al recuperar el correlativo: {ex.Message}", @"Error crítico",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cboLote_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboLote.Text))
                {
                    lbllote.Text = cboLote.GetItemText(cboLote.SelectedValue.ToString());
                    label4.Text = cboLote.Text;
                    mostrarclientes();
                    //int combo = Convert.ToInt32(label21.ToString());
                    //combo += - 1;
                    //label4 .Text = combo.ToString();

                    if (cboLote.Text == @"Nuevo ...")
                    {
                        var form = new frmLote();
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
            if (chkPesoManual.Checked)
            {
                CheckBoxClicked?.Invoke(this, EventArgs.Empty);

                formRoot = new formR00t(FuncionDespuesValidacion, IncrementarIntentosErroneos);
                formRoot.Show();              
            }               
            else
                txtPesoManual.Visible = false;
        }

        private void FuncionDespuesValidacion()
        {
            // Lógica a ejecutar después de que la contraseña sea válida
            txtPesoManual.Visible = true;

            intentosErroneos = 0;

            if (formRoot != null)
            {
                formRoot.Close();
                formRoot.Dispose();
            }
        }

        private void IncrementarIntentosErroneos()
        {
            intentosErroneos++;
            if (intentosErroneos >= MAX_INTENTOS_ERRONEOS)
            {
                MessageBox.Show("Se ha alcanzado el número máximo de intentos erróneos. Se contactará al administrador.");
                // Aquí puedes agregar lógica adicional si lo deseas
            }
        }

        private void mostrarlistadovariedad()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblvariedad_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value =
                    cbProducto.GetItemText(cbProducto.SelectedValue);
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbvariedad;
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
            catch (MySqlException ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarturno()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblturno_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();
                // label3.Text = cbMetodoCultivo.GetItemText(cbMetodoCultivo.SelectedValue);
                //   comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value = cbProducto.GetItemText(cbProducto.SelectedValue);
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboturno;
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
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarMetCultivo()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbMetodoCultivo;
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
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void txtPesoManual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtPesoManual.Text))
                    btnguardar.PerformClick();
                else
                    MessageBox.Show(@"Ingrese el Peso Correcto");
            }
        }

        private void mostrarservicio()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbltiposervicio_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbTipoServicio;
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
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                borrarmensajeerror();
                if (validarcampos())
                {
                    if (chkPesoManual.Checked == false || (chkPesoManual.Checked && txtPesoManual.Text != null))
                    {
                        InsertarRegistro();
                        mostrarconsulta();
                        //Instancio el Formulario Hijo al Padre
                        var FH = new ImprimirPesos();
                        //Indico al Formulario quien es el Propietario
                        AddOwnedForm(FH);
                        FH.ShowDialog();
                        txtPesoManual.Focus();
                        txtPesoManual.Text = "0.0";
                    }
                    else
                    {
                        MessageBox.Show("Error en btnguardar_Click - ", @"Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

       
          
      

        private void mostrarjabas()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbljabas_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbjabas;
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void InsertarRegistro()
        {
            float tarajaba = 0;
            float taraparihuela = 0;
            float pesobruto = 0;
            float pesobrutoManual = 0;
            if (txtPesoManual.Text !=  string .Empty )
                txtPesoManual.ToString();
            else
                txtPesoManual.Text = "0.0";


            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                var comando = new MySqlCommand("usp_tblticketpesaje_Insert", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                tarajaba = float.Parse(txttarajaba.Text);
                taraparihuela = float.Parse(txttaraParihuela.Text);
                pesobruto = float.Parse(lblpeso.Text);
                pesobrutoManual = float.Parse(txtPesoManual.Text);

                if (cboLote.SelectedItem != null)
                {
                    comando.Parameters.AddWithValue("p_numdoc", lblcorrelativo.Text);
                    comando.Parameters.AddWithValue("p_horallegada", DateTime.Now);
                    comando.Parameters.AddWithValue("p_horapesaje", DateTime.Now);
                    comando.Parameters.AddWithValue("p_fecha_ticket", Convert.ToDateTime(fpesaje.Text));
                    comando.Parameters.AddWithValue("p_idmetodocultivo", MySqlType.Int).Value =
                        cbMetodoCultivo.GetItemText(cbMetodoCultivo.SelectedValue);
                    comando.Parameters.AddWithValue("p_idtiposervicio", MySqlType.Int).Value =
                        cbTipoServicio.GetItemText(cbTipoServicio.SelectedValue);
                    comando.Parameters.AddWithValue("p_idproducto", MySqlType.Int).Value =
                        cbProducto.GetItemText(cbProducto.SelectedValue);
                    comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value =
                        cboLote.GetItemText(cboLote.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value =
                        cbvariedad.GetItemText(cbvariedad.SelectedValue);
                    comando.Parameters.AddWithValue("p_idcliente", MySqlType.Int).Value = label12.Text;
                    comando.Parameters.AddWithValue("p_idacopiador", MySqlType.Int).Value = label35.Text;

                    if (txtGuiaRemision.Text == string.Empty)
                    {
                        MessageBox.Show(@"Error, Tiene que Ingresar el Numero de Guia", @"GUIA REMISION");
                        return;
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("p_num_guia", MySqlType.Text).Value = txtGuiaRemision.Text;
                    }

                    if (tarajaba > 0)
                    {
                        comando.Parameters.AddWithValue("p_tara_java", MySqlType.Double).Value = txttarajaba.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"TARA JABA");
                        return;
                    }

                    if (taraparihuela > 0)
                    {
                        comando.Parameters.AddWithValue("p_tara_pallet", MySqlType.Double).Value =
                            txttaraParihuela.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"TARA PARIHUELA");
                        return;
                    }

                    comando.Parameters.AddWithValue("p_cant_jabas", MySqlType.Double).Value =
                        cbjabas.GetItemText(cbjabas.SelectedValue);

                    pesobrutoManual = float.Parse(txtPesoManual.Text);

                    if (chkPesoManual.Checked == false)
                    {
                        if (pesobruto > 0)
                        {
                            comando.Parameters.AddWithValue("p_peso_bruto", MySqlType.Double).Value = pesobruto;
                        }
                        else
                        {
                            MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"PESO BALANZA");
                            return;
                        }
                    }
                    else
                    {
                        if (pesobrutoManual > 0)
                        {
                            comando.Parameters.AddWithValue("p_peso_bruto", MySqlType.Double).Value =
                                pesobrutoManual;
                        }
                        else
                        {
                            MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"PESO BALANZA");
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(cboturno.Text))
                    {
                        comando.Parameters.AddWithValue("p_turno", MySqlType.Int).Value =
                            cboturno.GetItemText(cboturno.SelectedValue);
                    }
                    else
                    {
                        MessageBox.Show(@"Error, El Turno debe ser Ingresado", @"TURNO");
                        return;
                    }

                    if (!string.IsNullOrEmpty(lblCLP.Text))
                    {
                        comando.Parameters.AddWithValue("p_idclp", MySqlType.Int).Value = lblCLP.Text;
                    }
                    else
                    {
                        MessageBox.Show(@"Error, El Turno debe ser Ingresado", @"TURNO");
                        return;
                    }

                    comando.ExecuteNonQuery();
                    MessageBox.Show(@"PESO REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    // limpiarcampos()
                    //    this.chkcapturapeso.Checked = false;
                }
                else
                {
                    MessageBox.Show(@"Por favor, seleccione un Lote antes de continuar.", "Error de selección",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error en InsertarRegistro - " + ex.Message, @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            Cuentacorrelativo();
            mostrarLote();
            datalistado.DataSource = null;
            totalneto.Text = "0";
            lblcantjabas.Text = "0";
        }

        private void cbAcopiador_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbAcopiador.Text))
                {
                    // lblRUC.Text = cbcliente.GetItemText(cbcliente.SelectedValue.ToString());

                    var iniciocadena = cbAcopiador.Text.IndexOf('-');

                    if (cbAcopiador.Text == "Nuevo ...")
                    {
                        var F = new frmAltaRUC();
                        F.CambiarTextoLabel("Ingreso de Acopiadores");
                        F.Panel1.BackColor = Color.Green;
                        F.ShowDialog();
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
                if (!string.IsNullOrEmpty(cbjabas.Text) && !string.IsNullOrEmpty(txttarajaba.Text))
                {
                    var resultado = double.Parse(cbjabas.GetItemText(cbjabas.SelectedItem)) *
                                    double.Parse(txttarajaba.Text);
                    lblpesojabas.Text = resultado.ToString();
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
                if (!string.IsNullOrEmpty(cbMatCosecha.Text))
                    if (cbMatCosecha.Text == "Nuevo ...")
                    {
                        var form = new frmMatCosecha();
                        form.ShowDialog();
                        mostrarMaterialCosecha();
                    }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private bool validarcampos()
        {
            var ok = true;
            if (txttarajaba.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txttarajaba, "Ingrese un numero valido");
            }

            return ok;
        }

        private void cbMatCosecha_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var filaSeleccionada = cbMatCosecha.SelectedItem as DataRowView;

            if (filaSeleccionada != null)
            {
                // Obtener el texto seleccionado del ComboBox
                var resultado = filaSeleccionada.Row["nombre"].ToString();

                if (!string.IsNullOrEmpty(resultado))
                    // Verificar si el texto seleccionado es igual a algo
                    if (resultado == "JABAS")
                        titulosjavasinvisible();
            }
        }

        private void borrarmensajeerror()
        {
            errorProvider1.SetError(txttarajaba, "");
        }

        private void cbvariedad_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbvariedad.Text))
                    if (cbvariedad.Text == "Nuevo ...")
                    {
                        var form = new MantoVariedad();
                        form.ShowDialog();
                        mostrarlistadovariedad();
                    }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void IngresoPesos_Shown(object sender, EventArgs e)
        {
            mostrarLote();
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            VarIngresoPeso = cboLote.SelectedValue.ToString();
            VarNumlote = cboLote.Text;
            FrmAgregarDoc F = new FrmAgregarDoc();
            F.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mostrarconsulta()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();


                if (cboLote.SelectedItem != null)
                {
                    comando = new MySqlCommand("usp_tblticketpesaje_Selectlote", ConexionGral.conexion);
                    comando.CommandType = (CommandType)4;

                    comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cboLote.Text;
                    var fechaaño = Settings.Default.periodo;
                    var partes = fechaaño.Split(' ')[0].Split('/');
                    var año = partes[2];
                    comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Text).Value = año;

                    var adaptador = new MySqlDataAdapter(comando);
                    var datos = new DataTable();
                    adaptador.Fill(datos);

                    {
                        var withBlock = datalistado;
                        if (datos != null && datos.Rows.Count > 0)
                        {
                            var dr = datos.NewRow();
                            withBlock.DataSource = datos;
                            tamanio();
                            sumaneto();
                            contar();
                        }
                        else
                        {
                            withBlock.DataSource = null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Por favor, seleccione un Lote antes de continuar.", "Error de selección",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

     //   private int selectedRowIndex = -1; // Variable para almacenar el índice de la fila seleccionada

        private void datalistado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclick = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = datalistado.Rows[e.RowIndex];
                Varpesoneto= selectedRow.Cells["PESO NETO"].Value.ToString();
                Varcantjabas = selectedRow.Cells["CANT JABAS"].Value.ToString();
            }

            //Instancio el Formulario Hijo al Padre
            var FH1 = new ImprimirPesos();
            //Indico al Formulario quien es el Propietario
            AddOwnedForm(FH1);
            FH1.ShowDialog();
        }

        private void IngresoPesos_FormClosing(object sender, FormClosingEventArgs e)
        {
            sppuerto.Close();
        }

        public void contar()
        {
            var contarfila = datalistado.RowCount - 1;
            var contador = 0;
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
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblhabilitadodestino_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_clp", MySqlType.Int).Value = lblCLP.Text;
                ;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    //var withBlock = this.cboLote;
                    if (datos != null && datos.Rows.Count > 0)
                        lblpais1.Text = datos.Rows[0]["ORIGEN"].ToString();
                    
                    else
                        lblpais1.Text = @"EUROPA";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    txttarajaba.Text = bloque.javaverde.ToString();
                    txttaraParihuela.Text = bloque.paleta.ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void mostrarAcopiador()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbacopiador_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbAcopiador;
                    var dr = datos.NewRow();
                    dr["ruc"] = 0;
                    dr["razonsocial"] = "Nuevo ...";
                    datos.Rows.InsertAt(dr, 0);


                    withBlock.DataSource = datos;
                    withBlock.DisplayMember = "razonsocial";
                    withBlock.ValueMember = "ruc";
                    withBlock.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarMaterialCosecha()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmatcosecha_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbMatCosecha;
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
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void cerrarlote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_Update", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value =
                    cboLote.GetItemText(cboLote.SelectedValue.ToString());


                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    //if (datos.Rows.Count != 0)
                    //{

                    withBlock.DataSource = datos;
                    withBlock.DisplayMember = "numlote";
                    withBlock.ValueMember = "idlote";
                    withBlock.SelectedIndex = -1;
                    MessageBox.Show(@"El Lote se cerro Satisfactoriamente !!!");
                    //}
                    //else
                    //{
                    //    withBlock.DataSource = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void PrepGrid()
        {
            {
                var withBlock = datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 10.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

                // 
                // establecer color de resaltado (opcional)
                // 
                withBlock.DefaultCellStyle.SelectionBackColor = Color.Red;
                withBlock.DefaultCellStyle.SelectionForeColor = Color.Yellow;

                // 
                // propiedades relacionadas con agregar / eliminar filas
                // 
                withBlock.AllowUserToAddRows = false;
                withBlock.AllowUserToDeleteRows = false;

                // 
                // propiedades relacionadas con cambiar el tamaño de columnas / filas en la celda tingkal
                // 
                withBlock.AllowUserToResizeColumns = false;
                withBlock.AllowUserToResizeRows = false;

                // 
                // propiedades que permiten al usuario ordenar columnas
                // 'haciendo clic en los encabezados de columna
                withBlock.AllowUserToOrderColumns = false;

                withBlock.BorderStyle = BorderStyle.None;

                // propiedades que regulan las líneas uniformes de "cosméticos"
                // 
                withBlock.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;

                // propiedades relacionadas con el formato del encabezado de columna / encabezado de columna
                // NB. para poder aplicar ForeColor y BackColor al encabezado, luego
                // La propiedad EnableHeadersVisualStyles debe establecerse en FALSE
                // 
                withBlock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                withBlock.ColumnHeadersHeight = 40;
                withBlock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                withBlock.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Tahoma", 10.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
                withBlock.EnableHeadersVisualStyles = false;
                withBlock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                withBlock.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                withBlock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // 
                // dado que DataGridView es solo para mostrar datos, no para medios de entrada de datos
                // luego ocultar RowHeader será mejor visto
                // 
                withBlock.RowHeadersVisible = false;
                withBlock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                // 

                // establecer columnas y filas de cambio de tamaño automático
                withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                withBlock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // 
                // determina la altura de todas las filas
                // 
                withBlock.RowTemplate.Height = 20;

                // establecer el modo de selección
                // 
                withBlock.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                // 'establecer selección múltiple (elija más de 1 fila)  '
                withBlock.MultiSelect = true;

                // el siguiente es el formato por columna
                // ajusta la posición del texto en la celda

                withBlock.ResumeLayout();
                withBlock.PerformLayout();
            }
        }

        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;


                withBlock.Columns["N° PALLET"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["N° PALLET"].Width = 60;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CANT JABAS"].Width = 50;
                
                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 80;

                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 80;

            }
            catch (Exception)
            {
                //  throw;
            }

            {
            }
        }

        //public void CambiarTextoLabel(string nuevoTexto, string nuevotexto2)
        //{
        //    lbltitulo.Text = nuevoTexto;
        //    btnGuardar.Text = nuevotexto2;
        //}

        private delegate void DelegadoAcceso(string Adicionartexto);
    }
}