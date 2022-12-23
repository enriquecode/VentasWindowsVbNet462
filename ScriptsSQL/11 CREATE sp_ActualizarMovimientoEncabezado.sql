--DROP PROCEDURE dbo.[sp_ActualizarMovimientoEncabezado]      

CREATE PROCEDURE dbo.[sp_ActualizarMovimientoEncabezado]
(
@IdMovimiento As Int,
@Folio As Varchar(10),
@Fecha As DateTime,
@Status As bit
)	      
AS
BEGIN
      SET NOCOUNT ON;
      
      IF NOT EXISTS (SELECT Folio FROM dbo.Movimientos WITH(NOLOCK)
      WHERE Tipo = 1 And IdMovimiento <> @IdMovimiento AND Folio = @Folio)
      BEGIN
        --se puede agregar un commit transaccion, por si algo sale male en la insercion
        UPDATE dbo.Movimientos SET Folio = @Folio, Fecha = @Fecha, [Status] = @Status  
		WHERE IdMovimiento = @IdMovimiento
		SELECT IdMovimiento, Folio, Fecha, [Status] As StatusMovimiento, 'Exito' As ResultadoActualizacion
		FROM dbo.Movimientos WITH(NOLOCK)
		WHERE IdMovimiento = @IdMovimiento
		
      END
      ELSE
      BEGIN
		SELECT IdMovimiento, Folio, Fecha, [Status] As StatusMovimiento,
		'Error Folio Ya Existe' As ResultadoActualizacion FROM dbo.Movimientos WITH(NOLOCK)
		WHERE IdMovimiento = @IdMovimiento
      END
      
      
END

----declare @IdProducto As Integer
--declare @Clave As Varchar(50)
--declare @Nombre As Varchar(100)
--set @IdProducto = 27
-- set @Clave = 'Clave3-1'
-- set @Nombre = 'Producto3.-1'
-- exec sp_ActualizarProducto @IdProducto, @Clave, @Nombre