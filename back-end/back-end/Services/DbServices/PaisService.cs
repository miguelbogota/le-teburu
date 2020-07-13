using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class PaisService : IDbService<Pais, PaisModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public PaisService(TeburuDBContext db) { this.db = db; }

    public async Task<PaisModel> Add(PaisModel objeto) {
      db.Pais.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<PaisModel> Delete(int id) {
      Pais objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      PaisModel objetoModel = ToObject(objetoEntity);
      db.Pais.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<PaisModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Pais objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<PaisModel>> GetAll() {
      ICollection<PaisModel> objetosModel = new List<PaisModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Pais> objetosEntity = await SetEntities();

      foreach (Pais objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Pais ToEntity(PaisModel objeto) {
      if (objeto == null) { return null; }
      return new Pais() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<Pais> ToEntity(ICollection<PaisModel> objetos) {
      ICollection<Pais> objetosReturn = new List<Pais>();
      foreach (PaisModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public PaisModel ToObject(Pais objeto) {
      if (objeto == null) { return null; }
      return new PaisModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<PaisModel> ToObject(ICollection<Pais> objetos) {
      ICollection<PaisModel> objetosReturn = new List<PaisModel>();
      foreach (Pais objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(PaisModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Pais>> SetEntities() {
      return await db.Pais
        .ToListAsync();
    }

    public async Task<Pais> SetEntity(int id) {
      return await db.Pais
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
