using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoVentaService : IDbService<EstadoVenta, EstadoVentaModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoVentaService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoVentaModel> Add(EstadoVentaModel objeto) {
      db.EstadoVenta.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoVentaModel> Delete(int id) {
      EstadoVenta objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoVentaModel objetoModel = ToObject(objetoEntity);
      db.EstadoVenta.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoVentaModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoVenta objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoVentaModel>> GetAll() {
      ICollection<EstadoVentaModel> objetosModel = new List<EstadoVentaModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoVenta> objetosEntity = await SetEntities();

      foreach (EstadoVenta objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoVenta ToEntity(EstadoVentaModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoVenta() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoVenta> ToEntity(ICollection<EstadoVentaModel> objetos) {
      ICollection<EstadoVenta> objetosReturn = new List<EstadoVenta>();
      foreach (EstadoVentaModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoVentaModel ToObject(EstadoVenta objeto) {
      if (objeto == null) { return null; }
      return new EstadoVentaModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoVentaModel> ToObject(ICollection<EstadoVenta> objetos) {
      ICollection<EstadoVentaModel> objetosReturn = new List<EstadoVentaModel>();
      foreach (EstadoVenta objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoVentaModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoVenta>> SetEntities() {
      return await db.EstadoVenta
        .ToListAsync();
    }

    public async Task<EstadoVenta> SetEntity(int id) {
      return await db.EstadoVenta
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
