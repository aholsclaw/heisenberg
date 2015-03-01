using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class GoLive
    {
        public int GoLiveID { get; set; }
        public int GoLiveTypeID { get; set; }
        public int ProjectID { get; set; }
        public int OriginalForecast { get; set; }
        public int RevisedForecast { get; set; }
        public int Actual { get; set; }

        public virtual GoLiveType GoLiveType { get; set; }
        public virtual Project Project { get; set; }
    }
}