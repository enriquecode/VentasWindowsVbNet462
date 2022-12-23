--DROP TABLE [dbo].[Productos]
CREATE TABLE [dbo].[Productos](
	[IdProducto][int]IDENTITY(1,1)NOT NULL,
	[Clave][varchar](50)NOT NULL,
	[Nombre][varchar](100)NOT NULL,
	[Existencia][numeric](10,2) NOT NULL,
	[Status][bit]NOT NULL,
	[FechaAlta][datetime]NOT NULL,
	[FechaUltimaModificacion][datetime] NULL	
 )
 GO

ALTER TABLE Productos
ADD CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)
GO

ALTER TABLE Productos
ADD CONSTRAINT [UK_Productos] UNIQUE
(
	[Clave]
)
GO

ALTER TABLE [dbo].[Productos] ADD CONSTRAINT [DF_Productos_Existencia]  DEFAULT ((0)) FOR [Existencia]
GO

ALTER TABLE [dbo].[Productos] ADD CONSTRAINT [DF_Productos_Status]  DEFAULT ((1)) FOR [Status]
GO

ALTER TABLE [dbo].[Productos] ADD CONSTRAINT [DF_Productos_FechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO


