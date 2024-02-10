﻿using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;
using _3mpacador4.Presentacion.Trazabilidad;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FProgramaProceso : Form
    {
        public FProgramaProceso()
        {
            InitializeComponent();
            Cargar_lote();
        }

        public static string ls_fecha_produccion = "";

        public static Programa_proceso pp = null;
        string ls_tipo = "";

        private void Cargar_lote()
        {
            MySqlCommand comando = null;
            try
            {
                cboLote.Items.Clear();
                cboLote.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbllote_SelectTraceability", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", Convert.ToInt32(dtpbuscar_fecproduccion.Value.Year));

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cboLote.Items.Add(reader["numlote"].ToString());
                }

                ConexionGral.desconectar();
                cboLote.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal :( ");
                throw;
            }
        }

        private void Cargar_destino()
        {
            MySqlCommand comando = null;
            try
            {
                cboDestino.Items.Clear();
                cboDestino.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tbldestino_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cboDestino.Items.Add(reader["iddestino"] + " - " + reader["nombre"]);
                }

                ConexionGral.desconectar();
                cboDestino.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tbldestino_Select :( ");
                throw;
            }
        }

        private void Cargar_categoria()
        {
            MySqlCommand comando = null;
            try
            {
                cbCategoria.Items.Clear();
                cbCategoria.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcategoria_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cbCategoria.Items.Add(reader["idcategoria"] + " - " + reader["nombre"]);
                }

                ConexionGral.desconectar();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
            }
        }

        private void Cargar_presentacion()
        {
            MySqlCommand comando = null;
            try
            {
                cbpresentacion.Items.Clear();
                cbpresentacion.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblpresentacion_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cbpresentacion.Items.Add(reader["idpresentacion"] + " - " + reader["nombre"]);
                }

                ConexionGral.desconectar();
                cbpresentacion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
            }
        }

        private void Cargar_terminal()
        {
            MySqlCommand comando = null;
            try
            {
                cbxterminal.Items.Clear();
                cbxterminal.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblterminal_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cbxterminal.Items.Add(reader["idterminal"] + " - " + reader["descripcion"]);
                }

                ConexionGral.desconectar();
                cbxterminal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
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
                comando.Parameters.AddWithValue("p_fechaanio", Convert.ToInt32(dtpbuscar_fecproduccion.Value.Year));

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    if (datos.Rows.Count != 0)
                    {
                        lblcliente_desc.Text = datos.Rows[0]["RAZON SOCIAL"].ToString();
                        lblproductor.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //  lblmetodo.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        lblproducto.Text = datos.Rows[0]["PRODUCTO"].ToString();
                        //  lblservicio.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //  lblacopiador.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        // lblguiaingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        //  lblruc_dni.Text = datos.Rows[0]["PRODUCTOR"].ToString();
                        lblclp.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();
                        lblvariedad.Text = datos.Rows[0]["VARIEDAD"].ToString();
                        //lblfechaingreso.Text = datos.Rows[0]["FECHA PESAJE"].ToString();
                        //    lblhoraingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();

                        //lblpesoneto.Text = (datos.Rows[0]["PESO NETO"].ToString());
                        //lblcantjabas.Text = (datos.Rows[0]["CANT JABAS"].ToString());
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLote.SelectedIndex > 0)
                {
                    poblarLote();
                    Cargar_destino();
                    Cargar_categoria();
                    Cargar_presentacion();
                    Cargar_terminal();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void Cargar_Cliente()
        {
            MySqlCommand comando = null;
            try
            {
                cbxcliente.Items.Clear();
                cbxcliente.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblcliente_lista", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_anio", Convert.ToInt32(dtpbuscar_fecproduccion.Value.Year));

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) cbxcliente.Items.Add(reader["idcliente"] + " - " + reader["razon_social"]);
                }

                ConexionGral.desconectar();
                cbxcliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblcliente_lista :( ");
                throw;
            }
        }

        private void btncrearprograma_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLote.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione Un Lote", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cboDestino.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione un Destino", @"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbCategoria.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione una Categoria", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbpresentacion.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione una Presentación", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbxcliente.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Seleccione un Cliente", @"Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                var aux = new Programa_proceso();
                aux.fecha_proceso = Convert.ToDateTime(dtpf_proceso.Value);
                //aux.idgrupo_turno = 1; 
                aux.iddestino       = Convert.ToInt32(cboDestino.Text.Substring(0, cboDestino.Text.Contains("-").ToString().Length - 2));
                aux.idcategoria     = Convert.ToInt32(cbCategoria.Text.Substring(0,cbCategoria.Text.Contains("-").ToString().Length - 2));
                aux.idpresentacion  = Convert.ToInt32(cbpresentacion.Text.Substring(0,cbpresentacion.Text.Contains("-").ToString().Length - 2));
                aux.idcliente       = Convert.ToInt32(cbxcliente.Text.Substring(0, cbxcliente.Text.Contains("-").ToString().Length - 2));
                aux.idterminal      = Convert.ToInt32(cbxterminal.Text.Substring(0,cbxterminal.Text.Contains("-").ToString().Length - 2));
                aux.idusuario       = Login.usuarioId1;
                aux.flag_estado     = "1";


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var cmd = new MySqlCommand("select idlote from tbllote where numlote = @idlote and periodo = @anio", ConexionGral.conexion);
                cmd.Parameters.AddWithValue("@idlote", cboLote.Text.Trim());
                cmd.Parameters.AddWithValue("@anio", Convert.ToString(dtpbuscar_fecproduccion.Value.Year));
                aux.idlote = Convert.ToInt32(cmd.ExecuteScalar());

                var comando = new MySqlCommand("usp_tblprograma_proceso_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_fecha_produccion", aux.fecha_proceso);
                comando.Parameters.AddWithValue("p_idlote", aux.idlote);
                //comando.Parameters.AddWithValue("p_idgrupo_turno", aux.idgrupo_turno);
                comando.Parameters.AddWithValue("p_iddestino", aux.iddestino);
                comando.Parameters.AddWithValue("p_idcategoria", aux.idcategoria);
                comando.Parameters.AddWithValue("p_idpresentacion", aux.idpresentacion);
                comando.Parameters.AddWithValue("p_idcliente", aux.idcliente);
                comando.Parameters.AddWithValue("p_idterminal", aux.idterminal);
                comando.Parameters.AddWithValue("p_idusuario", aux.idusuario);
                comando.Parameters.AddWithValue("p_flag_estado", aux.flag_estado);
                comando.ExecuteNonQuery();
                MessageBox.Show(@"PROGRAMA REGISTRADO SATISFACTORIAMENTE.", @"Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //Lista_Grupo_turno(aux.fecha_produccion.ToString("yyyy-MM-dd"));
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(@"PROGRAMA NO REGISTRADO." + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboLote.SelectedIndex = 0;
                cbxcliente.SelectedIndex = 0;
                cbxterminal.SelectedIndex = 0;
                throw;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarCalibres(string ls_fecha_proceso, int li_idproceso, string ls_tipo)
        {
            MySqlCommand comando;
            try
            {
                int li_cantidad = 0;
                dgvcalibres.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcalibre_x_proceso", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_fecha_proceso", ls_fecha_proceso);
                comando.Parameters.AddWithValue("p_idproceso", li_idproceso);
                comando.Parameters.AddWithValue("p_tipo", ls_tipo);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*Calibre c = new Calibre();
                        c.calibre = Convert.ToInt32(reader["calibre"]);
                        c.ultimo_nro_print = Convert.ToInt32(reader["cantidad"]);*/
                        dgvcalibres.Rows.Add(Convert.ToInt32(reader["calibre"]), Convert.ToInt32(reader["cantidad"]), Convert.ToInt32(reader["nro_pallet"]));
                        li_cantidad += Convert.ToInt32(reader["cantidad"]);
                    }
                    lbltotal_calibre.Text = li_cantidad.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dtpbuscar_fecproduccion_ValueChanged(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnconteo_manual_Click(object sender, EventArgs e)
        {
            bool lb_estado = false;
            int li_idproceso = 0, li_idusuario = 0, li_idcliente = 0;
            string ls_fecha_produccion, ls_cliente = "";            

            if (lblid_proceso.Text.Length == 0)
            {
                MessageBox.Show("Debe Seleccionar un Proceso Para la Fecha " + dtpbuscar_fecproduccion.Text.Trim(), "Avisoo...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ls_fecha_produccion = dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd");
            li_idproceso = Convert.ToInt32(lblid_proceso.Text.Trim());
            li_idcliente = Convert.ToInt32(lblid_cliente.Text.Trim());
            ls_cliente = lblcliente.Text.Trim();
            li_idusuario = Login.usuarioId1;

            if (LConteo_manual.Existe_Conteo_manual_x_fecha(li_idproceso) > 0)
            {
                MessageBox.Show(@"Ya se Genero el Ingreso Manual del CLIENTE : "+ ls_cliente +
                                 " N° LOTE : " +lblnum_lote.Text.Trim()+" DESTINO :"+ lbldestino.Text.Trim() +" CATEGORIA : " +  lblcategoria.Text +
                                 " PRESENTACION : " + lblpresentacion.Text + " FECHA DE PRODUCCION : " + dtpbuscar_fecproduccion.Text.Trim(), 
                    "Avisoo...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpta = MessageBox.Show("¿ ESTA SEGUR@ DE GENERAR EL PROCESO MANUAL DEL CLIENTE : " + ls_cliente +" PARA LA FECHA : " + dtpbuscar_fecproduccion.Text.Trim() + " PROCESO N° " + lblid_proceso.Text.Trim() + " ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                for (int i = 0; i < dgvcalibres.RowCount; i++)
                {
                    if (Convert.ToInt32(dgvcalibres.Rows[i].Cells[1].Value) > 0 )
                    {
                        int li_calibre, li_cantidad, li_nro_pallet;  
                        
                        li_calibre = Convert.ToInt32(dgvcalibres.Rows[i].Cells[0].Value);                        
                        li_cantidad = Convert.ToInt32(dgvcalibres.Rows[i].Cells[1].Value);
                        li_nro_pallet = Convert.ToInt32(dgvcalibres.Rows[i].Cells[2].Value);

                        if (LConteo_manual.Conteo_Manual(li_idproceso, li_calibre, ls_fecha_produccion, li_idusuario, li_nro_pallet, li_cantidad, li_idcliente) > 0)
                        {
                            lb_estado = true;
                        }
                    }
                }

                if (lb_estado)
                {
                    MessageBox.Show("SE INGRESARON LAS CANTIDADES POR CALIBRES CORRECTAMENTE", "AVISO...!!!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Mostrar_conteo();
                }
            }
        }

        private void FProgramaProceso_Load(object sender, EventArgs e)
        {
            Cargar_Cliente();
        }

        private void cbxregistro_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxregistro_manual.Checked)
            {
                gbregistro_manual.Visible = true;
            }
            else
            {                
                gbregistro_manual.Visible = false;
            }
        }

        private void rbregistrar_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            if (rbregistrar.Checked)
            {
                btnconteo_manual.Enabled = true;
                ls_tipo = "R";                
            }            
        }

        private void rbbuscar_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            if (rbbuscar.Checked)
            {
                btnconteo_manual.Enabled = false;
                ls_tipo = "B";
            }
        }

        private void btnbuscar_proceso_Click(object sender, EventArgs e)
        {
            ls_fecha_produccion = dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd");

            pp = new Programa_proceso();
            var f = new FBuscar_proceso();
            f.ShowDialog();

            if (pp.idproceso > 0)
            {
                lblid_proceso.Text = pp.idproceso.ToString();

                lblid_lote.Text = pp.idlote.ToString();
                lblnum_lote.Text = pp.numlote.ToString();

                lblid_destino.Text = pp.iddestino.ToString();
                lbldestino.Text = pp.destino.ToString();

                lblid_categoria.Text = pp.idcategoria.ToString();
                lblcategoria.Text = pp.categoria.ToString();

                lblid_presentacion.Text = pp.idpresentacion.ToString();
                lblpresentacion.Text = pp.presentacion.ToString();

                lblid_cliente.Text = pp.idcliente.ToString();
                lblcliente.Text = pp.cliente.ToString();
            }

            Mostrar_conteo();
        }

        private void btnmostrar_conteo_manual_Click(object sender, EventArgs e)
        {
            //Mostrar_conteo();
        }

        void Limpiar() 
        {
            lblid_proceso.Text = "";
            lblid_lote.Text = "";
            lblnum_lote.Text = "";
            lblid_destino.Text = "";
            lbldestino.Text = "";
            lblid_categoria.Text = "";
            lblcategoria.Text = "";
            lblid_presentacion.Text = "";
            lblpresentacion.Text = "";
            lblid_cliente.Text = "";
            lblcliente.Text = "";            
            lbltotal_calibre.Text = "";
            dgvcalibres.Rows.Clear();
        }


        void Mostrar_conteo() 
        {
            int li_idproceso = 0;

            if (rbregistrar.Checked)
            {
                ls_tipo = "R";
            }
            else if (rbbuscar.Checked)
            {
                ls_tipo = "B";
                li_idproceso = Convert.ToInt32(lblid_proceso.Text.Length == 0 ? "0" : lblid_proceso.Text.Trim());
            }           

            MostrarCalibres(dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd"), li_idproceso, ls_tipo);

            if (rbregistrar.Checked)
            {
                dgvcalibres.Columns[3].Visible = true;
                dgvcalibres.Columns[4].Visible = true;
            }
            else
            {
                dgvcalibres.Columns[3].Visible = false;
                dgvcalibres.Columns[4].Visible = false;
            }  
        }


        private void dgvcalibres_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvcalibres.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    e.Value = "-";                    

                }
                else if (e.ColumnIndex == 4)
                {
                    e.Value = "=";
                }
            }
        }

        private void dgvcalibres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvcalibres.Columns[3].Index && e.RowIndex >= 0)
            {
                dgvcalibres.Rows.RemoveAt(e.RowIndex);
            }

            if (e.ColumnIndex == dgvcalibres.Columns[4].Index && e.RowIndex >= 0)
            {
                // Obtiene la posición de la fila seleccionada
                int rowIndex = e.RowIndex;   

                dgvcalibres.Rows.Insert(rowIndex + 1, dgvcalibres.Rows[rowIndex].Cells[0].Value, 0, "");
            }
        }

        private void dgvcalibres_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad = 0;
            if (e.ColumnIndex == dgvcalibres.Columns[1].Index || e.ColumnIndex == dgvcalibres.Columns[2].Index)
            {
                for (int i = 0; i < dgvcalibres.Rows.Count; i++)
                {
                    cantidad += Convert.ToInt32(dgvcalibres.Rows[i].Cells[1].Value);
                }              
            }

            lbltotal_calibre.Text = cantidad.ToString();
        }
    }
}