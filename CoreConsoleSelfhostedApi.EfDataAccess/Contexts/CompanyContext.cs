using CoreConsoleSelfhostedApi.EfDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreConsoleSelfhostedApi.EfDataAccess.Contexts
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
