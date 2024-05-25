using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Presentacion.Reporte;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3mpacador4.Presentacion.R00t
{
    public partial class FrmMod : Form
    {
        private formR00t formRoot;
        public int idclientelista = 0;
        public int idclientenuevo = 0;
        public int idlote = 0;
        public string idclplista = String.Empty;
        public string idclpnuevo = String.Empty;
        public string anio = String.Empty;
        public int status = 1;

        //    public string idnumguia = String.Empty;

        public FrmMod()
        {
            InitializeComponent();
            txtnumlote.Focus();
            PrepGrid(datalistado);
            PrepGrid(datalistado2);
        }

        private void btnSubirDoc_Click(object sender, EventArgs e)
        {
          //  VarIngresoPeso = cboLote.Text;
            FrmAgregarDoc F = new FrmAgregarDoc();
            F.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
          //  formRoot.Hide();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnumlote.Text))
            {
                MessageBox.Show("El campo no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            mostrarconsulta();
            mostrarconsulta2();
        }

        private void mostrarconsulta()
        {
            DataTable datos = null;
            try
            {
                // Desenlazar el DataGridView de los datos
                datalistado.DataSource = null;

                // Eliminar las columnas "Editar" y "Eliminar" si ya existen
                if (datalistado.Columns.Contains("editar"))
                    datalistado.Columns.Remove("editar");
                if (datalistado.Columns.Contains("eliminar"))
                    datalistado.Columns.Remove("eliminar");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var dtInicio = "null";
                var dtFin = "null";

                var fechaaño = Settings.Default.periodo;
                var partes = fechaaño.Split(' ')[0].Split('/');
                var año = partes[2];

                var iniciocadena = 0;

                var comando = new MySqlCommand("usp_tblticketpesaje_RptBoletaPesado2", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = txtnumlote.Text;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;             

                var adaptador = new MySqlDataAdapter(comando);
                datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;                 

                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        

                        withBlock.DataSource = datos;

                        ocultar_columnas();

                        // Agregar las columnas de "Editar" y "Eliminar"
                        DataGridViewButtonColumn columnaEditar = new DataGridViewButtonColumn();
                        columnaEditar.Name = "editar";
                        columnaEditar.HeaderText = "Edit";
                        columnaEditar.Text = "Edit";
                        columnaEditar.UseColumnTextForButtonValue = true;
                        datalistado.Columns.Add(columnaEditar);
                        datalistado.Columns["editar"].Width = 50; // Establece el ancho en 50 píxeles

                        DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();
                        columnaEliminar.Name = "eliminar";
                        columnaEliminar.HeaderText = "Delete";
                        columnaEliminar.Text = "Delete";
                        columnaEliminar.UseColumnTextForButtonValue = true;
                        datalistado.Columns.Add(columnaEliminar);
                        datalistado.Columns["eliminar"].Width = 50; // Establece el ancho en 50 píxeles

                        foreach (DataGridViewRow fila in datalistado.Rows)
                        {
                            if ((fila.Cells["editar"].Value != null && fila.Cells["editar"].Value.ToString() == "Edit") ||
                                (fila.Cells["eliminar"].Value != null && fila.Cells["eliminar"].Value.ToString() == "Delete"))
                            {
                                fila.Height = 30; // Establece el alto en 50 píxeles
                            }
                        }

                        tamanio();
                        lbllote.Text = txtnumlote.Text;
                        lblnum_guia.Text = datos.Rows[0][1].ToString();
                        lblnumdoc.Text = datos.Rows[0][8].ToString();   
                        lblexportador.Text = datos.Rows[0][5].ToString();
                        lblproductor.Text = datos.Rows[0][6].ToString();
                        lblclp.Text = datos.Rows[0][7].ToString();
                        idclplista = lblclp.Text;
                        idlote = int.Parse(datos.Rows[0][16].ToString());
                        idclientelista = int.Parse(datos.Rows[0][17].ToString());
                        lblcontarrecep.Text = datos.Rows.Count.ToString();
                        contarjaba_neto();
                      //  idnumguia =  datos.Rows[0][0].ToString();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        lbllote.Text = String.Empty;
                        lblnum_guia.Text = String.Empty;
                        lblnumdoc.Text = String.Empty;
                        lblexportador.Text = String.Empty;
                        lblproductor.Text = String.Empty;
                        lblclp.Text = String.Empty;
                        idclplista = String.Empty;
                 //       idnumguia = String.Empty;
                        idlote = 0;
                        idclientelista = 0;
                        lblcontarrecep.Text = "0";
                        contarjaba_neto();
                    }
                }
                txtnumlote.Focus();
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

        private DataTable mostrarconsulta2()
        {
            DataTable datos = null;
            try
            {
                // Desenlazar el DataGridView de los datos
                datalistado2.DataSource = null;

                // Eliminar las columnas "Editar" y "Eliminar" si ya existen
                if (datalistado2.Columns.Contains("editar"))
                    datalistado2.Columns.Remove("editar");
                if (datalistado2.Columns.Contains("eliminar"))
                    datalistado2.Columns.Remove("eliminar");

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var fechaaño = Settings.Default.periodo;
                var partes = fechaaño.Split(' ')[0].Split('/');
                var año = partes[2];

                var comando = new MySqlCommand("usp_tblticket_Descarte_Selectlote", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = txtnumlote.Text;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado2;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        ocultar_columnas2();
                        // Agregar las columnas de "Editar" y "Eliminar"
                        DataGridViewButtonColumn columnaEditar = new DataGridViewButtonColumn();
                        columnaEditar.Name = "editar";
                        columnaEditar.HeaderText = "Edit";
                        columnaEditar.Text = "Edit";
                        columnaEditar.UseColumnTextForButtonValue = true;
                        datalistado2.Columns.Add(columnaEditar);
                        datalistado2.Columns["editar"].Width = 50; // Establece el ancho en 50 píxeles

                        DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();
                        columnaEliminar.Name = "eliminar";
                        columnaEliminar.HeaderText = "Delete";
                        columnaEliminar.Text = "Delete";
                        columnaEliminar.UseColumnTextForButtonValue = true;
                        datalistado2.Columns.Add(columnaEliminar);
                        datalistado2.Columns["eliminar"].Width = 50; // Establece el ancho en 50 píxeles

                        foreach (DataGridViewRow fila in datalistado2.Rows)
                        {
                            if ((fila.Cells["editar"].Value != null && fila.Cells["editar"].Value.ToString() == "Edit") ||
                                (fila.Cells["eliminar"].Value != null && fila.Cells["eliminar"].Value.ToString() == "Delete"))
                            {
                                fila.Height = 30; // Establece el alto en 50 píxeles
                            }
                        }


                        tamanio2();
                        lblcontardesc.Text = datos.Rows.Count.ToString();
                        contarjaba_neto2();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                        lblcontardesc.Text = "0";
                        contarjaba_neto2();
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

        private void ocultar_columnas()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = true;
            datalistado.Columns[4].Visible = true;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[8].Visible = false;
            datalistado.Columns[9].Visible = false;
            datalistado.Columns[10].Visible = false;
            datalistado.Columns[11].Visible = true;
            datalistado.Columns[12].Visible = true;
            datalistado.Columns[13].Visible = false;
            datalistado.Columns[14].Visible = false;
            datalistado.Columns[15].Visible = false;
            datalistado.Columns[16].Visible = false;
            datalistado.Columns[17].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        private void ocultar_columnas2()
        {
            datalistado2.Columns[0].Visible = true;
            datalistado2.Columns[1].Visible = false;
            datalistado2.Columns[2].Visible = false;
            datalistado2.Columns[3].Visible = true;
            datalistado2.Columns[4].Visible = true;
            datalistado2.Columns[5].Visible = true;
            //datalistado.Columns[6].Visible = false;
            //datalistado.Columns[7].Visible = false;
            //datalistado.Columns[8].Visible = false;
            //datalistado.Columns[9].Visible = false;
            //datalistado.Columns[10].Visible = true;
            //datalistado.Columns[11].Visible = true;
            //datalistado.Columns[12].Visible = false;
            //datalistado.Columns[13].Visible = false;
            //datalistado.Columns[14].Visible = false;
            //datalistado.Columns[15].Visible = false;
            //datalistado.Columns[16].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        private void FrmMod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmdetallelote lote = new frmdetallelote();

            AddOwnedForm(lote);
            lote.ShowDialog();
        }

        private void chknumguia_CheckedChanged(object sender, EventArgs e)
        {
            if (!chknumguia.Checked)
            {
                modnumguia.Visible = false;
                txtnumguia.Enabled = false;

            }
            else
            {
                modnumguia.Visible = true;
                txtnumguia.Enabled = true;
            }
        }
       
        private void chkexportador_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkexportador.Checked)
            {
                modexport.Visible = false;
            }
            else
            {
                modexport.Visible = true;
                mostrarclientes();
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

        private void UpdateExportByfrmMod(int idclientenuevo, int idlote)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_frmmod_export_update", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_idcliente", MySqlType.Int).Value = idclientenuevo;
                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = idlote;
               
                comando.ExecuteNonQuery();

                MessageBox.Show(@"EXPORTADOR ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarconsulta();
                //LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void UpdateClpByfrmMod(string idclpnuevo, int idclientelista, int idlote)
        {
            bool resultado = VerificarClp();

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_frmmod_clp_update", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                if (resultado)
                {
                    comando.Parameters.AddWithValue("p_idclp", idclpnuevo);
                }
                else
                {
                    // El TextBox está vacío o no tiene más de 11 caracteres
                    MessageBox.Show("NO TIENE LOS DIGITOS COMPLETOS", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comando.Parameters.AddWithValue("p_idcliente", idclientelista);
                comando.Parameters.AddWithValue("p_idlote", idlote);

                comando.ExecuteNonQuery();
                MessageBox.Show(@"EXPORTADOR ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarconsulta();
                //LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void UpdateGuiaByfrmMod(int idlote)
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_frmmod_guia_update", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numguia", txtnumguia.Text);
                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = idlote;

                comando.ExecuteNonQuery();

                MessageBox.Show(@"NUMERO DE GUIA, ACTUALIZADO SATISFACTORIAMENTE.", @"Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarconsulta();
                //LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void chkclp_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkclp.Checked)
            {
                modclp.Visible = false;
                txtclp.Enabled = false;
                lblproductorMod.Visible = false;
            }
            else
            {
                modclp.Visible = true;
                txtclp.Enabled = true;
                lblproductorMod.Visible = true;
            }
        }      

        private void modclp_Click(object sender, EventArgs e)
        {
            UpdateClpByfrmMod(idclpnuevo, idclientenuevo, idlote);
        }

        private void txtnumlote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido de Windows cuando se presiona Enter
                e.Handled = true; // Indica que el evento se ha manejado para evitar que se propague

                // Cambiar el foco al siguiente control
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void modexport_Click(object sender, EventArgs e)
        {
            UpdateExportByfrmMod(idclientenuevo, idlote);
        }

        private void cbcliente_DropDownClosed(object sender, EventArgs e)
        {
            if (cbcliente.SelectedItem != null)
            {
                int indiceGuion = cbcliente.GetItemText(cbcliente.SelectedItem).IndexOf('-');

                if (indiceGuion != -1)
                {
                    string textoAntesDelGuion = cbcliente.GetItemText(cbcliente.SelectedItem).Substring(0, indiceGuion).Trim();
                    idclientenuevo = int.Parse(textoAntesDelGuion);
                }
                else
                {
                    idclientenuevo = 0;
                }
            }
        }

        private bool VerificarClp()
        {
            // Verificar si el TextBox no está vacío y tiene más de 11 caracteres
            if (!string.IsNullOrEmpty(txtclp.Text) && txtclp.Text.Length >= 11)
            {
                idclpnuevo = txtclp.Text;
                validarClp();
                return true; // El TextBox está lleno y tiene más de 11 caracteres
            }
            else
            {
                lblproductorMod.Text = "Ingrese todos los datos para validar !!!";
                return false; // El TextBox está vacío o no tiene más de 11 caracteres
            }
        }

        private void txtclp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VerificarClp();
            }
            catch (Exception)
            {
                throw;
            }           
        }

        private void validarClp()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                if (chkclp.Checked == true)
                {
                    comando = new MySqlCommand("usp_tblclp_Select", ConexionGral.conexion);
                    comando.CommandType = (CommandType)4;

                    comando.Parameters.AddWithValue("p_clp", MySqlType.Text).Value = txtclp.Text;
                }
                
                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {                   
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        lblproductorMod.Text = datos.Rows[0]["razonsocial"].ToString();                                       
                    }
                    else
                    {
                        lblproductorMod.Text = "No se encontraron datos !!!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comando != null)
                {
                    comando.Dispose();
                }
                ConexionGral.desconectar();
            }
        }

        private void PrepGrid(DataGridView dataGridView)
        {
            dataGridView.SuspendLayout();

            // Configuración de propiedades del DataGridView
            dataGridView.BackgroundColor = Color.Black;
            dataGridView.ForeColor = Color.Maroon;
            dataGridView.Font = new Font("Tahoma", 9.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToOrderColumns = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.5f, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.RowTemplate.Height = 17;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = true;

            dataGridView.ResumeLayout();
            dataGridView.PerformLayout();
        }

        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;


                withBlock.Columns["H LLEGADA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["H LLEGADA"].Width = 80;

                withBlock.Columns["N° PALLET"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["N° PALLET"].Width = 60;
                               
                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CANT JABAS"].Width = 50;

                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Format = "#.#0";
                withBlock.Columns["PESO BRUTO"].Width = 70;
           
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        private void tamanio2()
        {
            try
            {
                var withBlock = datalistado2;


                withBlock.Columns["FECHA PESAJE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["FECHA PESAJE"].Width = 80;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                withBlock.Columns["CANT JABAS"].Width = 50;

                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Format = "#.#0";
                withBlock.Columns["PESO BRUTO"].Width = 70;

                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                withBlock.Columns["PESO NETO"].Width = 70;


            }
            catch (Exception)
            {
                //  throw;
            }

        }

        private void modnumguia_Click(object sender, EventArgs e)
        {
            UpdateGuiaByfrmMod(idlote);
        }

        private void txtnumlote_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un dígito y no es la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un dígito ni una tecla de retroceso, cancelar la pulsación
                e.Handled = true;
            }
        }

        int Id_recepcion;
        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable datos = null;
            try
            {
                
                    if (datalistado.Columns[e.ColumnIndex].Name == "eliminar")
                    {
                    if (MessageBox.Show("Está seguro que desea borrar este registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Id_recepcion = Convert.ToInt32(datalistado.CurrentRow.Cells["ID"].Value.ToString());

                        if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                        var comando = new MySqlCommand("usp_frmmod_registro_delete", ConexionGral.conexion);
                        comando.CommandType = (CommandType)4;

                        comando.Parameters.AddWithValue("p_idticketpesaje", MySqlType.Int).Value = Id_recepcion;

                        comando.ExecuteNonQuery();

                        MessageBox.Show(@"Registro Eliminado satisfactoriamente.", @"Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mostrarconsulta();

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

        public void contarjaba_neto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO BRUTO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                }

                lblnetoRecepcion.Text = Strings.FormatNumber(total, 2);
                lblcontarjabarecep.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        public void contarjaba_neto2()
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

                lblnetoDescarte.Text = Strings.FormatNumber(total, 2);
                lblcontarjabadescarte.Text = Strings.FormatNumber(cantjabas, 0);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        int Id_descarte;
        private void datalistado2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable datos = null;
            try
            {

                if (datalistado2.Columns[e.ColumnIndex].Name == "eliminar")
                {
                    if (MessageBox.Show("Está seguro que desea borrar este registro?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Id_descarte = Convert.ToInt32(datalistado2.CurrentRow.Cells["ID"].Value.ToString());

                        if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                        var comando = new MySqlCommand("usp_frmmod_registro2_delete", ConexionGral.conexion);
                        comando.CommandType = (CommandType)4;

                        comando.Parameters.AddWithValue("p_idticketdescarte", MySqlType.Int).Value = Id_descarte;

                        comando.ExecuteNonQuery();

                        MessageBox.Show(@"Registro Eliminado satisfactoriamente.", @"Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mostrarconsulta();

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

        private void chklote_CheckedChanged(object sender, EventArgs e)
        {
            if (!chklote.Checked)
            {
                modlote.Visible = false;          
            }
            else
            {
                modlote.Visible = true;            
            }
        }

        private void modlote_Click(object sender, EventArgs e)
        {
            UpdateloteByfrmMod(status, idlote, anio);
        }

        private void UpdateloteByfrmMod(int status, int idlote, string anio)
        {
            try
            {
                var fechaaño = Settings.Default.periodo;
                var partes = fechaaño.Split(' ')[0].Split('/');
                anio = partes[2];

                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var comando = new MySqlCommand("usp_frmmod_lote_update", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_status", status);
                comando.Parameters.AddWithValue("p_idlote", MySqlType.Int).Value = idlote;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.VarChar).Value = anio;

                comando.ExecuteNonQuery();

                MessageBox.Show(@"LOTE ABIERTO SATISFACTORIAMENTE.", @"Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarconsulta();
                //LimpiarCampos();
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                ConexionGral.desconectar();
                MessageBox.Show("ALGO SALIO MAL \n" + ex.Message, @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
