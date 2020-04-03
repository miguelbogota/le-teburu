using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace models.Entity {
  public partial class TeburuDBContext : DbContext {
    public TeburuDBContext() {
    }

    public TeburuDBContext(DbContextOptions<TeburuDBContext> options)
        : base(options) {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }
    public virtual DbSet<Empleado> Empleado { get; set; }
    public virtual DbSet<EstadoVenta> EstadoVenta { get; set; }
    public virtual DbSet<Inventario> Inventario { get; set; }
    public virtual DbSet<Menu> Menu { get; set; }
    public virtual DbSet<Pedido> Pedido { get; set; }
    public virtual DbSet<Persona> Persona { get; set; }
    public virtual DbSet<Producto> Producto { get; set; }
    public virtual DbSet<Proveedor> Proveedor { get; set; }
    public virtual DbSet<Restaurante> Restaurante { get; set; }
    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer(new AppConfiguration().SqlConnectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Categoria>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(200);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(40);
      });

      modelBuilder.Entity<Empleado>(entity => {
        entity.Property(e => e.Id).HasColumnType("numeric(8, 0)");

        entity.Property(e => e.Cargo)
            .IsRequired()
            .HasMaxLength(40);

        entity.Property(e => e.Contrasena)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.EstadoActual)
            .IsRequired()
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.FechaContratacion).HasColumnType("datetime");

        entity.Property(e => e.PersonaId).HasColumnType("numeric(15, 0)");

        entity.Property(e => e.RestauranteId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.Salario).HasColumnType("money");

        entity.Property(e => e.TipoContrato)
            .IsRequired()
            .HasMaxLength(40);

        entity.HasOne(d => d.Persona)
            .WithMany(p => p.Empleado)
            .HasForeignKey(d => d.PersonaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__Person__3B75D760");

        entity.HasOne(d => d.Restaurante)
            .WithMany(p => p.Empleados)
            .HasForeignKey(d => d.RestauranteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Empleado__Restau__3C69FB99");
      });

      modelBuilder.Entity<EstadoVenta>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(200);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(20);
      });

      modelBuilder.Entity<Inventario>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(5, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Cantidad).HasColumnType("numeric(5, 0)");

        entity.Property(e => e.FechaIngreso).HasColumnType("date");

        entity.Property(e => e.PrecioTotal).HasColumnType("money");

        entity.Property(e => e.ProductoId).HasColumnType("numeric(3, 0)");

        entity.Property(e => e.RestauranteId).HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.Producto)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__Produ__4AB81AF0");

        entity.HasOne(d => d.Restaurante)
            .WithMany(p => p.Inventario)
            .HasForeignKey(d => d.RestauranteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Inventari__Resta__4BAC3F29");
      });

      modelBuilder.Entity<Menu>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(2, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.CategoriaId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(255);

        entity.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.ImgUrl)
            .IsRequired()
            .HasMaxLength(225);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.HasOne(d => d.Categoria)
            .WithMany(p => p.Menus)
            .HasForeignKey(d => d.CategoriaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Menu__CategoriaI__412EB0B6");
      });

      modelBuilder.Entity<Pedido>(entity => {
        entity.Property(e => e.Id).HasColumnType("numeric(8, 0)");

        entity.Property(e => e.Cantidad).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Descuento).HasColumnType("money");

        entity.Property(e => e.MenuId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.PrecioTotal).HasColumnType("money");

        entity.Property(e => e.VentaId).HasColumnType("numeric(8, 0)");

        entity.HasOne(d => d.Menu)
            .WithMany(p => p.Pedido)
            .HasForeignKey(d => d.MenuId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Pedido__MenuId__5535A963");

        entity.HasOne(d => d.Venta)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(d => d.VentaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Pedido__VentaId__5629CD9C");
      });

      modelBuilder.Entity<Persona>(entity => {
        entity.HasKey(e => e.Documento)
            .HasName("PK__Persona__AF73706C4E133805");

        entity.Property(e => e.Documento).HasColumnType("numeric(15, 0)");

        entity.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Ciudad)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Correo)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Direccion)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.FechaNacimiento).HasColumnType("date");

        entity.Property(e => e.Genero)
            .IsRequired()
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(70);

        entity.Property(e => e.Pais)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Telefono).HasColumnType("numeric(10, 0)");

        entity.Property(e => e.TipoDocumento)
            .IsRequired()
            .HasMaxLength(100);
      });

      modelBuilder.Entity<Producto>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(1)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.MenuId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Precio).HasColumnType("money");

        entity.Property(e => e.ProveedorId).HasColumnType("numeric(3, 0)");

        entity.HasOne(d => d.Menu)
            .WithMany(p => p.Productos)
            .HasForeignKey(d => d.MenuId)
            .HasConstraintName("FK__Producto__MenuId__46E78A0C");

        entity.HasOne(d => d.Proveedor)
            .WithMany(p => p.Productos)
            .HasForeignKey(d => d.ProveedorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Producto__Provee__47DBAE45");
      });

      modelBuilder.Entity<Proveedor>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Telefono).HasColumnType("numeric(10, 0)");
      });

      modelBuilder.Entity<Restaurante>(entity => {
        entity.Property(e => e.Id)
            .HasColumnType("numeric(3, 0)")
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Ciudad)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Direccion)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(60);

        entity.Property(e => e.Pais)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Telefono).HasColumnType("numeric(10, 0)");
      });

      modelBuilder.Entity<Venta>(entity => {
        entity.Property(e => e.Id).HasColumnType("numeric(8, 0)");

        entity.Property(e => e.EmpleadoId).HasColumnType("numeric(8, 0)");

        entity.Property(e => e.EstadoId).HasColumnType("numeric(2, 0)");

        entity.Property(e => e.Fecha).HasColumnType("datetime");

        entity.Property(e => e.PrecioTotal).HasColumnType("money");

        entity.HasOne(d => d.Empleado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.EmpleadoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EmpleadoI__5070F446");

        entity.HasOne(d => d.Estado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(d => d.EstadoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Venta__EstadoId__5165187F");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
