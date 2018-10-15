using CompaniesManagement.Api.Services;
using CoreConsoleSelfhostedApi.EfDataAccess.Contexts;
using CoreConsoleSelfhostedApi.EfDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreConsoleSelfhostedApi.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly CompanyContext _context;

        public CompaniesRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(long id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public long AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _context.Companies.Add(company);
            long id = company.Id;

            return id;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public long RemoveCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _context.Remove(company);

            return company.Id;
        }

        public async Task<long> AddCompanyAsync(Company company)
        {
            long rowsAffected = 0;

            _context.Companies.Add(company);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        public void UpdateCompany(Company company)
        {
            _context.Update(company);
        }
    }
}
