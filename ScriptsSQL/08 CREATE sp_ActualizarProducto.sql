--DROP PROCEDURE dbo.[sp_ActualizarProducto]      

CREATE PROCEDURE dbo.[sp_ActualizarProducto]
(
@IdProducto As Integer,
@Clave As Varchar(50),
@Nombre As Varchar(100)
)	      
AS
BEGIN
      SET NOCOUNT ON;
      
      IF NOT EXISTS (SELECT Clave FROM dbo.Productos WITH(NOLOCK) WHERE IdProducto <> @IdProducto AND Clave = @Clave)
      BEGIN
        --se puede agregar un commit transaccion, por si algo sale male en la insercion  
		UPDATE dbo.Productos SET Clave = @Clave, Nombre = @Nombre, FechaUltimaModificacion = GETDATE() 
		WHERE IdProducto = @IdProducto
		SELECT IdProducto, Clave, Nombre, 'Exito' As ResultadoActualizacion FROM dbo.Productos WITH(NOLOCK)
		WHERE IdProducto = @IdProducto
		
      END
      ELSE
      BEGIN
		SELECT IdProducto, Clave, Nombre, 'Error Clave Ya Existe' As ResultadoActualizacion FROM dbo.Productos WITH(NOLOCK)
		WHERE Clave = @Clave
      END
      
      
END

----declare @IdProducto As Integer
--declare @Clave As Varchar(50)
--declare @Nombre As Varchar(100)
--set @IdProducto = 27
-- set @Clave = 'Clave3-1'
-- set @Nombre = 'Producto3.-1'
-- exec sp_ActualizarProducto @IdProducto, @Clave, @Nombre