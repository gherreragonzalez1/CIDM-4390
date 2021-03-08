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
using GroceriesDelivery.Pages_Driver;
using GroceriesDelivery.Data;
using GroceriesDelivery.Models;

namespace GroceriesDelivery.Tests
{
    public class DriverPageTests
    {

        //https://xunit.net/docs/capturing-output
        private readonly ITestOutputHelper outputHelper;

        public DriverPageTests(ITestOutputHelper outputHelper) {
            this.outputHelper = outputHelper;
        }
        
        [Fact]
        public async Task OnPostAddDriverAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var pageModel = new CreateModel(mockGroceriesDeliveryContext.Object);
            Driver mockDriver = new Driver { DriverID = "kjasso", DriverPassword = "!azkaban!", DriverName = "Karla Jasso", DriverPhone = "585-495-4949" };

            // Act
            var result = await pageModel.OnPostAsync(mockDriver);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Fact]
        public async Task OnPostAddDriverAsync_ReturnsAPageResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var expectedDrivers = GroceriesDeliveryContext.GetSeedingDrivers();
            mockGroceriesDeliveryContext.Setup(db => db.GetDriversAsync()).Returns(Task.FromResult(expectedDrivers));
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
            pageModel.ModelState.AddModelError("Driver.DriverID", "The DriverID field is required.");
            var mockedDriver = new Driver { DriverID = "jherrera", DriverPassword = "manila505", DriverName = "Juan Herrera", DriverPhone = "808-939-9930"};

            // Act
            var result = await pageModel.OnPostAsync(mockedDriver);

            // Assert
            Assert.IsType<PageResult>(result);
        }


        [Fact]
        public async Task OnPostDeleteDriverAsync_ReturnsARedirectToPageResult()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesDeliveryContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockGroceriesDeliveryContext = new Mock<GroceriesDeliveryContext>(optionsBuilder.Options) {CallBase = true};
            var pageModel = new DeleteModel(mockGroceriesDeliveryContext.Object);
            var mockID = "mbrowning";

            // Act
            var result = await pageModel.OnPostAsync(mockID);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}