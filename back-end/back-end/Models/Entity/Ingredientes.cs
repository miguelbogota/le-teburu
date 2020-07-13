using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Ingredientes {
    public decimal Id { get; set; }
    public decimal Cantidad { get; set; }
    public string ProductoId { get; set; }
    public string MenuId { get; set; }

    public virtual Menu Menu { get; set; }
    public virtual Producto Producto { get; set; }
  }
}
