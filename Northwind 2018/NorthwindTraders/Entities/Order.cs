using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    [Table("Orders")]
    public class Order
    {
        #region Column Mappings
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        #endregion

        #region Navigational Properties
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new HashSet<OrderDetail>();

        [ForeignKey("ShipVia")] // Tell EF which property to use as Foreign Key data
        public virtual Shipper Shipper { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        #endregion
    }
}
