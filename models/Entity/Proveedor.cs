using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Proveedor {
    public Proveedor() {
      Producto = new HashSet<Producto>();
    }

    public decimal IdProveedor { get; set; }
    public string NombreProveedor { get; set; }
    public decimal ContactoProveedor { get; set; }

    public virtual ICollection<Producto> Producto { get; set; }
  }
}
