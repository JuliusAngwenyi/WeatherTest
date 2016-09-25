using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Model;

namespace WeatherTest.Business
{
    public class WeatherTestSampleApiBbc : IWeatherTestSampleApi
    {
        public IWeatherData QueryWeatherData(string location)
        {
            {
                var apiUrl = String.Format(@"http://localhost:60350/weather/london", location);
                var apiService = new HttpClientHelpers();

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
        }
    }
}
