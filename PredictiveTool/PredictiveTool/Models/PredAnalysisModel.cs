using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictiveTool.Models
{
    public class PredAnalysisModel
    {
        public string ID { get; set; }
        public string SectorID { get; set; }
        public string TabID { get; set; }
        public string Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
    public class ddnmodel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
