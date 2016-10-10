using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTest.SampleWebsite.ViewModels
{
    public enum TemperatureDisplayUnits
    {
        Celsius,
        Fahreinheit
    }
    public enum WindSpeedDislayUnits
    {
        Kph,
        Mph
    }
    /*
    public interface IHomeViewModel
    {
        string Location { get; set; }
        double Temperature { get; set; }
        double Windspeed { get; set; }
        TemperatureDisplayUnits TemperatureDisplayUnits { get; set; }
        WindSpeedDislayUnits WindSpeedDislayUnits { get; set; }

    }*/

    public class HomeViewModel //: IHomeViewModel
    {
        public HomeViewModel()
        {

        }
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Windspeed { get; set; }
        public TemperatureDisplayUnits TemperatureDisplayUnits { get; set; }
        public WindSpeedDislayUnits WindSpeedDislayUnits { get; set; }
    }
}
