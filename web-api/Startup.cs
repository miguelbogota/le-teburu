using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using web_api.Handlers;

namespace web_api {
  public class Startup {

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Esta funcion es llamada por el runtime. Usar esta funcion para agregar servicios al contenedor
    public void ConfigureServices(IServiceCollection services) {
      services.AddControllers();

      var key = "This is my secret key";
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

      services.AddSingleton<JwtAuthManager>(new JwtAuthManager(key));

      services.AddMvc(option => option.EnableEndpointRouting = false)
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

    }

    // Esta funcion es llamada por el runtime. Usar esta funcion para configurar la peticion HHTP pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

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
