using NorthwindTraders.Entities;
using System.Data.Entity;

namespace NorthwindTraders.DAL
{
    internal class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("name=NW2018") // name of the <connectionString><add name="" ...
        {
            // Since EF6 (by default) will want to create a database if it can't find it,
            // we can turn that feature off programmatically in our DbContext constructor.
            Database.SetInitializer<NorthwindContext>(null);
        }

        // Properties
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Region> Regions { get; set; }

        // Override base class method that does the details of mapping entities to the database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Here I could have a whole lot more control over how each entity
            // maps to the database tables.

            // DEMO: Many-to-Many Relationship Mapping
            modelBuilder
                .Entity<Employee>().HasMany(e => e.Territories)
                .WithMany(t => t.Employees)
                .Map(m => m.ToTable("EmployeeTerritories").MapLeftKey("EmployeeID").MapRightKey("TerritoryID"));

            base.OnModelCreating(modelBuilder);
        }
    }
}