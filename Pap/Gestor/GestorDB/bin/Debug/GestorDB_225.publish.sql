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
The column id_pra on table [dbo].[tblPraNotificacoes] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblPraNotificacoes])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[tblPraNotificacoes]...';


GO
ALTER TABLE [dbo].[tblPraNotificacoes] ALTER COLUMN [id_pra] INT NOT NULL;


GO
PRINT N'Altering [dbo].[sp_InsertNotificacoes]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertNotificacoes]
	@assinatura_enc varchar(50),
	@data_assinatura_enc date,
	@codenotificaçoes char(65),
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_notificaçoes) FROM tblPraNotificacoes

	IF(@count<>0)
	begin 
		select -1 as ReturnCode4
	End
	Begin
		Insert INTO [dbo].[tblPraNotificacoes]
				([assinatura_enc],
				[data_assinatura_enc],
				[codenotificaçoes],
				[id_pra])
		Values (@assinatura_enc,@data_assinatura_enc,@codenotificaçoes,@id_pra)
		select 1 as ReturnCode4
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetNotificacoesByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetNotificacoesByCode]';


GO
PRINT N'Refreshing [dbo].[sp_GetNotificacoesByPra]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetNotificacoesByPra]';


GO
PRINT N'Refreshing [dbo].[sp_UpdateNotificaçoesByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_UpdateNotificaçoesByID]';


GO
PRINT N'Update complete.';


GO
