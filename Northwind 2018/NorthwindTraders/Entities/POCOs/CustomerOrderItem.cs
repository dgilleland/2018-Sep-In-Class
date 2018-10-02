using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class CustomerOrderItem : ProductItem
    {
        public int OrderId { get; set; }
        public short Quantity { get; set; }
        public float DiscountPercent { get; set; }
    }
}
