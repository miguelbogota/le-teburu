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
    public decimal TiposDocumentoFk { get; set; }
    public decimal DireccionFk { get; set; }

    public virtual Direccion DireccionFkNavigation { get; set; }
    public virtual Genero GeneroFkNavigation { get; set; }
    public virtual TipoDocumento TiposDocumentoFkNavigation { get; set; }
    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
