using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class ContratoService : IDbService<Contrato, ContratoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public ContratoService(TeburuDBContext db) { this.db = db; }

    public async Task<ContratoModel> Add(ContratoModel objeto) {
      db.Contrato.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<ContratoModel> Delete(int id) {
      Contrato objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      ContratoModel objetoModel = ToObject(objetoEntity);
      db.Contrato.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<ContratoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Contrato objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<ContratoModel>> GetAll() {
      ICollection<ContratoModel> objetosModel = new List<ContratoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Contrato> objetosEntity = await SetEntities();

      foreach (Contrato objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Contrato ToEntity(ContratoModel objeto) {
      if (objeto == null) { return null; }
      return new Contrato() {
        Id = Convert.ToDecimal(objeto.Id),
        FechaContrato = objeto.FechaContrato,
        FechaIngreso = objeto.FechaIngreso,
        FechaTerminacion = objeto.FechaTerminacion,
        Salario = objeto.Salario,
        Empleado = new EmpleadoService(db).ToEntity(objeto.Empleado),
        TipoTerminacion = new TipoTerminacionService(db).ToEntity(objeto.TipoTerminacion)
      };
    }

    public ICollection<Contrato> ToEntity(ICollection<ContratoModel> objetos) {
      ICollection<Contrato> objetosReturn = new List<Contrato>();
      foreach (ContratoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public ContratoModel ToObject(Contrato objeto) {
      if (objeto == null) { return null; }
      return new ContratoModel() {
        Id = Convert.ToInt32(objeto.Id),
        FechaContrato = objeto.FechaContrato,
        FechaIngreso = objeto.FechaIngreso,
        FechaTerminacion = objeto.FechaTerminacion,
        Salario = objeto.Salario,
        Empleado = new EmpleadoService(db).ToObject(objeto.Empleado),
        TipoTerminacion = new TipoTerminacionService(db).ToObject(objeto.TipoTerminacion)
      };
    }

    public ICollection<ContratoModel> ToObject(ICollection<Contrato> objetos) {
      ICollection<ContratoModel> objetosReturn = new List<ContratoModel>();
      foreach (Contrato objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(ContratoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Contrato>> SetEntities() {
      return await db.Contrato
        .Include(e => e.Empleado)
        .Include(e => e.TipoTerminacion)
        .ToListAsync();
    }

    public async Task<Contrato> SetEntity(int id) {
      return await db.Contrato
        .Include(e => e.Empleado)
        .Include(e => e.TipoTerminacion)
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
