using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace models.Entity {
  public partial class DBContext : DbContext {
    public DBContext() {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options) {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }
    public virtual DbSet<Ciudad> Ciudad { get; set; }
    public virtual DbSet<Datos> Datos { get; set; }
    public virtual DbSet<Direccion> Direccion { get; set; }
    public virtual DbSet<Empleado> Empleado { get; set; }
    public virtual DbSet<EstadoEmpleado> EstadoEmpleado { get; set; }
    public virtual DbSet<EstadoMenu> EstadoMenu { get; set; }
    public virtual DbSet<EstadoProducto> EstadoProducto { get; set; }
    public virtual DbSet<EstadoVenta> EstadoVenta { get; set; }
    public virtual DbSet<Genero> Genero { get; set; }
    public virtual DbSet<Inventario> Inventario { get; set; }
    public virtual DbSet<Menu> Menu { get; set; }
    public virtual DbSet<Pais> Pais { get; set; }
    public virtual DbSet<Pedido> Pedido { get; set; }
    public virtual DbSet<Producto> Producto { get; set; }
    public virtual DbSet<Proveedor> Proveedor { get; set; }
    public virtual DbSet<Rol> Rol { get; set; }
    public virtual DbSet<Sede> Sede { get; set; }
    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-6I0PPMD\\SQLINSTANCE;Initial Catalog=teburuDB;Integrated Security=True");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Categoria>(entity => {
        entity.HasKey(e => e.IdCategoria)
            .HasName("PK__Categori__A3C02A1084ACD518");

        entity.Property(e => e.IdCategoria)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreCategoria)
            .IsRequired()
            .HasMaxLength(40);
      });

      modelBuilder.Entity<Ciudad>(entity => {
        entity.HasKey(e => e.IdCiudad)
            .HasName("PK__Ciudad__D4D3CCB0BE8E5A9D");

        entity.Property(e => e.IdCiudad)
            .HasColumnType("numeric(4, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreCiudad)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Datos>(entity => {
        entity.HasKey(e => e.Documento)
            .HasName("PK__Datos__AF73706C127CAE01");

        entity.Property(e => e.Documento).HasColumnType("numeric(14, 0)");

        entity.Property(e => e.DireccionFk)
            .HasColumnName("DireccionFK")
            .HasColumnType("numeric(7, 0)");

        entity.Property(e => e.FechaNacimiento).HasColumnType("date");

        entity.Property(e => e.GeneroFk)
            .HasColumnName("GeneroFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Telefono).HasColumnType("numeric(10, 0)");

        entity.Property(e => e.TiposDocumentoFk)
            .HasColumnName("TiposDocumentoFK")
            .HasColumnType("numeric(2, 0)");

        entity.HasOne(d => d.DireccionFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.DireccionFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__Direccion__4BAC3F29");

        entity.HasOne(d => d.GeneroFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.GeneroFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__GeneroFK__49C3F6B7");

        entity.HasOne(d => d.TiposDocumentoFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.TiposDocumentoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__TiposDocu__4AB81AF0");
      });

      modelBuilder.Entity<Direccion>(entity => {
        entity.HasKey(e => e.IdDireccion)
            .HasName("PK__Direccio__1F8E0C7647CCD3D8");

        entity.Property(e => e.IdDireccion)
            .HasColumnType("numeric(7, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CiudadSedeFk)
            .HasColumnName("CiudadSedeFK")
            .HasColumnType("numeric(4, 0)");

        entity.Property(e => e.Direccion1)
            .IsRequired()
            .HasColumnName("Direccion")
            .HasMaxLength(30);

        entity.Property(e => e.PaisSedeFk)
            .HasColumnName("PaisSedeFK")
            .HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.CiudadSedeFkNavigation)
            .WithMany(p => p.Direccion)
            .HasForeignKey(d => d.CiudadSedeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Direccion__Ciuda__4316F928");

        entity.HasOne(d => d.PaisSedeFkNavigation)
            .WithMany(p => p.Direccion)
            .HasForeignKey(d => d.PaisSedeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Direccion__PaisS__440B1D61");
      });

      modelBuilder.Entity<Empleado>(entity => {
        entity.HasKey(e => e.IdEmpleado)
            .HasName("PK__Empleado__CE6D8B9EC305BAC6");

        entity.Property(e => e.IdEmpleado).HasColumnType("numeric(8, 0)");

        entity.Property(e => e.ClaveEmpleado)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.DatosEmpleadoFk)
            .HasColumnName("DatosEmpleadoFK")
            .HasColumnType("numeric(14, 0)");

        entity.Property(e => e.EstadoEmpleadoFk)
            .HasColumnName("EstadoEmpleadoFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.FechaContrato).HasColumnType("datetime");

        entity.Property(e => e.RolEmpleadoFk)
            .HasColumnName("RolEmpleadoFK")
            .HasColumnType("numeric(2, 0)");

        entity.Property(e => e.SedeEmpleadoFk)
            .HasColumnName("SedeEmpleadoFK")
            .HasColumnType("numeric(1, 0)");

        entity.HasOne(d => d.DatosEmpleadoFkNavigation)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.DatosEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__DatosE__4E88ABD4");

        entity.HasOne(d => d.EstadoEmpleadoFkNavigation)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.EstadoEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__Estado__5165187F");

        entity.HasOne(d => d.RolEmpleadoFkNavigation)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.RolEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__RolEmp__4F7CD00D");

        entity.HasOne(d => d.SedeEmpleadoFkNavigation)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.SedeEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__SedeEm__5070F446");
      });

      modelBuilder.Entity<EstadoEmpleado>(entity => {
        entity.HasKey(e => e.IdEstadoEmpleado)
            .HasName("PK__EstadoEm__4ECA3F3323177F87");

        entity.Property(e => e.IdEstadoEmpleado)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoEmpleado)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoMenu>(entity => {
        entity.HasKey(e => e.IdEstadoMenu)
            .HasName("PK__EstadoMe__49521E5066EAF663");

        entity.Property(e => e.IdEstadoMenu)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoMenu)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoProducto>(entity => {
        entity.HasKey(e => e.IdEstadoProducto)
            .HasName("PK__EstadoPr__F02FAF37A61A9F1A");

        entity.Property(e => e.IdEstadoProducto)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoProducto)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoVenta>(entity => {
        entity.HasKey(e => e.IdEstadoVenta)
            .HasName("PK__EstadoVe__777FD960A360AB27");

        entity.Property(e => e.IdEstadoVenta)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoVenta)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<Genero>(entity => {
        entity.HasKey(e => e.IdGenero)
            .HasName("PK__Genero__0F834988F1F89807");

        entity.Property(e => e.IdGenero)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreGenero)
            .IsRequired()
            .HasMaxLength(9);
      });

      modelBuilder.Entity<Inventario>(entity => {
        entity.HasKey(e => e.IdInventario)
            .HasName("PK__Inventar__1927B20CFA214120");

        entity.Property(e => e.IdInventario)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CantidadInventario).HasColumnType("numeric(5, 0)");

        entity.Property(e => e.FechaIngresoInventario).HasColumnType("date");

        entity.Property(e => e.PrecioTotalInventario).HasColumnType("money");

        entity.Property(e => e.ProductoInventarioFk)
            .HasColumnName("ProductoInventarioFK")
            .HasColumnType("numeric(3, 0)");

        entity.Property(e => e.SedeInventarioFk)
            .HasColumnName("SedeInventarioFK")
            .HasColumnType("numeric(1, 0)");

        entity.HasOne(d => d.ProductoInventarioFkNavigation)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.ProductoInventarioFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__Produ__6477ECF3");

        entity.HasOne(d => d.SedeInventarioFkNavigation)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.SedeInventarioFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__SedeI__656C112C");
      });

      modelBuilder.Entity<Menu>(entity => {
        entity.HasKey(e => e.IdMenu)
            .HasName("PK__Menu__4D7EA8E194C89864");

        entity.Property(e => e.IdMenu)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CategoriaMenuFk)
            .HasColumnName("CategoriaMenuFK")
            .HasColumnType("numeric(2, 0)");

        entity.Property(e => e.EstadoMenuFk)
            .HasColumnName("EstadoMenuFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.NombreMenu)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.PrecioMenu).HasColumnType("money");

        entity.HasOne(d => d.CategoriaMenuFkNavigation)
            .WithMany(p => p.Menu)
            .HasForeignKey(d => d.CategoriaMenuFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Menu__CategoriaM__5812160E");

        entity.HasOne(d => d.EstadoMenuFkNavigation)
            .WithMany(p => p.Menu)
            .HasForeignKey(d => d.EstadoMenuFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Menu__EstadoMenu__59063A47");
      });

      modelBuilder.Entity<Pais>(entity => {
        entity.HasKey(e => e.IdPais)
            .HasName("PK__Pais__FC850A7B1EFFC29D");

        entity.Property(e => e.IdPais)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombrePais)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Pedido>(entity => {
        entity.HasKey(e => e.IdPedido)
            .HasName("PK__Pedido__9D335DC3D96B1958");

        entity.Property(e => e.IdPedido)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CantidadPedido).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.MenuPedidoFk)
            .HasColumnName("MenuPedidoFK")
            .HasColumnType("numeric(2, 0)");

        entity.Property(e => e.PrecioTotalPedido).HasColumnType("money");

        entity.Property(e => e.VentaPedidoFk)
            .HasColumnName("VentaPedidoFK")
            .HasColumnType("numeric(6, 0)");

        entity.HasOne(d => d.MenuPedidoFkNavigation)
            .WithMany(p => p.Pedido)
            .HasForeignKey(d => d.MenuPedidoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Pedido__MenuPedi__6E01572D");

        entity.HasOne(d => d.VentaPedidoFkNavigation)
            .WithMany(p => p.Pedido)
            .HasForeignKey(d => d.VentaPedidoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Pedido__VentaPed__6EF57B66");
      });

      modelBuilder.Entity<Producto>(entity => {
        entity.HasKey(e => e.IdProducto)
            .HasName("PK__Producto__09889210ACAE6778");

        entity.Property(e => e.IdProducto)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.EstadoProductoFk)
            .HasColumnName("EstadoProductoFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.MenuFk)
            .HasColumnName("MenuFK")
            .HasColumnType("numeric(2, 0)");

        entity.Property(e => e.NombreProducto)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.PrecioProducto).HasColumnType("money");

        entity.Property(e => e.ProveedorProductoFk)
            .HasColumnName("ProveedorProductoFK")
            .HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.EstadoProductoFkNavigation)
            .WithMany(p => p.Producto)
            .HasForeignKey(d => d.EstadoProductoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__Estado__60A75C0F");

        entity.HasOne(d => d.MenuFkNavigation)
            .WithMany(p => p.Producto)
            .HasForeignKey(d => d.MenuFk)
            .HasConstraintName("FK__Producto__MenuFK__619B8048");

        entity.HasOne(d => d.ProveedorProductoFkNavigation)
            .WithMany(p => p.Producto)
            .HasForeignKey(d => d.ProveedorProductoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__Provee__5FB337D6");
      });

      modelBuilder.Entity<Proveedor>(entity => {
        entity.HasKey(e => e.IdProveedor)
            .HasName("PK__Proveedo__E8B631AF068847DD");

        entity.Property(e => e.IdProveedor).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.ContactoProveedor).HasColumnType("numeric(10, 0)");

        entity.Property(e => e.NombreProveedor)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Rol>(entity => {
        entity.HasKey(e => e.IdRol)
            .HasName("PK__Rol__2A49584C8D466467");

        entity.Property(e => e.IdRol)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreRol)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Sede>(entity => {
        entity.HasKey(e => e.IdSede)
            .HasName("PK__Sede__A7780DFFAF30B7BC");

        entity.Property(e => e.IdSede)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.DireccionSedeFk)
            .HasColumnName("DireccionSedeFK")
            .HasColumnType("numeric(7, 0)");

        entity.Property(e => e.NombreSede)
            .IsRequired()
            .HasMaxLength(40);

        entity.HasOne(d => d.DireccionSedeFkNavigation)
            .WithMany(p => p.Sede)
            .HasForeignKey(d => d.DireccionSedeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Sede__DireccionS__46E78A0C");
      });

      modelBuilder.Entity<TipoDocumento>(entity => {
        entity.HasKey(e => e.IdTipoDocumento)
            .HasName("PK__TipoDocu__3AB3332FCFF56A61");

        entity.Property(e => e.IdTipoDocumento)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreTipoDocumento)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Venta>(entity => {
        entity.HasKey(e => e.IdVenta)
            .HasName("PK__Venta__BC1240BD7EEB2E71");

        entity.Property(e => e.IdVenta)
            .HasColumnType("numeric(6, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.EmpleadoVentaFk)
            .HasColumnName("EmpleadoVentaFK")
            .HasColumnType("numeric(8, 0)");

        entity.Property(e => e.EstadoVentaFk)
            .HasColumnName("EstadoVentaFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.FechaVenta).HasColumnType("date");

        entity.Property(e => e.PrecioTotalVenta).HasColumnType("money");

        entity.HasOne(d => d.EmpleadoVentaFkNavigation)
            .WithMany(p => p.Venta)
            .HasForeignKey(d => d.EmpleadoVentaFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EmpleadoV__6A30C649");

        entity.HasOne(d => d.EstadoVentaFkNavigation)
            .WithMany(p => p.Venta)
            .HasForeignKey(d => d.EstadoVentaFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EstadoVen__6B24EA82");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
