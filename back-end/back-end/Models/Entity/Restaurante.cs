using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Restaurante {
    public Restaurante() {
      Empleados = new HashSet<Empleado>();
      Inventario = new HashSet<Inventario>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public TimeSpan HoraApertura { get; set; }
    public TimeSpan HoraCierre { get; set; }
    public decimal EstadoRestauranteId { get; set; }
    public decimal UbicacionId { get; set; }

    public virtual EstadoRestaurante EstadoRestaurante { get; set; }
    public virtual Ubicacion Ubicacion { get; set; }
    public virtual ICollection<Empleado> Empleados { get; set; }
    public virtual ICollection<Inventario> Inventario { get; set; }
  }
}
