using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreConsoleSelfhostedApi.EfDataAccess.Entities
{
    [Table("Employees")]
    public class Employee
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public JobTitle JobTitle { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }
    }
}