using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindTraders.Entities.POCOs
{
    public class ProductItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short? InStockQuantity { get; set; }
    }
}
