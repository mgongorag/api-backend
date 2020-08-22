/*****************************************************/
/********SCRIPTS DE PROCEDIMIENTOS ALMACENADOS********/
/*****************************************************/

--PROCEDIMIENTO PARA INSERTAR USUARIO

/*
	AUTOR: Miguel Góngora
	FECHA: 19/08/2020
*/
DROP PROCEDURE Sesion.SPAgregarUsuario;
CREATE PROCEDURE Sesion.SPAgregarUsuario(
									@_TxtNombres	NVARCHAR(50),
									@_TxtApellidos	NVARCHAR(50),
									@_TxtDireccion	NVARCHAR(150),
									@_TxtEmail		NVARCHAR(100),
									@_TxtPassword   NVARCHAR(130)
									)
AS
DECLARE @_FilasAfectadas	TINYINT,
		@_Resultado			SMALLINT,
		@_UltimoId			SMALLINT
BEGIN
BEGIN TRAN
	--SE OBTIENE EL ULTIMO ID GUARDADO EN LA TABLA 
	SELECT @_UltimoId = ISNULL(MAX(a.IdUsuario),0)
	FROM Sesion.TblUsuarios AS a

	BEGIN TRY
		INSERT Sesion.TblUsuarios (
									IdUsuario,
									TxtNomBres,
									TxtApellidos,
									TxtDireccion,
									TxtEmail,
									TxtPassword,
									FechaDeIngreso,
									IntEstado
									)
		VALUES					  (
									@_UltimoId +1,
									@_TxtNombres,
									@_TxtApellidos,
									@_TxtDireccion,
									@_TxtEmail,
									@_TxtPassword,
									GETDATE(),
									1
									)
		SET @_FilasAfectadas	= @@ROWCOUNT
	END TRY

	BEGIN CATCH
		SET @_FilasAfectadas		= 0
	END CATCH

--DETERMINAR SI SE REALIZO CORRECTAMENTE LA TRANSACCION ANTERIOR
 IF(@_FilasAfectadas > 0)
	BEGIN
		SET @_Resultado	= @_UltimoId + 1
		COMMIT
	END
ELSE
	BEGIN
		SET @_Resultado = 0
		ROLLBACK
	END
--DEVOLVER RESULTADO : ULTIMO ID QUE UTILIZARE MAS ADELANTE
SELECT Resultado = @_Resultado

END --FIN

--PROBANDO EL PROCEDIMIENTO
EXEC Sesion.SPAgregarUsuario 'Juan', 'Marroquin', 'SantaElena', 'juan@gmail.com', '123'



/*
	AUTOR: Miguel Gongora
	FECHA: 15/08/2020
*/

--PROCEDIMIENTO PARA OBTENER TODOS LOS USUARIOS
CREATE PROCEDURE Sesion.SPObtenerUsuarios
AS
BEGIN
	SELECT
		a.IdUsuario,
		CONCAT(a.TxtNombres, ' ', a.TxtApellidos) AS TxtNombres,
		a.TxtDireccion,
		a.TxtEmail,
		a.TxtPassword,
		a.FechaDeIngreso,
		a.IntEstado
		
	FROM Sesion.TblUsuarios		AS a
	WHERE a.IntEstado			> 0
END


/*
	AUTOR: Miguel Gongora
	FECHA: 15/08/2020
*/
--PROCEDIMIENTO PARA OBTENER USUARIOS POR ID
CREATE PROCEDURE Sesion.SPObtenerDatosUsuarios	(
													@_IdUsuario INT
												)
AS
BEGIN
	SELECT
		a.IdUsuario,
		a.TxtNombres,
		a.TxtApellidos,
		a.TxtDireccion,
		a.TxtEmail,
		a.TxtPassword,
		a.FechaDeIngreso,
		a.IntEstado
	FROM Sesion.TblUsuarios		AS a
	WHERE a.IdUsuario = @_IdUsuario

END --FIN

/*
	AUTOR: Miguel Gongora
	FECHA: 15/08/2020
*/
--PROCEDIMIENTO PARA ELIMINAR USUARIO POR ID
CREATE PROCEDURE Sesion.SPEliminarUsuario	(
													@_IdUsuario INT
												)
AS
DECLARE 
		@_FilasAfectadas	TINYINT,
		@_Resultado			INT
BEGIN
	BEGIN TRAN
		BEGIN TRY
			UPDATE Sesion.TblUsuarios
			SET IntEstado			= 0
			WHERE IdUsuario = @_IdUsuario

			SET @_FilasAfectadas = @@ROWCOUNT
		END TRY

		BEGIN CATCH
			SET @_FilasAfectadas = 0
		END CATCH

		IF(@_FilasAfectadas > 0)
			BEGIN
				SET @_Resultado		= @_IdUsuario
				COMMIT
			END
		ELSE
			BEGIN
				SET @_Resultado		= 0
				ROLLBACK
			END

		
		SELECT Resultado			= @_Resultado
END --FIN


/*
	AUTOR: Miguel Gongora
	FECHA: 15/08/2020
*/
--PROCEDIMIENTO PARA ELIMINAR USUARIO POR ID
CREATE PROCEDURE Sesion.SPActualizarUsuario	(
													@_IdUsuario		INT,
													@_TxtNombres	NVARCHAR(50),
													@_TxtApellidos	NVARCHAR(50),
													@_TxtDireccion	NVARCHAR(150),
													@_TxtEmail		NVARCHAR(100),
													@_TxtPassword	NVARCHAR(256)
												)
AS
DECLARE 
		@_FilasAfectadas	TINYINT,
		@_Resultado			INT
BEGIN
	BEGIN TRAN
		BEGIN TRY
			UPDATE Sesion.TblUsuarios
			SET 
				TxtNomBres		= @_TxtNombres,
				TxtApellidos	= @_TxtApellidos,
				TxtDireccion	= @_TxtDireccion,
				TxtEmail		= @_TxtEmail,
				TxtPassword		= @_TxtPassword
				
			WHERE IdUsuario = @_IdUsuario

			SET @_FilasAfectadas = @@ROWCOUNT
		END TRY

		BEGIN CATCH
			SET @_FilasAfectadas = 0
		END CATCH

		IF(@_FilasAfectadas > 0)
			BEGIN
				SET @_Resultado		= @_IdUsuario
				COMMIT
			END
		ELSE
			BEGIN
				SET @_Resultado		= 0
				ROLLBACK
			END

		
		SELECT Resultado			= @_Resultado
END --FIN

SELECT RESULTADO;