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
    public virtual DbSet<Ubicacion> Ubicacion { get; set; }
    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-6I0PPMD\\SQLINSTANCE;Initial Catalog=teburuDB;Integrated Security=True");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Categoria>(entity => {
        entity.HasKey(e => e.IdCategoria)
            .HasName("PK__Categori__A3C02A109B359D7A");

        entity.Property(e => e.IdCategoria)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreCategoria)
            .IsRequired()
            .HasMaxLength(40);
      });

      modelBuilder.Entity<Ciudad>(entity => {
        entity.HasKey(e => e.IdCiudad)
            .HasName("PK__Ciudad__D4D3CCB015758056");

        entity.Property(e => e.IdCiudad)
            .HasColumnType("numeric(4, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreCiudad)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Datos>(entity => {
        entity.HasKey(e => e.Documento)
            .HasName("PK__Datos__AF73706C84B6B212");

        entity.Property(e => e.Documento).HasColumnType("numeric(14, 0)");

        entity.Property(e => e.FechaNacimiento).HasColumnType("date");

        entity.Property(e => e.GeneroFk)
            .HasColumnName("GeneroFK")
            .HasColumnType("numeric(1, 0)");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Telefono).HasColumnType("numeric(10, 0)");

        entity.Property(e => e.TipoDocumentoFk)
            .HasColumnName("TipoDocumentoFK")
            .HasColumnType("numeric(2, 0)");

        entity.Property(e => e.UbicacionFk)
            .HasColumnName("UbicacionFK")
            .HasColumnType("numeric(7, 0)");

        entity.HasOne(d => d.GeneroFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.GeneroFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__GeneroFK__49C3F6B7");

        entity.HasOne(d => d.TipoDocumentoFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.TipoDocumentoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__TipoDocum__4AB81AF0");

        entity.HasOne(d => d.UbicacionFkNavigation)
            .WithMany(p => p.Datos)
            .HasForeignKey(d => d.UbicacionFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Datos__Ubicacion__4BAC3F29");
      });

      modelBuilder.Entity<Empleado>(entity => {
        entity.HasKey(e => e.IdEmpleado)
            .HasName("PK__Empleado__CE6D8B9E6D49F727");

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

        entity.Property(e => e.FechaContratoEmpleado).HasColumnType("datetime");

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
            .HasName("PK__EstadoEm__4ECA3F3368AB50DC");

        entity.Property(e => e.IdEstadoEmpleado)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoEmpleado)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoMenu>(entity => {
        entity.HasKey(e => e.IdEstadoMenu)
            .HasName("PK__EstadoMe__49521E500AE2FC5F");

        entity.Property(e => e.IdEstadoMenu)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoMenu)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoProducto>(entity => {
        entity.HasKey(e => e.IdEstadoProducto)
            .HasName("PK__EstadoPr__F02FAF37A01F9529");

        entity.Property(e => e.IdEstadoProducto)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoProducto)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<EstadoVenta>(entity => {
        entity.HasKey(e => e.IdEstadoVenta)
            .HasName("PK__EstadoVe__777FD96034D76CEE");

        entity.Property(e => e.IdEstadoVenta)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreEstadoVenta)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<Genero>(entity => {
        entity.HasKey(e => e.IdGenero)
            .HasName("PK__Genero__0F834988BF1FFF4C");

        entity.Property(e => e.IdGenero)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreGenero)
            .IsRequired()
            .HasMaxLength(9);
      });

      modelBuilder.Entity<Inventario>(entity => {
        entity.HasKey(e => e.IdInventario)
            .HasName("PK__Inventar__1927B20CD276F135");

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
            .HasName("PK__Menu__4D7EA8E1D4DEA30A");

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
            .HasName("PK__Pais__FC850A7B8A77F4F8");

        entity.Property(e => e.IdPais)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombrePais)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Pedido>(entity => {
        entity.HasKey(e => e.IdPedido)
            .HasName("PK__Pedido__9D335DC3770FC774");

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
            .HasName("PK__Producto__09889210DE7E886C");

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
            .HasName("PK__Proveedo__E8B631AF645E9A13");

        entity.Property(e => e.IdProveedor).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.ContactoProveedor).HasColumnType("numeric(10, 0)");

        entity.Property(e => e.NombreProveedor)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Rol>(entity => {
        entity.HasKey(e => e.IdRol)
            .HasName("PK__Rol__2A49584C5C59007A");

        entity.Property(e => e.IdRol)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreRol)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Sede>(entity => {
        entity.HasKey(e => e.IdSede)
            .HasName("PK__Sede__A7780DFFDF953CC1");

        entity.Property(e => e.IdSede)
            .HasColumnType("numeric(1, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreSede)
            .IsRequired()
            .HasMaxLength(40);

        entity.Property(e => e.UbicacionSedeFk)
            .HasColumnName("UbicacionSedeFK")
            .HasColumnType("numeric(7, 0)");

        entity.HasOne(d => d.UbicacionSedeFkNavigation)
            .WithMany(p => p.Sede)
            .HasForeignKey(d => d.UbicacionSedeFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Sede__UbicacionS__46E78A0C");
      });

      modelBuilder.Entity<TipoDocumento>(entity => {
        entity.HasKey(e => e.IdTipoDocumento)
            .HasName("PK__TipoDocu__3AB3332FD6E65D4D");

        entity.Property(e => e.IdTipoDocumento)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreTipoDocumento)
            .IsRequired()
            .HasMaxLength(30);
      });

      modelBuilder.Entity<Ubicacion>(entity => {
        entity.HasKey(e => e.IdUbicacion)
            .HasName("PK__Ubicacio__778CAB1D5438FAD5");

        entity.Property(e => e.IdUbicacion)
            .HasColumnType("numeric(7, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CiudadUbicacionFk)
            .HasColumnName("CiudadUbicacionFK")
            .HasColumnType("numeric(4, 0)");

        entity.Property(e => e.DireccionUbicacion)
            .IsRequired()
            .HasMaxLength(30);

        entity.Property(e => e.PaisUbicacionFk)
            .HasColumnName("PaisUbicacionFK")
            .HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.CiudadUbicacionFkNavigation)
            .WithMany(p => p.Ubicacion)
            .HasForeignKey(d => d.CiudadUbicacionFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ubicacion__Ciuda__4316F928");

        entity.HasOne(d => d.PaisUbicacionFkNavigation)
            .WithMany(p => p.Ubicacion)
            .HasForeignKey(d => d.PaisUbicacionFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ubicacion__PaisU__440B1D61");
      });

      modelBuilder.Entity<Venta>(entity => {
        entity.HasKey(e => e.IdVenta)
            .HasName("PK__Venta__BC1240BD53C7D693");

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
