using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHoly.Controllers;
using WebHoly.Data;
using WebHoly.Tests.Helpers;
using Xunit;
using WebHoly.ViewModels;
using Newtonsoft.Json;

namespace WebHoly.Tests.Controllers
{
    public class SoulBoardsControllerTest : IClassFixture<WebApplicationFactory<WebHoly.Startup>>
    {

        private readonly ApplicationDbContext _context;


        [Fact]
        public void Index_ReturnsAViewResult()
        {
            //// Arrange
            //var controller = new SoulBoardsController(_context);
            //// Act
            //var result = controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            //// Arrange
            //var controller = new SoulBoardsController(_context);
            //// Act
            //var result = controller.Create();

            //// Assert
            //var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
