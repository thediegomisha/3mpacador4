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
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
