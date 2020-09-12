/*****************************************************/
/********SCRIPTS DE PROCEDIMIENTOS ALMACENADOS********/
/*****************************************************/

--PROCEDIMIENTO PARA INSERTAR USUARIO

/*
	AUTOR: Miguel G�ngora
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

SELECT * FROM Sesion.tblUsuarios;
DELETE FROM Sesion.TblUsuarios where IdUsuario > 1;

UPDATE Sesion.TblUsuarios
SET IntEstado = 1;


/*
	AUTOR: Miguel Gongora
	FECHA: 15/08/2020
*/
--PROCEDIMIENTO DE INICIO DE SESION


CREATE PROC Sesion.SPInicioDeSesion(
										@_TxtEmail			NVARCHAR(50),
										@_TxtPassword		NVARCHAR(256),
										@_TxtToken			NVARCHAR(250),
										@_VigenciaEnMinutos	INT
									)
AS
DECLARE @_IdUsuario		INT,
		@_TxtUsuario	NVARCHAR(100),
		@_UltimoId		INT,
		@_IntResultado	TINYINT,
		@_FilasAfectadas TINYINT,
		@_IdInstitucion	SMALLINT

BEGIN

	SELECT	
		@_IdUsuario				= a.IdUsuario,
		@_TxtUsuario			= CONCAT(
											a.TxtNombres,
											' ',
											a.TxtApellidos
										),
		@_IdInstitucion			= b.IdUsuario
	FROM Sesion.TblUsuarios		AS a
			LEFT JOIN Sesion.TblUsuarios AS b
			ON b.IdUsuario			= a.IdUsuario
	WHERE		a.TxtEmail			= @_TxtEmail
			AND a.TxtPassword		= @_TxtPassword
			AND a.IntEstado			= 1

	BEGIN TRAN
		SELECT @_UltimoId			= ISNULL(Max(a.IdToken),0)
		FROM Sesion.TblTokens		AS a

		UPDATE Sesion.TblTokens
		SET		IntEstado			= 0
		WHERE   IdUsuario			= @_IdInstitucion
				AND IntEstado		> 0
				

		BEGIN TRY
			INSERT INTO Sesion.TblTokens	(
												IdToken,
												IdUsuario,
												TxtToken,
												VigenciaEnMinutos
											)
			VALUES							(
												@_UltimoId + 1,
												@_IdUsuario,
												@_TxtToken,
												@_VigenciaEnMinutos
											)
			SET @_FilasAfectadas			= @@ROWCOUNT
		END TRY

		BEGIN CATCH
			SET	@_FilasAfectadas			= 0
		END CATCH

		--DETERMINAR SI SE REALIZO CORRECTAMENTE LA TRANSACCION
		IF(@_FilasAfectadas > 0) 
			BEGIN
				SET @_IntResultado = 1
				COMMIT
			END
		ELSE
			BEGIN
				SET @_IntResultado			= 0
				SET @_TxtToken				= 'Usuario o contrase�a inv�lida'
				ROLLBACK
			END
		

		--DEVOLVER RESULTADO
		SELECT
			IntResultaldo					= @_IntResultado,
			TxtToken						= @_TxtToken,
			TxtUsuario						= @_TxtUsuario,
			IdInstitucion					= @_IdInstitucion

END

/*
	AUTOR: Miguel Gongora
	FECHA: 29/08/2020
*/
--FUNCION PARA VERIFICAR SI EL TOKEN NO HA EXPIRADO
CREATE FUNCTION Sesion.FnVerificarVigenciaToken (
													@_TxtToken		NVARCHAR(250)
												)
RETURNS TINYINT
AS
BEGIN
	DECLARE @_IntResultado				TINYINT		= 0,
			@_VigenciaEnMinutos			INT			= 30,
			@_FechaYHoraDeCreacion		DATETIME	= '2001-01-01 01:01:01.001',
			@_FechaYHoraActual			DATETIME	= GETDATE(),
			@_TiempoDeUsoEnMinutos		INT			= 0

	SELECT	
			@_VigenciaEnMinutos			= a.VigenciaEnMinutos,
			@_FechaYHoraActual			= a.FechaIngreso
	FROM	Sesion.TblTokens			AS a
	WHERE	a.TxtToken					= @_TxtToken
			AND a.IntEstado				= 1

	SET		@_TiempoDeUsoEnMinutos		= DATEDIFF(MINUTE, @_FechaYHoraActual, @_FechaYHoraActual)

	IF(@_TiempoDeUsoEnMinutos > @_VigenciaEnMinutos)
		BEGIN
			SET @_IntResultado = 0
		END
	ELSE
		BEGIN
			SET @_IntResultado = 1
		END

	RETURN @_IntResultado
END
										


/*
	AUTOR: Miguel Gongora
	FECHA: 29/08/2020
*/
--ACTUALIZAR VIGENCIA DE TOKEN EN CADA TRANSACCION
CREATE PROC Sesion.SPActualizarVigenciaToken	(
													@_TxtToken	NVARCHAR(250)
												)
AS
BEGIN
	--ELIMINAR TOKENS EXPIRADOS
	DELETE Sesion.TblTokens
	WHERE IntEstado = 0

	UPDATE	Sesion.TblTokens
	SET		FechaIngreso				= GETDATE()
	WHERE	TxtToken					= @_TxtToken
			AND IntEstado				= 1
