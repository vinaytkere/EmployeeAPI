using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Repository.IRepository;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Employees> UpdateEmployeeAsync(Employees entity)
        {
            _db.Employees.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
