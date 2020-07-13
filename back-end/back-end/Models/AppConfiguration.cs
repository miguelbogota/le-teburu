using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace back_end.Models {
  public class AppConfiguration {

    public string SqlConnectionString { get; set; }

    // Constructor
    public AppConfiguration() {
      var configBuilder = new ConfigurationBuilder();
      string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
      configBuilder.AddJsonFile(path, false);
      var root = configBuilder.Build();
      var appsettings = root.GetSection("ConnectionStrings:DefaultConnection");
      SqlConnectionString = appsettings.Value;
    }

  }
}
