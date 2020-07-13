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

-- Creacion de la tabla de ciudades
CREATE TABLE Ciudad (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(70) NOT NULL
)
GO

CREATE TABLE Pais (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(70) NOT NULL
)
GO

-- Creacion de la tabla de datos de contacto
CREATE TABLE Ubicacion (
  Id NUMERIC(5,0) IDENTITY PRIMARY KEY,
  Direccion NVARCHAR(100) NOT NULL,
  Adiciones NVARCHAR(50) DEFAULT NULL,
  CiudadId NUMERIC(3,0) NOT NULL,
  PaisId NUMERIC(3,0) NOT NULL,

  FOREIGN KEY (CiudadId) REFERENCES Ciudad(Id),
  FOREIGN KEY (PaisId) REFERENCES Pais(Id)
)
GO

-- Creacion de la tabla de generos
CREATE TABLE Genero (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL
)
GO

-- Creacion de la tabla de tipos de documentos
CREATE TABLE TipoDocumento (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  NombreAbbr NVARCHAR(10) NOT NULL,
  NombreCompleto NVARCHAR(50) NOT NULL,
)
GO

-- Creacion de la tabla de datos de una persona
CREATE TABLE DatosPersonales (
  Documento NUMERIC(20,0) PRIMARY KEY,
  Nombre NVARCHAR(70) NOT NULL,
  Apellido NVARCHAR(70) NOT NULL,
  FechaNacimiento DATE NOT NULL,
  Correo NVARCHAR(100) NOT NULL,
  Telefono NVARCHAR(20) NOT NULL,

  GeneroId NUMERIC(3,0) NOT NULL,
  TipoDocumentoId NUMERIC(3,0) NOT NULL,
  UbicacionId NUMERIC(5,0) NOT NULL,

  FOREIGN KEY (GeneroId) REFERENCES Genero(Id),
  FOREIGN KEY (TipoDocumentoId) REFERENCES TipoDocumento(Id),
  FOREIGN KEY (UbicacionId) REFERENCES Ubicacion(Id)
)
GO

