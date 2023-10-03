using Employee.Models;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
