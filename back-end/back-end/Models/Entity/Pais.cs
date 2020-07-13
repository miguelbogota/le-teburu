using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Pais {
    public Pais() {
      Ubicaciones = new HashSet<Ubicacion>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }

    public virtual ICollection<Ubicacion> Ubicaciones { get; set; }
  }
}
