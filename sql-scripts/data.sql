
-- Usar la base de datos
USE TeburuDB
GO

INSERT INTO Ciudad VALUES
('Bogotá'),
('Medellin'),
('Cali')

INSERT INTO Pais VALUES
('Colombia')

INSERT INTO Ubicacion VALUES
('Cl. 54c Sur #95a-18', 'Int 204 - Apto 204', 1, 1),
('Av. 23 #12a-18', null, 1, 1),
('Cl. 26 #23-09', null, 1, 1),
('Dg. 32 #74d-26', 'Apto 1002', 1, 1),
('Cl. 7 #122-23', null, 1, 1),
('Cl. 13 #26-23', 'Local 481', 1, 1)

INSERT INTO Genero VALUES
('Masculino'),
('Femenino'),
('Otro'),
('Prefiero no decir')

INSERT INTO TipoDocumento VALUES
('C.C.','Cédula'),
('T.I.','Tarjeta de identidad'),
('P.A.','Pasaporte')

INSERT INTO DatosPersonales VALUES
(1126826757, 'Miguel Angel', 'Bogota Rico', '1996-11-09', 'miguel.bogota@gmail.com', '3197029889', 1, 1, 1),
(83747220, 'Angie Valeria', 'Herrera Gomez', '1992-08-23', 'angie.herrera@hotmail.com', '3203987295', 2, 1, 2),
(282919388, 'Luz Angelica', 'Moreno Diaz', '1994-01-23', 'luz.moreno@outlook.com', '3182093846', 2, 2, 3),
(8324877, 'Jonathan', 'Jimenez Orozco', '1988-12-01', 'jonathan.jimenez@gmail.com', '3178260937', 1, 3, 4),
(45983293, 'Maria Alejandra', 'Diaz Catañeda', '1967-02-20', 'maria.diaz@aol.com', '3209819283', 2, 3, 5)

INSERT INTO EstadoRestaurante VALUES
('Activo', 'Restaurante esta actualmente funcionando normalmente.'),
('Inctivo', 'Restaurante esta actualmente sin funcionamiento.')

INSERT INTO Restaurante VALUES
('Modelia', '3208736', '06:00:00', '23:00:00', 1, 6)

INSERT INTO Cargo VALUES
('Manager', 'Manejar a todos los cajeros.'),
('Cajero', 'Registrar transacciones en la caja.')

INSERT INTO EstadoEmpleado VALUES
('Activo', 'Empleado se encuentra generando sus funciones normales.'),
('Suspendido', 'Empleado sigue dentro de la compañia pero no esta asistiendo.'),
('Terminado', 'Empleado ya no labora dentro de la compañia.')

INSERT INTO Empleado VALUES
(194988928, 'Abc123', 1126826757, 1, 100, 1, null),
(194988929, '123Abc', 83747220, 1, 101, 1, 194988928),
(194988930, 'NoseAlgo', 282919388, 1, 101, 1, 194988928),
(194988931, 'ContraseñaSegura123', 8324877, 1, 101, 1, 194988928),
(194988932, 'MariaLaMejor2020', 45983293, 1, 101, 1, 194988928)

INSERT INTO TipoTerminacion VALUES
('Renuncia voluntaria', 'El empleado renuncio voluntariamente.'),
('Despido Justo', 'La compañia decidio que el empleado no puede seguir laborando por una razon de despido.')

INSERT INTO Contrato VALUES
(567234, '2020-04-03 13:30:00', '2020-04-06', null, 2500000, null, 194988928),
(567235, '2020-04-03 13:30:00', '2020-04-06', null, 1700000, null, 194988929),
(567236, '2020-04-03 13:30:00', '2020-04-06', null, 1700000, null, 194988930),
(567237, '2020-04-03 13:30:00', '2020-04-06', null, 1700000, null, 194988931),
(567238, '2020-04-03 13:30:00', '2020-04-06', null, 1700000, null, 194988932)

INSERT INTO Categoria VALUES
('Hamburguesas', 'Todo tipo de hamburguesas!'),
('Gaseosas', 'Gaseosas de todo tipo.')

INSERT INTO EstadoCombo VALUES
('Activo', 'El combo se encuentra disponible actualmente.'),
('Descontinuado', 'El combo no se encuentra disponible actualmente.')

INSERT INTO Combo VALUES
('C2830', 'Combo Kangreburger', 'Ideal para niños.', 21900, 'https://cdn-www.konbini.com/mx/files/2017/06/krabbypatty820430.jpg', 1)

INSERT INTO EstadoMenu VALUES
('Activo', 'El menu se encuentra disponible actualmente.'),
('Descontinuado', 'El menu no se encuentra disponible actualmente.')

INSERT INTO Menu VALUES
('M9283', 'Hamburguesa sencilla', 'Buena hamburguesa personal', 11900, 'https://images.unsplash.com/photo-1551615593-ef5fe247e8f7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1080&q=80', 1, 1, null),
('M9284', 'Hamburguesa doble carne', 'Buena con doble carne y mas sabor!', 13900, 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=902&q=80', 1, 1, null),
('M9285', 'Gaseosa Coca-Cola lata', 'Refrescante y clasica', 4900, 'https://images.unsplash.com/photo-1554866585-cd94860890b7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=701&q=80', 1, 2, 'C2830')

INSERT INTO Proveedor VALUES
('Don Juan', 'Juancho', '3192670339')

INSERT INTO TipoMedida VALUES
('Kg','Kilogramo'),
('Lt.','Lito'),
('Cantidad','Cantidad')

INSERT INTO EstadoProducto VALUES
('Activo', 'El producto se encuentra disponible actualmente.'),
('Descontinuado', 'El producto no se encuentra disponible actualmente.')

INSERT INTO Producto VALUES
('P6281', 'Carne', 3000, '2020-06-12', 1, 1, 1),
('P6282', 'Pan', 3000, '2020-06-12', 1, 1, 1)

INSERT INTO Ingredientes VALUES
(2, 'P6281', 'M9284'),
(2, 'P6282', 'M9284')

INSERT INTO Inventario VALUES
('2020-04-03 13:00:00', 20, 60000, 'P6281', 1),
('2020-04-03 13:00:00', 20, 60000, 'P6282', 1)

INSERT INTO EstadoVenta VALUES
('Aprovada', 'La venta se realizo exitosamente.'),
('Pendiente', 'Se esta esperando a realizar la venta.'),
('Procesando', 'La venta fue acreditada y se esta procesando el pago.'),
('Cancelada', 'La venta fue cancelada.'),
('Rechazada', 'La venta no se realizo debido a algun error.')

INSERT INTO Venta VALUES
('2020-04-03 23:27:00', 13900, 2641, 194988929, 1)

INSERT INTO Pedido VALUES
(1, 13900, 'M9284', null, 10000)






