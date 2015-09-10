USE [Uricao]
GO
CREATE PROCEDURE [SeleccionarTodosLosProveedores]
AS
BEGIN
SET NOCOUNT ON;
    SELECT rifProveedor, nombreProveedor
	FROM Proveedor
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarProveedor]    Script Date: 12/05/2012 16:59:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarProveedor]
@rif NVARCHAR(50),
@nombre NVARCHAR(50),
@direccion bigint

AS
BEGIN

	SET NOCOUNT ON;
    --Proveedor ( IdProveedor , rifProveedor , nombreProveedor , fkIdDireccion, estado )
    Insert Proveedor values(@rif,@nombre,@direccion,'activo');
	
END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarProveedor]
@rif NVARCHAR(50),
@nombre NVARCHAR(50),
@direccion bigint

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT p.rifProveedor, p.nombreProveedor, p.fkIdDireccion
    FROM Proveedor p, Direccion d
    WHERE p.rifProveedor = @rif AND p.nombreProveedor = @nombre AND p.fkIdDireccion = @direccion 
    and p.fkIdDireccion= d.IdDir;
	
END
--exec dbo.ConsultarProveedor '132','karen2','1';
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarIdProveedor]
@rif NVARCHAR(50),
@nombre NVARCHAR(50),
@direccion bigint

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT idProveedor, rifProveedor, nombreProveedor, fkIdDireccion
	FROM Proveedor
    WHERE rifProveedor = @rif AND nombreProveedor = @nombre AND fkIdDireccion = @direccion
	
END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarContacto]
@apellido NVARCHAR(50),
@nombre NVARCHAR(50),
@correo NVARCHAR(50),
@fkidProveedor bigint

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT nombreContacto, ApellidoContacto, correoContacto, fkidProveedor
	FROM Contacto
    WHERE nombreContacto = @nombre AND ApellidoContacto = @apellido AND correoContacto = @correo AND fkidProveedor = @fkidProveedor
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarContacto]
@nombre NVARCHAR(50),
@apellido NVARCHAR(50),
@correo NVARCHAR(50),
@fkidProveedor bigint

AS
BEGIN

	SET NOCOUNT ON;
    
    Insert Contacto values(@nombre,@apellido,@correo,@fkidProveedor);
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarProveedorPorNombre]
@nombre NVARCHAR(50)

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT idProveedor, rifProveedor, nombreProveedor, fkIdDireccion
    FROM Proveedor
    WHERE nombreProveedor = @nombre
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarProveedorPorRif]
@rif NVARCHAR(50)

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT idProveedor, rifProveedor, nombreProveedor, fkIdDireccion
    FROM Proveedor
    WHERE rifProveedor = @rif
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarContactoConFK]
@rif NVARCHAR(30)

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT nombreContacto, ApellidoContacto, correoContacto
    FROM Contacto, Proveedor
    WHERE rifProveedor = @rif  
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[buscarIdProveedorPorRif]
@rif NVARCHAR(50)

AS
BEGIN

	SET NOCOUNT ON;
    
    SELECT idProveedor, rifProveedor
    FROM Proveedor
    WHERE rifProveedor = @rif
	
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModificarProveedor]
@ID NVARCHAR (50),
@rif NVARCHAR(50),
@nombre NVARCHAR (50),
@estado NVARCHAR (50)

AS
BEGIN

	SET NOCOUNT ON;
    
    UPDATE Proveedor SET nombreProveedor = @nombre, rifProveedor = @rif, estado = @estado
    WHERE idProveedor = @ID 
	
END;