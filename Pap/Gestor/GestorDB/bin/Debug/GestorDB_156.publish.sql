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
PRINT N'The following operation was generated from a refactoring log file 87e76f00-136d-4691-b46a-e7179bebb709';

PRINT N'Rename [dbo].[tblAlunos].[nome] to nome_aluno';


GO
EXECUTE sp_rename @objname = N'[dbo].[tblAlunos].[nome]', @newname = N'nome_aluno', @objtype = N'COLUMN';


GO
PRINT N'Altering [dbo].[tblPrh]...';


GO
ALTER TABLE [dbo].[tblPrh]
    ADD [Complete] BIT NULL;


GO
PRINT N'Altering [dbo].[sp_GetPrhsByAluno]...';


GO
ALTER PROCEDURE [dbo].[sp_GetPrhsByAluno]
@id_aluno int
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome , tblDT.id_dt ,tblDT.nome
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPrh.id_dt = tblDT.id_dt where tblPrh.id_aluno=@id_aluno
END
GO
PRINT N'Altering [dbo].[sp_GetPrhsByDT]...';


GO
ALTER PROCEDURE [dbo].[sp_GetPrhsByDT]
@id_dt int
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome , tblDT.id_dt ,tblDT.nome
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPrh.id_dt = tblDT.id_dt where tblPrh.id_dt=@id_dt
END
GO
PRINT N'Altering [dbo].[sp_GetPrhsByProfessor]...';


GO
ALTER PROCEDURE [dbo].[sp_GetPrhsByProfessor]
@id_professor int
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome , tblDT.id_dt ,tblDT.nome
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPrh.id_dt = tblDT.id_dt where tblPrh.id_professor=@id_professor
END
GO
PRINT N'Altering [dbo].[sp_GetAlunoByName]...';


GO
ALTER PROCEDURE [dbo].[sp_GetAlunoByName]
	@nome varchar(100)

AS
begin
		select * From tblAlunos where nome_aluno=@nome
END
GO
PRINT N'Altering [dbo].[sp_GetAlunos]...';


GO
ALTER PROCEDURE [dbo].[sp_GetAlunos]
AS
BEGIN
	SELECT * FROM tblAlunos order by nome_aluno asc
END
GO
PRINT N'Altering [dbo].[sp_InsertAluno]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertAluno]
	@nome varchar(100),
	@n_processo int,
	@data_nascimento date,
	@id_curso int,
	@id_turma int,
	@numero int,
	@id_user int
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_aluno) FROM tblAlunos Where n_processo=@n_processo

	IF(@count<>0)
	begin 
		select -1 as ReturnCode1
	End
	Begin
		Insert INTO [dbo].[tblAlunos]
				([nome_aluno],
				[n_processo],
				[data_nascimento],
				[id_curso],
				[id_turma],
				[numero],
				[id_user])
		Values (@nome,@n_processo,@data_nascimento,@id_curso,@id_turma,@numero,@id_user)
		select 1 as ReturnCode1
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateAlunoByID]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateAlunoByID]
	@id_aluno int,
	@n_processo varchar(50),
	@nome char(64),
	@data_nascimento date,
	@id_curso int,
	@id_turma int,
	@numero int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblAlunos
	where id_aluno=@id_aluno

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblAlunos 
		set n_processo=@n_processo , nome_aluno=@nome , data_nascimento = @data_nascimento, id_curso = @id_curso, id_turma= @id_turma, numero= @numero
		where id_aluno=@id_aluno
		select 1 as ReturnCode
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetPrhByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhByCode]';


GO
PRINT N'Refreshing [dbo].[sp_GetPrhByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhByID]';


GO
PRINT N'Refreshing [dbo].[sp_InsertPrh]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_InsertPrh]';


GO
PRINT N'Refreshing [dbo].[sp_UpdatePrhByID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_UpdatePrhByID]';


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '87e76f00-136d-4691-b46a-e7179bebb709')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('87e76f00-136d-4691-b46a-e7179bebb709')

GO

GO
PRINT N'Update complete.';


GO