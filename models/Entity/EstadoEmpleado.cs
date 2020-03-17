using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class EstadoEmpleado {
    public EstadoEmpleado() {
      Empleado = new HashSet<Empleado>();
    }

    public decimal IdEstadoEmpleado { get; set; }
    public string NombreEstadoEmpleado { get; set; }

    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
