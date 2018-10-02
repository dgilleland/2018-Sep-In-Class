namespace NorthwindTraders.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }

        [Required(ErrorMessage = "CategoryName is required")]
        [StringLength(15, ErrorMessage = "A category name cannot be longer than 15 characters")]
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        [StringLength(40, ErrorMessage = "The PictureMimeType cannot be longer than 40 characters")]
        public string PictureMimeType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
