using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.DTOs
{
    public class CustomerOrderWithDetails : CustomerOrder
    {
        public IEnumerable<CustomerOrderItem> Details { get; set; }
            = new List<CustomerOrderItem>();
    }
}
