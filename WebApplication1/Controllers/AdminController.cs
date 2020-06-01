using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;

namespace DOAN.Controllers
{
    public class AdminController : Controller
    {
        //WEBContext db = new WEBContext();
        private WEBContext Context;

        [ActivatorUtilitiesConstructor]
        public AdminController(WEBContext _context)
        {
            this.Context = _context;
        }
        public IActionResult MasterAD()
        {
            return View();
        }
        public IActionResult TrangChuAD()
        {
            return View();
        }
      

        public IActionResult ReportAD()
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
             FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            // fileStreamResult.FileDownloadName = "Sample.pdf";

             return fileStreamResult;
            //return View();


        }
    }
}