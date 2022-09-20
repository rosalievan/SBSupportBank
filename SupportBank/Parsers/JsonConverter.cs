using CsvHelper; // install CSV helper
using Newtonsoft.Json; // install Newtonsoft.JSON NuGet Package
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace SupportBank.Parsers
{
    class JsonConverter
    {
        // public static void Convert(string source)
        // {

        //     // var json = JsonConvert.DeserializeObject<List<Transaction>>(@$"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\{source}");

        //     string jsonString = JsonSerializer.Serialize(@$"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\{source}");

        //     JsonToCsvFunction(json);

        // }

        // public static string JsonToCsvFunction(string jsonContent)
        // {
        //     var expandos = JsonConvert.DeserializeObject<ExpandoObject[]>(jsonContent);

        //     using (TextWriter writer = new StreamWriter(@"C:\Users\rvano\OneDrive\Desktop\SB\SupportBank\SupportBank\sample.csv"))
        //     {
        //         using (var csv = new CsvWriter(writer,System.Globalization.CultureInfo.CurrentCulture))
        //         {
        //             csv.WriteRecords((expandos as IEnumerable<dynamic>));
        //         }

        //         return writer.ToString();
        //     }
        // }
    }
}