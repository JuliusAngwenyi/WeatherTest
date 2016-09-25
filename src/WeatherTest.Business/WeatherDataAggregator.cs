using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherTest.Model;

namespace WeatherTest.Business
{
    public static class WeatherDataAggregator
    {
        //Sample static class to simulate data from API
        public static WeatherData QueryTestWeatherData(string location)
        {
            //Use parent class to hold aggregated data in 
            //WeatherDataSourceSystemType.CelsiusAndKph system
            var aggregatedData = new WeatherData();
            var allData = new List<IWeatherData>(); 

            //TODO: Interface with actual API
            var bbcData = new BbcWeatherData()
            {
                Temperature = 10,//Celsius
                Windspeed = 8,//Kph
                Location = location
            };
            allData.Add(bbcData);

            var accuData = new AccuWeatherData()
            {
                Temperature = 68,//Fahrenheit
                Windspeed = 10,//Mph
                Location = location
            };
            allData.Add(accuData);

            aggregatedData.Location = location;
            aggregatedData.Temperature = allData.Average(data=>data.GetTempInCelsius());// bbcData.GetTempInCelsius() + accuData.GetTempInCelsius()
            aggregatedData.Windspeed = allData.Average(data => data.GetWindSpeedInKph());

            return aggregatedData;
        }

    }
}
