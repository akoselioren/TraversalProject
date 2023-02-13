using Business.Abstract;
using ClosedXML.Excel;
using DataAccess.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalProject.Models;

namespace TraversalProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _excelService;

        public ReportController(IReportService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Turlistesi.xlsx");

            
        }

            public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }

        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Bu bir döküman örneğidir, bu bir döküman örneğidir PDF.");

            document.Add(paragraph);
            document.Close();

            return File("/Reports/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable=new PdfPTable(3);

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir Tc");


            pdfTable.AddCell("Aygül");
            pdfTable.AddCell("Yücedağ");
            pdfTable.AddCell("11111111111");

            pdfTable.AddCell("Şengül");
            pdfTable.AddCell("Yıldırım");
            pdfTable.AddCell("22222222222");

            pdfTable.AddCell("Birgül");
            pdfTable.AddCell("Yıldız");
            pdfTable.AddCell("33333333333");

            document.Add(pdfTable);
            document.Close();

            return File("/Reports/dosya2.pdf", "application/pdf", "dosya2.pdf");

        }


    }
}
