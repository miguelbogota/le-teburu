using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class TipoDocumento {
    public TipoDocumento() {
      Datos = new HashSet<Datos>();
    }

    public decimal IdTipoDocumento { get; set; }
    public string NombreTipoDocumento { get; set; }

    public virtual ICollection<Datos> Datos { get; set; }
  }
}
