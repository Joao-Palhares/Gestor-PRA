﻿/*
Deployment script for GestorDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "GestorDB"
:setvar DefaultFilePrefix "GestorDB"
:setvar DefaultDataPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\jonip\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[tblPra].[id_dm] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[tblPra])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[FK_tblPra_tblPraDM]...';


GO
ALTER TABLE [dbo].[tblPra] DROP CONSTRAINT [FK_tblPra_tblPraDM];


GO
PRINT N'Altering [dbo].[tblPra]...';


GO
ALTER TABLE [dbo].[tblPra] DROP COLUMN [id_dm];


GO
PRINT N'Altering [dbo].[sp_InsertPra]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertPra]
	@id_pra int,
	@id_principal int,
	@id_medidas int,
	@id_notificaçoes int,
	@id_decisao int,
	@codigo_pra varchar(20)

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_pra) FROM tblPra Where id_pra=@id_pra

	IF(@count<>0)
	begin 
		select -1 as ReturnCodepra
	End
	Begin
		Insert INTO [dbo].[tblPra]
				([id_pra],
				[id_principal],
				[id_medidas],
				[id_notificaçoes],
				[id_decisao],
				[codigo_pra])
		Values (@id_pra,@id_principal,@id_medidas,@id_notificaçoes,@id_decisao,@codigo_pra)
		select 1 as ReturnCodepra
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetPraByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPraByCode]';


GO
PRINT N'Update complete.';


GO
