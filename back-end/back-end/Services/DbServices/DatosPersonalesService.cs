using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class DatosPersonalesService : IDbService<DatosPersonales, DatosPersonalesModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public DatosPersonalesService(TeburuDBContext db) { this.db = db; }

    public async Task<DatosPersonalesModel> Add(DatosPersonalesModel objeto) {
      db.DatosPersonales.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<DatosPersonalesModel> Delete(int id) {
      DatosPersonales objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      DatosPersonalesModel objetoModel = ToObject(objetoEntity);
      db.DatosPersonales.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<DatosPersonalesModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      DatosPersonales objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<DatosPersonalesModel>> GetAll() {
      ICollection<DatosPersonalesModel> objetosModel = new List<DatosPersonalesModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<DatosPersonales> objetosEntity = await SetEntities();

      foreach (DatosPersonales objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public DatosPersonales ToEntity(DatosPersonalesModel objeto) {
      if (objeto == null) { return null; }
      return new DatosPersonales() {
        Documento = Convert.ToDecimal(objeto.Documento),
        Nombre = objeto.Nombre   ,
        Apellido = objeto.Apellido,
        FechaNacimiento = objeto.FechaNacimiento,
        Correo = objeto.Correo,
        Telefono = objeto.Telefono,
        Genero = new GeneroService(db).ToEntity(objeto.Genero),
        TipoDocumento = new TipoDocumentoService(db).ToEntity(objeto.TipoDocumento),
        Ubicacion = new UbicacionService(db).ToEntity(objeto.Ubicacion)
      };
    }

    public ICollection<DatosPersonales> ToEntity(ICollection<DatosPersonalesModel> objetos) {
      ICollection<DatosPersonales> objetosReturn = new List<DatosPersonales>();
      foreach (DatosPersonalesModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public DatosPersonalesModel ToObject(DatosPersonales objeto) {
      if (objeto == null) { return null; }
      return new DatosPersonalesModel() {
        Documento = Convert.ToInt32(objeto.Documento),
        Nombre = objeto.Nombre,
        Apellido = objeto.Apellido,
        FechaNacimiento = objeto.FechaNacimiento,
        Correo = objeto.Correo,
        Telefono = objeto.Telefono,
        Genero = new GeneroService(db).ToObject(objeto.Genero),
        TipoDocumento = new TipoDocumentoService(db).ToObject(objeto.TipoDocumento),
        Ubicacion = new UbicacionService(db).ToObject(objeto.Ubicacion)
      };
    }

    public ICollection<DatosPersonalesModel> ToObject(ICollection<DatosPersonales> objetos) {
      ICollection<DatosPersonalesModel> objetosReturn = new List<DatosPersonalesModel>();
      foreach (DatosPersonales objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(DatosPersonalesModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<DatosPersonales>> SetEntities() {
      return await db.DatosPersonales
        .Include(e => e.Genero)
        .Include(e => e.TipoDocumento)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Ciudad)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Pais)
        .ToListAsync();
    }

    public async Task<DatosPersonales> SetEntity(int id) {
      return await db.DatosPersonales
        .Include(e => e.Genero)
        .Include(e => e.TipoDocumento)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Ciudad)
        .Include(e => e.Ubicacion)
          .ThenInclude(r => r.Pais)
        .Where(e => e.Documento == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
