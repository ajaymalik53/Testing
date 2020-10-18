using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using PredictiveTool.BALayer;
using PredictiveTool.DALayer;
using PredictiveTool.Models;

namespace PredictiveTool.Controllers
{
    public class DashBoardPredectiveController : Controller
    {
        PredAnalysisModel predAnalysisModel;
        DataManager dataManager;

        private readonly IHostingEnvironment _hostingEnvironment;
        public DashBoardPredectiveController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult test1()
        {
            predAnalysisModel = new PredAnalysisModel();
            
            List<ddnmodel> ddn = CommonUtility.GetDDList(predAnalysisModel);
            ViewBag.UserName = CommonUtility.GetSelectListItemsstr(ddn);
          return View();
        }
        public IActionResult Index()
        {
           
            predAnalysisModel = new PredAnalysisModel();
            predAnalysisModel.TabID = "3";
            List<ddnmodel> ddn = CommonUtility.GetDDList(predAnalysisModel);
            ViewBag.UserName = CommonUtility.GetSelectListItemsstr(ddn);
            //TempData["ddlstUserMST"] = ViewBag.UserName;
            return View(predAnalysisModel);
        }
        [HttpGet]
        public ActionResult getChartandTableData(string SecID="",string TabID="",string type="",string from="",string To="")
        {
            dataManager = new DataManager();
            predAnalysisModel = new PredAnalysisModel();
            predAnalysisModel.SectorID = SecID;
            predAnalysisModel.TabID = TabID;
            predAnalysisModel.Type = type;
            predAnalysisModel.From = from;
            predAnalysisModel.To = To;
           var TesultDataSet = dataManager.GetData(predAnalysisModel);
            return new JsonResult(TesultDataSet);
        }

        //[HttpGet]
        //public ActionResult getMAPData(string SecID = "", string TabID = "", string type = "", string from = "", string To = "")
        //{
        //    dataManager = new DataManager();
        //    predAnalysisModel = new PredAnalysisModel();
        //    predAnalysisModel.SectorID = SecID;
        //    predAnalysisModel.TabID = TabID;
        //    predAnalysisModel.Type = "MAPData";
        //    predAnalysisModel.From = from;
        //    predAnalysisModel.To = To;
        //    var TesultDataSet = dataManager.GetData(predAnalysisModel);
        //    return new JsonResult(TesultDataSet);
        //}

        public JsonResult GetData()
        {
            //Dictionary<string, decimal> weeklyExpense = getFileDate();
            List<TableKilmOutPut> lsttableKilmOutPut = new List<TableKilmOutPut>();
            lsttableKilmOutPut = Import();
            return new JsonResult(lsttableKilmOutPut);
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
        public  ActionResult BindDropDown(string option, string option1 = "", string option2 = "")
        {
            string Result = string.Empty;
            //masterManager = new MasterManager();
            PredAnalysisModel predAnalysisModel = new PredAnalysisModel();

            List<ddnmodel> ddn = CommonUtility.GetDDList(predAnalysisModel);
            // Result = CommonUtility.ListToString(ds);
            return  Ok(ddn);
        }
    }
}