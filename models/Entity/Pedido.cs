using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Pedido {
    public decimal Id { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal? Descuento { get; set; }
    public decimal MenuId { get; set; }
    public decimal VentaId { get; set; }

    public virtual Menu Menu { get; set; }
    public virtual Venta Venta { get; set; }
  }
}
