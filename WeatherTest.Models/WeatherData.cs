using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Models
{
    public class WeatherData : IWeatherData
    {
        private string _location;
        private double _temperature;
        private double _windSpeed;
        private WeatherDataSourceSystemType _weatherDataSourceSystemType;

        public WeatherData(WeatherDataSourceSystemType weatherSystemType = WeatherDataSourceSystemType.CelsiusAndKph)
        {
            _weatherDataSourceSystemType = weatherSystemType;   
        }
        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
            }
        }

        public WeatherDataSourceSystemType WeatherDataSourceSystemType
        {
            get
            {
                return _weatherDataSourceSystemType;
            }
            set
            {
                _weatherDataSourceSystemType = value;
            }
        }

        public double Windspeed
        {
            get
            {
                return _windSpeed;
            }
            set
            {
                _windSpeed = value;
            }
        }


        public virtual double GetTempInFahrenheit()
        {
            return (_temperature * 1.8) + 32;
        }

        public virtual double GetTempInCelsius()
        {
            return _temperature;
        }

        public virtual double GetWindSpeedInMph()
        {
            return _windSpeed * 1.6;
        }

        public virtual double GetWindSpeedInKph()
        {
            return _windSpeed;
        }
    }
}
