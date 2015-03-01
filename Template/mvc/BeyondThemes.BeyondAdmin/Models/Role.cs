using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Role
    {
        public int RoleID {get; set;}
        public string RoleName { get; set; }

        
        public virtual ProjectPerson ProjectPerson { get; set; }
    }

}