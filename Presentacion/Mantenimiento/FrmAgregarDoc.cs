using _3mpacador4.Logica;
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
        //  private int textoLabel1;

        string variableDelPrimerFormulario;
        //   private IngresoPesos ingresospesos;

        public FrmAgregarDoc()
        {
            InitializeComponent();

            IngresoPesos primerFormulario = new IngresoPesos();
            variableDelPrimerFormulario = primerFormulario.MiVariable;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documentos";
            openFileDialog1.Filter = "Archivo PDF (*.pdf)|*.PDF";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtruta.Text = openFileDialog1.FileName;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            byte[] archivo = null;
            Stream MyStream = openFileDialog1.OpenFile();
            MemoryStream obj = new MemoryStream();
            MyStream.CopyTo(obj);
            archivo = obj.ToArray();

            //Agregar
            objDoc.Idlote = Convert.ToInt32(variableDelPrimerFormulario);
            objDoc.Nombre = txttitulo.Text;
            objDoc.Documento = archivo;
            objDoc.Extension = openFileDialog1.SafeFileName;
            MessageBox.Show(objDoc.AgregarDocumentos());

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
