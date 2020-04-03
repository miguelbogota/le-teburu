using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace front_end {

  public class Startup {

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Esta funcion es llamada por el runtime. Usar esta funcion para agregar servicios al contenedor
    public void ConfigureServices(IServiceCollection services) {

      services.AddControllersWithViews();

      // En produccion, los archivos de React se guardaran en el direcorio.
      services.AddSpaStaticFiles(configuration => {
        configuration.RootPath = "ClientApp/build";
      });
    }

    // Esta funcion es llamada por el runtime. Usar esta funcion para configurar la peticion HHTP pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      else {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
      });

      app.UseSpa(spa => {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment()) {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });

    }

  }

}
