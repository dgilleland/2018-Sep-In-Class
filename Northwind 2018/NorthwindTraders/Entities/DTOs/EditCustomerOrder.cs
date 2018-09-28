using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities.DTOs
{
    public class EditCustomerOrder
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int? ShipperId { get; set; }
        public decimal? FreightCharge { get; set; }
        public IEnumerable<EditOrderItem> OrderItems { get; set; }
    }
}
