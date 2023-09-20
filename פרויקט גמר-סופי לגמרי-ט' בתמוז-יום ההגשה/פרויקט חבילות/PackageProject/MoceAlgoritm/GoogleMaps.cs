using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using Common.DTOs;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;



namespace Algoritm
{
    public class Distance
    {
        public double Value { get; set; }
        public string Text { get; set; }
    }

    public class Element
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public string Status { get; set; }
    }

    
    public class Duration
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }


    public class Row
    {
        public Element[] Elements { get; set; }
    }

    public class DistanceMatrixApiResponse
    {
        public Row[] Rows { get; set; }
    }

    public enum Type{ time,kilometer }
    public class MyGoogleMapsApi
    {
        private const string baseUrl = "https://maps.googleapis.com/maps/api/distancematrix/json?";
        private const string ApiKey = "AIzaSyDAQtQkkmkI14Brtq_59WKrxuzcoE7FSzk";
        private const string ApiKeyLocation = "AIzaSyDAcuDzOKKt2Jjrx2thfncOik5s9QjRWbQ";


        //פונקציה שמחזירה רק זמן
        public static TimeSpan GetDrivingDistanceTime(string origin, string destination)
        {
            //פונקציה טובה-רק עשיתי דמה בינתים
            //TimeSpan result = new TimeSpan();
            //string apiKey = ApiKey;
            //var url = $"{baseUrl}origins={origin}&destinations={destination}&mode=driving&key={apiKey}";
            //var request = WebRequest.Create(url);
            //var response = request.GetResponse();
            //var stream = response.GetResponseStream();
            //var reader = new StreamReader(stream);
            //var json = reader.ReadToEnd();
            //var data = JsonConvert.DeserializeObject<DistanceMatrixApiResponse>(json);

            //if (data.Rows.Length == 0 || data.Rows[0].Elements.Length == 0)
            //{
            //    throw new Exception("No data found for the specified origin and destination.");
            //}

            //var durationSeconds = data.Rows[0].Elements[0].Duration.Value;
            //var durationText = data.Rows[0].Elements[0].Duration.Text;
            //var duration = new Duration { Value = durationSeconds, Text = durationText };
            //result = ParseStringToTimeOnly(duration.Text);

            //return result;
            Random random = new Random();
            return new TimeSpan(random.Next(1), random.Next(20, 59), 0);
        }

        private static TimeSpan ParseStringToTimeOnly(string text)
        {
            // "? hours ?? mins"
            // "?? mins"
            // "? min"
            int hours;
            int minutes;
            if (text.Last() != 's') //במקרה שהמרחק הוא דקה אחת
                return new TimeSpan(0, 1, 0);
            else
            {

                if (text[2] == 'h')
                {
                    hours = int.Parse(text[0].ToString());
                    if (text.Length == 15)
                        minutes = int.Parse(text.Substring(8, 2));
                    else
                        minutes = int.Parse(text.Substring(8, 1));
                }
                else
                {
                    hours = 0;
                    if (text.Length == 7)
                        minutes = int.Parse(text.Substring(0, 2));
                    else
                        minutes = int.Parse(text.Substring(0, 1));
                }
            }
            return new TimeSpan(hours, minutes, 0);
        }

        
        
        public static Tuple<double, double> GetLocation(string address)
        {
            string apiKey = ApiKey;
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
        //public static int googleMapsDistance(CollectingPointDto c1, CollectingPointDto c2, int[,] Distanses)
        //{
        //    return Distanses[c1.CollectingPointId, c2.CollectingPointId];
        //}
        //public static DistanceType googleMapsDistance(string origin, string destination)
        //{
        //    //return moce.weights[(int)c1.Value.LocationX, (int)c2.Value.LocationX];
        //    //צריך או להוסיף כתובת לנקודת איסוף או לבדוק אם אפשר לקבל מיקום במקום כתובת

        //    var result = MyGoogleMapsApi.GetDrivingDistance(origin, destination);

        //    return result;
        //}

        // פונקציה שמקבלת שתי נקודות ומחזירה את משך הזמן לנסיעה ביניהן במצב נהיגה
        //public static Duration GetDrivingDurationSecond(string origin, string destination, string apiKey)
        //{
        //    // יצירת כתובת ה-URL לבצע בקשת HTTP GET ל-API של Google Maps
        //    var url = $"{baseUrl}origins={origin}&destinations={destination}&mode=driving&key={apiKey}";

        //    // בקשת HTTP GET ל-API של Google Maps
        //    var request = WebRequest.Create(url);
        //    var response = request.GetResponse();
        //    var stream = response.GetResponseStream();
        //    var reader = new StreamReader(stream);

        //    // קריאת התגובה כטקסט והמרתה למופע של המחלקה DistanceMatrixApiR esponse
        //    var json = reader.ReadToEnd();
        //    var data = JsonConvert.DeserializeObject<DistanceMatrixApiResponse>(json);

        //    if (data.Rows.Length == 0 || data.Rows[0].Elements.Length == 0)
        //    {
        //        throw new Exception("No data found for the specified origin and destination.");
        //    }

        //    // החזרת משך הזמן לנסיעה במצב נהיגה
        //    var durationSeconds = data.Rows[0].Elements[0].Duration.Value;
        //    var durationText = data.Rows[0].Elements[0].Duration.Text;
        //    var duration = new Duration { Value = durationSeconds, Text = durationText };
        //    return duration;
        //}
        //public static Distance GetDrivingDistanceKM(string origin, string destination, string apiKey)
        //{
        //    var url = $"{baseUrl}origins={origin}&destinations={destination}&mode=driving&key={apiKey}";
        //    var request = WebRequest.Create(url);
        //    var response = request.GetResponse();
        //    var stream = response.GetResponseStream();
        //    var reader = new StreamReader(stream);
        //    var json = reader.ReadToEnd();
        //    var data = JsonConvert.DeserializeObject<DistanceMatrixApiResponse>(json);

        //    if (data.Rows.Length == 0 || data.Rows[0].Elements.Length == 0)
        //    {
        //        throw new Exception("No data found for the specified origin and destination.");
        //    }

        //    var distanceMeters = data.Rows[0].Elements[0].Distance.Value;
        //    var distanceKm = distanceMeters / 1000.0;
        //    var distance = new Distance { Value = distanceKm, Text = $"{distanceKm:F2} km" };
        //    return distance;
        //}
        //הפונקציה שמשתמשים בפרויקט-לא בטוח
        //פונקציה שמחזירה מרחק וזמן
        //public static DistanceType GetDrivingDistance(string origin, string destination)
        //{
        //    DistanceType result = new DistanceType();
        //    string apiKey = ApiKey;
        //    var url = $"{baseUrl}origins={origin}&destinations={destination}&mode=driving&key={apiKey}";
        //    var request = WebRequest.Create(url);
        //    var response = request.GetResponse();
        //    var stream = response.GetResponseStream();
        //    var reader = new StreamReader(stream);
        //    var json = reader.ReadToEnd();
        //    var data = JsonConvert.DeserializeObject<DistanceMatrixApiResponse>(json);

        //    if (data.Rows.Length == 0 || data.Rows[0].Elements.Length == 0)
        //    {
        //        throw new Exception("No data found for the specified origin and destination.");
        //    }

        //    var distanceMeters = data.Rows[0].Elements[0].Distance.Value;
        //    var distanceKm = distanceMeters / 1000.0;
        //    var distance = new Distance { Value = distanceKm, Text = $"{distanceKm:F2}" };
        //    result.kilometer = float.Parse(distance.Text);

        //    var durationSeconds = data.Rows[0].Elements[0].Duration.Value;
        //    var durationText = data.Rows[0].Elements[0].Duration.Text;
        //    var duration = new Duration { Value = durationSeconds, Text = durationText };
        //    result.time = ParseStringToTimeOnly(duration.Text);

        //    return result;
        //}

        //public static Tuple<double, double> GetLocation1(string address)
        //{
        //    // Replace YOUR_API_KEY with your actual Google Maps API key



        //    string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={WebUtility.UrlEncode(address)}&key={ApiKeyLocation}";

        //    using (var webClient = new WebClient())
        //    {
        //        string json = webClient.DownloadString(url);
        //        var result = JObject.Parse(json);

        //        if (result["status"].ToString() == "OK")
        //        {
        //            var location = result["results"][0]["geometry"]["location"];
        //            double lat = (double)location["lat"];
        //            double lng = (double)location["lng"];
        //            return Tuple.Create(lat, lng);
        //        }
        //        else
        //        {
        //            throw new Exception("Failed to get location.");
        //        }
        //    }
        //}

    }
}
