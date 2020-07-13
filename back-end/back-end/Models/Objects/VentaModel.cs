using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class VentaModel {

    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Precio { get; set; }
    public decimal Iva { get; set; }
    public EmpleadoModel Empleado { get; set; }
    public EstadoVentaModel EstadoVenta { get; set; }

  }
}
