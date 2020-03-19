using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Proveedor {
    public Proveedor() {
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; }
  }
}
