USE [Uricao]
GO

--DROP PROCEDURE BuscarLogin
--DROP PROCEDURE BuscarPrivilegios
--DROP PROCEDURE ConsultarUsuarioTodo
--DROP PROCEDURE ConsultarUsuarioTelefono
--DROP PROCEDURE ConsultarUsuarioDireccion
--DROP PROCEDURE ConsultarUsuarioNombre
--DROP PROCEDURE ConsultarUsuarioApellido
--DROP PROCEDURE ConsultarUsuarioRol
--DROP PROCEDURE ConsultarUsuarioIdentificacion
--DROP PROCEDURE ConsultarUsuarioUsuario
--DROP PROCEDURE ComboPais
--DROP PROCEDURE ComboEstadoPais
--DROP PROCEDURE ComboCiudadEstado
--DROP PROCEDURE ConsultarUsuarioPorIdentificador
--DROP PROCEDURE ModificarUsuario;
--DROP PROCEDURE ActivarInactivarUsuario;

CREATE PROCEDURE [dbo].[BuscarLogin]
@nombreUsuario varchar(50),
@contraseña varchar(50)
AS
BEGIN

select loginUser, passwordUser, estado
from Usuario 
where loginUser=@nombreUsuario 
	and passwordUser=@contraseña
	
END
GO

CREATE PROCEDURE [dbo].[BuscarPrivilegios]
@nombreUsuario varchar(50)
AS
BEGIN

select pr.fkIdPrivilegio
from Usuario, Usuario_Rol ur, Rol, Privilegio_Rol pr
where loginUser=@nombreUsuario 
	and idUsuario=ur.fkidUsuario
	and idRol=ur.fkidRol
	and idRol=pr.fkIdRol
	
END
GO
USE [Uricao]
GO

CREATE PROCEDURE [dbo].[ConsultarUsuarioTodo]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.correoUser,
		U.idUsuario,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO

CREATE PROCEDURE [dbo].[ConsultarUsuarioTelefono]
@loggin varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 	numeroTelefono
	FROM Usuario,Telefono
	where fkIdUsuario=idUsuario and
		loginUser= @loggin
	Group by numeroTelefono
END
GO

CREATE PROCEDURE [dbo].[ConsultarUsuarioDireccion]
@loggin varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT D.nombreDireccion, D.tipoDireccion, DD.nombreDireccion, DD.tipoDireccion, DDD.nombreDireccion, DDD.tipoDireccion, DDDD.nombreDireccion, DDDD.tipoDireccion, DDDDD.nombreDireccion, DDDDD.tipoDireccion, DDDDDD.nombreDireccion, DDDDDD.tipoDireccion
	FROM Direccion D, Usuario U, Direccion DD, Direccion DDD, Direccion DDDD, Direccion DDDDD, Direccion DDDDDD
	where D.fkIdDireccion=DD.IdDir and
		DD.fkIdDireccion=DDD.IdDir and
		DDD.fkIdDireccion=DDDD.IdDir and
		DDDD.fkIdDireccion=DDDDD.IdDir and
		DDDDD.fkIdDireccion=DDDDDD.IdDir and
		U.fkidDireccion=D.IdDir and
		U.loginUser = @loggin                                         
	group by D.nombreDireccion, D.tipoDireccion, DD.nombreDireccion, DD.tipoDireccion, DDD.nombreDireccion, DDD.tipoDireccion, DDDD.nombreDireccion, DDDD.tipoDireccion, DDDDD.nombreDireccion, DDDDD.tipoDireccion, DDDDDD.nombreDireccion, DDDDDD.tipoDireccion
	
	
END
GO

GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioNombre]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		(U.nombreUser1 like @parametro or U.nombreUser2 like @parametro) and
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO
GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioApellido]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		(U.apellidoUser1 like @parametro or U.apellidoUser2 like @parametro) and
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO

GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioRol]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		R.nombreRol like @parametro and
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO

GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioIdentificacion]
@parametro [nvarchar](50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		U.cedulaUser=@parametro and
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO

GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioUsuario]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.loginUser,
		U.nombreUser1, 
		U.nombreUser2,
		U.apellidoUser1,
		U.apellidoUser2,
		U.tipoidUser,
		U.cedulaUser,
		U.nacimientoUser,
		R.nombreRol,
		U.generoUser,
		U.fotoUser,
		U.estado,
		U.ocupacionUser,
		U.ingresoUser		
	FROM Usuario U , Rol R, Usuario_Rol UR
	where UR.fkidRol=R.idRol and 
		U.loginUser like @parametro and
		UR.fkidUsuario = U.idUsuario 		
	ORDER BY R.nombreRol
