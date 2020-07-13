using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Contrato {
    public decimal Id { get; set; }
    public DateTime FechaContrato { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime? FechaTerminacion { get; set; }
    public decimal Salario { get; set; }
    public decimal? TipoTerminacionId { get; set; }
    public decimal EmpleadoId { get; set; }

    public virtual Empleado Empleado { get; set; }
    public virtual TipoTerminacion TipoTerminacion { get; set; }
  }
}
