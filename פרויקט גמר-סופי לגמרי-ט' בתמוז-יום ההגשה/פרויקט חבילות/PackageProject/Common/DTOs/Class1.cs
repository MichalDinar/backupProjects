using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace Common.DTOs

{
    public class Class1
    {
        private const string ApiKeyLocation = "AIzaSyDAcuDzOKKt2Jjrx2thfncOik5s9QjRWbQ";

        public static Tuple<double, double> GetLocation1(string address)
        {
            //string apiKey = ApiKey;
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={WebUtility.UrlEncode(address)}&key={ApiKeyLocation}";

            using (var webClient = new WebClient())
            {
                string json = webClient.DownloadString(url);
                var result = JObject.Parse(json);

                if (result["status"].ToString() == "OK")
                {
                    var location = result["results"][0]["geometry"]["location"];
                    double lat = (double)location["lat"];
                    double lng = (double)location["lng"];
                    return Tuple.Create(lat, lng);
                }
                else
                {
                    throw new Exception("Failed to get location.");
                }
            }
        }
    }
}
