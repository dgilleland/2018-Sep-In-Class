using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class RegionalManager
    {
        public string City { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Region { get; internal set; }
        public string State { get; internal set; }
        public string Territory { get; internal set; }
        public string TerritoryZip { get; internal set; }
    }
}
