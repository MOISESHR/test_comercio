USE [master]
GO
/****** Object:  Database [DB_MHR_Comercio]    Script Date: 18/03/2019 18:00:50 ******/
CREATE DATABASE [DB_MHR_Comercio]

GO

USE [DB_MHR_Comercio]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 20/03/2019 17:39:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[fecha_registro] [datetime] NULL CONSTRAINT [DF_Banco_fecha_registro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 20/03/2019 17:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[sucursal_id] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[moneda] [varchar](10) NULL,
	[estado] [varchar](20) NULL,
	[fecha_pago] [datetime] NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 20/03/2019 17:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[banco_id] [int] NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[fecha_registro] [datetime] NULL CONSTRAINT [DF_Sucursales_fecha_registro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPago_Sucursales] FOREIGN KEY([sucursal_id])
REFERENCES [dbo].[Sucursales] ([ID])
GO
ALTER TABLE [dbo].[OrdenPago] CHECK CONSTRAINT [FK_OrdenPago_Sucursales]
GO
ALTER TABLE [dbo].[Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_Sucursales_Banco] FOREIGN KEY([banco_id])
REFERENCES [dbo].[Banco] ([ID])
GO
ALTER TABLE [dbo].[Sucursales] CHECK CONSTRAINT [FK_Sucursales_Banco]
GO
