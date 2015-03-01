using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Cost
    {
        public int CostID { get; set; }
        public int ProjectID { get; set; }
        public int CostTypeID { get; set; }
        public decimal Amount { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public bool PostProject {get; set;}
    }
}