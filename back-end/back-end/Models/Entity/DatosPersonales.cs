using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class DatosPersonales {
    public DatosPersonales() {
      Empleado = new HashSet<Empleado>();
    }

    public decimal Documento { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public decimal GeneroId { get; set; }
    public decimal TipoDocumentoId { get; set; }
    public decimal UbicacionId { get; set; }

    public virtual Genero Genero { get; set; }
    public virtual TipoDocumento TipoDocumento { get; set; }
    public virtual Ubicacion Ubicacion { get; set; }
    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
