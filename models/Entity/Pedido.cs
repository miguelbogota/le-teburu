using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Pedido {
    public decimal IdPedido { get; set; }
    public decimal CantidadPedido { get; set; }
    public decimal PrecioTotalPedido { get; set; }
    public decimal MenuPedidoFk { get; set; }
    public decimal VentaPedidoFk { get; set; }

    public virtual Menu MenuPedidoFkNavigation { get; set; }
    public virtual Venta VentaPedidoFkNavigation { get; set; }
  }
}
