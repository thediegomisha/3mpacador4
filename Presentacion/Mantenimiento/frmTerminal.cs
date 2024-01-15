using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3mpacador4.Logica;
using Devart.Data.MySql;
using _3mpacador4.Entidad;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmTerminal : Form
    {

        public frmTerminal()
        {
            InitializeComponent();
            MostrarTerminal(); 
        }
        public static bool editar;
        public static Terminal t = null;

        public int terminalId { get; }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //var aux = new Terminal();
            F.ShowDialog();
            MostrarTerminal();
        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
        } 

        public void MostrarTerminal()
        {
            MySqlCommand comando;
            try
            {
                datalistado.Rows.Clear();


                comando = new MySqlCommand("usp_tblterminal_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                {
                    while (reader.Read())
                    {
                        c.idterminal = Convert.ToInt32(reader["idterminal"]);
                        c.descripcion = reader["descripcion"].ToString();
                        c.flag_estado = reader["flag_estado"].ToString();
                    }

                    lblnro_reg.Text = datalistado.RowCount.ToString();
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (datalistado.Columns[e.ColumnIndex].Index == 0) //EDITAR
                {
                    editar = true;

                    t = new Terminal();
                    t.idterminal = Convert.ToInt32(datalistado.CurrentRow.Cells[2].Value);
                    t.descripcion = datalistado.CurrentRow.Cells[3].Value.ToString();
                    t.flag_estado = datalistado.CurrentRow.Cells[4].Value.ToString();

                    var f = new frmTerminal2();
                    f.ShowDialog();
                    MostrarTerminal();

                    editar = false;
                }
                else if (datalistado.Columns[e.ColumnIndex].Index == 1) // ELIMINAR
                {
                    if (rpta == DialogResult.Yes)
                    {
                        MySqlCommand comando;
                        try
                        {
                            comando = new MySqlCommand("usp_tblterminal_delete", ConexionGral.conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.ExecuteNonQuery();
                            ConexionGral.desconectar();
                            MostrarTerminal();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
            }
        }
    }
}