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

namespace _3mpacador4.Presentacion.Reporte
{
    public partial class ImprimirPesos : Form
    {
        public ImprimirPesos()
        {
            InitializeComponent();
            //  PrepGrid();
            ticket();
         
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ticket()
        {
          
          
            // Instanciamos el Formulario PADRE

                IngresoPesos IngresoPesos = Owner as IngresoPesos;

          //  lblproductor2.Text = (IngresoPesos.cbProductor.Text);
            //IngresoPesos.cbcliente.Text = 
            //IngresoPesos.cbProductor.Text = 
            //IngresoPesos.lblCLP.Text = 

              
                // mostrarconsulta2();
            }

        private void ImprimirPesos_Load(object sender, EventArgs e)
        {

        }
    }



        //private void poblarLote()
        //{
        //    MySqlCommand comando;
        //    try
        //    {
        //        if (ConexionGral.conexion.State == ConnectionState.Closed)
        //        {
        //            ConexionGral.conectar();
        //        }

        //        comando = new MySqlCommand("usp_tblticketpesaje_Select_Trazability", ConexionGral.conexion);
        //        comando.CommandType = (CommandType)4;

        //        comando.Parameters.AddWithValue("p_numlote", MySqlType.Int).Value = (cboLote.Text.ToString()); ;

        //        var adaptador = new MySqlDataAdapter(comando);
        //        var datos = new DataTable();
        //        adaptador.Fill(datos);

        //        {
        //            var withBlock = this.cboLote;
        //            if (datos.Rows.Count != 0)
        //            {
        //                CodCliente.Text = datos.Rows[0]["CODTRA"].ToString();
        //                CodPalta.Text = datos.Rows[0]["CODTRA2"].ToString();
        //                codPacking.Text = "01";
        //                CodProductor.Text = datos.Rows[0]["CODTRA3"].ToString();

        //                lblcliente.Text = datos.Rows[0]["RAZON SOCIAL"].ToString();
        //                lblcliente2.Text = datos.Rows[0]["RAZON SOCIAL"].ToString();

        //                lblproductor.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //                lblproductor2.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //                //  lblmetodo.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //                lblproducto.Text = datos.Rows[0]["PRODUCTO"].ToString();
        //              //  lblservicio.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //              //  lblacopiador.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //               // lblguiaingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //              //  lblruc_dni.Text = datos.Rows[0]["PRODUCTOR"].ToString();
        //                lblclp.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();
        //                lblclp2.Text = datos.Rows[0]["CODIGO PRODUCCION"].ToString();

        //                lblvariedad .Text = datos.Rows[0]["VARIEDAD"].ToString();
        //                lblfechaingreso.Text = datos.Rows[0]["FECHA PESAJE"].ToString();
        //                //    lblhoraingreso.Text = datos.Rows[0]["PRODUCTOR"].ToString();

        //                lblpesoneto.Text = (datos.Rows[0]["PESO NETO"].ToString());
        //                lblcantjabas.Text = (datos.Rows[0]["CANT JABAS"].ToString());




        //            }
        //            else
        //            {
        //                withBlock.DataSource = null;
        //            }
        //        }
        //        ConexionGral.desconectar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



    }

    

