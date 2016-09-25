using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherTest.Model;

namespace WeatherTest.Business
{
    //This class interfaces the Live API
    //Assumption about the logic which identifies the availle APIs to interface with
    //For this sample, I have hard coded the Bbc and Accu Sample APIs
    //Because time constraints, no error handling has been done yet
    public class WeatherTestAPIService
    {
        public WeatherData QueryLiveWeatherData(string location)
        {
            //Use parent class to hold aggregated data in 
            //WeatherDataSourceSystemType.CelsiusAndKph system
            var aggregatedData = new WeatherData();
            var allData = new List<IWeatherData>();
            
            var bbcData = DownloadBbcWeather(location);
            allData.Add(bbcData);

            var accuData = DownloadAccuWeather(location);
            allData.Add(accuData);

            aggregatedData.Location = bbcData.Location;//Same location, so any API should do
            aggregatedData.Temperature = allData.Average(data => data.GetTempInCelsius());// bbcData.GetTempInCelsius() + accuData.GetTempInCelsius()
            aggregatedData.Windspeed = allData.Average(data => data.GetWindSpeedInKph());

            return aggregatedData;
        }

        private AccuWeatherData DownloadAccuWeather(string location)
        {
            var apiUrl = String.Format(@"http://localhost:60368/{0}",location);
            var apiService = new WeatherTestAPIService();

            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);
            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);

            var accuData = new AccuWeatherData()
            {
                Temperature = data.TemperatureFahrenheit.Value,
                Windspeed =data.WindSpeedMph.Value,
                Location = data.Where
            };

            return accuData;
        }
        private BbcWeatherData DownloadBbcWeather(string location)
        {
            // Arrange
            var apiUrl = String.Format(@"http://localhost:60350/weather/london", location);
            var apiService = new WeatherTestAPIService();

            //Act
            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);

            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);
            //{"location":"london","temperatureCelsius":6.0,"windSpeedKph":31.0}

            var bbcData = new BbcWeatherData()
            {
                Temperature = data.TemperatureCelsius.Value,
                Windspeed = data.WindSpeedKph.Value,
                Location = data.Location
            };
            return bbcData;
        }
        public async Task<string> DownloadWeatherDataFromAPI(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(@url);

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
