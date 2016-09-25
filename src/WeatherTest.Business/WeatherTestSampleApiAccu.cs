using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Model;

namespace WeatherTest.Business
{
    public class WeatherTestSampleApiAccu : IWeatherTestSampleApi
    {
        public IWeatherData QueryWeatherData(string location)
        {
            var apiUrl = String.Format(@"http://localhost:60368/{0}", location);
            var apiService = new HttpClientHelpers();

            var sut = apiService.DownloadWeatherDataFromAPI(apiUrl);
            var data = JsonConvert.DeserializeObject<WeatherApiPayload>(sut.Result);

            var accuData = new AccuWeatherData()
            {
                Temperature = data.TemperatureFahrenheit.Value,
                Windspeed = data.WindSpeedMph.Value,
                Location = data.Where
            };

            return accuData;
        }
    }
}
