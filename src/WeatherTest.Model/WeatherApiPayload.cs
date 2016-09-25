using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.Model
{
    public class WeatherApiPayload
    {
        public string Location { get; set; }
        public string Where { get; set; }
        public double? TemperatureFahrenheit { get; set; }
        public double? TemperatureCelsius { get; set; }
        public double? WindSpeedMph { get; set; }
        public double? WindSpeedKph { get; set; }

    }
}
