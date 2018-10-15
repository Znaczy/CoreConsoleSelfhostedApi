using AutoMapper;
using CoreConsoleSelfhostedApi.Models;

namespace CoreConsoleSelfhostedApi
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<EfDataAccess.Entities.Company, Company>()
                //.ForMember(dest => dest.Employees, opt => opt.MapFrom(src => 
                //$"{src.Employee.FirstName} {src.Employee.LastName}")
                ;

            CreateMap<CompanyForCreation, EfDataAccess.Entities.Company>();

        }
    }
}
