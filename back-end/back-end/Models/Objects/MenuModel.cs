using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class MenuModel {

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string ImgUrl { get; set; }
    public CategoriaModel Categoria { get; set; }
    public ComboModel Combo { get; set; }
    public EstadoMenuModel EstadoMenu { get; set; }

  }
}
