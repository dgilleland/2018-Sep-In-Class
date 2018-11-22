namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(35)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string Province { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
