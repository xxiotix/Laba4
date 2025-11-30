using Laba4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Models
{
    public abstract class ConstructionProject : IAuditable
    {
        public string Name { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Deadline { get; set; }

        private List<string> _auditRecords = new List<string>();
        public void AddAuditRecord(string record)
        {
            _auditRecords.Add($"{DateTime.Now}: {record}");
        }
        public IEnumerable<string> GetAuditRecords()
        {
            return _auditRecords;
        }

        // Віртуальні методи
        public abstract void ExecuteStage();
        public abstract decimal CalculateBudget();
        public abstract string ProjectType { get; }
    }
}
