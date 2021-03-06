USE [DB_MHR_Comercio]
GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_ACTUALIZAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_ACTUALIZAR]
OBJETIVO             : Realizar la Actualización de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_ACTUALIZAR]
@ID                                                 int
,@nombre                                             varchar(50)
,@direccion                                          varchar(50)
,@fecha_registro                                     date=NULL
AS
BEGIN
       UPDATE Banco
       SET
          nombre = @nombre
          ,direccion = @direccion
          ,fecha_registro = @fecha_registro
       WHERE
          ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_ELIMINAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_ELIMINAR]
OBJETIVO             : Realizar la Eliminacion de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_ELIMINAR]
@ID                                                 int
AS
BEGIN TRANSACTION EliminarBanco
BEGIN
       DELETE FROM Banco
       WHERE
          ID = @ID
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_GETREG]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_GETREG]
OBJETIVO             : Obtener un Registro de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_GETREG]
@ID                                                 int
AS
BEGIN
       SELECT 
          ID
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Banco
       WHERE
          ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_INSERTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_INSERTAR]
OBJETIVO             : Realizar la Inserción de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_INSERTAR]
@nombre                                             varchar(50)
,@direccion                                          varchar(50)
,@fecha_registro                                     date=NULL
AS
BEGIN TRANSACTION InsertarBanco
BEGIN
       INSERT INTO Banco(
          nombre
          ,direccion
          ,fecha_registro
)
       VALUES(
          @nombre
          ,@direccion
          ,@fecha_registro
)
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_LISTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_LISTAR]
OBJETIVO             : Obtener un Listado de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_LISTAR]
AS
BEGIN
       SELECT 
          ID
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Banco WITH (NOLOCK)
END


