using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.Model
{

    public enum WeatherDataSourceSystemType
    {
        CelsiusAndKph,
        FahrenheitAndMph
    }
    /*
        //To extend more units in future, Create another Interface with new units 
        //Then simply implement the interface where needed     
    */
    public interface IWeatherData
    {
        string Location { get; set; }
        double Temperature { get; set; }
        double Windspeed { get; set; }
        WeatherDataSourceSystemType WeatherDataSourceSystemType { get; set; }
        double GetTempInFahrenheit();
        double GetTempInCelsius();
        double GetWindSpeedInMph();
        double GetWindSpeedInKph();
    }
}
