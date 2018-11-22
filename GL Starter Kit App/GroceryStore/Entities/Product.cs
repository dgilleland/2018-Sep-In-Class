namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderLists = new HashSet<OrderList>();
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal Discount { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitSize { get; set; }

        public int CategoryID { get; set; }

        public bool Taxable { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
