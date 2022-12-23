--DROP TABLE [dbo].[Movimientos]
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento][int]IDENTITY(1,1)NOT NULL,
	[Tipo][smallint] NOT NULL,
	[Folio][varchar](10) NOT NULL,
	[Fecha][datetime] NOT NULL,
	[Total][numeric](15,2) NOT NULL	,
	[Status][bit] NOT NULL	
 )
 GO

ALTER TABLE Movimientos
ADD CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)
GO

ALTER TABLE Movimientos
ADD CONSTRAINT [UK_FolioMovimiento] UNIQUE
(
	[Folio]
)
GO

ALTER TABLE Movimientos
ADD CONSTRAINT [FK_Movimientos_TipoMovimientos] FOREIGN KEY ([Tipo])
REFERENCES TipoMovimientos(Tipo)
GO

ALTER TABLE [dbo].[Movimientos] ADD CONSTRAINT [DF_Movimientos_Total] DEFAULT ((0)) FOR [Total]
GO

ALTER TABLE [dbo].[Movimientos] ADD CONSTRAINT [DF_Movimientos_Status] DEFAULT ((1)) FOR [Status]
GO

