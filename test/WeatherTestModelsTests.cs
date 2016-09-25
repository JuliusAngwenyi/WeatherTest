using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTest.Model;
using Xunit;

namespace WeatherTests
{
    public class WeatherTestModelsTests
    {
        [Fact]
        public void ParentWeatherDataClassHasCelsiusAndKph()
        {
            //Arrange
            var sut = new WeatherData();
            //Act
            //Assert
            Assert.Equal( WeatherDataSourceSystemType.CelsiusAndKph, sut.WeatherDataSourceSystemType);
        }

        [Fact]
        public void BbcWeatherDataSubClassHasCelsiusAndKph()
        {
            //Arrange
            var sut = new BbcWeatherData();
            //Act
            //Assert
            Assert.Equal( WeatherDataSourceSystemType.CelsiusAndKph, sut.WeatherDataSourceSystemType);
        }

        [Fact]
        public void BbcWeather10CelsiusReturns50Fahrenheit()
        {
            //Arrange
            var sut = new BbcWeatherData();
            //Act
            sut.Temperature = 10;//Celsius
            var result = Math.Round(sut.GetTempInFahrenheit(), 0);
            //Assert
            Assert.Equal(50,result);
            Assert.Equal(10, sut.GetTempInCelsius());
        }

        [Fact]
        public void BbcWeather10KphReturns6_2Mph()
        {
            //Arrange
            var sut = new BbcWeatherData();
            //Act
            sut.Windspeed = 10;//Kph
            var result = Math.Round(sut.GetWindSpeedInMph(), 1);
            //Assert
            Assert.Equal(6.2,result );
            Assert.Equal(10, sut.GetWindSpeedInKph());
        }


        [Fact]
        public void AccuWeatherDataSubClassHasFahrenheitAndMph()
        {
            //Arrange
            var sut = new AccuWeatherData();
            //Act
            //Assert
            Assert.Equal(sut.WeatherDataSourceSystemType, WeatherDataSourceSystemType.FahrenheitAndMph);
        }

        [Fact]
        public void AccuWeather50FahrenheitReturns10Celsius()
        {
            //Arrange
            var sut = new AccuWeatherData();
            //Act
            sut.Temperature = 50;//Fahrenheit
            var result = Math.Round(sut.GetTempInCelsius(), 0);
            //Assert
            Assert.Equal(10, result);
            Assert.Equal(50, sut.GetTempInFahrenheit());
        }

        [Fact]
        public void BbcWeather7_5MphReturns12_075Kph()
        {
            //Arrange
            var sut = new AccuWeatherData();
            //Act
            sut.Windspeed = 7.5;//Mph
            var result = Math.Round(sut.GetWindSpeedInKph(),0);
            //Assert
            Assert.Equal(12, result);
            Assert.Equal(7.5, sut.GetWindSpeedInMph());
        }

    }
}
