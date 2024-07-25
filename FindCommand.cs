using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class FindCommand : CommandBase
    {
        private readonly string _id;

        public FindCommand(string id)
        {
            _id = id;
        }
        public override void Execute()
        {
            EmployeeGenerator emlpoyeeGenerator = new EmployeeGenerator();
            var employees = GetJsonObject();
            bool isEmployeeFound = false;
            foreach (EmployeeContent employee in employees)
            {
                if (employee.Id == emlpoyeeGenerator.GetIdValue(_id))
                {
                    string info = $"Id = {employee.Id}, FirstName = {employee.FirstName}, LastName = {employee.LastName}, SalaryPerHour = {employee.Salary}";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(info);
                    Console.ResetColor();
                    isEmployeeFound = true;
                    break;
                }
                

            }
            if (!isEmployeeFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id not found");
            }
        }
    }
}
