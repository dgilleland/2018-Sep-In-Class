using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Entities.POCOsDTOs
{
    /// <summary>
    /// Query POCO for reading info from the database
    /// </summary>
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string Comment { get; set; }
    }
}
