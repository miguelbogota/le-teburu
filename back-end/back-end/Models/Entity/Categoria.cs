using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Categoria {
    public Categoria() {
      Menus = new HashSet<Menu>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Menu> Menus { get; set; }
  }
}
