using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class EstadoRestaurante {
    public EstadoRestaurante() {
      Restaurantes = new HashSet<Restaurante>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual ICollection<Restaurante> Restaurantes { get; set; }
  }
}
