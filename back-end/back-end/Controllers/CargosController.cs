using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models.Objects;
using back_end.Services.DbServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class CargosController : ControllerBase {

    // Propiedad de la base de datos
    private readonly Models.TeburuDBContext db;

    // Contructor con dependencia a la db
    public CargosController(Models.TeburuDBContext db) { this.db = db; }

    [HttpGet]
    public async Task<ICollection<CargoModel>> GetCargos() {
      return await new CargoService(db).GetAll();
    }

  }
}
