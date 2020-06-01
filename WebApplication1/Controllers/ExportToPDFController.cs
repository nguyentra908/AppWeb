 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;

using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace DOAN.Controllers
{
    public class ExportToPDFController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ExportToPDFController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }



        public IActionResult ExportToPDF()
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert("https://help.syncfusion.com/file-formats/pdf/convert-html-to-pdf/blink");
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);

            stream.Position = 0;        

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

 

            return fileStreamResult;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}