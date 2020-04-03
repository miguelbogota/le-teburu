-- Eliminar la sb si existe
USE master
IF EXISTS (SELECT * FROM sys.databases WHERE name='TeburuDB') DROP DATABASE TeburuDB
GO

-- Creacion de la base de datos
CREATE DATABASE TeburuDB
GO

-- Usar la base de datos
USE TeburuDB
GO

-- Creacion de la tabla de sedes
CREATE TABLE Restaurante (
  Id NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(60) NOT NULL,
  Telefono NUMERIC(10) NOT NULL,
  HoraApertura TIME NOT NULL,
  HoraCierre TIME NOT NULL,

  Direccion NVARCHAR(100) NOT NULL,
  Ciudad NVARCHAR(100) NOT NULL,
  Pais NVARCHAR(100) NOT NULL,
)
GO

-- Creacion de la tabla de datos de las personas
CREATE TABLE Persona (
  Documento NUMERIC(15) PRIMARY KEY,
  TipoDocumento NVARCHAR(100) NOT NULL,

  Nombre NVARCHAR(70) NOT NULL,
  Apellido NVARCHAR(70) NOT NULL,
  Genero CHAR(1)  NOT NULL,
  FechaNacimiento DATE NOT NULL,

  Telefono NUMERIC(10) NOT NULL,
  Correo NVARCHAR(50) NOT NULL,
  Direccion NVARCHAR(100) NOT NULL,
  Ciudad NVARCHAR(100) NOT NULL,
  Pais NVARCHAR(100) NOT NULL,
)
GO

-- Creacion de la tabla de empleado
CREATE TABLE Empleado (
  Id NUMERIC(8) PRIMARY KEY,
  Contrasena NVARCHAR(50) NOT NULL,
  Cargo NVARCHAR(40) NOT NULL,
  EstadoActual CHAR(1) NOT NULL,

  Salario MONEY NOT NULL,
  TipoContrato NVARCHAR(40) NOT NULL,
  FechaContratacion DATETIME NOT NULL,

  PersonaId NUMERIC(15) NOT NULL,
  RestauranteId NUMERIC(3) NOT NULL,

  FOREIGN KEY (PersonaId) REFERENCES Persona(Documento),
  FOREIGN KEY (RestauranteId) REFERENCES Restaurante(Id)
)
GO

-- Creacion de la tabla de categorias
CREATE TABLE Categoria (
  Id NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(40) NOT NULL,
  Descripcion NVARCHAR(200) NOT NULL
)
GO

-- Creacion de la tabla del menu
CREATE TABLE Menu (
  Id NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL,
  ImgUrl NVARCHAR(225) NOT NULL,
  Precio MONEY NOT NULL,
  Estado CHAR(1) NOT NULL,
  CategoriaId NUMERIC(2) NOT NULL,

  FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id)
)
GO

-- Creacion de la tabla de proveedor
CREATE TABLE Proveedor (
  Id NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Telefono NUMERIC(10) NOT NULL
)
GO
 
-- Creacion de la tabla de productos
CREATE TABLE Producto (
  Id NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Precio MONEY NOT NULL,
  Estado CHAR(1) NOT NULL,

  MenuId NUMERIC(2) DEFAULT NULL,
  ProveedorId NUMERIC(3) NOT NULL,

  FOREIGN KEY (MenuId) REFERENCES Menu(Id),
  FOREIGN KEY (ProveedorId) REFERENCES Proveedor(Id)
)
GO

-- Creacion de la tabla de inventario
CREATE TABLE Inventario (
  Id NUMERIC(5) IDENTITY(1,1) PRIMARY KEY,
  FechaIngreso DATE NOT NULL,
  PrecioTotal MONEY NOT NULL,
  Cantidad NUMERIC(5) NOT NULL,

  ProductoId NUMERIC(3) NOT NULL,
  RestauranteId NUMERIC(3) NOT NULL,

  FOREIGN KEY (ProductoId) REFERENCES Producto(Id),
  FOREIGN KEY (RestauranteId) REFERENCES Restaurante(Id)
)
GO

-- Creacion de la tabla de estados de las ventas
CREATE TABLE EstadoVenta (
  Id NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(20) NOT NULL,
  Descripcion NVARCHAR(200) NOT NULL,
)
GO

-- Creacion de la tabla de ventas
CREATE TABLE Venta (
  Id NUMERIC(8) PRIMARY KEY,
  Fecha DATETIME NOT NULL,
  PrecioTotal MONEY NOT NULL,

  EmpleadoId NUMERIC(8) NOT NULL,
  EstadoId NUMERIC(2) NOT NULL,

  FOREIGN KEY (EmpleadoId) REFERENCES Empleado(Id),
  FOREIGN KEY (EstadoId) REFERENCES EstadoVenta(Id)
)
GO

-- Creacion de la tabla de pedidos
CREATE TABLE Pedido (
  Id NUMERIC(8) PRIMARY KEY,
  Cantidad NUMERIC(2) NOT NULL,
  PrecioTotal MONEY NOT NULL,
  Descuento MONEY DEFAULT NULL,

  MenuId NUMERIC(2) NOT NULL,
  VentaId NUMERIC(8) NOT NULL,

  FOREIGN KEY (MenuId) REFERENCES Menu(Id),
  FOREIGN KEY (VentaId) REFERENCES Venta(Id)
)