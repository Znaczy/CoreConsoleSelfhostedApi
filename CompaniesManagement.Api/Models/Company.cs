using System.Collections.Generic;

namespace CoreConsoleSelfhostedApi.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
