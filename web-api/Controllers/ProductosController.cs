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
  public class ProductosController : ControllerBase {

    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return await db.Producto.ToListAsync();
      }
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var producto = await db.Producto.FindAsync(id);

        if (producto == null) {
          return NotFound();
        }

        return producto;
      }
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(decimal id, Producto producto) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != producto.Id) {
          return BadRequest();
        }

        db.Entry(producto).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!ProductoExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Producto.Add(producto);
        await db.SaveChangesAsync();

        return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
      }
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Producto>> DeleteProducto(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var producto = await db.Producto.FindAsync(id);
        if (producto == null) {
          return NotFound();
        }

        db.Producto.Remove(producto);
        await db.SaveChangesAsync();

        return producto;
      }
    }

    private bool ProductoExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Producto.Any(e => e.Id == id);
      }
    }
  }
}
