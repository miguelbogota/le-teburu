using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Ciudad {
    public Ciudad() {
      Ubicacion = new HashSet<Ubicacion>();
    }

    public decimal IdCiudad { get; set; }
    public string NombreCiudad { get; set; }

    public virtual ICollection<Ubicacion> Ubicacion { get; set; }
  }
}
