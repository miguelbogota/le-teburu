using System;
using System.Collections.Generic;
using System.Linq;

namespace services.Services {
  public class EmpleadoService {

    public EmpleadoService() {

    }

    // Funcion retorna un empleado en especifico
    public models.Objects.Empleado Find(decimal id) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Guardar Empleado
        models.Objects.Empleado empleado = ToOb(db.Empleado.Find(id));
        // Validar si la datos es valida
        if (empleado == null) { return null; }
        return empleado;
      }
    }

    // Funcion retorna todos los empleados
    public List<models.Objects.Empleado> GetAll() {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Lista a devolver
        List<models.Objects.Empleado> empleados = new List<models.Objects.Empleado>();
        foreach (var em in db.Empleado.ToList()) {
          empleados.Add(ToOb(em));
        }
        return empleados;
      }
    }

    // Funcion convierte un objeto a una entidad de Entity
    public models.Entity.Empleado ToEf(models.Objects.Empleado empleado) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (empleado == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Entity.Empleado() {
          IdEmpleado = empleado.Id,
          ClaveEmpleado = empleado.Clave,
          FechaContratoEmpleado = empleado.FechaContratacion,
          DatosEmpleadoFk = db.Datos.Where(d => d.Documento == empleado.Datos.Documento).First().Documento,
          RolEmpleadoFk = db.Rol.Where(r => r.NombreRol == empleado.Rol).First().IdRol,
          SedeEmpleadoFk =  empleado.Sede.Id,
          EstadoEmpleadoFk = db.EstadoEmpleado.Where(e => e.NombreEstadoEmpleado == empleado.Estado).First().IdEstadoEmpleado
        };
      }
    }

    // Funcion convierte una entidad de Entity a un objeto
    public models.Objects.Empleado ToOb(models.Entity.Empleado empleado) {
      // Usar base de datos
      using (models.Entity.DBContext db = new models.Entity.DBContext()) {
        // Validar
        if (empleado == null) { return null; }
        // Creacion de la entidad y devolver
        return new models.Objects.Empleado() {
          Id = empleado.IdEmpleado,
          Clave = empleado.ClaveEmpleado,
          FechaContratacion = empleado.FechaContratoEmpleado,
          Datos = new DatosService().Find(empleado.DatosEmpleadoFk),
          Rol = db.Rol.Find(empleado.RolEmpleadoFk).NombreRol,
          Sede = new SedeService().Find(empleado.SedeEmpleadoFk),
          Estado = db.EstadoEmpleado.Find(empleado.EstadoEmpleadoFk).NombreEstadoEmpleado
        };
      }
    }

  }
}