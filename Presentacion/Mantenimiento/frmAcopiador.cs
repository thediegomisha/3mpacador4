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
    public partial class frmAcopiador : Form
    {
        public frmAcopiador()
        {
            InitializeComponent();
            mostraracopiador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAcopiador2 F = new frmAcopiador2();
            F.ShowDialog();

        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void mostraracopiador()
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
                    var withBlock = this.datalistado;
                    if (datos.Rows.Count != 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;                       
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

    }
}
