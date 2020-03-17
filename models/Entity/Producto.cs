using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Producto {
    public Producto() {
      Inventario = new HashSet<Inventario>();
    }

    public decimal IdProducto { get; set; }
    public string NombreProducto { get; set; }
    public decimal PrecioProducto { get; set; }
    public decimal ProveedorProductoFk { get; set; }
    public decimal EstadoProductoFk { get; set; }
    public decimal? MenuFk { get; set; }

    public virtual EstadoProducto EstadoProductoFkNavigation { get; set; }
    public virtual Menu MenuFkNavigation { get; set; }
    public virtual Proveedor ProveedorProductoFkNavigation { get; set; }
    public virtual ICollection<Inventario> Inventario { get; set; }
  }
}
