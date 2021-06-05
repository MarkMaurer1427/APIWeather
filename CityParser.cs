using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIWeather
{
    class CityParser
    {
        string apikey;
        public CityParser(string key)
        {
            apikey = key;
        }

        public void ParseObjects(JObject obj)
        {
            JToken cities = obj["CityID"];
            foreach (JToken o in cities)
            { 
                string name = o["name"].ToString();
                string id = o["id"].ToString();
                GetEntry(name, id, apikey);
            }
        }
        public void GetEntry(string name, string id, string key)
        {
            var item = new CityWeather(name, id, apikey);
            item.PrintInfo();
            Console.WriteLine();
        }
    }
}
