using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3mpacador4.Logica
{
    public static class FormUtils
    {
        public static void CambiarTextoLabel(Label label, string nuevoTexto)
        {
            label.Text = nuevoTexto;
        }
    }
}
