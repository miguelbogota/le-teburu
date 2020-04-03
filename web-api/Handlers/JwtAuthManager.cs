using Microsoft.IdentityModel.Tokens;
using models.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace web_api.Handlers {
  public class JwtAuthManager {

    private readonly string key; // Key del token

    // Constructor con key
    public JwtAuthManager(string key) {
      this.key = key;
    }

    // Funcion autentica el usuario y devuelve el JWT
    public string Authenticate(decimal id, string password) {
      // Usar db para buscar el usuario y contraseña
      using (TeburuDBContext db = new TeburuDBContext()) {
        // Validacion si el usuario no existe o la contraseña no es la correcta y devolver null
        if (!db.Empleado.Any(u => u.Id == id && u.Contrasena == password)) { return null; }
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
}
