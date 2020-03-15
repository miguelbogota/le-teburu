using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Direccion {
    public Direccion() {
      Datos = new HashSet<Datos>();
      Sede = new HashSet<Sede>();
    }

    public decimal IdDireccion { get; set; }
    public string Direccion1 { get; set; }
    public decimal CiudadSedeFk { get; set; }
    public decimal PaisSedeFk { get; set; }

    public virtual Ciudad CiudadSedeFkNavigation { get; set; }
    public virtual Pais PaisSedeFkNavigation { get; set; }
    public virtual ICollection<Datos> Datos { get; set; }
    public virtual ICollection<Sede> Sede { get; set; }
  }
}
