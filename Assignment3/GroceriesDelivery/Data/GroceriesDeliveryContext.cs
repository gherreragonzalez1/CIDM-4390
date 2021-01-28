using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceriesDelivery.Models;


namespace GroceriesDelivery.Data {
    public class GroceriesDeliveryContext : DbContext
    {
        public GroceriesDeliveryContext (DbContextOptions<GroceriesDeliveryContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Driver> Driver { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Order>().ToTable("Order");
        }

    }
}
