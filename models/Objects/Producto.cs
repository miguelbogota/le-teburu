using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Producto {

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public Proveedor Proveedor { get; set; }
    public string Estado { get; set; }

    public Producto() {
    }

  }
}
