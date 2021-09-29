using System.Collections.Generic;

namespace SoftTensity.Controllers.LINQ.Employees
{
    public interface IEmployeeService
    {
        Dictionary<string, int> AverageAgeForEachCompany_QueryLike(List<Employee> employees);
        Dictionary<string, int> AverageAgeForEachCompany_ArrowLike(List<Employee> employees);
        Dictionary<string, int> CountOfEmployeesForEachCompany_QueryLike(List<Employee> employees);
        Dictionary<string, int> CountOfEmployeesForEachCompany_ArrowLike(List<Employee> employees);
        Dictionary<string, List<Employee>> OldestAgeForEachCompany_QueryLike(List<Employee> employees);
        Dictionary<string, List<Employee>> OldestAgeForEachCompany_ArrowLike(List<Employee> employees);
    }
}
