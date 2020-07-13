using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class IngredientesService : IDbService<Ingredientes, IngredientesModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public IngredientesService(TeburuDBContext db) { this.db = db; }

    public async Task<IngredientesModel> Add(IngredientesModel objeto) {
      db.Ingredientes.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<IngredientesModel> Delete(int id) {
      Ingredientes objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      IngredientesModel objetoModel = ToObject(objetoEntity);
      db.Ingredientes.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<IngredientesModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Ingredientes objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<IngredientesModel>> GetAll() {
      ICollection<IngredientesModel> objetosModel = new List<IngredientesModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Ingredientes> objetosEntity = await SetEntities();

      foreach (Ingredientes objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Ingredientes ToEntity(IngredientesModel objeto) {
      if (objeto == null) { return null; }
      return new Ingredientes() {
        Id = Convert.ToDecimal(objeto.Id),
        Cantidad = objeto.Cantidad,
        Producto = new ProductoService(db).ToEntity(objeto.Producto),
        Menu = new MenuService(db).ToEntity(objeto.Menu)
      };
    }

    public ICollection<Ingredientes> ToEntity(ICollection<IngredientesModel> objetos) {
      ICollection<Ingredientes> objetosReturn = new List<Ingredientes>();
      foreach (IngredientesModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public IngredientesModel ToObject(Ingredientes objeto) {
      if (objeto == null) { return null; }
      return new IngredientesModel() {
        Id = Convert.ToInt32(objeto.Id),
        Cantidad = objeto.Cantidad,
        Producto = new ProductoService(db).ToObject(objeto.Producto),
        Menu = new MenuService(db).ToObject(objeto.Menu)
      };
    }

    public ICollection<IngredientesModel> ToObject(ICollection<Ingredientes> objetos) {
      ICollection<IngredientesModel> objetosReturn = new List<IngredientesModel>();
      foreach (Ingredientes objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(IngredientesModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Ingredientes>> SetEntities() {
      return await db.Ingredientes
        .Include(e => e.Producto)
        .Include(e => e.Menu)
        .ToListAsync();
    }

    public async Task<Ingredientes> SetEntity(int id) {
      return await db.Ingredientes
        .Include(e => e.Producto)
        .Include(e => e.Menu)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
