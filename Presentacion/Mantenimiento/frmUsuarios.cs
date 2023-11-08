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
using NPOI.SS.Formula.Functions;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmUsuarios : Form
    {
        public int usuarioId { get; private set; }

        public frmUsuarios()
        {
            InitializeComponent();
            mostrarusuario();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarios2 F = new frmUsuarios2();
            F.ShowDialog();
            mostrarusuario();
        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        public void mostrarusuario()
        {
           
                MySqlCommand comando;
                try
                {
                    if (ConexionGral.conexion.State == ConnectionState.Closed){
                        
                        ConexionGral.conectar();
                    }

                    comando = new MySqlCommand("usp_tbusuario_Select", ConexionGral.conexion);
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
                } catch (Exception ex)
                {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        
        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datalistado.Columns[e.ColumnIndex].Name == "Editar")
            {
                usuarioId = Convert.ToInt32(datalistado.CurrentRow.Cells["idusuarios"].Value.ToString());

                frmEditUsuarios editForm = new frmEditUsuarios();
                editForm.CargarDatosUsuario(usuarioId);

                editForm.idUsuarioedit = usuarioId;

                editForm.ShowDialog();
                mostrarusuario();
            }

            if (datalistado.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea ELIMINAR este usuario?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (r == DialogResult.OK)
                {
                    EliminarUsuario(usuarioId);
                    mostrarusuario();
                }
            }
        }




        private void EliminarUsuario(int idUsuario)
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("DELETE FROM tblusuarios WHERE idusuarios = @idUsuario", ConexionGral.conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}