using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EstadoEmpleadoService : IDbService<EstadoEmpleado, EstadoEmpleadoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EstadoEmpleadoService(TeburuDBContext db) { this.db = db; }

    public async Task<EstadoEmpleadoModel> Add(EstadoEmpleadoModel objeto) {
      db.EstadoEmpleado.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EstadoEmpleadoModel> Delete(int id) {
      EstadoEmpleado objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EstadoEmpleadoModel objetoModel = ToObject(objetoEntity);
      db.EstadoEmpleado.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EstadoEmpleadoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      EstadoEmpleado objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EstadoEmpleadoModel>> GetAll() {
      ICollection<EstadoEmpleadoModel> objetosModel = new List<EstadoEmpleadoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<EstadoEmpleado> objetosEntity = await SetEntities();

      foreach (EstadoEmpleado objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public EstadoEmpleado ToEntity(EstadoEmpleadoModel objeto) {
      if (objeto == null) { return null; }
      return new EstadoEmpleado() {
        Id = Convert.ToDecimal(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoEmpleado> ToEntity(ICollection<EstadoEmpleadoModel> objetos) {
      ICollection<EstadoEmpleado> objetosReturn = new List<EstadoEmpleado>();
      foreach (EstadoEmpleadoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EstadoEmpleadoModel ToObject(EstadoEmpleado objeto) {
      if (objeto == null) { return null; }
      return new EstadoEmpleadoModel() {
        Id = Convert.ToInt32(objeto.Id),
        Nombre = objeto.Nombre,
        Descripcion = objeto.Descripcion
      };
    }

    public ICollection<EstadoEmpleadoModel> ToObject(ICollection<EstadoEmpleado> objetos) {
      ICollection<EstadoEmpleadoModel> objetosReturn = new List<EstadoEmpleadoModel>();
      foreach (EstadoEmpleado objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EstadoEmpleadoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<EstadoEmpleado>> SetEntities() {
      return await db.EstadoEmpleado
        .ToListAsync();
    }

    public async Task<EstadoEmpleado> SetEntity(int id) {
      return await db.EstadoEmpleado
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
