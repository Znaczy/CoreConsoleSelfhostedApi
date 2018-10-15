using System;

namespace CoreConsoleSelfhostedApi.Models
{
    public class Employee
    {
        public long Id { get; set; }
        // FirstName + LastName
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }
        public Company Company { get; set; }

    }
    public enum JobTitle
    {
        Administrator = 0,
        Developer = 1,
        Architect = 2,
        Manager = 3
    }
}
