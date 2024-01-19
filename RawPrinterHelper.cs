using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace _3mpacador4
{
    public static class RawPrinterHelper
    {
        // Declaraciones de funciones API para enviar datos a la impresora
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, StringBuilder pBytes, int dwCount, out int dwWritten);

        // Estructura DOCINFO para comenzar un nuevo documento
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        // Método para enviar una cadena a la impresora
        public static bool SendStringToPrinter(string printerName, string data)
        {
            IntPtr hPrinter;
            DOCINFOA di = new DOCINFOA();
            int dwCount;
            int dwWritten;

            di.pDocName = "PrintJob";
            di.pDataType = "RAW";

            // Abre la impresora
            if (!OpenPrinter(printerName.Normalize(), out hPrinter, IntPtr.Zero))
                return false;

            // Inicia un nuevo documento
            if (!StartDocPrinter(hPrinter, 1, di))
            {
                ClosePrinter(hPrinter);
                return false;
            }

            // Inicia una nueva página
            if (!StartPagePrinter(hPrinter))
            {
                EndDocPrinter(hPrinter);
                ClosePrinter(hPrinter);
                return false;
            }

            // Escribe los datos a la impresora
            dwCount = data.Length;
            StringBuilder pBytes = new StringBuilder(data, dwCount);
            if (!WritePrinter(hPrinter, pBytes, dwCount, out dwWritten))
            {
                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
                ClosePrinter(hPrinter);
                return false;
            }

            // Finaliza la página y el documento
            EndPagePrinter(hPrinter);
            EndDocPrinter(hPrinter);
            ClosePrinter(hPrinter);

            // Verifica si se escribieron todos los datos
            return dwWritten == dwCount;
        }
    }
}
