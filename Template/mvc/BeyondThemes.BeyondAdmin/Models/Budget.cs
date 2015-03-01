using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyondThemes.BeyondAdmin.Models
{
    public class Budget
    {
        public int BudgetID { get; set; }
        public int PhaseTypeID { get; set; }
        public decimal ForecastCapital { get; set; }
        public decimal ForecastExpense { get; set; }
        public decimal ActualCapital { get; set; }
        public decimal ActualExpense { get; set; }

        public virtual PhaseType PhaseType { get; set; }
    }
}