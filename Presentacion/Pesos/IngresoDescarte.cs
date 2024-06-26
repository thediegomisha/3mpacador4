﻿using System;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.R00t;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4
{
    public partial class IngresoDescarte : Form
    {
        private formR00t formRoot;
        private int intentosErroneos = 0;
        private int a, b, c, d;

        private int a1, b1, c1, d1, e2, f1, g1, h1;
        private int aux = 0;
        private readonly string cero = Convert.ToString('0'); // HEXADECIMAL
        private int contador = 0;
        private int correlativo = 0;
        private string CR = Convert.ToString('\r');
        private CultureInfo en = new CultureInfo("es-MX");
        private string LF = Convert.ToString('\n');

        private string MAS = Convert.ToString('+');
        private string menos = Convert.ToString('-');
        private string mostrarcaracter;
        private readonly string n = Convert.ToString('n'); // HEXADECIMAL

        private string POSICION_INICIAL;
        private readonly string PUNTO = Convert.ToString('.');
        private string salidacontrol;
        private string stringinicio;

        private readonly string w = Convert.ToString('w'); // HEXADECIMAL

        public bool doubleclickdescarte { get; set; } = false;

        public string Varcantjabasdesc { get; set; } = "";
        public string Varpesonetodesc { get; set; } = "";

        public IngresoDescarte()
        {
            InitializeComponent();
            conectarserial();
            cargarinicial();
        }

        //private void sppuerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    string DatoInterrupcion;
        //    try
        //    {
        //        DatoInterrupcion = sppuerto.ReadExisting();
        //        PuertaAccesoInterrupcion(DatoInterrupcion);
        //    }
        //    catch (Exception ex)
        //    {
        //        Interaction.MsgBox("ERROR DATOS INTERRUPCION " + ex.Message, Constants.vbCritical);
        //    }
        //}

        private void sppuerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Es más eficiente leer los datos en un búfer
                int bytesToRead = sppuerto.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                sppuerto.Read(buffer, 0, bytesToRead);

                // Convierte los bytes a una cadena utilizando la codificación adecuada
                string datosRecibidos = Encoding.UTF8.GetString(buffer);

                // Llama a la función de manejo de datos
                PuertaAccesoInterrupcion(datosRecibidos);
            }
            catch (Exception ex)
            {
                // En lugar de mostrar un MsgBox, podrías registrar el error o manejarlo de manera diferente
                // Aquí, se registra el error con más detalles, incluyendo el tipo de excepción y la traza de la pila
              //  Console.WriteLine($"ERROR DATOS INTERRUPCION: {ex.GetType().Name} - {ex.Message}\n{ex.StackTrace}");

                MessageBox.Show($"ERROR DATOS INTERRUPCION:  {ex.GetType().Name} - {ex.Message}\\n{ex.StackTrace}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

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
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
        }

        private void IngresoPesos_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100; // Un segundo
            timer1.Start();
            // temporizador();
            txtPesoManual.Visible = false;
            mostrarLote();
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
                    //label22.Text = Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error cbJabas DropDownClosed" + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PuertaAccesoInterrupcion(string BufferIn)
        {
            try
            {
                object[] TextoInterrupcion = { BufferIn };
                DelegadoAcceso DelegadoInterrupcion;
                DelegadoInterrupcion = AccesoFromPrincipal;
                BeginInvoke(DelegadoInterrupcion, TextoInterrupcion);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Error PuertaAccesoInterrupcion" + e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
           
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
                        MessageBox.Show(@"Error CONEXION FALLIDA" ,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void mostrarLote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_Select_descarte", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Text).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    withBlock.DataSource = datos;
                    withBlock.DisplayMember = "numlote";
                    withBlock.ValueMember = "idlote";
                    withBlock.SelectedIndex = -1;
                }
                mostrarjabas();
                mostrarturno();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error mostrarLote" + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void poblarLote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticketpesaje_Select_Trazability", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cboLote.Text;


                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Text).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        lblcliente.Text = datos.Rows[0]["RAZON SOCIAL"].ToString();
                        lblproductor.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //  lblmetodo.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        lblproducto.Text = datos.Rows[0]["PRODUCTO"].ToString();
                        //  lblservicio.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //  lblacopiador.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        // lblguiaingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        lblruc.Text = datos.Rows[0]["R.U.C."].ToString();
                        lblclp.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();
                        lblvariedad.Text = datos.Rows[0]["VARIEDAD"].ToString();
                        lblpesoneto.Text = datos.Rows[0]["PESO NETO"].ToString();
                        //    lblfechaingreso.Text = datos.Rows[0]["FECHA PESAJE"].ToString();
                        //    lblhoraingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();

                        //  lblpesoneto.Text = (datos.Rows[0]["PESO NETO"].ToString());
                        //   lblcantjabas.Text = (datos.Rows[0]["CANT JABAS"].ToString());
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error poblarLote " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
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
                MessageBox.Show("Error mostrarjabas" + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }


        private void chkPesoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPesoManual.Checked)
            {
                formRoot = new formR00t(FuncionDespuesValidacion, IncrementarIntentosErroneos);
                formRoot.Show();
            }
            else
            {
                txtPesoManual.Visible = false;
            }               
        }

        private void IncrementarIntentosErroneos()
        {
            intentosErroneos++;
        }
        private void FuncionDespuesValidacion()
        {
            // Lógica a ejecutar después de que la contraseña sea válida
            txtPesoManual.Visible = true;

            if (formRoot != null)
            {
                formRoot.Close();
                formRoot.Dispose();
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
                MessageBox.Show("Error mostrarturno " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var FH = new ImprimirPesosDescarte();
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

        private void InsertarRegistro()
        {
            float tarajaba = 0;
            float taraparihuela = 0;
            float pesobruto = 0;
            float pesobrutoManual = 0;
            if (txtPesoManual.Text != string.Empty)
                txtPesoManual.ToString();
            else
                txtPesoManual.Text = "0.0";

            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticket_descarte_Insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                 tarajaba = float.Parse(txttarajaba.Text);
                 taraparihuela = float.Parse(txttaraParihuela.Text);
                 pesobruto = float.Parse(lblpeso.Text);
                 pesobrutoManual = float.Parse(txtPesoManual.Text);

                comando.Parameters.AddWithValue("p_numdoc", lblcorrelativo.Text);
                comando.Parameters.AddWithValue("p_fecha_pesaje", Convert.ToDateTime(fpesaje.Text));
                comando.Parameters.AddWithValue("p_h_pesaje", DateTime.Now);

                comando.Parameters.AddWithValue("p_idmetodocultivo", MySqlType.Int).Value = lblconvencional.Text;
                comando.Parameters.AddWithValue("p_idtiposervicio", MySqlType.Int).Value = lblservicio.Text;
                comando.Parameters.AddWithValue("p_idproducto", MySqlType.Int).Value = lblproducto.Text;
                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = cboLote.GetItemText(cboLote.SelectedValue.ToString());
                comando.Parameters.AddWithValue("p_idvariedad", MySqlType.Int).Value = lblvariedad.Text;

                comando.Parameters.AddWithValue("p_idcliente", MySqlType.Int).Value = lblcliente.Text;

                if (tarajaba > 0)
                {
                    comando.Parameters.AddWithValue("p_tara_jaba", MySqlType.Double).Value = txttarajaba.Text;
                }
                else
                {
                    MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"TARA JABA");
                    return;
                }

                if (taraparihuela > 0)
                {
                    comando.Parameters.AddWithValue("p_tara_pallet", MySqlType.Double).Value = txttaraParihuela.Text;
                }
                else
                {
                    MessageBox.Show(@"Error, el Peso tiene que ser mayor que 0", @"TARA PARIHUELA");
                    return;
                }

                comando.Parameters.AddWithValue("p_cant_jabas", MySqlType.Double).Value =
                    cbjabas.GetItemText(cbjabas.SelectedValue);

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

                if (!string.IsNullOrEmpty(lblclp.Text))
                {
                    comando.Parameters.AddWithValue("p_idclp", MySqlType.Int).Value = lblclp.Text;
                }
                else
                {
                    MessageBox.Show(@"Error, El Turno debe ser Ingresado", @"TURNO");
                    return;
                }

                comando.ExecuteNonQuery();
                MessageBox.Show(@"PESO REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error InsertarRegistro " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
            // cuentacorrelativo_BG()
        }

        private void cboLote_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboLote.Text))
                {
                    poblarLote();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error cboLote_DropDownClosed" + "Error " + ex.Message, Constants.vbCritical);
            }
        }
            private void btnCerrarLote_Click(object sender, EventArgs e)
        {
            cerrarlote();
            mostrarLote();
            datalistado.DataSource = null;
            totalneto.Text = "0";
            lblcantjabas.Text = "0";
        }

        private void IngresoDescarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            sppuerto.Close();
        }

        private void datalistado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclickdescarte = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = datalistado.Rows[e.RowIndex];
                Varpesonetodesc = selectedRow.Cells["PESO NETO"].Value.ToString();
                Varcantjabasdesc = selectedRow.Cells["CANT JABAS"].Value.ToString();
            }

            //Instancio el Formulario Hijo al Padre
            var FH1 = new ImprimirPesosDescarte();
            //Indico al Formulario quien es el Propietario
            AddOwnedForm(FH1);
            FH1.ShowDialog();
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

        private void borrarmensajeerror()
        {
            errorProvider1.SetError(txttarajaba, "");
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

                comando = new MySqlCommand("usp_tblticket_Descarte_Selectlote", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cboLote.Text;

                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Text).Value = año;
                ;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
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
                MessageBox.Show("Error mostrarconsulta " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
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
                    object pesoNetoCellValue = row.Cells["PESO NETO"].Value;
                    object cantJabasCellValue = row.Cells["CANT JABAS"].Value;

                    if (pesoNetoCellValue != null && cantJabasCellValue != null)
                    {
                        total += Convert.ToDouble(pesoNetoCellValue);
                        cantjabas += Convert.ToDouble(cantJabasCellValue);
                    }
                }

                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
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
                MessageBox.Show("Error cerrarlote" + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private delegate void DelegadoAcceso(string Adicionartexto);
    }
}