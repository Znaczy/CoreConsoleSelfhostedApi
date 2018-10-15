using System;

namespace CoreConsoleSelfhostedApi.Models
{
    public class EmployeeForCreation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitle JobTitle { get; set; }
        public long CompanyId { get; set; }
    }
}
