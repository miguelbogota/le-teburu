using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Empleado {
    public Empleado() {
      Ventas = new HashSet<Venta>();
    }

    public decimal Id { get; set; }
    public string Contrasena { get; set; }
    public string Cargo { get; set; }
    public string EstadoActual { get; set; }
    public decimal Salario { get; set; }
    public string TipoContrato { get; set; }
    public DateTime FechaContratacion { get; set; }
    public decimal PersonaId { get; set; }
    public decimal RestauranteId { get; set; }

    public virtual Persona Persona { get; set; }
    public virtual Restaurante Restaurante { get; set; }
    public virtual ICollection<Venta> Ventas { get; set; }
  }
}
