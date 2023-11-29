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

                string numLote = cboLote.Text;

                comando.Parameters.AddWithValue("p_numlote", numLote);

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                // Especificamos las columnas que queramos mostrar en el datalistado.
                var datosMostrados = datos.DefaultView.ToTable(false, "ID", "Calibre", "Presentacion", "Cant Cajas");

                datalistado.DataSource = datosMostrados;

                //Aquí especificamos al datalistado que no genere columnas que no hayamos especificado.
                datalistado.AutoGenerateColumns = false;

                if (datos.Rows.Count > 0)
                { 
                    // Asignar las demás columnas a los labels
                    lblnumlote.Text = datos.Rows[0]["numlote"].ToString();
                    lblcliente.Text = datos.Rows[0]["cliente"].ToString();
                    lblclp.Text = datos.Rows[0]["clp"].ToString();
                    lblproductor.Text = datos.Rows[0]["productor"].ToString();
                    lblproducto.Text = datos.Rows[0]["producto"].ToString();
                    lblvariedad.Text = datos.Rows[0]["variedad"].ToString();
                    lblfproceso.Text = datos.Rows[0]["fproceso"].ToString();
                    lblcategoria.Text = datos.Rows[0]["categoria"].ToString();
                    lblingresoplanta.Text = datos.Rows[0]["ingresoplanta"].ToString();
                    lblcantjabas.Text = datos.Rows[0]["cant_jabas"].ToString();
                    lbldestino.Text = datos.Rows[0]["destino"].ToString();

                    lblinfo.Visible = false;
                }
                else
                {
                    //Se muestra el label cuando no haya datos en el datalistado.
                    lblinfo.Visible = true;
                }


                ConexionGral.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                            document.Add(new Paragraph($"TABLERO DE TRAZABILIDAD      LOTE Nº {lblnumlote.Text}").SetFontSize(12).AddStyle(estiloEncabezado));
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

                            document.Add(new Paragraph("INFORMACIÓN:").AddStyle(estiloNormal)
                                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)));


                            // Datos generales de la empresa.
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));
                            document.Add(new Paragraph("").AddStyle(estiloEncabezado));

                            document.Add(new Paragraph($"CLIENTE:     {lblcliente.Text}").SetFontSize(9)
                                .SetFixedPosition(35, 580, 200));
                            document.Add(new Paragraph($"PRODUCTOR:     {lblproductor.Text}").SetFontSize(9)
                                .SetFixedPosition(35, 560, 200));
                            document.Add(new Paragraph($"VARIEDAD:     {lblvariedad.Text}").SetFontSize(9)
                                .SetFixedPosition(35, 540, 200));
                            document.Add(new Paragraph($"INGRESO PLANTA:     {lblingresoplanta.Text}").SetFontSize(9)
                                .SetFixedPosition(35, 520, 200));
                            document.Add(new Paragraph($"DESTINO:     {lbldestino.Text}").SetFontSize(9)
                                .SetFixedPosition(35, 500, 200));
                            document.Add(new Paragraph($"CLP:     {lblclp.Text}").SetFontSize(9)
                                .SetFixedPosition(260, 580, 200));
                            document.Add(new Paragraph($"PRODUCTO:     {lblproducto.Text}").SetFontSize(9)
                                .SetFixedPosition(260, 560, 200));
                            document.Add(new Paragraph($"F PROCESO:     {lblfproceso.Text}").SetFontSize(9)
                                .SetFixedPosition(260, 540, 200));
                            document.Add(new Paragraph($"CANT JABAS:     {lblcantjabas.Text}").SetFontSize(9)
                                .SetFixedPosition(260, 520, 200));
                            document.Add(new Paragraph($"CATEGORÍA:     {lblcategoria.Text}").SetFontSize(9)
                                .SetFixedPosition(260, 500, 200));




                            document.Add(new Paragraph("TABLERO DE DATOS:").AddStyle(estiloNormal)
                                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)));

                                // Añadimos los nombres de las columnas.
                                Table tabla = new Table(datalistado.Columns.Count);

                                for (int c = 0; c < datalistado.Columns.Count; c++)
                                {
                                    Cell pdfCeldas = new Cell().Add(new Paragraph(datalistado.Columns[c].HeaderText))
                                        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                                        .SetFontSize(11);

                                    tabla.AddCell(pdfCeldas);
                                }

                                // Añadimos los datos de las filas del datagrid.
                                for (int f = 0; f < datalistado.Rows.Count; f++)
                                {
                                    for (int c = 0; c < datalistado.Columns.Count; c++)
                                    {
                                        Cell pdfCeldas = new Cell().Add(new Paragraph(datalistado[c, f].Value.ToString()))
                                            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                                            .SetFontSize(10);

                                        tabla.AddCell(pdfCeldas);
                                    }
                                }
                                document.Add(tabla);

                            document.Add(new LineSeparator(new SolidLine()).SetMarginTop(20).SetMarginBottom(20).SetBackgroundColor(new DeviceRgb(255, 165, 0)));

                            //Sección inferior de la hoja con estilos.css
                            document.Add(new Paragraph("Firmas:")
                                .AddStyle(estiloEncabezado)
                                .SetTextAlignment(TextAlignment.LEFT));

                                //Código de estilos para las firmas.
                                Style estiloFirma = new Style()
                                    .SetFontSize(12)
                                    .SetTextAlignment(TextAlignment.LEFT)
                                    .SetMarginBottom(10);

                                document.Add(new Paragraph("").AddStyle(estiloFirma));

                                document.Add(new Paragraph("__________________________").AddStyle(estiloFirma));
                                document.Add(new Paragraph("Gerente General").AddStyle(estiloNormal));

                                document.Add(new Paragraph("").AddStyle(estiloFirma));
                                document.Add(new Paragraph("").AddStyle(estiloFirma));

                                document.Add(new Paragraph("__________________________").AddStyle(estiloFirma));
                                document.Add(new Paragraph("Encargado de Planta").AddStyle(estiloNormal));

                                // Números de página
                                /*Cuando quito los coentarios de este código, la excepción dice que: Estoy intentando agregar contenido
                                  al documento después de que ya ha sido cerrado, pero el document.Close(); está bien colocado, ya que 
                                  está despues de toda modificación :( */
                                int totalPaginas = pdf.GetNumberOfPages();
                                for (int p = 1; p <= totalPaginas; p++)
                                {
                                    document.ShowTextAligned(new Paragraph($"Página {p} de {totalPaginas}"),
                                        pdf.GetDefaultPageSize().GetWidth() - 50, 30, p, TextAlignment.RIGHT,
                                        iText.Layout.Properties.VerticalAlignment.TOP, 0);
                                }

                                document.Close();

                                MessageBox.Show("Los datos se han exportado a PDF correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
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
