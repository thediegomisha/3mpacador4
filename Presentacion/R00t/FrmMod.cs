using _3mpacador4.Logica;
using _3mpacador4.Presentacion.Mantenimiento;
using _3mpacador4.Properties;
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

namespace _3mpacador4.Presentacion.R00t
{
    public partial class FrmMod : Form
    {
        public FrmMod()
        {
            InitializeComponent();
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
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            mostrarconsulta();
        }

        private void mostrarconsulta()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                var dtInicio = "null";
                var dtFin = "null";

                var fechaaño = Settings.Default.periodo;
                var partes = fechaaño.Split(' ')[0].Split('/');
                var año = partes[2];

                var iniciocadena = 0;

                var comando = new MySqlCommand("usp_tblticketpesaje_RptGral", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        //ocultar_columnas();
                        //LBLCONTAR.Text = datalistado.RowCount.ToString();
                        //tamanio();
                        //contarGeneral();
                        //contarjabaGeneral();
                        //lblinfo1.Visible = false;
                        
                        lbllote.Text = datos.Rows[0][0].ToString();
                        lblnum_guia.Text = datos.Rows[0][1].ToString();
                        lblnumdoc.Text = datos.Rows[0][2].ToString();
                        lblexportador.Text = datos.Rows[0][6].ToString();
                        lblproductor.Text = datos.Rows[0][7].ToString();
                        lblclp.Text = datos.Rows[0][8].ToString();


                    }
                    else
                    {
                        withBlock.DataSource = null;
                        //      lblinfo1.Visible = true;
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
    }
}
