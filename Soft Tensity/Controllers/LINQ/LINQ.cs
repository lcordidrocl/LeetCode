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
            new Employee("Franzo", "Zambuto", 29, "PwC"),
            new Employee("Seba", "Renzi", 40, "iRobot"),
            new Employee("Hugo","Zapata", 50, "iRobot")
        };

        [HttpGet("employees/average/query")]
        public async Task<IActionResult> GetEmployeesAgeAveraageQuery()
        {
            var average = _empployeeService.AverageAgeForEachCompany_QueryLike(Employes);
            return Ok(average);
        }

        [HttpGet("employees/average/arrow")]
        public async Task<IActionResult> GetEmployeesAgeAveraageArrow()
        {
            var average = _empployeeService.AverageAgeForEachCompany_ArrowLike(Employes);
            return Ok(average);
        }
    }
}
