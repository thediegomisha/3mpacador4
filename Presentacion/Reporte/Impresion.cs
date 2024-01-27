using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using HorizontalAlignment = System.Windows.Forms.HorizontalAlignment;


namespace _3mpacador4.Presentacion.Reporte
{
    
public partial class Impresion : Form
    {

        public Impresion()
        {
            InitializeComponent();
        }

        private void GenerarPDF()
        {
            // Configurar la licencia de QuestPDF
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            // Crear el documento PDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));
                    page.Header()
                        .Text("Hello PDF!");
                    page.Content()
                        .Text("This is a sample PDF created using QuestPDF.");
                });
            });

            // Guardar el documento como un archivo temporal y mostrarlo en el navegador
            string tempFilePath = System.IO.Path.GetTempFileName() + ".pdf";
           // document.Save(tempFilePath);

            // Mostrar el documento PDF
            System.Diagnostics.Process.Start(tempFilePath);
        }
    }





}

