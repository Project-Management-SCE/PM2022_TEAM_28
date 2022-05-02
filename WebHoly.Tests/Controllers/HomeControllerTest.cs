using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHoly.Controllers;
using Xunit;

namespace WebHoly.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result =  controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Privacy_ReturnAViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void THanks_ReturnAViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Thanks();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
