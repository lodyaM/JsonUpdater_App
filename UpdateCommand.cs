using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class UpdateCommand : CommandBase
    {
        private readonly string _id;
        private readonly string _firstName;

        public UpdateCommand(string id, string firstName)
        {
            _id = id;
            _firstName = firstName;
        }

        public override void Execute()
        {
            var employeeGenerator = new EmployeeGenerator();
            var newEmployee = employeeGenerator.GetEmployee(_id, _firstName);
            
            var employees = GetJsonObject();
            bool isIdExist = false;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == newEmployee.Id)
                {
                    employees[i].FirstName = newEmployee.FirstName;
                    isIdExist = true;
                    break;
                }
            }
            if (isIdExist)
            {


                UpdateJsonObject(employees);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee has been successfully updated");
                Console.ResetColor();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input id does not exist");
                Console.ResetColor();
            }


        }
    }
}
