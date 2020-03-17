using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Sede {

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public Ubicacion Ubicacion { get; set; }

    public Sede() {
    }

  }
}
