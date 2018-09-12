using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Entities
{
    [Table("Customers")]
    public class Customer
    {
        #region Column Mappings

        [Key]
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Demographics { get; set; }
        public DateTime LastModified { get; set; }

        #endregion Column Mappings

        #region Navigation Properties

        public virtual ICollection<Order> Orders { get; set; }
            = new HashSet<Order>();

        #endregion Navigation Properties
    }
}