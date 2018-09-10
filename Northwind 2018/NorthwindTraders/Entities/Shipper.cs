using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    [Table("Shippers")]
    public class Shipper
    {
        #region Column Mappings
        // TODO: Add validation annotations for CompanyName and Phone
        [Key]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        #endregion

        #region Navigational Properties
        public virtual ICollection<Order> Orders { get; set; }
            = new HashSet<Order>();
        #endregion
    }
}
