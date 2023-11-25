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
PRINT N'Altering [dbo].[tblAlunos]...';


GO
ALTER TABLE [dbo].[tblAlunos] ALTER COLUMN [pra] VARCHAR (5) NULL;


GO
PRINT N'Refreshing [dbo].[sp_DeleteAlunoByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_DeleteAlunoByID]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByID]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByName]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByName]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByNumturma]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByNumturma]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByProcesso]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByProcesso]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByTurma]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByTurma]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunoByUserID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunoByUserID]';


GO
PRINT N'Refreshing [dbo].[sp_GetAlunos]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetAlunos]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByAluno]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByAluno]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByDT]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByDT]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor1]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor1]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor2]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor2]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor3]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor3]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor4]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor4]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor5]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor5]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrasByProfessor6]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrasByProfessor6]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrhsByAluno]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhsByAluno]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrhsByDT]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhsByDT]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrhsByProfessor]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhsByProfessor]';


GO
PRINT N'Refreshing [dbo].[sp_InsertAluno]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertAluno]';


GO
PRINT N'Refreshing [dbo].[sp_UpdateAlunoByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_UpdateAlunoByID]';


GO
PRINT N'Update complete.';


GO
