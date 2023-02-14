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

