using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Inventario {
    public decimal Id { get; set; }
    public DateTime FechaIngreso { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal Cantidad { get; set; }
    public decimal ProductoId { get; set; }
    public decimal RestauranteId { get; set; }

    public virtual Producto Producto { get; set; }
    public virtual Restaurante Restaurante { get; set; }
  }
}
