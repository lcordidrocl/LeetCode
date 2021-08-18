using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackeRank.HackerRankTests
{
    public class CSharpTestEmployees
    {
        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }


        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var result = new Dictionary<string, int>();

            var s = from employee in employees
                    group employee by new { employee.Company } into c
                    select new
                    {
                        Company = c.Key.Company,
                        Average = (int) c.Average(e => e.Age)
                    };
            return s.ToDictionary(e => e.Company, e => e.Average);                
         }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            return new Dictionary<string, int>();
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            return new Dictionary<string, Employee>();
        }
    }
}
