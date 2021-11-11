﻿using System;
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
using PdfSharp;
using Rotativa;
using hotel_santa_ursula_II.Data;

namespace hotel_santa_ursula_II.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult PDf()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("Hello", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            MemoryStream stream = new MemoryStream(); //// 
            document.Save(stream, false); //// 
            Byte[] documentBytes = stream.ToArray(); //// 
            return File(documentBytes, "application/pdf");

            // // Save the document...
            // string filename = "HelloWorld.pdf";
            // document.Save(filename);
            // // ...and start a viewer.
            // Process.Start(filename);
            // return View(filename);
        }



    }
}
