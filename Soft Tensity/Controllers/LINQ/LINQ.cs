using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftTensity.Controllers.LINQ.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftTensity.Controllers.LINQ
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQ : ControllerBase
    {

        private readonly IEmployeeService _empployeeService;
        public LINQ(IEmployeeService employeeService) 
        {
            _empployeeService = employeeService;
        }
        
        public static List<Employee> Employes = new List<Employee>() {
            new Employee("Luciano", "Cordi", 27, "PwC"),
            new Employee("Nicolas", "Cejcas", 28, "PwC"),
            new Employee("Franco", "Zambuto", 29, "PwC"),
            new Employee("Seba", "Renzi", 40, "iRobot"),
            new Employee("Hugo","Zapata", 50, "iRobot"),
            new Employee("ElMasGrande","CompartePodioConHugo", 50, "iRobot")
        };

        [HttpGet("employees/average/query")]
        public async Task<IActionResult> GetEmployeesAgeAveraageQuery()
        {
            var averageAgePerCompany = _empployeeService.AverageAgeForEachCompany_QueryLike(Employes);
            return Ok(averageAgePerCompany);
        }

        [HttpGet("employees/average/arrow")]
        public async Task<IActionResult> GetEmployeesAgeAveraageArrow()
        {
            var averageAgePerCompany = _empployeeService.AverageAgeForEachCompany_ArrowLike(Employes);
            return Ok(averageAgePerCompany);
        }

        [HttpGet("employees/countEmployees/query")]
        public async Task<IActionResult> GetEmployeeCountQuery()
        {
            var employeesByCompany = _empployeeService.CountOfEmployeesForEachCompany_QueryLike(Employes);
            return Ok(employeesByCompany);
        }

        [HttpGet("employees/countEmployees/arrow")]
        public async Task<IActionResult> GetEmployeeCountArrow()
        {
            var employeesByCompany = _empployeeService.CountOfEmployeesForEachCompany_ArrowLike(Employes);
            return Ok(employeesByCompany);
        }

        [HttpGet("employees/oldestEmployees/query")]
        public async Task<IActionResult> GetOldestEmployeesQuery()
        {
            var oldestEmployees = _empployeeService.OldestAgeForEachCompany_QueryLike(Employes);
            return Ok(oldestEmployees);
        }

        [HttpGet("employees/oldestEmployees/arrow")]
        public async Task<IActionResult> GetOldestEmployeesArrow()
        {
            var oldestEmployees = _empployeeService.OldestAgeForEachCompany_ArrowLike(Employes);
            return Ok(oldestEmployees);
        }
    }
}
