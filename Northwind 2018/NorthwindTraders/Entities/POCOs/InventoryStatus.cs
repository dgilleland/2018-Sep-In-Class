using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.POCOs
{
    public class InventoryStatus
    {
        public string Category { get; internal set; }
        public short? InStockQuantity { get; internal set; }
        public short? OnOrderQuantity { get; internal set; }
        public string Product { get; internal set; }
        public string QuantityPerUnit { get; internal set; }
        public short? ReorderLevel { get; internal set; }
        public string Supplier { get; internal set; }
        public decimal? UnitPrice { get; internal set; }
    }
}
