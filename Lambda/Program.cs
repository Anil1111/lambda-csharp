using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Lambda.Entities;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] data = sr.ReadLine().Split(',');
                    list.Add(new Employee(data[0], data[1], double.Parse(data[2], CultureInfo.InvariantCulture)));
                }
            }

            var emails = list.Where(p => p.Salary > salary).OrderBy(p => p.Email).Select(p => p.Email);

            Console.WriteLine("Email of people whose salary is more than " + salary.ToString("F2", CultureInfo.InvariantCulture) + ":");
            foreach(string e in emails)
            {
                Console.WriteLine(e);
            }

            var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

            Console.Write("Sum of salary of people whose name starts with 'M': " + sum);
        }
    }
}
