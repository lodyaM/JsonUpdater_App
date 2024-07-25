using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    public abstract class CommandBase
    {
        private static string filePath = @"..\..\..\employees.json";
        public string file = File.ReadAllText(filePath);

        private protected List<EmployeeContent> GetJsonObject()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<EmployeeContent>>(file);

            }
            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
        private protected void UpdateJsonObject(List<EmployeeContent> employees)
        {
            var jsonObject = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(filePath, jsonObject);
        }

        public abstract void Execute();
    }
}
