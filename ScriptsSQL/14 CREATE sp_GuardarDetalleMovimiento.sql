--DROP PROCEDURE dbo.[sp_GuardarDetalleMovimiento]      

CREATE PROCEDURE dbo.[sp_GuardarDetalleMovimiento]
(
	@IdMovimiento As Int,
	@IdProductos AS Varchar(4096),
	@Cantidades AS Varchar(MAX),
	@Precios AS Varchar(MAX),
	@Totales AS Varchar(MAX)
)
AS
BEGIN
      SET NOCOUNT ON;
      
      --DECLARE @TablaDetalle TABLE
      --(IdProducto INT,
      --Cantidad As Decimal(10,2),
      --Precio As Decimal(10,2),
      --Total As Decimal(10,2)
      --)
      
      select @IdMovimiento As IdMovimiento, Productos.Columna As IdProducto, 
      Cantidades.Columna As Cantidad,
      Precios.Columna As Precio,
      Totales.Columna As Total
      INTO #TempDetalle
      from dbo.fn_SplitToRows(@IdProductos, ',') As Productos
      INNER JOIN dbo.fn_SplitToRows(@Cantidades, ',') As Cantidades
      ON Productos.ID = Cantidades.ID
      INNER JOIN dbo.fn_SplitToRows(@Precios, ',') As Precios
      ON Cantidades.ID = Precios.ID
      INNER JOIN dbo.fn_SplitToRows(@Totales, ',') As Totales
      ON Totales.ID = Precios.ID
      
      --Se borran los IdProductos, ya no incluidos
      DELETE FROM dbo.MovimientosDetalle
      WHERE IdMovimiento = @IdMovimiento
      AND IdProducto NOT IN (SELECT IdProducto from #TempDetalle)
      
      --Se insertan producto nuevos
      INSERT INTO dbo.MovimientosDetalle
      SELECT @IdMovimiento, IdProducto, Cantidad, Precio, Total
      FROM #TempDetalle
      WHERE IdProducto NOT IN (SELECT IdProducto from dbo.MovimientosDetalle
								WHERE IdMovimiento = @IdMovimiento)
								
	  --Se actualizan productos ya existentes
	  UPDATE dbo.MovimientosDetalle
	  SET
		Cantidad = DetalleNuevo.Cantidad,
		Precio = DetalleNuevo.Precio,
		Total = DetalleNuevo.Total
	  FROM
		dbo.MovimientosDetalle DetalleActual
	  INNER JOIN
		#TempDetalle DetalleNuevo
	  ON 
	    DetalleActual.IdMovimiento = DetalleNuevo.IdMovimiento
		AND DetalleActual.IdProducto = DetalleNuevo.IdProducto;		
      
      
      SELECT Detalle.IdMovimientoDetalle, Detalle.IdProducto,
      Productos.Clave, Productos.Nombre,
      Detalle.Cantidad, Detalle.Precio, Detalle.Total
      FROM dbo.MovimientosDetalle AS Detalle
      INNER JOIN dbo.Productos AS Productos WITH(NOLOCK)
      ON Detalle.IdProducto = Productos.IdProducto
      WHERE Detalle.IdMovimiento = @IdMovimiento
END
--exec sp_GuardarDetalleMovimiento 5, '33,34,','125,135,','125,135,','125,135,' 