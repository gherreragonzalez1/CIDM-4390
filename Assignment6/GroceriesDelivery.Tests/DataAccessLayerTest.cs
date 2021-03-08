using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using GroceriesDelivery.Data;
using GroceriesDelivery.Models;

namespace GroceriesDelivery.Tests
{
    public class DataAccessLayerTest
    {
        // Customer Data Tests
        [Fact]
        public async Task GetCustomersAsync_CustomersAreReturned()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedCustomers = GroceriesDeliveryContext.GetSeedingCustomers();
                await db.AddRangeAsync(expectedCustomers);
                await db.SaveChangesAsync();

                // Act
                var result = await db.GetCustomersAsync();

                // Assert
                var actualCustomers = Assert.IsAssignableFrom<List<Customer>>(result);
                Assert.Equal(
                    expectedCustomers.OrderBy(c => c.CustID).Select(c => c.CustID), 
                    actualCustomers.OrderBy(c => c.CustID).Select(c => c.CustID));
            }
        }

        [Fact]
        public async Task AddCustomerAsync_CustomerIsAdded()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var mockID = "aramos";
                var expectedCustomer = new Customer{CustID = mockID, CustPassword = "pp99!", CustName = "Andres Ramos", CustAddress = "54 Waking Dr", CustEmail = "aramos@email.com", CustPhone = "555-495-4949"};

                // Act
                await db.AddCustomerAsync(expectedCustomer);

                // Assert
                var actualCustomer = await db.FindAsync<Customer>(mockID);
                Assert.Equal(expectedCustomer, actualCustomer);
            }
        }

        [Fact]
        public async Task DeleteCustomerAsync_CustomerIsDeleted_WhenCustomerIsFound()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedCustomers = GroceriesDeliveryContext.GetSeedingCustomers();
                await db.AddRangeAsync(seedCustomers);
                await db.SaveChangesAsync();
                var mockID = "jbabb";
                var expectedCustomers = seedCustomers.Where(c => c.CustID != mockID).ToList();

                // Act
                await db.DeleteCustomerAsync(mockID);

                // Assert
                var actualCustomers = await db.Customer.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedCustomers.OrderBy(c => c.CustID).Select(c => c.CustName),
                    actualCustomers.OrderBy(c => c.CustID).Select(c => c.CustName));
            }
        }

        [Fact]
        public async Task DeleteCustomerAsync_NoCustomerIsDeleted_WhenCustomerIsNotFound()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedCustomers = GroceriesDeliveryContext.GetSeedingCustomers();
                await db.AddRangeAsync(expectedCustomers);
                await db.SaveChangesAsync();
                var mockID = "galia";

                // Act
                try
                {
                    await db.DeleteCustomerAsync(mockID);
                }
                catch
                {
                    // mockID does not exist
                }

                // Assert
                var actualCustomers = await db.Customer.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedCustomers.OrderBy(c => c.CustID).Select(c => c.CustName), 
                    actualCustomers.OrderBy(c => c.CustID).Select(c => c.CustName));
            }
        }

        // Driver Data Tests
        [Fact]
        public async Task GetDriversAsync_DriversAreReturned()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedDrivers = GroceriesDeliveryContext.GetSeedingDrivers();
                await db.AddRangeAsync(expectedDrivers);
                await db.SaveChangesAsync();

                // Act
                var result = await db.GetDriversAsync();

                // Assert
                var actualDrivers = Assert.IsAssignableFrom<List<Driver>>(result);
                Assert.Equal(
                    expectedDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverID), 
                    actualDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverID));
            }
        }

        [Fact]
        public async Task AddDriverAsync_DriverIsAdded()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var mockID = "pgonzalez";
                var expectedDriver = new Driver { DriverID = mockID, DriverPassword = "password848", DriverName = "Patty Gonzalez", DriverPhone = "484-449-4949"};

                // Act
                await db.AddDriverAsync(expectedDriver);

                // Assert
                var actualDriver = await db.FindAsync<Driver>(mockID);
                Assert.Equal(expectedDriver, actualDriver);
            }
        }

        [Fact]
        public async Task DeleteDriverAsync_DriverIsDeleted_WhenDriverIsFound()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedDrivers = GroceriesDeliveryContext.GetSeedingDrivers();
                await db.AddRangeAsync(seedDrivers);
                await db.SaveChangesAsync();
                var mockID = "mbrowning";
                var expectedDrivers = seedDrivers.Where(c => c.DriverID != mockID).ToList();

                // Act
                await db.DeleteDriverAsync(mockID);

                // Assert
                var actualDrivers = await db.Driver.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverName),
                    actualDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverName));
            }
        }

        [Fact]
        public async Task DeleteDriverAsync_NoDriverIsDeleted_WhenDriverIsNotFound()
        {
            using (var db = new GroceriesDeliveryContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedDrivers = GroceriesDeliveryContext.GetSeedingDrivers();
                await db.AddRangeAsync(expectedDrivers);
                await db.SaveChangesAsync();
                var mockID = "amoreno";

                // Act
                try
                {
                    await db.DeleteDriverAsync(mockID);
                }
                catch
                {
                    // mockID does not exist
                }

                // Assert
                var actualDrivers = await db.Driver.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverName), 
                    actualDrivers.OrderBy(d => d.DriverID).Select(d => d.DriverName));
            }
        }
    }
}