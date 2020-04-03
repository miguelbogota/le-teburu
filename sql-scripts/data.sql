
-- Usar la base de datos
USE TeburuDB
GO

INSERT INTO Restaurante VALUES
('Kennedy', 4005700, '06:00', '22:00', 'Cra. 78K #35 Sur-39', 'Bogotá', 'Colombia'),
('Modelia', 4005700, '06:00', '22:00', 'Cl. 26 #22-09', 'Bogotá', 'Colombia')

INSERT INTO Persona VALUES
(1126826757, 'Cedula', 'Miguel Angel', 'Bogota Rico', 'M', '1996-11-09', 3197029889, 'miguelbogota.rico@gmail.com', 'Cl. 54c Sur #95a-18', 'Bogotá', 'Colombia'),
(982734898, 'Cedula', 'Angie Valeria', 'Ramirez Herrera', 'F', '1997-05-23', 3198720927, 'angieramirez@gmail.com', 'Cl. 52 #12-45', 'Bogotá', 'Colombia')

INSERT INTO Empleado VALUES
(12345678, '1234Abcd', 'Cajero', 'A', 1500000.00, 'Prestaciones', '2019-05-14 14:00:00', 1126826757, 1),
(12345679, 'Abcd1234', 'Gerente', 'A', 1800000.00, 'Prestaciones', '2019-05-14 14:00:00', 982734898, 2)

INSERT INTO Proveedor VALUES
('Postobon', 3173980928)

INSERT INTO Categoria VALUES
('Hamburguesas', 'Lista de todas las hamburguesas'),
('Combos', 'Diferentes comboes'),
('Ensaladas', 'Esaladitas')

INSERT INTO Menu VALUES
('Hamburguesa doble carne', 'Hamburguesa con doble carne', 'https://www.saborusa.com/wp-content/uploads/2019/10/67.-Hamburguesa-de-carne.png', 11900, 'A', 1),
('Hamburguesa Pollo', 'Hamburguesa con sencilla', 'https://cdn2.cocinadelirante.com/sites/default/files/styles/gallerie/public/images/2018/08/hamburguesas-caseras-receta-facil.jpg', 8900, 'A', 1),
('Cine', 'Combo para cine', 'https://cinemultiplex.co/sites/default/files/styles/comida_modal/public/4%20COMBO%20DE%20PELICULA.png?itok=9Req35Fe', 22900, 'A', 2),
('Esalada gourmet', 'Gourmet', 'https://d1uz88p17r663j.cloudfront.net/original/84e720e8bc62d59c69924ba55da2b810_ensalada_de_pollo_1.jpg', 5900, 'A', 3),
('Esalada Caesar', 'Esalada', 'https://static.vix.com/es/sites/default/files/styles/4x3/public/imj/elgranchef/R/Receta-de-ensalada-Cesar-1.jpg?itok=1RBs6hiJ', 7900, 'A', 3)

INSERT INTO Producto VALUES
('Carne Doble', 4000, 'A', 1, 1),
('Pan', 2000, 'A', 1, 1),
('Lechuga verde', 3000, 'A', 1, 1),
('Pollo', 5000, 'A', 2, 1),
('Pan integral', 2000, 'A', 2, 1),
('Tomates', 300, 'A', 2, 1),
('Crispetas', 19300, 'A', 3, 1),
('Gaseosa', 3900, 'A', 3, 1),
('Cebolla', 1900, 'A', 4, 1),
('Durazno', 5900, 'A', 4, 1),
('Salsa Caesar', 7900, 'A', 5, 1),
('Mango', 2900, 'A', 5, 1),

('Gaseosa Colombiana', 2500, 'A', null, 1),
('Gaseosa Uva', 2500, 'A', null, 1),
('Gaseosa Manzana', 2500, 'A', null, 1)

INSERT INTO Inventario VALUES
('2020-04-02', 2000, 8, 1, 1),
('2020-04-02', 500000, 200, 2, 1),
('2020-04-02', 300000, 120, 3, 1)


