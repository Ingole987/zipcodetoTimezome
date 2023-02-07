using System;
using System.Data;
using System.Data.SqlClient;

namespace DateTimeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: DateTimeConverter [date and time] [zip code]");
                return;
            }

            DateTime originalDateTime = DateTime.Parse(args[0]);
            string zipCode = args[1];

            string timeZoneId = GetTimeZoneIdFromZipCode(zipCode);
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            DateTime convertedDateTime = TimeZoneInfo.ConvertTime(originalDateTime, TimeZoneInfo.Local, timeZone);

            Console.WriteLine("The converted date and time is: " + convertedDateTime);
        }

        static string GetTimeZoneIdFromZipCode(string zipCode)
        {
            string timeZoneId = "";

            // Replace "connection_string" with the actual connection string to your database
            using (SqlConnection connection = new SqlConnection("connection_string"))
            {
                connection.Open();

                // Replace "time_zone_table" with the actual table name that maps zip codes to time zones
                SqlCommand command = new SqlCommand("SELECT time_zone_id FROM time_zone_table WHERE zip_code = @zip_code", connection);
                command.Parameters.AddWithValue("@zip_code", zipCode);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    timeZoneId = reader.GetString(0);
                }

                reader.Close();
            }

            return timeZoneId;
        }
    }
}
