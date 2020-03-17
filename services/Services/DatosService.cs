using System;
using System.Collections.Generic;
using System.Linq;

namespace services.Services {
  public class DatosService {

    public DatosService() {

    }

    // Funcion retorna datos en especifico
    public models.Objects.Datos Find(decimal id) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Guardar Datos
        models.Objects.Datos datos = ToOb(db.Datos.Find(id));
        // Validar si la datos es valida
        if (datos == null) { return null; }
        return datos;
      }
    }

    // Funcion retorna todos los datos
    public List<models.Objects.Datos> GetAll() {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Lista a devolver
        List<models.Objects.Datos> datos = new List<models.Objects.Datos>();
        foreach (var da in db.Datos.ToList()) {
          datos.Add(ToOb(da));
        }
        return datos;
      }
    }

    // Funcion convierte un objeto a una entidad de Entity
    public models.Entity.Datos ToEf(models.Objects.Datos datos) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (datos == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Entity.Datos() {
          Documento = datos.Documento,
          Nombre = datos.Nombre,
          FechaNacimiento = datos.FechaNacimiento,
          Telefono = datos.Telefono,
          GeneroFk = db.Genero.Where(g => g.NombreGenero == datos.Genero).First().IdGenero,
          TipoDocumentoFk = db.TipoDocumento.Where(t => t.NombreTipoDocumento == datos.TipoDocumento).First().IdTipoDocumento,
          UbicacionFk = datos.Ubicacion.Id
        };
      }
    }

    // Funcion convierte una entidad de Entity a un objeto
    public models.Objects.Datos ToOb(models.Entity.Datos datos) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (datos == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Objects.Datos() {
          Documento = datos.Documento,
          Nombre = datos.Nombre,
          FechaNacimiento = datos.FechaNacimiento,
          Telefono = datos.Telefono,
          Genero = db.Genero.Find(datos.GeneroFk).NombreGenero,
          TipoDocumento = db.TipoDocumento.Find(datos.TipoDocumentoFk).NombreTipoDocumento,
          Ubicacion = new UbicacionService().Find(datos.UbicacionFk)
        };
      }
    }

  }
}
