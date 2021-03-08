using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceriesDelivery.Models;


namespace GroceriesDelivery.Data {
    public class GroceriesDeliveryContext : DbContext
    {
        public GroceriesDeliveryContext(DbContextOptions<GroceriesDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Driver> Driver { get; set; }

        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Order>().ToTable("Order");
        }

        public void Initialize()
        {
            Customer.AddRange(GetSeedingCustomers());
            Driver.AddRange(GetSeedingDrivers());
            Order.AddRange(GetSeedingOrders());
            SaveChanges();
        }

        

        public static List<Customer> GetSeedingCustomers()
        {
            return new List<Customer>()
            {
                new Customer{CustID = "jbabb", CustPassword = "jbabb123", CustName = "Jeffry Babb", CustAddress = "123 West Texas Dr", CustEmail = "jbabb@wtamu.edu", CustPhone = "123-948-3938"},
                new Customer{CustID = "gherrera", CustPassword = "buff0", CustName = "Gerardo Herrera", CustAddress = "859 Maroon St", CustEmail = "gherrera@email.com", CustPhone = "555-495-9393"},
                new Customer{CustID = "bbentley", CustPassword = "cidm2021", CustName = "Barek Bentley", CustAddress = "393 Blue Dr", CustEmail = "bbentley@email.edu", CustPhone = "874-949-3031"}
            };
        }

        public static List<Driver> GetSeedingDrivers()
        {
            return new List<Driver>()
            {
                new Driver{DriverID = "jlofgren", DriverPassword = "wtamU932", DriverName = "Jonathan Lofgren", DriverPhone = "393-494-4984"},
                new Driver{DriverID = "mbrowning", DriverPassword = "jghH-489", DriverName = "Mary Browning", DriverPhone = "495-493-2929"},
                new Driver{DriverID = "rslavik", DriverPassword = "Jj-dj20", DriverName = "Rachael Slavik", DriverPhone = "222-394-3003"}
            };
        }

        public static List<Order> GetSeedingOrders()
        {
            return new List<Order>()
            {
                new Order{OrderDateCreated = DateTime.Parse("2021-02-12"), OrderStatus = "Pending", CustID = "jbabb", DriverID = "mbrowning"},
                new Order{OrderDateCreated = DateTime.Parse("2021-01-03"), OrderStatus = "Fulfilled", CustID = "gherrera", DriverID = "jlofgren"},
                new Order{OrderDateCreated = DateTime.Parse("2021-01-30"), OrderStatus = "Fulfilled", CustID = "bbentley", DriverID = "mbrowning"},
                new Order{OrderDateCreated = DateTime.Parse("2021-01-14"), OrderStatus = "Pending", CustID = "gherrera", DriverID = "rslavik"},
                new Order{OrderDateCreated = DateTime.Parse("2021-02-04"), OrderStatus = "Canceled", CustID = "jbabb", DriverID = "rslavik"}
            };
        }

        public async virtual Task<List<Customer>> GetCustomersAsync() 
        {
            return await Customer
                .OrderBy(c => c.CustName)
                .ToListAsync();
        }

        public async virtual Task AddCustomerAsync(Customer customer) 
        {
            await Customer.AddAsync(customer);
            await SaveChangesAsync();
        }

        public async virtual Task DeleteCustomerAsync(string id)
        {
            var customer = await Customer.FindAsync(id);

            if (customer != null)
            {
                Customer.Remove(customer);
                await SaveChangesAsync();
            }
        }

         public async virtual Task<List<Driver>> GetDriversAsync() 
        {
            return await Driver
                .OrderBy(c => c.DriverName)
                .ToListAsync();
        }

        public async virtual Task AddDriverAsync(Driver driver) 
        {
            await Driver.AddAsync(driver);
            await SaveChangesAsync();
        }
        
        public async virtual Task DeleteDriverAsync(string id)
        {
            var driver = await Driver.FindAsync(id);

            if (driver != null)
            {
                Driver.Remove(driver);
                await SaveChangesAsync();
            }
        }
    }
}
