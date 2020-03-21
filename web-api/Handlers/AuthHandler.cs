using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace web_api.Handlers {
  public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions> {

    // Constructor
    public AuthHandler(
      IOptionsMonitor<AuthenticationSchemeOptions> options,
      ILoggerFactory logger,
      UrlEncoder encoder,
      ISystemClock clock
    ) : base(options, logger, encoder, clock) {

    }

    // Funcion para autenticar a un usuario que intente usar el API
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {

      // Validar si se envio la autorizacion
      if (!Request.Headers.ContainsKey("Authorization")) {
        return AuthenticateResult.Fail("Authorization header was not found");
      }

      var authHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
      var bytes = Convert.FromBase64String(authHeaderValue.Parameter);
      string credentials = Encoding.UTF8.GetString(bytes);

      return AuthenticateResult.Fail("Need implementation");
    }

  }
}
