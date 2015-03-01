using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class ProjectPhase
    {
        public int ProjectPhaseID { get; set; }
        public int ProjectID { get; set; }
        public int PhaseTypeID { get; set; }
        public DateTime ForecastCompletion { get; set; }
        public DateTime ActualCompletion {get; set;}

        public virtual Project Project { get; set; }
        public virtual PhaseType PhaseType { get; set; }
    }
}