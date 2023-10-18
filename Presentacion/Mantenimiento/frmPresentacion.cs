using _3mpacador4.Logica;
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

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmpresentacion : Form
    {
        public frmpresentacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void mostrarPresentacion()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tblpresentacion_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Clear();

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                //{
                //    //var withBlock = this.cbjabas;
                //    //if (datos.Rows.Count != 0)
                //    {
                //        var dr = datos.NewRow();
                //        dr["idjabas"] = 0;
                //        dr["numjabas"] = "Nuevo ...";
                //        datos.Rows.InsertAt(dr, 0);

                //        withBlock.DataSource = datos;
                //        withBlock.DisplayMember = "numjabas";
                //        withBlock.ValueMember = "idjabas";
                //        withBlock.SelectedIndex = -1;
                //    }
                //    else
                //    {
                //        withBlock.DataSource = null;
                //    }
                //}
                ConexionGral.desconectar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void InsertarLote()
        //{
        //    try
        //    {
        //        if (ConexionGral.conexion.State == ConnectionState.Closed)
        //        {
        //            ConexionGral.conectar();
        //        }
        //        var comando = new MySqlCommand(" INSERT INTO tbllote(numlote)" + '\r'
        //            + "VALUES(LPAD(@numlote, 3, '0'))", ConexionGral.conexion);

        //        //var comando = new MySqlCommand("INSERT INTO tbllote (numlote)" + '\r'
        //        //   + "VALUES(@numlote)", ConexionGral.conexion);

        //        //INSERT INTO tbllote(numlote) VALUES(LPAD(numlote, 3, '0'))

        //        float cantlote = float.Parse(txtnumlote.Text);





        //        if (cantlote > 0)
        //        {
        //            comando.Parameters.AddWithValue("@numlote", MySqlType.Int).Value = cantlote;


        //        comando.ExecuteNonQuery();
        //        MessageBox.Show("PESO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
        //            // limpiarcampos()
        //            //    this.chkcapturapeso.Checked = false;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error, La cantidad tiene que ser mayor que 0", "CANTIDAD LOTE");
        //            return;
        //        }
        //        ConexionGral.desconectar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
