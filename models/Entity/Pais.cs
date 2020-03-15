using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Pais {
    public Pais() {
      Direccion = new HashSet<Direccion>();
    }

    public decimal IdPais { get; set; }
    public string NombrePais { get; set; }

    public virtual ICollection<Direccion> Direccion { get; set; }
  }
}
