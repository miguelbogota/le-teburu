using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Venta {
    public Venta() {
      Pedidos = new HashSet<Pedido>();
    }

    public decimal Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Precio { get; set; }
    public decimal Iva { get; set; }
    public decimal EmpleadoId { get; set; }
    public decimal EstadoVentaId { get; set; }

    public virtual Empleado Empleado { get; set; }
    public virtual EstadoVenta EstadoVenta { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }
  }
}
