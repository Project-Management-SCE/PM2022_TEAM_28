using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebHoly.Data;
using WebHoly.Tests.Helpers;
using WebHoly.Tests.Identity;
using Xunit;

namespace WebHoly.Tests.IntegrationTests
{
    #region snippet1

    public class LoginPageTests :
       IClassFixture<CustomWebApplicationFactory<WebHoly.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<WebHoly.Startup>
        _factory;

        public LoginPageTests(
            CustomWebApplicationFactory<WebHoly.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
#endregion

        #region snippet2
        [Fact]
        public async Task LoginTest()
        {
            // Arrange
           var defaultPage = await _client.GetAsync("/Login");
            var content = await HtmlHelpers.GetDocumentAsync(defaultPage);

            //Act
            var response = await _client.SendAsync(
                (IHtmlFormElement)content.QuerySelector("form[id='account']"),
                (IHtmlButtonElement)content.QuerySelector("button[id='login']"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, defaultPage.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("/Login", response.RequestMessage.Headers.Referrer.AbsolutePath);
        }
        #endregion

       
        
    }
}
