using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models.Entity;

namespace web_api.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class InventariosController : ControllerBase {

    // GET: api/Inventarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return await db.Inventario
          .Include(i => i.Producto)
          .ToListAsync();
      }
    }

    // GET: api/Inventarios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Inventario>> GetInventario(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var inventario = await db.Inventario
          .Include(i => i.Producto)
          .Where(i => i.Id == id)
          .FirstOrDefaultAsync();

        if (inventario == null) {
          return NotFound();
        }

        return inventario;
      }
    }

    // PUT: api/Inventarios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInventario(decimal id, Inventario inventario) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != inventario.Id) {
          return BadRequest();
        }

        db.Entry(inventario).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!InventarioExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Inventarios
    [HttpPost]
    public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        System.Diagnostics.Debug.WriteLine("");
        System.Diagnostics.Debug.WriteLine("");
        System.Diagnostics.Debug.WriteLine("");
        System.Diagnostics.Debug.WriteLine(inventario);
        System.Diagnostics.Debug.WriteLine("");
        System.Diagnostics.Debug.WriteLine("");
        System.Diagnostics.Debug.WriteLine("");
        db.Inventario.Add(inventario);
        await db.SaveChangesAsync();

        return CreatedAtAction("GetInventario", new { id = inventario.Id }, inventario);
      }
    }

    // DELETE: api/Inventarios/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Inventario>> DeleteInventario(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var inventario = await db.Inventario.FindAsync(id);
        if (inventario == null) {
          return NotFound();
        }

        db.Inventario.Remove(inventario);
        await db.SaveChangesAsync();

        return inventario;
      }
    }

    private bool InventarioExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Inventario.Any(e => e.Id == id);
      }
    }
  }
}
