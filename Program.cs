using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace APIWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var SATX = new CityWeather(4726206);
            SATX.PrintInfo();

            Console.WriteLine();

            var Birmingham = new CityWeather(4049979);
            Birmingham.PrintInfo();







        }
    }
}
