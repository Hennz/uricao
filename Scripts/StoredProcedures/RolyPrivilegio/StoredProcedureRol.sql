USE [Uricao]
GO
CREATE PROCEDURE [dbo].[AgregarRol]
@nombreRol nchar(50),
@descripcionRol text,
@estadoRol nchar(10)
AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol]
           ,[estado])
     VALUES
           (@nombreRol
           ,@descripcionRol
           ,@estadoRol)	
END;
GO

CREATE PROCEDURE [dbo].[ConsltarRolid]
@idRolBusca int
AS

BEGIN
SELECT [idRol]
      ,[nombreRol]
      ,[descripcionRol]
      ,[estado]
  FROM [Uricao].[dbo].[Rol]
  WHERE idRol=@idRolBusca
END;
GO

CREATE PROCEDURE [dbo].[ConsltarRolnombre]
@nombreRolBusca varchar(50)
AS

BEGIN
SELECT [idRol]
      ,[nombreRol]
      ,[descripcionRol]
      ,[estado]
  FROM [Uricao].[dbo].[Rol]
  WHERE UPPER(nombreRol) LIKE UPPER(LTRIM(@nombreRolBusca))
END;
GO

CREATE PROCEDURE [dbo].[ConsltarRoldescrip]
@descripRolBusca varchar(50)
AS

BEGIN
SELECT [idRol]
      ,[nombreRol]
      ,[descripcionRol]
      ,[estado]
  FROM [Uricao].[dbo].[Rol]
  WHERE descripcionRol LIKE (@descripRolBusca)
END;
GO

CREATE PROCEDURE [dbo].[ConsltarRolestado]
@estadoRolBusca varchar(50)
AS

BEGIN
SELECT [idRol]
      ,[nombreRol]
      ,[descripcionRol]
      ,[estado]
  FROM [Uricao].[dbo].[Rol]
  WHERE UPPER(estado) LIKE UPPER(LTRIM(@estadoRolBusca))
END;
GO

CREATE PROCEDURE [dbo].[ConsltarRoltodo]
AS

BEGIN
SELECT [idRol]
      ,[nombreRol]
      ,[descripcionRol]
      ,[estado]
  FROM [Uricao].[dbo].[Rol]
END;
GO

CREATE PROCEDURE [dbo].[ModificarRol]
@idRolModf bigint,
@nombreRolModf nchar(50),
@descripRolModf text,
@estadoRolModf nchar(10)
AS

BEGIN
UPDATE [Uricao].[dbo].[Rol]
   SET [nombreRol] = @nombreRolModf
      ,[descripcionRol] = @descripRolModf
      ,[estado] = @estadoRolModf
 WHERE idRol = @idRolModf
END;
GO

CREATE PROCEDURE [dbo].[AsignarRol]
@idUsuarioAsig bigint,
@idRolAsig bigint
AS

BEGIN
INSERT INTO [Uricao].[dbo].[Usuario_Rol]
           ([fkidUsuario]
           ,[fkidRol])
     VALUES
           (@idUsuarioAsig
           ,@idRolasig)
END;
GO

CREATE PROCEDURE [dbo].[ConsultarRol]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	nombreRol 
	FROM Rol	
	ORDER BY nombreRol
END
GO

CREATE PROCEDURE [dbo].[ActivarInactivarRol]
(
@idRol bigint,
@estado nchar(50)
)
AS
BEGIN
	UPDATE rol
	SET estado = @estado
	WHERE idRol = @idRol;
END
GO

CREATE PROCEDURE [dbo].[ConsultarRolLista]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT	* 
	FROM Rol;
END