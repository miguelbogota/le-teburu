using System;
using System.Collections.Generic;
using System.Linq;

namespace services.Services {
  public class UbicacionService {

    public UbicacionService() {

    }

    // Funcion retorna una ubicacion en especifico
    public models.Objects.Ubicacion Find(decimal id) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Guardar ubicacion
        models.Objects.Ubicacion ubicacion = ToOb(db.Ubicacion.Find(id));
        // Validar si la ubicacion es valida
        if (ubicacion == null) { return null; }
        return ubicacion;
      }
    }

    // Funcion retorna todas las ubicaciones
    public List<models.Objects.Ubicacion> GetAll() {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Lista a devolver
        List<models.Objects.Ubicacion> ubicaciones = new List<models.Objects.Ubicacion>();
        foreach (var ub in db.Ubicacion.ToList()) {
          ubicaciones.Add(ToOb(ub));
        }
        return ubicaciones;
      }
    }

    // Funcion convierte un objeto a una entidad de Entity
    public models.Entity.Ubicacion ToEf(models.Objects.Ubicacion ubicacion) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (ubicacion == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Entity.Ubicacion() {
          IdUbicacion = ubicacion.Id,
          DireccionUbicacion = ubicacion.Direccion,
          CiudadUbicacionFk = db.Ciudad.Where(c => c.NombreCiudad == ubicacion.Ciudad).First().IdCiudad,
          PaisUbicacionFk = db.Pais.Where(p => p.NombrePais == ubicacion.Pais).First().IdPais
        };
      }
    }

    // Funcion convierte una entidad de Entity a un objeto
    public models.Objects.Ubicacion ToOb(models.Entity.Ubicacion ubicacion) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (ubicacion == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Objects.Ubicacion() {
          Id = ubicacion.IdUbicacion,
          Direccion = ubicacion.DireccionUbicacion,
          Ciudad = db.Ciudad.Find(ubicacion.CiudadUbicacionFk).NombreCiudad,
          Pais = db.Pais.Find(ubicacion.PaisUbicacionFk).NombrePais
        };
      }
    }

  }
}
