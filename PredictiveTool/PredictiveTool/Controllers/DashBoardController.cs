using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using PredictiveTool.Models;

namespace PredictiveTool.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DashBoardController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            Import();
            return View();
        }
        public JsonResult GetData()
        {
            //Dictionary<string, decimal> weeklyExpense = getFileDate();
            List<TableKilmOutPut> lsttableKilmOutPut = new List<TableKilmOutPut>();
            lsttableKilmOutPut = Import();
            return new JsonResult(lsttableKilmOutPut);
        }
        public Dictionary<string, decimal> getFileDate()
        {
            Dictionary<string, decimal> obj = new Dictionary<string, decimal>();
           
            return  obj;
        }
        public List<TableKilmOutPut> Import()
        {
            List<TableKilmOutPut> lsttableKilmOutPut = new List<TableKilmOutPut>();
            TableKilmOutPut tableKilmOutPut = new TableKilmOutPut();
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"demo.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    StringBuilder sb = new StringBuilder();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    //bool bHeaderRow = true;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        tableKilmOutPut = new TableKilmOutPut();
                        tableKilmOutPut.Year = (double)worksheet.Cells[row, 1].Value;
                        tableKilmOutPut.MQ = (double)worksheet.Cells[row, 2].Value;
                        tableKilmOutPut.MQF = (double)worksheet.Cells[row, 3].Value;
                        tableKilmOutPut.TSC = (double)worksheet.Cells[row, 4].Value;
                        tableKilmOutPut.TSCF = (double)worksheet.Cells[row, 5].Value;
                        lsttableKilmOutPut.Add(tableKilmOutPut);
                     }
                    return lsttableKilmOutPut;
                }
            }
            catch (Exception ex)
            {
                return lsttableKilmOutPut;
            }
        }
    }
}