using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class GeneroService : IDbService<Genero, GeneroModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public GeneroService(TeburuDBContext db) { this.db = db; }

    public async Task<GeneroModel> Add(GeneroModel objeto) {
      db.Genero.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<GeneroModel> Delete(int id) {
      Genero objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      GeneroModel objetoModel = ToObject(objetoEntity);
      db.Genero.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<GeneroModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Genero objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<GeneroModel>> GetAll() {
      ICollection<GeneroModel> objetosModel = new List<GeneroModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Genero> objetosEntity = await SetEntities();

      foreach (Genero objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Genero ToEntity(GeneroModel objeto) {
      if (objeto == null) { return null; }
      return new Genero() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<Genero> ToEntity(ICollection<GeneroModel> objetos) {
      ICollection<Genero> objetosReturn = new List<Genero>();
      foreach (GeneroModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public GeneroModel ToObject(Genero objeto) {
      if (objeto == null) { return null; }
      return new GeneroModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre
      };
    }

    public ICollection<GeneroModel> ToObject(ICollection<Genero> objetos) {
      ICollection<GeneroModel> objetosReturn = new List<GeneroModel>();
      foreach (Genero objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(GeneroModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Genero>> SetEntities() {
      return await db.Genero
        .ToListAsync();
    }

    public async Task<Genero> SetEntity(int id) {
      return await db.Genero
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
