CREATE PROCEDURE [consultarDeudaXFactura]
(
@IdFactura int
)
AS
BEGIN

SET NOCOUNT ON;

    SELECT min(A.deuda)
	FROM FACTURA F, ABONO A
	WHERE 
		F.IdFactura=@IdFactura and A.fkIdFactura=@IdFactura


  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
END;