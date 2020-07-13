using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Functions;
using back_end.Models.Objects;
using back_end.Services.DbServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class EmpleadosController : ControllerBase {

    // Propiedad de la base de datos
    private readonly Models.TeburuDBContext db;

    // Contructor con dependencia a la db
    public EmpleadosController(Models.TeburuDBContext db) { this.db = db; }

    [HttpGet]
    public async Task<ICollection<EmpleadoModel>> GetEmpleados() {
      return await new EmpleadosFunction(db).GetEmpleados();
    }

    [HttpGet("{id}")]
    public async Task<EmpleadoModel> GetEmpleado(int id) {
      return await new EmpleadosFunction(db).GetEmpleado(id);
    }

    [HttpPost]
    public void PostEmpleado([FromBody] string value) {
    }

    [HttpPut("{id}")]
    public void PutEmpleado(int id, [FromBody] string value) {
    }

    [HttpDelete("{id}")]
    public void DeleteEmpleado(int id) {
    }

    

  }
}
