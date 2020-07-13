using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoComboService : IDbService<EstadoCombo, EstadoComboModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoComboService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoComboModel> Add(EstadoComboModel objeto) {
      db.EstadoCombo.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoComboModel> Delete(int id) {
      EstadoCombo objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoComboModel objetoModel = ToObject(objetoEntity);
      db.EstadoCombo.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoComboModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoCombo objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoComboModel>> GetAll() {
      ICollection<EstadoComboModel> objetosModel = new List<EstadoComboModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoCombo> objetosEntity = await SetEntities();

      foreach (EstadoCombo objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoCombo ToEntity(EstadoComboModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoCombo() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoCombo> ToEntity(ICollection<EstadoComboModel> objetos) {
      ICollection<EstadoCombo> objetosReturn = new List<EstadoCombo>();
      foreach (EstadoComboModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoComboModel ToObject(EstadoCombo objeto) {
      if (objeto == null) { return null; }
      return new EstadoComboModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoComboModel> ToObject(ICollection<EstadoCombo> objetos) {
      ICollection<EstadoComboModel> objetosReturn = new List<EstadoComboModel>();
      foreach (EstadoCombo objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoComboModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoCombo>> SetEntities() {
      return await db.EstadoCombo
        .ToListAsync();
    }

    public async Task<EstadoCombo> SetEntity(int id) {
      return await db.EstadoCombo
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
