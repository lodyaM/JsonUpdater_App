using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class EmployeeGenerator
    {
        private static string _idPattern = @"Id: ?(\d+)";
        private static string _firstNamePattern = @"FirstName:([A-Z][a-z]+)";
        private static string _lastNamePattern = @"LastName:([A-Z][a-z]+)";
        private static string _salaryPattern = @"Salary: ?(\d+(\.\d{2})?)";

        private static Regex _idRegex = new Regex(_idPattern);
        private static Regex _firstNameRegex = new Regex(_firstNamePattern);
        private static Regex _lastNameRegex = new Regex(_lastNamePattern);
        private static Regex _salaryRegex = new Regex(_salaryPattern);

        public int GetIdValue(string id)
        {

            Match matchId = _idRegex.Match(id);


            if (matchId.Success)
            {
                return int.Parse(matchId.Groups[1].Value);

            }
            else
            {
                Console.WriteLine("Input incorrect");
                Environment.Exit(1);
                return -1;
            }


        }
        public EmployeeContent GetEmployee(string id, string firstName)
        {

            Match matchId = _idRegex.Match(id);
            Match matchFirstName = _firstNameRegex.Match(firstName);

            if (matchFirstName.Success && matchId.Success)
            {
                EmployeeContent employee = new EmployeeContent
                {
                    Id = int.Parse(matchId.Groups[1].Value),
                    FirstName = matchFirstName.Groups[1].Value,
                    
                };
                return employee;
            }
            else
            {
                Console.WriteLine("Input incorrect");
                Environment.Exit(1);
                return null;
            }

        }
        public EmployeeContent GetEmployee(string firstName, string lastName, string salary)
        {

            Match matchFirstName = _firstNameRegex.Match(firstName);
            Match matchLastName = _lastNameRegex.Match(lastName);
            Match matchSalary = _salaryRegex.Match(salary);

            

            if (matchFirstName.Success && matchLastName.Success && matchSalary.Success)
            {

                string salaryValue = matchSalary.Groups[1].Value;
                if (salaryValue.Contains('.'))
                {
                    salaryValue = salaryValue.Replace('.', ',');
                }

                EmployeeContent employee = new EmployeeContent
                {
                    FirstName = matchFirstName.Groups[1].Value,
                    LastName = matchLastName.Groups[1].Value,
                    Salary = Decimal.Parse(salaryValue),

                };
                return employee;
            }
            else
            {
                Console.WriteLine("Input incorrect");
                Environment.Exit(1);
                return null;
            }


        }

    }
}
