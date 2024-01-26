using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FProgramaProceso : Form
    {
        public FProgramaProceso()
        {
            InitializeComponent();
            Cargar_lote();
        }


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

        private void Cargar_proceso_x_fecha(string ls_fecha_proceso)
        {
            MySqlCommand comando;
            try
            {
                cbxproceso.Items.Clear();
                cbxproceso.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblprograma_proceso_x_fecha", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("p_fecha_proceso", ls_fecha_proceso);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read()) 
                        cbxproceso.Items.Add(reader["idproceso"] + " - " + reader["descripcion"]);
                }

                ConexionGral.desconectar();
                cbxproceso.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, @"Algo salio Mal en usp_tblprograma_proceso_x_fecha :( ");
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

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = cboLote;
                    if (datos.Rows.Count != 0)
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

                var aux = new Programa_proceso();
                aux.fecha_proceso = Convert.ToDateTime(dtpf_proceso.Value);
                aux.idgrupo_turno = 1; // 
                aux.iddestino =
                    Convert.ToInt32(cboDestino.Text.Substring(0, cboDestino.Text.Contains("-").ToString().Length - 2));
                aux.idcategoria =
                    Convert.ToInt32(cbCategoria.Text.Substring(0,
                        cbCategoria.Text.Contains("-").ToString().Length - 2));
                aux.idpresentacion =
                    Convert.ToInt32(cbpresentacion.Text.Substring(0,
                        cbpresentacion.Text.Contains("-").ToString().Length - 2));
                aux.idterminal =
                    Convert.ToInt32(cbxterminal.Text.Substring(0,
                        cbxterminal.Text.Contains("-").ToString().Length - 2));
                aux.idusuario = 4;
                aux.flag_estado = "1";


                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var cmd = new MySqlCommand("select idlote from tbllote where numlote = @idlote", ConexionGral.conexion);
                cmd.Parameters.AddWithValue("@idlote", cboLote.Text.Trim());
                aux.idlote = Convert.ToInt32(cmd.ExecuteScalar());

                var comando = new MySqlCommand("usp_tblprograma_proceso_insert", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("p_fecha_produccion", aux.fecha_proceso);
                comando.Parameters.AddWithValue("p_idlote", aux.idlote);
                comando.Parameters.AddWithValue("p_idgrupo_turno", aux.idgrupo_turno);
                comando.Parameters.AddWithValue("p_iddestino", aux.iddestino);
                comando.Parameters.AddWithValue("p_idcategoria", aux.idcategoria);
                comando.Parameters.AddWithValue("p_idpresentacion", aux.idpresentacion);
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
                throw;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarCalibres(string ls_fecha_proceso)
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
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Calibre c = new Calibre();
                        c.calibre = Convert.ToInt32(reader["calibre"]);
                        c.ultimo_nro_print = Convert.ToInt32(reader["cantidad"]);
                        dgvcalibres.Rows.Add(c.calibre, c.ultimo_nro_print);
                        li_cantidad += c.ultimo_nro_print;
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
            Cargar_proceso_x_fecha(dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd"));
            MostrarCalibres(dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd"));
        }

        private void btnconteo_manual_Click(object sender, EventArgs e)
        {
            bool lb_estado = false;
            int li_idproceso;
            string ls_fecha_produccion;            

            if (cbxproceso.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar un Proceso Para la Fecha " + dtpbuscar_fecproduccion.Text.Trim(), "Avisoo...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ls_fecha_produccion = dtpbuscar_fecproduccion.Value.ToString("yyyy-MM-dd");
            li_idproceso = Convert.ToInt32(cbxproceso.Text.Substring(0, cbxproceso.Text.Contains("-").ToString().Length - 2));

            if (LConteo_manual.Existe_Conteo_manual_x_fecha(ls_fecha_produccion, li_idproceso) > 0)
            {
                MessageBox.Show("Ya se Genero el Ingreso Manual Para la Fecha " + dtpbuscar_fecproduccion.Text.Trim(), "Avisoo...!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rpta = MessageBox.Show("¿ ESTA SEGUR@ DE GENERAR EL PROCESO MANUAL PARA LA FECHA " + dtpbuscar_fecproduccion.Text.Trim() + " PROCESO " + cbxproceso.Text.Trim() + " ?", "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                for (int i = 0; i < dgvcalibres.RowCount; i++)
                {
                    if (Convert.ToInt32(dgvcalibres.Rows[i].Cells[1].Value) > 0 )
                    {
                        int li_calibre, li_cantidad;  
                        
                        li_calibre = Convert.ToInt32(dgvcalibres.Rows[i].Cells[0].Value);                        
                        li_cantidad = Convert.ToInt32(dgvcalibres.Rows[i].Cells[1].Value);

                        if (LConteo_manual.Conteo_Manual(li_idproceso, li_calibre, ls_fecha_produccion, li_cantidad) > 0)
                        {
                            lb_estado = true;
                        }
                    }
                }

                if (lb_estado)
                {
                    MessageBox.Show("SE INGRESARON LAS CANTIDADES POR CALIBRES CORRECTAMENTE", "AVISO...!!!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}