using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class GoLiveType
    {
        public int GoLiveTypeID { get; set; }
        public string GoLiveName { get; set; }


        public virtual GoLive GoLive { get; set; }
    }
}