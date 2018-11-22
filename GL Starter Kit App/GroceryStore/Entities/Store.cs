namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            Orders = new HashSet<Order>();
            Pickers = new HashSet<Picker>();
        }

        public int StoreID { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picker> Pickers { get; set; }
    }
}
