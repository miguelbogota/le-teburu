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
  public class CategoriasController : ControllerBase {

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return await db.Categoria
          .Include(m => m.Menus).ThenInclude(m => m.Productos)
          .ToListAsync();
      }
    }

    // GET: api/Categorias/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoria(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var categoria = await db.Categoria
          .Include(m => m.Menus).ThenInclude(m => m.Productos)
          .Where(u => u.Id == id)
          .FirstOrDefaultAsync();

        if (categoria == null) {
          return NotFound();
        }

        return categoria;
      }
    }

    // PUT: api/Categorias/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(decimal id, Categoria categoria) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != categoria.Id) {
          return BadRequest();
        }

        db.Entry(categoria).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!CategoriaExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Categorias
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Categoria.Add(categoria);
        await db.SaveChangesAsync();

        return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
      }
    }

    // DELETE: api/Categorias/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Categoria>> DeleteCategoria(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var categoria = await db.Categoria.FindAsync(id);
        if (categoria == null) {
          return NotFound();
        }

        db.Categoria.Remove(categoria);
        await db.SaveChangesAsync();

        return categoria;
      }
    }

    private bool CategoriaExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Categoria.Any(e => e.Id == id);
      }
    }
  }
}
