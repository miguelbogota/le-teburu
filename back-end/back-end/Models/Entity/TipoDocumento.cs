using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class TipoDocumento {
    public TipoDocumento() {
      DatosPersonales = new HashSet<DatosPersonales>();
    }

    public decimal Id { get; set; }
    public string NombreAbbr { get; set; }
    public string NombreCompleto { get; set; }

    public virtual ICollection<DatosPersonales> DatosPersonales { get; set; }
  }
}
