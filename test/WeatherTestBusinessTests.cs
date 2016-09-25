using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherTest.Business;
using WeatherTest.Model;
using Xunit;
using Xunit.Abstractions;

namespace WeatherTests
{
    public class WeatherTestBusinessTests
    {
        private readonly ITestOutputHelper output;

        public WeatherTestBusinessTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestWeatherDataAggregationUsingTestData()
        {
            //Arrange
            var query = "london";
            var sut = WeatherDataAggregator.QueryTestWeatherData(query);
            //Act
            //Assert
            Assert.NotNull(sut);
            Assert.IsType<WeatherData>(sut);

            Assert.Equal(15, Math.Round(sut.GetTempInCelsius()));
            Assert.Equal(59, Math.Round(sut.GetTempInFahrenheit()));

            Assert.Equal(12, Math.Round(sut.GetWindSpeedInKph()));
            Assert.Equal(7.5, Math.Round(sut.GetWindSpeedInMph(), 1));
        }
        [Fact]
        public void TestSampleApiBbcWeatherRetunrsValidJson()
        {
            // Arrange
            var apiUrl = @"http://localhost:60350/weather/london";
            var apiService = new WeatherTestAPIService();

            //Act
            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);
           

            //Assert
            Assert.NotNull(sut);
            output.WriteLine(sut.Result);

            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);

            //{"location":"london","temperatureCelsius":6.0,"windSpeedKph":31.0}

        }

        [Fact]
        public void TestSampleApiBbcWeatherRetunrsLondon()
        {
            // Arrange
            var apiUrl = @"http://localhost:60350/weather/london";
            var apiService = new WeatherTestAPIService();

            //Act
            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);

            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);
            //{"location":"london","temperatureCelsius":6.0,"windSpeedKph":31.0}

            //Assert
            Assert.Equal("london", data.Location);
        }

        [Fact]
        public void TestSampleApiAccuWeatherRetunrsValidJson()
        {
            //Arrange
            var apiUrl = @"http://localhost:60368/paris";
            var apiService = new WeatherTestAPIService();

            //Act
            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);

            //Assert
            Assert.NotNull(sut);
            output.WriteLine(sut.Result);
             
        }
        [Fact]
        public void TestSampleApiAccuWeatherRetunrsParis()
        {
            //Arrange
            var apiUrl = @"http://localhost:60368/paris";
            var apiService = new WeatherTestAPIService();

            //Act
            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);
            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);
            //{"temperatureFahrenheit":75.0,"where":"paris","windSpeedMph":6.0}
            
            //Assert
            Assert.Equal("paris", data.Where);
        }

    }
}
