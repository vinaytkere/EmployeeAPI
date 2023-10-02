using AutoMapper;
using EmployeeAPI.Models;
using EmployeeAPI.Models.DTO;

namespace EmployeeAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Employees, EmployeesDTO>().ReverseMap();
            CreateMap<Employees, EmployeesCreateDTO>().ReverseMap();
            CreateMap<Employees, EmployeesUpdateDTO>().ReverseMap();

            CreateMap<Departments, DepartmentsDTO>().ReverseMap();
            CreateMap<Departments, DepartmentsCreateDTO>().ReverseMap();
            CreateMap<Departments, DepartmentUpdateDTO>().ReverseMap();
        }
    }
}
