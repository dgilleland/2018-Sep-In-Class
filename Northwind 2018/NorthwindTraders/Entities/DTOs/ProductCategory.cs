using NorthwindTraders.Entities.POCOs;
using System.Collections.Generic;

namespace NorthwindTraders.Entities.DTOs
{
    public class ProductCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public IEnumerable<ProductInfo> Products { get; set; }
    }
}
