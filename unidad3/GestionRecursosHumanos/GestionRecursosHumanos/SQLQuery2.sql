INSERT INTO Cargos
(Nombre, UsuarioId, Codigo)
VALUES
('Gerente de Ventas', 1, 'GVEN');
SELECT SCOPE_IDENTITY();

SELECT * FROM Cargos

SELECT 1
FROM Cargos
WHERE Nombre = 'Gerente de Ventas' AND UsuarioId = 1