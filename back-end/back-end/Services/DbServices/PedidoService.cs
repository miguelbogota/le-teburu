using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class PedidoService : IDbService<Pedido, PedidoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public PedidoService(TeburuDBContext db) { this.db = db; }

    public async Task<PedidoModel> Add(PedidoModel objeto) {
      db.Pedido.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<PedidoModel> Delete(int id) {
      Pedido objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      PedidoModel objetoModel = ToObject(objetoEntity);
      db.Pedido.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<PedidoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      Pedido objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<PedidoModel>> GetAll() {
      ICollection<PedidoModel> objetosModel = new List<PedidoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<Pedido> objetosEntity = await SetEntities();

      foreach (Pedido objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public Pedido ToEntity(PedidoModel objeto) {
      if (objeto == null) { return null; }
      return new Pedido() {
        Codigo = Convert.ToDecimal(objeto.Codigo),
        Cantidad = objeto.Cantidad,
        Precio = objeto.Precio,
        Menu = new MenuService(db).ToEntity(objeto.Menu),
        Combo = new ComboService(db).ToEntity(objeto.Combo),
        Venta = new VentaService(db).ToEntity(objeto.Venta)
      };
    }

    public ICollection<Pedido> ToEntity(ICollection<PedidoModel> objetos) {
      ICollection<Pedido> objetosReturn = new List<Pedido>();
      foreach (PedidoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public PedidoModel ToObject(Pedido objeto) {
      if (objeto == null) { return null; }
      return new PedidoModel() {
        Codigo = Convert.ToInt32(objeto.Codigo),
        Cantidad = objeto.Cantidad,
        Precio = objeto.Precio,
        Menu = new MenuService(db).ToObject(objeto.Menu),
        Combo = new ComboService(db).ToObject(objeto.Combo),
        Venta = new VentaService(db).ToObject(objeto.Venta)
      };
    }

    public ICollection<PedidoModel> ToObject(ICollection<Pedido> objetos) {
      ICollection<PedidoModel> objetosReturn = new List<PedidoModel>();
      foreach (Pedido objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(PedidoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<Pedido>> SetEntities() {
      return await db.Pedido
        .Include(e => e.Menu)
        .Include(e => e.Combo)
        .Include(e => e.Venta)
        .ToListAsync();
    }

    public async Task<Pedido> SetEntity(int id) {
      return await db.Pedido
        .Include(e => e.Menu)
        .Include(e => e.Combo)
        .Include(e => e.Venta)
        .Where(e => e.Codigo == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
