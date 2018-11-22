namespace GroceryStore.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picker
    {
        public int PickerID { get; set; }

        [Required]
        [StringLength(35)]
        public string LastName { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        public bool Active { get; set; }

        public int StoreID { get; set; }

        public virtual Store Store { get; set; }
    }
}
