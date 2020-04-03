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
  public class MenusController : ControllerBase {
    // GET: api/Menus
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Menu>>> GetMenus() {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return await db.Menu
          .Include(m => m.Productos)
          .ToListAsync();
      }
    }

    // GET: api/Menus/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Menu>> GetMenu(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var menu = await db.Menu
          .Include(m => m.Productos)
          .Where(u => u.Id == id)
          .FirstOrDefaultAsync();

        if (menu == null) {
          return NotFound();
        }

        return menu;
      }
    }

    // PUT: api/Menus/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMenu(decimal id, Menu menu) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        if (id != menu.Id) {
          return BadRequest();
        }

        db.Entry(menu).State = EntityState.Modified;

        try {
          await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!MenuExists(id)) {
            return NotFound();
          }
          else {
            throw;
          }
        }

        return NoContent();
      }
    }

    // POST: api/Menus
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Menu>> PostMenu(Menu menu) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        db.Menu.Add(menu);
        await db.SaveChangesAsync();

        return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
      }
    }

    // DELETE: api/Menus/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Menu>> DeleteMenu(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        var menu = await db.Menu.FindAsync(id);
        if (menu == null) {
          return NotFound();
        }

        db.Menu.Remove(menu);
        await db.SaveChangesAsync();

        return menu;
      }
    }

    private bool MenuExists(decimal id) {
      // Usar base de datos
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Menu.Any(e => e.Id == id);
      }
    }
  }
}
