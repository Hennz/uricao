USE [Uricao]

go

create procedure [dbo].[ActivarDesactivarTratamiento]
@idTratamiento Bigint ,
@estadoTratamiento char (15)
AS
begin
set nocount on;
	UPDATE [Uricao].[dbo].[Tratamiento]
	SET [estadoTratamiento]=@estadoTratamiento
	WHERE [IdTratamiento]=@idTratamiento;
end;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[AgregarTratamientoAsociado]
@fkidTratamiento2 bigint,
@fkidTratamiento1 bigint

AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
           ([fkidTratamiento1],
			[fkidTratamiento2])
     VALUES
           (@fkidTratamiento1,
			@fkidTratamiento2)	
END;
go
USE [Uricao]

go
CREATE PROCEDURE [dbo].[AgregarTratamiento]
@nombreTratamiento char (50),
@duracionTratamiento int,
@descripcionTratamiento text,
@costoTratamiento real,
@imagenTratamiento char (50), /*null*/
@explicacionTratamiento text,
@estadoTratamiento char (50)

AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Tratamiento]
           ([nombreTratamiento],
			[duracionTratamiento],
			[descripccionTratamiento],
			[costoTratamiento],
			[imagenTratamiento],
			[explicacionTratamiento],
			[estadoTratamiento])
     VALUES
           (LTRIM(@nombreTratamiento),
			LTRIM(@duracionTratamiento),
			@descripcionTratamiento,
			LTRIM(@costoTratamiento),
			@imagenTratamiento,
			@explicacionTratamiento,
			LTRIM(@estadoTratamiento));	
END;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[AgregarTratamientoProducto]
@fkProducto bigint,
@prioridad_trat_prod int,
@cantidad_trat_prod numeric,
@fkTratamiento bigint
AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
           ([fkProducto],
			[fkTratamiento],
			[prioridad_trat_prod],
			[cantidad_trat_prod])
     VALUES
           (@fkProducto,
			@fkTratamiento,
			@prioridad_trat_prod,
			@cantidad_trat_prod)	
END;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BorrarTratamientoAsociado]
@fkidTratamiento1 bigint
AS

BEGIN
	SET NOCOUNT ON;
	
	Delete From Tratamiento_Asociado
	where fkidTratamiento1=@fkidTratamiento1
END;
go

USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BorrarTratamientoProducto]
@fkTratamiento bigint
AS

BEGIN
	SET NOCOUNT ON;
	
	Delete From Tratamiento_Producto
	where fkTratamiento=@fkTratamiento
END;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BuscarProductoNoImplemento]
@idTratamiento bigint
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT p.idProducto, p.nombreProducto
	FROM Producto AS P 
	WHERE 
	p.idProducto not in  (SELECT TP.fkProducto FROM Tratamiento AS T, Tratamiento_Producto AS TP, Producto AS P WHERE TP.fkTratamiento=T.IdTratamiento AND T.IdTratamiento=@idTratamiento AND P.idProducto=TP.fkProducto);
End;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BuscarTodoImplementoTratamiento]
@idTratamiento bigint
AS

BEGIN
	SET NOCOUNT ON;
	
	SELECT TP.fkProducto,TP.fkTratamiento, TP.idtratProd, P.nombreProducto, TP.cantidad_trat_prod, TP.prioridad_trat_prod
	FROM TRATAMIENTO AS T, Tratamiento_Producto AS TP, Producto AS P
	WHERE 
		TP.fkProducto=P.idProducto AND
		TP.fkTratamiento=T.IdTratamiento AND 
		T.IdTratamiento=@idTratamiento;
End;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BuscarTodoProducto]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT P.*
	FROM Producto AS P;
End;
go
use [Uricao]
go
create procedure [dbo].[BuscarXEstadoTratamiento]
@EstadoTratamiento char(50)
as

BEGIN
	set nocount on
	/*obtener Tratamientos Por Estado*/
	SELECT T.*
	FROM TRATAMIENTO AS T
	WHERE 
		UPPER(T.estadoTratamiento)=UPPER(LTRIM(@EstadoTratamiento))
	ORDER BY T.IdTratamiento
	
END;
go
use [Uricao]
go
create procedure [dbo].[BuscarXIdTratamientos]
@idTratamiento int
as

BEGIN
	set nocount on
	/*obtener tratamientos por ID*/
	SELECT T.*
	FROM TRATAMIENTO AS T
	WHERE 
		T.IdTratamiento=@idTratamiento
	
END;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BuscarXNombreImplementoTratamiento]
@idTratamiento bigint,
@nombreProducto nvarchar(50)
AS

