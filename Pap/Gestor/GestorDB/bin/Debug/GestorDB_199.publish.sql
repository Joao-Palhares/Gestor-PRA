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
PRINT N'Creating [dbo].[sp_GetPra]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPra]
AS
begin
		select * From tblPra 
END
GO
PRINT N'Creating [dbo].[sp_GetPraByCode]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPraByCode]
	@codigo_pra varchar(20)
AS
begin
		select * From tblPra where codigo_pra=@codigo_pra
END
GO
PRINT N'Creating [dbo].[sp_GetPraByID]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPraByID]
	@id_pra int

AS
begin
		select * From tblPra where id_pra=@id_pra
END
GO
PRINT N'Creating [dbo].[sp_GetPraPrincipalByCode]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPraPrincipalByCode]
	@codepraprincipal varchar(70)
AS
begin
		select * From tblPraPrincipal where codepraprincipal=@codepraprincipal
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByAluno]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByAluno]
@id_aluno int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_aluno=@id_aluno
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByDT]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByDT]
@id_dt int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_dt=@id_dt
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor1]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor1]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor1=@id_professor
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor2]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor2]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor2=@id_professor
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor3]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor3]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor3=@id_professor
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor4]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor4]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor4=@id_professor
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor5]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor5]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor5=@id_professor
END
GO
PRINT N'Creating [dbo].[sp_GetPrasByProfessor6]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrasByProfessor6]
@id_professor int
AS
BEGIN
	SELECT tblPra.id_pra ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblProfessores.id_professor,tblProfessores.nome_professor,tblTurmas.id_turma ,tblTurmas.nome_turma , tblDT.id_dt ,tblDT.nome_dt, tblPra.estado,tblPra.progresso
FROM tblPra
INNER JOIN tblProfessores ON tblPra.id_professor1=tblProfessores.id_professor
INNER JOIN tblAlunos ON tblPra.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblTurmas ON tblPra.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPra.id_dt = tblDT.id_dt where tblPra.id_professor6=@id_professor
END
GO
PRINT N'Update complete.';


GO
