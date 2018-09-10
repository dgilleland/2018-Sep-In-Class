using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    [Table("Territories")]
    public class Territory
    {
        #region Column Mappings
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // TerritoryID is not an IDENTITY
        public string TerritoryID { get; set; }
        [Required, StringLength(50)]
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
        #endregion

        #region Navigation Properties
        // DEMO: Many-to-Many Relationships
        public virtual ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();
        public virtual Region Region { get; set; }
        #endregion
    }
}
