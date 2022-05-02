using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHoly.Controllers;
using Xunit;

namespace WebHoly.Tests.Controllers
{
    public class ApiControllerTest
    {
        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);
            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ShabbatApiHebcal_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);
            string city = "Tal-Aviv";
            // Act
            var result = controller.ShabbatApiHebcal(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void JewishCalendarHebcal_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);
            int city = 215624;
            // Act
            var result = controller.JewishCalendarHebcal(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ShabbatTimesHebcal_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);
            string city = "Hifa";

            // Act
            var result = controller.ShabbatTimesHebcal(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void HebrewdatesHebcal_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);

            // Act
            var result = controller.HebrewdatesHebcal();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void BiblebookApi_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object);
            string city = "Hifa";

            // Act
            var result = controller.BiblebookApi(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public void citys_ReturnString()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}

        //[Fact]
        //public voidTodayTimeHebcal_ReturnTodayTimeHebcalViewModel()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}

        //[Fact]
        //public void BibleApichapter_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}

        //[Fact]
        //public void MidrasSefariaApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}
    }
}
