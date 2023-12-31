﻿using _3mpacador4.Logica;
using _3mpacador4.Presentacion.Mantenimiento;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class RptGeneral : Form
    {
        public RptGeneral()
        {
            InitializeComponent();
            comboboxgrupo();
            fechasgrupo();
            checkboxgrupo();
            texboxgrupo();
            
        }

        private void rpt1_Load(object sender, EventArgs e)
        {
            PrepGrid();
            PrepGrid2();
            PrepGrid3();
            mostrarclientes();
            //mostrarconsulta();
            mostrarproductor();
            mostrarAcopiador();
            mostrarVariedad();
            mostrarMetodo();
            mostrarDestino();
            lblpuntero.Visible  = false;
            
        }
        private void comboboxgrupo()
        {
            cb_cliente.Enabled= false;
            cb_destino.Enabled= false;
            cb_estado.Enabled= false;
            cb_metodo.Enabled= false;
            cb_productor.Enabled= false;
            cb_variedad.Enabled= false;
            cbAcopiador.Enabled = false;
        }
        private void fechasgrupo()
        {
            dtpfingresofin.Enabled= false;
            dtpfingresoini.Enabled= false;
            dtpprocesofin.Enabled = false;
            dtpprocesoini.Enabled= false;

        }
        private void checkboxgrupo()
        {
            chkcliente.Checked= false;
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
            txt_guia.Enabled= false;
            txt_lote.Enabled= false;
        }

        private void chkf_ing_CheckedChanged(object sender, EventArgs e)
        {
            if(chkf_ing.Checked == true)
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
            if (chkf_proc.Checked == true)
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
            if(chkcliente.Checked == true)
            {
                cb_cliente.Enabled = true;
            }
            else
            {
                cb_cliente.Enabled = false;
            }
        }

        private void chkproductor_CheckedChanged(object sender, EventArgs e)
        {
            if(chkproductor.Checked == true)
            {
                cb_productor.Enabled = true;
            }
            else
            {
                cb_productor.Enabled = false;
            }
        }

        private void chkestado_CheckedChanged(object sender, EventArgs e)
        {
            if(chkestado.Checked == true)
            {
                cb_estado.Enabled = true;
            }
            else
            {
                cb_estado.Enabled = false;
            }
        }

        private void chkvariedad_CheckedChanged(object sender, EventArgs e)
        {
            if(chkvariedad.Checked == true)
            {
                cb_variedad.Enabled = true;
            }
            else
            {
                cb_variedad.Enabled = false;
            }
        }

        private void chkmetodo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkmetodo.Checked == true)
            {
                cb_metodo.Enabled = true;
            }
            else
            {
                cb_metodo.Enabled = false;
            }
        }

        private void chkdestino_CheckedChanged(object sender, EventArgs e)
        {
            if(chkdestino.Checked == true)
            {
                cb_destino.Enabled = true;
            }
            else
            {
                cb_destino.Enabled = false;
            }
        }

        private void chklote_CheckedChanged(object sender, EventArgs e)
        {
            if(chklote.Checked == true)
            {
                txt_lote.Enabled = true;
            }
            else
            {
                txt_lote.Enabled = false;
            }
        }

        private void chkguia_CheckedChanged(object sender, EventArgs e)
        {
            if(chkguia.Checked == true)
            {
                txt_guia.Enabled = true;
            }
            else
            {
                txt_guia.Enabled = false;
            }
        }

        private void chk_acopiador_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_acopiador .Checked == true)
            {
                cbAcopiador .Enabled = true;
            }
            else
            {
                cbAcopiador.Enabled = false;
            }
        }

        private void mostrarclientes()
        {
            MySqlCommand comando;
          //  MostrarAnimacionEspera();
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
                    var withBlock = this.cb_cliente;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }
        private void mostrarconsulta()
        {
            string procedimientoalmacenado="null";
            string bandera = "null";
            string dtinicio = "null";
            string dtfin = "null";


            int iniciocadena;

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                if (chkcliente.Checked == true && chkf_ing.Checked  == true)
                {
                    procedimientoalmacenado = "usp_tblticketpesaje_Exportador";
                    //iniciocadena = cb_cliente.Text.IndexOf('-');
                    //flag.Text = cb_cliente.Text.Substring(0, iniciocadena);
                    bandera = "p_idcliente";
                    dtinicio = "p_fechainicio";
                    dtfin = "p_fechafin";
                }
                else if (chkcliente.Checked == true)
                {
                    procedimientoalmacenado = "usp_tblticketpesaje_Exportador";
                  //  iniciocadena = cb_cliente.Text.IndexOf('-');
                  //  flag.Text = cb_cliente.Text.Substring(0, iniciocadena);
                    bandera = "p_idcliente";                   
                }             
                else if (chkproductor.Checked == true)
                {
                    procedimientoalmacenado = "usp_tblticketpesaje_Productor";
                    iniciocadena = cb_productor.Text.IndexOf('-');
                    flag.Text = cb_productor.Text.Substring(0, iniciocadena);
                    bandera = "p_idproductor";
                }
                else if (chkvariedad.Checked == true)
                {
                    procedimientoalmacenado = "usp_tblticketpesaje_Variedad";                  
                    flag.Text = cb_variedad.SelectedValue.ToString();
                    bandera = "p_variedad";
                }
                else if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked == false && chk_acopiador.Checked == false)
                {
                    procedimientoalmacenado = "usp_tblticketpesaje_RptGral";                   
                }
                comando = new MySqlCommand(procedimientoalmacenado, ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked == false && chk_acopiador.Checked == false)
                {

                }
                else if (chkproductor.Checked == false && chkvariedad.Checked == false && chkcliente.Checked == true && chkf_ing.Checked == true && chk_acopiador.Checked == false)
                {
                    comando.Parameters.AddWithValue(bandera, MySqlType.Int).Value = flag.Text;
                    comando.Parameters.AddWithValue(dtinicio, MySqlType.Int).Value = dtpfingresoini.Value;
                    comando.Parameters.AddWithValue(dtfin, MySqlType.Int).Value = dtpfingresofin.Value;
                }
                else
                {
                    comando.Parameters.AddWithValue(bandera, MySqlType.Int).Value = flag.Text;
                }               

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PrepGrid()
        {
            {
                var withBlock = this.datalistado;
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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                var withBlock = this.datalistado2;
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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                var withBlock = this.datalistado3;
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
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                withBlock.Columns["GUIA REMISION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["GUIA REMISION"].Width = 90;

                withBlock.Columns["NUMDOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["NUMDOC"].Width = 70;


                withBlock.Columns["LOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["LOTE"].Width = 40;


                withBlock.Columns["FECHA PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FECHA PESAJE"].Width = 90;

                withBlock.Columns["H LLEGADA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["H LLEGADA"].Width = 70;

                withBlock.Columns["PRODUCTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["PRODUCTO"].Width = 60;

                if(chkvariedad.Checked == true)
                {
                   
                }
                else
                {
                    withBlock.Columns["VARIEDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["VARIEDAD"].Width = 60;
                }                               
                
                if(chkcliente.Checked == true)
                {                
                }
                else
                {
                    withBlock.Columns["EXPORTADOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["EXPORTADOR"].Width = 200;
                }

               if(chkproductor.Checked == true)
                {
                }
                else
                {
                    withBlock.Columns["PRODUCTOR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    withBlock.Columns["PRODUCTOR"].Width = 270;
                }                

                withBlock.Columns["CODIGO PRODUCCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CODIGO PRODUCCION"].Width = 90;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("PESAJE").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["CANT JABAS"].Width = 50;

                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 80;

                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO JABAS"].Width = 80;

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
        private void ocultar_columnas()
        {
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[1].Visible = false;
            this.datalistado.Columns[2].Visible = false;
            this.datalistado.Columns[3].Visible = true;
            this.datalistado.Columns[4].Visible = false;
            this.datalistado.Columns[5].Visible = false;
            this.datalistado.Columns[6].Visible = false;
            this.datalistado.Columns[7].Visible = false;
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[0].Visible = false;
            this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        
        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = this.datalistado.Rows[e.RowIndex];
               lblpuntero.Text  = fila.Cells[2].Value.ToString();
                mostrarconsulta2();
                contardescarte();
                sumanetodescarte();
                mostrarconsulta3();
            }
        }
       

        private DataTable mostrarconsulta2()
        {
            DataTable datos = new DataTable();

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticketpesaje_RptBoletaPesado", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;

                var adaptador = new MySqlDataAdapter(comando);
                // var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado2;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        //tamanio();
                        ocultar_columnas2();
                        //actualizardatos();
                        sumaneto();
                        contar();
                        lblinfo3.Visible = false;                        
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        lblinfo2.Visible = true;                       
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
            return datos;
        }

        private void mostrarconsulta3()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticket_Descarte_Selectlote", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = lblpuntero.Text;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado3;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        sumanetodescarte();
                        contardescarte();
                        lblinfo2.Visible = false;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        contardescarte();
                        lblinfo2.Visible = true;                     
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
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblproductor_Select3", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cb_productor;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
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
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "razon_social";
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarVariedad()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblvariedad_Select2", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cb_variedad;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarMetodo()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblmetodocultivo_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cb_metodo;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void mostrarDestino()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbldestino_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cb_destino;
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }


        private void ocultar_columnas2()
        {
            this.datalistado2.Columns[0].Visible = false;
            this.datalistado2.Columns[1].Visible = false;
            this.datalistado2.Columns[2].Visible = false;
            this.datalistado2.Columns[3].Visible = false;
            this.datalistado2.Columns[4].Visible = false;
            this.datalistado2.Columns[5].Visible = false;
            this.datalistado2.Columns[6].Visible = false;
            this.datalistado2.Columns[7].Visible = false;
            this.datalistado2.Columns[8].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;
            //this.datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            int contarfila = datalistado2.RowCount - 1;
            int contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }
            LBLCONTAR.Text = Strings.FormatNumber(contador, 0);
        }

        public void contarGeneral()
        {
            int contarfila = datalistado.RowCount - 1;
            int contador = 0;
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
                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        public void contardescarte()
        {
            int contarfila = datalistado3.RowCount - 1;
            int contador = 0;
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
            if (chkcliente.Checked == true || chkdestino.Checked == true || chkestado.Checked == true || chkf_ing.Checked == true
                || chkf_proc.Checked == true || chkguia.Checked == true || chklote.Checked == true || chkmetodo.Checked == true
                || chkproductor.Checked == true || chkvariedad.Checked == true || chk_acopiador.Checked == true)
            {
                mostrarconsulta();
            }
            else
            {
                MessageBox.Show("Error Selecciona un Item para buscar !!!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            if(chkcliente.Checked == false && chkdestino.Checked  == false && chkestado.Checked == false && chkf_ing.Checked == false
                && chkf_proc.Checked == false && chkguia.Checked == false && chklote.Checked == false && chkmetodo.Checked == false
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
                DataGridViewRow filasseleccionada = datalistado.Rows[e.RowIndex];

                string[] filaConDatos = new string[filasseleccionada.Cells.Count];

                for (int i = 0; i < filasseleccionada.Cells.Count; i++)
                {
                    filaConDatos[i] = filasseleccionada.Cells[i].Value.ToString();
                }

                DataTable resultados = mostrarconsulta2();

                RptBoletaPesadoDetalle FH = new RptBoletaPesadoDetalle(filaConDatos, resultados);

                FH.ShowDialog();

               
            }

        }

       
    }
}
