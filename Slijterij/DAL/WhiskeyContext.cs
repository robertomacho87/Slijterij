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





    }
}
