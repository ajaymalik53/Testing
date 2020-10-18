using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PredictiveTool.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
           // DataMaster dataMaster = new DataMaster();
           // var sasa=dataMaster.GetMenuList();
            return View();
        }
    }
}