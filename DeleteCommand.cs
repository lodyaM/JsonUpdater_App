using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class DeleteCommand : CommandBase
    {
        private readonly string _id;

        public DeleteCommand(string id)
        {
            _id = id;
        }
        public override void Execute()
        {
            EmployeeGenerator employeeGenerator = new EmployeeGenerator();
            int idValue = employeeGenerator.GetIdValue(_id);
            var employees = GetJsonObject();
            bool isIdDeleted = false;
            foreach (EmployeeContent employee in employees)
            {
                if (employee.Id == idValue)
                {
                    employees.Remove(employee);
                    UpdateJsonObject(employees);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee removed");
                    Console.ResetColor();
                    isIdDeleted = true;
                    break;
                }
                
            }
            if (!isIdDeleted)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee not found");
                Console.ResetColor();
            }

        }
    }
}
