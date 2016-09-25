using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherTest.Model;
using WeatherTest.Business;
using WeatherTest.SampleWebsite.ViewModels;

namespace WeatherTest.SampleWebsite.Controllers
{
    public class HomeController : Controller
    {
        private WeatherData aggregatedData;
        private IWeatherTestAPIService _weatherTestAPIService;

        public HomeController(IWeatherTestAPIService weatherTestAPIService)
        {
            _weatherTestAPIService = weatherTestAPIService;
        }

        public IActionResult Index()
        {
            //Improvements:
            //The Weather Data could be cached on the client side
            //to avoid unnecessary API calls in scenarios where the user simply
            //wants to view results in different units
            return View();
        }

        [HttpPost]
        public IActionResult QueryWeatherData(HomeViewModel model)//, string Location ="london")
        {
            var data = _weatherTestAPIService.QueryLiveWeatherData(model.Location);
            
            var viewModel = new HomeViewModel()//Could use AutoMapper here
            {
                Location = data.Location,
                Temperature= Math.Round(data.Temperature,1),
                Windspeed= Math.Round(data.Windspeed,1),
                TemperatureDisplayUnits = model.TemperatureDisplayUnits,
                WindSpeedDislayUnits = model.WindSpeedDislayUnits
            };
            //By design, Temperature is in Celsius and WindSpeed in Kph (metric system)
            //Check the user specified units and convert measurement in correct units
            if (model.TemperatureDisplayUnits == TemperatureDisplayUnits.Fahareinheit)
            {
                viewModel.Temperature = Math.Round(data.GetTempInFahrenheit(),1);
            }
            if(model.WindSpeedDislayUnits == WindSpeedDislayUnits.Mph)
            {
                viewModel.Windspeed = Math.Round(data.GetWindSpeedInMph(),1);
            }

            return View("Index", viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "WeatherTest technical test attempt by Julius Angwenyi";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
