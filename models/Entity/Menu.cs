using System;
using System.Collections.Generic;

namespace models.Entity {
  public partial class Menu {
    public Menu() {
      Pedido = new HashSet<Pedido>();
      Productos = new HashSet<Producto>();
    }

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Estado { get; set; }
    public decimal CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }
    public virtual ICollection<Pedido> Pedido { get; set; }
    public virtual ICollection<Producto> Productos { get; set; }
  }
}
