
/******								 StoredProcedure Para Agregar                                   ******/ 
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[agregarHistoriaClinica]    Script Date: 12/06/2012 19:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[agregarHistoriaClinica]
@fechaHistoriaClinica date,
@fkIdUsuario bigint,
@observacionHistoriaClinica nvarchar(500),
@estadoHistoriaClinica nvarchar(15)
AS
BEGIN	
	SET NOCOUNT ON;
	INSERT INTO [Uricao].[dbo].[HistoriaClinica] 
				([fechaHistoriaClinica],
				[fkIdUsuario],
				[observacionHistoriaClinica],
				[estadoHistoriaClinica])				
		 VALUES
				(@fechaHistoriaClinica, 
				@fkIdUsuario,
				@observacionHistoriaClinica, 
				@estadoHistoriaClinica)		
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[agregarSecuencia]    Script Date: 12/05/2012 10:53:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[agregarSecuencia]
@observacionSecuencia nvarchar(50),
@fkIdTratamiento bigint,
@fkIdDoctor bigint,
@fechaSecuencia date,
@fkIdHistoriaClinica bigint,
@piezaSecuencia nvarchar(50),
@diagnosticoSecuencia nvarchar(50),
@estadoSecuencia nvarchar(15)
AS
BEGIN
	SET NOCOUNT ON;	
	INSERT INTO [Uricao].[dbo].[Secuencia]
				([observacionSecuencia],
				[fkIdTratamiento], 
				[fkIdDoctor],
				[fechaSecuencia],
				[fkIdHistoriaClinica],
				[piezaSecuencia],
				[diagnosticoSecuencia],
				[estadoSecuencia])
		 VALUES
				(@observacionSecuencia,
				@fkIdTratamiento,
				@fkIdDoctor,
				@fechaSecuencia,
				@fkIdHistoriaClinica,
				@piezaSecuencia,
				@diagnosticoSecuencia,
				@estadoSecuencia)
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[agregarAntecedente]    Script Date: 12/05/2012 10:51:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[agregarAntecedente]
@respuestaAntecedente nvarchar(50),
@fkIdHistoriaClinica bigint
AS
BEGIN
	SET NOCOUNT ON;	
	INSERT INTO [Uricao].[dbo].[Antecedente] 
				([respuestaAntecedente],
				 [fkIdHistoriaClinica])
		 VALUES
				(@respuestaAntecedente,
				@fkIdHistoriaClinica)			
END;
GO
/******								 StoredProcedure Para Consultar                                 ******/     
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[BuscarHistoriaClinica]    Script Date: 12/04/2012 09:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BuscarTodasHistoriaClinica]
AS
BEGIN
	SET NOCOUNT ON;	
		
	SELECT	U.idUsuario, U.nombreUser1,U.nombreUser2,
		    U.apellidoUser1, U.apellidoUser2,U.nacimientoUser,
		    U.generoUser,U.cedulaUser, 
		   /* D.nombreDireccion,D.tipoDireccion,
		    T.codigoTelefono,T.numeroTelefono, T.tipoTelefono,*/
			H.fechaHistoriaClinica, H.IdHistoriaClinica,
			H.observacionHistoriaClinica, H.estadoHistoriaClinica
			
	FROM	Usuario AS U, HistoriaClinica AS H/*, Direccion AS D, Telefono AS T*/
	WHERE	U.idUsuario = H.fkIdUsuario /*AND U.fkidDireccion = D.IdDir
			AND T.fkIdUsuario =U.idUsuario*/
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[BuscarHistoriaClinica]    Script Date: 12/04/2012 09:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BuscarHistoriaClinica]
(
@nombre nchar(50),
@apellido nchar(50),
@cedula nvarchar(50),
@idHistoria bigint
)
AS

BEGIN
	SET NOCOUNT ON;	
		
	SELECT	U.idUsuario, U.nombreUser1,U.nombreUser2,
		    U.apellidoUser1, U.apellidoUser2,U.nacimientoUser,
		    U.generoUser,U.cedulaUser, 
		   /* D.nombreDireccion,D.tipoDireccion,
		    T.codigoTelefono,T.numeroTelefono, T.tipoTelefono,*/
			H.fechaHistoriaClinica, H.IdHistoriaClinica,
			H.observacionHistoriaClinica, H.estadoHistoriaClinica
			
	FROM	Usuario AS U, HistoriaClinica AS H/*, Direccion AS D, Telefono AS T*/
	WHERE	U.idUsuario = H.fkIdUsuario /*AND U.fkidDireccion = D.IdDir
			AND T.fkIdUsuario =U.idUsuario*/
			AND (U.nombreUser1= @nombre or U.apellidoUser1=@apellido or U.cedulaUser=@cedula or H.IdHistoriaClinica=@idHistoria)		
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[consultarAntecedente]    Script Date: 12/04/2012 09:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[consultarAntecedente]
@idHistoria bigint
AS

