using Tarea3_GestionEmpleados_C34387.Data;
using Tarea3_GestionEmpleados_C34387.Models;
using Tarea3_GestionEmpleados_C34387.Repositories.Interfaces;

namespace Tarea3_GestionEmpleados_C34387.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {

        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public Empleado ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            return _context.Empleados
                .Where(e => e.Nombre.Contains(termino) ||
                            e.Apellidos.Contains(termino) ||
                            e.Departamento.Contains(termino))
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e =>
                    e.Nombre.Contains(busqueda) ||
                    e.Apellidos.Contains(busqueda) ||
                    e.Departamento.Contains(busqueda));
            }

            return query
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(e =>
                    e.Nombre.Contains(busqueda) ||
                    e.Apellidos.Contains(busqueda) ||
                    e.Departamento.Contains(busqueda));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
        }

    }
}
