using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Pedido {
    public decimal Codigo { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }
    public string MenuId { get; set; }
    public string ComboId { get; set; }
    public decimal VentaId { get; set; }

    public virtual Combo Combo { get; set; }
    public virtual Menu Menu { get; set; }
    public virtual Venta Venta { get; set; }
  }
}
