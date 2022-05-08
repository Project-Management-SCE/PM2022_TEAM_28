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
    public class ApiControllerTest : IClassFixture<WebApplicationFactory<WebHoly.Startup>>
    {
        
        private ApplicationDbContext user;
        private HttpRequestMessage request;

        [Fact]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
           ;
            var controller = new ApiController(mockRepo.Object, user);
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
            var controller = new ApiController(mockRepo.Object, user);
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
            var controller = new ApiController(mockRepo.Object, user);
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
            var controller = new ApiController(mockRepo.Object, user);
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
            var controller = new ApiController(mockRepo.Object,user);

            //Act
            var result = controller.HebrewdatesHebcal();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void BiblebookApi_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object, user);
            string city = "Hifa";

            // Act
            var result = controller.BiblebookApi(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        

        [Fact]
        public void TodayTimeHebcal_ReturnTodayTimeHebcalViewModel()
        {
            var mockRepo = new Mock<IHttpClientFactory>();
            var di = GetTestSessions();
            // Arrange
            var controller = new ApiController(mockRepo.Object,user);
            string city = "חיפה";

            // Act
            var result = controller.TodayTimeHebcal(city);

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<todaytimeApiviewModel>>(di);
            var r = Assert.IsAssignableFrom<todaytimeApiviewModel>(result);
            Assert.Equal(2, model.Count());
            Assert.Equal("294801", r.CityId);
        }
        private List<todaytimeApiviewModel> GetTestSessions()
        {
            var sessions = new List<todaytimeApiviewModel>();
            sessions.Add(new todaytimeApiviewModel()
            {
                TodayDate = DateTime.Now,
                CityId = "3215262"
            });
            sessions.Add(new todaytimeApiviewModel()
            {
                TodayDate = DateTime.Now,
                CityId = "32152621"
            });
            return sessions;

        }


        [Fact]
        public void BibleApichapter_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object,user);
            string city = "Hifa";

            // Act
            var result = controller.BiblebookApi(city);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task MidrasSefariaApi_ReturnsAViewResultAsync()
        {

            // Arrange
            var mockRepo = new Mock<IHttpClientFactory>();
            var controller = new ApiController(mockRepo.Object, user);
            string book = "Exodus";
            int sChapter = 2;
            int eChapter = 3;
            // Act
            var result = controller.MidrasSefariaApi(book, sChapter, eChapter);


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.sefaria.org/api/links/{book}.{sChapter}.{eChapter}"),
                Headers =
                {
                    { "Accept", "application/json"}
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);
                // Assert

                string Titel = res[0]["index_title"];
                Assert.True(Titel.Equals("Shemot Rabbah"));
            }
        }
    }
}
