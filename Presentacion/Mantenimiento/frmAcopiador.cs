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
        public int acopiadorId { get; private set; }
        public frmAcopiador()
        {
            InitializeComponent();
            mostraracopiadores();
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

        public void mostraracopiadores()
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

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistado.Columns[e.ColumnIndex].Name == "Editar")
            {
                acopiadorId = Convert.ToInt32(datalistado.CurrentRow.Cells["idacopiador"].Value.ToString());

                frmEditAcopiador editForm = new frmEditAcopiador();
                editForm.CargarDatosProductor(acopiadorId);

                editForm.idAcopiadoredit = acopiadorId;

                editForm.ShowDialog();
                mostraracopiadores();
            }

            if (datalistado.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                DialogResult c = MessageBox.Show("¿Está seguro que desea ELIMINAR este productor?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (c == DialogResult.OK)
                {
                    if (datalistado.CurrentRow.Cells["idproductor"].Value != null)
                    {
                        acopiadorId = Convert.ToInt32(datalistado.CurrentRow.Cells["idproductor"].Value.ToString());
                        EliminarAcopiador(acopiadorId);
                        mostraracopiadores();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar una fila sin ID asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EliminarAcopiador(int idAcopiador)
        {
            MySqlCommand comando = null;

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("DELETE FROM tblacopiador WHERE idacopiador = @idAcopiador", ConexionGral.conexion);
                comando.Parameters.AddWithValue("@idAcopiador", idAcopiador);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Acopiador eliminado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Acopiador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el Acopiador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Para que no moleste la excepción JAJAJA.
                if (comando != null)
                {
                    comando.Dispose();
                }

                ConexionGral.desconectar();
            }
        }
    }
}
