using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using back_end.Models.Objects;
using back_end.Models.Entity;

namespace back_end.Services.DbServices {
  public class TipoDocumentoService : IDbService<TipoDocumento, TipoDocumentoModel, int> {

    // Propiedad de la base de datos
    private readonly TeburuDBContext db;

    // Contructor con dependencia a la db
    public TipoDocumentoService(TeburuDBContext db) { this.db = db; }

    public async Task<TipoDocumentoModel> Add(TipoDocumentoModel objeto) {
      db.TipoDocumento.Add(ToEntity(objeto));
      await db.SaveChangesAsync();
      return objeto;
    }

    public async Task<TipoDocumentoModel> Delete(int id) {
      TipoDocumento objetoEntity = await SetEntity(id);
      if (objetoEntity == null) { return null; }
      TipoDocumentoModel objetoModel = ToObject(objetoEntity);
      db.TipoDocumento.Remove(objetoEntity);
      await db.SaveChangesAsync();
      return objetoModel;
    }

    public async Task<TipoDocumentoModel> Get(int id) {
      // Objeto desde la db con las tablas necesarias a mapear
      TipoDocumento objetoDb = await SetEntity(id);
      return ToObject(objetoDb);
    }

    public async Task<ICollection<TipoDocumentoModel>> GetAll() {
      ICollection<TipoDocumentoModel> objetosModel = new List<TipoDocumentoModel>();
      // Objetos desde la db con las tablas necesarias a mapear
      ICollection<TipoDocumento> objetosEntity = await SetEntities();

      foreach (TipoDocumento objeto in objetosEntity) { objetosModel.Add(ToObject(objeto)); }
      return objetosModel;
    }

    public TipoDocumento ToEntity(TipoDocumentoModel objeto) {
      if (objeto == null) { return null; }
      return new TipoDocumento() {
        Id = Convert.ToDecimal(objeto.Id),
        NombreAbbr = objeto.NombreAbbr,
        NombreCompleto = objeto.NombreCompleto
      };
    }

    public ICollection<TipoDocumento> ToEntity(ICollection<TipoDocumentoModel> objetos) {
      ICollection<TipoDocumento> objetosReturn = new List<TipoDocumento>();
      foreach (TipoDocumentoModel objeto in objetos) { objetosReturn.Add(ToEntity(objeto)); }
      return objetosReturn;
    }

    public TipoDocumentoModel ToObject(TipoDocumento objeto) {
      if (objeto == null) { return null; }
      return new TipoDocumentoModel() {
        Id = Convert.ToInt32(objeto.Id),
        NombreAbbr = objeto.NombreAbbr,
        NombreCompleto = objeto.NombreCompleto
      };
    }

    public ICollection<TipoDocumentoModel> ToObject(ICollection<TipoDocumento> objetos) {
      ICollection<TipoDocumentoModel> objetosReturn = new List<TipoDocumentoModel>();
      foreach (TipoDocumento objeto in objetos) { objetosReturn.Add(ToObject(objeto)); }
      return objetosReturn;
    }

    public async Task Update(TipoDocumentoModel objeto) {
      db.Entry(ToEntity(objeto)).State = EntityState.Modified;
      await db.SaveChangesAsync();
    }

    public async Task<ICollection<TipoDocumento>> SetEntities() {
      return await db.TipoDocumento
        .ToListAsync();
    }

    public async Task<TipoDocumento> SetEntity(int id) {
      return await db.TipoDocumento
        .Where(e => e.Id == Convert.ToDecimal(id))
        .FirstAsync();
    }

  }
}
