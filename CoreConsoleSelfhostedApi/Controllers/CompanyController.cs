using AutoMapper;
using CoreConsoleSelfhostedApi.EfDataAccess.Entities;
using CoreConsoleSelfhostedApi.EfDataAccess.Repositories;
using CoreConsoleSelfhostedApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreConsoleSelfhostedApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //readonly?
        private CompaniesRepository _companies;
        private readonly IMapper _mapper;

        public CompanyController(CompaniesRepository companies,
            IMapper mapper)
        {
            _companies = companies;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("company/create")]
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> CreateAsync([FromBody] CompanyForCreation company)
        {
            // all fields are required
            var companyEntity = _mapper.Map<EfDataAccess.Entities.Company>(company);
            _companies.AddCompany(companyEntity);

            await _companies.SaveChangesAsync();

            return CreatedAtRoute("GetCompany",
                new { id = companyEntity.Id },
                companyEntity);
        }

        //[Route("company/search")]
        //[HttpPost("{keyword}")]
        //public async Task<ActionResult<List<Company>>> SearchAsync(string keyword)
        //{
        //    // keyword -> like do nazwy firmy, imienia i nazwiska pracownika - jeśli w którymkolwiek, to wynik na liście
        //    // „EmployeeDateOfBirthFrom” oraz „EmployeeDateOfBirthTo” określają zakres daty urodzenia 
        //    // dowolnego pracownika w firmie. Podobnie „EmployeeJobTitles” – wystarczy aby jeden pracownik
        //    // posiadał stanowisko obecne na liście.

        //    return await _companies.GetCompaniesAsync();
        //}

        //[Route("company/update/{id}")]
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Company>> UpdateAsync([FromBody] Company company, long id)
        //{
        //    // tak jak create, dane z pytania
        //    var entity = await _companies.GetCompanyAsync(id);

        //    // nic nie zwraca?
        //    return entity;
        //}

        [Route("company/delete/{id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            // tak jak create, dane z pytania
            var entity = await _companies.GetCompanyAsync(id);

            // nic nie zwraca?
            return Ok();
        }

        //// Aplikacja powinna być odporna na przesłanie brakujących lub nieprawidłowych danych w
        //// zapytaniach i odpowiadać odpowiednim statusem HTTP wraz z informacją o powodzie błędu.
        //// Wszystkie akcje oprócz wyszukiwania(3.) muszą być chronione metodą „Basic Authentication” czyli
        //// dodatkowym nagłówkiem HTTP zawierającym zakodowanego w Base64 użytkownika i hasło. Serwer
        //// musi odpowiedzieć błędem 401 – Unauthorized jeśli zapytanie nie posiada takiego nagłówka lub jest
        //// niepoprawny. Dla uproszczenia użytkownik i hasło mogą być zdefiniowane na stałe w kodzie.

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        private async Task<ActionResult> GetByIdAsync(long id)
        {
            var company = await _companies.GetCompanyAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Company>>> GetAllAsync()
        //{
        //    return await _companies.GetCompaniesAsync();
        //}
    }
}