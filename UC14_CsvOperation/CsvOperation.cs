using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC14_CsvOperation
{
    class CsvOperation
    {
        public static void CSVOperation(Dictionary<string, List<AddrBook>> addressbooknames)
        {
            //Store Csv File path in a string
            string csvFilePath = @"C:\Users\DEEPAK\OneDrive\Desktop\RFP _.NET Fellowship - 142\Address_Book_System\Addressbook\UC14_CsvOperation\CsvData.csv";
            File.WriteAllText(csvFilePath, string.Empty);
            //Iterate over Dictionary Values
            foreach (KeyValuePair<string, List<AddrBook>> kvp in addressbooknames)
            {
                //Open file in Append Mode for adding List elements
                using var stream = File.Open(csvFilePath, FileMode.Append);
                using var writer = new StreamWriter(stream);
                using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                //Iterate over each value
                foreach (var value in kvp.Value)
                {
                    //Create List to add Records
                    List<AddrBook> list = new List<AddrBook>();
                    list.Add(value);
                    //Write List to CSV File
                    csvWriter.WriteRecords(list);
                }
                //Print a newline
                csvWriter.NextRecord();
            }
            //Reading a Csv File
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Get all records from Csv File
                var records = csv.GetRecords<AddrBook>().ToList();

                foreach (AddrBook member in records)
                {
                    //To skip Headers in Csv File
                    if (member.firstName == "firstName")
                    {
                        Console.WriteLine("\n");
                        continue;
                    }
                    //Convert each Value to string and Print to Console
                    Console.WriteLine(member.ToString());
                }

            }
        }
    }
}