BEGIN
	SET NOCOUNT ON;
	
	SELECT TP.fkProducto,TP.fkTratamiento, TP.idtratProd, P.nombreProducto, TP.cantidad_trat_prod, TP.prioridad_trat_prod
	FROM TRATAMIENTO AS T, Tratamiento_Producto AS TP, Producto AS P
	WHERE 
		TP.fkProducto=P.idProducto AND
		TP.fkTratamiento=T.IdTratamiento AND 
		T.IdTratamiento=@idTratamiento AND
		UPPER(P.nombreProducto)=UPPER(LTRIM('%@nombreProducto%'));
End;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[BuscarXNombreProducto]
@nombreProducto nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT P.*
	FROM Producto AS P
	WHERE 
		UPPER(P.nombreProducto)=UPPER(LTRIM('%@nombreProducto%'));
End;
go
use [Uricao]
go
create procedure [dbo].[BuscarXNombreTratamiento]
@NombreTratamiento varchar(50)
as

BEGIN
	set nocount on
	/*obtener Tratamiento por Nombre*/
	SELECT T.*
	FROM TRATAMIENTO AS T
	WHERE 
		UPPER(T.nombreTratamiento) like UPPER(LTRIM(@NombreTratamiento))
    order by T.IdTratamiento		
END;
go
USE [Uricao]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[consultarListaTratamiento]

AS

BEGIN

SELECT [IdTratamiento]
      ,[nombreTratamiento]
      ,[duracionTratamiento]
      ,[descripccionTratamiento]
      ,[costoTratamiento]
      ,[imagenTratamiento]
      ,[explicacionTratamiento]
      ,[estadoTratamiento]
  FROM [Uricao].[dbo].[Tratamiento]
  ORDER BY (IdTratamiento)
		
END
go
use [Uricao]
go
create procedure [dbo].[ConsultarTratamientosAsociados]
@idTratamiento Bigint
as

BEGIN
	set nocount on
	/*obtener TRATAMIENTOS ASOCIADOS A UN TRATAMIENTO*/
	SELECT TA.*
	FROM TRATAMIENTO AS T, TRATAMIENTO AS TA, Tratamiento_Asociado AS T_A
	WHERE T.IdTratamiento=T_A.fkidTratamiento1 AND 
		TA.IdTratamiento= T_a.fkidTratamiento2 AND
		T.IdTratamiento=@idTratamiento
	ORDER BY TA.IdTratamiento
	
END;
go
USE [Uricao]
GO
CREATE PROCEDURE [dbo].[ConsultarTratamientosNoAsociados]
@idTratamiento bigint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT T.IdTratamiento, T.nombreTratamiento
	FROM Tratamiento AS T, Tratamiento_Asociado AS TA
	WHERE
	T.IdTratamiento NOT IN (SELECT TA.fkidTratamiento2
	FROM Tratamiento AS T, Tratamiento_Asociado AS TA
	WHERE T.IdTratamiento=TA.fkidTratamiento1 AND T.IdTratamiento=@idTratamiento)
	Group by T.IdTratamiento, T.nombreTratamiento;
End;
go
CREATE PROCEDURE [dbo].[IdTratamientoNuevo]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT max (T.idTratamiento)
	FROM Tratamiento as T
End;
go
create procedure [dbo].[ModificarImplemento]
@idtratProd bigint,
@prioridad_trat_prod int,
@cantidad_trat_prod numeric
AS
BEGIN
set nocount on;

UPDATE [Uricao].[dbo].[Tratamiento_Producto]
   SET 	[cantidad_trat_prod]=@cantidad_trat_prod,
		[prioridad_trat_prod]=@prioridad_trat_prod

 WHERE idtratProd=@idtratProd;
end;
go

create procedure [dbo].[ModificarTratamiento]
@idTratamiento bigint,
@nombreTratamiento char(50),
@duracionTratamiento int,
@descripcionTratamiento text,
@costoTratamiento real,
@imagenTratamiento char(50), /*null*/
@explicacionTratamiento text,
@estadoTratamiento char(50)
AS

begin
set nocount on;

UPDATE [Uricao].[dbo].[Tratamiento]
   SET 	[nombreTratamiento]=@nombreTratamiento,
		[duracionTratamiento]=@duracionTratamiento,
		[descripccionTratamiento]=@descripcionTratamiento,
		[costoTratamiento]=@costoTratamiento,
		[imagenTratamiento]=@imagenTratamiento,
		[explicacionTratamiento]=@explicacionTratamiento,
		[estadoTratamiento]=@estadoTratamiento

 WHERE [IdTratamiento]=@idTratamiento;
end;
