using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Categoria {
    public Categoria() {
      Menu = new HashSet<Menu>();
    }

    public decimal IdCategoria { get; set; }
    public string NombreCategoria { get; set; }

    public virtual ICollection<Menu> Menu { get; set; }
  }
}
