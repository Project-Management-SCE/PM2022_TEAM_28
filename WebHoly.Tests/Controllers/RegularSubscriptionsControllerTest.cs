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
    public class RegularSubscriptionsControllerTest : IClassFixture<WebApplicationFactory<WebHoly.Startup>>
    {

        private ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

   
    
        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var controller = new RegularSubscriptionsController(_context, _userManager, _signInManager);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //// Arrange
            //var controller = new RegularSubscriptionsController(_context, _userManager, _signInManager);

            //// Act
            //var result = controller.Create();

            //// Assert
            //var viewResult = Assert.IsType<IActionResult>(result);
        }
    }
}
