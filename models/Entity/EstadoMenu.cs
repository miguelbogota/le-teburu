using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class EstadoMenu {
    public EstadoMenu() {
      Menu = new HashSet<Menu>();
    }

    public decimal IdEstadoMenu { get; set; }
    public string NombreEstadoMenu { get; set; }

    public virtual ICollection<Menu> Menu { get; set; }
  }
}
