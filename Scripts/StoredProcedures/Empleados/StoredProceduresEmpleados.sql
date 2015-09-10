USE [Uricao]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaEmpleadoActivos]
AS
BEGIN

	SELECT usuario.*,rol.nombreRol,
       det.IdDir, det.nombreDireccion,
       ciudad.IdDir, ciudad.nombreDireccion,
       estado.IdDir, estado.nombreDireccion,
       pais.IdDir, pais.nombreDireccion
FROM [Uricao].[dbo].[Usuario] usuario, [Uricao].[dbo].[Usuario_Rol] u_r, [Uricao].[dbo].[Rol] rol,
	 Direccion det, Direccion ciudad, Direccion estado, Direccion pais
WHERE (u_r.fkidUsuario = usuario.idUsuario)
AND (u_r.fkidRol = rol.idRol)
AND (nombreRol = 'Administrador de la Empresa'
OR nombreRol = 'Personal Odontologico'
OR nombreRol = 'Secretaria'
OR nombreRol = 'Administrador del Sistema')
AND (pais.IdDir = estado.fkIdDireccion)
AND (estado.IdDir = ciudad.fkIdDireccion)
AND (ciudad.IdDir = det.fkIdDireccion)
AND (det.IdDir = usuario.fkidDireccion)
AND (usuario.estado = 'Activo')
		
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActivarInactivarEmpleado]
(
@id bigint,
@estado nchar(50)
)
AS
BEGIN
	UPDATE Usuario
	SET Usuario.estado=@estado
	WHERE Usuario.idUsuario=@id;
END;

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarPais]
AS
BEGIN
	SET NOCOUNT ON;
	
select IdDir, nombreDireccion
from Direccion
where tipoDireccion='Pais'
end

go
CREATE PROCEDURE [dbo].[ConsultarEstadoPais]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
select dd.IdDir, dd.nombreDireccion
from Direccion d, Direccion dd
where dd.tipoDireccion='Estado'
and dd.fkIdDireccion=d.IdDir
and d.nombreDireccion=@parametro and d.tipoDireccion='Pais'
end

GO
CREATE PROCEDURE [dbo].[AgregarEmpleado]
@login VARCHAR(50),
@password VARCHAR(50),
@tipoCi VARCHAR(50),
@cedula VARCHAR(50),
@primerNombre VARCHAR(50),
@primerApellido VARCHAR(50),
@fechaNace DATE,
@sexo VARCHAR(50),
@correo VARCHAR(50),
@fkIdDireccion bigint,
@estado VARCHAR(50),
@sueldo VARCHAR (50)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO Usuario(loginUser,passwordUser,tipoidUser,cedulaUser,nombreUser1,apellidoUser1,nacimientoUser,generoUser,correoUser,fkidDireccion,estado,ingresoUser)
VALUES		       (@login,@password,@tipoCi,@cedula,@primerNombre,@primerApellido,@fechaNace,@sexo,@correo,@fkIdDireccion,@estado,@sueldo);
END;

GO
CREATE PROCEDURE [dbo].[AsignarRolEmpleado]
@especialidad VARCHAR (50)
AS

BEGIN
INSERT INTO Usuario_Rol(fkidUsuario,fkidRol)
     VALUES((Select MAX(idUsuario) FROM Usuario),(Select Rol.idRol FROM Rol WHERE Rol.nombreRol = @especialidad))
END;



				
go
create PROCEDURE [dbo].[ConsultarCiudadEstado]
@parametro varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
select dd.IdDir, dd.nombreDireccion
from Direccion d, Direccion dd
where dd.tipoDireccion='Ciudad'
and dd.fkIdDireccion=d.IdDir
and d.nombreDireccion=@parametro and d.tipoDireccion='Estado'
end


GO

CREATE PROCEDURE [dbo].[ListaEmpleadoInactivos]
AS
BEGIN

	SELECT usuario.*,rol.nombreRol,
       det.IdDir, det.nombreDireccion,
       ciudad.IdDir, ciudad.nombreDireccion,
       estado.IdDir, estado.nombreDireccion,
       pais.IdDir, pais.nombreDireccion
