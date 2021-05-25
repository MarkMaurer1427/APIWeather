using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIWeather
{
    class CityWeather
    {
        string name;
        string urlC;
        string urlF;
        string tempC;
        string tempF;
        string hum;

        public CityWeather(int id)
        {
            var client = new HttpClient();
            urlC = $"https://api.openweathermap.org/data/2.5/weather?id={id}&appid=9319a57f9c0565bf38f245d8a721f21b&units=metric";
            urlF = $"https://api.openweathermap.org/data/2.5/weather?id={id}&appid=9319a57f9c0565bf38f245d8a721f21b&units=imperial";
            var pingC = client.GetStringAsync(urlC).Result;
            var mainC = JObject.Parse(pingC).GetValue("main").ToString();
            var pingF = client.GetStringAsync(urlF).Result;
            var mainF = JObject.Parse(pingF).GetValue("main").ToString();
            name = JObject.Parse(pingC).GetValue("name").ToString();
            tempC = JObject.Parse(mainC).GetValue("temp").ToString();
            tempF = JObject.Parse(mainF).GetValue("temp").ToString();
            hum = JObject.Parse(mainC).GetValue("humidity").ToString();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"City: {name}");
            Console.WriteLine($"Temp in Celsius: {tempC}");
            Console.WriteLine($"Temp in Fahrenheit: {tempF}");
            Console.WriteLine($"Humidity: {hum}");
        }
    }
}
