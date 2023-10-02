using EmployeeAPI.Models;

namespace EmployeeAPI.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employees>
    {
        Task<Employees> UpdateEmployeeAsync(Employees entity);
    }
}
