using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Producto {
    public Producto() {
      Ingredientes = new HashSet<Ingredientes>();
      Inventario = new HashSet<Inventario>();
    }

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public decimal TipoMedidaId { get; set; }
    public decimal EstadoProductoId { get; set; }
    public decimal ProveedorId { get; set; }

    public virtual EstadoProducto EstadoProducto { get; set; }
    public virtual Proveedor Proveedor { get; set; }
    public virtual TipoMedida TipoMedida { get; set; }
    public virtual ICollection<Ingredientes> Ingredientes { get; set; }
    public virtual ICollection<Inventario> Inventario { get; set; }
  }
}
