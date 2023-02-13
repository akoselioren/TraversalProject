using Business.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells["A1"].LoadFromCollection(t,true,OfficeOpenXml.Table.TableStyles.Light10);
            return excel.GetAsByteArray();
        }
    }
}
