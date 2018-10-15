using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreConsoleSelfhostedApi.EfDataAccess.Entities
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(4)]
        public int EstablishmentYear { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
