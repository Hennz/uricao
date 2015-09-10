CREATE PROCEDURE AbonarConsultarCuentasPorPagar
(
   @fechaInicio   varchar(10),
   @fechaFin	  varchar(10),
   @proveedor     nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select cpp.idCuentaPP, cpp.fechaEmisionPP, cpp.fechaVencimientoPP, pro.nombreProveedor,
	cpp.montoPP from Cuenta_Por_Pagar cpp, Proveedor pro, Cuenta_Bancaria cta where
	cpp.fkCuentaBancaria = cta.iDCuenta and pro.idProveedor = cta.fkIdProveedor 
	and cpp.estatuspp = 'activo' and pro.nombreProveedor = @proveedor and cpp.fechaEmisionPP >= @fechaInicio 
	and cpp.fechaVencimientoPP <= @fechaFin order by pro.idProveedor
END;
GO
CREATE PROCEDURE AbonarConsultarCuentasPorPagarFechas
(
   @fechaInicio varchar(10),
   @fechaFin varchar(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select cpp.idCuentaPP, cpp.fechaEmisionPP, cpp.fechaVencimientoPP, pro.nombreProveedor,
	cpp.montoPP from Cuenta_Por_Pagar cpp, Proveedor pro, Cuenta_Bancaria cta where
	cpp.fkCuentaBancaria = cta.iDCuenta and pro.idProveedor = cta.fkIdProveedor and
	cpp.estatuspp = 'activo' and cpp.fechaEmisionPP >= @fechaInicio 
	and cpp.fechaVencimientoPP <= @fechaFin order by pro.idProveedor
END;
GO
CREATE PROCEDURE ActivarDesactivarCpp
(
   @idCuentaPP bigint,
   @estatusPP  nchar(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	update Cuenta_Por_Pagar set estatusPP = @estatusPP where idCuentaPP = @idCuentaPP
END;
GO
USE [uricao]
GO
/****** Object:  StoredProcedure [dbo].[abonoCuentaPorPagar]    Script Date: 12/04/2012 17:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[abonoCuentaPorPagar]
(
   @fechaAbono       date,
   @montoAbono  real,
   @deuda       real,
   @idCuentaPP  bigint 
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT Abono (fechaAbono, montoAbono, deuda, fkIdCuentaPP)
	values(@fechaAbono,@montoAbono,@deuda,@idCuentaPP);

END;
GO
CREATE PROCEDURE [dbo].[BuscarAbonoXIdCpp]
(
   @idCuentaPP   varchar(50)
)
AS
BEGIN

select abo.fechaAbono, abo.montoAbono,abo.deuda from Abono abo,
Cuenta_Por_Pagar cpp where cpp.idCuentaPP = @idCuentaPP and abo.fkIdCuentaPP = cpp.idCuentaPP
and abo.fkIdCuentaPC is null

END;
GO
CREATE PROCEDURE [dbo].[CambiarEstatusCpp]
(
   @idCuentaPP   bigint,
   @estatusPP 	 nchar(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE cuenta_por_pagar
   	SET 	[estatusPP]= @estatusPP

 	WHERE idCuentaPP=@idCuentaPP;
END;
GO
Create Procedure [dbo].[ConsultarCuentaPorPagar](
@idCuentaPorPagar int)
as 
begin


	select idcuentapp, fechaemisionpp, fechaVencimientoPP, tipoPagoPP, estatusPP,
tipoDeudaPP, detallePP,  montopp, pro.nombreProveedor, cb.numeroCuenta, ba.nombreBanco
	from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb, Banco ba 
	where idcuentapp = @idCuentaPorPagar
	and cpp.fkcuentabancaria = cb.idcuenta
	and cb.fkidproveedor = pro.idproveedor 
	and ba.idBanco = cb.fkIdBanco
	and cpp.estatuspp = 'activo'

end;
GO
USE [uricao]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCuentasPorPagar]    Script Date: 12/04/2012 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[ConsultarCuentasPorPagar](
@idCuentaPorPagar int)
as 
begin


	select idcuentapp, fechaemisionpp, fechaVencimientoPP, tipoPagoPP, estatusPP,
tipoDeudaPP, detallePP,  montopp, pro.nombreProveedor, cb.numeroCuenta, ba.nombreBanco
	from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb, Banco ba 
	where idcuentapp = @idCuentaPorPagar
	and cpp.fkcuentabancaria = cb.idcuenta
	and cb.fkidproveedor = pro.idproveedor 
	and ba.idBanco = cb.fkIdBanco
	and cpp.estatuspp = 'activo'

end;
GO
create PROCEDURE [dbo].[ConsultarCuentasPorPagarFechas]
(
   @fechaInicio date,
   @fechaFin date
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select idcuentapp, fechaemisionpp, montopp, pro.nombreProveedor from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb 
	where cb.fkidproveedor = pro.idproveedor and cpp.fkcuentabancaria = cb.idcuenta and fechaemisionpp >= @fechaInicio
	and fechaemisionpp <= @fechaFin and cpp.estatuspp = 'activo'
END;
GO
CREATE PROCEDURE ConsultarCuentasPorPagarFechasActivar
(
   @fechaInicio varchar(10),
   @fechaFin varchar(10)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select idcuentapp, fechaemisionpp, estatusPP, nombreProveedor, montopp from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb 
	where cb.fkidproveedor = pro.idproveedor and cpp.fkcuentabancaria = cb.idcuenta and fechaemisionpp >= @fechaInicio
	and fechavencimientopp <= @fechaFin and (cpp.estatuspp = 'activo' or cpp.estatuspp = 'inactivo')

END;
GO
CREATE PROCEDURE [dbo].[ConsultarCuentasPorPagarFechasProveedor]
(
   @proveedor nvarchar(50),
   @fechaInicio date,
   @fechaFin date
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select idcuentapp, fechaemisionpp, montopp, tipoDeudaPP from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb 
	where pro.nombreproveedor = @proveedor and cb.fkidproveedor = pro.idproveedor and cpp.fkcuentabancaria = cb.idcuenta 
        and fechaemisionpp >= @fechaInicio and fechaemisionpp <= @fechaFin and cpp.estatuspp = 'activo'

END;
GO
CREATE PROCEDURE ConsultarCuentasPorPagarFechasProveedorActivar
(
   @fechaInicio varchar(10),
   @fechaFin varchar(10),
   @proveedor nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	select idcuentapp, fechaemisionpp, estatusPP,montopp from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb 
	where pro.nombreproveedor = @proveedor and cb.fkidproveedor = pro.idproveedor and cpp.fkcuentabancaria = cb.idcuenta 
        and fechaemisionpp >= @fechaInicio and fechavencimientopp <= @fechaFin and (cpp.estatuspp = 'activo' or cpp.estatuspp = 'inactivo')

END;
GO
CREATE PROCEDURE [dbo].[ConsultarCuentasPorPagaProveedor]
(
   @proveedor   nvarchar(50)
)
AS
BEGIN
	select idcuentapp, fechaemisionpp, montopp, pro.nombreProveedor,cb.numeroCuenta,ba.nombreBanco 
from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb, Banco ba 
where cb.fkidproveedor = pro.idproveedor 
and cpp.fkcuentabancaria = cb.idcuenta 
and ba.idBanco = cb.fkIdBanco
and pro.nombreproveedor =@proveedor
	and cpp.estatuspp = 'activo'
END;
GO
CREATE PROCEDURE ActivarDesactivarConsultarCuentasPorPagarProveedor
(
   @proveedor   nvarchar(50)
)
AS
BEGIN
	select idcuentapp, fechaemisionpp, estatuspp, montopp from cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb 
	where cb.fkidproveedor = pro.idproveedor and cpp.fkcuentabancaria = cb.idcuenta and pro.nombreproveedor = @proveedor
	and (cpp.estatuspp = 'activo' or cpp.estatuspp = 'inactivo')
END;
GO
USE [uricao]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCuentaPorPagar]    Script Date: 12/05/2012 22:20:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[InsertarCuentaPorPagar]    Script Date: 12/10/2012 18:33:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[InsertarCuentaPorPagar]    Script Date: 12/10/2012 18:33:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarCuentaPorPagar]

@nroCtaBancaria_entra nvarchar(50),

@fechaEmisionPP DATE,
@fechaVencimientoPP DATE,
@tipoPagoPP nchar(10),
@estatusPP nchar(10),
@tipoDeudaPP nchar(10),
@detallePP text,
@montoPP real

AS

BEGIN
	SET NOCOUNT ON;

	INSERT INTO Cuenta_Por_Pagar (fechaEmisionPP,fechaVencimientoPP,tipoPagoPP,estatusPP,tipoDeudaPP,detallePP,montoPP,fkCuentaBancaria)
	VALUES (@fechaEmisionPP,@fechaVencimientoPP,@tipoPagoPP,@estatusPP,@tipoDeudaPP,@detallePP,@montoPP,
		(SELECT TOP 1 CB.iDCuenta 
		FROM Cuenta_Bancaria CB 
		WHERE CB.numeroCuenta = @nroCtaBancaria_entra
		ORDER BY CB.iDCuenta)
		);
	
END;
GO
CREATE PROCEDURE llenarAbonoCpp2
(
   @proveedor   nvarchar(50),
   @idCuentaPP  bigint
)
AS
BEGIN
	SET NOCOUNT ON;

	select cb.numeroCuenta,ba.nombreBanco, cpp.tipoPagopp,(select SUM(abo.montoabono) from abono abo, cuenta_por_pagar cpp
	where cpp.idcuentapp = @idCuentaPP and fkidcuentapp = cpp.idcuentapp) as abonosTotales from 
	abono abo, cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb, Banco ba where cb.fkidproveedor = pro.idproveedor 
	and cpp.fkcuentabancaria = cb.idcuenta and ba.idBanco = cb.fkIdBanco and pro.nombreproveedor =@proveedor 
	and cpp.idCuentapp = @idCuentaPP and cpp.estatuspp = 'activo' group by numeroCuenta,nombreBanco,tipoPagopp
END;
GO
CREATE PROCEDURE llenarGridAbonos
(
   @proveedor   varchar(50),
   @idCuentaPP  bigint
)
AS
BEGIN
	SET NOCOUNT ON;

	select abo.fechaabono,abo.montoabono,abo.deuda from 
	abono abo, cuenta_por_pagar cpp, proveedor pro ,cuenta_bancaria cb, Banco ba where cb.fkidproveedor = pro.idproveedor 
	and cpp.fkcuentabancaria = cb.idcuenta and ba.idBanco = cb.fkIdBanco and pro.nombreproveedor = @proveedor
	and cpp.idCuentapp = @idCuentaPP and abo.fkidcuentapp = cpp.idCuentapp
END;
GO
create procedure [dbo].[ModificarCuentaPorPagar](
@idCuentaPP int,
@fechaEmision date,
@fechaVencimiento date,
@tipoPago  nchar(20),
@tipoDeuda  nchar(50),
@detalle text,
@MontoCPP real,
@numeroCuentaBancaria nvarchar(50))
AS
BEGIN
	Update Cuenta_Por_Pagar
 set fechaEmisionPP = @fechaEmision,
montoPP = @MontoCPP,
fechaVencimientoPP = @fechaVencimiento,
tipoPagoPP= @tipoPago,
tipoDeudaPP = @tipoDeuda,
fkCuentaBancaria = (select distinct cb.iDCuenta
					from Cuenta_Bancaria cb
					where cb.numeroCuenta = @numeroCuentaBancaria
					),
					
detallePP = @detalle
					
where idCuentaPP=@idCuentaPP
END;
GO
