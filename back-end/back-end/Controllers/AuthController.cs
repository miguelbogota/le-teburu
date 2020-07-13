using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Functions;

namespace web_api.Controllers {

  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase {

    private readonly AuthFunction authFunction;

    // Constructor espera el JWT
    public AuthController(AuthFunction authFunction) {
      this.authFunction = authFunction;
    }

    // Funcion returna el web token para autenticar el usuario
    [HttpPost]
    public IActionResult SignIn([FromBody] Credentials credentials) {
      // Generara token y validar si los datos existen y son corrector
      string token = authFunction.GetToken(credentials.Id, credentials.Contrasena);
      // Si no lo son devolver no autorizado
      if (token == null) { return Unauthorized(); }
      // Devolver el token
      return Ok(new { Token = token });
    }

  }

  // Clase para las credeciales de los usuarios
  public class Credentials {
    // Propiedades
    public int Id { get; set; }
    public string Contrasena { get; set; }
  }

}