using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class IngredientesModel {

    public int Id { get; set; }
    public decimal Cantidad { get; set; }
    public MenuModel Menu { get; set; }
    public ProductoModel Producto { get; set; }

  }
}
