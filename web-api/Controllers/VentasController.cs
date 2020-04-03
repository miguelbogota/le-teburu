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


  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class VentasController : ControllerBase {

    // GET: api/Ventas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venta>>> GetVentas() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return await db.Venta
          .Include(v => v.Pedidos)
          .Include(v => v.Empleado)
          .Include(v => v.Estado)
          .ToListAsync();
      }
    }

    // GET: api/Ventas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Venta>> GetVenta(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var venta = await db.Venta
          .Include(v => v.Pedidos)
          .Include(v => v.Empleado)
          .Include(v => v.Estado)
          .Where(u => u.Id == id)
          .FirstOrDefaultAsync();

        if (venta == null) {
          return NotFound();
        }

        return venta;
      }
    }

    // PUT: api/Ventas/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenta(decimal id, Venta venta) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != venta.Id) {
          return BadRequest();
        }

        db.Entry(venta).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!VentaExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Ventas
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Venta>> PostVenta(Venta venta) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Venta.Add(venta);
        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateException) {
          if (VentaExists(venta.Id)) {
            return Conflict();
          }
          else {
            throw;
          }
        }

        return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
      }
    }

    // DELETE: api/Ventas/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Venta>> DeleteVenta(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var venta = await db.Venta.FindAsync(id);
        if (venta == null) {
          return NotFound();
        }

        db.Venta.Remove(venta);
        await db.SaveChangesAsync();

        return venta;
      }
    }

    private bool VentaExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Venta.Any(e => e.Id == id);
      }
    }
  }
}
