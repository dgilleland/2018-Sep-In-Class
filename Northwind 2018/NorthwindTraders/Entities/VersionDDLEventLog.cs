namespace NorthwindTraders.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VersionDDLEventLog")]
    public partial class VersionDDLEventLog
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        public DateTime? EventTime { get; set; }

        [StringLength(128)]
        public string EventType { get; set; }

        [StringLength(128)]
        public string ServerName { get; set; }

        [StringLength(128)]
        public string DatabaseName { get; set; }

        [StringLength(128)]
        public string SchemaName { get; set; }

        [StringLength(128)]
        public string ObjectType { get; set; }

        [StringLength(128)]
        public string ObjectName { get; set; }

        [StringLength(128)]
        public string UserName { get; set; }

        public string CommandText { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "xml")]
        public string XmlEvent { get; set; }
    }
}
