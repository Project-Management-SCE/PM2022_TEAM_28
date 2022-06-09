using Microsoft.AspNetCore.Identity;
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
    public class PrayerTimesControllerTest : IClassFixture<WebApplicationFactory<WebHoly.Startup>>
    {

        private readonly ApplicationDbContext _context;
       

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            // Arrange

            //var controller = new PrayerTimesController(_context);

            //// Act
            //var result = controller.Create();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange

            //var controller = new PrayerTimesController(_context);

            //// Act
            //var result = controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
        }

    }
}
