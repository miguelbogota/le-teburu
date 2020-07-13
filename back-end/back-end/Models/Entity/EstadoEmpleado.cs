using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class EstadoEmpleado {
    public EstadoEmpleado() {
      Empleados = new HashSet<Empleado>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; }
  }
}
