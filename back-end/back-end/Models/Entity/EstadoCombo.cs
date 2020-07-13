using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class EstadoCombo {
    public EstadoCombo() {
      Combos = new HashSet<Combo>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Combo> Combos { get; set; }
  }
}
