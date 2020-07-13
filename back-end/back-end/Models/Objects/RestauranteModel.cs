using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class RestauranteModel {

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public TimeSpan HoraApertura { get; set; }
    public TimeSpan HoraCierre { get; set; }
    public EstadoRestauranteModel EstadoRestaurante { get; set; }
    public UbicacionModel Ubicacion { get; set; }

  }
}
