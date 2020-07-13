using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class CiudadService : IDbService<Ciudad, CiudadModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public CiudadService(TeburuDBContext db) { this.db = db; }

    public async Task<CiudadModel> Add(CiudadModel objeto) {
      db.Ciudad.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<CiudadModel> Delete(int id) {
      Ciudad objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      CiudadModel objetoModel = ToObject(objetoEntity);
      db.Ciudad.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<CiudadModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Ciudad objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<CiudadModel>> GetAll() {
      ICollection<CiudadModel> objetosModel = new List<CiudadModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Ciudad> objetosEntity = await SetEntities();

      foreach (Ciudad objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Ciudad ToEntity(CiudadModel objeto) {
      if (objeto == null) { return null; }
      return new Ciudad() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<Ciudad> ToEntity(ICollection<CiudadModel> objetos) {
      ICollection<Ciudad> objetosReturn = new List<Ciudad>();
      foreach (CiudadModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public CiudadModel ToObject(Ciudad objeto) {
      if (objeto == null) { return null; }
      return new CiudadModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<CiudadModel> ToObject(ICollection<Ciudad> objetos) {
      ICollection<CiudadModel> objetosReturn = new List<CiudadModel>();
      foreach (Ciudad objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(CiudadModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Ciudad>> SetEntities() {
      return await db.Ciudad
        .ToListAsync();
    }

    public async Task<Ciudad> SetEntity(int id) {
      return await db.Ciudad
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
