using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictiveTool.Models
{
    public class TableKilmOutPut
    {
        //Year MQ  MQF TSC TSCF
        public double Year { get; set; }
        public double MQ { get; set; }
        public double MQF { get; set; }
        public double TSC { get; set; }
        public double TSCF { get; set; }
    }
    public class OutPutChart
    {
        //Year MQ  MQF TSC TSCF
        public double Year { get; set; }
        public double Col1 { get; set; }
        public double Col2 { get; set; }
        public double Col3 { get; set; }
        public double Col4 { get; set; }
    }
  }
