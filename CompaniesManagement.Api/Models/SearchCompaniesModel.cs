using System;

namespace CoreConsoleSelfhostedApi.Models
{
    public class SearchCompaniesModel
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public JobTitle? EmployeeJobTitles { get; set; }
    }
}
