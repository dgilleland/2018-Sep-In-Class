namespace GroceryStore.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GroceryStore.Entities;

    public partial class GroceryListContext : DbContext
    {
        public GroceryListContext()
            : base("name=GroceryListContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Picker> Pickers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Province)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.CustomerComment)
                .IsUnicode(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.PickIssue)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.GST)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderLists)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Discount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderLists)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Province)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Pickers)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);
        }
    }
}
