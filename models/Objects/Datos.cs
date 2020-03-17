using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Datos {

    public decimal Documento { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal Telefono { get; set; }

    public string Genero { get; set; }
    public string TipoDocumento { get; set; }
    public Ubicacion Ubicacion { get; set; }

    public Datos() {
    }

  }
}
