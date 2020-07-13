using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoMenuService : IDbService<EstadoMenu, EstadoMenuModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoMenuService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoMenuModel> Add(EstadoMenuModel objeto) {
      db.EstadoMenu.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoMenuModel> Delete(int id) {
      EstadoMenu objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoMenuModel objetoModel = ToObject(objetoEntity);
      db.EstadoMenu.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoMenuModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoMenu objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoMenuModel>> GetAll() {
      ICollection<EstadoMenuModel> objetosModel = new List<EstadoMenuModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoMenu> objetosEntity = await SetEntities();

      foreach (EstadoMenu objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoMenu ToEntity(EstadoMenuModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoMenu() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoMenu> ToEntity(ICollection<EstadoMenuModel> objetos) {
      ICollection<EstadoMenu> objetosReturn = new List<EstadoMenu>();
      foreach (EstadoMenuModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoMenuModel ToObject(EstadoMenu objeto) {
      if (objeto == null) { return null; }
      return new EstadoMenuModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoMenuModel> ToObject(ICollection<EstadoMenu> objetos) {
      ICollection<EstadoMenuModel> objetosReturn = new List<EstadoMenuModel>();
      foreach (EstadoMenu objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoMenuModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoMenu>> SetEntities() {
      return await db.EstadoMenu
        .ToListAsync();
    }

    public async Task<EstadoMenu> SetEntity(int id) {
      return await db.EstadoMenu
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
