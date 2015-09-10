USE [Uricao]

GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[AgregarDetalleFactura]
@id_usuario bigint,
@cantidad int,
@monto real,
@id_Factura bigint,
@id_Tratamiento bigint

AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Detalle]
           ([fkidUsuario],
			[cantidadDetalle],
			[montoDetalle],
			[fkIdPresupuesto],
			[fkIdFactura],
			[fkIdTratamiento])
     VALUES
           (@id_usuario,
			@cantidad,
			@monto,
			NULL,
			@id_Factura,
			@id_Tratamiento)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[AgregarDetallePresupuesto]
@id_usuario bigint,
@cantidad int,
@monto real,
@id_Presupuesto bigint,
@id_Tratamiento bigint

AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Detalle]
           ([fkidUsuario],
			[cantidadDetalle],
			[montoDetalle],
			[fkIdPresupuesto],
			[fkIdFactura],
			[fkIdTratamiento])
     VALUES
           (@id_usuario,
			@cantidad,
			@monto,
			@id_Presupuesto,
			NULL,
			@id_Tratamiento)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[AgregarFactura]
@id_usuario bigint,
@nombre_razon text,
@tipo_identificacion text,
@tipo_id_paciente text,
@cedula_razon text,
@fecha date, 
@hora_fecha date,
@total_factura real,
@id_Direccion bigint,
@pagado bigint /*null*/

AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Factura]
           ([fkidUsuario],
			[nombreRazonsocialFactura],
			[tipo_identificacionFactura],
			[tipoid],
			[cedulaRifFactura],
			[fechaFactura],
			[horaFactura],
			[totalFactura],
			[fkIdDireccion],
			[pagadoFactura])
     VALUES
           (@id_usuario,
			@nombre_razon,
			@tipo_identificacion,
			@tipo_id_paciente,
			@cedula_razon,
			@fecha, /*null*/
			@hora_fecha,
			@total_factura,
			@id_Direccion,
			@pagado)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[AgregarPresupuesto]
@id_usuario bigint,
@fechaPresupuesto date, 
@totalPresupuesto real,
@ObservacionesPresupuesto text /*null*/

AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [Uricao].[dbo].[Presupuesto]
           ([fkIdUsuario],
			[fechaPresupuesto],
			[totalPresupuesto],
			[ObservacionesPresupuesto])
     VALUES
           (@id_usuario,
			@fechaPresupuesto,
			@totalPresupuesto,
			@ObservacionesPresupuesto)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO

CREATE PROCEDURE [dbo].[BuscarXIdTratamientos]
@idTratamiento int

AS

BEGIN
	set nocount on
	/*obtener Tratamiento por Nombre*/
	SELECT T.*
	FROM TRATAMIENTO AS T
	WHERE 
		T.IdTratamiento = @idTratamiento

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO

CREATE PROCEDURE [dbo].[buscarPorNombreTratamiento]
@NombreTratamiento char(50)

AS

BEGIN
	set nocount on
	/*obtener Tratamiento por Nombre*/
	SELECT T.*
	FROM TRATAMIENTO AS T
	WHERE 
		UPPER(T.nombreTratamiento) = UPPER (@NombreTratamiento)
    order by T.IdTratamiento

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarCedulaUsuarioPresupuesto]
@paramIdUsuario integer 

AS

BEGIN
	SELECT [idUsuario],[cedulaUser]
	  FROM [Uricao].[dbo].[Usuario]
	  WHERE [idUsuario]=@paramIdUsuario

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarDatosUsuarioPresupuesto]
@paramIdUsuario integer

AS

BEGIN
	SELECT [idUsuario]
	,[cedulaUser]
	,[tipoidUser]
	,[nombreUser1]
	,[apellidoUser1]
	,[apellidoUser2]
	  FROM [Uricao].[dbo].[Usuario]
	  WHERE [idUsuario]=@paramIdUsuario

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarDatosUsuarioCI]
@paramCI integer

AS

BEGIN
	SELECT [idUsuario]
	  FROM [Uricao].[dbo].[Usuario]
	  WHERE [cedulaUser]=@paramCI

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarDetalleFactura]
@paramIdFactura integer

AS

BEGIN
	SELECT [fkIdTratamiento]
	,[cantidadDetalle]
	,[montoDetalle]
	  FROM [Uricao].[dbo].[Detalle]
	  WHERE [fkIdFactura]=@paramIdFactura

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarDetallePresupuesto]
@paramIdPresupuesto integer 

AS

BEGIN
	SELECT [fkIdTratamiento]
	,[cantidadDetalle]
	,[montoDetalle]
	  FROM [Uricao].[dbo].[Detalle]
	  WHERE [fkIdPresupuesto]=@paramIdPresupuesto

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarDireccionXId]
@paramIdDir integer

AS

