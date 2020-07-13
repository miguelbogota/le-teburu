using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoProductoService : IDbService<EstadoProducto, EstadoProductoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoProductoService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoProductoModel> Add(EstadoProductoModel objeto) {
      db.EstadoProducto.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoProductoModel> Delete(int id) {
      EstadoProducto objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoProductoModel objetoModel = ToObject(objetoEntity);
      db.EstadoProducto.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoProductoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoProducto objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoProductoModel>> GetAll() {
      ICollection<EstadoProductoModel> objetosModel = new List<EstadoProductoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoProducto> objetosEntity = await SetEntities();

      foreach (EstadoProducto objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoProducto ToEntity(EstadoProductoModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoProducto() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoProducto> ToEntity(ICollection<EstadoProductoModel> objetos) {
      ICollection<EstadoProducto> objetosReturn = new List<EstadoProducto>();
      foreach (EstadoProductoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoProductoModel ToObject(EstadoProducto objeto) {
      if (objeto == null) { return null; }
      return new EstadoProductoModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoProductoModel> ToObject(ICollection<EstadoProducto> objetos) {
      ICollection<EstadoProductoModel> objetosReturn = new List<EstadoProductoModel>();
      foreach (EstadoProducto objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoProductoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoProducto>> SetEntities() {
      return await db.EstadoProducto
        .ToListAsync();
    }

    public async Task<EstadoProducto> SetEntity(int id) {
      return await db.EstadoProducto
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
