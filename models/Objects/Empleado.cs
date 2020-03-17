using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Empleado {

    public decimal Id { get; set; }
    public string Clave { get; set; }
    public DateTime FechaContratacion { get; set; }
    public Datos Datos { get; set; }

    public string Rol { get; set; }
    public Sede Sede { get; set; }
    public string Estado { get; set; }

    public Empleado() {
    }

  }
}