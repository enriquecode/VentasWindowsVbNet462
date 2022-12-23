--DROP PROCEDURE dbo.[sp_ObtenerProductos]      

CREATE PROCEDURE dbo.[sp_ObtenerProductos]      
AS
BEGIN
      SET NOCOUNT ON;
      SELECT IdProducto, Clave, Nombre, Existencia, [Status] FROM dbo.Productos WITH(NOLOCK)
END