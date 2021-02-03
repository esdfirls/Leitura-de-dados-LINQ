using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using lambdalinqdelegate.Entities;
using System.Linq;

namespace lambdalinqdelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>();
            Console.WriteLine("Enter the full file path: ");
            var path = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            var salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    var lines = sr.ReadLine().Split(',');
                    var name = lines[0];
                    var email = lines[1];
                    var salaryLine = double.Parse(lines[2], CultureInfo.InvariantCulture);

                    emp.Add(new Employee(name, email, salaryLine));
                }
            }

            Console.WriteLine($"Email of people whose salary is more than {salary}: ");

            var emails = emp.Where(p => p.Salary > salary).OrderBy(p => p.Email).Select(p => p.Email);
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Sum of salary of people whose name starts with 'M':");

            Console.WriteLine(emp.Where(p => p.Name[0] == 'M').Sum(p => p.Salary));




        }
    }
}