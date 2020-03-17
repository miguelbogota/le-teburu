using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Inventario {

    public decimal Id { get; set; }
    public DateTime FechaIngreso { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal Cantidad { get; set; }
    public Producto Producto { get; set; }
    public Sede Sede { get; set; }


    public Inventario() {
    }

  }
}
