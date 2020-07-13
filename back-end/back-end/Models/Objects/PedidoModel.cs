using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class PedidoModel {

    public int Codigo { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }
    public ComboModel Combo { get; set; }
    public MenuModel Menu { get; set; }
    public VentaModel Venta { get; set; }

  }
}
