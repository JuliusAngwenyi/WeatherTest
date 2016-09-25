using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Models
{
    public class BbcWeatherData : WeatherData
    {
        BbcWeatherData():base(WeatherDataSourceSystemType.CelsiusAndKph)
        {
        }

        public override double GetTempInFahrenheit()
        {
          return  (Temperature * 1.8) + 32;
        }

        public override double GetTempInCelsius()
        {
            return Temperature;
        }

        public override double GetWindSpeedInMph()
        {
            return Windspeed * 1.6;
        }

        public override double GetWindSpeedInKph()
        {
            return Windspeed;
        }
    }
}
