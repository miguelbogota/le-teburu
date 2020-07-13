using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class TipoTerminacionService : IDbService<TipoTerminacion, TipoTerminacionModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public TipoTerminacionService(TeburuDBContext db) { this.db = db; }

    public async Task<TipoTerminacionModel> Add(TipoTerminacionModel objeto) {
      db.TipoTerminacion.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<TipoTerminacionModel> Delete(int id) {
      TipoTerminacion objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      TipoTerminacionModel objetoModel = ToObject(objetoEntity);
      db.TipoTerminacion.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<TipoTerminacionModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      TipoTerminacion objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<TipoTerminacionModel>> GetAll() {
      ICollection<TipoTerminacionModel> objetosModel = new List<TipoTerminacionModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<TipoTerminacion> objetosEntity = await SetEntities();

      foreach (TipoTerminacion objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public TipoTerminacion ToEntity(TipoTerminacionModel objeto) {
      if (objeto == null) { return null; }
      return new TipoTerminacion() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<TipoTerminacion> ToEntity(ICollection<TipoTerminacionModel> objetos) {
      ICollection<TipoTerminacion> objetosReturn = new List<TipoTerminacion>();
      foreach (TipoTerminacionModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public TipoTerminacionModel ToObject(TipoTerminacion objeto) {
      if (objeto == null) { return null; }
      return new TipoTerminacionModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<TipoTerminacionModel> ToObject(ICollection<TipoTerminacion> objetos) {
      ICollection<TipoTerminacionModel> objetosReturn = new List<TipoTerminacionModel>();
      foreach (TipoTerminacion objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(TipoTerminacionModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<TipoTerminacion>> SetEntities() {
      return await db.TipoTerminacion
        .ToListAsync();
    }

    public async Task<TipoTerminacion> SetEntity(int id) {
      return await db.TipoTerminacion
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