END

/*
	AUTOR: Miguel Gongora
	FECHA: 29/08/2020
*/

--OBTENER ESTADO DEL TOKEN
CREATE PROC Sesion.SPObtenerEstadoToken	(
											@_TxtToken		NVARCHAR(250)
										)
AS
DECLARE @_EstadoToken TINYINT	= 0
BEGIN

	-- 0 = Expirado,
	-- 1 = Vigente
	SELECT @_EstadoToken = Sesion.FnVerificarVigenciaToken(@_EstadoToken)

	IF(@_EstadoToken = 1)
		BEGIN
			--Actualizar la vigencia del token
			EXEC Sesion.SPActualizarVigenciaToken 
		END

	SELECT EstadoToken	= @_EstadoToken

END


DROP PROCEDURE Sesion.SPInicioDeSesion;
CREATE PROC Sesion.SPInicioDeSesion(@_TxtEmail NVARCHAR(50), @_TxtPassword NVARCHAR(300), @_TxtToken NVARCHAR(250), @_VigenciaEnMinutos INT)

AS
DECLARE @_IdUsuario INT, @_TxtUsuario NVARCHAR(100), @_UltimoId int, @_IntResultado TINYINT, @_FilasAfectadas TINYINT, @_IdInstitucion SMALLINT

BEGIN
	SELECT
		@_IdUsuario = a.IdUsuario,
		@_TxtUsuario = CONCAT(a.TxtNombres, ' ', a.TxtApellidos),
		@_IdInstitucion = b.IdUsuario
	FROM Sesion.TblUsuarios AS a
		LEFT JOIN Sesion.TblUsuariosPorInstitucion AS b
		ON b.IdUsuario = a.IdUsuario
	WHERE a.TxtEmail = @_TxtEmail
		AND a.TxtPassword = @_TxtPassword
		AND a.IntEstado = 1

	BEGIN TRAN
		SELECT 
			@_UltimoId = ISNULL(MAX(a.IdToken),0)
		FROM Sesion.TblTokens AS a

		UPDATE Sesion.TblTokens
		SET IntEstado = 0
		WHERE IdUsuario = @_IdUsuario
			AND IntEstado > 0

	BEGIN TRY
		INSERT INTO Sesion.TblTokens(IdToken, IdUsuario, TxtToken, VigenciaEnMinutos, FechaIngreso, IntEstado)
		VALUES (@_UltimoId + 1, @_IdUsuario, @_TxtToken, @_VigenciaEnMinutos, GETDATE(), 1)
		SET @_FilasAfectadas = @@ROWCOUNT
	END TRY
	BEGIN CATCH
		SET @_FilasAfectadas = 0
	END CATCH

	--determina si se realizo correctamente la transaccion
	IF(@_FilasAfectadas > 0)
		BEGIN
			SET @_IntResultado = 1
			COMMIT
		END
	ELSE
		BEGIN
			SET @_IntResultado = 0
			SET	@_TxtToken = 'Usuario o contrase�a invalida'
			ROLLBACK
		END
	--devolver resultado
	SELECT
		IntResultado = @_IntResultado,
		TxtToken = @_TxtToken,
		TxtUsuario = @_TxtUsuario,
		IdIstitucion = @_IdInstitucion
END

EXEC Sesion.SPInicioDeSesion 'prueba@gmail.com', 'vPBTLVm/u9xYRiQsUp8sTefvptveDP9Aodpn4Im2r8EH24tOuHKmusHZ0RiOxYTLiK2mwCUCvS3YF/3xoBwUPA==', '122', 30
SELECT * FROM Sesion.TblUsuariosPorInstitucion
SELECT * FROM Sesion.TblUsuarios;
SELECT * FROM Sistema.TblInstituciones;
SELECT * FROM Sesion.TblTokens;

CREATE PROC Sesion.SPMenuUsuario 	(
								@_TxtToken NVARCHAR(250),
								@_idModulo TINY INT
							)
AS 
DECLARE	@_idUsuario INT = 0
BEGIN
	SELECT @_idUsuario = Sesion.FnObtenerIdUsuario(@_txtToken);
	SELECT
		b.idMenu,
		a.TxtNombres,
		a.txtLink,
		a.IdMenuPadre
		a.Txtimagen,
		b.Agregar,
		b.ModificarActualizar,
		b.Eliminar,
		b.Consultar,
		b.Imprimir,
		b.Reversar,
		b.Aprobar,
		b.Finalizar
	FROM 
		Sesion.TblMenus	AS a
		LEFT JOIN Sesion.TblRolesPorMenus	AS b
		ON a.IdMenu = b.IdMenu
		LEFT JOIN Sesion.TblRoles AS c
		ON c.IdRol = b.IdRol
		LEFT JOIN Sesion.TblUsuariosPorRoles AS d
		ON d.IdRol = c.IdRol 
		LEFT JOIN Sesion.TblUsuarios As e
		ON e.IdUsuario	= d.idUsuario
	WHERE
		a.IntEstado = 1
		AND a.IdModulo = @_idModulo
		AND b.IntEstado = 1
		AND c.intEstado = 1
		AND d.IntEstado = 1
	ORDER BY a.dblOrden ASC
END