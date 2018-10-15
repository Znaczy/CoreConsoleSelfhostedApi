using CoreConsoleSelfhostedApi.EfDataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompaniesManagement.Api.Services
{
    interface ICompaniesRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(long id);
        long AddCompany(Company company);
        Task<bool> SaveChangesAsync();
        long RemoveCompany(Company company);
        Task<long> AddCompanyAsync(Company company);
    }
}
