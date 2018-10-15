using System.Collections.Generic;

namespace CoreConsoleSelfhostedApi.Models
{
    public class CompanyForCreation
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IEnumerable<EmployeeForCreation> Employees { get; set; }
    }
}