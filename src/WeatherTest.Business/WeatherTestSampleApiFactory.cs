using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Business
{
    public class WeatherTestSampleApiFactory
    {

        public virtual IWeatherTestSampleApi CreateWeatherTestSampleApi(WeatherTestApiType apiType)
        {
            IWeatherTestSampleApi weatherTestSampleApi = null;
            switch (apiType)
            {
                case WeatherTestApiType.Accu:
                    weatherTestSampleApi = new WeatherTestSampleApiAccu();
                    break;
                case WeatherTestApiType.Bbc:
                    weatherTestSampleApi = new WeatherTestSampleApiBbc();
                    break;
            }

            return weatherTestSampleApi;
        }
    }
}
