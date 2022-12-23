--drop TABLE [dbo].[TipoMovimientos]
CREATE TABLE [dbo].[TipoMovimientos](
	[Tipo] [smallint] NOT NULL,
	[Descripcion] [varchar](20) NOT NULL,
	[Naturaleza] [varchar] (1) NOT NULL
	
 )

GO

ALTER TABLE TipoMovimientos
ADD CONSTRAINT [PK_TipoMovimientos] PRIMARY KEY CLUSTERED 
(
	[Tipo] ASC
)
GO

