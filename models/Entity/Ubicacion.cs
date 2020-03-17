using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Ubicacion {
    public Ubicacion() {
      Datos = new HashSet<Datos>();
      Sede = new HashSet<Sede>();
    }

    public decimal IdUbicacion { get; set; }
    public string DireccionUbicacion { get; set; }
    public decimal CiudadUbicacionFk { get; set; }
    public decimal PaisUbicacionFk { get; set; }

    public virtual Ciudad CiudadUbicacionFkNavigation { get; set; }
    public virtual Pais PaisUbicacionFkNavigation { get; set; }
    public virtual ICollection<Datos> Datos { get; set; }
    public virtual ICollection<Sede> Sede { get; set; }
  }
}
