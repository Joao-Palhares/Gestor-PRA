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
PRINT N'The following operation was generated from a refactoring log file 6f7f3bdd-96d6-445e-abeb-6dc95d56e019';

PRINT N'Rename [dbo].[tblPrh].[Complete] to estado';


GO
EXECUTE sp_rename @objname = N'[dbo].[tblPrh].[Complete]', @newname = N'estado', @objtype = N'COLUMN';


GO
PRINT N'Altering [dbo].[tblPrh]...';


GO
ALTER TABLE [dbo].[tblPrh] ALTER COLUMN [estado] VARCHAR (50) NULL;


GO
PRINT N'Altering [dbo].[sp_GetPrhsByAluno]...';


GO
ALTER PROCEDURE [dbo].[sp_GetPrhsByAluno]
@id_aluno int
AS
BEGIN
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome_professor , tblDT.id_dt ,tblDT.nome_dt, tblPrh.estado
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
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome_professor , tblDT.id_dt ,tblDT.nome_dt, tblPrh.estado
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
	SELECT tblPrh.id_prh ,tblAlunos.id_aluno,tblAlunos.nome_aluno,tblTurmas.id_turma ,tblTurmas.nome_turma,tblProfessores.id_professor ,tblProfessores.nome_professor , tblDT.id_dt ,tblDT.nome_dt, tblPrh.estado
FROM tblPrh
INNER JOIN tblAlunos ON tblPrh.id_aluno = tblAlunos.id_aluno 
INNER JOIN tblProfessores ON tblPrh.id_professor = tblProfessores.id_professor
INNER JOIN tblTurmas ON tblPrh.id_turma = tblTurmas.id_turma 
INNER JOIN tblDT ON tblPrh.id_dt = tblDT.id_dt where tblPrh.id_professor=@id_professor
END
GO
PRINT N'Altering [dbo].[sp_InsertPrh]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertPrh]
	@id_principal int,
	@codigo_prh varchar(70),
	@id_professor int,
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@estado varchar(50)


AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_prh) FROM tblPrh

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblPrh]
				([id_principal],
				[codigo_prh],
				[id_professor],
				[id_aluno],
				[id_turma],
				[id_dt],
				[estado])
		Values (@id_principal,@codigo_prh,@id_professor,@id_aluno,@id_turma,@id_dt,@estado)
		select 1 as ReturnCode
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdatePrhByID]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdatePrhByID]
	@id_prh int,
	@id_principal int,
	@id_descricao_atividade int,
	@codigo_prh char(70),
	@id_professor int,
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@id_avaliaçoes int,
	@estado varchar(50)
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPrh
	where id_prh=@id_prh

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tblPrh 
		set id_principal=@id_principal,id_descricao_atividade=@id_descricao_atividade,id_avaliaçoes=@id_avaliaçoes,codigo_prh=@codigo_prh,id_professor=@id_professor,id_aluno=@id_aluno,id_turma=@id_turma,id_dt=@id_dt,estado=@estado
		where id_prh=@id_prh
		select 1 as ReturnCode10
	END
END
GO
PRINT N'Creating [dbo].[sp_GetPrhEstadoByID]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrhEstadoByID]
	@id_prh int

AS
begin
		select * From tblPrh where id_prh=@id_prh
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
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6f7f3bdd-96d6-445e-abeb-6dc95d56e019')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6f7f3bdd-96d6-445e-abeb-6dc95d56e019')

GO

GO
PRINT N'Update complete.';


GO
