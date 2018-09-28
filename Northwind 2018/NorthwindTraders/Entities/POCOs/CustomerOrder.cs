using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class CustomerOrder
    {
        public int OrderId { get; set; }
        public string Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Shipper { get; set; }
        public decimal? Freight { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
