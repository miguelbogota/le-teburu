using System;
using System.Collections.Generic;
using System.Linq;

namespace services.Services {
  public class SedeService {

    public SedeService() {

    }

    // Funcion retorna una sede en especifico
    public models.Objects.Sede Find(decimal id) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Guardar Sede
        models.Objects.Sede sede = ToOb(db.Sede.Find(id));
        // Validar si la sede es valida
        if (sede == null) { return null; }
        return sede;
      }
    }

    // Funcion retorna todas las sedes
    public List<models.Objects.Sede> GetAll() {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Lista a devolver
        List<models.Objects.Sede> sedes = new List<models.Objects.Sede>();
        foreach (var se in db.Sede.ToList()) {
          sedes.Add(ToOb(se));
        }
        return sedes;
      }
    }

    // Funcion convierte un objeto a una entidad de Entity
    public models.Entity.Sede ToEf(models.Objects.Sede sede) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (sede == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Entity.Sede() {
          IdSede = sede.Id,
          NombreSede = sede.Nombre,
          UbicacionSedeFk = sede.Ubicacion.Id
        };
      }
    }

    // Funcion convierte una entidad de Entity a un objeto
    public models.Objects.Sede ToOb(models.Entity.Sede sede) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (sede == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Objects.Sede() {
          Id = sede.IdSede,
          Nombre = sede.NombreSede,
          Ubicacion = new UbicacionService().Find(sede.UbicacionSedeFk)
        };
      }
    }

  }
}
