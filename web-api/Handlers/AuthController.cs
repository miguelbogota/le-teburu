using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Handlers {

  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase {

    private readonly JwtAuthManager jwtAuthManager;

    // Constructor espera el JWT
    public AuthController(JwtAuthManager jwtAuthManager) {
      this.jwtAuthManager = jwtAuthManager;
    }

    // Funcion returna el web token para autenticar el usuario
    [HttpPost]
    public IActionResult Authenticate([FromBody] Credentials credentials) {
      // Generara token y validar si los datos existen y son corrector
      var token = jwtAuthManager.Authenticate(credentials.Id, credentials.Password);
      // Si no lo son devolver no autorizado
      if (token == null) { return Unauthorized(); }
      // Devolver el token
      return Ok(token);
    }

  }

  // Clase para las credeciales de los usuarios
  public class Credentials {
    // Propiedades
    public decimal Id { get; set; }
    public string Password { get; set; }
  }

}