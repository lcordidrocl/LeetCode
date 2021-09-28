namespace SoftTensity.Controllers.LINQ.Employees
{
    public class Employee
    {
        public Employee() { }

        public Employee(string firstName, string lastName, int age, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Company = company;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }

}
