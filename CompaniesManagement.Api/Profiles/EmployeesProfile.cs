using AutoMapper;
using CoreConsoleSelfhostedApi.Models;
using System.Collections.Generic;

namespace CoreConsoleSelfhostedApi.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<EmployeeForCreation, EfDataAccess.Entities.Employee>();

            CreateMap<IEnumerable<Employee>, IEnumerable<EfDataAccess.Entities.Employee>>();
        }
    }
}
