using _3mpacador4.Logica;
using _3mpacador4.Presentacion.Reporte;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class FrmAgregarDoc : Form
    {
       
        Documentos objDoc = new Documentos();

        string variableRecibida = "";
        int clickcodigo;

        public FrmAgregarDoc()
        {
            InitializeComponent();                       
        }
        private void FormularioBoton_BotonClickeado(object sender, EventArgs e)
        {
            // Manejar la lógica cuando el botón es clickeado desde otro formulario
            MessageBox.Show("El botón fue clickeado desde otro formulario.");
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documentos";
            openFileDialog1.Filter = "Todos los Archivos(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtruta.Text = openFileDialog1.FileName;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           // if(clickcodigo == 1)
         //   {
                byte[] archivo = null;
                Stream MyStream = openFileDialog1.OpenFile();
                MemoryStream obj = new MemoryStream();
                MyStream.CopyTo(obj);
                archivo = obj.ToArray();

                //Agregar
                objDoc.Idlote = Convert.ToInt32(variableRecibida);
                objDoc.Nombre = txttitulo.Text;
                objDoc.Documento = archivo;
                objDoc.Extension = openFileDialog1.SafeFileName;
                MessageBox.Show(objDoc.AgregarDocumentos());
         //   }
            //else
            //{
            //    MessageBox.Show("Hacer otra cosa");
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarDoc_Load(object sender, EventArgs e)
        {
            try
            {
                IngresoPesos formOrigen = (IngresoPesos)Application.OpenForms["IngresoPesos"];
                variableRecibida = formOrigen.VarIngresoPeso;
             }
            catch (Exception)
            {
            }
          
        }
    }
}
