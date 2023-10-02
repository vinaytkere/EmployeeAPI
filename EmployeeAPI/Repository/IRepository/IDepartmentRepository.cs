using EmployeeAPI.Models;

namespace EmployeeAPI.Repository.IRepository
{
    public interface IDepartmentRepository:IRepository<Departments>
    {
        Task<Departments> UpdateDepartmentAsync(Departments entity);
    }
}
