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
        int Flag = 0;
    //    string extension = "";

        string variableRecibida = "";
        string numlote = "";
        int clickcodigo;
        string ruta;
        string ruta1;
        string ruta2;
        string ruta3;

        public FrmAgregarDoc()
        {
            InitializeComponent();                       
        }
       
        private void btnExaminar_Click(object sender, EventArgs e)
        {           
                openFileDialog1.InitialDirectory = "C:\\Documentos";
                openFileDialog1.Filter = "Todos los Archivos(*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   ruta= openFileDialog1.FileName;
                   lblguia.Text = "LTE - " + numlote + " - " + txtguia.Text;
            }           
        }
       
      

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 4; i++)
            {
                string nombreArchivo = ""; // Variable para almacenar el nombre del archivo original
                string nombre = "";
                byte[] archivo = null;

                // Obtener valores de la sección actual
                switch (i)
                {
                    case 1:
                        nombreArchivo = Path.GetFileName(ruta); // Obtener el nombre del archivo original
                                                                // Leer el archivo en un array de bytes
                  
                        using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                        {
                            archivo = new byte[fs.Length];
                            fs.Read(archivo, 0, archivo.Length);
                        }
                        nombre = lblguia.Text;
                        break;
                    case 2:
                        nombreArchivo = Path.GetFileName(ruta1);
                        // Leer el archivo en un array de bytes
                        using (FileStream fs = new FileStream(ruta1, FileMode.Open, FileAccess.Read))
                        {
                            archivo = new byte[fs.Length];
                            fs.Read(archivo, 0, archivo.Length);
                        }
                        nombre = lblclp.Text;
                        break;
                    case 3:
                        nombreArchivo = Path.GetFileName(ruta2);
                        // Leer el archivo en un array de bytes
                        using (FileStream fs = new FileStream(ruta2, FileMode.Open, FileAccess.Read))
                        {
                            archivo = new byte[fs.Length];
                            fs.Read(archivo, 0, archivo.Length);
                        }
                        nombre = lbldni.Text;
                        break;
                    case 4:
                        nombreArchivo = Path.GetFileName(ruta3);
                        // Leer el archivo en un array de bytes
                        using (FileStream fs = new FileStream(ruta3, FileMode.Open, FileAccess.Read))
                        {
                            archivo = new byte[fs.Length];
                            fs.Read(archivo, 0, archivo.Length);
                        }
                        nombre = lbldj.Text;
                        break;
                }
                // Agregar registro
                Documentos objDoc = new Documentos();
                objDoc.Idlote = Convert.ToInt32(variableRecibida);
                objDoc.Nombre = nombre;
                objDoc.Documento = archivo;
                objDoc.Extension = (nombreArchivo); // Obtener el nombre del archivo original
                objDoc.AgregarDocumentos();
            }

            MessageBox.Show("Los 4 registros se han guardado correctamente.");
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
                numlote = formOrigen.VarNumlote;

            }
            catch (Exception)
            {
            }
          
        }

            private void btnExaminar2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documentos";
            openFileDialog1.Filter = "Todos los Archivos(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta2 = openFileDialog1.FileName;
                lbldni.Text = "LTE - " + numlote + " - " + txtdni.Text;
            }   
        }

        private void btnExaminar3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Documentos";
            openFileDialog1.Filter = "Todos los Archivos(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta3 = openFileDialog1.FileName;
                lbldj.Text = "LTE - " + numlote + " - " + txtdj.Text;

            }
        }

        private void btnExaminar1_Click(object sender, EventArgs e)
     
            {
                openFileDialog1.InitialDirectory = "C:\\Documentos";
                openFileDialog1.Filter = "Todos los Archivos(*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                ruta1 = openFileDialog1.FileName;
                lblclp.Text = "LTE - " + numlote + " - " + txtclp.Text;
            }
        }
        }
}
