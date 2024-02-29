using _3mpacador4.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class FrmDocAdjuntos : Form
    {
    Documentos objDoc = new Documentos();

        public FrmDocAdjuntos()
        {
        InitializeComponent();
        }
        private void LlenarData()
        {
            try
            {
                DataTable documentos = objDoc.ListarDocumentos();

                // Verificar si la tabla de documentos es nula o está vacía
                if (documentos != null && documentos.Rows.Count > 0)
                {
                    // Asignar origen de datos al DataGridView si hay documentos
                    datalistado.DataSource = documentos;
                    ocultar_columnas();
                    lblcontar.Text = documentos.Rows.Count.ToString();
                }
                else
                {
                    // Limpiar el DataGridView y la etiqueta si no hay documentos
                    datalistado.DataSource = null;
                //    ocultar_columnas();
                    lblcontar.Text = "0";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void FrmDocAdjuntos_Load(object sender, EventArgs e)
        {           
            RptBoletaPesadoDetalle formularioPrincipal = (RptBoletaPesadoDetalle)Application.OpenForms["RptBoletaPesadoDetalle"];
            string variableRecibida = formularioPrincipal.VarBolPesoDetalle;
            objDoc.Idlote = Convert.ToInt32(variableRecibida);
            LlenarData();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datalistado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var fila = datalistado.Rows[e.RowIndex];

                    int id = Convert.ToInt32(fila.Cells[0].Value.ToString());
                    objDoc.Id = id;
                    var Lista = new List<Documentos>();
                    Lista = objDoc.filtrodocumentos();

                    foreach (Documentos item in Lista)
                    {
                        //crear carpeta temporal, donde se guardaran los archivos
                        string direccion = AppDomain.CurrentDomain.BaseDirectory;
                        string carpeta = direccion + "/temp/";
                        string ubicacioncompleta = carpeta + item.Extension;

                        //validaciones

                        if (!Directory.Exists(carpeta))
                            Directory.CreateDirectory(carpeta);

                        if (File.Exists(ubicacioncompleta))
                            File.Delete(ubicacioncompleta);

                        File.WriteAllBytes(ubicacioncompleta, item.Documento);
                        Process.Start(ubicacioncompleta);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FrmDocAdjuntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void ocultar_columnas()
        {
            datalistado.Columns[0].Visible = false;
            
        }
    }
}