-- Creacion de la tabla de estados de restaurantes
CREATE TABLE EstadoRestaurante (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de datos de un restaurante
CREATE TABLE Restaurante (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(70) NOT NULL,
  Telefono NVARCHAR(20) NOT NULL,
  HoraApertura TIME NOT NULL,
  HoraCierre TIME NOT NULL,
  
  EstadoRestauranteId NUMERIC(2,0) NOT NULL,
  UbicacionId NUMERIC(5,0) NOT NULL,

  FOREIGN KEY (EstadoRestauranteId) REFERENCES EstadoRestaurante(Id),
  FOREIGN KEY (UbicacionId) REFERENCES Ubicacion(Id)
)
GO

-- Creacion de la tabla de cargos de los empleados
CREATE TABLE Cargo (
  Id NUMERIC(3,0) IDENTITY(100,1) PRIMARY KEY,
  Nombre NVARCHAR(40) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)

-- Creacion de la tabla de estados de los empleados
CREATE TABLE EstadoEmpleado (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de los empleados
CREATE TABLE Empleado (
  Id NUMERIC(9,0) PRIMARY KEY,
  Contrasena NVARCHAR(70) NOT NULL,

  DatosPersonalesId NUMERIC(20,0) NOT NULL,
  EstadoEmpleadoId NUMERIC(2,0) NOT NULL,
  CargoId NUMERIC(3,0) NOT NULL,
  RestauranteId NUMERIC(3,0) NOT NULL,
  JefeId NUMERIC(9,0),
  
  FOREIGN KEY (DatosPersonalesId) REFERENCES DatosPersonales(Documento),
  FOREIGN KEY (EstadoEmpleadoId) REFERENCES EstadoEmpleado(Id),
  FOREIGN KEY (CargoId) REFERENCES Cargo(Id),
  FOREIGN KEY (RestauranteId) REFERENCES Restaurante(Id),
  FOREIGN KEY (JefeId) REFERENCES Empleado(Id)
)
GO

-- Creacion de la tabla de los tipos de terminaciones
CREATE TABLE TipoTerminacion (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de los contratos de los empleados
CREATE TABLE Contrato (
  Id NUMERIC(6,0) PRIMARY KEY,
  FechaContrato DATETIME NOT NULL,
  FechaIngreso DATE NOT NULL,
  FechaTerminacion DATETIME DEFAULT NULL,
  Salario MONEY NOT NULL,

  TipoTerminacionId NUMERIC(2,0) DEFAULT NULL,
  EmpleadoId NUMERIC(9,0) NOT NULL,

  FOREIGN KEY (TipoTerminacionId) REFERENCES TipoTerminacion(Id),
  FOREIGN KEY (EmpleadoId) REFERENCES Empleado(Id)
)
GO

-- Creacion de la tabla de categorias
CREATE TABLE Categoria (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de estados de los menus
CREATE TABLE EstadoCombo (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de combos
CREATE TABLE Combo (
  Codigo NVARCHAR(5) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(250) NOT NULL,
  Precio MONEY NOT NULL,
  ImgUrl NVARCHAR(2100) NOT NULL,

  EstadoComboId NUMERIC(2,0) NOT NULL,

  FOREIGN KEY (EstadoComboId) REFERENCES EstadoCombo(Id)
)
GO

-- Creacion de la tabla de estados de los menus
CREATE TABLE EstadoMenu (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de menus
CREATE TABLE Menu (
  Codigo NVARCHAR(5) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL,
  Precio MONEY NOT NULL,
  ImgUrl NVARCHAR(2100) NOT NULL,

  EstadoMenuId NUMERIC(2,0) NOT NULL,
  CategoriaId NUMERIC(3,0) NOT NULL,
  ComboId NVARCHAR(5) DEFAULT NULL,

  FOREIGN KEY (EstadoMenuId) REFERENCES EstadoMenu(Id),
  FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
  FOREIGN KEY (ComboId) REFERENCES Combo(Codigo)
)
GO

-- Creacion de la tabla de proveedores
CREATE TABLE Proveedor (
  Id NUMERIC(3,0) IDENTITY(1,1) PRIMARY KEY,
  NombreCompania NVARCHAR(50) NOT NULL,
  NombreContacto NVARCHAR(50) NOT NULL,
  Telefono NVARCHAR(20) NOT NULL
)
GO

-- Creacion de la tabla de los tipos de medias
CREATE TABLE TipoMedida (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  NombreAbbr NVARCHAR(10) NOT NULL,
  NombreCompleto NVARCHAR(50) NOT NULL,
)
GO

-- Creacion de la tabla de estados de los productos
CREATE TABLE EstadoProducto (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de productos
CREATE TABLE Producto (
  Codigo NVARCHAR(5) PRIMARY KEY,
  Nombre NVARCHAR(70) NOT NULL,
  Precio MONEY NOT NULL,
  FechaVencimiento DATE DEFAULT NULL,
  
  TipoMedidaId NUMERIC(2,0) NOT NULL,
  EstadoProductoId NUMERIC(2,0) NOT NULL,
  ProveedorId NUMERIC(3,0) NOT NULL,
  
  FOREIGN KEY (TipoMedidaId) REFERENCES TipoMedida(Id),
  FOREIGN KEY (EstadoProductoId) REFERENCES EstadoProducto(Id),
  FOREIGN KEY (ProveedorId) REFERENCES Proveedor(Id)
)
GO

-- Creacion de la tabla de ingredientes
CREATE TABLE Ingredientes (
  Id NUMERIC(5,0) IDENTITY(1,1) PRIMARY KEY,
  Cantidad NUMERIC(5,0) NOT NULL,

  ProductoId NVARCHAR(5) NOT NULL,
  MenuId NVARCHAR(5) NOT NULL,

  FOREIGN KEY (ProductoId) REFERENCES Producto(Codigo),
  FOREIGN KEY (MenuId) REFERENCES Menu(Codigo)
)

-- Creacion de la tabla de inventarios
CREATE TABLE Inventario (
  Id NUMERIC(5,0) IDENTITY(1,1) PRIMARY KEY,
  FechaEntrada DATETIME NOT NULL,
  Cantidad NUMERIC(9,0) NOT NULL,
  Precio MONEY NOT NULL,

  ProductoId NVARCHAR(5) NOT NULL,
  RestauranteId NUMERIC(3,0) NOT NULL,

  FOREIGN KEY (ProductoId) REFERENCES Producto(Codigo),
  FOREIGN KEY (RestauranteId) REFERENCES Restaurante(Id)
)
GO

-- Creacion de la tabla de los estados de ventas
CREATE TABLE EstadoVenta (
  Id NUMERIC(2,0) IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(50) NOT NULL,
  Descripcion NVARCHAR(255) NOT NULL
)
GO

-- Creacion de la tabla de ventas
CREATE TABLE Venta (
  Codigo NUMERIC(5,0) IDENTITY(10000,1) PRIMARY KEY,
  Fecha DATETIME NOT NULL,
  Precio MONEY NOT NULL,
  Iva MONEY NOT NULL,

  EmpleadoId NUMERIC(9,0) NOT NULL,
  EstadoVentaId NUMERIC(2,0) NOT NULL,

  FOREIGN KEY (EmpleadoId) REFERENCES Empleado(Id),
  FOREIGN KEY (EstadoVentaId) REFERENCES EstadoVenta(Id)
)
GO

-- Creacion de la tabla de pedidos
CREATE TABLE Pedido (
  Codigo NUMERIC(5,0) IDENTITY(10000,1) PRIMARY KEY,
  Cantidad NUMERIC(2,0) NOT NULL,
  Precio MONEY NOT NULL,

  MenuId NVARCHAR(5) DEFAULT NULL,
  ComboId NVARCHAR(5) DEFAULT NULL,
  VentaId NUMERIC(5,0) NOT NULL,

  FOREIGN KEY (MenuId) REFERENCES Menu(Codigo),
  FOREIGN KEY (ComboId) REFERENCES Combo(Codigo),
  FOREIGN KEY (VentaId) REFERENCES Venta(Codigo)
)








