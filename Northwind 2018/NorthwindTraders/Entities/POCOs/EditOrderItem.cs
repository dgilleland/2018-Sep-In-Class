using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class EditOrderItem
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short OrderQuantity { get; set; }
        public float DiscountPercent { get; set; }
    }
}
