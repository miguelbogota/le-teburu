using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class EstadoProducto {
    public EstadoProducto() {
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; }
  }
}
