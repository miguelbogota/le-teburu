
-- Creacion de la base de datos
CREATE DATABASE teburuDB;

-- Usar la base de datos
USE teburuDB;

-- Creacion de la tabla de generos
CREATE TABLE Genero (
  IdGenero NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  NombreGenero VARCHAR(9) NOT NULL
);

-- Creacion de la tabla de tipo de documentos
CREATE TABLE TipoDocumento (
  IdTipoDocumento NUMERIC(2) IDENTITY(1,1) PRIMARY KEY,
  NombreTipoDocumento VARCHAR(30) NOT NULL
);

-- Creacion de la tabla de los roles
CREATE TABLE Rol (
  IdRol NUMERIC(4) IDENTITY(1,1) PRIMARY KEY,
  NombreRol VARCHAR(30) NOT NULL
);

-- Creacion de la tabla de las ciudades
CREATE TABLE Ciudad (
  IdCiudad NUMERIC(4) IDENTITY(1,1) PRIMARY KEY,
  NombreCiudad VARCHAR(30) NOT NULL
);

-- Creacion de la tabla de los paises
CREATE TABLE Pais (
  IdPais NUMERIC(3) IDENTITY(1,1) PRIMARY KEY,
  NombrePais VARCHAR(30) NOT NULL
);

-- Creacion de la tabla de sedes
CREATE TABLE Sede (
  IdSede NUMERIC(1) IDENTITY(1,1) PRIMARY KEY,
  DirreccionSede VARCHAR(50) NOT NULL,
  CiudadSedeFK NUMERIC(4) NOT NULL,
  PaisSedeFK NUMERIC(3) NOT NULL,

  FOREIGN KEY (CiudadSedeFK) REFERENCES Ciudad(IdCiudad),
  FOREIGN KEY (PaisSedeFK) REFERENCES Pais(IdPais)
);

-- Creacion de la tabla de empleado
CREATE TABLE Empleado (
  IdEmpleado NUMERIC(3) PRIMARY KEY,
  ClaveEmpleado VARCHAR(50) NOT NULL,
  NombreEmpleado VARCHAR(50) NOT NULL,
  Apellido VARCHAR(50) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  FechaContrato DATETIME NOT NULL,
  GeneroEmpleadoFK NUMERIC(1)  NOT NULL,
  TiposDocumentoEmpleadoFK NUMERIC(2) NOT NULL,
  RolEmpleadoFK NUMERIC(4) NOT NULL,
  SedeEmpleadoFK NUMERIC(1) NOT NULL,
 
  FOREIGN KEY (GeneroEmpleadoFK) REFERENCES Genero(IdGenero),
  FOREIGN KEY (TiposDocumentoEmpleadoFK) REFERENCES TipoDocumento(IdTipoDocumento),
  FOREIGN KEY (RolEmpleadoFK) REFERENCES Rol(IdRol),
  FOREIGN KEY (SedeEmpleadoFK) REFERENCES Sede(IdSede)
);
 
-- Creacion de la tabla de productos
CREATE TABLE Producto (
  IdProducto NUMERIC(3) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  NombreProducto VARCHAR(50) NOT NULL,
  PesoProducto VARCHAR(50) NOT NULL
);

-- Creacion de la tabla de estados
CREATE TABLE  Estado (
  IdEstado NUMERIC(1) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Estado VARCHAR(20) NOT NULL
);

 -- Creacion de la tabla de proveedor
 CREATE TABLE Proveedor (
  IdProveedor NUMERIC(3) PRIMARY KEY,
  NombreProveedor VARCHAR(50) NOT NULL,
  ContactoProveedor VARCHAR(50) NOT NULL
);

-- Creacion de la tabla de ventas
CREATE TABLE Factura ( 
  IdFactura NUMERIC(5) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FechaFactura DATE NOT NULL,
  EstadoFacturaFK NUMERIC(1) NOT NULL,
 
  FOREIGN KEY (EstadoFacturaFK) REFERENCES Estado(IdEstado)
);

-- Creacion de la tabla de inventario
CREATE TABLE Inventario (
  IdInventario NUMERIC(5) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  FechaIngresoInventario DATE NOT NULL,
  CantidadInventario VARCHAR(50) NOT NULL,
  ProductoInventarioFK NUMERIC(3) NOT NULL,
  SedeInventarioFK NUMERIC(1) NOT NULL,
  ProveedorInventioFK NUMERIC(3) NOT NULL,

  FOREIGN KEY (ProductoInventarioFK) REFERENCES Producto(IdProducto),
  FOREIGN KEY (SedeInventarioFK) REFERENCES Sede(IdSede),
  FOREIGN KEY (ProveedorInventioFK) REFERENCES Proveedor(IdProveedor),
);

-- Creacion de la tabla de pedidos
CREATE TABLE Venta (
  IdVenta NUMERIC(5) IDENTITY(1,1) PRIMARY KEY NOT NULL,
  CantidadVenta VARCHAR(20) NOT NULL,
  EmpleadoVentaFK NUMERIC(3) NOT NULL,
  ProductoVentaFK NUMERIC(3) NOT NULL,
  FacturaVentaFK NUMERIC(5) NOT NULL,

  FOREIGN KEY (EmpleadoVentaFK) REFERENCES Empleado(IdEmpleado),
  FOREIGN KEY (ProductoVentaFK) REFERENCES Producto(IdProducto),
  FOREIGN KEY (FacturaVentaFK) REFERENCES Factura(IdFactura)
);
