using Microsoft.EntityFrameworkCore;
using eStoreAPI.Models.Entities;

namespace eStoreAPI.Data
{
    public class EStoreDbContext : DbContext
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data cho Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics", Description = "Electronic devices and accessories" },
                new Category { CategoryId = 2, CategoryName = "Clothing", Description = "Fashion and clothing items" },
                new Category { CategoryId = 3, CategoryName = "Books", Description = "Books and educational materials" }
            );

            // Seed data cho Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Laptop Dell", UnitPrice = 1500m, UnitsInStock = 10, CategoryId = 1, Description = "High performance laptop" },
                new Product { ProductId = 2, ProductName = "iPhone 15", UnitPrice = 999m, UnitsInStock = 20, CategoryId = 1, Description = "Latest iPhone model" },
                new Product { ProductId = 3, ProductName = "T-Shirt", UnitPrice = 25m, UnitsInStock = 50, CategoryId = 2, Description = "Cotton t-shirt" }
            );
        }
    }
}