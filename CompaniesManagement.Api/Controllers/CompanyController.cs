using AutoMapper;
using CoreConsoleSelfhostedApi.Repositories;
using CoreConsoleSelfhostedApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreConsoleSelfhostedApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private CompaniesRepository _companies;
        private readonly IMapper _mapper;

        public CompanyController(CompaniesRepository companies,
            IMapper mapper)
        {
            _companies = companies;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> CreateAsync([FromBody] CompanyForCreation company)
        {
            var companyEntity = _mapper.Map<EfDataAccess.Entities.Company>(company);
            _companies.AddCompany(companyEntity);

            await _companies.SaveChangesAsync();

            return CreatedAtRoute("GetCompany",
                new { id = companyEntity.Id },
                companyEntity);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] Company newCompany, long id)
        {
            var company = await _companies.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }
            company.Name = newCompany.Name;
            company.EstablishmentYear = newCompany.EstablishmentYear;
            if (newCompany.Employees.Any())
            {
                company.Employees = _mapper.Map<IEnumerable<EfDataAccess.Entities.Employee>>(newCompany.Employees);
            }
            _companies.UpdateCompany(company);

            await _companies.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteAsync([FromBody] long id)
        {
            var entity = await _companies.GetCompanyByIdAsync(id);
            _companies.RemoveCompany(entity);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        private async Task<ActionResult> GetByIdAsync(long id)
        {
            var company = await _companies.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}