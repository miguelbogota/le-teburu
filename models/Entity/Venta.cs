using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Venta {
    public Venta() {
      Pedidos = new HashSet<Pedido>();
    }

    public decimal Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal EmpleadoId { get; set; }
    public decimal EstadoId { get; set; }

    public virtual Empleado Empleado { get; set; }
    public virtual EstadoVenta Estado { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }
  }
}
