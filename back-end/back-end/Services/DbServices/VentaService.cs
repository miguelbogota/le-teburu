using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class VentaService : IDbService<Venta, VentaModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public VentaService(TeburuDBContext db) { this.db = db; }

    public async Task<VentaModel> Add(VentaModel objeto) {
      db.Venta.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<VentaModel> Delete(int id) {
      Venta objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      VentaModel objetoModel = ToObject(objetoEntity);
      db.Venta.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<VentaModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Venta objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<VentaModel>> GetAll() {
      ICollection<VentaModel> objetosModel = new List<VentaModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Venta> objetosEntity = await SetEntities();

      foreach (Venta objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Venta ToEntity(VentaModel objeto) {
      if (objeto == null) { return null; }
      return new Venta() {
        Codigo = Convert.ToDecimal(objeto.Codigo),
        Fecha = objeto.Fecha,
        Precio = objeto.Precio,
        Iva = objeto.Iva,
        Empleado = new EmpleadoService(db).ToEntity(objeto.Empleado),
        EstadoVenta = new EstadoVentaService(db).ToEntity(objeto.EstadoVenta)
      };
    }

    public ICollection<Venta> ToEntity(ICollection<VentaModel> objetos) {
      ICollection<Venta> objetosReturn = new List<Venta>();
      foreach (VentaModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public VentaModel ToObject(Venta objeto) {
      if (objeto == null) { return null; }
      return new VentaModel() {
        Codigo = Convert.ToInt32(objeto.Codigo),
        Fecha = objeto.Fecha,
        Precio = objeto.Precio,
        Iva = objeto.Iva,
        Empleado = new EmpleadoService(db).ToObject(objeto.Empleado),
        EstadoVenta = new EstadoVentaService(db).ToObject(objeto.EstadoVenta)
      };
    }

    public ICollection<VentaModel> ToObject(ICollection<Venta> objetos) {
      ICollection<VentaModel> objetosReturn = new List<VentaModel>();
      foreach (Venta objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(VentaModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Venta>> SetEntities() {
      return await db.Venta
        .Include(e => e.Empleado)
        .Include(e => e.EstadoVenta)
        .ToListAsync();
    }

    public async Task<Venta> SetEntity(int id) {
      return await db.Venta
        .Include(e => e.Empleado)
        .Include(e => e.EstadoVenta)
        .Where(e => e.Codigo == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
