using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Entities.POCOsDTOs
{
    public class PickListItem
    {
        public int OrderItemId { get; set; }
        public double QuantityPicked { get; set; }
        public string PickIssue { get; set; }
    }
}
