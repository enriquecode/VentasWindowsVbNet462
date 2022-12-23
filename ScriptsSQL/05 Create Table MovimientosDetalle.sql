--drop table [dbo].[MovimientosDetalle]
CREATE TABLE [dbo].[MovimientosDetalle](
	[IdMovimientoDetalle][int] IDENTITY(1,1)NOT NULL,
	[IdMovimiento][int] NOT NULL,
	[IdProducto][int] NOT NULL,
	[Cantidad][numeric](10,2) NOT NULL,
	[Precio][numeric](10,2) NOT NULL,
	[Total][numeric](15,2) NOT NULL		
 )
 GO

ALTER TABLE MovimientosDetalle
ADD CONSTRAINT [PK_MovimientosDetalle] PRIMARY KEY CLUSTERED 
(
	[IdMovimientoDetalle] ASC
)
GO

ALTER TABLE MovimientosDetalle
ADD CONSTRAINT [UK_MovimientosDetalle] UNIQUE 
(
	[IdMovimiento] ASC, [IdProducto] ASC
)
GO

ALTER TABLE MovimientosDetalle
ADD CONSTRAINT [FK_MovimientosDetalle_Movimientos] FOREIGN KEY ([IdMovimiento])
REFERENCES Movimientos(IdMovimiento)
GO

ALTER TABLE MovimientosDetalle
ADD CONSTRAINT [FK_MovimientosDetalle_Productos] FOREIGN KEY ([IdProducto])
REFERENCES Productos(IdProducto)
GO
