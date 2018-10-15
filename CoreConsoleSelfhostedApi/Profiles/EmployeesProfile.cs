using AutoMapper;
using CoreConsoleSelfhostedApi.Models;

namespace CoreConsoleSelfhostedApi.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<EmployeeForCreation, EfDataAccess.Entities.Employee>();
        }
    }
}
