--DROP PROCEDURE dbo.[sp_InsertarProducto]      

CREATE PROCEDURE dbo.[sp_InsertarProducto]
(
@Clave As Varchar(50),
@Nombre As Varchar(100)
)	      
AS
BEGIN
      SET NOCOUNT ON;
      
      IF NOT EXISTS (SELECT Clave FROM dbo.Productos WITH(NOLOCK) WHERE Clave = @Clave)
      BEGIN
        --se puede agregar un commit transaccion, por si algo sale male en la insercion  
		Insert Into dbo.Productos (Clave, Nombre) Values (@Clave, @Nombre)
		SELECT IdProducto, Clave, Nombre, 'Exito' As ResultadoInsercion FROM dbo.Productos WITH(NOLOCK)
		WHERE Clave = @Clave
      END
      ELSE
      BEGIN
		SELECT IdProducto, Clave, Nombre, 'Error Clave Ya Existe' As ResultadoInsercion FROM dbo.Productos WITH(NOLOCK)
		WHERE Clave = @Clave
      END
      
      
END

--declare @Clave As Varchar(50)
--declare @Nombre As Varchar(100)
 --set @Clave = 'Clave1'
 --set @Nombre = 'Producto1'
 --exec sp_InsertarProducto @Clave, @Nombre