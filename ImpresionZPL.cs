using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace _3mpacador4
{
    public class ImpresionZPL
    {

        public const int GENERIC_WRITE = 0x40000000;
        public const int OPEN_EXISTING = 3;
        public const int FILE_SHARE_WRITE = 0x2;

        private string LPTPORT;
        private string PuertoImpresion = "LPT2";

        //internal Global.System.Windows.Forms.Button btnImpresion;
        //internal Global.System.Windows.Forms.Button btnSalir;
        private int hPort;

        [DllImport("kernel32", EntryPoint = "CreateFileA")]
        public static extern int CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);


        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        public static extern int CloseHandle(int hObject);
        private int retval;

        public partial struct SECURITY_ATTRIBUTES
        {
            private int nLength;
            private int lpSecurityDescriptor;
            private int bInheritHandle;
        }

        public void Impresion(string Evento, string Nombre, string Apellidos, string Empresa, string Codigo, string Fecha)
        {
            var SA = default(SECURITY_ATTRIBUTES);
            // outFile es el archivo stream que contien la etiqueta y su formato
            FileStream outFile;
            IntPtr hPortP;
            // Imprime por LPT1 en local.
            // Para la impresión por red vía net use.
            // Se ha de crear un bat con: --> net use LPT2 /del 

            // --> net use LPT2 \\NombrePC\NombreImpresoraCompartida y colocarlo en
            // ....\All Users\Menú Inicio\Programas\Inicio 
            // para que cada usr. que inicie tenga 
            LPTPORT = PuertoImpresion;
            hPort = ImpresionZPL.CreateFile(/*ref*/ LPTPORT, GENERIC_WRITE, FILE_SHARE_WRITE, ref SA, OPEN_EXISTING, 0, 0);
            // Convertir Integer a IntPtr 
            hPortP = new IntPtr(hPort);
            // Crear FileStream usando Handle 
            outFile = new FileStream(hPortP, FileAccess.Write, false);

            var fileWriter = new StreamWriter(outFile);

            // Sustitución de caracteres. El alfabeto que maneja esta impresora en concreto

            // es solo inglés por eso se sustituyen las tildes, eñes, etc.

            // Esta operación se debe realizar con todos los campos susceptibles a contener 

            // carácteres no aceptados 
            Apellidos = Apellidos.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U").Replace("ñ", "n").Replace("Ñ", "N").Replace("ç", "c").Replace("Ç", "C").Replace("ª", ".");

            // Poner a mayusculas la primera letra
            /*Empresa = Empresa.ToLower();
            Empresa = Application.CurrentCulture.TextInfo.ToTitleCase(Empresa);
            Nombre = Nombre.ToLower();
            Nombre = Application.CurrentCulture.TextInfo.ToTitleCase(Nombre);
            Apellidos = Apellidos.ToLower();
            Apellidos = Application.CurrentCulture.TextInfo.ToTitleCase(Apellidos);*/

            // --------------------------INICIO ETIQUETA---------------------------' 
            fileWriter.Write("^XA");
            // Deshabilita el panel de la impresora, para que el usr no pueda acceder
            fileWriter.Write("^MPS");
            // Posicion del eje de cordenadas, en dots
            fileWriter.Write("^LH0,0");
            // FO para el inicio de escritura, eje X,Y
            // AU el formato de la fuente
            // FB establece un espacio de 900 dots y la C para centrar el texto
            fileWriter.Write("^FO1,30^AU^FB900,1,0,C^FD" + Evento + "^FS");

            // AD el formato de la fuente y el 20 para el tamaño de la fuente
            fileWriter.Write("^FO50,90^AD,,20^FD" + Apellidos + "^FS");

            fileWriter.Write("^FO50,130^AD,,20^FD" + Nombre + "^FS");

            fileWriter.Write("^FO520,130^AD,,10^FD" + "Historia Cl. " + Empresa + "^FS");

            // GB escribe una linea horizontal 900 largo, 0 grosor y 2 ancho
            fileWriter.Write("^FO50,165^FR^GB900,0,2^FS");

            fileWriter.Write("^FO520,180^AD^FD" + Fecha + "^FS");

            // B3 escribe el texto en cod. de barras tipo B3 (alfanumerico)

            // el 60 para el tamaño
            fileWriter.Write("^FO200,200^B3,,60^FD" + Codigo + " ^FS");
            // --------------------------PIE DE ETIQUETA---------------------------'
            fileWriter.Write("^FO100,290^AD^FD" + "SUJA Corporation" + "^FS");
            // Finaliza la etiqueta
            fileWriter.Write("^XZ");
            fileWriter.Flush();
            fileWriter.Close();
            outFile.Close();
            retval = CloseHandle(hPort);
        }
    }
}
