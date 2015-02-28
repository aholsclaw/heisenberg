using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Test.Models
{
    public class GoLiveTask
    {
        public int TaskID { get; set; }
        public int TaskTypeID { get; set; }
        public int ProjectID { get; set; }
        public int OriginalForecast { get; set; }
        public int RevisedForecast { get; set; }
        public int Actual { get; set; }
    }
}