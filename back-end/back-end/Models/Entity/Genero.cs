using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Genero {
    public Genero() {
      DatosPersonales = new HashSet<DatosPersonales>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }

    public virtual ICollection<DatosPersonales> DatosPersonales { get; set; }
  }
}
