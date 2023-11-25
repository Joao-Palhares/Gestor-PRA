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
PRINT N'Altering [dbo].[sp_GetPrhs]...';


GO
ALTER PROCEDURE [dbo].[sp_GetPrhs]
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.nome, tblTurmas.nome_turma, tblProfessores.nome
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_dt = tblProfessores.id_professor
END
GO
PRINT N'Update complete.';


GO
