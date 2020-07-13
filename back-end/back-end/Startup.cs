using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back_end.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using web_api.Functions;

namespace web_api {
  public class Startup {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // Esta funcion es llamada por el runtime. Usar esta funcion para agregar servicios al contenedor
    public void ConfigureServices(IServiceCollection services) {
      services.AddControllers();

      // Usar el contexto de la base de datos para inyectaro en los controladores
      services.AddDbContext<TeburuDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


      // Validacion y crecion del token de autenticacion
      string key = "This my secrect key in order to use for the token... Love u... Salchipapa";
      services.AddAuthentication(x => {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x => {

        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      // Manejar el JWT
      services.AddSingleton<AuthFunction>(new AuthFunction(key));

      // Configurar el CORS en la API
      services.AddMvc(option => option.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

    }

    // Esta funcion es llamada por el runtime. Usar esta funcion para configurar la peticion HHTP pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      // Usare el CORS
      app.UseCors(builder => {
        builder.WithOrigins("http://localhost:3000");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }

  }
}
