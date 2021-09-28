using System.Collections.Generic;

namespace SoftTensity.Controllers.LINQ.Employees
{
    public interface IEmployeeService
    {
        Dictionary<string, int> AverageAgeForEachCompany_QueryLike(List<Employee> employees);
        Dictionary<string, int> AverageAgeForEachCompany_ArrowLike(List<Employee> employees);
        Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees);
        Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees);
    }
}
