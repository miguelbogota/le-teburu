using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class MenuService : IDbService<Menu, MenuModel, string> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public MenuService(TeburuDBContext db) { this.db = db; }

    public async Task<MenuModel> Add(MenuModel objeto) {
      db.Menu.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<MenuModel> Delete(string id) {
      Menu objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      MenuModel objetoModel = ToObject(objetoEntity);
      db.Menu.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<MenuModel> Get(string id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Menu objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<MenuModel>> GetAll() {
      ICollection<MenuModel> objetosModel = new List<MenuModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Menu> objetosEntity = await SetEntities();

      foreach (Menu objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Menu ToEntity(MenuModel objeto) {
      if (objeto == null) { return null; }
      return new Menu() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion,
        Precio = objeto.Precio,
        ImgUrl = objeto.ImgUrl,
        EstadoMenu = new EstadoMenuService(db).ToEntity(objeto.EstadoMenu),
        Categoria = new CategoriaService(db).ToEntity(objeto.Categoria),
        Combo = new ComboService(db).ToEntity(objeto.Combo)
      };
    }

    public ICollection<Menu> ToEntity(ICollection<MenuModel> objetos) {
      ICollection<Menu> objetosReturn = new List<Menu>();
      foreach (MenuModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public MenuModel ToObject(Menu objeto) {
      if (objeto == null) { return null; }
      return new MenuModel() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion,
        Precio = objeto.Precio,
        ImgUrl = objeto.ImgUrl,
        EstadoMenu = new EstadoMenuService(db).ToObject(objeto.EstadoMenu),
        Categoria = new CategoriaService(db).ToObject(objeto.Categoria),
        Combo = new ComboService(db).ToObject(objeto.Combo)
      };
    }

    public ICollection<MenuModel> ToObject(ICollection<Menu> objetos) {
      ICollection<MenuModel> objetosReturn = new List<MenuModel>();
      foreach (Menu objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(MenuModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Menu>> SetEntities() {
      return await db.Menu
        .Include(e => e.EstadoMenu)
        .Include(e => e.Categoria)
        .Include(e => e.Combo)
        .ToListAsync();
    }

    public async Task<Menu> SetEntity(string id) {
      return await db.Menu
        .Include(e => e.EstadoMenu)
        .Include(e => e.Categoria)
        .Include(e => e.Combo)
        .Where(e => e.Codigo == id)
        .FirstAsync();
    }

  }
}
