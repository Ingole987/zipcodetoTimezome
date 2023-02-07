class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the input CSV file: ");
            string inputFilePath = Console.ReadLine();

            Console.WriteLine("Enter the path to the output CSV file: ");
            string outputFilePath = Console.ReadLine();

            DataTable inputData = ReadCSV(inputFilePath);
            DataTable outputData = ConvertDateTime(inputData);
            WriteCSV(outputData, outputFilePath);

            Console.WriteLine("The conversion is complete. The output file is located at " + outputFilePath);
        }

        static DataTable ReadCSV(string filePath)
        {
            DataTable data = new DataTable();
            data.Columns.Add("DateTime", typeof(DateTime));
            data.Columns.Add("ZipCode", typeof(string));

            using (StreamReader reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine();
                string[] header = headerLine.Split(',');

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    DataRow row = data.NewRow();
                    row["DateTime"] = DateTime.Parse(values[0]);
                    row["ZipCode"] = values[1];
                    data.Rows.Add(row);
                }
            }

            return data;
        }

        static DataTable ConvertDateTime(DataTable data)
        {
            DataTable outputData = data.Clone();
            outputData.Columns.Add("ConvertedDateTime", typeof(DateTime));

            foreach (DataRow row in data.Rows)
            {
                string zipCode = (string)row["ZipCode"];
                string timeZoneId = GetTimeZoneIdFromZipCode(zipCode);
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

                DateTime originalDateTime = (DateTime)row["DateTime"];
                DateTime convertedDateTime = TimeZoneInfo.ConvertTime(originalDateTime, TimeZoneInfo.Local, timeZone, TimeZoneInfo.Local.GetAdjustmentRules());

                DataRow newRow = outputData.NewRow();
                newRow["DateTime"] = originalDateTime;
                newRow["ZipCode"] = zipCode;
                newRow["ConvertedDateTime"] = convertedDateTime;
                outputData.Rows.Add(newRow);
            }

            return outputData;
        }

        static void WriteCSV(DataTable data, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string headerLine = "DateTime,ZipCode,ConvertedDateTime";
                writer.WriteLine(headerLine);

                foreach (DataRow row in data.Rows)
                {
                    string line = $"{row["DateTime"]},{row["ZipCode"]},{row["ConvertedDateTime"]}";
                    writer.WriteLine(line);
                }
            }
        }

        static string GetTimeZoneIdFromZipCode(
