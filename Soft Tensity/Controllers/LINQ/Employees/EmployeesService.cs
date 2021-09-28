using System.Collections.Generic;
using System.Linq;

namespace SoftTensity.Controllers.LINQ.Employees
{
    public class EmployeeService: IEmployeeService
    {
        public  Dictionary<string, int> AverageAgeForEachCompany_QueryLike(List<Employee> employees)
        {
            var queryResult = from employee in employees
                    group employee by new { employee.Company } into company
                    select new
                    {
                        Company = company.Key.Company,
                        Average = (int)company.Average(e => e.Age)
                    };
            return queryResult.ToDictionary(e => e.Company, e => e.Average);
        }
        public Dictionary<string, int> AverageAgeForEachCompany_ArrowLike(List<Employee> employees)
        {

            var result = employees
                .GroupBy(e =>  new { Company = e.Company })
                .Select(em => new { Company = em.Key.Company, Average =(int) em.Average( o => o.Age )}).ToDictionary(a => a.Company, a => a.Average);
            return result;
        }

        public Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            return new Dictionary<string, int>();
        }

        public Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            return new Dictionary<string, Employee>();
        }
    }
}
