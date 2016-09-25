using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherTest.Business
{
    public class HttpClientHelpers
    {
        public async Task<string> DownloadWeatherDataFromAPI(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(@url);

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
