using BookLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Helpers
{
    internal class FileHelper
    {

        public static void WriteRents(List<RentCodeGenerator> rents, string fileName)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("rents.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, rents);
                }
            }
        }

        public static ObservableCollection<RentCodeGenerator> ReadRents(string fileName)
        {
            ObservableCollection<RentCodeGenerator> rents = null;
            var base_subscribers = new ObservableCollection<RentCodeGenerator>();
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{fileName}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    rents = serializer.Deserialize<ObservableCollection<RentCodeGenerator>>(jr);
                }
            }

            return rents;
        }
    }
}
