using System;
using System.Collections.Generic;
using System.Text;

namespace services.Services {
  public class DBService {

    public readonly DatosService DatosService = new DatosService();
    public readonly EmpleadoService EmpleadoService = new EmpleadoService();
    public readonly InventarioService InventarioService = new InventarioService();
    public readonly MenuService MenuService = new MenuService();
    public readonly PedidoService PedidoService = new PedidoService();
    public readonly ProductoService ProductoService = new ProductoService();
    public readonly ProveedorService ProveedorService = new ProveedorService();
    public readonly SedeService SedeService = new SedeService();
    public readonly UbicacionService UbicacionService = new UbicacionService();
    public readonly VentaService VentaService = new VentaService();

    public DBService() {

    }

  }
}
