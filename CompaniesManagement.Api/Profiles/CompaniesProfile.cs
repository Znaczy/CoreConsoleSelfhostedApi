using AutoMapper;
using CoreConsoleSelfhostedApi.Models;

namespace CoreConsoleSelfhostedApi
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            CreateMap<EfDataAccess.Entities.Company, Company>();

            CreateMap<CompanyForCreation, EfDataAccess.Entities.Company>();
        }
    }
}
