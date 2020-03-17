using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Rol {
    public Rol() {
      Empleado = new HashSet<Empleado>();
    }

    public decimal IdRol { get; set; }
    public string NombreRol { get; set; }

    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
