using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class ProveedorService : IDbService<Proveedor, ProveedorModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public ProveedorService(TeburuDBContext db) { this.db = db; }

    public async Task<ProveedorModel> Add(ProveedorModel objeto) {
      db.Proveedor.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<ProveedorModel> Delete(int id) {
      Proveedor objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      ProveedorModel objetoModel = ToObject(objetoEntity);
      db.Proveedor.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<ProveedorModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Proveedor objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<ProveedorModel>> GetAll() {
      ICollection<ProveedorModel> objetosModel = new List<ProveedorModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Proveedor> objetosEntity = await SetEntities();

      foreach (Proveedor objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Proveedor ToEntity(ProveedorModel objeto) {
      if (objeto == null) { return null; }
      return new Proveedor() {
        Id = Convert.ToDecimal(objeto.Id),
        NombreCompania = objeto.NombreCompania,
        NombreContacto = objeto.NombreContacto,
        Telefono = objeto.Telefono
      };
    }

    public ICollection<Proveedor> ToEntity(ICollection<ProveedorModel> objetos) {
      ICollection<Proveedor> objetosReturn = new List<Proveedor>();
      foreach (ProveedorModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public ProveedorModel ToObject(Proveedor objeto) {
      if (objeto == null) { return null; }
      return new ProveedorModel() {
        Id = Convert.ToInt32(objeto.Id),
        NombreCompania = objeto.NombreCompania,
        NombreContacto = objeto.NombreContacto,
        Telefono = objeto.Telefono
      };
    }

    public ICollection<ProveedorModel> ToObject(ICollection<Proveedor> objetos) {
      ICollection<ProveedorModel> objetosReturn = new List<ProveedorModel>();
      foreach (Proveedor objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(ProveedorModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Proveedor>> SetEntities() {
      return await db.Proveedor
        .ToListAsync();
    }

    public async Task<Proveedor> SetEntity(int id) {
      return await db.Proveedor
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
