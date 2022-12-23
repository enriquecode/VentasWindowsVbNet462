--DROP PROCEDURE dbo.[sp_ObtenerMovimientosEncabezados]      

CREATE PROCEDURE dbo.[sp_ObtenerMovimientosEncabezados] 
(
@Tipo As SmallInt
)     
AS
BEGIN
      SET NOCOUNT ON;
      SELECT IdMovimiento, Folio, Fecha, Total, [Status] As Status
      FROM dbo.Movimientos WITH(NOLOCK)
      WHERE Tipo = @Tipo
END