using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Sede {
    public Sede() {
      Empleado = new HashSet<Empleado>();
      Inventario = new HashSet<Inventario>();
    }

    public decimal IdSede { get; set; }
    public string NombreSede { get; set; }
    public decimal UbicacionSedeFk { get; set; }

    public virtual Ubicacion UbicacionSedeFkNavigation { get; set; }
    public virtual ICollection<Empleado> Empleado { get; set; }
    public virtual ICollection<Inventario> Inventario { get; set; }
  }
}
