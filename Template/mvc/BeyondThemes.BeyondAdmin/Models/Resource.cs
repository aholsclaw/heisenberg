using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public int ProjectID { get; set; }
        public int ResourceTypeID { get; set; }
        public decimal FTE { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public bool PostProject { get; set; }
    }
}