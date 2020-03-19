using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class EstadoVenta {
    public EstadoVenta() {
      Ventas = new HashSet<Venta>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; }
  }
}
