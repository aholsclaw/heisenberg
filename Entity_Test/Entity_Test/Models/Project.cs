using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Test.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public int PhaseID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}