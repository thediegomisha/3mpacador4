using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using iText.Layout.Element;
using Microsoft.VisualBasic;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using IContainer = QuestPDF.Infrastructure.IContainer;
using Settings = _3mpacador4.Properties.Settings;

//using Microsoft.Office.Interop.Excel;
//using objExcel  = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;


namespace _3mpacador4.Presentacion.Reporte
{


    public partial class RptBoletaPesado : Form

    {
        //  String nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string nombreArchivo = "C:/archivo.xlsx";

        // Label[] labels = new Label[] { lblciente, label2, label3, label4, label5, label6 };
      //  QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;


        public RptBoletaPesado()
        {
            InitializeComponent();
            PrepGrid();
        }

        private void GenerarPDF()
        {
            // Configurar la licencia de QuestPDF
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        
            var doc = Document.Create(contenedor => contenedor.Page(pagina =>
            {
                pagina.Size(PageSizes.A4);
                pagina.Margin(2, Unit.Centimetre);
                pagina.DefaultTextStyle(x => x.FontSize(12));

                pagina.Content()
                    .Column(x => x.Item().Text(Placeholders.Paragraph()));
            }));

            doc.GeneratePdf("simple.pdf");

        }

      

        private void RptBoletaPesado_Load(object sender, EventArgs e)
        {
        }

