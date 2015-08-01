using Newtonsoft.Json; //in console - Install-Package Newtonsoft.Json
using Newtonsoft.Json.Linq; //Contained in System.Web.Extensions assembly
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JavaScriptSerializerDemo
{
    class JavaScriptSerializerDemo
    {
        static void Main()
        {
            var digits = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            var serializer = new JavaScriptSerializer();
            var digitsInJson = serializer.Serialize(digits);
            Console.WriteLine("Serialize:\n{0}", digitsInJson);

            var digitsDeserialized = serializer.Deserialize<Dictionary<string, int>>(digitsInJson);
            Console.WriteLine("Deserialize:");
            foreach (var pair in digitsDeserialized)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            //-----JSON.NET----------//
            var jsonFormatting = JsonConvert.SerializeObject(digits, Formatting.Indented);
            Console.WriteLine("formatting: {0}\n", jsonFormatting);

            var json =
                @"{
                  'firstName': 'Vladimir',
                  'lastName': 'Georgiev',
                  'jobTitle': 'Technical Trainer'
                }";

            var template = new
            {
                FirstName = string.Empty,
                Lastname = string.Empty,
                JobTitle = string.Empty
            };

            var person = JsonConvert.DeserializeAnonymousType(json, template);
            Console.WriteLine(person);

            //-----LINQ to JSON---------//
            var jsonObj = JObject.Parse(json);
            Console.WriteLine("\nFirst name: {0}", jsonObj["firstName"]);
        }
    }
}
