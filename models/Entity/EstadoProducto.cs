using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class EstadoProducto {
    public EstadoProducto() {
      Producto = new HashSet<Producto>();
    }

    public decimal IdEstadoProducto { get; set; }
    public string NombreEstadoProducto { get; set; }

    public virtual ICollection<Producto> Producto { get; set; }
  }
}
