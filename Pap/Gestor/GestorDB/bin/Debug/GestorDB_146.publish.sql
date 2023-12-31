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
PRINT N'Altering [dbo].[tbldescricaoatividades]...';


GO
ALTER TABLE [dbo].[tbldescricaoatividades] ALTER COLUMN [data_final] DATE NOT NULL;

ALTER TABLE [dbo].[tbldescricaoatividades] ALTER COLUMN [data_inicio] DATE NOT NULL;


GO
PRINT N'Refreshing [dbo].[sp_GetDescricaoAtividadesByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDescricaoAtividadesByCode]';


GO
PRINT N'Refreshing [dbo].[sp_GetDescricaoAtividadesByPrh]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDescricaoAtividadesByPrh]';


GO
PRINT N'Refreshing [dbo].[sp_InsertDescricaoatividades]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertDescricaoatividades]';


GO
PRINT N'Refreshing [dbo].[sp_InsertDescricaoatividades2]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertDescricaoatividades2]';


GO
PRINT N'Refreshing [dbo].[sp_InsertDescricaoatividades3]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertDescricaoatividades3]';


GO
PRINT N'Refreshing [dbo].[sp_InsertDescricaoatividades4]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertDescricaoatividades4]';


GO
PRINT N'Refreshing [dbo].[sp_InsertDescricaoatividades5]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertDescricaoatividades5]';


GO
PRINT N'Refreshing [dbo].[sp_UpdateDescricaoAtividadesByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_UpdateDescricaoAtividadesByID]';


GO
PRINT N'Update complete.';


GO
