using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    public class AddCommand : CommandBase
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _salary;

        public AddCommand(string firstName, string lastName, string salary)
        {
            _firstName = firstName;
            _lastName = lastName;
            _salary = salary;
        }



        public override void Execute()
        {
            EmployeeGenerator employeeGenerator = new EmployeeGenerator();

            var employees = GetJsonObject();
            var newEmployee = employeeGenerator.GetEmployee(_firstName, _lastName, _salary);
            newEmployee.Id = employees.Last().Id + 1;

            employees.Add(newEmployee);
            UpdateJsonObject(employees);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New employee has been successfully added");
            Console.ResetColor();
        }



    }
}

