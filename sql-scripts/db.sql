-- Eliminar la sb si existe
USE master;
IF EXISTS (SELECT * FROM sys.databases WHERE name='teburuDB') DROP DATABASE teburuDB;
GO

-- Creacion de la base de datos
CREATE DATABASE teburuDB;
GO

-- Usar la base de datos
USE teburuDB;
GO

-- Creacion de la tabla de generos
CREATE TABLE Genero (
  IdGenero NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreGenero NVARCHAR(9) NOT NULL
);
GO

-- Creacion de la tabla de tipo de documentos
CREATE TABLE TipoDocumento (
  IdTipoDocumento NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  NombreTipoDocumento NVARCHAR(30) NOT NULL
);
GO

-- Creacion de la tabla de los roles
CREATE TABLE Rol (
  IdRol NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  NombreRol NVARCHAR(30) NOT NULL
);
GO

-- Creacion de la tabla de estados de los empleados
CREATE TABLE EstadoEmpleado (
  IdEstadoEmpleado NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreEstadoEmpleado NVARCHAR(20) NOT NULL
);
GO

-- Creacion de la tabla de las ciudades
CREATE TABLE Ciudad (
  IdCiudad NUMERIC(4) IDENTITY(1,1) PRIMARY KEY,
  NombreCiudad NVARCHAR(30) NOT NULL
);
GO

-- Creacion de la tabla de los paises
CREATE TABLE Pais (
  IdPais NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  NombrePais NVARCHAR(30) NOT NULL
);
GO

-- Creacion de la tabla de direcciones
CREATE TABLE Direccion (
  IdDireccion NUMERIC(7) IDENTITY(1,1) PRIMARY KEY,
  Direccion NVARCHAR(30) NOT NULL,
  CiudadSedeFK NUMERIC(4) NOT NULL,
  PaisSedeFK NUMERIC(3) NOT NULL,
  
  FOREIGN KEY (CiudadSedeFK) REFERENCES Ciudad(IdCiudad),
  FOREIGN KEY (PaisSedeFK) REFERENCES Pais(IdPais)
);
GO

-- Creacion de la tabla de sedes
CREATE TABLE Sede (
  IdSede NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreSede NVARCHAR(40) NOT NULL,
  DireccionSedeFK NUMERIC(7) NOT NULL,

  FOREIGN KEY (DireccionSedeFK) REFERENCES Direccion(IdDireccion)
);
GO

-- Creacion de la tabla de datos
CREATE TABLE Datos (
  Documento NUMERIC(14) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  Telefono NUMERIC(10) NOT NULL,
  GeneroFK NUMERIC(1)  NOT NULL,
  TiposDocumentoFK NUMERIC(2) NOT NULL,
  DireccionFK NUMERIC(7) NOT NULL,
  
  FOREIGN KEY (GeneroFK) REFERENCES Genero(IdGenero),
  FOREIGN KEY (TiposDocumentoFK) REFERENCES TipoDocumento(IdTipoDocumento),
  FOREIGN KEY (DireccionFK) REFERENCES Direccion(IdDireccion)
);
GO

-- Creacion de la tabla de empleado
CREATE TABLE Empleado (
  IdEmpleado NUMERIC(8) PRIMARY KEY,
  ClaveEmpleado NVARCHAR(50) NOT NULL,
  FechaContrato DATETIME NOT NULL,
  DatosEmpleadoFK NUMERIC(14) NOT NULL,
  RolEmpleadoFK NUMERIC(2) NOT NULL,
  SedeEmpleadoFK NUMERIC(1) NOT NULL,
  EstadoEmpleadoFK NUMERIC(1) NOT NULL,
 
  FOREIGN KEY (DatosEmpleadoFK) REFERENCES Datos(Documento),
  FOREIGN KEY (RolEmpleadoFK) REFERENCES Rol(IdRol),
  FOREIGN KEY (SedeEmpleadoFK) REFERENCES Sede(IdSede),
  FOREIGN KEY (EstadoEmpleadoFK) REFERENCES EstadoEmpleado(IdEstadoEmpleado)
);
GO

