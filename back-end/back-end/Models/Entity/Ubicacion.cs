using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Ubicacion {
    public Ubicacion() {
      DatosPersonales = new HashSet<DatosPersonales>();
      Restaurante = new HashSet<Restaurante>();
    }

    public decimal Id { get; set; }
    public string Direccion { get; set; }
    public string Adiciones { get; set; }
    public decimal CiudadId { get; set; }
    public decimal PaisId { get; set; }

    public virtual Ciudad Ciudad { get; set; }
    public virtual Pais Pais { get; set; }
    public virtual ICollection<DatosPersonales> DatosPersonales { get; set; }
    public virtual ICollection<Restaurante> Restaurante { get; set; }
  }
}