GO
/****** Object:  StoredProcedure [dbo].[PA_Banco_LISTAR_All]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Banco_LISTAR_All]
OBJETIVO             : Obtiene Todos los Registros de Banco
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Banco_LISTAR_All]
AS
BEGIN
       SELECT 
          ID
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Banco WITH (NOLOCK)
END


GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_ACTUALIZAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_ACTUALIZAR]
OBJETIVO             : Realizar la Actualización de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_ACTUALIZAR]
@ID                                                 int
,@sucursal_id                                        int=NULL
,@monto                                              decimal(18,2)
,@moneda                                             varchar(10)
,@estado                                             varchar(20)
,@fecha_pago                                         datetime=NULL
AS
BEGIN
       UPDATE OrdenPago
       SET
          sucursal_id = @sucursal_id
          ,monto = @monto
          ,moneda = @moneda
          ,estado = @estado
          ,fecha_pago = @fecha_pago
       WHERE
          ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_ELIMINAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_ELIMINAR]
OBJETIVO             : Realizar la Eliminacion de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_ELIMINAR]
@ID                                                 int
AS
BEGIN TRANSACTION EliminarOrdenPago
BEGIN
       DELETE FROM OrdenPago
       WHERE
          ID = @ID
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_GETREG]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_GETREG]
OBJETIVO             : Obtener un Registro de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_GETREG]
@ID                                                 int
AS
BEGIN
       SELECT 
          ID
          ,sucursal_id
          ,monto
          ,moneda
          ,estado
          ,fecha_pago
       FROM OrdenPago
       WHERE
          ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_INSERTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_INSERTAR]
OBJETIVO             : Realizar la Inserción de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_INSERTAR]
@ID                                                 int
,@sucursal_id                                        int=NULL
,@monto                                              decimal(18,2)
,@moneda                                             varchar(10)
,@estado                                             varchar(20)
,@fecha_pago                                         datetime=NULL
AS
BEGIN TRANSACTION InsertarOrdenPago
BEGIN
       INSERT INTO OrdenPago(
          sucursal_id
          ,monto
          ,moneda
          ,estado
          ,fecha_pago
)
       VALUES(
          @sucursal_id
          ,@monto
          ,@moneda
          ,@estado
          ,@fecha_pago
)
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_LISTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_LISTAR]
OBJETIVO             : Obtener un Listado de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_LISTAR]
@sucursal_id                                        int=NULL
,@moneda                                             varchar(10)=''
AS
BEGIN
       SELECT 
          n1.ID
          ,n1.sucursal_id
		  ,n2.nombre as NomSucursal
          ,n1.monto
          ,n1.moneda
          ,n1.estado
          ,n1.fecha_pago
       FROM OrdenPago n1 WITH (NOLOCK)
	   INNER JOIN Sucursales n2 ON n1.sucursal_id=n2.ID
	   WHERE (@sucursal_id=0 OR @sucursal_id IS NULL OR sucursal_id=@sucursal_id) AND n1.moneda like '%' + @moneda + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[PA_OrdenPago_LISTAR_All]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_OrdenPago_LISTAR_All]
OBJETIVO             : Obtiene Todos los Registros de OrdenPago
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_OrdenPago_LISTAR_All]
AS
BEGIN
       SELECT 
          ID
          ,sucursal_id
          ,monto
          ,moneda
          ,estado
          ,fecha_pago
       FROM OrdenPago WITH (NOLOCK)
END


GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_ACTUALIZAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_ACTUALIZAR]
OBJETIVO             : Realizar la Actualización de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_ACTUALIZAR]
@ID                                                 int
,@banco_id                                           int=NULL
,@nombre                                             varchar(50)
,@direccion                                          varchar(50)
,@fecha_registro                                     date=NULL
AS
BEGIN
       UPDATE Sucursales
       SET
          banco_id = @banco_id
          ,nombre = @nombre
          ,direccion = @direccion
          ,fecha_registro = @fecha_registro
       WHERE
          ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_ELIMINAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_ELIMINAR]
OBJETIVO             : Realizar la Eliminacion de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_ELIMINAR]
@ID                                                 int
AS
BEGIN TRANSACTION EliminarSucursales
BEGIN
       DELETE FROM Sucursales
       WHERE
          ID = @ID
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_GETREG]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_GETREG]
OBJETIVO             : Obtener un Registro de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_GETREG]
@ID                                                 int
AS
BEGIN
       SELECT 
          ID
          ,banco_id
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Sucursales
       WHERE
          ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_INSERTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_INSERTAR]
OBJETIVO             : Realizar la Inserción de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_INSERTAR]
@ID                                                 int
,@banco_id                                           int=NULL
,@nombre                                             varchar(50)
,@direccion                                          varchar(50)
,@fecha_registro                                     date=NULL
AS
BEGIN TRANSACTION InsertarSucursales
BEGIN
       INSERT INTO Sucursales(
          banco_id
          ,nombre
          ,direccion
          ,fecha_registro
)
       VALUES(
          @banco_id
          ,@nombre
          ,@direccion
          ,@fecha_registro
)
END
IF @@ERROR <> 0 ROLLBACK TRANSACTION
ELSE COMMIT TRANSACTION


GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_LISTAR]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_LISTAR]
OBJETIVO             : Obtener un Listado de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_LISTAR]
@banco_id                                           int=NULL
,@nombre                                             varchar(50)=''
AS
BEGIN
       SELECT 
          ID
          ,banco_id
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Sucursales WITH (NOLOCK)
	   WHERE (@banco_id=0 OR @banco_id IS NULL OR banco_id=@banco_id) AND nombre LIKE '%' + @nombre + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[PA_Sucursales_LISTAR_All]    Script Date: 20/03/2019 17:40:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=====================================================================================================
STORE                : [PA_Sucursales_LISTAR_All]
OBJETIVO             : Obtiene Todos los Registros de Sucursales
Autor                : Moisés HUAMÁN RAMOS
Fecha Creación       : 19/03/2019
Fecha Modificación   : **************
=====================================================================================================
*/

CREATE PROCEDURE [dbo].[PA_Sucursales_LISTAR_All]
AS
BEGIN
       SELECT 
          ID
          ,banco_id
          ,nombre
          ,direccion
          ,fecha_registro
       FROM Sucursales WITH (NOLOCK)
END


GO
