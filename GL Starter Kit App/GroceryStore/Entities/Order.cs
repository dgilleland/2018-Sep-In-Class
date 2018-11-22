namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderLists = new HashSet<OrderList>();
        }

        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public int StoreID { get; set; }

        public int CustomerID { get; set; }

        public int? PickerID { get; set; }

        public DateTime? PickedDate { get; set; }

        public bool Delivery { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal GST { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderLists { get; set; }

        public virtual Store Store { get; set; }
    }
}
