using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class ComboService : IDbService<Combo, ComboModel, string> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public ComboService(TeburuDBContext db) { this.db = db; }

    public async Task<ComboModel> Add(ComboModel objeto) {
      db.Combo.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<ComboModel> Delete(string id) {
      Combo objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      ComboModel objetoModel = ToObject(objetoEntity);
      db.Combo.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<ComboModel> Get(string id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Combo objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<ComboModel>> GetAll() {
      ICollection<ComboModel> objetosModel = new List<ComboModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Combo> objetosEntity = await SetEntities();

      foreach (Combo objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Combo ToEntity(ComboModel objeto) {
      if (objeto == null) { return null; }
      return new Combo() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion,
        Precio = objeto.Precio,
        ImgUrl = objeto.ImgUrl,
        EstadoCombo = new EstadoComboService(db).ToEntity(objeto.EstadoCombo)
      };
    }

    public ICollection<Combo> ToEntity(ICollection<ComboModel> objetos) {
      ICollection<Combo> objetosReturn = new List<Combo>();
      foreach (ComboModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public ComboModel ToObject(Combo objeto) {
      if (objeto == null) { return null; }
      return new ComboModel() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion,
        Precio = objeto.Precio,
        ImgUrl = objeto.ImgUrl,
        EstadoCombo = new EstadoComboService(db).ToObject(objeto.EstadoCombo)
      };
    }

    public ICollection<ComboModel> ToObject(ICollection<Combo> objetos) {
      ICollection<ComboModel> objetosReturn = new List<ComboModel>();
      foreach (Combo objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(ComboModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Combo>> SetEntities() {
      return await db.Combo
        .Include(e => e.EstadoCombo)
        .ToListAsync();
    }

    public async Task<Combo> SetEntity(string id) {
      return await db.Combo
        .Include(e => e.EstadoCombo)
        .Where(e => e.Codigo == id)
        .FirstAsync();
    }

  }
}
