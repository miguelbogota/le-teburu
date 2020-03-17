using System;
using System.Collections.Generic;

namespace models.Objects {
  public partial class Menu {

    public decimal Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Producto> Productos { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }
    public string Estado { get; set; }

    public Menu() {
    }

  }
}
