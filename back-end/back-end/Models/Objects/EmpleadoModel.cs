using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class EmpleadoModel {

    public int Id { get; set; }
    public string Contrasena { get; set; }
    public CargoModel Cargo { get; set; }
    public DatosPersonalesModel DatosPersonales { get; set; }
    public EstadoEmpleadoModel EstadoEmpleado { get; set; }
    public EmpleadoModel Jefe { get; set; }
    public RestauranteModel Restaurante { get; set; }

  }
}
