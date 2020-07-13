using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class InventarioService : IDbService<Inventario, InventarioModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public InventarioService(TeburuDBContext db) { this.db = db; }

    public async Task<InventarioModel> Add(InventarioModel objeto) {
      db.Inventario.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<InventarioModel> Delete(int id) {
      Inventario objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      InventarioModel objetoModel = ToObject(objetoEntity);
      db.Inventario.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<InventarioModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Inventario objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<InventarioModel>> GetAll() {
      ICollection<InventarioModel> objetosModel = new List<InventarioModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Inventario> objetosEntity = await SetEntities();

      foreach (Inventario objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Inventario ToEntity(InventarioModel objeto) {
      if (objeto == null) { return null; }
      return new Inventario() {
        Id = Convert.ToDecimal(objeto.Id),
        FechaEntrada = objeto.FechaEntrada,
        Cantidad = objeto.Cantidad,
        Precio = objeto.Precio,
        Producto = new ProductoService(db).ToEntity(objeto.Producto),
        Restaurante = new RestauranteService(db).ToEntity(objeto.Restaurante)
      };
    }

    public ICollection<Inventario> ToEntity(ICollection<InventarioModel> objetos) {
      ICollection<Inventario> objetosReturn = new List<Inventario>();
      foreach (InventarioModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public InventarioModel ToObject(Inventario objeto) {
      if (objeto == null) { return null; }
      return new InventarioModel() {
        FechaEntrada = objeto.FechaEntrada,
        Cantidad = objeto.Cantidad,
        Precio = objeto.Precio,
        Producto = new ProductoService(db).ToObject(objeto.Producto),
        Restaurante = new RestauranteService(db).ToObject(objeto.Restaurante)
      };
    }

    public ICollection<InventarioModel> ToObject(ICollection<Inventario> objetos) {
      ICollection<InventarioModel> objetosReturn = new List<InventarioModel>();
      foreach (Inventario objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(InventarioModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Inventario>> SetEntities() {
      return await db.Inventario
        .Include(e => e.Producto)
        .Include(e => e.Restaurante)
        .ToListAsync();
    }

    public async Task<Inventario> SetEntity(int id) {
      return await db.Inventario
        .Include(e => e.Producto)
        .Include(e => e.Restaurante)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
