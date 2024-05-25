using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Color = System.Drawing.Color;
using Constants = Microsoft.VisualBasic.Constants;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;

// using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptGeneral : Form
    {
        private bool btnsearchallpress;
        private bool btnsearchpress;

        public RptGeneral()
        {
            InitializeComponent();
            comboboxgrupo();
            fechasgrupo();
            checkboxgrupo();
            texboxgrupo();
            fechaPeriodo.Format = DateTimePickerFormat.Custom;
            fechaPeriodo.CustomFormat = "yyyy";
        }

        private void rpt1_Load(object sender, EventArgs e)
        {
            PrepGrid();
            PrepGrid2();
            PrepGrid3();
            mostrarclientes();
            //mostrarconsulta();
            mostrarproductor();
        //    mostrarAcopiador();
         //   mostrarVariedad();
        //    mostrarMetodo();
         //   mostrarDestino();
            lblpuntero.Visible = false;
        }

        private void comboboxgrupo()
        {
            cb_cliente.Enabled = false;
            cb_destino.Enabled = false;
            cb_estado.Enabled = false;
            cb_metodo.Enabled = false;
            cb_productor.Enabled = false;
            cb_variedad.Enabled = false;
            cbAcopiador.Enabled = false;
        }

        private void fechasgrupo()
        {
            dtpfingresofin.Enabled = false;
            dtpfingresoini.Enabled = false;
            dtpprocesofin.Enabled = false;
            dtpprocesoini.Enabled = false;
        }

        private void checkboxgrupo()
        {
            chkcliente.Checked = false;
            chkdestino.Checked = false;
            chkestado.Checked = false;
            chkf_ing.Checked = false;
            chkf_proc.Checked = false;
            chkguia.Checked = false;
            chklote.Checked = false;
            chkmetodo.Checked = false;
            chkproductor.Checked = false;
            chk_acopiador.Checked = false;
        }

        private void texboxgrupo()
        {
            txt_guia.Enabled = false;
            txt_lote.Enabled = false;
        }

        private void chkf_ing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkf_ing.Checked)
            {
                dtpfingresoini.Enabled = true;
                dtpfingresofin.Enabled = true;
            }
            else
            {
                dtpfingresoini.Enabled = false;
                dtpfingresofin.Enabled = false;
            }
        }

        private void chkf_proc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkf_proc.Checked)
            {
                dtpprocesoini.Enabled = true;
                dtpprocesofin.Enabled = true;
            }
            else
            {
                dtpprocesoini.Enabled = false;
                dtpprocesofin.Enabled = false;
            }
        }

        private void chkcliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcliente.Checked)
                cb_cliente.Enabled = true;
            else
                cb_cliente.Enabled = false;
        }

        private void chkproductor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkproductor.Checked)
                cb_productor.Enabled = true;
            else
                cb_productor.Enabled = false;
        }

        private void chkestado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkestado.Checked)
                cb_estado.Enabled = true;
            else
                cb_estado.Enabled = false;
        }

        private void chkvariedad_CheckedChanged(object sender, EventArgs e)
        {
            if (chkvariedad.Checked)
                cb_variedad.Enabled = true;
            else
                cb_variedad.Enabled = false;
        }

        private void chkmetodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmetodo.Checked)
                cb_metodo.Enabled = true;
            else
                cb_metodo.Enabled = false;
        }

        private void chkdestino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdestino.Checked)
                cb_destino.Enabled = true;
            else
                cb_destino.Enabled = false;
        }

        private void chklote_CheckedChanged(object sender, EventArgs e)
        {
            if (chklote.Checked)
                txt_lote.Enabled = true;
            else
                txt_lote.Enabled = false;
        }

        private void chkguia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkguia.Checked)
                txt_guia.Enabled = true;
            else
                txt_guia.Enabled = false;
        }

        private void chk_acopiador_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_acopiador.Checked)
                cbAcopiador.Enabled = true;
            else
                cbAcopiador.Enabled = false;
        }

        private void mostrarclientes()
        {
            MySqlCommand comando = null;
            //  MostrarAnimacionEspera();
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcliente_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cb_cliente;
                    if (datos != null && datos.Rows.Count > 0)
                    {
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
                //    OcultarAnimacionEspera();
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

        private void mostrarconsulta()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var procedimientoAlmacenado = DeterminarProcedimientoAlmacenado();
                var bandera = DeterminarBandera();
                var dtInicio = "null";
                var dtFin = "null"; 
                DateTime fechaseleccionada = fechaPeriodo.Value;
                string añoseleccionado = fechaseleccionada.Year.ToString();

                var iniciocadena = 0;

                var comando = new MySqlCommand(procedimientoAlmacenado, ConexionGral.conexion);
                comando.CommandType = (CommandType)4;


                if (chkcliente.Checked && chkf_ing.Checked)
                {
                    //     procedimientoalmacenado = "usp_tblticketpesaje_Exportador";
                    iniciocadena = cb_cliente.Text.IndexOf('-');
                    flag.Text = cb_cliente.Text.Substring(0, iniciocadena);
                   // añoseleccionado = "p_fechaanio";
                    
                    dtInicio = "p_fechainicio";
                    dtFin = "p_fechafin";
                }
                else if (chkcliente.Checked)
                {
                    //     procedimientoalmacenado = "usp_tblticketpesaje_Exportador";
                    iniciocadena = cb_cliente.Text.IndexOf('-');
                    flag.Text = cb_cliente.Text.Substring(0, iniciocadena);
                                 
                }
                else if (chkproductor.Checked)
                {
                    //     procedimientoalmacenado = "usp_tblticketpesaje_Productor";
                    iniciocadena = cb_productor.Text.IndexOf('-');
                    flag.Text = cb_productor.Text.Substring(0, iniciocadena);
                 //   añoseleccionado = "p_fechaanio";
                    //   bandera = "p_idproductor";
                }
                else if (chkvariedad.Checked)
                {
                    //    procedimientoalmacenado = "usp_tblticketpesaje_Variedad";                  
                    flag.Text = cb_variedad.SelectedValue.ToString();
                 //   añoseleccionado = "p_fechaanio";
                    //    bandera = "p_variedad";
                }
                //    procedimientoalmacenado = "usp_tblticketpesaje_Acopiador";   
                else if (chk_acopiador.Checked)
                {
                    iniciocadena = cbAcopiador.Text.IndexOf('-');
                    flag.Text = cbAcopiador.Text.Substring(0, iniciocadena);
                //    añoseleccionado = "p_fechaanio";
                }
                else if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked == false &&
                         chk_acopiador.Checked == false)
                {
                    //     procedimientoalmacenado = "usp_tblticketpesaje_RptGral";                   
                }
                // comando = new MySqlCommand(procedimientoalmacenado, ConexionGral.conexion);

                if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked == false &&
                    chk_acopiador.Checked == false)
                {
                }
                else if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked &&
                         chkf_ing.Checked && chk_acopiador.Checked == false)
                {
                    //comando.Parameters.AddWithValue(bandera, MySqlType.Int).Value = flag.Text;
                    //comando.Parameters.AddWithValue(dtinicio, MySqlType.Int).Value = dtpfingresoini.Value;
                    //comando.Parameters.AddWithValue(dtfin, MySqlType.Int).Value = dtpfingresofin.Value;
                }

              
                if (btnsearchallpress)
                {
                  
                    comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Date).Value = añoseleccionado;
                }

                if (btnsearchpress)
                {
                    comando.Parameters.AddWithValue(bandera, MySqlType.Date).Value = flag .Text ;
                    comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Date).Value = añoseleccionado;

                }
              
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
                        contarGeneral();
                        contarjabaGeneral();
                        lblinfo1.Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        lblinfo1.Visible = true;
                    }
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

        private string DeterminarProcedimientoAlmacenado()
        {
            if (chkcliente.Checked && chkf_ing.Checked)
                return "usp_tblticketpesaje_Exportador";
            if (chkcliente.Checked)
                return "usp_tblticketpesaje_Exportador";
            if (chkproductor.Checked)
                return "usp_tblticketpesaje_Productor";
            if (chk_acopiador.Checked)
                return "usp_tblticketpesaje_Acopiador";
            if (chkvariedad.Checked)
                return "usp_tblticketpesaje_Variedad";
            return "usp_tblticketpesaje_RptGral";
        }

        private string DeterminarBandera()
        {
            if (chkcliente.Checked)
                return "p_idcliente";
            if (chkproductor.Checked)
                return "p_idproductor";
            if (chk_acopiador.Checked)
                return "p_idacopiador";
            if (chkvariedad.Checked)
                return "p_variedad";
            return null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrepGrid()
        {
            {
                var withBlock = datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = System.Drawing.Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

                // 
                // establecer color de resaltado (opcional)
                // 
                withBlock.DefaultCellStyle.SelectionBackColor = Color.Blue;
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
                    new Font("Tahoma", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                withBlock.RowTemplate.Height = 17;
                // withBlock.SelectionMode.


                // establecer el modo de selección
                // 
                withBlock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // 'establecer selección múltiple (elija más de 1 fila)  '
                withBlock.MultiSelect = true;

                // el siguiente es el formato por columna
                // ajusta la posición del texto en la celda

                withBlock.ResumeLayout();
                withBlock.PerformLayout();
            }
        }

        private void PrepGrid2()
        {
            {
                var withBlock = datalistado2;
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

        private void PrepGrid3()
        {
            {
                var withBlock = datalistado3;
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


                withBlock.Columns["LOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["LOTE"].Width = 50;

                withBlock.Columns["GUIA REMISION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["GUIA REMISION"].Width = 110;

                withBlock.Columns["NUMDOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["NUMDOC"].Width = 65;

                withBlock.Columns["FECHA PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FECHA PESAJE"].Width = 90;

                if (chk_acopiador.Checked || chkcliente.Checked || chkproductor.Checked)
                {
                }
                else
                {
                    //withBlock.Columns["H LLEGADA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    //withBlock.Columns["H LLEGADA"].Width = 70;

                    withBlock.Columns["PRODUCTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["PRODUCTO"].Width = 60;
                    //withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment =
                    //    DataGridViewContentAlignment.MiddleRight;
                    //// .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                    //withBlock.Columns["PESO BRUTO"].Width = 80;

                    //withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment =
                    //    DataGridViewContentAlignment.MiddleRight;
                    //// .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                    //withBlock.Columns["PESO JABAS"].Width = 80;
                }


                if (chkvariedad.Checked)
                {
                }
                else
                {
                    withBlock.Columns["VARIEDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["VARIEDAD"].Width = 60;
                }

                if (chkcliente.Checked)
                {
                }
                else
                {
                    withBlock.Columns["EXPORTADOR"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["EXPORTADOR"].Width = 200;
                }

                if (chkproductor.Checked)
                {
                }
                else
                {
                    withBlock.Columns["PRODUCTOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["PRODUCTOR"].Width = 270;
                }

                withBlock.Columns["CODIGO PRODUCCION"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CODIGO PRODUCCION"].Width = 90;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("PESAJE").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["CANT JABAS"].Width = 50;


                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 80;

                withBlock.Columns["PROM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PROM"].Width = 50;
            }
            catch (Exception)
            {
                //  throw;
            }

            {
            }
        }
        private void tamanio2()
        {
            try
            {
                var withBlock = datalistado2;

                withBlock.Columns["H PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["H PESAJE"].Width = 70;

                withBlock.Columns["T. JABA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T. JABA"].Width = 40;

                withBlock.Columns["T.PARIH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T.PARIH"].Width = 80;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["CANT JABAS"].Width = 60;

                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 90;

                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO JABAS"].Width = 60;


                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 80;

                withBlock.Columns["PROM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PROM"].Width = 90;
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        private void ocultar_columnas()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = true;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }


        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = datalistado.Rows[e.RowIndex];
                lblpuntero.Text = fila.Cells[0].Value.ToString();
                mostrarconsulta2();
                contardescarte();
                sumanetodescarte();
                mostrarconsulta3();
            }
        }


        private DataTable mostrarconsulta2()
        {
            var datos = new DataTable();
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_rptticketpesajedetalle2", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = fechaPeriodo.Text;

                    comando.Parameters.Add("p_resultado", MySqlType.Text);
                    comando.Parameters["p_resultado"].Direction = ParameterDirection.Output;

                var adaptador = new MySqlDataAdapter(comando);
                // var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado2;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        tamanio2();
                        ocultar_columnas2();
                        //actualizardatos();
                        sumaneto();
                        contar();

                        string resultado = (comando.Parameters["p_resultado"].Value.ToString());
                        totalneto.Text = resultado;
                        lblinfo2.Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        lblinfo3.Visible = true;
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
            return datos;
        }

        private DataTable mostrarconsulta3()
        {
            var datos = new DataTable();
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticket_Descarte_Selectlote", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = fechaPeriodo.Text;

                var adaptador = new MySqlDataAdapter(comando);
               // var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado3;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        ocultar_columnas3();
                        sumanetodescarte();
                        contardescarte();

                        //string resultado = (comando.Parameters["p_resultado"].Value.ToString());
                        //totalnetodescarte.Text = resultado;

                        lblinfo3.Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        contardescarte();
                        lblinfo3.Visible = true;
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
            return datos;
        }

        private void mostrarproductor()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblproductor_Select3", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cb_productor;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "RAZON SOCIAL";
                        withBlock.ValueMember = "idproductor";
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
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
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "razonsocial";
                        withBlock.ValueMember = "ruc";
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarVariedad()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblvariedad_Select2", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cb_variedad;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idvariedad";
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarMetodo()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cb_metodo;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "idmetodocultivo";
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
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
                    var withBlock = cb_destino;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "nombre";
                        withBlock.ValueMember = "iddestino";
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
                MessageBox.Show("Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }


        private void ocultar_columnas2()
        {
            datalistado2.Columns[0].Visible = false;
            datalistado2.Columns[1].Visible = false;
            datalistado2.Columns[2].Visible = true;
            datalistado2.Columns[3].Visible = false;
            datalistado2.Columns[4].Visible = false;
            datalistado2.Columns[5].Visible = false;
            datalistado2.Columns[6].Visible = false;
            datalistado2.Columns[7].Visible = false;
            datalistado2.Columns[8].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        private void ocultar_columnas3()
        {
            datalistado3.Columns[0].Visible = false;
            //datalistado2.Columns[1].Visible = false;
            //datalistado2.Columns[2].Visible = false;
            //datalistado2.Columns[3].Visible = false;
            //datalistado2.Columns[4].Visible = false;
            //datalistado2.Columns[5].Visible = false;
            //datalistado2.Columns[6].Visible = false;
            //datalistado2.Columns[7].Visible = false;
            //datalistado2.Columns[8].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            var contarfila = datalistado2.RowCount - 1;
            var contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }

            LBLCONTAR.Text = Strings.FormatNumber(contador, 0);
        }

        public void contarGeneral()
        {
            var contarfila = datalistado.RowCount - 1;
            var contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }

            itemsconsulta.Text = Strings.FormatNumber(contador, 0);
        }

        public void contarjabaGeneral()
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

                totalgeneral.Text = Strings.FormatNumber(total, 2);
                cantjbasgeneral.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado2.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                }

               // totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        public void contardescarte()
        {
            var contarfila = datalistado3.RowCount - 1;
            var contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }

            lblcontardescarte.Text = Strings.FormatNumber(contador, 0);
        }

        public void sumanetodescarte()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado3.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                }

                totalnetodescarte.Text = Strings.FormatNumber(total, 2);
                cantjabasdescarte.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnsearchpress = true;
            btnsearchallpress = false;

            if (chkcliente.Checked || chkdestino.Checked || chkestado.Checked || chkf_ing.Checked
                || chkf_proc.Checked || chkguia.Checked || chklote.Checked || chkmetodo.Checked
                || chkproductor.Checked || chkvariedad.Checked || chk_acopiador.Checked)
                mostrarconsulta();
            else
                MessageBox.Show(@"Error Selecciona un Item para buscar !!!", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            btnsearchallpress = true;
            btnsearchpress = false;


            if (chkcliente.Checked == false && chkdestino.Checked == false && chkestado.Checked == false &&
                chkf_ing.Checked == false
                && chkf_proc.Checked == false && chkguia.Checked == false && chklote.Checked == false &&
                chkmetodo.Checked == false
                && chkproductor.Checked == false && chkvariedad.Checked == false && chk_acopiador.Checked == false)
            {
                mostrarconsulta();
                datalistado2.DataSource = null;
                datalistado3.DataSource = null;
            }
        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hace un chequeo si se hizo click en una fila
            if (e.RowIndex >= 0)
            {
                // EVALUA la fila que se clickeo
                var filasseleccionada = datalistado.Rows[e.RowIndex];
              
                var filaConDatos = new string[filasseleccionada.Cells.Count];
              
                for (var i = 0; i < filasseleccionada.Cells.Count; i++)
                    filaConDatos[i] = filasseleccionada.Cells[i].Value.ToString();

                var resultadosingresos = mostrarconsulta2();
                var resultadosdescarte = mostrarconsulta3();                           

                var FH = new RptBoletaPesadoDetalle(filaConDatos,  resultadosingresos, resultadosdescarte);

                FH.ShowDialog();
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            GenerarPDF2();
        }

        private void GenerarPDF2()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Size(PageSizes.A4.Portrait());
                    pagina.Margin(2, QuestPDF.Infrastructure.Unit.Millimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(14));

                    pagina.Header().Element(CrearCabecera);
                    pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf("RptGeneral_TheAthoq.pdf");
            Process.Start("RptGeneral_TheAthoq.pdf");
        }
        void CrearCabecera(IContainer container)
        {
            const string LogoPath = (@"Resources\logoagricola.png");

            container.Column(col =>
            {

                col.Item().Row(
                    row =>
                    {
                        row.RelativeItem().AlignLeft()

                            .Row(rowitem =>
                            {

                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Padding(0).Column(column =>
                                {
                                    column.Item().Container().Height(2);

                                    if (File.Exists(LogoPath))
                                    {
                                        rowitem.AutoItem().Width(160).Height(80).Image(LogoPath);
                                    }

                                });
                            });

                        row.RelativeItem().AlignCenter()

                            .Row(rowitem =>
                            {
                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Padding(2).Column(column =>
                                {
                                    column.Item().Container().Height(3);
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(8);
                                        row2.AutoItem().Text($"RECEPCION DE MATERIA PRIMA").SemiBold().FontSize(12)
                                            .FontColor(Colors.Orange.Medium);
                                    });

                                });
                            });



                        row.RelativeItem().AlignRight().Width(150).Height(45)

                            .Row(rowitem =>
                            {
                                //   rowitem.AutoItem().Width(65).Height(65).Image(QRCodeGenerator.GenerateQRCodeBytes("https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---Csharp----Huong-dan-tao-ung-dung-dock-windows-giong-Taskbar/2f0a9a79ff1bafd4.html", 170, 170));
                                //   rowitem.AutoItem().Width(65).Height(65).Image(GenerarCodigoQr.ReadImageFileToBytes(LogoPath));
                                rowitem.AutoItem().Container().Width(4);
                                rowitem.RelativeItem().Border(0.5f).Padding(1).Column(column =>
                                {
                                    column.Item().Container().Height(2);
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().Text($"CODIGO : AGS-PRO-R-01").FontSize(9).Italic();

                                    });
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().Text($"FECHA: 27/10/2023").FontSize(9).Italic();

                                    });
                                    column.Item().Row(row2 =>
                                    {
                                        row2.Spacing(12);
                                        row2.AutoItem().AlignCenter().Text($"VERSION : 02").FontSize(9).Italic();

                                    });


                                });
                            });
                    });


                col.Item().Row(row =>
                {
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            //columns.RelativeColumn();
                            //columns.RelativeColumn();
                        });
                        //table.Cell().AlignCenter().Text(String.Empty).SemiBold().FontSize(18)
                        //    .FontColor(Colors.Black);
                        table.Cell().AlignCenter().Text("LOTE N° " ).SemiBold().FontSize(18)
                            .FontColor(Colors.Black);
                    });
                });


                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });
                    table.Cell().Text("        Cliente :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Guia de Remision :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Productor :");
                    table.Cell().Text("").FontSize(9).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   RUC / DNI :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Metodo :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   CLP :");
                    table.Cell().Text("");

                    table.Cell().Text("        Producto :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Variedad :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Tipo de Servicio :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Fecha Ingreso :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();

                    table.Cell().Text("        Acopiador :");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                    table.Cell().Text("   Hora Ingreso");
                    table.Cell().Text("").FontSize(10).FontColor(Colors.Black).Bold();
                });
            });
        }
        void CrearContenido(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Table(table =>
                {
                    QuestPDF.Infrastructure.IContainer DefaultCellStyle(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                            .Border(0.5f)
                            .BorderColor(Colors.Grey.Lighten1)
                            .Background(backgroundColor)

                            .PaddingVertical(5)
                            .PaddingHorizontal(10)
                            .AlignCenter()
                            .AlignMiddle();
                    }

                    QuestPDF.Infrastructure.IContainer DefaultCellStyle2(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                              .Border(0.5f)
                              .BorderColor(Colors.Grey.Lighten1)
                              .Background(Colors.White)

                              .PaddingVertical(5)
                              .PaddingHorizontal(10);
                    }

                    QuestPDF.Infrastructure.IContainer DefaultCellStyleGroup(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
                    {
                        return containers
                              .Border(0.5f)
                                .BorderColor(Colors.Grey.Lighten1)
                              .Background("#f0f0f0")

                              .PaddingVertical(5)
                              .PaddingHorizontal(10);
                    }

                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);

                    });

                    table.Header(header =>
                    {
                        //foreach (DataGridViewRow row in datalistado.Rows)
                        //{
                        header.Cell().Element(CellStyle).Text("T. JABA").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("T. PARIH").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("CANT JABAS").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO BRUTO").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO JABAS").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PESO NETO").FontSize(10).FontColor(Colors.White)
                            .Bold();
                        header.Cell().Element(CellStyle).Text("PROM").FontSize(10).FontColor(Colors.White).Bold();

                        QuestPDF.Infrastructure.IContainer
                            CellStyle(QuestPDF.Infrastructure.IContainer containers) =>
                            DefaultCellStyle(containers, Colors.Blue.Medium);
                        //}

                    });

                    foreach (DataGridViewRow row in datalistado.Rows)
                    {
                        table.Cell().Element(CellStyle2).Text(row.Cells["T. JABA"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["T.PARIH"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["CANT JABAS"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO BRUTO"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO JABAS"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PESO NETO"].Value).FontSize(9);
                        table.Cell().Element(CellStyle2).Text(row.Cells["PROMEDIO"].Value).FontSize(9);


                        QuestPDF.Infrastructure.IContainer CellStyle2(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyle2(containers, Colors.Blue.Medium);

                    }
                });
                //col.Item().Text(string.Empty);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();

                    });

                    table.Cell().Text("Items");
                    table.Cell().Text($"{datalistado.RowCount}").FontSize(12).FontColor(Colors.Black).Bold();
                    //   $"{TableOfContents.Contents.Count}"
                    ;
                    table.Cell().Text("Cant Jabas");
                    table.Cell().Text(lblcantjabas.Text).FontSize(12).FontColor(Colors.Black).Bold();

                    table.Cell().Text("Total Neto");
                    table.Cell().Text(totalneto.Text).FontSize(12).FontColor(Colors.Black).Bold();
                    ;
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                });
                col.Item().AlignCenter().Text(String.Empty);


                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();

                    });
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);
                    table.Cell().Text(String.Empty);

                    table.Cell().Text("V.B");

                    //    col.Item().AlignCenter().Text("V.B");

                });
            });
        }
        private void CrearFooter(IContainer container)
        {
            container.Background("#8fce00").Padding(5).Row(row =>
            {
                row.RelativeItem().Padding(0).Column(col =>
                {
                    col.Item()
                        .Hyperlink("https://agricoladelsurpisco.com/")
                        .Text("www.agricoladelsurpisco.com");
                });
                row.RelativeItem().AlignRight().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });

                //row.RelativeItem().AlignRight()
                //        .Row(rowitem =>
                //        {
                //            rowitem.AutoItem().AlignRight().Text("USER : " + Login.nombre1 + " " + Login.apaterno1).SemiBold().FontSize(10)
                //                .FontColor(Colors.Red.Medium);

                //        });
                //   row.RelativeItem().AlignLeft().Text("Copyright © 2024 - Todos los derechos reservados");                
            });

        }

    }
}