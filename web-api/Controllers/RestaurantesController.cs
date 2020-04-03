using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models.Entity;
using web_api.Handlers;

namespace web_api.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class RestaurantesController : ControllerBase {

    // GET: api/Restaurantes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurantes() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        new XmlHandler().ToXml(new Venta());
        return await db.Restaurante
          .Include(r => r.Empleados).ThenInclude(e => e.Persona)
          .Include(r => r.Empleados).ThenInclude(e => e.Ventas)
          .Include(r => r.Inventario).ThenInclude(i => i.Producto)
          .ToListAsync();
      }
    }

    // GET: api/Restaurantes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurante>> GetRestaurante(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var restaurante = await db.Restaurante
          .Include(r => r.Empleados).ThenInclude(e => e.Persona)
          .Include(r => r.Empleados).ThenInclude(e => e.Ventas)
          .Include(r => r.Inventario).ThenInclude(i => i.Producto)
          .Where(u => u.Id == id)
          .FirstOrDefaultAsync();

        if (restaurante == null) {
          return NotFound();
        }

        return restaurante;
      }
    }

    // PUT: api/Restaurantes/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRestaurante(decimal id, Restaurante restaurante) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != restaurante.Id) {
          return BadRequest();
        }

        db.Entry(restaurante).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!RestauranteExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Restaurantes
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Restaurante.Add(restaurante);
        await db.SaveChangesAsync();

        return CreatedAtAction("GetRestaurante", new { id = restaurante.Id }, restaurante);
      }
    }

    // DELETE: api/Restaurantes/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Restaurante>> DeleteRestaurante(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var restaurante = await db.Restaurante.FindAsync(id);
        if (restaurante == null) {
          return NotFound();
        }

        db.Restaurante.Remove(restaurante);
        await db.SaveChangesAsync();

        return restaurante;
      }
    }

    private bool RestauranteExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Restaurante.Any(e => e.Id == id);
      }
    }
  }
}