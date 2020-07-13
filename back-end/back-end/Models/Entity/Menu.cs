using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Menu {
    public Menu() {
      Ingredientes = new HashSet<Ingredientes>();
      Pedidos = new HashSet<Pedido>();
    }

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string ImgUrl { get; set; }
    public decimal EstadoMenuId { get; set; }
    public decimal CategoriaId { get; set; }
    public string ComboId { get; set; }

    public virtual Categoria Categoria { get; set; }
    public virtual Combo Combo { get; set; }
    public virtual EstadoMenu EstadoMenu { get; set; }
    public virtual ICollection<Ingredientes> Ingredientes { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }
  }
}
