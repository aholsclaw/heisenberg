﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class PhaseType
    {
        public int PhaseTypeID { get; set; }
        public string PhaseTypeName { get; set; }

        public virtual ProjectPhase ProjectPhase { get; set; }
        public virtual Budget Budget { get; set; }
    }
}