END
GO

use Uricao
Go	

CREATE PROCEDURE [dbo].[ComboPais]
AS
BEGIN
	SET NOCOUNT ON;
	
select nombreDireccion
from Direccion
where tipoDireccion='Pais'
end

go
CREATE PROCEDURE [dbo].[ComboEstadoPais]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
select dd.nombreDireccion
from Direccion d, Direccion dd
where dd.tipoDireccion='Estado'
and dd.fkIdDireccion=d.IdDir
and d.nombreDireccion=@parametro and d.tipoDireccion='Pais'
end


go
create PROCEDURE [dbo].[ComboCiudadEstado]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
select dd.nombreDireccion
from Direccion d, Direccion dd
where dd.tipoDireccion='Ciudad'
and dd.fkIdDireccion=d.IdDir
and d.nombreDireccion=@parametro and d.tipoDireccion='Estado'
end

GO

CREATE PROCEDURE [dbo].[ConsultarUsuarioPorIdentificador]
@paramIdUsuario integer

AS

BEGIN
	SET NOCOUNT ON;
	
	SELECT U.idUsuario, 
	    U.cedulaUser,
	    U.tipoidUser,
		U.nombreUser1, 
		U.apellidoUser1,
		U.apellidoUser2	
	FROM Usuario U
	where [idUsuario]=@paramIdUsuario		
END

-------------AGREGAR USUARIO-------------

CREATE PROCEDURE [dbo].[AgregarUsuario]

( 	
	@login [nchar](50),
	@password [nchar](50), 
	@tipoCi [nchar](50), 
	@cedula [nvarchar](50), 
	@primerNombre [nchar](50), 
	@segundoNombre [nchar](50), 
	@primerApellido [nchar](50), 
	@segundoApellido [nchar](50), 
	@fechaNace [date], 
	@fechaIngreso [date], 
	@sexo [nchar](50), 
	@correo [nchar](50),
	@foto [nchar](50), 
	@estado [nchar](10),
	@codigotlf [nchar](10),@numtelefono [nchar](20),@tipotelefono [nchar](20),
	@ciudad [nchar](50),@municipio [nchar](50),@calle [nchar](50),@edificio [nchar](50)--,@casa [nchar](50)
)

AS

BEGIN

	INSERT INTO Direccion VALUES(@municipio,'Municipio',(SELECT IdDir FROM Direccion WHERE nombreDireccion = @ciudad));
	DECLARE @fkidDireccion INT;
	SET @fkidDireccion = SCOPE_IDENTITY();
	INSERT INTO Direccion VALUES(@calle,'Calle',@fkidDireccion);
	SET @fkidDireccion = SCOPE_IDENTITY();
	INSERT INTO Direccion VALUES(@edificio,'Edificio',@fkidDireccion);
	--INSERT INTO Direccion VALUES(@casa,'Casa',@calle);
	
	SET @fkidDireccion = SCOPE_IDENTITY();
	
	INSERT INTO [Uricao].[dbo].[Usuario]
		        ([loginUser],[passwordUser],[tipoidUser],[cedulaUser],[nombreUser1],[nombreUser2],[apellidoUser1],
				[apellidoUser2],[nacimientoUser],[fechIngresoUser],[generoUser],[correoUser],[ocupacionUser],
				[fkidDireccion],[fotoUser],[estado],[ingresoUser])		
    VALUES
          (@login,@password,@tipoCi,@cedula,@primerNombre,@segundoNombre,@primerApellido,@segundoApellido,
		   @fechaNace,@fechaIngreso,@sexo,@correo,NULL,@fkidDireccion,@foto,@estado,NULL);

	
	INSERT INTO [Uricao].[dbo].[Usuario_Rol] 
			([fkidUsuario],[fkidRol]) 
	VALUES 
		   ((SELECT [idUsuario] FROM [Uricao].[dbo].[Usuario] WHERE cedulaUser = @cedula),(SELECT [idRol] FROM [Uricao].[dbo].[Rol] WHERE nombreRol = 'Cliente'))
		   
		   			   
	INSERT INTO [Uricao].[dbo].[Telefono] 
				([codigoTelefono],[numeroTelefono],[tipoTelefono],[fkIdUsuario],[fkIdProveedor],[fkIdContacto])				 
	VALUES 
		   (@codigotlf,@numtelefono,@tipotelefono,(SELECT [idUsuario] FROM [Uricao].[dbo].[Usuario] WHERE cedulaUser = @cedula),NULL,NULL)
				
