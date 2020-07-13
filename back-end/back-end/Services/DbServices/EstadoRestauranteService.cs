using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoRestauranteService : IDbService<EstadoRestaurante, EstadoRestauranteModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoRestauranteService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoRestauranteModel> Add(EstadoRestauranteModel objeto) {
      db.EstadoRestaurante.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoRestauranteModel> Delete(int id) {
      EstadoRestaurante objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoRestauranteModel objetoModel = ToObject(objetoEntity);
      db.EstadoRestaurante.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoRestauranteModel> Get(int id) {
      EstadoRestauranteModel objeto = new EstadoRestauranteModel();
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoRestaurante objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoRestauranteModel>> GetAll() {
      ICollection<EstadoRestauranteModel> objetosModel = new List<EstadoRestauranteModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoRestaurante> objetosEntity = await SetEntities();

      foreach (EstadoRestaurante objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoRestaurante ToEntity(EstadoRestauranteModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoRestaurante() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoRestaurante> ToEntity(ICollection<EstadoRestauranteModel> objetos) {
      ICollection<EstadoRestaurante> objetosReturn = new List<EstadoRestaurante>();
      foreach (EstadoRestauranteModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoRestauranteModel ToObject(EstadoRestaurante objeto) {
      if (objeto == null) { return null; }
      return new EstadoRestauranteModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoRestauranteModel> ToObject(ICollection<EstadoRestaurante> objetos) {
      ICollection<EstadoRestauranteModel> objetosReturn = new List<EstadoRestauranteModel>();
      foreach (EstadoRestaurante objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoRestauranteModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoRestaurante>> SetEntities() {
      return await db.EstadoRestaurante
        .ToListAsync();
    }

    public async Task<EstadoRestaurante> SetEntity(int id) {
      return await db.EstadoRestaurante
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
