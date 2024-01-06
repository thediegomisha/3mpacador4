using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Presentacion.Mantenimiento;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using _3mpacador4;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmProductor : Form
    {
        public frmProductor()
        {
            InitializeComponent();
            mostrarclientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductor2 F = new frmProductor2();
            F.ShowDialog();
            mostrarclientes();

        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void mostrarclientes()
        {
           
                MySqlCommand comando;
                try
                {
                    if (ConexionGral.conexion.State == ConnectionState.Closed)
                    {
                        ConexionGral.conectar();
                    }

                    comando = new MySqlCommand("usp_tblproductor_Select", ConexionGral.conexion);
                    comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        //dr["idproducto"] = 0;
                        //dr["nombre"] = "Nuevo ...";
                        //datos.Rows.InsertAt(dr, 0);

                        withBlock.DataSource = datos;
                        //withBlock.DisplayMember = "nombre";
                        //withBlock.ValueMember = "idproducto";
                        //withBlock.SelectedIndex = -1;
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
                lblnro_reg.Text = datalistado.RowCount.ToString();
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

    }
}