FROM [Uricao].[dbo].[Usuario] usuario, [Uricao].[dbo].[Usuario_Rol] u_r, [Uricao].[dbo].[Rol] rol,
	 Direccion det, Direccion ciudad, Direccion estado, Direccion pais
WHERE (u_r.fkidUsuario = usuario.idUsuario)
AND (u_r.fkidRol = rol.idRol)
AND (nombreRol = 'Administrador de la Empresa'
OR nombreRol = 'Personal Odontologico'
OR nombreRol = 'Secretaria'
OR nombreRol = 'Administrador del Sistema')
AND (pais.IdDir = estado.fkIdDireccion)
AND (estado.IdDir = ciudad.fkIdDireccion)
AND (ciudad.IdDir = det.fkIdDireccion)
AND (det.IdDir = usuario.fkidDireccion)
AND usuario.estado = 'Inactivo'
		
END;

go
create PROCEDURE [dbo].[AgregarDireccionEmpleado]
@detalle varchar(50),
@ciudad varchar(50)
AS
BEGIN
SET NOCOUNT ON;

INSERT INTO Direccion(nombreDireccion,fkIdDireccion,tipoDireccion)
VALUES (@detalle,(Select IdDir From Direccion Where @ciudad = nombreDireccion AND tipoDireccion = 'Ciudad'),'Detalle')

end;

go
create PROCEDURE [dbo].[AgregarTelefonoEmpleado]
@telefono varchar(50),
@tipo varchar(50)
AS
BEGIN
SET NOCOUNT ON;

INSERT INTO Telefono(numeroTelefono,fkIdUsuario,tipoTelefono)
VALUES (@telefono,(Select MAX(idUsuario)From Usuario),@tipo)

end;


GO
CREATE PROCEDURE [dbo].[ModificarEmpleado]
@idUsuario bigint,
@login VARCHAR(50),
@password VARCHAR(50),
@tipoCi VARCHAR(50),
@cedula VARCHAR(50),
@primerNombre VARCHAR(50),
@primerApellido VARCHAR(50),
@fechaNace DATE,
@sexo VARCHAR(50),
@correo VARCHAR(50),
@sueldo VARCHAR (50)
AS
BEGIN
SET NOCOUNT ON;
UPDATE  Usuario  SET loginUser = @login,passwordUser = @password,tipoidUser=@tipoCi,cedulaUser=@cedula,nombreUser1=@primerNombre,apellidoUser1=@primerApellido,nacimientoUser=@fechaNace,generoUser=@sexo,correoUser=@correo,ingresoUser=@sueldo
Where		       @idUsuario=IdUsuario;
END;


go
create PROCEDURE [dbo].[ModificarTelefonoEmpleado]
@telefono varchar(50),
@tipo varchar(50),
@idUsuario bigint
AS
BEGIN
SET NOCOUNT ON;

UPDATE Telefono SET numeroTelefono = @telefono,tipoTelefono=@tipo
Where fkIdUsuario=@idUsuario

end;



go
create PROCEDURE [dbo].[ModificarDireccionEmpleado]
@detalle varchar(500),
@ciudad varchar(500),
@idUsuario bigint
AS
BEGIN
SET NOCOUNT ON;

UPDATE  Direccion SET nombreDireccion = @detalle, fkIdDireccion = (Select IdDir From Direccion Where nombreDireccion = @ciudad )
Where  IdDir = (Select fkIdDireccion FROM Usuario where idUsuario = @idUsuario)

end;





go

create PROCEDURE [dbo].[ModificarRolEmpleado]
@especialidad varchar(50),
@idUsuario bigint
as
BEGIN
SET NOCOUNT ON;

UPDATE Usuario_Rol SET fkidRol = (Select idRol FROM Rol where nombreRol = @especialidad)
Where @idUsuario = fkidUsuario

end;
