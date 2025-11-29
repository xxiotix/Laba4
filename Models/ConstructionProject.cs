using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Models
{
    public abstract class ConstructionProject
    {
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Deadline { get; set; }

        // Віртуальні методи
        public abstract void ExecuteStage();
        public abstract decimal CalculateBudget();
        public abstract string ProjectType { get; }
    }
}
