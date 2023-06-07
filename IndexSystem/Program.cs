using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;


namespace IndexSystem
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string fullPath = Path.Combine("..", "..", "..", "U16A2Task2Data.csv");
            string destinationPath = Path.Combine("..", "..", "..", "U16A2DataSorted.csv");

            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<BookMap>();

                List<BookTwo> csvRecords = new List<BookTwo>();

                // Read each record and store it in the list
                while (await csv.ReadAsync())
                {
                    var record = csv.GetRecord<BookTwo>();
                    record.Hash = Utils.GetShortHash(record.GetHashCode());
                    csvRecords.Add(record);                   
                }

                Utils.CheckIfExists(destinationPath);

                // Write the records to the destination file
                using (var writer = new StreamWriter(destinationPath))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
;

                    csvWriter.Context.RegisterClassMap<BookTwoMap>();

                    
                    //await csvWriter.NextRecordAsync();

                    foreach (var record in csvRecords)
                    {
                        csvWriter.WriteRecord(record);
                        await csvWriter.NextRecordAsync();
                    }
                }
            }

            Console.WriteLine(fullPath);
            Console.WriteLine(File.Exists(fullPath));

            // Print the content of the destination file
            string[] lines = File.ReadAllLines(destinationPath);
            Console.WriteLine("Content of the destination file:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }


    }
}
