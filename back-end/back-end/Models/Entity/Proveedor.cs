using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Proveedor {
    public Proveedor() {
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public string NombreCompania { get; set; }
    public string NombreContacto { get; set; }
    public string Telefono { get; set; }

    public virtual ICollection<Producto> Productos { get; set; }
  }
}
