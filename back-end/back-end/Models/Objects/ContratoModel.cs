using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class ContratoModel {

    public int Id { get; set; }
    public DateTime FechaContrato { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime? FechaTerminacion { get; set; }
    public decimal Salario { get; set; }
    public EmpleadoModel Empleado { get; set; }
    public TipoTerminacionModel TipoTerminacion { get; set; }

  }
}
