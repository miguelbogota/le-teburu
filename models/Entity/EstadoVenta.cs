using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class EstadoVenta {
    public EstadoVenta() {
      Venta = new HashSet<Venta>();
    }

    public decimal IdEstadoVenta { get; set; }
    public string NombreEstadoVenta { get; set; }

    public virtual ICollection<Venta> Venta { get; set; }
  }
}
