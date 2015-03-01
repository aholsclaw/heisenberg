using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class ProjectTask
    {
        public int ProjectTaskID { get; set; }
        public int ProjectTaskTypeID { get; set; }
        public int ProjectID { get; set; }
        public int OriginalForecast { get; set; }
        public int RevisedForecast { get; set; }
        public int Actual { get; set; }

        public virtual ProjectTaskType ProjectTaskType { get; set; }
        public virtual Project Project { get; set; }
    }
}