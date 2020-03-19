using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models.Entity;

namespace web_api.Controllers {

  // Controlador para la ruta de los empleados.
  // Aqui se encontraran todos los metodos de CRUD
  // que se usaran en el frontend.
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase {

    // GET - Ruta      /api/employees
    // Funcion devuelve todos los empleados de la base de datos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmployees() {
      // Usar base de datos
      using (DBContext db = new DBContext()) {
        // Devuleve la funcion con todos los empleados
        return await db.Empleado
          .Include(u => u.Ventas)
          .Include(u => u.Persona)
          .ToListAsync();
      }
    }

    // GET - Ruta      /api/employees/id
    // Funcion devuelve un empleado con el id
    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> GetEmployee(decimal id) {
      // Usar base de datos
      using (DBContext db = new DBContext()) {
        // Guardar empleado
        Empleado e = await db.Empleado
          .Include(u => u.Ventas)
          .Include(u => u.Persona)
          .Where(u => u.Id == id)
          .FirstOrDefaultAsync();
        // Validar si existe
        if (e == null) { return NotFound(); }
        // Devuleve el empleado
        return e;
      }
    }


  }

}