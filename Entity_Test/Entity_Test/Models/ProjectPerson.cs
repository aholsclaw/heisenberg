using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Test.Models
{
    public class ProjectPerson
    {
        public int ProjectPersonId { get; set; }
        public int ProjectID { get; set; }
        public int PersonID { get; set; }
        public int RoleID { get; set; }

    }
}