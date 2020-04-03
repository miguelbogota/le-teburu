using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models.Entity;

namespace web_api.Controllers {

  // Controlador para la ruta de los empleados.
  // Aqui se encontraran todos los metodos de CRUD
  // que se usaran en el frontend.
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class EmpleadosController : ControllerBase {

    // GET - Ruta      /api/employees
    // Funcion devuelve todos los empleados de la base de datos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
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
    public async Task<ActionResult<Empleado>> GetEmpleado(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
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

    // POST- Ruta     /api/inventory
    // Funcion agrega un nuevo empleado
    [HttpPost]
    public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Empleado.Add(empleado);
        await db.SaveChangesAsync();
        return CreatedAtAction("GetEmployee", new { id = empleado.Id }, empleado);
      }
    }

    // PUT - Ruta     /api/employee/id
    // Funcion actualiza un empleado existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmpleado(decimal id, Empleado empleado) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != empleado.Id) { return BadRequest(); }
        db.Entry(empleado).State = EntityState.Modified;
        // Guardar informacion en db
        try { await db.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException) {
          if (!EmpleadoExists(id)) { return NotFound(); }
          else { throw; }
        }
        return NoContent();
      }
    }

    // DELETE- Ruta     /api/employees/id
    // Funcion elimina un dato del empleado en la db con el id
    [HttpDelete("{id}")]
    public async Task<ActionResult<Empleado>> DeleteEmpleado(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        // Buscar empleado
        Empleado empleado = await db.Empleado
          .Include(e => e.Persona)
          .Where(e => e.Id == id)
          .FirstOrDefaultAsync();
        // Guardar datos
        Persona datos = empleado.Persona;
        // Validacion si no se encontro el usuario
        if (empleado == null) { return NotFound(); }
        // Eliminar el usuario y datos
        db.Empleado.Remove(empleado);
        db.Persona.Remove(datos);
        // Guardar datos
        await db.SaveChangesAsync();
        return empleado;
      }
    }

    // Funcion para validar si exite record en db
    private bool EmpleadoExists(decimal id) {
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Empleado.Any(e => e.Id == id);
      }
    }

  }
}