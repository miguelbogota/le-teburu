using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class UbicacionService : IDbService<Ubicacion, UbicacionModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public UbicacionService(TeburuDBContext db) { this.db = db; }

    public async Task<UbicacionModel> Add(UbicacionModel objeto) {
      db.Ubicacion.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<UbicacionModel> Delete(int id) {
      Ubicacion objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      UbicacionModel objetoModel = ToObject(objetoEntity);
      db.Ubicacion.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<UbicacionModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Ubicacion objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<UbicacionModel>> GetAll() {
      ICollection<UbicacionModel> objetosModel = new List<UbicacionModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Ubicacion> objetosEntity = await SetEntities();

      foreach (Ubicacion objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Ubicacion ToEntity(UbicacionModel objeto) {
      if (objeto == null) { return null; }
      return new Ubicacion() {
        Id = Convert.ToDecimal(objeto.Id),
        Direccion = objeto.Direccion,
        Adiciones = objeto.Adiciones,
        Ciudad = new CiudadService(db).ToEntity(objeto.Ciudad),
        Pais = new PaisService(db).ToEntity(objeto.Pais)
      };
    }

    public ICollection<Ubicacion> ToEntity(ICollection<UbicacionModel> objetos) {
      ICollection<Ubicacion> objetosReturn = new List<Ubicacion>();
      foreach (UbicacionModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public UbicacionModel ToObject(Ubicacion objeto) {
      if (objeto == null) { return null; }
      return new UbicacionModel() {
        Id = Convert.ToInt32(objeto.Id),
        Direccion = objeto.Direccion,
        Adiciones = objeto.Adiciones,
        Ciudad = new CiudadService(db).ToObject(objeto.Ciudad),
        Pais = new PaisService(db).ToObject(objeto.Pais)
      };
    }

    public ICollection<UbicacionModel> ToObject(ICollection<Ubicacion> objetos) {
      ICollection<UbicacionModel> objetosReturn = new List<UbicacionModel>();
      foreach (Ubicacion objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(UbicacionModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Ubicacion>> SetEntities() {
      return await db.Ubicacion
        .Include(e => e.Ciudad)
        .Include(e => e.Pais)
        .ToListAsync();
    }

    public async Task<Ubicacion> SetEntity(int id) {
      return await db.Ubicacion
        .Include(e => e.Ciudad)
        .Include(e => e.Pais)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
