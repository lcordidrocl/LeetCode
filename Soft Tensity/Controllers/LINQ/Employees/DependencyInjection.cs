using Microsoft.Extensions.DependencyInjection;

namespace SoftTensity.Controllers.LINQ.Employees
{
    public static class DependencyInjection
    {
        public static void AddLinqServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
