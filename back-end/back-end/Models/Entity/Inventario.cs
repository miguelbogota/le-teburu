using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Inventario {
    public decimal Id { get; set; }
    public DateTime FechaEntrada { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }
    public string ProductoId { get; set; }
    public decimal RestauranteId { get; set; }

    public virtual Producto Producto { get; set; }
    public virtual Restaurante Restaurante { get; set; }
  }
}
