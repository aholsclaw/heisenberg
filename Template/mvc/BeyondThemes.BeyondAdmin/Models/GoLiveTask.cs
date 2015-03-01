using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class GoLiveTask
    {
        public int GoLiveTaskID { get; set; }
        public int TaskTypeID { get; set; }
        public int ProjectID { get; set; }
        public int OriginalForecast { get; set; }
        public int RevisedForecast { get; set; }
        public int Actual { get; set; }
    }
}