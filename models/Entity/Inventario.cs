using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Inventario {
    public decimal IdInventario { get; set; }
    public DateTime FechaIngresoInventario { get; set; }
    public decimal PrecioTotalInventario { get; set; }
    public decimal CantidadInventario { get; set; }
    public decimal ProductoInventarioFk { get; set; }
    public decimal SedeInventarioFk { get; set; }

    public virtual Producto ProductoInventarioFkNavigation { get; set; }
    public virtual Sede SedeInventarioFkNavigation { get; set; }
  }
}
