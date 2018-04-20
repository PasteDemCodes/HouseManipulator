using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testtest
{
    public class WeatherInfo
    {
        // Piraeus lat - lon
        public string lat = "51.5085";
        public string lon = "-0.1258";
        private string APIKEY = "6fb45b570be8513bc249f591e5ab99f5";

        public string urlBuilder()
        {

            return ("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&&lon=" + lon + "&&appid=" + APIKEY);

        }

        public String getTemperature(OpenWeatherMap.Root obj)
        {

            return Math.Round(obj.main.temp - 273.15).ToString();


        }


        public String getPictureUrl(OpenWeatherMap.Root obj)
        {

            return ("http://openweathermap.org/img/w/" + obj.weather.ElementAt(0).icon + ".png");

        }
        public String getWeatherCondition(OpenWeatherMap.Root obj)
        {

            return (obj.weather.ElementAt(0).description.ToString());

        }



    }   // class ends here.
}
