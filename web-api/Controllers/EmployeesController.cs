using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models.Objects;
using services.Services;

namespace web_api.Controllers {

  // Controlador para la ruta de los empleados.
  // Aqui se encontraran todos los metodos de CRUD
  // que se usaran en el frontend.
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase {

    // GET - Ruta      /api/employees
    // Funcion devuelve todos los empleados de la base de datos
    [HttpGet]
    public ActionResult<List<Empleado>> Get() {
      // Devuleve la funcion con todos los empleados
      return new DBService().EmpleadoService.GetAll();
    }

    // GET - Ruta     /api/employees/id
    // Funcion devuelve el empleado con su respectiva id
    [HttpGet("{id}")]
    public ActionResult<Ubicacion> GetItem(decimal id) {
      // Guarda el empleado
      Ubicacion e = new DBService().UbicacionService.Find(id);
      // Valida si el empleado no es null
      if (e == null) { return NotFound(); }
      // Devuelve el empleado
      return e;
    }

  }

}