        private void mostrarconsulta()
        {
            MySqlCommand comando = null;
            try
            {
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticketpesaje_RptBoletaPesado", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = txtnumlote.Text;

                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
              

                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;

                var adaptador = new MySqlDataAdapter(comando);
                var datos = new DataTable();
                adaptador.Fill(datos);

                {
                    var withBlock = datalistado;
                    if (datos != null && datos.Rows.Count > 0)
                    {
                        var dr = datos.NewRow();
                        withBlock.DataSource = datos;
                        tamanio();
                        ocultar_columnas();
                        actualizardatos();
                        sumaneto();
                        contar();
                    }
                    else
                    {
                        withBlock.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConexionGral.desconectar();
            }
        }

        private void actualizardatos()
        {
            lblcliente.Text = datalistado.Rows[0].Cells[6].Value.ToString();
            lblproductor.Text = datalistado.Rows[0].Cells[7].Value.ToString();
            lblclp.Text = datalistado.Rows[0].Cells[8].Value.ToString();
            lblproducto.Text = datalistado.Rows[0].Cells[4].Value.ToString();
            lblvariedad.Text = datalistado.Rows[0].Cells[5].Value.ToString();
            lblfechaingreso.Text = datalistado.Rows[0].Cells[1].Value.ToString();
            lblhoraingreso.Text = datalistado.Rows[0].Cells[2].Value.ToString();
            lblguiaingreso.Text = datalistado.Rows[0].Cells[0].Value.ToString();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            mostrarconsulta();
        }

        private void PrepGrid()
        {
            {
                var withBlock = datalistado;
                withBlock.SuspendLayout();

                // propiedades que establecen el color de fondo del control DataGridView,
                // 'color del texto y tipo de fuente (tipo, tamaño y estilo)
                // 
                withBlock.BackgroundColor = Color.Black;
                withBlock.ForeColor = Color.Maroon;
                withBlock.Font = new Font("Tahoma", 11.0f, FontStyle.Regular, GraphicsUnit.Point, 0);

                // 
                // establecer color de resaltado (opcional)
                // 
                withBlock.DefaultCellStyle.SelectionBackColor = Color.Red;
                withBlock.DefaultCellStyle.SelectionForeColor = Color.Yellow;

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

                withBlock.BorderStyle = BorderStyle.None;

                // propiedades que regulan las líneas uniformes de "cosméticos"
                // 
                withBlock.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;

                // propiedades relacionadas con el formato del encabezado de columna / encabezado de columna
                // NB. para poder aplicar ForeColor y BackColor al encabezado, luego
                // La propiedad EnableHeadersVisualStyles debe establecerse en FALSE
                // 
                withBlock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                withBlock.ColumnHeadersHeight = 40;
                withBlock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                withBlock.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Tahoma", 11.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
                withBlock.EnableHeadersVisualStyles = false;
                withBlock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                withBlock.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
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

        private void tamanio()
        {
            try
            {
                var withBlock = datalistado;

                //withBlock.Columns["LOTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //withBlock.Columns["LOTE"].Width = 0;

                // establecer modo de ajuste
                // .Columns("NOMBRE_PRODUCTO").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                withBlock.Columns["T. JABA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T. JABA"].Width = 90;

                withBlock.Columns["T.PARIH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["T.PARIH"].Width = 130;

                withBlock.Columns["CANT JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("PESAJE").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["CANT JABAS"].Width = 100;


                withBlock.Columns["PESO BRUTO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("TURNO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO BRUTO"].Width = 70;


                withBlock.Columns["PESO JABAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO JABAS"].Width = 90;

                withBlock.Columns["PESO NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                withBlock.Columns["PESO NETO"].DefaultCellStyle.Format = "#.#0";
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PESO NETO"].Width = 90;

                withBlock.Columns["PROMEDIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // .Columns("USUARIO").DefaultCellStyle.Format = "#.#0"
                withBlock.Columns["PROMEDIO"].Width = 90;
            }
            catch (Exception)
            {
                //  throw;
            }

            {
            }
        }

        private void ocultar_columnas()
        {
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[8].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;
            datalistado.Columns[0].Visible = false;

            // datalistado.Columns(3).Visible = False
        }

        public void contar()
        {
            var contarfila = datalistado.RowCount - 1;
            var contador = 0;
            while (contarfila >= 0)
            {
                contador = contador + 1;
                contarfila = contarfila - 1;
            }

            LBLCONTAR.Text = Strings.FormatNumber(contador, 0);
        }

        public void sumaneto()
        {
            try
            {
                double total = 0;
                double cantjabas = 0;

                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    total += Convert.ToDouble(row.Cells["PESO NETO"].Value);
                    cantjabas += Convert.ToDouble(row.Cells["CANT JABAS"].Value);
                }

                totalneto.Text = Strings.FormatNumber(total, 2);
                lblcantjabas.Text = Strings.FormatNumber(cantjabas, 0);
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void txtnumlote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtnumlote.Text))
                    BtnBuscar.PerformClick();
                else
                    MessageBox.Show(@"Ingrese el Peso Correcto");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    ExportarExcel( nombreArchivo);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
         GenerarPDF2();
        // mostrarconsulta2();
        //  CrearPDF();
        }

        private void mostrarconsulta2()
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            try
            {

                datalistado.Rows.Clear();
                if (ConexionGral.conexion.State == ConnectionState.Closed) ConexionGral.conectar();

                comando = new MySqlCommand("usp_tblticketpesaje_RptBoletaPesado", ConexionGral.conexion);
                comando.CommandType = (CommandType)4;

                comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = txtnumlote.Text;

                String fechaaño = Settings.Default.periodo.ToString();
                String[] partes = fechaaño.Split(' ')[0].Split('/');
                String año = partes[2];
                comando.Parameters.AddWithValue("p_fechaanio", MySqlType.Int).Value = año;

                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    datalistado.DataSource = dataTable;
                    ocultar_columnas();
                    actualizardatos();
                }
                else
                {
                    datalistado.DataSource = null;
                }                                                                                                                                                                                                                               

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error " + ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar el reader
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                // Cerrar la conexión
                ConexionGral.desconectar();
            }
        }

        const string LogoPath = "logoagricola.png";

        private void GenerarPDF2()
        {

            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                    pagina.DefaultTextStyle(x => x.FontSize(12));

                    pagina.Header().Element(CrearCabecera);
                    pagina.Content().Padding(20).Element(CrearContenido);
                    pagina.Footer().Element(CrearFooter);
                });
            }).GeneratePdf("simple.pdf");
        }

       void CrearCabecera(IContainer container)
        {
            container.Column(col =>
            {
               //   col.Item().Image(LogoPath);
                

                col.Item().Row(row =>
                    {
                        row.RelativeItem().AlignLeft()
                            .Row(rowitem =>
                            {
                                rowitem.AutoItem().Width(200).Height(200).Image(LogoPath);
                            });

                        row.RelativeItem().Text("Boleta de Pesaje N° ");
                    }

                    );
               // col.Item().Text("Boleta de Pesaje N° ");
            });
        }


        void CrearContenido(IContainer container)
        {
            container.Column(col =>
            {
                col.Item().Text("Algun Texto");
                col.Item().Text("Algun Texto");
                col.Item().Text(string.Empty);
                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        
                    });
                    table.Header(header =>
                    {
                        header.Cell().BorderBottom(1).Text("Column 1").Bold();
                        header.Cell().BorderBottom(1).Text("Column 2").Bold();
                        header.Cell().BorderBottom(1).Text("Column 3").Bold();
                        header.Cell().BorderBottom(1).Text("Column 4").Bold();
                        header.Cell().BorderBottom(1).Text("Column 5").Bold();
                        header.Cell().BorderBottom(1).Text("Column 6").Bold();
                        header.Cell().BorderBottom(1).Text("Column 7").Bold();
                       
                    });
                    for (int i = 0; i < 8; i++)
                    {
                        table.Cell().Text($"Row {i}, Purto Floro Nomas");
                        table.Cell().Text($"Row {i}, Col 2");
                        table.Cell().Text($"Row {i}, Col 3");
                        table.Cell().Text($"Row {i}, Col 4");
                        table.Cell().Text($"Row {i}, Col 5");
                        table.Cell().Text($"Row {i}, Col 6");
                        table.Cell().Text($"Row {i}, Col 7");
                    }
                });
                col.Item().Text(string.Empty);
                col.Item().Text(string.Empty);
                col.Item().Text("Items");
                col.Item().Text("Cant Jabas");
                col.Item().Text("Total Neto");

            });
        }

        private void CrearFooter(IContainer container)
        {
            container.Background("#8fce00").Padding(5).Row(row =>
            {
                row.RelativeItem().Padding(0).Column(col =>
                {
                    col.Item()
                        .Hyperlink("https://agricoladelsurpisco.com/")
                        .Text("agricoladelsurpisco.com"); //.ApplyCommonTextStyle();
                });
                row.RelativeItem().AlignRight().Text(text =>
                {
                    text.CurrentPageNumber();//.ApplyCommonTextStyle();
                    text.Span(" / ");//.ApplyCommonTextStyle();
                    text.TotalPages(); //.ApplyCommonTextStyle();
                });
            });
        }

       
    }
}