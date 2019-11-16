using Babat_Taxi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Services
{
    public static class JsonWriter
    {
        public static void WriteToFile(List<Account> Accounts)
        {
            JsonSerializer ser = new JsonSerializer();
            using (var sw = new StreamWriter(@"dataBase.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    ser.Serialize(jw, Accounts);
                }
            }

        }

    }


    public static class JsonReader
    {
        public static List<Account> ReadFromFile(List<Account> Accounts)
        {
            if (File.Exists(@"dataBase.json"))
            {
                var ser = new JsonSerializer();
                using (var sw = new StreamReader(@"dataBase.json"))
                {
                    using (var jr = new JsonTextReader(sw))
                    {
                        return Accounts = ser.Deserialize<List<Account>>(jr);
                    }
                }
            }
            else
            {
                return new List<Account>();
            }
        }
    }
}
