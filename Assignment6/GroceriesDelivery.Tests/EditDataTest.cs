using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions;
using GroceriesDelivery.Models;
using GroceriesDelivery;
using GroceriesDelivery.Data;
using GroceriesDelivery.Pages_Customer;

namespace GroceriesDelivery.Tests
{
    public class EditDataTest
    {

        private readonly ITestOutputHelper outputHelper;

        public EditDataTest(ITestOutputHelper outputHelper) {
            this.outputHelper = outputHelper;
        } 

        [Fact]
        public void CanEditCustomerName()
        {
            // Arrange
            var p = new Customer { CustID = "jramirez", CustPassword = "ale949", CustName = "Jocelin Ramirez", CustAddress = "139 Neverland St", CustEmail = "jramirez@email.com", CustPhone = "848-393-4949" };

            // Act
            p.CustName = "Alessandra Ramirez";

            // Assert
            Assert.Equal("Alessandra Ramirez", p.CustName);

        }

        [Fact]
        public void CanEditOrderStatus()
        {
            // Arrange
            var p = new Order { OrderDateCreated = DateTime.Parse("2021-02-01"), OrderStatus = "Pending", CustID = "jbabb", DriverID = "rslavik" };

            // Act
            p.OrderStatus = "Fulfilled";

            // Assert
            Assert.Equal("Fulfilled", p.OrderStatus);
        }

        [Fact]
        public void CanEditDriversPhone()
        {
            // Arrange
            var p = new Driver { DriverID = "rslavik", DriverPassword = "Jj-dj20", DriverName = "Rachael Slavik", DriverPhone = "222-394-3003" };

            // Act
            p.DriverPhone = "885-494-3933";

            // Assert
            Assert.Equal("885-494-3933", p.DriverPhone);
        }

    }
}
