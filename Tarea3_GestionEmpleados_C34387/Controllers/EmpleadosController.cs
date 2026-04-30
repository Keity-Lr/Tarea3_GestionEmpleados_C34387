using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C34387.Models;
using Tarea3_GestionEmpleados_C34387.Repositories.Interfaces;

namespace Tarea3_GestionEmpleados_C34387.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            int tamano = 5;

            var empleados = _repo.ObtenerPaginado(pagina, tamano, busqueda);
            var total = _repo.ContarTotal(busqueda);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamano);

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (empleado.FechaIngreso == default) empleado.FechaIngreso = DateTime.Now;

            if (ModelState.IsValid)
            {
                _repo.Agregar(empleado); //
                return RedirectToAction(nameof(Index));
            }
           
            return View(empleado);
        }
        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _repo.Actualizar(empleado);
            }

            return RedirectToAction("Index");
        }

    }
}
