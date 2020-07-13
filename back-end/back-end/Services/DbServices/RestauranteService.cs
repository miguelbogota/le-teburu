using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class RestauranteService : IDbService<Restaurante, RestauranteModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public RestauranteService(TeburuDBContext db) { this.db = db; }

    public async Task<RestauranteModel> Add(RestauranteModel objeto) {
      db.Restaurante.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<RestauranteModel> Delete(int id) {
      Restaurante objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      RestauranteModel objetoModel = ToObject(objetoEntity);
      db.Restaurante.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<RestauranteModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Restaurante objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<RestauranteModel>> GetAll() {
      ICollection<RestauranteModel> objetosModel = new List<RestauranteModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Restaurante> objetosEntity = await SetEntities();

      foreach (Restaurante objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Restaurante ToEntity(RestauranteModel objeto) {
      if (objeto == null) { return null; }
      return new Restaurante() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Telefono = objeto.Telefono,
        HoraApertura = objeto.HoraApertura,
        HoraCierre = objeto.HoraCierre,
        EstadoRestaurante = new EstadoRestauranteService(db).ToEntity(objeto.EstadoRestaurante),
        Ubicacion = new UbicacionService(db).ToEntity(objeto.Ubicacion)
      };
    }

    public ICollection<Restaurante> ToEntity(ICollection<RestauranteModel> objetos) {
      ICollection<Restaurante> objetosReturn = new List<Restaurante>();
      foreach (RestauranteModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public RestauranteModel ToObject(Restaurante objeto) {
      if (objeto == null) { return null; }
      return new RestauranteModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Telefono = objeto.Telefono,
        HoraApertura = objeto.HoraApertura,
        HoraCierre = objeto.HoraCierre,
        EstadoRestaurante = new EstadoRestauranteService(db).ToObject(objeto.EstadoRestaurante),
        Ubicacion = new UbicacionService(db).ToObject(objeto.Ubicacion)
      };
    }

    public ICollection<RestauranteModel> ToObject(ICollection<Restaurante> objetos) {
      ICollection<RestauranteModel> objetosReturn = new List<RestauranteModel>();
      foreach (Restaurante objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(RestauranteModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Restaurante>> SetEntities() {
      return await db.Restaurante
        .Include(e => e.EstadoRestaurante)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Ciudad)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Pais)
        .ToListAsync();
    }

    public async Task<Restaurante> SetEntity(int id) {
      return await db.Restaurante
        .Include(e => e.EstadoRestaurante)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Ciudad)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Pais)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
