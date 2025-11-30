using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Interfaces
{
    public interface IAuditable
    {
        void AddAuditRecord(string record);
        IEnumerable<string> GetAuditRecords();
    }
}
