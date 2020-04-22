using AllCoreInOne.Models;
using AllCoreInOne.ViewModels.Employee;
using AutoMapper;

namespace AllCoreInOne.Infrastructure.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                 .ForMember(dest => dest.DepartmentName,
                  opt => opt.MapFrom(src => src.Department.Name)).ReverseMap();
        }
    }
}
