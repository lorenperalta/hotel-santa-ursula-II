using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using hotel_santa_ursula_II.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace hotel_santa_ursula_II.Controllers
{
    public class PdfController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PdfController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            // string filename = "HelloWorld.pdf";
            // document.Save("C:\\");
            // Process.Start(filename);
            // byte[] document;

            MemoryStream stream = new MemoryStream(); //// 
            document.Save(stream, false); //// 
            Byte[] documentBytes = stream.ToArray(); //// 
            return File(documentBytes, "application/pdf");
        }


    }
}
