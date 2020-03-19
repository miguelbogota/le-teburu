using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Persona {
    public Persona() {
      Empleado = new HashSet<Empleado>();
    }

    public decimal Documento { get; set; }
    public string TipoDocumento { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Genero { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public decimal Telefono { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }

    public virtual ICollection<Empleado> Empleado { get; set; }
  }
}
