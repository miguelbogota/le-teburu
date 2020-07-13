using System;
using System.Collections.Generic;

namespace back_end.Models.Entity {
  public partial class Combo {
    public Combo() {
      Menus = new HashSet<Menu>();
      Pedidos = new HashSet<Pedido>();
    }

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string ImgUrl { get; set; }
    public decimal EstadoComboId { get; set; }

    public virtual EstadoCombo EstadoCombo { get; set; }
    public virtual ICollection<Menu> Menus { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }
  }
}
