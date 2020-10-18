using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PredictiveTool.BALayer;
using PredictiveTool.DALayer;
using PredictiveTool.Models;

namespace PredictiveTool.Controllers
{
    public class DashBoardCPIController : Controller
    {
        PredAnalysisModel predAnalysisModel;
        DataManager dataManager;
        public IActionResult Index()
        {
            predAnalysisModel = new PredAnalysisModel();
            predAnalysisModel.TabID = "4";
            List<ddnmodel> ddn = CommonUtility.GetDDList(predAnalysisModel);
            ViewBag.UserName = CommonUtility.GetSelectListItemsstr(ddn);
            //TempData["ddlstUserMST"] = ViewBag.UserName;
            return View(predAnalysisModel);
           
        }
    }
}