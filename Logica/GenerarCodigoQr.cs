using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace _3mpacador4.Logica
{
    class GenerarCodigoQr
    {
        public static byte[] GenerarQRCodeBytes(string text, int width = 100, int height = 100, int margin = 0)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = margin
            };
            Bitmap qrCodeBitmap = barcodeWriter.Write(text);
            byte[] byteArray = BitmapToByteArray(qrCodeBitmap);
            return byteArray;
        }
        private static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static byte[] ReadImageFileToBytes(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }
                byte[] fileBytes = File.ReadAllBytes(filePath);
                return fileBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }
    }
}
