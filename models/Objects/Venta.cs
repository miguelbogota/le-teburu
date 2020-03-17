using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Venta {

    public decimal Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public Empleado Empleado { get; set; }
    public string Estado { get; set; }

    public Venta() {
    }

  }
}
