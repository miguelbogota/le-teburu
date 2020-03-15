using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Venta {
    public Venta() {
      Pedido = new HashSet<Pedido>();
    }

    public decimal IdVenta { get; set; }
    public DateTime FechaVenta { get; set; }
    public decimal PrecioTotalVenta { get; set; }
    public decimal EmpleadoVentaFk { get; set; }
    public decimal EstadoVentaFk { get; set; }

    public virtual Empleado EmpleadoVentaFkNavigation { get; set; }
    public virtual EstadoVenta EstadoVentaFkNavigation { get; set; }
    public virtual ICollection<Pedido> Pedido { get; set; }
  }
}
