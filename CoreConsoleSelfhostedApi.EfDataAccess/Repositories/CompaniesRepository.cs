using CoreConsoleSelfhostedApi.EfDataAccess.Contexts;
using CoreConsoleSelfhostedApi.EfDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreConsoleSelfhostedApi.EfDataAccess.Repositories
{
    public class CompaniesRepository
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

        public async Task<Company> GetCompanyAsync(long id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public long AddCompany(Company company)
        {
            if(company == null)
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

        public async Task<long> AddCompanyAsync(Company company)
        {
            long rowsAffected = 0;

            _context.Companies.Add(company);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }

        //public async Task Delete(long id)
        //{
        //    var company = _context.Companies.Find(id);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
