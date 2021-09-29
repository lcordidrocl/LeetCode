using System.Collections.Generic;
using System.Linq;

namespace SoftTensity.Controllers.LINQ.Employees
{
    public class EmployeeService: IEmployeeService
    {
        public Dictionary<string, int> AverageAgeForEachCompany_ArrowLike(List<Employee> employees)
        {

            var result = employees
                .GroupBy(e => e.Company)
                .Select(em => new { em.Key, Average = (int)em.Average(o => o.Age) }).ToDictionary(a => a.Key, a => a.Average);
            return result;
        }

        public  Dictionary<string, int> AverageAgeForEachCompany_QueryLike(List<Employee> employees)
        {
            var queryResult =
                    from employee in employees
                    group employee by new { employee.Company } into company
                    select new
                    {
                        Company = company.Key.Company,
                        Average = (int)company.Average(e => e.Age)
                    };
            return queryResult.ToDictionary(e => e.Company, e => e.Average);
        }

        public Dictionary<string, int> CountOfEmployeesForEachCompany_ArrowLike(List<Employee> employees)
        {
            var queryResult = employees
                .GroupBy(e => new { e.Company })
                .Select(group => new { group.Key.Company, NumberOfEmployees = group.Count() });
            return queryResult.ToDictionary(key => key.Company, element => element.NumberOfEmployees );
        }

        public Dictionary<string, int> CountOfEmployeesForEachCompany_QueryLike(List<Employee> employees)
        {
            var queryResult =
                from employee in employees
                group employee by employee.Company into employeeByCompany
                select new
                {
                    employeeByCompany.Key,
                    NumberOfEmployees = employeeByCompany.Count()
                };
            return queryResult.ToDictionary(key => key.Key, element => element.NumberOfEmployees);
        }

        public Dictionary<string, List<Employee>> OldestAgeForEachCompany_ArrowLike(List<Employee> employees)
        {
            var queryResult = employees
                .GroupBy(e => e.Company)
                .Select(group => new { group.Key, OldestEmployees = group.Where(ge => ge.Age.Equals(group.Max(e=>e.Age))).ToList()});
            return queryResult.ToDictionary(key => key.Key, element => element.OldestEmployees);
        }

        public Dictionary<string, List<Employee>> OldestAgeForEachCompany_QueryLike(List<Employee> employees)
        {
            var queryResult =
                from employee in employees
                group employee by employee.Company into employeesByCompany
                select new
                {
                    employeesByCompany.Key,
                    OldestEmployees = employeesByCompany.Where(e => e.Age == employeesByCompany.Max(e => e.Age)).ToList()
                };
            return queryResult.ToDictionary(k => k.Key, e => e.OldestEmployees);
        }
    }
}
