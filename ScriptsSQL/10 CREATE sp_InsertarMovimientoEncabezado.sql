--DROP PROCEDURE dbo.[sp_InsertarMovimientoEncabezado]      

CREATE PROCEDURE dbo.[sp_InsertarMovimientoEncabezado]
(
@Tipo As SmallInt,
@Folio As Varchar(10),
@Fecha As DateTime
)	      
AS
BEGIN
      SET NOCOUNT ON;
      
      IF NOT EXISTS (SELECT Folio FROM dbo.Movimientos WITH(NOLOCK)
      WHERE Tipo = @Tipo AND Folio = @Folio)
      BEGIN
        --se puede agregar un commit transaccion, por si algo sale male en la insercion  
		Insert Into dbo.Movimientos (Tipo, Folio, Fecha) Values (1, @Folio, @Fecha)
		SELECT IdMovimiento, Folio, Fecha, 'Exito' As ResultadoInsercion
		FROM dbo.Movimientos WITH(NOLOCK)
		WHERE Tipo = @Tipo AND Folio = @Folio
      END
      ELSE
      BEGIN
		SELECT IdMovimiento, Folio, Fecha, 'Error Folio de Movimiento Ya Existe' As ResultadoInsercion
		FROM dbo.Movimientos WITH(NOLOCK)
		WHERE Tipo = @Tipo AND Folio = @Folio
      END
      
      
END

---- declare @FolioMovimiento As Varchar(10)
--declare @FechaMovimiento As DateTime
--set @FolioMovimiento = 'C-00001'
--set @FechaMovimiento = GETDATE()

--exec sp_InsertarCompraEncabezado @FolioMovimiento, @FechaMovimiento