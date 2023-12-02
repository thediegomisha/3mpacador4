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
    public partial class frmCliente : Form
    {
        public int clienteId { get; private set; }

        public frmCliente()
        {
            InitializeComponent();
            mostrarclientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCliente2 F = new frmCliente2();
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

        public void mostrarclientes()
        {

            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {

                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblcliente_Select", ConexionGral.conexion);
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
                clienteId = Convert.ToInt32(datalistado.CurrentRow.Cells["idcliente"].Value.ToString());

                frmEditClientes editForm = new frmEditClientes();
                editForm.CargarDatosCliente(clienteId);

                editForm.idClienteedit = clienteId;

                editForm.ShowDialog();
                mostrarclientes();
            }

            if (datalistado.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                DialogResult c = MessageBox.Show("¿Está seguro que desea ELIMINAR este usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (c == DialogResult.OK)
                {
                    if (datalistado.CurrentRow.Cells["idcliente"].Value != null)
                    {
                        clienteId = Convert.ToInt32(datalistado.CurrentRow.Cells["idcliente"].Value.ToString());
                        EliminarCliente(clienteId);
                        mostrarclientes();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar una fila sin ID asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }




        private void EliminarCliente(int idCliente)
        {
            MySqlCommand comando = null;

            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("DELETE FROM tblcliente WHERE idcliente = @idCliente", ConexionGral.conexion);
                comando.Parameters.AddWithValue("@idCliente", idCliente);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Cliente eliminado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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