BEGIN
	SELECT Pais.[nombreDireccion]
		  ,Pais.[tipoDireccion]
		  ,Estado.[nombreDireccion]
		  ,Estado.[tipoDireccion]
		  ,Ciudad.[nombreDireccion]
		  ,Ciudad.[tipoDireccion]
		  ,Municipio.[nombreDireccion]
		  ,Municipio.[tipoDireccion]
		  ,Calle.[nombreDireccion]
		  ,Calle.[tipoDireccion]
		  ,Edificio.[nombreDireccion]
		  ,Edificio.[tipoDireccion]
	  FROM [Uricao].[dbo].[Direccion] Pais 
		LEFT OUTER JOIN [Uricao].[dbo].[Direccion] Estado ON Estado.fkIdDireccion=Pais.IdDir 
		LEFT OUTER JOIN [Uricao].[dbo].[Direccion] Ciudad ON Ciudad.fkIdDireccion=Estado.IdDir
		LEFT OUTER JOIN [Uricao].[dbo].[Direccion] Municipio ON Municipio.fkIdDireccion=Ciudad.IdDir
		LEFT OUTER JOIN [Uricao].[dbo].[Direccion] Calle ON Calle.fkIdDireccion=Municipio.IdDir
		LEFT OUTER JOIN [Uricao].[dbo].[Direccion] Edificio ON Edificio.fkIdDireccion=Calle.IdDir
	  WHERE Pais.[tipoDireccion]='Pais' AND 
		  (Edificio.fkIdDireccion=@paramIdDir
			OR Calle.fkIdDireccion=@paramIdDir
			OR Municipio.fkIdDireccion=@paramIdDir 
			OR Ciudad.fkIdDireccion=@paramIdDir 
			OR Estado.fkIdDireccion=@paramIdDir
			OR Pais.fkIdDireccion=@paramIdDir)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarListaFactura] 

AS

BEGIN

SELECT [IdFactura]
      ,[fkidUsuario]
      ,[nombreRazonsocialFactura]
      ,[tipo_identificacionFactura]
      ,[cedulaRifFactura]
      ,[fechaFactura]
      ,[horaFactura]
      ,[totalFactura]
      ,[fkIdDireccion]
      ,[pagadoFactura]
  FROM [Uricao].[dbo].[Factura]
  ORDER BY (IdFactura)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarFacturaNumero] 
@paramID integer

AS

BEGIN

SELECT [IdFactura]
      ,[fkidUsuario]
      ,[nombreRazonsocialFactura]
      ,[tipo_identificacionFactura]
      ,[cedulaRifFactura]
      ,[fechaFactura]
      ,[horaFactura]
      ,[totalFactura]
      ,[fkIdDireccion]
      ,[pagadoFactura]
  FROM [Uricao].[dbo].[Factura]
  WHERE [idFactura]=@paramID
  ORDER BY (IdFactura)
		
END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarFacturasRangoFechas]
@fechaInicio varchar(10),
@fechaFin varchar(10)

AS

BEGIN

SELECT [IdFactura]
      ,[fkidUsuario]
      ,[nombreRazonsocialFactura]
      ,[tipo_identificacionFactura]
      ,[cedulaRifFactura]
      ,[fechaFactura]
      ,[horaFactura]
      ,[totalFactura]
      ,[fkIdDireccion]
      ,[pagadoFactura]
  FROM [Uricao].[dbo].[Factura]
	WHERE [fechaFactura] BETWEEN @fechaInicio AND @fechaFin
  ORDER BY (IdFactura)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarFacturaXIDUsuario]
@paramID integer

AS

BEGIN

SELECT [IdFactura]
      ,[fkidUsuario]
      ,[nombreRazonsocialFactura]
      ,[tipo_identificacionFactura]
      ,[cedulaRifFactura]
      ,[fechaFactura]
      ,[horaFactura]
      ,[totalFactura]
      ,[fkIdDireccion]
      ,[pagadoFactura]
  FROM [Uricao].[dbo].[Factura]
  WHERE [fkidUsuario]=@paramID
  ORDER BY (IdFactura)
		
END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarFKUsuarioFactura]
@nro_factura integer

AS

BEGIN

	SELECT [fkidUsuario]
	  FROM [Uricao].[dbo].[Factura]
	  WHERE [IdFactura]=@nro_factura

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarFKUsuarioPresupuesto]
@nro_presupuesto integer

AS

BEGIN

	SELECT [fkIdUsuario]
	  FROM [Uricao].[dbo].[Presupuesto]
	  WHERE [IdPresupuesto]=@nro_presupuesto

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarListaPresupuesto] 

AS

BEGIN

	SELECT [IdPresupuesto]
		  ,[fechaPresupuesto]
		  ,[totalPresupuesto]
		  ,[ObservacionesPresupuesto]
	  FROM [Uricao].[dbo].[Presupuesto]
	  ORDER BY (IdPresupuesto)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarPresupuestoFKUsuario]
@paramFK integer

AS

