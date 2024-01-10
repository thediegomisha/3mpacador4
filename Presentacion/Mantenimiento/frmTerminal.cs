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
using _3mpacador4.Entidad;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmTerminal : Form
    {
        public int terminalId { get; private set; }

        public frmTerminal()
        {
            InitializeComponent();
            MostrarTerminal(); 
        }
        public static bool editar;
        public static Terminal t = null;


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //var aux = new Terminal();
            frmTerminal2 F = new frmTerminal2();
            F.ShowDialog();
            MostrarTerminal();
        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void MostrarTerminal()
        {
            MySqlCommand comando;
            try
            {
                datalistado.Rows.Clear();

                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblterminal_select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Terminal c = new Terminal();
                        c.idterminal = Convert.ToInt32(reader["idterminal"]);
                        c.descripcion = reader["descripcion"].ToString();
                        c.flag_estado = reader["flag_estado"].ToString();
                        datalistado.Rows.Add(null, null, c.idterminal, c.descripcion, c.flag_estado == "1" ? true : false);
                    }
                    lblnro_reg.Text = datalistado.RowCount.ToString();
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var rpta = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL TERMINAL " + datalistado.CurrentRow.Cells[3].Value.ToString() + " ?"
                        , "Aviso...!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rpta == DialogResult.Yes)
                    {
                        MySqlCommand comando;
                        try
                        {
                            if (ConexionGral.conexion.State == ConnectionState.Closed)
                            {
                                ConexionGral.conectar();
                            }
                            comando = new MySqlCommand("usp_tblterminal_delete", ConexionGral.conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.AddWithValue("p_id", Convert.ToInt32(datalistado.CurrentRow.Cells[2].Value));
                            comando.ExecuteNonQuery();
                            MessageBox.Show("TERMINAL SE ELIMINO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ConexionGral.desconectar();
                            MostrarTerminal();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
            }
        }
    }
}