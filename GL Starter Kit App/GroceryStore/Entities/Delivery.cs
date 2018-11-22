namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Delivery
    {
        public int DeliveryID { get; set; }

        public int OrderID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        public DateTime ShippedDate { get; set; }
    }
}
