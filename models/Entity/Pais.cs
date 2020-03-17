using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Pais {
    public Pais() {
      Ubicacion = new HashSet<Ubicacion>();
    }

    public decimal IdPais { get; set; }
    public string NombrePais { get; set; }

    public virtual ICollection<Ubicacion> Ubicacion { get; set; }
  }
}
