using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    public class Version
    {
        public short Major { get; set; }
        public short Minor { get; set; }
        public short Maintenance { get; set; }
        public int Build { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
