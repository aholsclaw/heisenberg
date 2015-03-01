using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class ProjectTaskType
    {
        public int ProjectTaskTypeID { get; set; }
        public string ProjectTaskTypeName { get; set; }

        public virtual ProjectTask ProjectTask { get; set; }
    }
}