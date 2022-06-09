using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebHoly.Controllers;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.Service;
using Xunit;

namespace WebHoly.Tests.Controllers
{
    public class HolySubscriptionsControllerTest : IClassFixture<WebApplicationFactory<WebHoly.Startup>>
    {

        private ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IConfiguration _configuration { get; }
        public IEmailSender _emailSender { get; }

        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var mockIConfiguration = new Mock<IConfiguration>();
            var mockEmailSender = new Mock<IEmailSender>();
         
            var controller = new HolySubscriptionsController(_context, _userManager, _signInManager, mockIConfiguration.Object, mockEmailSender.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}


        //[Fact]
        //public void BiblebookApi_ReturnsAViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IHttpClientFactory>();
        //    var controller = new ApiController(mockRepo.Object, user);
        //    string city = "Hifa";

        //    // Act
        //    var result = controller.BiblebookApi(city);

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //}

    }
}
