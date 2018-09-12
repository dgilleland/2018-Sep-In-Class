/*  Mapping our C# Entities to Database Tables
 *      By default, the Entity Framework (EF) will use some "defaults" in mapping classes to database
 *  tables. For example, if the C# class is named "Employee" (singular), then Entity Framework will
 *  assume that the database table is called "Employees" (plural). Likewise, for the same Employee
 *  class, Entity Framework is going to look for a property in the class called either "ID" or
 *  "EmployeeID" to represent the Primary Key column in the database table.
 *
 *      We can override these default assumptions of Entity Framework by adding Annotations to
 *  our class and its properties. The following annotations are used in this code sample:
 *      - [Table("TableName")]  //  This annotation is placed right before the class declaration
 *                                  and tells EF to map this class to the TableName in the annotation.
 *      - [Key]                 //  This annotation is placed right before the property declaration
 *                                  in the class that is supposed to map to the Primary Key column
 *                                  in the table.
 *      - [NotMapped]           //  This annotation is placed before any property declaration in our class
 *                                  that does NOT have a corresponding column name in the database table.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // for [Key]

// The following namespace is only available if you add Entity Framework via NuGet
using System.ComponentModel.DataAnnotations.Schema; // for [Table]

namespace NorthwindTraders.Entities
{
    [Table("Products", Schema = "dbo")] // map this class to a specific table name
    public class Product // Keep in the singular
    {
        #region Column Mappings

        [Key]
        public int ProductID { get; set; }          // ProductID    int     PRIMARY KEY     NOT NULL,

        public string ProductName { get; set; }     // ProductName  nvarchar(40)            NOT NULL,
        public int? SupplierID { get; set; }        // SupplierID   int                         NULL,
        public int? CategoryID { get; set; }        // CategoryID   int                         NULL,
        public string QuantityPerUnit { get; set; } // QuantityPerUnit  nvarchar(20)            NULL,
        public decimal? UnitPrice { get; set; }     // UnitPrice    money                       NULL,
        public short? UnitsInStock { get; set; }    // UnitsInStock smallint                    NULL,
        public short? UnitsOnOrder { get; set; }    // UnitsOnOrder smallint                    NULL,
        public short? ReorderLevel { get; set; }    // ReorderLevel smallint                    NULL,
        public bool Discontinued { get; set; }      // Discontinued bit                     NOT NULL,
        public DateTime LastModified { get; set; }  // LastModified datetime                NOT NULL

        #endregion Column Mappings

        #region Navigational Property

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
            = new HashSet<OrderDetail>();

        #endregion Navigational Property
    }
}