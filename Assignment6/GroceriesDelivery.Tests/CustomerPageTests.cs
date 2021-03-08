using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Xunit.Abstractions;
using GroceriesDelivery.Pages_Customer;
using GroceriesDelivery.Data;
using GroceriesDelivery.Models;

namespace GroceriesDelivery.Tests
{
    public class CustomerPageTests
    {

        //https://xunit.net/docs/capturing-output
        private readonly ITestOutputHelper outputHelper;

        public CustomerPageTests(ITestOutputHelper outputHelper) {
            this.outputHelper = outputHelper;
        }
        
        [Fact]
        public async Task OnPostAddCustomerAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var pageModel = new CreateModel(mockGroceriesDeliveryContext.Object);
            Customer mockCustomer = new Customer { CustID = "dalvaran", CustPassword = "55aquiohp!", CustName = "Daniel Alvaran", CustAddress = "585 Juarez St", CustEmail = "dalvaran99@email.com", CustPhone = "444-595-4949" };

            // Act
            var result = await pageModel.OnPostAsync(mockCustomer);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostAddCustomerAsync_ReturnsAPageResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var expectedCustomers = GroceriesDeliveryContext.GetSeedingCustomers();
            mockGroceriesDeliveryContext.Setup(db => db.GetCustomersAsync()).Returns(Task.FromResult(expectedCustomers));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new CreateModel(mockGroceriesDeliveryContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            pageModel.ModelState.AddModelError("Customer.CustID", "The CustID field is required.");
            var mockedCustomer = new Customer{CustID = "aramos", CustPassword = "pp99!", CustName = "Andres Ramos", CustAddress = "54 Waking Dr", CustEmail = "aramos@email.com", CustPhone = "555-495-4949"};

            // Act
            var result = await pageModel.OnPostAsync(mockedCustomer);

            // Assert
            Assert.IsType<PageResult>(result);
        }


        [Fact]
        public async Task OnPostDeleteCustomerAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var pageModel = new DeleteModel(mockGroceriesDeliveryContext.Object);
            var mockID = "jbabb";

            // Act
            var result = await pageModel.OnPostAsync(mockID);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}