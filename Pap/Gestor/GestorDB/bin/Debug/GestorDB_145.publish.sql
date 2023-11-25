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
PRINT N'Altering [dbo].[tblAvaliacao]...';


GO
ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [data_assinatura_aluno] DATE NULL;

ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [data_assinatura_dt] DATE NULL;

ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [data_assinatura_professor] DATE NULL;

ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [dt_assinatura] VARCHAR (200) NULL;

ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [nome_aluno] VARCHAR (200) NULL;

ALTER TABLE [dbo].[tblAvaliacao] ALTER COLUMN [nome_professor] VARCHAR (200) NULL;


GO
PRINT N'Altering [dbo].[sp_InsertAvaliacao]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertAvaliacao]
	@avaliaçao_atividade varchar(1000),
	@faltas_desconsideradas varchar(1000),
	@codigo_avaliacao char(65)


AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_avaliaçoes) FROM tblAvaliacao

	IF(@count<>0)
	begin 
		select -1 as ReturnCode3
	End
	Begin
		Insert INTO [dbo].[tblAvaliacao]
				([avaliaçao_atividade],
				[faltas_desconsideradas],
				[codigo_avaliacao])
		Values (@avaliaçao_atividade,@faltas_desconsideradas,@codigo_avaliacao)
		select 1 as ReturnCode3
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetAvaliacaoByPrh]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAvaliacaoByPrh]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrhAvaliacaoByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhAvaliacaoByCode]';


GO
PRINT N'Refreshing [dbo].[sp_UpdatePrhAvaliacaoByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_UpdatePrhAvaliacaoByID]';


GO
PRINT N'Update complete.';


GO