-- Creacion de la tabla de estados de los menus
CREATE TABLE EstadoMenu (
  IdEstadoMenu NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreEstadoMenu NVARCHAR(20) NOT NULL
);
GO

-- Creacion de la tabla de categorias
CREATE TABLE Categoria (
  IdCategoria NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  NombreCategoria NVARCHAR(40) NOT NULL
);
GO

-- Creacion de la tabla del menu
CREATE TABLE Menu (
  IdMenu NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  NombreMenu NVARCHAR(50) NOT NULL,
  PrecioMenu MONEY NOT NULL,
  CategoriaMenuFK NUMERIC(2) NOT NULL,
  EstadoMenuFK NUMERIC(1) NOT NULL,

  FOREIGN KEY (CategoriaMenuFK) REFERENCES Categoria(IdCategoria),
  FOREIGN KEY (EstadoMenuFK) REFERENCES EstadoMenu(IdEstadoMenu)
);
GO

-- Creacion de la tabla de estados de los productos
CREATE TABLE EstadoProducto (
  IdEstadoProducto NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreEstadoProducto NVARCHAR(20) NOT NULL
);
GO

 -- Creacion de la tabla de proveedor
 CREATE TABLE Proveedor (
  IdProveedor NUMERIC(3) PRIMARY KEY,
  NombreProveedor NVARCHAR(50) NOT NULL,
  ContactoProveedor NUMERIC(10) NOT NULL
);
GO
 
-- Creacion de la tabla de productos
CREATE TABLE Producto (
  IdProducto NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  NombreProducto NVARCHAR(50) NOT NULL,
  PrecioProducto MONEY NOT NULL,
  ProveedorProductoFK NUMERIC(3) NOT NULL,
  EstadoProductoFK NUMERIC(1) NOT NULL,
  MenuFK NUMERIC(2),

  FOREIGN KEY (ProveedorProductoFK) REFERENCES Proveedor(IdProveedor),
  FOREIGN KEY (EstadoProductoFK) REFERENCES EstadoProducto(IdEstadoProducto),
  FOREIGN KEY (MenuFK) REFERENCES Menu(IdMenu)
);
GO

-- Creacion de la tabla de inventario
CREATE TABLE Inventario (
  IdInventario NUMERIC(5) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FechaIngresoInventario DATE NOT NULL,
  PrecioTotalInventario MONEY NOT NULL,
  CantidadInventario NUMERIC(5) NOT NULL,
  ProductoInventarioFK NUMERIC(3) NOT NULL,
  SedeInventarioFK NUMERIC(1) NOT NULL,

  FOREIGN KEY (ProductoInventarioFK) REFERENCES Producto(IdProducto),
  FOREIGN KEY (SedeInventarioFK) REFERENCES Sede(IdSede),
);
GO

-- Creacion de la tabla de estados de los productos
CREATE TABLE EstadoVenta (
  IdEstadoVenta NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreEstadoVenta NVARCHAR(20) NOT NULL
);
GO

-- Creacion de la tabla de ventas
CREATE TABLE Venta ( 
  IdVenta NUMERIC(6) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FechaVenta DATE NOT NULL,
  PrecioTotalVenta MONEY NOT NULL,
  EmpleadoVentaFK NUMERIC(8) NOT NULL,
  EstadoVentaFK NUMERIC(1) NOT NULL,

  FOREIGN KEY (EmpleadoVentaFK) REFERENCES Empleado(IdEmpleado),
  FOREIGN KEY (EstadoVentaFK) REFERENCES EstadoVenta(IdEstadoVenta)
);
GO

-- Creacion de la tabla de pedidos
CREATE TABLE Pedido (
  IdPedido NUMERIC(5) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  CantidadPedido NUMERIC(2) NOT NULL,
  PrecioTotalPedido MONEY NOT NULL,
  MenuPedidoFK NUMERIC(2) NOT NULL,
  VentaPedidoFK NUMERIC(6) NOT NULL,

  FOREIGN KEY (MenuPedidoFK) REFERENCES Menu(IdMenu),
  FOREIGN KEY (VentaPedidoFK) REFERENCES Venta(IdVenta)
);