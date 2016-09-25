using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class WebsiteTests : IClassFixture<TestFixture<WeatherTest.SampleWebsite.Startup>>
    {
        public WebsiteTests(TestFixture<WeatherTest.SampleWebsite.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Theory]
        [InlineData("GET")]
        public async Task HomePageReturns200(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/");

            // Act
            var response = await Client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        } 

    }
}