END
GO
-------------MODIFICAR USUARIO-------------



CREATE PROCEDURE [dbo].[ModificarUsuario]

(
@login [nchar](50),
@password [nchar](50), 
@tipoCi [nchar](50), 
@cedula [nvarchar](50),
@cedulaOriginal [nvarchar](50),
@primerNombre [nchar](50), 
@segundoNombre [nchar](50), 
@primerApellido [nchar](50), 
@segundoApellido [nchar](50), 
@fechaNace [date], 
@fechaIngreso [date], 
@sexo [nchar](50), 
@correo [nchar](50),
@foto [nchar](50), 
@estado [nchar](10),
@codigotlf [nchar](10),@numtelefono [nchar](20),@tipotelefono [nchar](20),
@ciudad [nchar](50),@municipio [nchar](50),@calle [nchar](50),@edificio [nchar](50)--,@casa [nchar](50)
)

AS

BEGIN

UPDATE Direccion SET nombreDireccion=@municipio,tipoDireccion='Municipio',fkIdDireccion=(SELECT IdDir FROM Direccion WHERE nombreDireccion = @ciudad);
DECLARE @fkidDireccion INT;
DECLARE @fkidDireccionCasa INT;
SET @fkidDireccion = SCOPE_IDENTITY();
UPDATE Direccion SET nombreDireccion=@calle,tipoDireccion='Calle',fkIdDireccion=@fkidDireccion;
SET @fkidDireccion = SCOPE_IDENTITY();
UPDATE Direccion SET nombreDireccion=@edificio,tipoDireccion='Edificio',fkIdDireccion=@fkidDireccion;
--INSERT INTO Direccion VALUES(@casa,'Casa',@calle);
--SET @fkidDireccionCasa = (SELECT IdDir FROM Direccion WHERE nombreDireccion=@edificio);
UPDATE [Uricao].[dbo].[Usuario]
       --([loginUser],[passwordUser],[tipoidUser],[cedulaUser],[nombreUser1],[nombreUser2],[apellidoUser1],
--[apellidoUser2],[nacimientoUser],[fechIngresoUser],[generoUser],[correoUser],[ocupacionUser],
--[fkidDireccion],[fotoUser],[estado],[ingresoUser])	
    SET
          loginUser=@login,passwordUser=@password,tipoidUser=@tipoCi,cedulaUser=@cedula,nombreUser1=@primerNombre,nombreUser2=@segundoNombre,apellidoUser1=@primerApellido,apellidoUser2=@segundoApellido,
  nacimientoUser=@fechaNace,fechIngresoUser=@fechaIngreso,generoUser=@sexo,correoUser=@correo,fkidDireccion=(SELECT IdDir FROM Direccion WHERE nombreDireccion=@edificio),fotoUser=@foto,estado=@estado
WHERE cedulaUser=@cedulaOriginal;

    
UPDATE [Uricao].[dbo].[Telefono] 
--([codigoTelefono],[numeroTelefono],[tipoTelefono],[fkIdUsuario],[fkIdProveedor],[fkIdContacto])	 
SET 
  codigoTelefono=@codigotlf,numeroTelefono=@numtelefono,tipoTelefono=@tipotelefono,fkIdUsuario=(SELECT [idUsuario] FROM [Uricao].[dbo].[Usuario] WHERE cedulaUser = @cedulaOriginal),fkIdProveedor=NULL,fkIdContacto=NULL
END


-------------------Activar/Inactivar Usuario------------------
GO
CREATE PROCEDURE [dbo].[ActivarInactivarUsuario]
(
@ci bigint,
@state nchar(50)
)
AS

BEGIN
UPDATE Usuario
SET Usuario.estado=@state
WHERE Usuario.cedulaUser=@ci;
END