BEGIN
	SET NOCOUNT ON;

		
	SELECT A.IdAntecedente, A.respuestaAntecedente
	FROM Antecedente as A
	WHERE A.fkIdHistoriaClinica = @idHistoria		
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[consultarSecuencia]    Script Date: 12/04/2012 09:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[consultarSecuencia]
@idHistoriaClinica bigint
AS

BEGIN
	SET NOCOUNT ON;
			
	SELECT  S.idSecuencia, S.observacionSecuencia, S.fechaSecuencia,
			S.piezaSecuencia,S.diagnosticoSecuencia, S.estadoSecuencia,S.fkIdTratamiento,
			S.fkIdDoctor
			/*,U.idUsuario, U.nombreUser1,U.apellidoUser1,
		    T.IdTratamiento, T.nombreTratamiento*/
	FROM	Secuencia AS S /*, HistoriaClinica AS H, Usuario AS U, Tratamiento AS T*/
	WHERE	S.fkIdHistoriaClinica = @idHistoriaClinica /*AND S.fkIdDoctor= U.idUsuario 
			AND S.fkIdTratamiento = T.IdTratamiento	*/
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[spGenerateID]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[UltimaHistoria]
AS     
BEGIN 
	SELECT MAX(IdHistoriaClinica) FROM HistoriaClinica
END;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[ActivarDesactivarHistoriaClinica]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActivarDesactivarHistoriaClinica]
@idHistoria int ,
@estadoHistoria nvarchar(15)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE	[Uricao].[dbo].[HistoriaClinica]	
	SET		[estadoHistoriaClinica]=@estadoHistoria
	WHERE	[IdHistoriaClinica]=@idHistoria;
END;


GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[modificarHistoriaClinica]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModificarHistoriaClinica]
@idHistoria bigint,
@fechaHistoria date,
@observacion nvarchar(500)
/*,@estadoHistoria text*/

AS

begin
	SET NOCOUNT ON;

	UPDATE	[Uricao].[dbo].[HistoriaClinica] 
	SET		[fechaHistoriaClinica]=@fechaHistoria,
			[observacionHistoriaClinica]=@observacion
			/*,[estadoHistoria_Base]=@estadoHistoria*/		
	WHERE	[IdHistoriaClinica]=@idHistoria;
end;

GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[modificarAntecedentes]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[modificarAntecedentes]
@idAntecedente bigint,
@respuesta nvarchar(50)

AS

begin
	SET NOCOUNT ON;

	UPDATE	[Uricao].[dbo].[Antecedente] 
	SET 	[respuestaAntecedente] =@respuesta
	WHERE	[IdAntecedente] =@idAntecedente;
end;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[modificarSecuenciaTratamiento]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[modificarSecuencia]
@idSecuencia bigint,
@observacionSecuencia nvarchar(50),
@fkIdTratamiento bigint,
@fkIdDoctor bigint,
@fechaSecuencia date,
/*@fkIdHistoriaClinica bigint,*/
@piezaSecuencia nvarchar(50),
@diagnosticoSecuencia nvarchar(50)
/*@estadoSecuencia nvarchar(15)*/
AS

begin
	SET NOCOUNT ON;

	UPDATE	[Uricao].[dbo].[Secuencia]
	SET 	[ObservacionSecuencia]=@observacionSecuencia , [fkIdDoctor]=@fkIdDoctor, [fkIdTratamiento]=@fkIdTratamiento, 
			[fechaSecuencia]=@fechaSecuencia, [piezaSecuencia]=@piezaSecuencia,[diagnosticoSecuencia]=@diagnosticoSecuencia		
	WHERE [idSecuencia]=@idSecuencia;
end;
GO
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[ActivarDesactivarHistoriaClinica]    Script Date: 12/04/2012 09:56:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActivarDesactivarSecuencia]
@idSecuencia int ,
@estadoSecuencia nvarchar(15)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE	[Uricao].[dbo].[Secuencia]	
	SET		[estadoSecuencia]=@estadoSecuencia 
	WHERE	[idSecuencia]=@idSecuencia;
END;
USE [Uricao]
GO
/****** Object:  StoredProcedure [dbo].[consultarSecuenciaXid]    Script Date: 01/12/2013 03:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[consultarSecuenciaXid]
@idHistoriaSecuencia bigint
AS

BEGIN
	SET NOCOUNT ON;
			
	SELECT  S.idSecuencia, S.observacionSecuencia, S.fechaSecuencia,
			S.piezaSecuencia,S.diagnosticoSecuencia, S.estadoSecuencia,S.fkIdTratamiento,
			S.fkIdDoctor
			/*,U.idUsuario, U.nombreUser1,U.apellidoUser1,
		    T.IdTratamiento, T.nombreTratamiento*/
	FROM	Secuencia AS S /*, HistoriaClinica AS H, Usuario AS U, Tratamiento AS T*/
	WHERE	S.idSecuencia = @idHistoriaSecuencia /*AND S.fkIdDoctor= U.idUsuario 
			AND S.fkIdTratamiento = T.IdTratamiento	*/
END;
