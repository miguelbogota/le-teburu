using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Genero {
    public Genero() {
      Datos = new HashSet<Datos>();
    }

    public decimal IdGenero { get; set; }
    public string NombreGenero { get; set; }

    public virtual ICollection<Datos> Datos { get; set; }
  }
}
