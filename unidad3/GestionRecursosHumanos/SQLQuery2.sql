CREATE PROCEDURE Cargos_Insertar
	@Nombre NVARCHAR(50),
	@UsuarioId INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Cargos (Nombre, UsuarioId)
	VALUES (@Nombre, @UsuarioId);

	Select SCOPE_IDENTITY();
END