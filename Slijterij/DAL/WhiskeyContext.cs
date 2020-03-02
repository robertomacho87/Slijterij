using Microsoft.EntityFrameworkCore;
using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slijterij.DAL
{
    public class WhiskeyContext : DbContext
    {
        public WhiskeyContext(DbContextOptions<WhiskeyContext> options) : base(options)
        {
        }

        public DbSet<Origin> Origins { get; set; }
        public DbSet<TypeOfWhiskey> TypesOfWhiskey { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add Fluent API configuration here
            modelBuilder.Entity<Order>().Property(t => t.Date).HasColumnType("Date");
            modelBuilder.Entity<Product>().Property(t => t.Price).HasColumnType("Money");
            modelBuilder.Entity<OrderProduct>().HasKey(o => new { o.OrderID, o.ProductID });

            // Database seed data
            modelBuilder.Entity<TypeOfWhiskey>().HasData(
                new TypeOfWhiskey { ID = 1, Name = "Single malt" },
                new TypeOfWhiskey { ID = 2, Name = "Blended malt" });
            modelBuilder.Entity<Origin>().HasData(
                new Origin { ID = 1, Name = "Highland" },
                new Origin { ID = 2, Name = "Lowland" });
            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "Seaweed", Age = 30, AlcoholByVolume = 40, TypeID = 2, OriginID = 2, Price = 499.99M, AmountInStock = 1, Available = true },
                new Product { ID = 2, Name = "Oak", Age = 10, AlcoholByVolume = 40, TypeID = 1, OriginID = 1, Price = 49.99M, AmountInStock = 15, Available = false },
                new Product { ID = 3, Name = "Hammer Head", Age = 21, AlcoholByVolume = 40, TypeID = 1, OriginID = 2, Price = 50.00M, AmountInStock = 11, Available = true },
                new Product { ID = 4, Name = "Frysk Hynder", Age = 8, AlcoholByVolume = 40, TypeID = 2, OriginID = 1, Price = 9.99M, AmountInStock = 23, Available = true },
                new Product { ID = 5, Name = "Smoke", Age = 12, AlcoholByVolume = 40, TypeID = 2, OriginID = 1, Price = 99.95M, AmountInStock = 7, Available = false });
            
        }
    }
}
