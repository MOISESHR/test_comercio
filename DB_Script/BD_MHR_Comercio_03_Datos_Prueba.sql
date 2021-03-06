USE [DB_MHR_Comercio]
GO
--SET DATEFORMAT dmy;  

SET DATEFORMAT ymd;  
GO  

SET IDENTITY_INSERT [dbo].[Banco] ON 

INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (1, N'BANCO REPUBLICA EN LIQUIDACION', N'AV. REPUBLICA', CAST(N'2019-03-20 03:59:49.957' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (2, N'BANCO CCC DEL PERU', N'AV. CCC DEL PERU', CAST(N'2019-03-20 03:59:50.040' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (3, N'CITIBANK DEL PERU S A', N'AV. CITIBANK PERU', CAST(N'2019-03-20 03:59:50.073' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (4, N'BANCO INTERAMERICANO DE FINANZAS', N'AV. BANCO INTERAMERICANO', CAST(N'2019-03-20 03:59:50.113' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (5, N'BANCO DE LA NACION', N'AV. NACION 444', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (6, N'BANCO AGRARIO DEL PERU EN LIQUIDACION', N'AV. BANCO AGRARIO DEL PE', CAST(N'2019-03-20 03:59:50.183' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (7, N'BANCO INDUSTRIAL DEL PERU', N'AV. INDUSTRIAL', CAST(N'2019-03-20 03:59:50.217' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (8, N'BANCO MINERO DEL PERU', N'AV. MINERO', CAST(N'2019-03-20 03:59:50.250' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (9, N'BANCO DE LA VIVIENDA DEL PERU', N'AV. VIVIENDA', CAST(N'2019-03-20 03:59:50.287' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (10, N'BANCO HIPOTECARIO DEL PERU', N'AV. HIPOTECARIO', CAST(N'2019-03-20 03:59:50.320' AS DateTime))
INSERT [dbo].[Banco] ([ID], [nombre], [direccion], [fecha_registro]) VALUES (11, N'BANCO NUEVO MUNDO', N'AV. NOVOBANC', CAST(N'2019-03-20 03:59:50.357' AS DateTime))
SET IDENTITY_INSERT [dbo].[Banco] OFF
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (1, 2, N'Arenales', N'Av. Arenales 333', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (2, 2, N'Plaza Sam miguel 222', N'Av. la marina 123', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (3, 3, N'Torre Derby', N'Av. El Derby 556', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (4, 5, N'Jokey Plaza', N'Av. javier prado 456', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (5, 4, N'Central Grau', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (6, 4, N'Plaza Zalaberry', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (7, 4, N'Plaza Central', N'Av. javier prado 456', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (8, 4, N'Jiron de la Union', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (9, 4, N'Edificio central', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (10, 4, N'Plaza Riso', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (11, 2, N'Arenales 200', N'Av. Arenales 333', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (12, 2, N'Plaza Sam miguel 333', N'Av. la marina 123', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (13, 3, N'Torre Derby 2000', N'Av. El Derby 556', CAST(N'2018-02-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (14, 5, N'Jokey Plaza - Of 200', N'Av. javier prado 456', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Sucursales] ([ID], [banco_id], [nombre], [direccion], [fecha_registro]) VALUES (15, 4, N'Central Grau  - Of 500', N'Av. Grau 2333', CAST(N'2019-03-20 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
SET IDENTITY_INSERT [dbo].[OrdenPago] ON 

INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (1, 1, CAST(100.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (2, 1, CAST(350.00 AS Decimal(18, 2)), N'Soles', N'Anulada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (3, 3, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (4, 4, CAST(600.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (5, 4, CAST(800.00 AS Decimal(18, 2)), N'Dolares', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (6, 2, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Fallida', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (7, 3, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (8, 3, CAST(150.00 AS Decimal(18, 2)), N'Dolares', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (9, 3, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (10, 1, CAST(350.00 AS Decimal(18, 2)), N'Dolares', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (11, 1, CAST(350.00 AS Decimal(18, 2)), N'Soles', N'Declinada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (12, 1, CAST(400.00 AS Decimal(18, 2)), N'Dolares', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (13, 1, CAST(350.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (14, 3, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (16, 3, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-20 02:00:00.000' AS DateTime))
INSERT [dbo].[OrdenPago] ([ID], [sucursal_id], [monto], [moneda], [estado], [fecha_pago]) VALUES (21, 13, CAST(500.00 AS Decimal(18, 2)), N'Soles', N'Pagada', CAST(N'2019-03-22 04:55:34.363' AS DateTime))
SET IDENTITY_INSERT [dbo].[OrdenPago] OFF
