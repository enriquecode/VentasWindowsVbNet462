--DROP PROCEDURE dbo.[sp_ObtenerDetalleMovimiento]      

CREATE PROCEDURE dbo.[sp_ObtenerDetalleMovimiento]
(
	@IdMovimiento As Int
)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT Detalle.IdMovimientoDetalle, Detalle.IdProducto,
      Productos.Clave, Productos.Nombre,
      Detalle.Cantidad, Detalle.Precio, Detalle.Total
      FROM dbo.MovimientosDetalle AS Detalle
      INNER JOIN dbo.Productos AS Productos WITH(NOLOCK)
      ON Detalle.IdProducto = Productos.IdProducto
      WHERE Detalle.IdMovimiento = @IdMovimiento
END