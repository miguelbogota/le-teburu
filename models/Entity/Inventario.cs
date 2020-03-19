using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Inventario {
    public Inventario() {
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public DateTime FechaIngreso { get; set; }
    public decimal PrecioTotal { get; set; }
    public decimal Cantidad { get; set; }
    public decimal RestauranteId { get; set; }

    public virtual Restaurante Restaurante { get; set; }
    public virtual ICollection<Producto> Productos { get; set; }
  }
}
