using System;
using System.Data;
using System.Windows.Forms;
using _3mpacador4.Logica;
using _3mpacador4.Properties;
using Devart.Data.MySql;
using Microsoft.VisualBasic;

namespace _3mpacador4.Presentacion.Mantenimiento
{
    public partial class frmCampania : Form
    {
        public frmCampania()
        {
            InitializeComponent();
          cargarinicial();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
           }
        private void cargarinicial()
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    if (bloque.periodo != null)
                    {
                       dateTimePicker1.Text = bloque.periodo.ToString();
                    }
                    else
                    {
                        dateTimePicker1.Text = DateTime.Now.Year.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }

        private void guardar()
        {
            try
            {
                {
                    var bloque = Settings.Default;

                    if (dateTimePicker1.Value != null)
                    {
                        bloque.periodo = dateTimePicker1.Value.ToString(); ;
                    }

                    bloque.Save();
                    MessageBox.Show(@"Datos Guardados Satisfactoriamente !!!");
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, Constants.vbCritical);
            }
        }


    }
}