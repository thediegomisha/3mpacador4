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
using Devart.Common;
using Microsoft.VisualBasic;
using _3mpacador4.Presentacion.Mantenimiento;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.SqlServer.Server;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.IO.Font.Constants;
using System.IO;

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class TblTrazabilidad : Form
    {
        public TblTrazabilidad()
        {
            InitializeComponent();
            PrepGrid();
            mostrarLote();
        }

        private void RptBoletaPesado_Load(object sender, EventArgs e)
        {

        }

        private void PrepGrid()
        {
            {
                var withBlock = this.datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = System.Drawing.Color.Black;
                withBlock.ForeColor = System.Drawing.Color.Maroon;
                withBlock.Font = new System.Drawing.Font("Tahoma", 11.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

                // 
                // establecer color de resaltado (opcional)
                // 
                withBlock.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Red;
                withBlock.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Yellow;

                // 
                // propiedades relacionadas con agregar / eliminar filas
                // 
                withBlock.AllowUserToAddRows = false;
                withBlock.AllowUserToDeleteRows = false;

                // 
                // propiedades relacionadas con cambiar el tamaño de columnas / filas en la celda tingkal
                // 
                withBlock.AllowUserToResizeColumns = false;
                withBlock.AllowUserToResizeRows = false;

                // 
                // propiedades que permiten al usuario ordenar columnas
                // 'haciendo clic en los encabezados de columna
                withBlock.AllowUserToOrderColumns = false;

                withBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;

                // propiedades que regulan las líneas uniformes de "cosméticos"
                // 
                withBlock.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;

                // propiedades relacionadas con el formato del encabezado de columna / encabezado de columna
                // NB. para poder aplicar ForeColor y BackColor al encabezado, luego
                // La propiedad EnableHeadersVisualStyles debe establecerse en FALSE
                // 
                withBlock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                withBlock.ColumnHeadersHeight = 40;
                withBlock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                withBlock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
                withBlock.EnableHeadersVisualStyles = false;
                withBlock.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                withBlock.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
                withBlock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // 
                // dado que DataGridView es solo para mostrar datos, no para medios de entrada de datos
                // luego ocultar RowHeader será mejor visto
                // 
                withBlock.RowHeadersVisible = false;
                withBlock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                // 

                // establecer columnas y filas de cambio de tamaño automático
                withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                withBlock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                // 
                // determina la altura de todas las filas
                // 
                withBlock.RowTemplate.Height = 20;

                // establecer el modo de selección
                // 
                withBlock.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                // 'establecer selección múltiple (elija más de 1 fila)  '
                withBlock.MultiSelect = true;

                // el siguiente es el formato por columna
                // ajusta la posición del texto en la celda

                withBlock.ResumeLayout();
                withBlock.PerformLayout();

            }
        }

        private void mostrarLote()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbllote_SelectTraceability", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = this.cboLote;
                    if (datos.Rows.Count != 0)
                    {
                        //var dr = datos.NewRow();
                        //dr["idlote"] = 0;
                        //dr["numlote"] = "Nuevo ...";
                        //datos.Rows.InsertAt(dr, 0);


                        withBlock.DataSource = datos;
                        withBlock.DisplayMember = "numlote";
                        withBlock.ValueMember = "idlote";
                        withBlock.SelectedIndex = -1;
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



        private void cboLote_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cboLote.Text))
                {
                    poblarLote();
                    mostrarDatosEnDataListado();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error " + "Error " + ex.Message, Constants.vbCritical);
            }
        }

        private void mostrarDatosEnDataListado()
        {
            try
            {
                MySqlCommand comando;
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbltrazabilidad_Select", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", cboLote.Text);

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                datalistado.DataSource = datos;

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void poblarLote()
        {
            MySqlCommand comando;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }

                comando = new MySqlCommand("usp_tbltrazabilidad_Select", ConexionGral.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                // Usamos el valor seleccionado del combo box
                string numLote = cboLote.Text;

                // Agregamos el parámetro al comando
                comando.Parameters.AddWithValue("p_numlote", numLote);

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                // Mostramos los datos en el datalistado
                datalistado.DataSource = datos;

                // También puedes asignar los datos a las etiquetas si es necesario
                if (datos.Rows.Count > 0)
                {
                    lblcliente.Text = datos.Rows[0]["cliente"].ToString();
                    lblproductor.Text = datos.Rows[0]["productor"].ToString();
                    lblproducto.Text = datos.Rows[0]["producto"].ToString();
                    lblclp.Text = datos.Rows[0]["clp"].ToString();
                    lblvariedad.Text = datos.Rows[0]["variedad"].ToString();
                    lblpesoneto.Text = datos.Rows[0]["ingresoplanta"].ToString();
                    lblfechaingreso.Text = datos.Rows[0]["fproceso"].ToString();
                    lblcantjabas.Text = datos.Rows[0]["cantjabas"].ToString();
                    // Otras asignaciones de etiquetas según sea necesario
                }

                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            InsertarRegistro();

        }

        private void InsertarRegistro()
        {
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed)
                {
                    ConexionGral.conectar();
                }
                var comando = new MySqlCommand("INSERT INTO tbltrazabilidad (numlote ,cliente,clp, productor ,producto ,variedad ,fproceso ,ingresoplanta ,cant_jabas ,destino ,calibre ,categoria ,presentacion ,cant_cajas)" + '\r'
                    + "VALUES(@numlote, @cliente, @clp, @productor, @producto, @variedad, @fproceso, @ingresoplanta, @cant_jabas, @destino, @calibre, @categoria, @presentacion, @cant_cajas)", ConexionGral.conexion);


                int numlote = Convert.ToInt32(cboLote.Text.ToString());

                comando.Parameters.AddWithValue("@numlote", MySqlType.Int).Value = numlote;
                comando.Parameters.AddWithValue("@cliente", this.lblcliente.Text);
                comando.Parameters.AddWithValue("@clp", this.lblclp.Text);
                comando.Parameters.AddWithValue("@productor", this.lblproductor.Text);

                comando.Parameters.AddWithValue("@producto", this.lblproducto.Text);
                comando.Parameters.AddWithValue("@variedad", this.lblvariedad.Text);
                //comando.Parameters.AddWithValue("@fproceso", Convert.ToDateTime(this.fproceso.Text));

                double pesoingreso = Convert.ToDouble(lblpesoneto.Text.ToString());

                comando.Parameters.AddWithValue("@ingresoplanta", MySqlType.Double).Value = pesoingreso;

                int cant_jabas = Convert.ToInt32(lblcantjabas.Text.ToString());

                comando.Parameters.AddWithValue("@cant_jabas", MySqlType.Int).Value = cant_jabas;

                //comando.Parameters.AddWithValue("@destino", MySqlType.Int).Value = cboDestino.Text.ToString();

                //int calibre = Convert.ToInt32(cbCalibre.Text.ToString());

                //comando.Parameters.AddWithValue("@calibre", MySqlType.Int).Value = calibre;
                //comando.Parameters.AddWithValue("@categoria", MySqlType.Int).Value = cbCategoria.Text.ToString();
                //comando.Parameters.AddWithValue("@presentacion", MySqlType.Text).Value = cbpresentacion .Text.ToString();

                //double cant_cajas = Convert.ToDouble(txtcant_cajas.Text.ToString());

                //comando.Parameters.AddWithValue("@cant_cajas", MySqlType.Int).Value = cant_cajas;



                comando.ExecuteNonQuery();
                MessageBox.Show("PESO REGISTRADO SATISFACTORIAMENTE.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                // limpiarcampos()
                //    this.chkcapturapeso.Checked = false;
                ConexionGral.desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // cuentacorrelativo_BG()
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboLote_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (datalistado.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportarPDF(datalistado);
        }

        private void ExportarPDF(DataGridView datalistado)
        {
            try
            {
                SaveFileDialog dialogoGuardar = new SaveFileDialog();
                dialogoGuardar.Filter = "Archivo PDF|*.pdf";
                dialogoGuardar.Title = "Guardar PDF";
                dialogoGuardar.ShowDialog();

                if (!string.IsNullOrEmpty(dialogoGuardar.FileName))
                {
                    using (var stream = new FileStream(dialogoGuardar.FileName, FileMode.Create))
                    {
                        using (var pdf = new PdfDocument(new PdfWriter(stream)))
                        {
                            // Crea una nueva página.
                            var page = pdf.AddNewPage();

                            // Dibujar en la página.
                            var canvas = new PdfCanvas(page);

                            //Rotación horizontal.
                            //pdf.SetDefaultPageSize(PageSize.A4.Rotate());
                            Document document = new Document(pdf);

                            // Darle estilo a la sección encabezado.css
                            Style estiloEncabezado = new Style()
                                .SetFontSize(12)
                                .SetBold()
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetMarginBottom(10);

                            // Título.
                            document.Add(new Paragraph("TABLERO DE TRAZABILIDAD").SetFontSize(12).AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado)); //Espacios para ajustar la iamgen, textos(decripciones) y cuadro RUC.

                            Style estiloNormal = new Style()
                                .SetFontSize(12)
                                .SetTextAlignment(TextAlignment.LEFT)
                                .SetMarginBottom(5);

                            // Añadeimos una imgaen de la empresa con posibilidad de ajustar sus dimensiones.
                            //string rutaImagen = "C:\\Users\\W10\\Pictures\\Saved Pictures\\logo.jpg";
                            string rutaImagen = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.jpg");

                            if (File.Exists(rutaImagen))
                            {
                                iText.Layout.Element.Image imgEmpresa = new iText.Layout.Element.Image(ImageDataFactory.Create(rutaImagen));
                                imgEmpresa.SetWidth(150);
                                imgEmpresa.SetHeight(100);
                                imgEmpresa.SetFixedPosition(40, 660);
                                document.Add(imgEmpresa);
                            }
                            else
                            {
                                MessageBox.Show("No se puede encontrar la ruta", "Error al cargar la Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            // Datos generales de la empresa.
                            document.Add(new Paragraph("AGRICOLA DEL SUR PISCO EIRL").SetFontSize(9).SetBold()
                                .SetFixedPosition(225, 740, 200));
                            document.Add(new Paragraph("Empacadora con productos de calidad  y respaldo de").SetFontSize(8)
                                .SetFixedPosition(200, 730, 200));
                            document.Add(new Paragraph("trabajadores capacitados").SetFontSize(8)
                                .SetFixedPosition(250, 720, 210));
                            document.Add(new Paragraph("PARCELA 081 NRO. S/N SECTOR SANTA ANA").SetFontSize(8)
                                .SetFixedPosition(210, 710, 200));
                            document.Add(new Paragraph("(CARR.LOS LIBERTADORES KM 1.5 -DEFENSORES)").SetFontSize(8)
                                .SetFixedPosition(200, 700, 200));
                            document.Add(new Paragraph("ICA-PISCO-SAN CLEMENTE").SetFontSize(8)
                                .SetFixedPosition(240, 690, 200));
                            document.Add(new Paragraph("Teléfono: 938438743").SetFontSize(8)
                                .SetFixedPosition(255, 680, 200));
                            document.Add(new Paragraph("E-mail: agricola.delsur@pisco.senasa.pe").SetFontSize(8)
                                .SetFixedPosition(220, 670, 200));
                            document.Add(new Paragraph("www.agricoladelsur-pisco.com.pe").SetFontSize(8)
                                .SetFixedPosition(230, 660, 200));

                            // Posición del rectángulo con sus divisiones.
                            float rectAncho = 155;
                            float rectAlto = 90;
                            float rectX = page.GetPageSize().GetWidth() - rectAncho - 33;
                            float rectY = page.GetPageSize().GetHeight() - rectAlto - 90;

                            canvas.SaveState();  // Guardar el estado actual del canvas

                            canvas.Rectangle(rectX, rectY, rectAncho, rectAlto);

                            // Configurar posición para las divisiones dentro del rectángulo
                            float divisionAlto = rectAlto / 3;
                            canvas.MoveTo(rectX, rectY + divisionAlto).LineTo(rectX + rectAncho, rectY + divisionAlto).Stroke();
                            canvas.MoveTo(rectX, rectY + 2 * divisionAlto).LineTo(rectX + rectAncho, rectY + 2 * divisionAlto).Stroke();

                            // Configurar posición para el texto dentro del rectángulo
                            float textX = rectX + 20; // Ajusta según necesidades (movido a la derecha)
                            float textY1 = rectY + 2 * divisionAlto + 7; // Ajusta según necesidades (posición del RUC)
                            float textY2 = rectY + divisionAlto + 7; // Ajusta según necesidades (posición de "GUIA DE REMISIÓN")

                            // Texto en la primera celda (RUC)
                            canvas.BeginText()
                                .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD), 12)
                                .MoveText(textX, textY1)
                                .ShowText("R.U.C. 20604679380")
                                .EndText();

                            // Texto en la segunda celda ("GUIA DE REMISIÓN")
                            canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(), 12)
                                .MoveText(textX, textY2)
                                .ShowText("     REPORTE")
                                .EndText();

                            // Texto en la tercera celda (Número de guía de remisión desde datalistado2_2)
                            string numeroGuiaRemision = $"   Nº T001 - 00001"; // Reemplaza esto con la lógica para obtener el número de guía de remisión
                            canvas.BeginText()
                                .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD), 11)
                                .MoveText(textX, textY2 - divisionAlto + 5) // Ajusta según necesidades
                                .ShowText(numeroGuiaRemision)
                                .EndText();

                            canvas.Stroke();

                            canvas.RestoreState();



                            // Creamos una línea horizontal que separa las secciones (encabezado, medio y inferior.
                            document.Add(new LineSeparator(new SolidLine()).SetMarginTop(20).SetMarginBottom(20).SetBackgroundColor(new DeviceRgb(255, 165, 0)));

                            document.Add(new Paragraph("TABLERO DE DATOS:").AddStyle(estiloNormal)
                                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)));

                            // En este list string especificamos las columnas que deseamos solo mostrar (no fue eliminar ya que deja espacios en blanco).
                            List<string> columnasMostradas = new List<string> { /*"GUIA REMISION", "FECHA PESAJE", "H LLEGADA", "CODIGO PRODUCCION",
                                "T. JABA", "T.PARIH", "CANT JABAS", "PESO BRUTO", "PESO JABAS", "PESO NETO", "PROMEDIO"*/ };

                            // Instanciamos la tabla para datalistado.
                            Table tabla = new Table(columnasMostradas.Count);

                            document.Add(tabla);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar el PDF: {ex.Message}\nDetalles: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
