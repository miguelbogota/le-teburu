using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Datos {
    public Datos() {
      Empleado = new HashSet<Empleado>();
    }

    public decimal Documento { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal Telefono { get; set; }
    public decimal GeneroFk { get; set; }
    public decimal TipoDocumentoFk { get; set; }
    public decimal UbicacionFk { get; set; }

    public virtual Genero GeneroFkNavigation { get; set; }
    public virtual TipoDocumento TipoDocumentoFkNavigation { get; set; }
    public virtual Ubicacion UbicacionFkNavigation { get; set; }
    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
