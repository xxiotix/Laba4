using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4.Interfaces
{
    public interface IHasLocation
    {
        string Location { get; set; }
        string GetLocationInfo();
    }
}
