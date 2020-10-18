using PredictiveTool.Controllers;
using PredictiveTool.DALayer;
using PredictiveTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictiveTool.BALayer
{
    public class PredectiveBusinessModel
    {
        DataManager dataMaster;
        ddnmodel ddnmodel;
        PredAnalysisModel predAnalysisModel;
        public void GetSectorList(PredAnalysisModel predAnalysisModel)
        {
            dataMaster = new DataManager();

            var asasa = dataMaster.GetData(predAnalysisModel);

            // SqlParamAdd("@Host", DbType.String, uploadModel.HostName);
            
        }
        public void GetChartData(PredAnalysisModel predAnalysisModel)
        {
            dataMaster = new DataManager();

            var asasa = dataMaster.GetData(predAnalysisModel);

            // SqlParamAdd("@Host", DbType.String, uploadModel.HostName);

        }
    }
}
