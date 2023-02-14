using System;
using TimeZoneDB;

namespace TimeZoneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "New York";
            string state = "New York";
            string country = "USA";
            string timeZone = TZDBCache.GetTimeZone(city, state, country).TimeZoneId;
            Console.WriteLine("The time zone for " + city + "," + state + "," + country + " is " + timeZone);
            Console.ReadLine();
        }
    }
}



using System;
using System.IO;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening to Postman calls at http://localhost:8080/");
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                string responseString = "Hello World!";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                HttpListenerResponse response = context.Response;
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}

static string GetResponseString(HttpListenerRequest request)
{
    List<string> infoList = new List<string>();
    infoList.Add($"Request URL: {request.Url}");
    infoList.Add($"Request Method: {request.HttpMethod}");
    infoList.Add($"Request Headers: {request.Headers}");
    infoList.Add($"Request Content Type: {request.ContentType}");

    string responseString = string.Join(Environment.NewLine, infoList);
    return responseString;
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening to Postman calls at http://localhost:8080/");
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                string responseString = GetResponseString(request);
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                HttpListenerResponse response = context.Response;
                response.ContentLength64 = buffer.Length;
                response.ContentType = "application/json";
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }

        static string GetResponseString(HttpListenerRequest request)
        {
            var info = new Dictionary<string, string>();
            info.Add("Request URL", request.Url.ToString());
            info.Add("Request Method", request.HttpMethod);
            info.Add("Request Headers", request.Headers.ToString());
            info.Add("Request Content Type", request.ContentType);

            string json = JsonConvert.SerializeObject(info, Formatting.Indented);
            return json;
        }
    }
}
