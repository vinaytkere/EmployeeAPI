using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Repository.IRepository;

namespace EmployeeAPI.Repository
{
    public class DepartmentRepository : Repository<Departments>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Departments> UpdateDepartmentAsync(Departments entity)
        {
            _db.Departments.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
