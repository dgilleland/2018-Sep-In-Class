using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindTraders.Entities
{
    [Table("Categories")]
    public class Category
    {
        #region Column Mappings

        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string PictureMimeType { get; set; }

        #endregion Column Mappings

        #region Navigation Properties

        public virtual ICollection<Product> Products { get; set; }

        #endregion Navigation Properties

        #region Constructor

        public Category()
        {
            Products = new HashSet<Product>();
        }

        #endregion Constructor
    }
}