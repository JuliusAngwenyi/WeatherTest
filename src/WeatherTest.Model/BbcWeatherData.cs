using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Model
{
    public class BbcWeatherData : WeatherData
    {
        public BbcWeatherData():base(WeatherDataSourceSystemType.CelsiusAndKph)
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
            return Windspeed * 0.62;
        }

        public override double GetWindSpeedInKph()
        {
            return Windspeed;
        }
    }
}
