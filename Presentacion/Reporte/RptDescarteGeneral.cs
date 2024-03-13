using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;
using Constants = Microsoft.VisualBasic.Constants;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;

// using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptDescarteGeneral : Form
    {
        private bool btnsearchallpress;
        private bool btnsearchpress;

        public RptDescarteGeneral()
        {
            InitializeComponent();
            this.Load += rpt1_Load;
        }

        private void rpt1_Load(object sender, EventArgs e)
        {
            PrepGrid();
            lblpuntero.Visible = false;
            comboboxgrupo();
            fechasgrupo();          
            fechaPeriodo.Format = DateTimePickerFormat.Custom;
            fechaPeriodo.CustomFormat = "yyyy";

       //     mostrarclientes();
            //mostrarconsulta();
       //     mostrarproductor();
        //    mostrarAcopiador();
       //     mostrarVariedad();
       //     mostrarMetodo();
       //     mostrarDestino();
           
        }

        private void comboboxgrupo()
        {
            cb_cliente.Enabled = false;
            cb_productor.Enabled = false;
        }

        private void fechasgrupo()
        {
            dtpfingresofin.Enabled = false;
            dtpfingresoini.Enabled = false;
            dtpprocesofin.Enabled = false;
            dtpprocesoini.Enabled = false;
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

                //var procedimientoAlmacenado = DeterminarProcedimientoAlmacenado();
                //var bandera = DeterminarBandera();
                var dtInicio = "null";
                var dtFin = "null"; 
                DateTime fechaseleccionada = fechaPeriodo.Value;
                string añoseleccionado = fechaseleccionada.Year.ToString();

                var iniciocadena = 0;

                var comando = new MySqlCommand("usp_tblticketdescarte_select", ConexionGral.conexion);
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
              
                if (btnsearchallpress)
                {
                  
                    comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Date).Value = añoseleccionado;
                }

                if (btnsearchpress)
                {
                //    comando.Parameters.AddWithValue(bandera, MySqlType.Date).Value = flag .Text ;
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


        //private string DeterminarProcedimientoAlmacenado()
        //{
        //    if (chkcliente.Checked && chkf_ing.Checked)
        //        return "usp_tblticketpesaje_Exportador";
        //    if (chkcliente.Checked)
        //        return "usp_tblticketpesaje_Exportador";
        //    if (chkproductor.Checked)
        //        return "usp_tblticketpesaje_Productor";           
        //    return "usp_tblticketpesaje_RptGral";
        //}

        //private string DeterminarBandera()
        //{
        //    if (chkcliente.Checked)
        //        return "p_idcliente";
        //    if (chkproductor.Checked)
        //        return "p_idproductor";           
        //    return null;
        //}

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
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

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
                withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

     
        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;


                withBlock.Columns["LOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["LOTE"].Width = 50;

                //withBlock.Columns["GUIA REMISION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["GUIA REMISION"].Width = 110;

                //withBlock.Columns["NUMDOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["NUMDOC"].Width = 65;

                withBlock.Columns["FECHA PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FECHA PESAJE"].Width = 90;

                    //withBlock.Columns["H LLEGADA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    //withBlock.Columns["H LLEGADA"].Width = 70;

                //withBlock.Columns["PRODUCTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["PRODUCTO"].Width = 60;
                    //withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment =
                    //    DataGridViewContentAlignment.MiddleRight;
                    //// .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                    //withBlock.Columns["PESO BRUTO"].Width = 80;

                    //withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment =
                    //    DataGridViewContentAlignment.MiddleRight;
                    //// .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                    //withBlock.Columns["PESO JABAS"].Width = 80;           
               
               
                    //withBlock.Columns["VARIEDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    //withBlock.Columns["VARIEDAD"].Width = 60;
                

                if (chkcliente.Checked)
                {
                }
                else
                {
                    withBlock.Columns["EXPORTADOR"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["EXPORTADOR"].Width = 200;
                }

                //withBlock.Columns["CODIGO PRODUCCION"].DefaultCellStyle.Alignment =
                //    DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["CODIGO PRODUCCION"].Width = 90;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("PESAJE").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["CANT JABAS"].Width = 50;


                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 80;

                //withBlock.Columns["PROM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //// .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                //withBlock.Columns["PROM"].Width = 50;
            }
            catch (Exception)
            {
                //  throw;
            }

            {
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
            }
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

     

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnsearchpress = true;
            btnsearchallpress = false;

            if (chkcliente.Checked || chkf_ing.Checked || chkf_proc.Checked || chkproductor.Checked)
                mostrarconsulta();
            else
                MessageBox.Show(@"Error Selecciona un Item para buscar !!!", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            btnsearchallpress = true;
            btnsearchpress = false;


            if (chkcliente.Checked == false && chkf_ing.Checked == false && chkf_proc.Checked == false && chkproductor.Checked == false)
            {
                mostrarconsulta();
               
            }
        }

    
     
    }
}