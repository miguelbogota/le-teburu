using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class InventarioModel {

    public int Id { get; set; }
    public DateTime FechaEntrada { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }
    public ProductoModel Producto { get; set; }
    public RestauranteModel Restaurante { get; set; }

  }
}
