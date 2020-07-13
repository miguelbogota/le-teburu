using System;
using back_end.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back_end.Models {
  public partial class TeburuDBContext : DbContext {

    // Propiedades
    public virtual DbSet<Cargo> Cargo { get; set; }
    public virtual DbSet<Categoria> Categoria { get; set; }
    public virtual DbSet<Ciudad> Ciudad { get; set; }
    public virtual DbSet<Combo> Combo { get; set; }
    public virtual DbSet<Contrato> Contrato { get; set; }
    public virtual DbSet<DatosPersonales> DatosPersonales { get; set; }
    public virtual DbSet<Empleado> Empleado { get; set; }
    public virtual DbSet<EstadoCombo> EstadoCombo { get; set; }
    public virtual DbSet<EstadoEmpleado> EstadoEmpleado { get; set; }
    public virtual DbSet<EstadoMenu> EstadoMenu { get; set; }
    public virtual DbSet<EstadoProducto> EstadoProducto { get; set; }
    public virtual DbSet<EstadoRestaurante> EstadoRestaurante { get; set; }
    public virtual DbSet<EstadoVenta> EstadoVenta { get; set; }
    public virtual DbSet<Genero> Genero { get; set; }
    public virtual DbSet<Ingredientes> Ingredientes { get; set; }
    public virtual DbSet<Inventario> Inventario { get; set; }
    public virtual DbSet<Menu> Menu { get; set; }
    public virtual DbSet<Pais> Pais { get; set; }
    public virtual DbSet<Pedido> Pedido { get; set; }
    public virtual DbSet<Producto> Producto { get; set; }
    public virtual DbSet<Proveedor> Proveedor { get; set; }
    public virtual DbSet<Restaurante> Restaurante { get; set; }
    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
    public virtual DbSet<TipoMedida> TipoMedida { get; set; }
    public virtual DbSet<TipoTerminacion> TipoTerminacion { get; set; }
    public virtual DbSet<Ubicacion> Ubicacion { get; set; }
    public virtual DbSet<Venta> Venta { get; set; }

    // Contructores
    public TeburuDBContext() { }
    public TeburuDBContext(DbContextOptions<TeburuDBContext> options) : base(options) {}

    // Funcion de configuracion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) { optionsBuilder.UseSqlServer(new AppConfiguration().SqlConnectionString); }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Cargo>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(40);
      });

      modelBuilder.Entity<Categoria>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Ciudad>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);
      });

      modelBuilder.Entity<Combo>(entity => {
        entity.HasKey(e => e.Codigo)
            .HasName("PK__Combo__06370DADC0BCD889");

        entity.Property(e => e.Codigo).HasMaxLength(5);

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(250);

        entity.Property(e => e.EstadoComboId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.ImgUrl)
            .IsRequired()
            .HasMaxLength(2100);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.HasOne(d => d.EstadoCombo)
            .WithMany(p => p.Combos)
            .HasForeignKey(d => d.EstadoComboId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Combo__EstadoCom__6477ECF3");
      });

      modelBuilder.Entity<Contrato>(entity => {
        entity.Property(e => e.Id).HasColumnType("numeric(6, 0)");

        entity.Property(e => e.EmpleadoId).HasColumnType("numeric(9, 0)");

        entity.Property(e => e.FechaContrato).HasColumnType("datetime");

        entity.Property(e => e.FechaIngreso).HasColumnType("date");

        entity.Property(e => e.FechaTerminacion).HasColumnType("datetime");

        entity.Property(e => e.Salario).HasColumnType("money");

        entity.Property(e => e.TipoTerminacionId).HasColumnType("numeric(2, 0)");

        entity.HasOne(d => d.Empleado)
            .WithMany(p => p.Contratos)
            .HasForeignKey(d => d.EmpleadoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Contrato__Emplea__5DCAEF64");

        entity.HasOne(d => d.TipoTerminacion)
            .WithMany(p => p.Contratos)
            .HasForeignKey(d => d.TipoTerminacionId)
            .HasConstraintName("FK__Contrato__TipoTe__5CD6CB2B");
      });

      modelBuilder.Entity<DatosPersonales>(entity => {
        entity.HasKey(e => e.Documento)
            .HasName("PK__DatosPer__AF73706C4D07075D");

        entity.Property(e => e.Documento).HasColumnType("numeric(20, 0)");

        entity.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Correo)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.FechaNacimiento).HasColumnType("date");

        entity.Property(e => e.GeneroId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Telefono)
            .IsRequired()
            .HasMaxLength(20);

        entity.Property(e => e.TipoDocumentoId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.UbicacionId).HasColumnType("numeric(5, 0)");

        entity.HasOne(d => d.Genero)
            .WithMany(p => p.DatosPersonales)
            .HasForeignKey(d => d.GeneroId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__DatosPers__Gener__440B1D61");

        entity.HasOne(d => d.TipoDocumento)
            .WithMany(p => p.DatosPersonales)
            .HasForeignKey(d => d.TipoDocumentoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__DatosPers__TipoD__44FF419A");

        entity.HasOne(d => d.Ubicacion)
            .WithMany(p => p.DatosPersonales)
            .HasForeignKey(d => d.UbicacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__DatosPers__Ubica__45F365D3");
      });

      modelBuilder.Entity<Empleado>(entity => {
        entity.Property(e => e.Id).HasColumnType("numeric(9, 0)");

        entity.Property(e => e.CargoId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.Contrasena)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.DatosPersonalesId).HasColumnType("numeric(20, 0)");

        entity.Property(e => e.EstadoEmpleadoId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.JefeId).HasColumnType("numeric(9, 0)");

        entity.Property(e => e.RestauranteId).HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.Cargo)
            .WithMany(p => p.Empleados)
            .HasForeignKey(d => d.CargoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__CargoI__5441852A");

        entity.HasOne(d => d.DatosPersonales)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.DatosPersonalesId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__DatosP__52593CB8");

        entity.HasOne(d => d.EstadoEmpleado)
            .WithMany(p => p.Empleados)
            .HasForeignKey(d => d.EstadoEmpleadoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__Estado__534D60F1");

        entity.HasOne(d => d.Jefe)
            .WithMany(p => p.Empleados)
            .HasForeignKey(d => d.JefeId)
            .HasConstraintName("FK__Empleado__JefeId__5629CD9C");

        entity.HasOne(d => d.Restaurante)
            .WithMany(p => p.Empleados)
            .HasForeignKey(d => d.RestauranteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__Restau__5535A963");
      });

      modelBuilder.Entity<EstadoCombo>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<EstadoEmpleado>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<EstadoMenu>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<EstadoProducto>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<EstadoRestaurante>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<EstadoVenta>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Genero>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Ingredientes>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Cantidad).HasColumnType("numeric(5, 0)");

        entity.Property(e => e.MenuId)
            .IsRequired()
            .HasMaxLength(5);

        entity.Property(e => e.ProductoId)
            .IsRequired()
            .HasMaxLength(5);

        entity.HasOne(d => d.Menu)
            .WithMany(p => p.Ingredientes)
            .HasForeignKey(d => d.MenuId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ingredien__MenuI__7B5B524B");

        entity.HasOne(d => d.Producto)
            .WithMany(p => p.Ingredientes)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ingredien__Produ__7A672E12");
      });

      modelBuilder.Entity<Inventario>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Cantidad).HasColumnType("numeric(9, 0)");

        entity.Property(e => e.FechaEntrada).HasColumnType("datetime");

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.Property(e => e.ProductoId)
            .IsRequired()
            .HasMaxLength(5);

        entity.Property(e => e.RestauranteId).HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.Producto)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__Produ__7E37BEF6");

        entity.HasOne(d => d.Restaurante)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.RestauranteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__Resta__7F2BE32F");
      });

      modelBuilder.Entity<Menu>(entity => {
        entity.HasKey(e => e.Codigo)
            .HasName("PK__Menu__06370DAD77B2F5C2");

        entity.Property(e => e.Codigo).HasMaxLength(5);

        entity.Property(e => e.CategoriaId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.ComboId).HasMaxLength(5);

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.EstadoMenuId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.ImgUrl)
            .IsRequired()
            .HasMaxLength(2100);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.HasOne(d => d.Categoria)
            .WithMany(p => p.Menus)
            .HasForeignKey(d => d.CategoriaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Menu__CategoriaI__6B24EA82");

        entity.HasOne(d => d.Combo)
            .WithMany(p => p.Menus)
            .HasForeignKey(d => d.ComboId)
            .HasConstraintName("FK__Menu__ComboId__6C190EBB");

        entity.HasOne(d => d.EstadoMenu)
            .WithMany(p => p.Menus)
            .HasForeignKey(d => d.EstadoMenuId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Menu__EstadoMenu__6A30C649");
      });

      modelBuilder.Entity<Pais>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);
      });

      modelBuilder.Entity<Pedido>(entity => {
        entity.HasKey(e => e.Codigo)
            .HasName("PK__Pedido__06370DAD8551E7A8");

        entity.Property(e => e.Codigo)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Cantidad).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.ComboId).HasMaxLength(5);

        entity.Property(e => e.MenuId).HasMaxLength(5);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.Property(e => e.VentaId).HasColumnType("numeric(5, 0)");

        entity.HasOne(d => d.Combo)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.ComboId)
            .HasConstraintName("FK__Pedido__ComboId__0A9D95DB");

        entity.HasOne(d => d.Menu)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.MenuId)
            .HasConstraintName("FK__Pedido__MenuId__09A971A2");

        entity.HasOne(d => d.Venta)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Pedido__VentaId__0B91BA14");
      });

      modelBuilder.Entity<Producto>(entity => {
        entity.HasKey(e => e.Codigo)
            .HasName("PK__Producto__06370DAD6086639E");

        entity.Property(e => e.Codigo).HasMaxLength(5);

        entity.Property(e => e.EstadoProductoId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.FechaVencimiento).HasColumnType("date");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.Property(e => e.ProveedorId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.TipoMedidaId).HasColumnType("numeric(2, 0)");

        entity.HasOne(d => d.EstadoProducto)
            .WithMany(p => p.Productos)
            .HasForeignKey(d => d.EstadoProductoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__Estado__76969D2E");

        entity.HasOne(d => d.Proveedor)
            .WithMany(p => p.Productos)
            .HasForeignKey(d => d.ProveedorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__Provee__778AC167");

        entity.HasOne(d => d.TipoMedida)
            .WithMany(p => p.Productos)
            .HasForeignKey(d => d.TipoMedidaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__TipoMe__75A278F5");
      });

      modelBuilder.Entity<Proveedor>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreCompania)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.NombreContacto)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Telefono)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<Restaurante>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.EstadoRestauranteId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Telefono)
            .IsRequired()
            .HasMaxLength(20);

        entity.Property(e => e.UbicacionId).HasColumnType("numeric(5, 0)");

        entity.HasOne(d => d.EstadoRestaurante)
            .WithMany(p => p.Restaurantes)
            .HasForeignKey(d => d.EstadoRestauranteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Restauran__Estad__4AB81AF0");

        entity.HasOne(d => d.Ubicacion)
            .WithMany(p => p.Restaurante)
            .HasForeignKey(d => d.UbicacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Restauran__Ubica__4BAC3F29");
      });

      modelBuilder.Entity<TipoDocumento>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreAbbr)
            .IsRequired()
            .HasMaxLength(10);

        entity.Property(e => e.NombreCompleto)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<TipoMedida>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.NombreAbbr)
            .IsRequired()
            .HasMaxLength(10);

        entity.Property(e => e.NombreCompleto)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<TipoTerminacion>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
      });

      modelBuilder.Entity<Ubicacion>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Adiciones).HasMaxLength(50);

        entity.Property(e => e.CiudadId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.Direccion)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.PaisId).HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.Ciudad)
            .WithMany(p => p.Ubicaciones)
            .HasForeignKey(d => d.CiudadId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ubicacion__Ciuda__3C69FB99");

        entity.HasOne(d => d.Pais)
            .WithMany(p => p.Ubicaciones)
            .HasForeignKey(d => d.PaisId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Ubicacion__PaisI__3D5E1FD2");
      });

      modelBuilder.Entity<Venta>(entity => {
        entity.HasKey(e => e.Codigo)
            .HasName("PK__Venta__06370DAD61CA4288");

        entity.Property(e => e.Codigo)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.EmpleadoId).HasColumnType("numeric(9, 0)");

        entity.Property(e => e.EstadoVentaId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Fecha).HasColumnType("datetime");

        entity.Property(e => e.Iva).HasColumnType("money");

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.HasOne(d => d.Empleado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.EmpleadoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EmpleadoI__03F0984C");

        entity.HasOne(d => d.EstadoVenta)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.EstadoVentaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EstadoVen__04E4BC85");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
