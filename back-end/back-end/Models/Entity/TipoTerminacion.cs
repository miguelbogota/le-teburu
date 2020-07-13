using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class TipoTerminacion {
    public TipoTerminacion() {
      Contratos = new HashSet<Contrato>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; }
  }
}
