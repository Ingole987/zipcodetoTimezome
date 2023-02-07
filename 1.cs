using System;
using System.Globalization;

namespace TimeZoneConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: TimeZoneConverter.exe <DateTime> <ZipCode>");
                Console.WriteLine("Example: TimeZoneConverter.exe \"2022-12-25 12:00:00\" 98052");
                return;
            }

            DateTime originalDateTime = DateTime.Parse(args[0], CultureInfo.InvariantCulture);
            string zipCode = args[1];

            TimeZoneInfo timeZone = GetTimeZoneFromZipCode(zipCode);
            DateTime convertedDateTime = TimeZoneInfo.ConvertTime(originalDateTime, TimeZoneInfo.Local, timeZone);

            Console.WriteLine("Original Date and Time: " + originalDateTime);
            Console.WriteLine("Converted Date and Time: " + convertedDateTime);
        }

        static TimeZoneInfo GetTimeZoneFromZipCode(string zipCode)
        {
            // Add logic to look up the time zone based on the zip code
            // For this example, we'll just use a fixed time zone
            return TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        }
    }
}
