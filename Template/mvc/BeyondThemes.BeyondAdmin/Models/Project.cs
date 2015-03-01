using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

     public virtual ICollection<ProjectPerson>ProjectPeople {get; set;}
     public virtual ICollection<Cost> Costs { get; set; }
     public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
     public virtual ICollection<ProjectPhase> ProjectPhases { get; set; }
     public virtual ICollection<Resource> Resources { get; set; }
     public virtual ICollection<Status> Statuses { get; set; }
    }
}