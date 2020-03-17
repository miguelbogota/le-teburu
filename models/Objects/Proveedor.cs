using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Proveedor {

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Contacto { get; set; }

    public Proveedor() {
    }

  }
}
