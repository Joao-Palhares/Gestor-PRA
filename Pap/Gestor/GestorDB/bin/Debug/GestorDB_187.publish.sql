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
PRINT N'Altering [dbo].[sp_InsertPra]...';


GO
ALTER PROCEDURE [dbo].[sp_InsertPra]
	@id_principal int,
	@codigo_pra varchar(20),
	@id_aluno int,
	@id_turma int,
	@id_dt int,
	@estado varchar(100),
	@progresso varchar(100)

AS
Begin
	Declare @count int
	SELECT @count= COUNT(id_pra) FROM tblPra 

	IF(@count<>0)
	begin 
		select -1 as ReturnCodepra
	End
	Begin
		Insert INTO [dbo].[tblPra]
				([id_principal],
				[codigo_pra],
				[id_aluno],
				[id_turma],
				[id_dt],
				[estado],
				[progresso])
		Values (@id_principal,@codigo_pra,@id_aluno,@id_turma,@id_dt,@estado,@progresso)
		select 1 as ReturnCodepra
	END
END
GO
PRINT N'Update complete.';


GO