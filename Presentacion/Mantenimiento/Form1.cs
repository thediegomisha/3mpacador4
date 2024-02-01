//using EmployeeDataExample;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ZXing;

namespace QuestPDFTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;
        }

       // private async void button1_Click(object sender, EventArgs e)
       // {

       //     //var image = QRCodeGenerator.GenerateQRCodeBytes("https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---Csharp----Huong-dan-tao-ung-dung-dock-windows-giong-Taskbar/2f0a9a79ff1bafd4.html", 80, 80);
       //     //var ddd = (Bitmap)((new ImageConverter()).ConvertFrom(image));
       //     //pictureBox1.Image = (ddd);


       ////     var listEmployee = await new EmployeeData().GetEmployeesAsync();

       //     Document.Create(container =>
       //     {
       //         container.Page(page =>
       //         {
       //             page.Size(PageSizes.A4);
       //             page.Margin(4, Unit.Millimetre);
       //             page.PageColor(Colors.White);

       //             page.DefaultTextStyle(x => x.FontSize(9));
       //             page.DefaultTextStyle(x => x.FontFamily("Tahoma"));

       //             //page.Header()
       //             //    .Text("Hello PDF!")
       //             //    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

       //             page.Content()
       //               .PaddingVertical(1, Unit.Centimetre)
       //               .Column(x =>
       //               {
       //                   x.Item().Row(
       //                       row =>
       //                       {


       //                           row.RelativeItem().AlignLeft()

       //                             .Row(rowitem =>
       //                             {
       //                                 rowitem.AutoItem().Width(65).Height(65).Image(QRCodeGenerator.ReadImageFileToBytes("logo.png"));


       //                                 rowitem.AutoItem().Container().Width(4);
       //                                 rowitem.RelativeItem().Padding(2).Column(column =>
       //                                 {
       //                                     column.Item().Container().Height(2);
       //                                     column.Item().Row(row2 =>
       //                                     {
       //                                         row2.Spacing(8);
       //                                         row2.AutoItem().Text($"CÔNG TY PHÁT TRIỂN CÔNG NGHỆ TPHCM").FontSize(9).FontColor("#000");

       //                                     });
       //                                     column.Item().Row(row2 =>
       //                                     {
       //                                         row2.Spacing(8);
       //                                         row2.AutoItem().Text($"LẬP TRÌNH VB.NET").FontSize(9).FontColor("#000");

       //                                     });

       //                                     column.Item().Row(row2 =>
       //                                     {
       //                                         row2.Spacing(8);
       //                                         row2.RelativeItem().Hyperlink("https://laptrinhvb.net").Text("https://laptrinhvb.net").FontSize(9).FontColor("#0958d9");

       //                                     });

       //                                 });
       //                             });



       //                           row.RelativeItem().AlignRight().Width(250).Height(65)

       //                               .Row(rowitem =>
       //                               {
       //                                   rowitem.AutoItem().Width(65).Height(65).Image(QRCodeGenerator.GenerateQRCodeBytes("https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---Csharp----Huong-dan-tao-ung-dung-dock-windows-giong-Taskbar/2f0a9a79ff1bafd4.html", 170, 170));


       //                                   rowitem.AutoItem().Container().Width(4);
       //                                   rowitem.RelativeItem().Border(0.5f).Padding(2).Column(column =>
       //                                   {
       //                                       column.Item().Container().Height(2);
       //                                       column.Item().Row(row2 =>
       //                                       {
       //                                           row2.Spacing(12);
       //                                           row2.AutoItem().Text($"Mã tài liệu: LAPTRINHVB-03-BCT/02").FontSize(9).Italic();

       //                                       });
       //                                       column.Item().Row(row2 =>
       //                                       {
       //                                           row2.Spacing(12);
       //                                           row2.AutoItem().Text($"Ngày ban hành: 21/11/2023").FontSize(9).Italic();

       //                                       });
       //                                       column.Item().Row(row2 =>
       //                                       {
       //                                           row2.Spacing(12);
       //                                           row2.AutoItem().Text($"Ngày sửa đổi: 22/03/2023").FontSize(9).Italic();

       //                                       });
       //                                       column.Item().Row(row2 =>
       //                                       {
       //                                           row2.Spacing(5);
       //                                           row2.AutoItem().Text($"Sửa đổi lần: 01").FontSize(9).Italic();

       //                                       });

       //                                   });
       //                               });

       //                       }
       //                   );

       //                   // x.Item().LineHorizontal(1);
       //                   x.Spacing(10);
       //                   x.Item().AlignCenter().Text("DANH SÁCH NHÂN VIÊN")

       //                   .SemiBold().FontSize(16).FontColor(Colors.Orange.Medium);
       //                   x.Spacing(10);



       //                   // x.Item().Text(Placeholders.LoremIpsum());


       //                   x.Item().MinimalBox();
       //                   //  x.Item().Border(0.5F);
       //                   x.Item().Table(table =>
       //                   {
       //                       QuestPDF.Infrastructure.IContainer DefaultCellStyle(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
       //                       {
       //                           return containers
       //                                 .Border(0.5f)
       //                                 .BorderColor(Colors.Grey.Lighten1)
       //                                 .Background(backgroundColor)

       //                                 .PaddingVertical(5)
       //                                 .PaddingHorizontal(10)
       //                                 .AlignCenter()
       //                                 .AlignMiddle();
       //                       }

       //                       QuestPDF.Infrastructure.IContainer DefaultCellStyle2(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
       //                       {
       //                           return containers
       //                                 .Border(0.5f)
       //                                 .BorderColor(Colors.Grey.Lighten1)
       //                                 .Background(Colors.White)

       //                                 .PaddingVertical(5)
       //                                 .PaddingHorizontal(10);

       //                       }

       //                       QuestPDF.Infrastructure.IContainer DefaultCellStyleGroup(QuestPDF.Infrastructure.IContainer containers, string backgroundColor)
       //                       {
       //                           return containers
       //                                 .Border(0.5f)
       //                                   .BorderColor(Colors.Grey.Lighten1)
       //                                 .Background("#f0f0f0")

       //                                 .PaddingVertical(5)
       //                                 .PaddingHorizontal(10);

       //                       }

       //                       table.ColumnsDefinition(columns =>
       //                       {
       //                           columns.ConstantColumn(40);
       //                           columns.ConstantColumn(70);
       //                           columns.ConstantColumn(120);
       //                           columns.ConstantColumn(100);
       //                           columns.RelativeColumn();


       //                       });


       //                       table.Header(header =>
       //                       {

       //                           header.Cell().Element(CellStyle).Text("#").FontSize(10).FontColor(Colors.White).Bold();
       //                           header.Cell().Element(CellStyle).Text("Mã NV").FontSize(10).FontColor(Colors.White).Bold();
       //                           header.Cell().Element(CellStyle).Text("Tên nhân viên").FontSize(10).FontColor(Colors.White).Bold();
       //                           header.Cell().Element(CellStyle).Text("Nơi sinh").FontSize(10).FontColor(Colors.White).Bold();
       //                           header.Cell().Element(CellStyle).Text("Địa chỉ").FontSize(10).FontColor(Colors.White).Bold();

       //                           QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyle(containers, Colors.Blue.Medium);


       //                       });

       //                   //    var list50Item = listEmployee.Where(u => u.BirthPlace != "Trung Quốc").ToList().Take(50);

       //                       var groupedProducts = list50Item.GroupBy(p => p.BirthPlace);
       //                       int i = 1;
       //                       foreach (var group in groupedProducts)
       //                       {
       //                           table.Cell().ColumnSpan(5).Element(CellStyleGroup).Text(group.Key).FontSize(10).FontColor("#000000");


       //                           foreach (var item in group)
       //                           {
       //                               table.Cell().Element(CellStyle2).AlignCenter().Text(i.ToString() + ".").FontSize(10);
       //                               table.Cell().Element(CellStyle2).Text(item.Code).FontSize(10);
       //                               table.Cell().Element(CellStyle2).Text(item.Name).FontSize(10);
       //                               table.Cell().Element(CellStyle2).Text(item.BirthPlace).FontSize(10);
       //                               table.Cell().Element(CellStyle2).Text(item.Address).FontSize(10);
       //                               i++;
       //                           }
       //                       }


       //                       QuestPDF.Infrastructure.IContainer CellStyle2(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyle2(containers, Colors.Blue.Medium);
       //                       QuestPDF.Infrastructure.IContainer CellStyleGroup(QuestPDF.Infrastructure.IContainer containers) => DefaultCellStyleGroup(containers, Colors.Blue.Medium);

       //                       table.ExtendLastCellsToTableBottom();


       //                   });
       //               });






       //             page.Footer()
       //                 .AlignCenter()
       //                 .Text(x =>
       //                 {
       //                     x.Span("Page ");
       //                     x.CurrentPageNumber();
       //                 });
       //         });
       //     })
       //         .GeneratePdf("test.pdf");


       //     Process.Start("test.pdf");
       // }


    }


    public static class SimpleExtension
    {
        private static QuestPDF.Infrastructure.IContainer Cell(this QuestPDF.Infrastructure.IContainer container, bool dark)
        {
            return container
                .Border(1)
                .Background(dark ? Colors.Grey.Lighten2 : Colors.White)
                .Padding(10);
        }

        public static void LabelCell(this QuestPDF.Infrastructure.IContainer container, string text) => container.Cell(true).Text(text).Medium();
        public static QuestPDF.Infrastructure.IContainer ValueCell(this QuestPDF.Infrastructure.IContainer container) => container.Cell(false);

        public static QuestPDF.Infrastructure.IContainer Block(this QuestPDF.Infrastructure.IContainer container)
        {
            return container
                .Border(1)
                .Background(Colors.Grey.Lighten3)
                .ShowOnce()
                .MinWidth(50)
                .MinHeight(50)
                .AlignCenter()
                .AlignMiddle();
        }

    }

    //class QRCodeGenerator
    //{
    //    public static byte[] GenerateQRCodeBytes(string text, int width = 100, int height = 100, int margin = 0)
    //    {
    //        BarcodeWriter barcodeWriter = new BarcodeWriter();
    //        barcodeWriter.Format = BarcodeFormat.QR_CODE;
    //        barcodeWriter.Options = new ZXing.Common.EncodingOptions
    //        {
    //            Width = width,
    //            Height = height,
    //            Margin = margin
    //        };
    //        Bitmap qrCodeBitmap = barcodeWriter.Write(text);
    //        byte[] byteArray = BitmapToByteArray(qrCodeBitmap);
    //        return byteArray;
    //    }
    //    private static byte[] BitmapToByteArray(Bitmap bitmap)
    //    {
    //        using (var stream = new System.IO.MemoryStream())
    //        {
    //            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    //            return stream.ToArray();
    //        }
    //    }

    //    public static byte[] ReadImageFileToBytes(string filePath)
    //    {
    //        try
    //        {
    //            if (!File.Exists(filePath))
    //            {
    //                throw new FileNotFoundException($"File not found: {filePath}");
    //            }
    //            byte[] fileBytes = File.ReadAllBytes(filePath);
    //            return fileBytes;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Error reading image file: {ex.Message}");
    //            return null;
    //        }
    //    }
    //}
}
