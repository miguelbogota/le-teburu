using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class CargoService : IDbService<Cargo, CargoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public CargoService(TeburuDBContext db) { this.db = db; }

    public async Task<CargoModel> Add(CargoModel objeto) {
      db.Cargo.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<CargoModel> Delete(int id) {
      Cargo objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      CargoModel objetoModel = ToObject(objetoEntity);
      db.Cargo.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<CargoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Cargo objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<CargoModel>> GetAll() {
      ICollection<CargoModel> objetosModel = new List<CargoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Cargo> objetosEntity = await SetEntities();

      foreach (Cargo objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Cargo ToEntity(CargoModel objeto) {
      if (objeto == null) { return null; }
      return new Cargo() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<Cargo> ToEntity(ICollection<CargoModel> objetos) {
      ICollection<Cargo> objetosReturn = new List<Cargo>();
      foreach (CargoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public CargoModel ToObject(Cargo objeto) {
      if (objeto == null) { return null; }
      return new CargoModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<CargoModel> ToObject(ICollection<Cargo> objetos) {
      ICollection<CargoModel> objetosReturn = new List<CargoModel>();
      foreach (Cargo objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(CargoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Cargo>> SetEntities() {
      return await db.Cargo
        .ToListAsync();
    }

    public async Task<Cargo> SetEntity(int id) {
      return await db.Cargo
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
