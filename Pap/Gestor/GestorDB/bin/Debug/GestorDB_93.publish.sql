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
The column [dbo].[tblPrh].[id_aluno] on table [dbo].[tblPrh] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[tblPrh].[id_turma] on table [dbo].[tblPrh] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column id_professor on table [dbo].[tblPrh] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblPrh])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[tblPrh]...';


GO
ALTER TABLE [dbo].[tblPrh] ALTER COLUMN [id_professor] INT NOT NULL;


GO
ALTER TABLE [dbo].[tblPrh]
    ADD [id_aluno] INT NOT NULL,
        [id_turma] INT NOT NULL;


GO
PRINT N'Altering [dbo].[sp_InsertPrh]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertPrh]
	@id_principal int,
	@codigo_prh varchar(70),
	@id_professor int,
	@id_aluno int,
	@id_turma int,
	@id_descricao_atividade int


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
				[id_descricao_atividade],
				[codigo_prh],
				[id_professor],
				[id_aluno],
				[id_turma])
		Values (@id_principal,@id_descricao_atividade,@codigo_prh,@id_professor,@id_aluno,@id_turma)
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
	@id_avaliaçoes int
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
		set id_principal=@id_principal,id_descricao_atividade=@id_descricao_atividade,codigo_prh=@codigo_prh,id_professor=@id_professor,id_avaliaçoes=@id_avaliaçoes,id_turma=@id_turma,id_turma=@id_turma
		where id_prh=@id_prh
		select 1 as ReturnCode10
	END
END
GO
PRINT N'Creating [dbo].[sp_GetPrhs]...';


GO
CREATE PROCEDURE [dbo].[sp_GetPrhs]
AS
BEGIN
	SELECT * FROM tblPrh
END
GO
PRINT N'Refreshing [dbo].[sp_GetPrhByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetPrhByCode]';


GO
PRINT N'Update complete.';


GO
