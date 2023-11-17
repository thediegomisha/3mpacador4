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
using _3mpacador4.Entidad;
using _3mpacador4.Logica;
using Devart.Data.MySql;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmColaborador : Form
    {
        public frmColaborador()
        {
            InitializeComponent();
            MostrarColaborador();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmColaborador2 F = new frmColaborador2();
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

        public void MostrarColaborador()
        {
           
                MySqlCommand comando;
                try
                {
                    if (ConexionGral.conexion.State == ConnectionState.Closed)
                    {
                        ConexionGral.conectar();
                    }

                    comando = new MySqlCommand("usp_tblcolaborador_select", ConexionGral.conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Colaborador c = new Colaborador();
                            c.idcolaborador = Convert.ToInt32(reader["idcolaborador"]);
                            c.dni = reader["dni"].ToString();
                            c.nombres = reader["nombres"].ToString();
                            c.apel_paterno = reader["apel_paterno"].ToString();
                            c.apel_materno = reader["apel_materno"].ToString();
                            c.flag_estado = reader["flag_estado"].ToString();
                            datalistado.Rows.Add(null, null, c.idcolaborador, c.dni, c.nombres, c.apel_paterno, c.apel_materno, c.flag_estado == "1" ? true : false);
                        }
                    lblnro_reg.Text = datalistado.RowCount.ToString();
                    }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistado.Columns[e.ColumnIndex].Index == 0)
            {
                var f = new frmColaborador2();
                f.ShowDialog();
            }
        }
    }
}
