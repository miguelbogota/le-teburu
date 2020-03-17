using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Pedido {

    public decimal Id { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }
    public Menu Menu { get; set; }
    public Venta Venta { get; set; }

    public Pedido() {
    }

  }
}
