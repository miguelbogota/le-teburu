using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class DatosPersonalesModel {

    public int Documento { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public GeneroModel Genero { get; set; }
    public TipoDocumentoModel TipoDocumento { get; set; }
    public UbicacionModel Ubicacion { get; set; }

  }
}
