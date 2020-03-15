using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Empleado {
    public Empleado() {
      Venta = new HashSet<Venta>();
    }

    public decimal IdEmpleado { get; set; }
    public string ClaveEmpleado { get; set; }
    public DateTime FechaContrato { get; set; }
    public decimal DatosEmpleadoFk { get; set; }
    public decimal RolEmpleadoFk { get; set; }
    public decimal SedeEmpleadoFk { get; set; }
    public decimal EstadoEmpleadoFk { get; set; }

    public virtual Datos DatosEmpleadoFkNavigation { get; set; }
    public virtual EstadoEmpleado EstadoEmpleadoFkNavigation { get; set; }
    public virtual Rol RolEmpleadoFkNavigation { get; set; }
    public virtual Sede SedeEmpleadoFkNavigation { get; set; }
    public virtual ICollection<Venta> Venta { get; set; }
  }
}
