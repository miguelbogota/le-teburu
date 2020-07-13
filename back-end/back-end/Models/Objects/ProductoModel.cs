using System;
using System.Collections.Generic;

namespace back_end.Models.Objects {
  public partial class ProductoModel {

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public EstadoProductoModel EstadoProducto { get; set; }
    public ProveedorModel Proveedor { get; set; }
    public TipoMedidaModel TipoMedida { get; set; }

  }
}
