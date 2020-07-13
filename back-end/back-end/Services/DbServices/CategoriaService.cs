using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class CategoriaService: IDbService<Categoria, CategoriaModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public CategoriaService(TeburuDBContext db) { this.db = db; }

    public async Task<CategoriaModel> Add(CategoriaModel objeto) {
      db.Categoria.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<CategoriaModel> Delete(int id) {
      Categoria objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      CategoriaModel objetoModel = ToObject(objetoEntity);
      db.Categoria.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<CategoriaModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Categoria objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<CategoriaModel>> GetAll() {
      ICollection<CategoriaModel> objetosModel = new List<CategoriaModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Categoria> objetosEntity = await SetEntities();

      foreach (Categoria objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Categoria ToEntity(CategoriaModel objeto) {
      if (objeto == null) { return null; }
      return new Categoria() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<Categoria> ToEntity(ICollection<CategoriaModel> objetos) {
      ICollection<Categoria> objetosReturn = new List<Categoria>();
      foreach (CategoriaModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public CategoriaModel ToObject(Categoria objeto) {
      if (objeto == null) { return null; }
      return new CategoriaModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<CategoriaModel> ToObject(ICollection<Categoria> objetos) {
      ICollection<CategoriaModel> objetosReturn = new List<CategoriaModel>();
      foreach (Categoria objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(CategoriaModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Categoria>> SetEntities() {
      return await db.Categoria
        .ToListAsync();
    }

    public async Task<Categoria> SetEntity(int id) {
      return await db.Categoria
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
