using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        #region Column Mappings
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        #endregion

        #region Navigational Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
