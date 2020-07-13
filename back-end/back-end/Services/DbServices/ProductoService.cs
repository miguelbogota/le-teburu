using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class ProductoService : IDbService<Producto, ProductoModel, string> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public ProductoService(TeburuDBContext db) { this.db = db; }

    public async Task<ProductoModel> Add(ProductoModel objeto) {
      db.Producto.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<ProductoModel> Delete(string id) {
      Producto objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      ProductoModel objetoModel = ToObject(objetoEntity);
      db.Producto.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<ProductoModel> Get(string id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Producto objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<ProductoModel>> GetAll() {
      ICollection<ProductoModel> objetosModel = new List<ProductoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Producto> objetosEntity = await SetEntities();

      foreach (Producto objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Producto ToEntity(ProductoModel objeto) {
      if (objeto == null) { return null; }
      return new Producto() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Precio = objeto.Precio,
        FechaVencimiento = objeto.FechaVencimiento,
        TipoMedida = new TipoMedidaService(db).ToEntity(objeto.TipoMedida),
        EstadoProducto = new EstadoProductoService(db).ToEntity(objeto.EstadoProducto),
        Proveedor = new ProveedorService(db).ToEntity(objeto.Proveedor)
      };
    }

    public ICollection<Producto> ToEntity(ICollection<ProductoModel> objetos) {
      ICollection<Producto> objetosReturn = new List<Producto>();
      foreach (ProductoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public ProductoModel ToObject(Producto objeto) {
      if (objeto == null) { return null; }
      return new ProductoModel() {
        Codigo = objeto.Codigo,
        Nombre = objeto.Nombre,
        Precio = objeto.Precio,
        FechaVencimiento = objeto.FechaVencimiento,
        TipoMedida = new TipoMedidaService(db).ToObject(objeto.TipoMedida),
        EstadoProducto = new EstadoProductoService(db).ToObject(objeto.EstadoProducto),
        Proveedor = new ProveedorService(db).ToObject(objeto.Proveedor)
      };
    }

    public ICollection<ProductoModel> ToObject(ICollection<Producto> objetos) {
      ICollection<ProductoModel> objetosReturn = new List<ProductoModel>();
      foreach (Producto objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(ProductoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Producto>> SetEntities() {
      return await db.Producto
        .Include(e => e.TipoMedida)
        .Include(e => e.EstadoProducto)
        .Include(e => e.Proveedor)
        .ToListAsync();
    }

    public async Task<Producto> SetEntity(string id) {
      return await db.Producto
        .Include(e => e.TipoMedida)
        .Include(e => e.EstadoProducto)
        .Include(e => e.Proveedor)
        .Where(e => e.Codigo == id)
        .FirstAsync();
    }

  }
}
