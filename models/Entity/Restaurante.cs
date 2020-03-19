using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Restaurante {
    public Restaurante() {
      Empleados = new HashSet<Empleado>();
      Inventario = new HashSet<Inventario>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Telefono { get; set; }
    public TimeSpan HoraApertura { get; set; }
    public TimeSpan HoraCierre { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; }
    public virtual ICollection<Inventario> Inventario { get; set; }
  }
}
