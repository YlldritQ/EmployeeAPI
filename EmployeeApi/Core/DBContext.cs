using EmployeeApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
