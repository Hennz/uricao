USE [Uricao]
GO

CREATE PROCEDURE [dbo].[BuscarBancoProveedor]
@nombreProveedor varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT DISTINCT nombreBanco
	FROM Banco, Proveedor, Cuenta_Bancaria
	where nombreProveedor = @nombreProveedor and 
		fkIdBanco=idBanco and
		fkIdProveedor=idProveedor
		
	ORDER BY nombreBanco
END

GO



USE [uricao]
GO

CREATE PROCEDURE [dbo].[BuscarCuentaProveedor]
@nombreProveedor varchar(50),
@nombreBanco varchar(50)
AS

BEGIN
	SET NOCOUNT ON;
	
SELECT	DISTINCT cb.numeroCuenta
FROM	Cuenta_Bancaria cb
WHERE	cb.fkIdBanco =	(SELECT	ba.idBanco
						FROM	Banco ba
						WHERE	ba.nombreBanco = @nombreBanco
)
AND	cb.fkIdProveedor =	(SELECT pro.idProveedor
						FROM Proveedor pro
						WHERE pro.nombreProveedor = @nombreProveedor
)
ORDER BY numeroCuenta


END
