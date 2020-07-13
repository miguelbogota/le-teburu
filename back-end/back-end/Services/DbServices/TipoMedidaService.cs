using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class TipoMedidaService : IDbService<TipoMedida, TipoMedidaModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public TipoMedidaService(TeburuDBContext db) { this.db = db; }

    public async Task<TipoMedidaModel> Add(TipoMedidaModel objeto) {
      db.TipoMedida.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<TipoMedidaModel> Delete(int id) {
      TipoMedida objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      TipoMedidaModel objetoModel = ToObject(objetoEntity);
      db.TipoMedida.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<TipoMedidaModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      TipoMedida objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<TipoMedidaModel>> GetAll() {
      ICollection<TipoMedidaModel> objetosModel = new List<TipoMedidaModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<TipoMedida> objetosEntity = await SetEntities();

      foreach (TipoMedida objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public TipoMedida ToEntity(TipoMedidaModel objeto) {
      if (objeto == null) { return null; }
      return new TipoMedida() {
        Id = Convert.ToDecimal(objeto.Id),
        NombreAbbr = objeto.NombreAbbr,
        NombreCompleto = objeto.NombreCompleto
      };
    }

    public ICollection<TipoMedida> ToEntity(ICollection<TipoMedidaModel> objetos) {
      ICollection<TipoMedida> objetosReturn = new List<TipoMedida>();
      foreach (TipoMedidaModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public TipoMedidaModel ToObject(TipoMedida objeto) {
      if (objeto == null) { return null; }
      return new TipoMedidaModel() {
        Id = Convert.ToInt32(objeto.Id),
        NombreAbbr = objeto.NombreAbbr,
        NombreCompleto = objeto.NombreCompleto
      };
    }

    public ICollection<TipoMedidaModel> ToObject(ICollection<TipoMedida> objetos) {
      ICollection<TipoMedidaModel> objetosReturn = new List<TipoMedidaModel>();
      foreach (TipoMedida objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(TipoMedidaModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<TipoMedida>> SetEntities() {
      return await db.TipoMedida
        .ToListAsync();
    }

    public async Task<TipoMedida> SetEntity(int id) {
      return await db.TipoMedida
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
