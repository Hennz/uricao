use [Uricao]
GO

CREATE PROCEDURE [dbo].[CancelarCita]
(
@idcita BIGINT
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE CITA
SET CITA.statusCita='Inactiva'

WHERE CITA.idCita=@idcita;
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
END;
GO
GO

CREATE PROCEDURE [dbo].[ConfirmarCita]
(
@idCita BIGINT
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE CITA
SET CITA.confirmacionCita='Confirmada'

WHERE CITA.idCita=@idCita;
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
END;

GO

CREATE PROCEDURE [dbo].[ConsultarCitaCliente]
(
@idusuario nvarchar(50)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT c.idCita,c.fechaCita,c.horaInicioCita,c.horaFinCita, u2.nombreUser1,u2.apellidoUser1,t.nombreTratamiento
from cita c, usuario u,usuario u2,tratamiento t,Per_Hor ph
where c.fkIdUsuario=u.idUsuario and u.cedulaUser=@idusuario  
and c.fkIdTratamiento=t.idTratamiento and c.fkidHorario=ph.idPer_Hor
and ph.fkIdUsuario=u2.idUsuario  and c.statusCita='Activa'


  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
END;

GO
CREATE PROCEDURE [dbo].[ConsultarCitaUnaFecha](
@idusuario nvarchar(50),
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@fecha date
)
AS
BEGIN


       SET NOCOUNT ON;

       SELECT 
              c.idCita,
              c.fechaCita,
              c.horaInicioCita,
              c.horaFinCita, 
              u2.nombreUser1,
              u2.apellidoUser1,
              t.nombreTratamiento,
              c.confirmacionCita,
              c.statusCita
       from cita c, usuario u,usuario u2,tratamiento t,Per_Hor ph
       where c.fkIdUsuario=u.idUsuario and u.cedulaUser=@idusuario  and u2.nombreUser1=@nombremedico and u2.apellidoUser1=@apellidomedico  
       and c.fkIdTratamiento=t.idTratamiento and c.fkidHorario=ph.idPer_Hor
       and ph.fkIdUsuario=u2.idUsuario and c.fechaCita=@fecha and c.statusCita='Activa'

       


END;

GO

GO


CREATE PROCEDURE [dbo].[ConsultarCitaRangoFecha](
@idusuario nvarchar(50),
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@fecha1 date,
@fecha2 date
)
AS
BEGIN


       SET NOCOUNT ON;

       SELECT 
              c.idCita,
              c.fechaCita,
              c.horaInicioCita,
              c.horaFinCita, 
              u2.nombreUser1,
              u2.apellidoUser1,
              t.nombreTratamiento,
              c.confirmacionCita,
              c.statusCita
       from cita c, usuario u,usuario u2,tratamiento t,Per_Hor ph
       where c.fkIdUsuario=u.idUsuario and u.cedulaUser=@idusuario and u2.nombreUser1=@nombremedico and u2.apellidoUser1=@apellidomedico  
       and c.fkIdTratamiento=t.idTratamiento and c.fkidHorario=ph.idPer_Hor
       and ph.fkIdUsuario=u2.idUsuario and c.fechaCita BETWEEN @fecha1 and @fecha2 and c.statusCita='Activa'

       


END;


GO

CREATE PROCEDURE [dbo].[DetalleCita](
@idcita int
)
AS
BEGIN


       SET NOCOUNT ON;
       SELECT c.confirmacionCita, c.statusCita
       from cita c
       where c.idCita=@idcita
       
       

END;


GO



GO

CREATE PROCEDURE [dbo].[ConsultarHorarioMedico](
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@tratamiento CHAR(50),
@diaSemana CHAR(50)
)
AS
BEGIN


       SET NOCOUNT ON;

       
SELECT h.iniciohorario, h.finhorario ,t.duracionTratamiento
	FROM horario h, usuario u, per_hor ph , tratamiento t 
		WHERE u.nombreuser1=@nombremedico AND u.apellidoUser1=@apellidomedico and
		ph.fkIdUsuario = u.idUsuario AND ph.fkIdHorario = h.idHorario AND 
		@diaSemana=h.diaHorario 
		AND	t.nombreTratamiento=@tratamiento

       


END;

GO

GO

CREATE PROCEDURE [dbo].[ConsultarCitasActuales](
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@fecha date
)
AS
BEGIN


       SET NOCOUNT ON;

       
SELECT	c.idCita,
		c.fechaCita,
		horaInicioCita,
		C.horaFinCita 
	FROM Cita c, Tratamiento t, Per_Hor ph , Horario h, usuario u
		WHERE c.fkidHorario=ph.idPer_Hor AND 
		ph.fkIdHorario=h.idHorario AND 
		ph.fkIdUsuario=u.idUsuario AND
		c.fkIdTratamiento=t.IdTratamiento AND
		t.estadoTratamiento='Activo' AND
		c.horaInicioCita <= h.finHorario AND
		c.horaInicioCita >= h.inicioHorario AND
		c.statusCita='Activa' AND
		u.nombreUser1=@nombremedico AND 
		u.apellidoUser1=@apellidomedico AND 
		c.fechaCita=@fecha 
	ORDER BY c.horaInicioCita


END;

GO

GO


CREATE PROCEDURE [dbo].[ModificarCita]
(
@idcita INT,
@fechacita date,
@horainiciocita INT,
@horafincita INT,
@tratamiento NCHAR(50),
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50)

)
AS
BEGIN

	SET NOCOUNT ON;
	UPDATE CITA 
	SET CITA.fechaCita=@fechacita, CITA.horaInicioCita=@horainiciocita, CITA.horaFinCita=@horafincita,
        CITA.fkIdTratamiento=(select idTratamiento from tratamiento where nombreTratamiento=@tratamiento),
        CITA.fkidHorario=(select idPer_Hor from per_hor, horario, usuario where per_hor.fkIdUsuario=usuario.idUsuario and usuario.nombreUser1=@nombremedico and apellidoUser1=@apellidomedico 
        and per_hor.fkIdHorario=horario.idHorario and DATENAME(DW,@fechacita)like horario.diaHorario COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI)
	WHERE CITA.idCita=@idcita;
	
END;





GO



GO

CREATE PROCEDURE [dbo].[AgregarCita]
(
@fechacita date,
@horainiciocita INT,
@horafincita INT,
@nombretratamiento nchar(50),
@fkidusuario INT,
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@diasemana NCHAR(50)
)
AS
BEGIN

SET NOCOUNT ON;

INSERT INTO CITA
VALUES (@fechacita, @horainiciocita, @horafincita,(SELECT IdTratamiento from TRATAMIENTO WHERE nombretratamiento=@nombretratamiento),(SELECT IdUsuario from USUARIO WHERE cedulaUser=@fkidusuario),(select idPer_Hor from per_hor, horario, usuario where per_hor.fkIdUsuario=usuario.idUsuario and usuario.nombreUser1=@nombremedico and apellidoUser1=@apellidomedico 
        and per_hor.fkIdHorario=horario.idHorario and horario.diaHorario=@diasemana COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI),'No Confirmada','Activa');
END;
GO

GO

CREATE PROCEDURE [dbo].[ConsultarHorarioMedicoRangoFecha](
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@fecha date
)
AS
BEGIN


       SET NOCOUNT ON;

       
select h.iniciohorario, h.finhorario 
from horario h, usuario u, per_hor ph 
where u.nombreuser1=@nombremedico and u.apellidoUser1=@apellidomedico and
DATENAME(DW,@fecha)=h.diaHorario and ph.fkIdHorario=h.idHorario
and ph.fkIdUsuario=u.idUsuario  

       


END;

GO



GO

CREATE PROCEDURE [dbo].[ConsultarCitaPorNombreMedico](
@nombre NCHAR(50),
@apellido NCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;
       SELECT 
			c.idCita,
			c.fechaCita,
			c.horaInicioCita,
			c.horaFinCita, 
			c.confirmacionCita, 
			c.statusCita, 
			T.nombreTratamiento, 
			u.idUsuario AS idMedico, 
			u.nombreUser1 AS nombreMedico, 
			u.apellidoUser1 as apellidoMedico
		FROM cita c, usuario u,Per_Hor p, Tratamiento T
		WHERE c.fkIdHorario=p.idPer_Hor AND 
			p.fkIdUsuario=u.idUsuario AND 
			c.statusCita='Activa' AND
			T.IdTratamiento=C.fkIdTratamiento AND
			U.nombreUser1 LIKE '%'+@nombre+'%' AND
			U.apellidoUser1 LIKE '%'+@apellido+'%'
		ORDER BY c.fechaCita, c.horaInicioCita, c.horaFinCita
END;

GO


CREATE PROCEDURE [dbo].[ConsultarCitaPorFecha](

@fecha date
)
AS
BEGIN

       SET NOCOUNT ON;

       SELECT 
			c.idCita,
			c.fechaCita,
			c.horaInicioCita,
			c.horaFinCita, 
			c.confirmacionCita, 
			c.statusCita, 
			T.nombreTratamiento, 
			u.idUsuario AS idMedico, 
			u.nombreUser1 AS nombreMedico, 
			u.apellidoUser1 as apellidoMedico
		FROM cita c, usuario u,Per_Hor p, Tratamiento T
		WHERE c.fkIdHorario=p.idPer_Hor AND 
			p.fkIdUsuario=u.idUsuario AND 
			c.statusCita='Activa' AND
			T.IdTratamiento=C.fkIdTratamiento AND
			c.fechaCita=@fecha
		ORDER BY c.fechaCita, c.horaInicioCita, c.horaFinCita

       


END;

GO

GO


CREATE PROCEDURE [dbo].[ConsultarCitaPorRangoFecha](

@fecha1 date,
@fecha2 date
)
AS
BEGIN
       SET NOCOUNT ON;

       SELECT 
			c.idCita,
			c.fechaCita,
			c.horaInicioCita,
			c.horaFinCita, 
			c.confirmacionCita, 
			c.statusCita, 
			T.nombreTratamiento, 
			u.idUsuario AS idMedico, 
			u.nombreUser1 AS nombreMedico, 
			u.apellidoUser1 as apellidoMedico
		FROM cita c, usuario u,Per_Hor p, Tratamiento T
		WHERE c.fkIdHorario=p.idPer_Hor AND 
			p.fkIdUsuario=u.idUsuario AND 
			c.statusCita='Activa' AND
			T.IdTratamiento=C.fkIdTratamiento AND
			c.fechaCita BETWEEN @fecha1 AND @fecha2
		ORDER BY c.fechaCita, c.horaInicioCita, c.horaFinCita       


END;


GO


GO

CREATE PROCEDURE [dbo].[ConsultarCitaPorCedulaUsuario]
(
@cedula nvarchar(50)
)
AS
BEGIN

SET NOCOUNT ON;

       SELECT 
			c.idCita,
			c.fechaCita,
			c.horaInicioCita,
			c.horaFinCita, 
			c.confirmacionCita, 
			c.statusCita, 
			T.nombreTratamiento, 
			uMedico.idUsuario AS idMedico, 
			uMedico.nombreUser1 AS nombreMedico, 
			uMedico.apellidoUser1 as apellidoMedico
		FROM cita c, usuario uMedico, usuario uPaciente, Per_Hor p, Tratamiento T
		WHERE c.fkIdHorario=p.idPer_Hor AND 
			p.fkIdUsuario=uMedico.idUsuario AND 
			c.statusCita='Activa' AND
			T.IdTratamiento=C.fkIdTratamiento AND
			uPaciente.idUsuario=c.fkIdUsuario AND
			uPaciente.cedulaUser LIKE '%'+@cedula+'%'
		ORDER BY c.fechaCita, c.horaInicioCita, c.horaFinCita


END;
GO

CREATE PROCEDURE [dbo].[ModificarUnaCita]
(
@idcita INT,
@fechacita date,
@horainiciocita INT,
@horafincita INT,
@tratamiento NCHAR(50),
@nombremedico NCHAR(50),
@apellidomedico NCHAR(50),
@diasemana NCHAR(50)

)
AS
BEGIN

	SET NOCOUNT ON;
	UPDATE Cita  
	SET Cita.fechaCita=@fechacita, 
	    Cita.horaInicioCita=@horainiciocita, 
	    Cita.horaFinCita=@horafincita,
        Cita.fkIdTratamiento=(
			SELECT TOP 1 idTratamiento 
			 FROM tratamiento 
			  WHERE nombreTratamiento=@tratamiento),
        Cita.fkidHorario=(
          SELECT TOP 1 idPer_Hor 
           FROM per_hor ph, horario h, usuario u
            WHERE ph.fkIdUsuario=u.idUsuario AND 
             u.nombreUser1=@nombremedico AND 
             apellidoUser1=@apellidomedico AND
             ph.fkIdHorario=h.idHorario AND
             h.diaHorario=@diasemana
             )
	WHERE Cita.idCita=@idcita;
	
END;

GO

CREATE PROCEDURE [dbo].[ConfirmarCita]
@idCita int
AS

BEGIN

	SET NOCOUNT ON;

    UPDATE cita
	SET confirmacionCita = 'Confirmada'
	WHERE idCita = @idCita;
	
END;

go

CREATE PROCEDURE [dbo].[CancelarCita]
@idCita int
AS

BEGIN

	SET NOCOUNT ON;

    UPDATE cita
	SET statusCita = 'Inactiva', confirmacionCita = 'No Confirmada'
	WHERE idCita = @idCita;
	
END;





GO
