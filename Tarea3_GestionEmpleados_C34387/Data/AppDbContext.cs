using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C34387.Models;

namespace Tarea3_GestionEmpleados_C34387.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}