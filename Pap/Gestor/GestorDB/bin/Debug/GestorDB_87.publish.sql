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
The column [dbo].[tbldescricaoatividades].[horario_final] is being dropped, data loss could occur.

The column [dbo].[tbldescricaoatividades].[horario_inicial] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[tbldescricaoatividades])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[tbldescricaoatividades]...';


GO
ALTER TABLE [dbo].[tbldescricaoatividades] DROP COLUMN [horario_final], COLUMN [horario_inicial];


GO
ALTER TABLE [dbo].[tbldescricaoatividades] ALTER COLUMN [data_final] DATETIME NOT NULL;

ALTER TABLE [dbo].[tbldescricaoatividades] ALTER COLUMN [data_inicio] DATETIME NOT NULL;


GO
PRINT N'Altering [dbo].[sp_InsertDescricaoatividades]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDescricaoatividades]
	@atividades varchar(1000),
	@local varchar(1000),
	@data_inicio date,
	@data_final date,
	@codigo_descricao char(50)

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades

	IF(@count<>0)
	begin 
		select -1 as ReturnCode21
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([atividades],
				[local],
				[data_inicio],
				[data_final],
				[codigo_descricao])
		Values (@atividades,@local,@data_inicio,@data_final,@codigo_descricao)
		select 1 as ReturnCode21
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDescricaoatividades2]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDescricaoatividades2]
	@id_descriçao_atividade int,
	@atividades varchar(300),
	@local varchar(100),
	@data_inicio date,
	@data_final date,
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades Where id_descriçao_atividade=@id_descriçao_atividade

	IF(@count<>0)
	begin 
		select -1 as ReturnCode22
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([id_descriçao_atividade],
				[atividades],
				[local],
				[data_inicio],
				[data_final],
				[id_prh])
		Values (@id_descriçao_atividade,@atividades,@local,@data_inicio,@data_final,@id_prh)
		select 1 as ReturnCode22
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDescricaoatividades3]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDescricaoatividades3]
	@id_descriçao_atividade int,
	@atividades varchar(300),
	@local varchar(100),
	@data_inicio date,
	@data_final date,
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades Where id_descriçao_atividade=@id_descriçao_atividade

	IF(@count<>0)
	begin 
		select -1 as ReturnCode23
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([id_descriçao_atividade],
				[atividades],
				[local],
				[data_inicio],
				[data_final],
				[id_prh])
		Values (@id_descriçao_atividade,@atividades,@local,@data_inicio,@data_final,@id_prh)
		select 1 as ReturnCode23
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDescricaoatividades4]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDescricaoatividades4]
	@id_descriçao_atividade int,
	@atividades varchar(300),
	@local varchar(100),
	@data_inicio date,
	@data_final date,
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades Where id_descriçao_atividade=@id_descriçao_atividade

	IF(@count<>0)
	begin 
		select -1 as ReturnCode24
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([id_descriçao_atividade],
				[atividades],
				[local],
				[data_inicio],
				[data_final],
				[id_prh])
		Values (@id_descriçao_atividade,@atividades,@local,@data_inicio,@data_final,@id_prh)
		select 1 as ReturnCode24
	END
END
GO
PRINT N'Altering [dbo].[sp_InsertDescricaoatividades5]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertDescricaoatividades5]
	@id_descriçao_atividade int,
	@atividades varchar(300),
	@local varchar(100),
	@data_inicio date,
	@data_final date,
	@id_prh int

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_descriçao_atividade) FROM tbldescricaoatividades Where id_descriçao_atividade=@id_descriçao_atividade

	IF(@count<>0)
	begin 
		select -1 as ReturnCode25
	End
	Begin
		Insert INTO [dbo].[tbldescricaoatividades]
				([id_descriçao_atividade],
				[atividades],
				[local],
				[data_inicio],
				[data_final],
				[id_prh])
		Values (@id_descriçao_atividade,@atividades,@local,@data_inicio,@data_final,@id_prh)
		select 1 as ReturnCode25
	END
END
GO
PRINT N'Altering [dbo].[sp_UpdateDescricaoAtividadesByID]...';


GO
ALTER PROCEDURE [dbo].[sp_UpdateDescricaoAtividadesByID]
	@id_descriçao_atividade int,
	@atividades varchar(1000),
	@local varchar(1000),
	@data_inicio date,
	@data_final date,
	@id_prh int,
	@codigo_descricao char(50)

AS
begin
	declare @count int 
	SELECT @count = COUNT (*) from tbldescricaoatividades
	where id_descriçao_atividade=@id_descriçao_atividade

	if(@count=0)
		begin
			select -1 as ReturnCode100
		End
	Else
	Begin
		update tbldescricaoatividades 
		set atividades=@atividades,local=@local,data_inicio=@data_inicio,data_final=@data_final,id_prh=@id_prh,codigo_descricao=@codigo_descricao
		where id_descriçao_atividade=@id_descriçao_atividade
		select 1 as ReturnCode10
	END
END
GO
PRINT N'Refreshing [dbo].[sp_GetDescricaoAtividadesByCode]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_GetDescricaoAtividadesByCode]';


GO
PRINT N'Update complete.';


GO
