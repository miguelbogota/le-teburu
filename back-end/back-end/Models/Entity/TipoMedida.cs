using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class TipoMedida {
    public TipoMedida() {
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public string NombreAbbr { get; set; }
    public string NombreCompleto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; }
  }
}
