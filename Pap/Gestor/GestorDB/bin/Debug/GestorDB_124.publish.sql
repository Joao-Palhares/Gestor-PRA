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
PRINT N'Altering [dbo].[sp_InsertTurma]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertTurma]
	@id_curso int,
	@ano_escolaridade int,
	@nome_turma varchar(100)
AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_curso) FROM tblTurmas Where nome_turma=@nome_turma

	IF(@count<>0)
	begin 
		select -1 as ReturnCode
	End
	Begin
		Insert INTO [dbo].[tblTurmas]
				([id_curso],
				[ano_escolaridade],
				[nome_turma])
		Values (@id_curso,@ano_escolaridade,@nome_turma)
		select 1 as ReturnCode
	END
END
GO
PRINT N'Creating [dbo].[sp_UpdateTurmaByID]...';


GO
CREATE PROCEDURE [dbo].[sp_UpdateTurmaByID]
	@id_turma int,
	@ano_escolaridade int,
	@id_curso int,
	@diretor_turma int,
	@nome_turma varchar(100)
AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblTurmas
	where id_turma=@id_turma

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblTurmas 
		set ano_escolaridade=@ano_escolaridade , id_curso=@id_curso , diretor_turma=@diretor_turma,nome_turma=@nome_turma
		where id_turma=@id_turma
		select 1 as ReturnCode
	END
END
GO
PRINT N'Update complete.';


GO