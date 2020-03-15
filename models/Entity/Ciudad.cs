using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Ciudad {
    public Ciudad() {
      Direccion = new HashSet<Direccion>();
    }

    public decimal IdCiudad { get; set; }
    public string NombreCiudad { get; set; }

    public virtual ICollection<Direccion> Direccion { get; set; }
  }
}