BEGIN

	SELECT [IdPresupuesto]
		  ,[fechaPresupuesto]
		  ,[totalPresupuesto]
		  ,[ObservacionesPresupuesto]
	  FROM [Uricao].[dbo].[Presupuesto]
	  WHERE [fkIdUsuario]=@paramFK
	  ORDER BY (IdPresupuesto)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarPresupuestoNumero]
@paramID integer

AS

BEGIN

	SELECT [IdPresupuesto]
		  ,[fechaPresupuesto]
		  ,[totalPresupuesto]
		  ,[ObservacionesPresupuesto]
	  FROM [Uricao].[dbo].[Presupuesto]
	  WHERE [IdPresupuesto]=@paramID
	  ORDER BY (IdPresupuesto)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarPresupuestosRangoFechas]
@fechaInicio varchar(10),
@fechaFin varchar(10) 

AS

BEGIN

	SELECT [IdPresupuesto]
		  ,[fechaPresupuesto]
		  ,[totalPresupuesto]
		  ,[ObservacionesPresupuesto]
	  FROM [Uricao].[dbo].[Presupuesto]
	  WHERE [fechaPresupuesto] BETWEEN @fechaInicio AND @fechaFin
	  ORDER BY (IdPresupuesto)

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[ConsultarTratamientosDetalle]
@paramIdTratamiento integer

AS

BEGIN
	SELECT [nombreTratamiento]
	  FROM [Uricao].[dbo].[Tratamiento]
	  WHERE [IdTratamiento]=@paramIdTratamiento

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[DevolverDatosUsuarioPresupuesto]
@paramcedulaUser nvarchar(50),
@paramUserTipoCi nvarchar(50)

AS

BEGIN
	SELECT [idUsuario],[cedulaUser],[nombreUser1],[apellidoUser1],[tipoidUser]
	  FROM [Uricao].[dbo].[Usuario]
	  WHERE [cedulaUser] = @paramcedulaUser AND 
			[tipoidUser]= @paramUserTipoCi

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[DevolverIDUsuario]
@paramcedulaUser nvarchar(50)

AS

BEGIN
	SELECT [idUsuario]
	  FROM [Uricao].[dbo].[Usuario]
	  WHERE [cedulaUser] = @paramcedulaUser

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[EliminarPresupuestoViejo]
@idUsuario nvarchar(50)

AS

BEGIN
	
	DELETE 
	FROM [dbo].[Detalle] 
	WHERE (Detalle.fkidUsuario = @idUsuario AND Detalle.fkIdFactura is null AND 
	Detalle.fkIdPresupuesto = 
	(
		SELECT P.IdPresupuesto
		FROM [dbo].[Presupuesto] AS P
		WHERE P.fkIdUsuario = @idUsuario
	));
	
	

	DELETE 
	FROM [dbo].[Presupuesto] 
	WHERE (Presupuesto.IdPresupuesto = 
	(
		SELECT P.IdPresupuesto
		FROM [dbo].[Presupuesto] AS P
		WHERE P.fkIdUsuario = @idUsuario
	));

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[getIdDireccionFromUsuario]
@idUsuario bigint

AS

BEGIN
	SET nocount ON
	/*obtener el nro de factura apartir de la fecha, total y el 
	usuairo*/
	SELECT U.fkidDireccion
	FROM [dbo].[Usuario] AS U
	WHERE 
		idUsuario = @idUsuario;

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[getIdFactura]
@fecha_factura date,
@total_factura real,
@id_Usuario bigint,
@nombre_razon nchar(50),
@cedula_razon nchar(50)

AS

BEGIN
	SET nocount ON
	/*obtener el nro de factura apartir de la fecha, total y el 
	usuairo*/
	SELECT F.IdFactura
	FROM [dbo].[Factura] AS F
	WHERE 
		@id_Usuario = fkIdUsuario AND 
		@fecha_factura= fechaFactura AND 
		@total_factura = totalFactura AND
		@nombre_razon = nombreRazonsocialFactura AND
		@cedula_razon = cedulaRifFactura;

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[getIdPresupuesto]
@fecha_Presupuesto date,
@total_presupuesto real,
@id_usuario bigint

AS

BEGIN
	SET nocount ON
	/*obtener el nro de presupuesto apartir de la fecha, total y el 
	usuairo*/
	SELECT P.IdPresupuesto
	FROM [dbo].[Presupuesto] AS P
	WHERE 
		@id_usuario = fkIdUsuario AND 
		@fecha_Presupuesto = fechaPresupuesto AND 
		@total_presupuesto = totalPresupuesto;

END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[RegresoIDDireccion]
@nombreDireccion bigint

AS

BEGIN

	SELECT D.IdDir
	  FROM [Uricao].[dbo].[Direccion] as D
	  WHERE D.nombreDireccion = @nombreDireccion
	  
END;


GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE [dbo].[RegresoTotalTratamiento]
@idTratamiento bigint

AS

BEGIN

	SELECT T.costoTratamiento
	  FROM [Uricao].[dbo].[Tratamiento] as T
	  WHERE T.IdTratamiento = @idTratamiento

END;