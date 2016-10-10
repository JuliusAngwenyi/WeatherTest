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
    //Assumption about the logic which identifies the available APIs to interface with
    //For this sample, I have hard coded the Bbc and Accu Sample APIs within the Enum
    //To extend with more APIs, a) simply add new values to the Enum WeatherTestAPIType
    //b)Create new Factory class which inherits from base WeatherTestSampleApiFactory and implements those new APIs
    public class WeatherTestAPIService: IWeatherTestAPIService
    {
        public WeatherData QueryLiveWeatherData(string location)
        {
            //Use parent/base class to hold aggregated data which will use 
            //WeatherDataSourceSystemType.CelsiusAndKph metric system
            //During display to user, this will be converted to selected units
            var aggregatedData = new WeatherData();
            IWeatherTestSampleApi weatherApi = null;

            try
            {
                //Use IWeatherData for listing all data from different Apis
                var allData = new List<IWeatherData>();

                //Factory pattern to instantiate specific Apis based on Api Type
                var apiFactory = new WeatherTestSampleApiFactory();

                var availableApis = Enum.GetValues(typeof(WeatherTestApiType)).Cast<WeatherTestApiType>();
                foreach (var api in availableApis)
                {
                    weatherApi = apiFactory.CreateWeatherTestSampleApi(api);
                    var apiData = weatherApi.QueryWeatherData(location);
                    if (apiData != null) //Gracefully handle API availabilty, if API is not working for example
                    {
                        allData.Add(apiData);
                    }
                }
                if (allData.Any())//If no APIs are working at all, aggregatedData will have default values(null object pattern). User interface can use this to display warning messages
                {
                    aggregatedData.Location = location;//Same location, so any API location value should do
                    aggregatedData.Temperature = allData.Average(data => data.GetTempInCelsius());
                    aggregatedData.Windspeed = allData.Average(data => data.GetWindSpeedInKph());
                }
            }
            catch (Exception)
            {
                //TODO ILog.LogError()...
            }

            return aggregatedData;
        }
    }
    
}
