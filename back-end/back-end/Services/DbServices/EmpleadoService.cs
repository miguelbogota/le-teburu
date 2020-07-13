using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class EmpleadoService : IDbService<Empleado, EmpleadoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public EmpleadoService(TeburuDBContext db) { this.db = db; }

    public async Task<EmpleadoModel> Add(EmpleadoModel objeto) {
      db.Empleado.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<EmpleadoModel> Delete(int id) {
      Empleado objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      EmpleadoModel objetoModel = ToObject(objetoEntity);
      db.Empleado.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<EmpleadoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Empleado objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<EmpleadoModel>> GetAll() {
      ICollection<EmpleadoModel> objetosModel = new List<EmpleadoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Empleado> objetosEntity = await SetEntities();

      foreach (Empleado objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Empleado ToEntity(EmpleadoModel objeto) {
      if (objeto == null) { return null; }
      return new Empleado() {
        Id = Convert.ToDecimal(objeto.Id),
        Contrasena = objeto.Contrasena,
        Cargo = new CargoService(db).ToEntity(objeto.Cargo),
        DatosPersonales = new DatosPersonalesService(db).ToEntity(objeto.DatosPersonales),
        EstadoEmpleado = new EstadoEmpleadoService(db).ToEntity(objeto.EstadoEmpleado),
        Jefe = new Empleado() { Id = Convert.ToDecimal(objeto.Jefe.Id) },
        Restaurante = new RestauranteService(db).ToEntity(objeto.Restaurante)
      };
    }

    public ICollection<Empleado> ToEntity(ICollection<EmpleadoModel> objetos) {
      ICollection<Empleado> objetosReturn = new List<Empleado>();
      foreach (EmpleadoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public EmpleadoModel ToObject(Empleado objeto) {
      if (objeto == null) { return null; }
      return new EmpleadoModel() {
        Id = Convert.ToInt32(objeto.Id),
        Contrasena = objeto.Contrasena,
        Cargo = new CargoService(db).ToObject(objeto.Cargo),
        DatosPersonales = new DatosPersonalesService(db).ToObject(objeto.DatosPersonales),
        EstadoEmpleado = new EstadoEmpleadoService(db).ToObject(objeto.EstadoEmpleado),
        Jefe = new EmpleadoModel() { Id = Convert.ToInt32(objeto.JefeId) },
        Restaurante = new RestauranteService(db).ToObject(objeto.Restaurante)
      };
    }

    public ICollection<EmpleadoModel> ToObject(ICollection<Empleado> objetos) {
      ICollection<EmpleadoModel> objetosReturn = new List<EmpleadoModel>();
      foreach (Empleado objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(EmpleadoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Empleado>> SetEntities() {
      return await db.Empleado
        .Include(e => e.DatosPersonales)
        .Include(e => e.EstadoEmpleado)
        .Include(e => e.Cargo)
        .Include(e => e.Restaurante)
        .ToListAsync();
    }

    public async Task<Empleado> SetEntity(int id) {
      return await db.Empleado
        .Include(e => e.DatosPersonales)
        .Include(e => e.EstadoEmpleado)
        .Include(e => e.Cargo)
        .Include(e => e.Restaurante)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
