using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Models
{
    
    public class AccuWeatherData:WeatherData
    {
        AccuWeatherData():base(WeatherDataSourceSystemType.FahrenheitAndMph)
        {
        }


        public override double GetTempInFahrenheit()
        {
            return Temperature;
        }

        public override double GetTempInCelsius()
        {
            return (Temperature - 32) * 0.5556;
        }

        public override double GetWindSpeedInMph()
        {
            return Windspeed;
        }

        public override double GetWindSpeedInKph()
        {
            return Windspeed/1.6;
        }
    }
}
