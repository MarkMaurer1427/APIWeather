using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIWeather
{
    class CityWeather
    {
        string cityName;
        string urlC;
        string urlF;
        string tempC;
        string tempF;
        string hum;

        public CityWeather(string name, string id, string key)
        {
            string apikey = key;
            var client = new HttpClient();
            urlC = $"https://api.openweathermap.org/data/2.5/weather?id={id}&appid={apikey}&units=metric";
            urlF = $"https://api.openweathermap.org/data/2.5/weather?id={id}&appid={apikey}&units=imperial";
            var pingC = client.GetStringAsync(urlC).Result;
            var mainC = JObject.Parse(pingC).GetValue("main").ToString();
            var pingF = client.GetStringAsync(urlF).Result;
            var mainF = JObject.Parse(pingF).GetValue("main").ToString();
            cityName = name;
            tempC = JObject.Parse(mainC).GetValue("temp").ToString();
            tempF = JObject.Parse(mainF).GetValue("temp").ToString();
            hum = JObject.Parse(mainC).GetValue("humidity").ToString();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"City: {cityName}");
            Console.WriteLine($"Temp in Celsius: {tempC}");
            Console.WriteLine($"Temp in Fahrenheit: {tempF}");
            Console.WriteLine($"Humidity: {hum}");
        }
    }
}
