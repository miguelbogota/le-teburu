using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Producto {
    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Estado { get; set; }
    public decimal? MenuId { get; set; }
    public decimal ProveedorId { get; set; }
    public decimal InventarioId { get; set; }

    public virtual Inventario Inventario { get; set; }
    public virtual Menu Menu { get; set; }
    public virtual Proveedor Proveedor { get; set; }
  }
}
