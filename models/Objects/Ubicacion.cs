using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Ubicacion {

    public decimal Id { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }

    public Ubicacion() {
    }

  }
}
