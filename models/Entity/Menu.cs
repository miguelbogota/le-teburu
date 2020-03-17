using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Menu {
    public Menu() {
      Pedido = new HashSet<Pedido>();
      Producto = new HashSet<Producto>();
    }

    public decimal IdMenu { get; set; }
    public string NombreMenu { get; set; }
    public decimal PrecioMenu { get; set; }
    public decimal CategoriaMenuFk { get; set; }
    public decimal EstadoMenuFk { get; set; }

    public virtual Categoria CategoriaMenuFkNavigation { get; set; }
    public virtual EstadoMenu EstadoMenuFkNavigation { get; set; }
    public virtual ICollection<Pedido> Pedido { get; set; }
    public virtual ICollection<Producto> Producto { get; set; }
  }
}
