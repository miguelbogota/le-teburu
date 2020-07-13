using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Empleado {
    public Empleado() {
      Contratos = new HashSet<Contrato>();
      Empleados = new HashSet<Empleado>();
      Ventas = new HashSet<Venta>();
    }

    public decimal Id { get; set; }
    public string Contrasena { get; set; }
    public decimal DatosPersonalesId { get; set; }
    public decimal EstadoEmpleadoId { get; set; }
    public decimal CargoId { get; set; }
    public decimal RestauranteId { get; set; }
    public decimal? JefeId { get; set; }

    public virtual Cargo Cargo { get; set; }
    public virtual DatosPersonales DatosPersonales { get; set; }
    public virtual EstadoEmpleado EstadoEmpleado { get; set; }
    public virtual Empleado Jefe { get; set; }
    public virtual Restaurante Restaurante { get; set; }
    public virtual ICollection<Contrato> Contratos { get; set; }
    public virtual ICollection<Empleado> Empleados { get; set; }
    public virtual ICollection<Venta> Ventas { get; set; }
  }
}
