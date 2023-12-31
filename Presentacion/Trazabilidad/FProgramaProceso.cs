﻿using _3mpacador4.Logica;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Common;
using Microsoft.VisualBasic;
using _3mpacador4.Presentacion.Mantenimiento;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.SqlServer.Server;
using _3mpacador4.Entidad;

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
            MySqlCommand comando;
            try
            {
                cboLote.Items.Clear();
                cboLote.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbllote_SelectTraceability", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboLote.Items.Add(reader["numlote"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cboLote.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal :( ");
                throw;
            }
        }

        private void Cargar_destino()
        {
            MySqlCommand comando;
            try
            {
                cboDestino.Items.Clear();
                cboDestino.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbldestino_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboDestino.Items.Add(reader["iddestino"].ToString() + " - " + reader["nombre"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cboDestino.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal en usp_tbldestino_Select :( ");
                throw;
            }
        }

        private void Cargar_categoria()
        {
            MySqlCommand comando;
            try
            {
                cbCategoria.Items.Clear();
                cbCategoria.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcategoria_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbCategoria.Items.Add(reader["idcategoria"].ToString() + " - " + reader["nombre"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
            }
        }

        private void Cargar_presentacion()
        {
            MySqlCommand comando;
            try
            {
                cbpresentacion.Items.Clear();
                cbpresentacion.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblpresentacion_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbpresentacion.Items.Add(reader["idpresentacion"].ToString()+" - "+reader["nombre"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cbpresentacion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
            }
        }

        private void Cargar_terminal()
        {
            MySqlCommand comando;
            try
            {
                cbxterminal.Items.Clear();
                cbxterminal.Items.Add("< Seleccione >");

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblterminal_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbxterminal.Items.Add(reader["idterminal"].ToString() + " - " + reader["descripcion"].ToString());
                    }
                }
                ConexionGral.desconectar();
                cbxterminal.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show(ex.Message, "Algo salio Mal en usp_tblcategoria_Select :( ");
                throw;
            }
        }

        private void poblarLote()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblticketpesaje_Select_Trazability", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = (cboLote.Text.ToString()); ;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cboLote;
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
                        lblvariedad .Text = datos.Rows[0]["VARIEDAD"].ToString();
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
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void InsertarRegistro()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                var comando = new MySqlCommand("INSERT INTO tbltrazabilidad (numlote ,cliente,clp, productor ,producto ,variedad ,fproceso ,ingresoplanta ,cant_jabas ,destino ,calibre ,categoria ,presentacion ,cant_cajas)" + '\r'
                    + "VALUES(@numlote, @cliente, @clp, @productor, @producto, @variedad, @fproceso, @ingresoplanta, @cant_jabas, @destino, @calibre, @categoria, @presentacion, @cant_cajas)", ConexionGral.conexion);

                //float tarajaba = float.Parse(txttarajaba.Text);
                //float taraparihuela = float.Parse(txttaraParihuela.Text);
                //float pesobruto = float.Parse(lblpeso.Text);
                //float pesobrutoManual = float.Parse(txtPesoManual.Text);

                int numlote = Convert.ToInt32(cboLote.Text.ToString());

                comando.Parameters.AddWithValue("@numlote", MySqlType.Int).Value = numlote;
                comando.Parameters.AddWithValue("@cliente", this.lblcliente.Text);
                comando.Parameters.AddWithValue("@clp", this.lblclp.Text);
                comando.Parameters.AddWithValue("@productor", this.lblproductor.Text);

                comando.Parameters.AddWithValue("@producto", this.lblproducto.Text);
                comando.Parameters.AddWithValue("@variedad", this.lblvariedad.Text);
                comando.Parameters.AddWithValue("@fproceso", Convert.ToDateTime(this.dtpf_proceso.Text));

                //double pesoingreso = Convert.ToDouble(lblpesoneto.Text.ToString());

                //comando.Parameters.AddWithValue("@ingresoplanta", MySqlType.Double).Value = pesoingreso;

                //int cant_jabas = Convert.ToInt32(lblcantjabas.Text.ToString());

                //comando.Parameters.AddWithValue("@cant_jabas", MySqlType.Int).Value = cant_jabas;

                comando.Parameters.AddWithValue("@destino", MySqlType.Int).Value = cboDestino.Text.ToString();

                //int calibre = Convert.ToInt32(cbCalibre.Text.ToString());

                //comando.Parameters.AddWithValue("@calibre", MySqlType.Int).Value = calibre;
                comando.Parameters.AddWithValue("@categoria", MySqlType.Int).Value = cbCategoria.Text.ToString();
                comando.Parameters.AddWithValue("@presentacion", MySqlType.Text).Value = cbpresentacion .Text.ToString();

               // double cant_cajas = Convert.ToDouble(txtcant_cajas.Text.ToString());

                //comando.Parameters.AddWithValue("@cant_cajas", MySqlType.Int).Value = cant_cajas;



                comando.ExecuteNonQuery();
                MessageBox.Show("PESO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                // limpiarcampos()
                //    this.chkcapturapeso.Checked = false;
                ConexionGral.desconectar();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // cuentacorrelativo_BG()
        }

        private void btncrearprograma_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLote.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione Un Lote", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cboDestino.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un Destino", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbCategoria.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione una Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cbpresentacion.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione una Presentación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }             

                var aux = new Programa_proceso();
                aux.fecha_proceso = Convert.ToDateTime(dtpf_proceso.Value);                
                aux.idgrupo_turno = 1;// 
                aux.iddestino = Convert.ToInt32(cboDestino.Text.Substring(0, cboDestino.Text.Contains("-").ToString().Length - 2));
                aux.idcategoria = Convert.ToInt32(cbCategoria.Text.Substring(0, cbCategoria.Text.Contains("-").ToString().Length - 2));
                aux.idpresentacion = Convert.ToInt32(cbpresentacion.Text.Substring(0, cbpresentacion.Text.Contains("-").ToString().Length - 2));
                aux.idterminal = Convert.ToInt32(cbxterminal.Text.Substring(0, cbxterminal.Text.Contains("-").ToString().Length - 2));
                aux.idusuario = 4;
                aux.flag_estado = "1";


                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

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
                MessageBox.Show("PROGRAMA REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Lista_Grupo_turno(aux.fecha_produccion.ToString("yyyy-MM-dd"));
                ConexionGral.desconectar();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("PROGRAMA NO REGISTRADO. \n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    
}
