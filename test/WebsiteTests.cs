using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{

    //TODO: Due to time constraints, website integration tests are pending
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
            var request = new HttpRequestMessage(HttpMethod.Get, "/Home");

            // Act
            var response = await Client.GetAsync("/Home");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        } 

    }
}
