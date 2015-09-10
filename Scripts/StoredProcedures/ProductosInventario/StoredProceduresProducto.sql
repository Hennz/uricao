USE [Uricao]

GO
CREATE PROCEDURE [SeleccionarTodosLosProductos]
AS
BEGIN
SET NOCOUNT ON;
SELECT p.nombreProducto, p.tipoProducto, c.nombreCategoria
FROM Producto p, Categoria c
WHERE c.idCategoria = p.fkCategoria
END;

GO

CREATE PROCEDURE [SeleccionarTodasLasCategorias]
AS
BEGIN
SET NOCOUNT ON;
SELECT *
FROM Categoria
END;

GO
CREATE PROCEDURE [SeleccionarTodasLasMarcas]
AS
BEGIN
SET NOCOUNT ON;
SELECT m.nombreMarca
FROM Marca m
END;

GO
CREATE PROCEDURE [SeleccionarTodasLasMarcasProveedor]
@nombreProveedor VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;
SELECT m.nombreMarca
FROM Marca m, Proveedor p
WHERE p.idProveedor = m.fkidProveedor
AND p.nombreProveedor = @nombreProveedor
END;

GO
CREATE PROCEDURE [SeleccionarProductosDetallados]
@nombreProducto VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;
    SELECT p.nombreProducto, d.codigoProducto, d.calidadProducto, d.precioProducto, m.nombreMarca, pro.nombreProveedor
	FROM   Producto p, Detalle_Producto d, Marca m, Proveedor pro
	WHERE  (p.idProducto = d.fkProducto)
	AND    (m.IdMarca = d.fkMarca)
	AND	   (pro.idProveedor = m.fkidProveedor)
	AND    (p.nombreProducto = @nombreProducto)
END;

GO

drop PROCEDURE [AgregarProducto]
go
CREATE PROCEDURE [AgregarProducto]
@nombreProducto VARCHAR(100),
@tipoProducto VARCHAR(100),
@categoria INT,
@cantidad INT
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO Producto(nombreProducto,tipoProducto,fkCategoria,cantidadMinInventario)
VALUES		(@nombreProducto, @tipoProducto, @categoria, @cantidad);
END;

GO
CREATE PROCEDURE [AgregarDetalleProducto]
@codigo VARCHAR(100),
@precio DECIMAL,
@calidad VARCHAR(100),
@marca VARCHAR(100),
@producto VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;

DECLARE @marcaId BIGINT
DECLARE @productoId BIGINT

SELECT @marcaId = m.IdMarca 
FROM Marca m
WHERE m.nombreMarca = @marca

SELECT @productoId = p.idProducto
FROM Producto p
WHERE p.nombreProducto = @producto

INSERT INTO Detalle_Producto (codigoProducto,precioProducto,calidadProducto,fkMarca,fkProducto)
VALUES (@codigo,@precio,@calidad,@marcaId,@productoId)
END;

GO
CREATE PROCEDURE [ConsultarTodosImplementosProductos]
AS
BEGIN
SET NOCOUNT ON;
SELECT idProducto, nombreProducto 
FROM Producto
END;

GO
CREATE PROCEDURE [EditarProducto]
@codigo VARCHAR(100),
@precio DECIMAL,
@calidad VARCHAR(100),
@marca VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;

DECLARE @marcaId BIGINT

SELECT @marcaId = m.IdMarca 
FROM Marca m
WHERE m.nombreMarca = @marca

UPDATE Detalle_Producto SET precioProducto=@precio,calidadProducto=@calidad,fkMarca=@marcaId
WHERE (codigoProducto=@codigo)
END;

GO
CREATE PROCEDURE [EditarProductoGenerico]
@nombreViejo VARCHAR(100),
@nombreNuevo VARCHAR(100),
@tipo VARCHAR(100),
@categoria VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;

DECLARE @categoriaId BIGINT

SELECT @categoriaId = c.idCategoria 
FROM Categoria c
WHERE c.nombreCategoria = @categoria

UPDATE Producto SET nombreProducto=@nombreNuevo, tipoProducto=@tipo, fkCategoria=@categoriaId
WHERE (nombreProducto = @nombreViejo)
END;

GO
CREATE PROCEDURE [SumarCantidadProducto]
@nombreProducto VARCHAR(100)
AS
BEGIN
SET NOCOUNT ON;
Select SUM(l.cantidadLote)
from Lote l, Detalle_producto d, Producto p 
where l.fkidDet_Pro = d.idDet_Pro
and p.idProducto = d.fkProducto
and p.nombreProducto=@nombreProducto
END;
