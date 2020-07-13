using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class UbicacionModel {

    public int Id { get; set; }
    public string Direccion { get; set; }
    public string Adiciones { get; set; }
    public CiudadModel Ciudad { get; set; }
    public PaisModel Pais { get; set; }

  }
}
