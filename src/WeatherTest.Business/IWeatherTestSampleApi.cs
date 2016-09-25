using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Model;

namespace WeatherTest.Business
{
    public interface IWeatherTestSampleApi
    {
        IWeatherData QueryWeatherData(string location);
    }

}
