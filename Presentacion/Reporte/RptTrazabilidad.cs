using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptTrazabilidad : Form
    {
        public RptTrazabilidad()
        {
            InitializeComponent();
            //  PrepGrid();
            mostrarLote();
        }

        private void RptBoletaPesado_Load(object sender, EventArgs e)
        {
        }

        private void mostrarLote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_SelectTraceability", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        //var dr = datos.NewRow();
                        //dr["idlote"] = 0;
                        //dr["numlote"] = "Nuevo ...";
                        //datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "numlote";
                        withBlock.ValueMember = "idlote";
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


        private void cboLote_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboLote.Text))
                {
                    poblarLote();
                    mostrarDestino();
                    mostrarCalibre();
                    mostrarCategoria();
                    MostrarPresentacion();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void mostrarDestino()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbldestino_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboDestino;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["iddestino"] = 0;
                        dr["nombre"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "iddestino";
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

        private void mostrarCalibre()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcalibre_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbCalibre;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        //var dr = datos.NewRow();
                        //dr["idcalibre"] = 0;
                        //dr["nombre"] = "Nuevo ...";
                        //datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idcalibre";
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


        private void mostrarCategoria()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcategoria_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbCategoria;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        //var dr = datos.NewRow();
                        //dr["idcalibre"] = 0;
                        //dr["nombre"] = "Nuevo ...";
                        //datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idcategoria";
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

        private void MostrarPresentacion()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblpresentacion_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cbpresentacion;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        dr["idpresentacion"] = 0;
                        dr["nombre"] = "Nuevo ...";
                        datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idpresentacion";
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

        private void mostrarconsulta()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbltrazabilidad_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cboLote.Text;
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
                        //sumaneto();
                        //contar();
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


        private void poblarLote()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticketpesaje_Select_Trazability", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = cboLote.Text;
                ;

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
                        //  lblruc_dni.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        lblclp.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();
                        lblvariedad.Text = datos.Rows[0]["VARIEDAD"].ToString();
                        lblfechaingreso.Text = datos.Rows[0]["FECHA PESAJE"].ToString();
                        //    lblhoraingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();

                        lblpesoneto.Text = datos.Rows[0]["PESO NETO"].ToString();
                        lblcantjabas.Text = datos.Rows[0]["CANT JABAS"].ToString();
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            InsertarRegistro();
            mostrarconsulta();
        }

        private void InsertarRegistro()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();
                var comando = new MySqlCommand(
                    "INSERT INTO tbltrazabilidad (numlote ,cliente,clp, productor ,producto ,variedad ,fproceso ,ingresoplanta ,cant_jabas ,destino ,calibre ,categoria ,presentacion ,cant_cajas)" +
                    '\r'
                    + "VALUES(@numlote, @cliente, @clp, @productor, @producto, @variedad, @fproceso, @ingresoplanta, @cant_jabas, @destino, @calibre, @categoria, @presentacion, @cant_cajas)",
                    ConexionGral.conexion);

                //float tarajaba = float.Parse(txttarajaba.Text);
                //float taraparihuela = float.Parse(txttaraParihuela.Text);
                //float pesobruto = float.Parse(lblpeso.Text);
                //float pesobrutoManual = float.Parse(txtPesoManual.Text);

                var numlote = Convert.ToInt32(cboLote.Text);

                comando.Parameters.AddWithValue("@numlote", MySqlType.Int).Value = numlote;
                comando.Parameters.AddWithValue("@cliente", lblcliente.Text);
                comando.Parameters.AddWithValue("@clp", lblclp.Text);
                comando.Parameters.AddWithValue("@productor", lblproductor.Text);

                comando.Parameters.AddWithValue("@producto", lblproducto.Text);
                comando.Parameters.AddWithValue("@variedad", lblvariedad.Text);
                comando.Parameters.AddWithValue("@fproceso", Convert.ToDateTime(fproceso.Text));

                var pesoingreso = Convert.ToDouble(lblpesoneto.Text);

                comando.Parameters.AddWithValue("@ingresoplanta", MySqlType.Double).Value = pesoingreso;

                var cant_jabas = Convert.ToInt32(lblcantjabas.Text);

                comando.Parameters.AddWithValue("@cant_jabas", MySqlType.Int).Value = cant_jabas;

                comando.Parameters.AddWithValue("@destino", MySqlType.Int).Value = cboDestino.Text;

                var calibre = Convert.ToInt32(cbCalibre.Text);

                comando.Parameters.AddWithValue("@calibre", MySqlType.Int).Value = calibre;
                comando.Parameters.AddWithValue("@categoria", MySqlType.Int).Value = cbCategoria.Text;
                comando.Parameters.AddWithValue("@presentacion", MySqlType.Text).Value = cbpresentacion.Text;

                var cant_cajas = Convert.ToDouble(txtcant_cajas.Text);

                comando.Parameters.AddWithValue("@cant_cajas", MySqlType.Int).Value = cant_cajas;


                comando.ExecuteNonQuery();
                MessageBox.Show(@"PESO REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                // limpiarcampos()
                //    this.chkcapturapeso.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
            // cuentacorrelativo_BG()
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}