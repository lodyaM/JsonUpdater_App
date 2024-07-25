using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class GetAllCommand : CommandBase
    {
        public override void Execute()
        {
            var employees = GetJsonObject();
            foreach (var employee in employees)
            {
                string info = $"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, SalaryPerHour = {employee.Salary}";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(info);
                Console.ResetColor();
            }
        }
    }
}
