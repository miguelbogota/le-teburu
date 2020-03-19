
-- Usar la base de datos
USE teburuDB
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