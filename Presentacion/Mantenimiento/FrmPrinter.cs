using _3mpacador4.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class FrmPrinter : Form
    {
        public FrmPrinter()
        {
            InitializeComponent();
        }

        private void FrmPrinter_Load(object sender, EventArgs e)
        {
          
                PrintDocument pd = new PrintDocument();
                string Impresoras;

                // Default printer
                string s_Default_Printer = pd.PrinterSettings.PrinterName;

                // Recorre las impresoras instaladas
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    List_Printer.Items.Add(printer);
                }

                // Selecciona la impresora predeterminada
                List_Printer.Text = s_Default_Printer;

            //  lblprinter_choose.Text = Settings.Default.Impresora_valor;
            lblprinter_choose.Text = Settings.Default.Impresora_valor;

        }
    }
}
