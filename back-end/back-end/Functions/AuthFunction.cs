using System;
using System.Linq;
using System.Text;
using back_end.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using back_end.Models.Objects;

namespace web_api.Functions {
  public class AuthFunction {

    private readonly string key; // Key del token

    // Constructor con key
    public AuthFunction(string key) {
      this.key = key;
    }

    // Funcion para autenticar si un empleado tiene las credeciales correctas
    public bool CheckAuth(int id, string contrasena) {
      // Usar db para buscar el usuario y contraseña
      using (TeburuDBContext db = new TeburuDBContext()) {
        return db.Empleado.Any(u => u.Id == Convert.ToDecimal(id) && u.Contrasena == contrasena) ? true : false;
      }
    }

    // Funcion autentica el usuario y devuelve el JWT
    public string GetToken(int id, string contrasena) {
      // Validacion si el usuario no existe o la contraseña no es la correcta y devolver null
      if (!CheckAuth(id, contrasena)) { return null; }
      // De otra manera crear el token y devolverlo
      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenKey = Encoding.ASCII.GetBytes(key);
      var tokenDescriptor = new SecurityTokenDescriptor {
        Subject = new ClaimsIdentity(new Claim[] {
          new Claim(ClaimTypes.Name, id.ToString())
        }),
        Expires = DateTime.UtcNow.AddHours(8),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
      };
      // Obtener el token
      var token = tokenHandler.CreateToken(tokenDescriptor);
      // Devolver el token generado
      return tokenHandler.WriteToken(token);
    }

  }
}
