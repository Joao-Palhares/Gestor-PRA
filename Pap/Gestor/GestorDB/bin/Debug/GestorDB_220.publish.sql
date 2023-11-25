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
The type for column disciplina_modulo in table [dbo].[tblPraDM] is currently  VARCHAR (50) NOT NULL but is being changed to  INT NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[tblPraDM])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[tblPraDM]...';


GO
ALTER TABLE [dbo].[tblPraDM] ALTER COLUMN [disciplina_modulo] INT NOT NULL;


GO
PRINT N'Altering [dbo].[sp_InsertDM]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDM]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode2
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDM2]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDM2]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode22
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDM3]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDM3]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode23
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDM4]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDM4]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode24
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDM5]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDM5]
	@disciplina_modulo int,
	@faltas_excesso int,
	@dmcode char(50),
	@id_professor int,
	@id_pra int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_dm) FROM tblPraDM

	IF(@count<>0)
	begin 
		select -1 as ReturnCode2
	End
	Begin
		Insert INTO [dbo].[tblPraDM]
				([disciplina_modulo],
				[faltas_excesso],
				[dmcode],
				[id_professor],
				[id_pra])
		Values (@disciplina_modulo,@faltas_excesso,@dmcode,@id_professor,@id_pra)
		select 1 as ReturnCode25
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDMByID1]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDMByID1]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode, id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDMByID2]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDMByID2]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode , id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDMByID3]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDMByID3]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode, id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDMByID4]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDMByID4]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode, id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDMByID5]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDMByID5]
	@id_dm int,
	@disciplina_modulo int,
	@faltas_excesso int,
	@assinatura_professor_disciplina varchar(50),
	@data_assinatura date,
	@avaliaçao varchar(50),
	@retido varchar(50),
	@id_pra int,
	@dmcode char(50),
	@id_professor int

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tblPraDM
	where id_dm=@id_dm

	if(@count=0)
		begin
			select -1 as ReturnCode
		End
	Else
	Begin
		update tblPraDM 
		set disciplina_modulo=@disciplina_modulo , faltas_excesso = @faltas_excesso, assinatura_professor_disciplina = @assinatura_professor_disciplina, data_assinatura= @data_assinatura, avaliaçao = @avaliaçao, retido=@retido, id_pra=@id_pra, dmcode=@dmcode, id_professor=@id_professor
		where id_dm=@id_dm
		select 1 as ReturnCode
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetDMByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByCode]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByCode2]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByCode2]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByCode3]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByCode3]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByCode4]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByCode4]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByCode5]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByCode5]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByID1]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByID1]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByID2]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByID2]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByID3]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByID3]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByID4]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByID4]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByID5]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByID5]';


GO
PRINT N'Refreshing [dbo].[sp_GetDMByPra]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDMByPra]';


GO
PRINT N'Update complete.';


GO