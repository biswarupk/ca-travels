namespace CA_UnitTest
{
    using System;
    using NUnit.Framework;
    using Moq;
    using Microsoft.Extensions.Configuration;
    using CATravels.Controllers;
    using CA_UnitTest.TestData;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using CatTravels.Utility.Abstract;
    using CatTravels.Service.Abstract;

    [TestFixture]
    public class ControllerUnitTest
    {
        private Mock<IConfiguration> config;
        private Mock<ILogger> log;
        private Mock<IHotelService> service;
        private HotelDetailsList_MockData mockData;

        [SetUp]
        public void Setup()
        {
            config = new Mock<IConfiguration>();
            log = new Mock<ILogger>();
            service = new Mock<IHotelService>();
            mockData = new HotelDetailsList_MockData();
        }

        /// <summary>
        /// The purpose of this test method is to check whether correct view is called or not.
        /// </summary>
        /// <param name="apiUrl">This is the test api endpoint</param>
        /// <param name="authCode">This is the test api auth code</param>
        /// <returns>Returns the Task to which assertion of condition is performed. Checks for the Model passed to View is not null </returns>
        [Test]
        [TestCase("https://webbedsdevtest.azurewebsites.net/api/", "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==")]
        public async Task TestIndexFunction_WhenPassedAnyIntegerAndUrlToGetHotelDetailsList_ShouldReturnActionResult(string apiUrl, string authCode)
        {
            //arrange
            HotelController hotelController = new HotelController(config.Object, log.Object, service.Object);
            service.Setup(x => x.GetHotelDetailsList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(() =>
            {
                return mockData.MockData;
            });
            config.Setup(x => x.GetSection("APIUrl").Value).Returns(() =>
            {
                return apiUrl;
            });
            config.Setup(x => x.GetSection("AuthCode").Value).Returns(() =>
            {
                return authCode;
            });

            //act
            var result = await hotelController.Index(2, 3) as ViewResult;

            //assert
            Assert.That(result.ViewData["ResultSet"], Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        /// <summary>
        /// The purpose of this test method is to check whether correct view is called or not.
        /// </summary>
        /// <param name="apiUrl">This is the test api endpoint</param>
        /// <param name="authCode">This is the test api auth code</param>
        /// <returns>Returns the Task to which assertion of condition is performed.Checks for the null result to be passed to view.Also check if the ViewResult is returned. </returns>
        [Test]
        [TestCase("https://webbedsdevtest.azurewebsites.net/api/", "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==")]
        public async Task TestIndexFunction_WhenGetHotelDetailsListReturnsNull_ShouldReturnViewResult(string apiUrl, string authCode)
        {
            //arrange
            HotelController hotelController = new HotelController(config.Object, log.Object, service.Object);
            service.Setup(x => x.GetHotelDetailsList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(() =>
            {
                return null;
            });
            config.Setup(x => x.GetSection("APIUrl").Value).Returns(() =>
            {
                return apiUrl;
            });
            config.Setup(x => x.GetSection("AuthCode").Value).Returns(() =>
            {
                return authCode;
            });

            //act
            var result = await hotelController.Index(2, 3) as ViewResult;

            //assert
            Assert.That(result.ViewData["ResultSet"], Is.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
        }

        /// <summary>
        /// The purpose of this test method is to check whether correct view is called or not.
        /// </summary>
        /// <param name="apiUrl">This is the test api endpoint</param>
        /// <param name="authCode">This is the test api auth code</param>
        /// <returns>Returns the Task to which assertion of condition is performed.Checks for the exception and returns Error.cshtml view. </returns>
        [Test]
        [TestCase("https://webbedsdevtest.azurewebsites.net/api/", "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==")]
        public async Task TestIndexFunction_WhenGetHotelDetailsListReturnsException_ShouldReturnViewResult(string apiUrl, string authCode)
        {
            //arrange
            HotelController hotelController = new HotelController(config.Object, log.Object, service.Object);
            service.Setup(x => x.GetHotelDetailsList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(() =>
            {
                throw new Exception();
            });
            config.Setup(x => x.GetSection("APIUrl").Value).Returns(() =>
            {
                return apiUrl;
            });
            config.Setup(x => x.GetSection("AuthCode").Value).Returns(() =>
            {
                return authCode;
            });

            //act
            var result = await hotelController.Index(2, 3) as ViewResult;

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }
    }
}