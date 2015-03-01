using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        public int ProjectID { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public int StatusColor { get; set; }
        public string StatusDescription { get; set; }


    }
}