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
