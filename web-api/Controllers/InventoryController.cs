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
  public class InventoryController : ControllerBase {

    // GET: api/inventory
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventario>>> GetInventario() {
      using (DBContext db = new DBContext()) {
        return await db.Inventario.ToListAsync();
      }
    }

    // GET: api/inventory/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Inventario>> GetInventario(decimal id) {
      using (DBContext db = new DBContext()) {
        Inventario inventario = await db.Inventario.FindAsync(id);
        if (inventario == null) { return NotFound(); }
        return inventario;
      }
    }

    // PUT: api/inventory/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutInventario(decimal id, Inventario inventario) {
      using (DBContext db = new DBContext()) {
        if (id != inventario.Id) { return BadRequest(); }
        db.Entry(inventario).State = EntityState.Modified;

        try { await db.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException) {
          if (!InventarioExists(id)) { return NotFound(); }
          else { throw; }
        }

        return NoContent();
      }
    }

    // POST: api/inventory
    [HttpPost]
    public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario) {
      using (DBContext db = new DBContext()) {
        db.Inventario.Add(inventario);
        await db.SaveChangesAsync();
        return CreatedAtAction("GetInventario", new { id = inventario.Id }, inventario);
      }
    }

    // DELETE: api/inventory/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Inventario>> DeleteInventario(decimal id) {
      using (DBContext db = new DBContext()) {
        Inventario inventario = await db.Inventario.FindAsync(id);
        if (inventario == null) { return NotFound(); }

        db.Inventario.Remove(inventario);
        await db.SaveChangesAsync();

        return inventario;
      }
    }

    // Funcion para validar si exite record en db
    private bool InventarioExists(decimal id) {
      using (DBContext db = new DBContext()) {
        return db.Inventario.Any(e => e.Id == id);
      }
    }
  }
}