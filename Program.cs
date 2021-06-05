using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;

namespace APIWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject o1 = JObject.Parse(File.ReadAllText(@"apikey.json"));
            JObject o2 = JObject.Parse(File.ReadAllText(@"cityIDs.json"));

            string key = o1["apikey"].ToString();
            var parser = new CityParser(key);
            parser.ParseObjects(o2);








        }
    }
}
